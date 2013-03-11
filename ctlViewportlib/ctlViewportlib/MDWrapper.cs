using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging; //Bitamps...
using System.IO; //GetTempFileName();
using DexterLib;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ctlViewportlib 
{

	/// <summary>
	/// MediaDetWrapper to klasa obudowywujaca biblioteke MediaDet (DirectShow).
	/// Wymagana jest biblioteka Interop.DexterLib.dll (referencja w Project->Add Reference)
	/// </summary>

	public class MDWrapper
	{
			
		//public variables
		public  string nazwa_pliku;
		
		//private variables
		private double FrameRate;
		private double MediaLength;
		public  MediaDetClass mD;
		public Bitmap imageBuffer;
		public string tempFile;
		
		//constructors
	    public MDWrapper(string nazwa_pliku)
		{
			mD = new MediaDetClass();
			mD.Filename=nazwa_pliku;
			mD.CurrentStream = 0;
            
			FrameRate=mD.FrameRate; //in fps
			MediaLength=mD.StreamLength; //in seconds
		}



		//public methods
		public Bitmap GrabFrameNo(uint FrameNumber, int imageWidth, int imageHeight)
		{
			
			tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(FrameToTime(FrameNumber), imageWidth, imageHeight, tempFile);
			
			imageBuffer = new Bitmap(tempFile);
			return imageBuffer; 	
			
		}
		
		public Bitmap GrabFrameNo(double Time, int imageWidth, int imageHeight, string tempFile)
		{
			//string tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(Time, imageWidth, imageHeight, tempFile);
			imageBuffer = new Bitmap(tempFile);
	        return imageBuffer; 
		}

		public Bitmap GrabFrameNo(double Time, int imageWidth, int imageHeight)
		{
			tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(Time, imageWidth, imageHeight, tempFile);
			imageBuffer = new Bitmap(tempFile);
			return imageBuffer; 
		//	return GetFrameFromVideo(mD.Filename, Time,new Size(imageWidth,imageHeight));
		}
		public Bitmap GrabFrameNo(uint FrameNumber)
		{
			
			tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(FrameToTime(FrameNumber), 320, 240, tempFile);
			imageBuffer = new Bitmap(tempFile);
	
			return imageBuffer; 	
			
		} //320x240 Res
		public Bitmap GrabFrameNo(double Time)
		{
			tempFile = Path.GetTempFileName();
			mD.WriteBitmapBits(Time, 320, 240, tempFile);
			imageBuffer = new Bitmap(tempFile);
		    
			return imageBuffer; 
		}

		
		
		
    
            //__________________________________________________________________________KONIEC
		

		
		public double GetFrameRate()
		{
			return FrameRate;
		}

		public double GetMediaLength()
		{
		
			return MediaLength;
		}
	



		//private methods 
		private uint TimeToFrame (double time)
		{
			//time = Round(time,2,100);
			uint totalFrames = Convert.ToUInt32(MediaLength*FrameRate);

			return Convert.ToUInt32((time * totalFrames)/MediaLength);
		}
		private double FrameToTime (uint FrameNumber)
		{

			return 1;// Round((FrameNumber*MediaLength)/(FrameRate*MediaLength),2,100);
		}
     
		

		
	}
	
	

}

