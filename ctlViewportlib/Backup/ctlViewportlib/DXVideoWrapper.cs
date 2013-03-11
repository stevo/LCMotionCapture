using System;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace ctlViewportlib
{
	/// <summary>
	/// Summary description for DXVideoWrapper
	/// </summary>
	public class DXVideoWrapper
	{
		private string filename;
		private int height;
		private int width;
		private int displayWidth=0;
		private int displayHeight=0;
        private Video _video; 
		public bool is_playing=false;
		
		
		public DXVideoWrapper(string filename)
		{
			_video = new Video(filename);
		    
			this.filename = filename; 

			width = _video.DefaultSize.Width; 
			height = _video.DefaultSize.Height;

		}

		
		public void Play()
		{
			_video.Play();
			is_playing=true;
		}
		public void Pause()
		{
			_video.Pause();
			is_playing=false;
		}
		public void Stop()
		{
			_video.Stop();
			is_playing=false;
		}

		public void DisposeExt()
		{
			_video.Stop();
			_video.Dispose();
		}
		
		public void GotoPosition(double time)
		{
			_video.CurrentPosition=time;
			_video.Pause();
			is_playing=false;
		}

		public void SetDisplay(System.Windows.Forms.Control Display)
		{
			displayWidth = Display.Width;
			displayHeight = Display.Height;
			_video.Owner=Display;
			_video.Owner.Size= new System.Drawing.Size(displayWidth,displayHeight);
		
		}

		public void SetDisplay(System.Windows.Forms.Control Display, int resX, int resY)
		{
			_video.Owner=Display;
			_video.Owner.Size = new System.Drawing.Size(resX, resY);
		    displayWidth=resX;
			displayHeight=resY;
		}	
		
		public double GetCurrentTime()
		{
			return _video.CurrentPosition;
		}
		
		public double GetTotalTime()
		{
			return _video.Duration;
		}
	
		public int GetMediaWidth()
		{
			return width;
		}

		public int GetMediaHeight()
		{
			return height;
		}

		public int GetDisplayWidth()
		{
			return displayWidth;
		}
		public int GetDisplayHeight()
		{
			return displayHeight;
		}

	}
}
