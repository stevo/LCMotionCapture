using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

using System.Windows;
using System.Windows.Forms;


namespace FinalApp1
{
	/// <summary>
	/// Convert bitmap into byte/double vector
	/// </summary>
	
	public class ByteVector
	{
		//variable use for storing the bitmap
		private Bitmap _bitmap;

		//stores, how long the vector is
		private int count;

		//property for obtaining the value above
		public int Count
		{
			get
			{return count;}
			set
			{}
		}


		//vector storing bitmap as vector of its pixel brightness (0-255)
        private byte[] _ByteVector;

		//as above, but normalized to values varying from -1 to 1
		private double[] _DoubleVector;


        //create new ByteVecotor instance
		public ByteVector(Bitmap b)
		{
			_bitmap = new Bitmap(b);
			count=_bitmap.Width*_bitmap.Height;
			_ByteVector = new byte[count];
			_DoubleVector = new double[count];
			GenerateByteVector();
			NormalizeVector();
		}
        
        //generate vector of bitmap's pixel brightness values
		private void GenerateByteVector()
		{

			BitmapData bmData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
			
			int stride = bmData.Stride; 
			System.IntPtr Scan0 = bmData.Scan0;
 
			unsafe
			{
				byte * p = (byte *)(void *)Scan0;

				int nOffset = stride - _bitmap.Width*3;

				byte PixelValue;
				int counter=0;
				for(int y=0;y < _bitmap.Height;++y)
				{
					for(int x=0; x < _bitmap.Width; ++x )
					{
						PixelValue=p[1]; 
						_ByteVector[counter]=PixelValue;
						counter++;	
						p += 3;
					}
					p += nOffset;
				}
			}

			_bitmap.UnlockBits(bmData);


		}

		
		//normalize vector to values from range between -1 and 1
		private void NormalizeVector()
		{
			for (int i=0; i<count; i++)
			{
             _DoubleVector[i]=NormalizeValue(_ByteVector[i]);
			}
		}
		
		//normalize single value (from 0 to 255) to value from -1 to 1
		private double NormalizeValue(byte Val)
		{
			double wynik;//= new double();
	
			if (Val>127)
				wynik = (Val-128.0)/127.0;
			else
				wynik = (Val/128.0)-1;
			
			return wynik;

		}
		
	
		//returns brightness vector (values 0-255)
		public byte[] GetByteVector()
		{
			return  _ByteVector;
		}


		//as above, but normalized
		public double[] GetDoubleVector()
		{
			return  _DoubleVector;
		}


	}
}
