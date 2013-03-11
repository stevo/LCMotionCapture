using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging; 
using System.IO;
using DexterLib;

namespace FinalApp1
{
	/// <summary>
	/// MediaDetWrapper is a class wrapping MediaDet library (DirectShow).
	/// Interop.DexterLib.dll is required (Project->Add Reference)
	/// </summary>

	public class MDWrapper
	{
		//public variables
		public  string nazwa_pliku; 
		
		//private variables
		private double FrameRate;
		private double MediaLength;
		public  MediaDetClass mD;
		
		//constructor
	    public MDWrapper(string nazwa_pliku)
		{
			mD = new MediaDetClass();
			mD.Filename=nazwa_pliku;
			mD.CurrentStream = 0;
            
			FrameRate=mD.FrameRate; //in fps
			MediaLength=mD.StreamLength; //in seconds
		}


		//grabs frame at certain frame with custom resolution applied
		public Bitmap GrabFrameNo(uint FrameNumber, int imageWidth, int imageHeight)
		{
			
			string tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(FrameToTime(FrameNumber), imageWidth, imageHeight, tempFile);
			Bitmap imageBuffer = new Bitmap(tempFile);
			File.Delete(tempFile);
			return imageBuffer; 	
			
			
		}


		//grabs frame at certain time with custom resolution applied
		public Bitmap GrabFrameNo(double Time, int imageWidth, int imageHeight)
		{
			string tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(Time, imageWidth, imageHeight, tempFile);
			Bitmap imageBuffer = new Bitmap(tempFile);
			File.Delete(tempFile);
			return imageBuffer; 
		}


		//grabs frame at certain frame with resolution of 320x240 applied
		public Bitmap GrabFrameNo(uint FrameNumber)
		{
			
			string tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(FrameToTime(FrameNumber), 320, 240, tempFile);
			Bitmap imageBuffer = new Bitmap(tempFile);
			File.Delete(tempFile);
			return imageBuffer; 	
			
		} 
		

		//grabs frame at certain time with resolution of 320x240 applied
		public Bitmap GrabFrameNo(double Time)
		{
			string tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(Time, 320, 240, tempFile);
			Bitmap imageBuffer = new Bitmap(tempFile);
			File.Delete(tempFile);
			return imageBuffer; 
		}
	

		//return frame rate (fps)
		public double GetFrameRate()
		{
			return FrameRate;
		}


		//returns media length (time)
		public double GetMediaLength()
		{
			return MediaLength;
		}


		//converts time to frame
		public uint TimeToFrame (double time)
		{
			uint totalFrames = Convert.ToUInt32(MediaLength*FrameRate);

			return Convert.ToUInt32((time * totalFrames)/MediaLength);
		}


		//converts frame to time
		public double FrameToTime (uint FrameNumber)
		{
			return (FrameNumber*MediaLength)/(FrameRate*MediaLength);
		}
	}
}

