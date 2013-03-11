using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace ctlViewportlib
{
	/// <summary>
	/// Bitmap handling routines and filters
	/// </summary>
	public class BitmapFilters
	{
		public BitmapFilters()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		public static bool GrayScale(Bitmap b)
		{
			// GDI+ still lies to us - the return format is BGR, NOT RGB. 
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
			int stride = bmData.Stride; 
			System.IntPtr Scan0 = bmData.Scan0; 
			
			unsafe
			{
				byte * p = (byte *)(void *)Scan0;

				int nOffset = stride - b.Width*3;

				byte red, green, blue;

				for(int y=0;y < b.Height;++y)
				{
					for(int x=0; x < b.Width; ++x )
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						p[0] = p[1] = p[2] = (byte)(.299 * red 
							+ .587 * green 
							+ .114 * blue);

						p += 3;
					}
					p += nOffset;
				}
			}

			b.UnlockBits(bmData);

			return true;
		}

		public static bool Brightness(Bitmap b, int nBrightness)
		{
			if (nBrightness < -255 || nBrightness > 255)
				return false;

			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			int nVal = 0;

			unsafe
			{
				byte * p = (byte *)(void *)Scan0;

				int nOffset = stride - b.Width*3;
				int nWidth = b.Width * 3;

				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < nWidth; ++x )
					{
						nVal = (int) (p[0] + nBrightness);
		
						if (nVal < 0) nVal = 0;
						if (nVal > 255) nVal = 255;

						p[0] = (byte)nVal;

						++p;
					}
					p += nOffset;
				}
			}

			b.UnlockBits(bmData);

			return true;
		}

		public static bool Contrast(Bitmap b, sbyte nContrast)
		{
			if (nContrast < -100) return false;
			if (nContrast >  100) return false;

			double pixel = 0, contrast = (100.0+nContrast)/100.0;

			contrast *= contrast;

			int red, green, blue;
			
			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte * p = (byte *)(void *)Scan0;

				int nOffset = stride - b.Width*3;

				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < b.Width; ++x )
					{
						blue = p[0];
						green = p[1];
						red = p[2];
				
						pixel = red/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[2] = (byte) pixel;

						pixel = green/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[1] = (byte) pixel;

						pixel = blue/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[0] = (byte) pixel;					

						p += 3;
					}
					p += nOffset;
				}
			}

			b.UnlockBits(bmData);

			return true;
		}
	
	
		public static Bitmap ConvertBitmap(Bitmap inputBmp, ImageFormat destFormat) 
		{
			//If the dest format matches the source format and quality/bpp not changing, just clone
			if (inputBmp.RawFormat.Equals(destFormat)) 
			{
				return(Bitmap)inputBmp.Clone();
			}

			//Create an in-memory stream which will be used to save
			//the converted image
			System.IO.Stream imgStream = new System.IO.MemoryStream();

			//Save the bitmap out to the memory stream, using the format indicated by the caller
			inputBmp.Save(imgStream, destFormat);

			//At this point, imgStream contains the binary form of the
			//bitmap in the target format.  All that remains is to load it
			//into a new bitmap object
			Bitmap destBitmap = new Bitmap(imgStream);

			//Free the stream
			//imgStream.Close();
			//For some reason, the above causes unhandled GDI+ exceptions
			//when destBitmap.Save is called.  Perhaps the bitmap object reads
			//from the stream asynchronously?

			return destBitmap;
		}
		public static Bitmap CropBitmap(Bitmap inputBmp, Rectangle cropRectangle)
		{
			Bitmap newBmp = new Bitmap(cropRectangle.Width,
				cropRectangle.Height,
				PixelFormat.Format24bppRgb);
			//Graphics.FromImage doesn't like Indexed pixel format

			//Create a graphics object and attach it to the bitmap
			Graphics newBmpGraphics = Graphics.FromImage(newBmp);

			//Draw the portion of the input image in the crop rectangle
			//in the graphics object
			newBmpGraphics.DrawImage(inputBmp,
				new Rectangle(0, 0, cropRectangle.Width, cropRectangle.Height),
				cropRectangle,
				GraphicsUnit.Pixel);

			//Return the bitmap
			newBmpGraphics.Dispose();

			//newBmp will have a RawFormat of MemoryBmp because it was created
			//from scratch instead of being based on inputBmp. 
			//Since it it inconvenient
			//for the returned version of a bitmap to be 
			//of a different format, now convert
			//the scaled bitmap to the format of the source bitmap
			return ConvertBitmap(newBmp, inputBmp.RawFormat);
		}
	}
}
