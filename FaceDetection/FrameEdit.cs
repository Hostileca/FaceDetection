using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV.Face;
using Emgu.CV.Util;

namespace FaceDetection
{
	public class FrameEdit
	{
		public bool isEnabledRotation { get; set; }
		public bool IsEnabledDetection { get; set; }
		public bool IsEnabledRecognation { get; set; }

		private CascadeClassifier _cascadeClassifier;
		private EigenFaceRecognizer recognizer;
		private VectorOfMat imageList = new VectorOfMat();
		private List<string> personsNamesList = new List<string>();
		private VectorOfInt labelList = new VectorOfInt();

		public List<FaceData> detectedPersons = new List<FaceData>();


		public FrameEdit(CascadeClassifier cascadeClassifier, VectorOfMat imageList, List<string> personsNamesList, VectorOfInt labelList)
		{
			_cascadeClassifier = cascadeClassifier;
			isEnabledRotation = true;
			IsEnabledDetection = false;
			IsEnabledRecognation = false;
			this.imageList = imageList;
			this.personsNamesList = personsNamesList;
			this.labelList = labelList;

			if (imageList.Size > 0)
			{
				recognizer = new EigenFaceRecognizer(imageList.Size);
				recognizer.Train(imageList, labelList);
			}
		}


		public Bitmap BitmapAnalyze(Bitmap bitmap)
		{
			detectedPersons.Clear();
			bitmap = isEnabledRotation ? bitmap = Rotation(bitmap) : bitmap;
			bitmap = IsEnabledDetection ? bitmap = Detection(bitmap) : bitmap;
			bitmap = IsEnabledRecognation ? bitmap = Recognation(bitmap) : bitmap;

			return bitmap;
		}

		private Bitmap Rotation(Bitmap bitmap)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
			return bitmap;
		}
		private Bitmap Detection(Bitmap bitmap)
		{

			Image<Gray, byte> grayImage = new Image<Gray, Byte>(bitmap);
			Rectangle[] rectangles = _cascadeClassifier.DetectMultiScale(grayImage, 1.5, 3);

			foreach (var rectangle in rectangles)
			{
				var image = new Image<Gray, Byte>(bitmap.Clone(rectangle, bitmap.PixelFormat));
				detectedPersons.Add(new FaceData(image));

				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (Pen pen = new Pen(Color.Red, 1))
					{
						graphics.DrawRectangle(pen, rectangle);
					}
				}
			}

			return bitmap;
		}

		private Bitmap Recognation(Bitmap bitmap)
		{
			foreach (var item in detectedPersons)
			{
				if (recognizer != null)
				{
					FaceRecognizer.PredictionResult result = recognizer.Predict(item.FaceImage.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));
					item.PersonName = personsNamesList[result.Label];
				}
			}
			return bitmap;
		}
	}
}
