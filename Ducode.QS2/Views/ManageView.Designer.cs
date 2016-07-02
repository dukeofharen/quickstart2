namespace Ducode.QS2.Views
{
    partial class ManageView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageView));
            this.managePanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.itemsFolderLocation = new System.Windows.Forms.Label();
            this.addCommandButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // managePanel
            // 
            this.managePanel.AutoScroll = true;
            this.managePanel.Location = new System.Drawing.Point(18, 129);
            this.managePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.managePanel.Name = "managePanel";
            this.managePanel.Size = new System.Drawing.Size(1298, 507);
            this.managePanel.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(18, 646);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(165, 35);
            this.saveButton.TabIndex = 1;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(18, 14);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 20);
            this.titleLabel.TabIndex = 2;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(18, 38);
            this.selectFolderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(165, 35);
            this.selectFolderButton.TabIndex = 3;
            this.selectFolderButton.UseVisualStyleBackColor = true;
            // 
            // itemsFolderLocation
            // 
            this.itemsFolderLocation.AutoSize = true;
            this.itemsFolderLocation.Location = new System.Drawing.Point(192, 46);
            this.itemsFolderLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemsFolderLocation.Name = "itemsFolderLocation";
            this.itemsFolderLocation.Size = new System.Drawing.Size(51, 20);
            this.itemsFolderLocation.TabIndex = 4;
            this.itemsFolderLocation.Text = "label2";
            // 
            // addCommandButton
            // 
            this.addCommandButton.Location = new System.Drawing.Point(18, 83);
            this.addCommandButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addCommandButton.Name = "addCommandButton";
            this.addCommandButton.Size = new System.Drawing.Size(165, 35);
            this.addCommandButton.TabIndex = 5;
            this.addCommandButton.UseVisualStyleBackColor = true;
            this.addCommandButton.Click += new System.EventHandler(this.addCommandButton_Click);
            // 
            // ManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 705);
            this.Controls.Add(this.addCommandButton);
            this.Controls.Add(this.itemsFolderLocation);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.managePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManageView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel managePanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.Label itemsFolderLocation;
        private System.Windows.Forms.Button addCommandButton;
    }
}