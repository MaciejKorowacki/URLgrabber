using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace URLgrabberTEST
{
    public partial class Form1 : Form
    {
        private bool autoGrabEnabled = false;
        private readonly string urlsFile = "urls.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo_image.png");
                if (File.Exists(logoPath))
                    logoPictureBox.Image = Image.FromFile(logoPath);
                else
                    logoPictureBox.Visible = false;
            }
            catch
            {
                logoPictureBox.Visible = false;
            }
            // --- AUTOGRAB STATUS LABEL ---
            autograbStatusLabel.Text = "Autograb status: OFF";

            // Autograb menu checkbox
            autograbMenuItem.Checked = autoGrabEnabled;
            autograbMenuItem.CheckedChanged += (s, ev) =>
            {
                autoGrabEnabled = autograbMenuItem.Checked;
                autograbStatusLabel.Text = $"Autograb status: {(autoGrabEnabled ? "ON" : "OFF")}";
            };

            // Hide browser initially
            webView.Visible = false;
            splitContainer.Visible = false;

            // Show logo splash
            logoPictureBox.Visible = true;
            logoLabel.Visible = true;

            // Menu items
            loadMenuItem.Click += (s, ev) => LoadUrlsFromFileDialog();
            saveMenuItem.Click += (s, ev) => SaveUrlsToFileDialog();
            clearMenuItem.Click += (s, ev) =>
            {
                urlTreeView.Nodes.Clear();
                UpdateStatus();
                SaveUrlsToFile();
            };
            exitMenuItem.Click += (s, ev) => Close();

            // Help menu
            githubMenuItem.Click += (s, ev) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://github.com/MaciejKorowacki/repo_url_grabber",
                        UseShellExecute = true
                    });
                }
                catch { }
            };
            aboutMenuItem.Click += (s, ev) =>
            {
                MessageBox.Show("URLGrabber\nVersion 1.0\n© 2025 Maciej Korowacki", "About URLGrabber",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Go button & URL textbox
            goButton.Click += (s, ev) => NavigateToUrl();
            urlTextBox.KeyDown += UrlTextBox_KeyDown;

            // Back button
            backButton.Click += (s, ev) => { if (webView.CanGoBack) webView.GoBack(); };

            // Add button
            addButton.Click += (s, ev) => PromptAddLink();

            // TreeView double click navigation
            urlTreeView.NodeMouseDoubleClick += (s, ev) =>
            {
                if (ev.Node != null && !string.IsNullOrEmpty(ev.Node.Name))
                    NavigateTo(ev.Node.Name);
            };

            // TreeView right-click dynamic context menu
            urlTreeView.MouseUp += UrlTreeView_MouseUp;

            // Initialize WebView2
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            // Capture link right-clicks from web pages
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"
                document.addEventListener('contextmenu', function(e) {
                    let target = e.target;
                    while(target) {
                        if(target.tagName === 'A' && target.href) {
                            e.preventDefault();
                            chrome.webview.postMessage(target.href);
                            break;
                        }
                        target = target.parentElement;
                    }
                });
            ");

            webView.CoreWebView2.WebMessageReceived += (s, ev) =>
            {
                string linkUrl = ev.TryGetWebMessageAsString()?.ToLower();
                if (!string.IsNullOrEmpty(linkUrl))
                {
                    if (autoGrabEnabled)
                        AddLink(linkUrl);
                    else
                    {
                        ContextMenuStrip tempMenu = new ContextMenuStrip();
                        tempMenu.Items.Add("Add link", null, (o, a) => AddLink(linkUrl));
                        tempMenu.Show(Cursor.Position);
                    }
                }
            };

            // Clear and load previous links
            urlTreeView.Nodes.Clear();
            if (File.Exists(urlsFile))
            {
                string[] savedLinks = File.ReadAllLines(urlsFile);
                foreach (var link in savedLinks)
                    if (!string.IsNullOrWhiteSpace(link))
                        AddLink(link.Trim());
            }
        }

        private void UrlTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = urlTreeView.GetNodeAt(e.X, e.Y);
                treeContextMenu.Items.Clear();

                if (node != null)
                {
                    urlTreeView.SelectedNode = node;
                    treeContextMenu.Items.Add("Remove this link", null, (s, ev) =>
                    {
                        urlTreeView.Nodes.Remove(node);
                        UpdateStatus();
                        SaveUrlsToFile();
                    });
                    treeContextMenu.Items.Add("Rename this link", null, (s, ev) =>
                    {
                        node.BeginEdit();
                    });
                }
                else
                {
                    treeContextMenu.Items.Add("Add a link", null, (s, ev) => PromptAddLink());
                }

                treeContextMenu.Show(urlTreeView, e.Location);
            }
        }

        private void PromptAddLink()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the URL:", "Add Link", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                AddLink(input.Trim());
                SaveUrlsToFile();
            }
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            urlTextBox.Text = e.Uri;
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavigateToUrl();
            }
        }

        private void NavigateToUrl()
        {
            string url = urlTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(url))
                NavigateTo(url);
        }

        private void NavigateTo(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            // Hide splash
            logoPictureBox.Visible = false;
            logoLabel.Visible = false;
            webView.Visible = true;
            splitContainer.Visible = true;

            webView.CoreWebView2.Navigate(url);
        }

        private void AddLink(string url)
        {
            if (urlTreeView.Nodes.ContainsKey(url)) return;
            TreeNode node = new TreeNode(url) { Name = url };
            urlTreeView.Nodes.Add(node);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            statusLabel.Text = $"Links: {urlTreeView.Nodes.Count}";
        }

        private void SaveUrlsToFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Title = "Save URLs to file";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new StreamWriter(dlg.FileName))
                        {
                            foreach (TreeNode node in urlTreeView.Nodes)
                                writer.WriteLine(node.Name);
                        }
                        statusLabel.Text = $"Saved {urlTreeView.Nodes.Count} links to {dlg.FileName}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message);
                    }
                }
            }
        }

        private void LoadUrlsFromFileDialog()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Title = "Load URLs from file";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        urlTreeView.Nodes.Clear();
                        string[] lines = File.ReadAllLines(dlg.FileName);
                        foreach (var line in lines)
                            if (!string.IsNullOrWhiteSpace(line))
                                AddLink(line.Trim());
                        UpdateStatus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading file: " + ex.Message);
                    }
                }
            }
        }

        private void SaveUrlsToFile()
        {
            try
            {
                using (var writer = new StreamWriter(urlsFile))
                {
                    foreach (TreeNode node in urlTreeView.Nodes)
                        writer.WriteLine(node.Name);
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save URLs before exit?", "Confirm", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
                SaveUrlsToFile();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
