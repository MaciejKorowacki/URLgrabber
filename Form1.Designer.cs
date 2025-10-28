namespace URLgrabberTEST
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TreeView urlTreeView;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton autoGrabToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;

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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.autoGrabToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);

            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();

            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoGrabToolStripButton,
            this.loadToolStripButton,
            this.saveToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1400, 25);
            this.toolStrip.TabIndex = 0;

            // 
            // autoGrabToolStripButton
            // 
            this.autoGrabToolStripButton.CheckOnClick = true;
            this.autoGrabToolStripButton.Text = "Autograb";

            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.Text = "Load";

            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Text = "Save";

            // 
            // webView
            // 
            this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webView.Location = new System.Drawing.Point(10, 60);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1100, 700);
            this.webView.TabIndex = 1;

            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(10, 30);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(1000, 23);
            this.urlTextBox.TabIndex = 2;

            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1020, 29);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(90, 25);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;

            // 
            // urlTreeView
            // 
            this.urlTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTreeView.Location = new System.Drawing.Point(1120, 30);
            this.urlTreeView.Name = "urlTreeView";
            this.urlTreeView.Size = new System.Drawing.Size(260, 730);
            this.urlTreeView.TabIndex = 4;

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 770);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1400, 22);
            this.statusStrip.TabIndex = 5;

            // 
            // statusLabel
            // 
            this.statusLabel.Text = "Ready";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.urlTreeView);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "WebView2 Grabber";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
