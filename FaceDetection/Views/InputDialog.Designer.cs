namespace FaceDetection.Views
{
	partial class InputDialog
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
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.TextBoxName = new System.Windows.Forms.TextBox();
			this.dialogInfo = new System.Windows.Forms.Label();
			this.faceImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.faceImage)).BeginInit();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(163, 173);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(12, 173);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// TextBoxName
			// 
			this.TextBoxName.Location = new System.Drawing.Point(12, 145);
			this.TextBoxName.Name = "TextBoxName";
			this.TextBoxName.Size = new System.Drawing.Size(226, 22);
			this.TextBoxName.TabIndex = 2;
			// 
			// dialogInfo
			// 
			this.dialogInfo.AutoSize = true;
			this.dialogInfo.Location = new System.Drawing.Point(12, 126);
			this.dialogInfo.Name = "dialogInfo";
			this.dialogInfo.Size = new System.Drawing.Size(96, 16);
			this.dialogInfo.TabIndex = 3;
			this.dialogInfo.Text = "Enter the name";
			// 
			// faceImage
			// 
			this.faceImage.Location = new System.Drawing.Point(71, 12);
			this.faceImage.Name = "faceImage";
			this.faceImage.Size = new System.Drawing.Size(100, 100);
			this.faceImage.TabIndex = 4;
			this.faceImage.TabStop = false;
			// 
			// InputDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(250, 210);
			this.Controls.Add(this.faceImage);
			this.Controls.Add(this.dialogInfo);
			this.Controls.Add(this.TextBoxName);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputDialog";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.faceImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TextBox TextBoxName;
		private System.Windows.Forms.Label dialogInfo;
		private System.Windows.Forms.PictureBox faceImage;
	}
}