using Emgu.CV.Structure;
using Emgu.CV;
using System;

namespace FaceDetection
{
	public class FaceData
	{
		public string PersonName { get; set; }
		public Image<Gray, byte> FaceImage { get; set; }
		public DateTime CreateDate { get; set; }

		public FaceData(){
			PersonName = "Unknown";
		}
		public FaceData(Image<Gray, byte> faceImage)
		{
			PersonName = "Unknown";
			FaceImage = faceImage;
		}
	}
}
