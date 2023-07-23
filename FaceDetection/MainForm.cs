using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using FaceDetection.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FaceDetection
{
	public partial class mainForm : Form
	{
		#region Properties
		private FilterInfoCollection filterInfoCollection;
		private VideoCaptureDevice videoCaptureDevice;

		private CascadeClassifier cascadeClassifier = new CascadeClassifier(Config.cascadeClassifier);

		private FrameEdit faceDetector;

		private List<Tuple<PictureBox, Label>> detectedPersonsBoxes = new List<Tuple<PictureBox, Label>>();


		#endregion

		#region Constructors
		public mainForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Events
		private void Window_Load(object sender, EventArgs e)
		{
			//load list of devices
			filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			foreach(FilterInfo filterInfo in filterInfoCollection)
			{
				var newDevice = devicesToolStripMenuItem.DropDownItems.Add(filterInfo.Name);
				newDevice.Click += DeviceChoose_Click;
			}
			videoCaptureDevice = new VideoCaptureDevice();

			//load for recognation
			string line;
			VectorOfMat imageList = new VectorOfMat();
			List<string> personsNamesList = new List<string>();
			VectorOfInt labelList = new VectorOfInt();

			if (!Directory.Exists(Config.FacePhotosPath))
			{
				Directory.CreateDirectory(Config.FacePhotosPath);
			}

			if (!File.Exists(Config.PersonsListTextFile))
			{
				File.Create(Config.PersonsListTextFile);
			}

			StreamReader reader = new StreamReader(Config.PersonsListTextFile);
			int i = 0;
			while ((line = reader.ReadLine()) != null)
			{
				string[] lineParts = line.Split(':');
				imageList.Push(new Image<Gray, byte>(Config.FacePhotosPath + lineParts[0] + Config.ImageFileExtension));
				personsNamesList.Add(lineParts[1]);
				labelList.Push(new[] { i++ });
			}
			reader.Close();


			faceDetector = new FrameEdit(cascadeClassifier,imageList,personsNamesList,labelList);

			OutputBox.Size = new Size(this.Width,this.Height);
		}

		private void DeviceChoose_Click(object sender, EventArgs e)
		{
			var currentItem = sender as ToolStripMenuItem;
			
			if (currentItem != null && !currentItem.Checked)
			{
				int forFindSelectedItem = 0;
				int foundedItemNumber = 0;
				((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems
					.OfType<ToolStripMenuItem>().ToList()
					.ForEach(item =>
					{
						if(item.Text==currentItem.Text)
						{
							foundedItemNumber = forFindSelectedItem;
						}
						forFindSelectedItem++;
						item.Checked = false;
					});

				currentItem.Checked = true;

				var a = currentItem.Owner;

				videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[foundedItemNumber].MonikerString);
				videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
				videoCaptureDevice.Start();
			}
		}

		private void MainForm_Closing(object sender, FormClosingEventArgs e)
		{
			if (videoCaptureDevice.IsRunning)
			{
				videoCaptureDevice.Stop();
			}
			
		}

		private void enableFaceDetectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (enableFaceDetectionToolStripMenuItem.Checked)
			{
				enableFaceDetectionToolStripMenuItem.Checked = false;
				faceDetector.IsEnabledDetection = false;
				//detectedPersonsPanelUpdateTimer.Enabled = false;
			}
			else
			{
				enableFaceDetectionToolStripMenuItem.Checked = true;
				faceDetector.IsEnabledDetection = true;
				//detectedPersonsPanelUpdateTimer.Enabled = true;
			}
		}

		private void enableFaceRecognationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (enableFaceRecognationToolStripMenuItem.Checked)
			{
				enableFaceRecognationToolStripMenuItem.Checked = false;
				faceDetector.IsEnabledRecognation = false;
			}
			else
			{
				enableFaceRecognationToolStripMenuItem.Checked = true;
				faceDetector.IsEnabledRecognation = true;
			}
		}

		private void detectedPerson_Click(object sender, EventArgs e)
		{
			//Application.Exit();
			PictureBox s = (PictureBox)sender;
			using (InputDialog dialog = new InputDialog(s.Image))
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					string inputText = dialog.InputText;

					// Ваш код обработки введенного текста здесь
					// Пример:
					MessageBox.Show("Вы ввели следующий текст: " + inputText);
				}
			}
		}

		#endregion

		#region FrameUpdater
		private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
			OutputBox.Image = faceDetector.BitmapAnalyze(bitmap);
			UpdateDetectedPersonsPanel();

		}


		private readonly object personsPanelLock = new object();
		private void UpdateDetectedPersonsPanel()
		{
			lock (personsPanelLock)
			{
				BeginInvoke(new Action(() =>
				{
					List<FaceData> detectedPersonsCopy = new List<FaceData>(faceDetector.detectedPersons);
					int count = 0;
					int Y = 0;
					int X = 0;

					if (detectedPersonsCopy.Count < detectedPersonsBoxes.Count)
					{
						personsPanel.Controls.Clear();
						detectedPersonsBoxes.Clear();
					}

					while (detectedPersonsCopy.Count > detectedPersonsBoxes.Count)
					{

						var newPictureBox = new PictureBox
						{
							Name = "detectedpersonface",
							Size = new Size(100, 100),
							Location = new Point(X, Y),
							SizeMode = PictureBoxSizeMode.StretchImage,
						};
						newPictureBox.Click += detectedPerson_Click;

						var newLabel = new Label
						{
							Name = "detectedpersonname",
							Location = new Point(X, Y + 100),
						};

						detectedPersonsBoxes.Add(new Tuple<PictureBox, Label>(newPictureBox, newLabel));
						personsPanel.Controls.Add(newPictureBox);
						personsPanel.Controls.Add(newLabel);
						X += 130;
						if (count % 2 == 1)
						{
							X = 0;
							Y += 180;
						}
						count++;
					}

					if (detectedPersonsBoxes.Count != detectedPersonsCopy.Count) { return; }
					for (int itemId = 0; itemId < detectedPersonsBoxes.Count; itemId++)
					{
						detectedPersonsBoxes[itemId].Item1.Image = detectedPersonsCopy[itemId].FaceImage.ToBitmap();
						detectedPersonsBoxes[itemId].Item2.Text = detectedPersonsCopy[itemId].PersonName;
					}

				}));
			}
		}




		#endregion
	}
}
