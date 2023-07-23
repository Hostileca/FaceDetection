using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FaceDetection.Views
{
	public partial class InputDialog : Form
	{

		public string InputText { get { return TextBoxName.Text; } }


		public InputDialog(Image FaceImage)
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Enabled = true;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Input Dialog";
			ClientSize = new Size(190, 180);
			faceImage.SizeMode = PictureBoxSizeMode.StretchImage;
			faceImage.Image = FaceImage;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			Image<Gray, Byte> detectedFace = new Image<Gray,Byte>(new Bitmap(faceImage.Image));
			detectedFace = detectedFace.Resize(100, 100, Inter.Cubic);
			detectedFace.Save(Config.FacePhotosPath + "face" + (InputText) + Config.ImageFileExtension);
			StreamWriter writer = new StreamWriter(Config.PersonsListTextFile, true);
			writer.WriteLine(String.Format("face{0}:{1}", (InputText), InputText));
			writer.Close();
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
