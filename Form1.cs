using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace URLgrabberTEST
{
    public partial class Form1 : Form
    {
        private bool autoGrabEnabled = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // deafult Autograb
            autoGrabToolStripButton.Checked = false; // OFF
            autoGrabToolStripButton.Text = "Autograb: OFF";

            // Autograb toggle
            autoGrabToolStripButton.CheckedChanged += (s, ev) =>
            {
                autoGrabEnabled = autoGrabToolStripButton.Checked;
                autoGrabToolStripButton.Text = autoGrabEnabled ? "Autograb: ON" : "Autograb: OFF";
            };

            // save to file
            saveToolStripButton.Click += (s, ev) => SaveUrlsToFileDialog();

            // load from file
            loadToolStripButton.Click += (s, ev) => LoadUrlsFromFileDialog();

            // Go button
            goButton.Click += (s, ev) => NavigateToUrl();
            urlTextBox.KeyDown += UrlTextBox_KeyDown;

            // TreeView double click
            urlTreeView.NodeMouseDoubleClick += (s, ev) =>
            {
                if (ev.Node != null && !string.IsNullOrEmpty(ev.Node.Text))
                    NavigateTo(ev.Node.Text);
            };

            // Initialize WebView2
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            // JS context menu capture
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
                string linkUrl = ev.TryGetWebMessageAsString();
                if (!string.IsNullOrEmpty(linkUrl))
                {
                    if (autoGrabEnabled)
                        AddLink(linkUrl);
                    else
                    {
                        contextMenuStrip.Items.Clear();
                        contextMenuStrip.Items.Add("Add link", null, (o, a) => AddLink(linkUrl));
                        contextMenuStrip.Show(Cursor.Position);
                    }
                }
            };

            // Start with empty TreeView
            urlTreeView.Nodes.Clear();

            // Default page
            NavigateTo("https://www.ironpdf.com");
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

            webView.CoreWebView2.Navigate(url);
        }

        private void AddLink(string url)
        {
            if (!urlTreeView.Nodes.ContainsKey(url))
            {
                TreeNode node = new TreeNode(url) { Name = url };
                urlTreeView.Nodes.Add(node);
                UpdateStatus();
            }
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
                                writer.WriteLine(node.Text);
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
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                                AddLink(line.Trim());
                        }
                        statusLabel.Text = $"Loaded {urlTreeView.Nodes.Count} links from {dlg.FileName}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading file: " + ex.Message);
                    }
                }
            }
        }
        // pop-up to save urls. will add logic to check if they were saved prior to exiting if so pop-up wont show up.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save URLs before exit?", "Confirm", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaveUrlsToFileDialog();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
    }
}
