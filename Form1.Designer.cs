namespace URLgrabberTEST
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TreeView urlTreeView;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel autograbStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameLinkMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem autograbMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem githubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;

        // --- Splash screen ---
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label logoLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.urlTreeView = new System.Windows.Forms.TreeView();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.autograbStatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.autograbMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.githubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // --- Splash controls ---
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.logoLabel = new System.Windows.Forms.Label();

            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu,
                this.optionsMenu,
                this.helpMenu
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1400, 24);

            // File Menu
            this.fileMenu.Text = "File";
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.loadMenuItem,
                this.saveMenuItem,
                this.clearMenuItem,
                this.exitMenuItem
            });
            this.loadMenuItem.Text = "Load";
            this.saveMenuItem.Text = "Save";
            this.clearMenuItem.Text = "Clear";
            this.exitMenuItem.Text = "Exit";

            // Options Menu
            this.optionsMenu.Text = "Options";
            this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.autograbMenuItem
            });
            this.autograbMenuItem.Text = "Autograb";
            this.autograbMenuItem.CheckOnClick = true;

            // Help Menu
            this.helpMenu.Text = "Help";
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.githubMenuItem,
                this.aboutMenuItem
            });
            this.githubMenuItem.Text = "Github";
            this.aboutMenuItem.Text = "About";

            // ToolStrip
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.autograbStatusLabel
            });
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1400, 25);
            this.autograbStatusLabel.Text = "Autograb status: OFF";

            // URL TextBox
            this.urlTextBox.Location = new System.Drawing.Point(10, 54);
            this.urlTextBox.Size = new System.Drawing.Size(1000, 23);
            this.urlTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Go Button
            this.goButton.Location = new System.Drawing.Point(1020, 53);
            this.goButton.Size = new System.Drawing.Size(90, 25);
            this.goButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.goButton.Text = "Go";

            // Back Button
            this.backButton.Location = new System.Drawing.Point(1120, 53);
            this.backButton.Size = new System.Drawing.Size(90, 25);
            this.backButton.Text = "Back";

            // Add Button
            this.addButton.Location = new System.Drawing.Point(1220, 53);
            this.addButton.Size = new System.Drawing.Size(90, 25);
            this.addButton.Text = "Add";

            // SplitContainer
            this.splitContainer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.splitContainer.Location = new System.Drawing.Point(10, 84);
            this.splitContainer.Size = new System.Drawing.Size(1380, 650);
            this.splitContainer.SplitterDistance = 1100;
            this.splitContainer.Panel1.Controls.Add(this.webView);
            this.splitContainer.Panel2.Controls.Add(this.urlTreeView);

            // WebView
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;

            // TreeView
            this.urlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTreeView.LabelEdit = true;
            this.urlTreeView.ContextMenuStrip = this.treeContextMenu;

            // TreeView Context Menu
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.addLinkMenuItem,
                this.removeLinkMenuItem,
                this.renameLinkMenuItem
            });
            this.addLinkMenuItem.Text = "Add a link";
            this.removeLinkMenuItem.Text = "Remove this link";
            this.renameLinkMenuItem.Text = "Rename this link";

            // StatusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 734);
            this.statusStrip.Size = new System.Drawing.Size(1400, 22);
            this.statusLabel.Text = "Ready";

            // --- Splash Logo ---
            this.logoPictureBox.Location = new System.Drawing.Point(400, 200);
            this.logoPictureBox.Size = new System.Drawing.Size(200, 200);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.Visible = true;

            this.logoLabel.Location = new System.Drawing.Point(400, 410);
            this.logoLabel.Size = new System.Drawing.Size(600, 50);
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.logoLabel.Text = "URLGrabber";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.logoLabel.Visible = true;

            // Form1
            this.ClientSize = new System.Drawing.Size(1400, 756);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.logoLabel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "URLGrabber";

            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
