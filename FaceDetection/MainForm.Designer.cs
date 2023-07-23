namespace FaceDetection
{
	partial class mainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Menu = new System.Windows.Forms.MenuStrip();
			this.devicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableFaceDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableFaceRecognationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OutputBox = new System.Windows.Forms.PictureBox();
			this.personsPanel = new System.Windows.Forms.Panel();
			this.Menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OutputBox)).BeginInit();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// Menu
			// 
			this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devicesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.Menu.Location = new System.Drawing.Point(0, 0);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(1155, 28);
			this.Menu.TabIndex = 4;
			this.Menu.Text = "Menu";
			// 
			// devicesToolStripMenuItem
			// 
			this.devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
			this.devicesToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
			this.devicesToolStripMenuItem.Text = "Devices";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableFaceDetectionToolStripMenuItem,
            this.enableFaceRecognationToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// enableFaceDetectionToolStripMenuItem
			// 
			this.enableFaceDetectionToolStripMenuItem.Name = "enableFaceDetectionToolStripMenuItem";
			this.enableFaceDetectionToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.enableFaceDetectionToolStripMenuItem.Text = "Enable face detection";
			this.enableFaceDetectionToolStripMenuItem.Click += new System.EventHandler(this.enableFaceDetectionToolStripMenuItem_Click);
			// 
			// enableFaceRecognationToolStripMenuItem
			// 
			this.enableFaceRecognationToolStripMenuItem.Name = "enableFaceRecognationToolStripMenuItem";
			this.enableFaceRecognationToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.enableFaceRecognationToolStripMenuItem.Text = "Enable face recognation";
			this.enableFaceRecognationToolStripMenuItem.Click += new System.EventHandler(this.enableFaceRecognationToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// OutputBox
			// 
			this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.OutputBox.Location = new System.Drawing.Point(0, 31);
			this.OutputBox.Name = "OutputBox";
			this.OutputBox.Size = new System.Drawing.Size(851, 443);
			this.OutputBox.TabIndex = 2;
			this.OutputBox.TabStop = false;
			// 
			// personsPanel
			// 
			this.personsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.personsPanel.Location = new System.Drawing.Point(857, 31);
			this.personsPanel.Name = "personsPanel";
			this.personsPanel.Size = new System.Drawing.Size(298, 443);
			this.personsPanel.TabIndex = 5;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1155, 486);
			this.Controls.Add(this.personsPanel);
			this.Controls.Add(this.OutputBox);
			this.Controls.Add(this.Menu);
			this.MainMenuStrip = this.Menu;
			this.MaximumSize = new System.Drawing.Size(1173, 533);
			this.MinimumSize = new System.Drawing.Size(1173, 533);
			this.Name = "mainForm";
			this.Text = "FaceDetector";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.Window_Load);
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.OutputBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.MenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enableFaceDetectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enableFaceRecognationToolStripMenuItem;
		private System.Windows.Forms.PictureBox OutputBox;
		private System.Windows.Forms.Panel personsPanel;
	}
}

