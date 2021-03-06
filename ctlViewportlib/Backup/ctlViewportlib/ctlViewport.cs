using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using DexterLib;
using System.Runtime.InteropServices;


namespace ctlViewportlib
{
	/// <summary>
	/// Viewport control
	/// </summary>
	public class ctlViewport : System.Windows.Forms.UserControl
	{
		
        
		private System.Windows.Forms.ToolTip m_wndToolTip;
        private uint startFrame;
		public  uint currentFrame;
		public  double currentTime;
		private Bitmap grabbedFrame;
		private string mediaFileName;
		private bool videoLoaded;
		private DXVideoWrapper dxVideo;
	    private string mode;
        private bool timeRepresentation; //true = time, false = frame;
        private double MediaLength;
	    private double FrameRate;
        public  int contrastCorrection;
		public  int brightnessCorrection;
		public  bool grayscale;


        

	    private System.Windows.Forms.PictureBox display;
		private System.Windows.Forms.Button ffdB;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.OpenFileDialog openMediaDialog;
		private System.Windows.Forms.Panel backPanel;
		private System.Windows.Forms.Timer mainTimer;
		public System.Windows.Forms.PictureBox stillDisplay;
		private System.Windows.Forms.Button postProcessingB;
		private System.Windows.Forms.Button resetStartFrameB;
		private System.Windows.Forms.Button playbackCaptureB;
		private System.Windows.Forms.Button revB;
		private System.Windows.Forms.Button frameBackwardB;
		private System.Windows.Forms.Button frameForwardB;
		private System.Windows.Forms.Button startFrameB;
		private System.Windows.Forms.Button loadB;
		private System.Windows.Forms.Button stopB;
		private System.Windows.Forms.Button playB;
		private System.Windows.Forms.Panel infoDisplay;
		private System.Windows.Forms.Label infoDisplayValue;
		private System.Windows.Forms.Button timeFrameB;
		private System.Windows.Forms.Button manualCaptureB;
		private System.Windows.Forms.Panel frameDisplay;
		private System.Windows.Forms.Label frameDisplayValue;
		private System.Windows.Forms.Panel controlsPanel;
		private System.Windows.Forms.TextBox frameCounter; //playback, capture
        string          status;//play,pause,stop,capture

		



		public ctlViewport()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitComponent call
            InitializeToolTips();
			mediaFileName="";
			videoLoaded=false;
			startFrame=0;
			mode="playback";
			status="stop";
			timeRepresentation=true;
		}

		public ctlViewport(string FileName)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitComponent call
            InitializeToolTips();
			LoadMedia(FileName);
		}

		public ctlViewport(string FileName, int resX, int resY)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitComponent call
			InitializeToolTips();
			LoadMedia(FileName, resX, resY);
		}

		public ctlViewport(string FileName, int scaleFactor)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitComponent call
			InitializeToolTips();
			LoadMedia(FileName, scaleFactor);
		}



		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlViewport));
			this.display = new System.Windows.Forms.PictureBox();
			this.ffdB = new System.Windows.Forms.Button();
			this.backPanel = new System.Windows.Forms.Panel();
			this.openMediaDialog = new System.Windows.Forms.OpenFileDialog();
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.stillDisplay = new System.Windows.Forms.PictureBox();
			this.postProcessingB = new System.Windows.Forms.Button();
			this.resetStartFrameB = new System.Windows.Forms.Button();
			this.playbackCaptureB = new System.Windows.Forms.Button();
			this.revB = new System.Windows.Forms.Button();
			this.frameBackwardB = new System.Windows.Forms.Button();
			this.frameForwardB = new System.Windows.Forms.Button();
			this.startFrameB = new System.Windows.Forms.Button();
			this.loadB = new System.Windows.Forms.Button();
			this.stopB = new System.Windows.Forms.Button();
			this.playB = new System.Windows.Forms.Button();
			this.infoDisplay = new System.Windows.Forms.Panel();
			this.infoDisplayValue = new System.Windows.Forms.Label();
			this.timeFrameB = new System.Windows.Forms.Button();
			this.manualCaptureB = new System.Windows.Forms.Button();
			this.frameDisplay = new System.Windows.Forms.Panel();
			this.frameDisplayValue = new System.Windows.Forms.Label();
			this.controlsPanel = new System.Windows.Forms.Panel();
			this.frameCounter = new System.Windows.Forms.TextBox();
			this.infoDisplay.SuspendLayout();
			this.frameDisplay.SuspendLayout();
			this.controlsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.display.Cursor = System.Windows.Forms.Cursors.Cross;
			this.display.Location = new System.Drawing.Point(2, 2);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(360, 240);
			this.display.TabIndex = 0;
			this.display.TabStop = false;
			this.display.Resize += new System.EventHandler(this.display_Resize);
			// 
			// ffdB
			// 
			this.ffdB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ffdB.BackgroundImage")));
			this.ffdB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ffdB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ffdB.Location = new System.Drawing.Point(133, 0);
			this.ffdB.Name = "ffdB";
			this.ffdB.Size = new System.Drawing.Size(48, 16);
			this.ffdB.TabIndex = 4;
			this.ffdB.Text = "Ffd";
			this.ffdB.Click += new System.EventHandler(this.ffdB_Click);
			// 
			// backPanel
			// 
			this.backPanel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.backPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.backPanel.Location = new System.Drawing.Point(0, 0);
			this.backPanel.Name = "backPanel";
			this.backPanel.Size = new System.Drawing.Size(364, 278);
			this.backPanel.TabIndex = 12;
			// 
			// mainTimer
			// 
			this.mainTimer.Interval = 50;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// stillDisplay
			// 
			this.stillDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.stillDisplay.Cursor = System.Windows.Forms.Cursors.Cross;
			this.stillDisplay.Location = new System.Drawing.Point(2, 2);
			this.stillDisplay.Name = "stillDisplay";
			this.stillDisplay.Size = new System.Drawing.Size(360, 240);
			this.stillDisplay.TabIndex = 13;
			this.stillDisplay.TabStop = false;

			
			// 
			// postProcessingB
			// 
			this.postProcessingB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.postProcessingB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("postProcessingB.BackgroundImage")));
			this.postProcessingB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.postProcessingB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.postProcessingB.Location = new System.Drawing.Point(34, 17);
			this.postProcessingB.Name = "postProcessingB";
			this.postProcessingB.Size = new System.Drawing.Size(26, 16);
			this.postProcessingB.TabIndex = 17;
			this.postProcessingB.Text = "Pp";
			this.postProcessingB.Click += new System.EventHandler(this.postProcessingB_Click);
			// 
			// resetStartFrameB
			// 
			this.resetStartFrameB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.resetStartFrameB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resetStartFrameB.BackgroundImage")));
			this.resetStartFrameB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.resetStartFrameB.Font = new System.Drawing.Font("Silkscreen", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.resetStartFrameB.Location = new System.Drawing.Point(213, 17);
			this.resetStartFrameB.Name = "resetStartFrameB";
			this.resetStartFrameB.Size = new System.Drawing.Size(30, 16);
			this.resetStartFrameB.TabIndex = 14;
			this.resetStartFrameB.Text = "RSF";
			this.resetStartFrameB.Click += new System.EventHandler(this.resetStartFrameB_Click);
			// 
			// playbackCaptureB
			// 
			this.playbackCaptureB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.playbackCaptureB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playbackCaptureB.BackgroundImage")));
			this.playbackCaptureB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.playbackCaptureB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.playbackCaptureB.Location = new System.Drawing.Point(0, 17);
			this.playbackCaptureB.Name = "playbackCaptureB";
			this.playbackCaptureB.Size = new System.Drawing.Size(33, 16);
			this.playbackCaptureB.TabIndex = 13;
			this.playbackCaptureB.Text = "PLB";
			this.playbackCaptureB.Click += new System.EventHandler(this.playbackCaptureB_Click);
			// 
			// revB
			// 
			this.revB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.revB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("revB.BackgroundImage")));
			this.revB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.revB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.revB.Location = new System.Drawing.Point(84, 0);
			this.revB.Name = "revB";
			this.revB.Size = new System.Drawing.Size(48, 16);
			this.revB.TabIndex = 3;
			this.revB.Text = "Rew";
			this.revB.Click += new System.EventHandler(this.revB_Click);
			// 
			// frameBackwardB
			// 
			this.frameBackwardB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.frameBackwardB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frameBackwardB.BackgroundImage")));
			this.frameBackwardB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.frameBackwardB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.frameBackwardB.Location = new System.Drawing.Point(82, 17);
			this.frameBackwardB.Name = "frameBackwardB";
			this.frameBackwardB.Size = new System.Drawing.Size(38, 16);
			this.frameBackwardB.TabIndex = 5;
			this.frameBackwardB.Text = "<Frm";
			this.frameBackwardB.Click += new System.EventHandler(this.frameBackwardB_Click);
			// 
			// frameForwardB
			// 
			this.frameForwardB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.frameForwardB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frameForwardB.BackgroundImage")));
			this.frameForwardB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.frameForwardB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.frameForwardB.Location = new System.Drawing.Point(143, 17);
			this.frameForwardB.Name = "frameForwardB";
			this.frameForwardB.Size = new System.Drawing.Size(38, 16);
			this.frameForwardB.TabIndex = 6;
			this.frameForwardB.Text = "Frm>";
			this.frameForwardB.Click += new System.EventHandler(this.frameForwardB_Click);
			// 
			// startFrameB
			// 
			this.startFrameB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.startFrameB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startFrameB.BackgroundImage")));
			this.startFrameB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startFrameB.Font = new System.Drawing.Font("Silkscreen", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.startFrameB.Location = new System.Drawing.Point(182, 17);
			this.startFrameB.Name = "startFrameB";
			this.startFrameB.Size = new System.Drawing.Size(30, 16);
			this.startFrameB.TabIndex = 7;
			this.startFrameB.Text = "SF";
			this.startFrameB.Click += new System.EventHandler(this.startFrameB_Click);
			// 
			// loadB
			// 
			this.loadB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.loadB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadB.BackgroundImage")));
			this.loadB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadB.Font = new System.Drawing.Font("Silkscreen", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loadB.Location = new System.Drawing.Point(244, 17);
			this.loadB.Name = "loadB";
			this.loadB.Size = new System.Drawing.Size(41, 16);
			this.loadB.TabIndex = 11;
			this.loadB.Text = "Load";
			this.loadB.Click += new System.EventHandler(this.loadB_Click);
			// 
			// stopB
			// 
			this.stopB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.stopB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stopB.BackgroundImage")));
			this.stopB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.stopB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.stopB.Location = new System.Drawing.Point(40, 0);
			this.stopB.Name = "stopB";
			this.stopB.Size = new System.Drawing.Size(43, 16);
			this.stopB.TabIndex = 2;
			this.stopB.Text = "Stop";
			this.stopB.Click += new System.EventHandler(this.stopB_Click);
			// 
			// playB
			// 
			this.playB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.playB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playB.BackgroundImage")));
			this.playB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.playB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.playB.Location = new System.Drawing.Point(0, 0);
			this.playB.Name = "playB";
			this.playB.Size = new System.Drawing.Size(39, 16);
			this.playB.TabIndex = 1;
			this.playB.Text = "Play";
			this.playB.Click += new System.EventHandler(this.playB_Click);
			// 
			// infoDisplay
			// 
			this.infoDisplay.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.infoDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.infoDisplay.Controls.Add(this.infoDisplayValue);
			this.infoDisplay.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.infoDisplay.Location = new System.Drawing.Point(182, 0);
			this.infoDisplay.Name = "infoDisplay";
			this.infoDisplay.Size = new System.Drawing.Size(178, 16);
			this.infoDisplay.TabIndex = 8;
			// 
			// infoDisplayValue
			// 
			this.infoDisplayValue.ForeColor = System.Drawing.Color.Yellow;
			this.infoDisplayValue.Location = new System.Drawing.Point(1, 3);
			this.infoDisplayValue.Name = "infoDisplayValue";
			this.infoDisplayValue.Size = new System.Drawing.Size(173, 6);
			this.infoDisplayValue.TabIndex = 0;
			// 
			// timeFrameB
			// 
			this.timeFrameB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.timeFrameB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeFrameB.BackgroundImage")));
			this.timeFrameB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.timeFrameB.Font = new System.Drawing.Font("Silkscreen", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.timeFrameB.Location = new System.Drawing.Point(286, 17);
			this.timeFrameB.Name = "timeFrameB";
			this.timeFrameB.Size = new System.Drawing.Size(12, 16);
			this.timeFrameB.TabIndex = 12;
			this.timeFrameB.Text = "T";
			this.timeFrameB.Click += new System.EventHandler(this.timeFrameB_Click);
			// 
			// manualCaptureB
			// 
			this.manualCaptureB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.manualCaptureB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("manualCaptureB.BackgroundImage")));
			this.manualCaptureB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.manualCaptureB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manualCaptureB.Location = new System.Drawing.Point(61, 17);
			this.manualCaptureB.Name = "manualCaptureB";
			this.manualCaptureB.Size = new System.Drawing.Size(20, 16);
			this.manualCaptureB.TabIndex = 16;
			this.manualCaptureB.Text = "P";
			this.manualCaptureB.Click += new System.EventHandler(this.manualCaptureB_Click);
			// 
			// frameDisplay
			// 
			this.frameDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.frameDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.frameDisplay.Controls.Add(this.frameDisplayValue);
			this.frameDisplay.Location = new System.Drawing.Point(299, 17);
			this.frameDisplay.Name = "frameDisplay";
			this.frameDisplay.Size = new System.Drawing.Size(61, 16);
			this.frameDisplay.TabIndex = 15;
			// 
			// frameDisplayValue
			// 
			this.frameDisplayValue.Font = new System.Drawing.Font("Silkscreen", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.frameDisplayValue.ForeColor = System.Drawing.Color.Gold;
			this.frameDisplayValue.Location = new System.Drawing.Point(0, 3);
			this.frameDisplayValue.Name = "frameDisplayValue";
			this.frameDisplayValue.Size = new System.Drawing.Size(57, 14);
			this.frameDisplayValue.TabIndex = 0;
			// 
			// controlsPanel
			// 
			this.controlsPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.controlsPanel.Controls.Add(this.postProcessingB);
			this.controlsPanel.Controls.Add(this.resetStartFrameB);
			this.controlsPanel.Controls.Add(this.playbackCaptureB);
			this.controlsPanel.Controls.Add(this.revB);
			this.controlsPanel.Controls.Add(this.frameBackwardB);
			this.controlsPanel.Controls.Add(this.frameForwardB);
			this.controlsPanel.Controls.Add(this.startFrameB);
			this.controlsPanel.Controls.Add(this.ffdB);
			this.controlsPanel.Controls.Add(this.loadB);
			this.controlsPanel.Controls.Add(this.stopB);
			this.controlsPanel.Controls.Add(this.playB);
			this.controlsPanel.Controls.Add(this.infoDisplay);
			this.controlsPanel.Controls.Add(this.timeFrameB);
			this.controlsPanel.Controls.Add(this.manualCaptureB);
			this.controlsPanel.Controls.Add(this.frameDisplay);
			this.controlsPanel.Controls.Add(this.frameCounter);
			this.controlsPanel.Location = new System.Drawing.Point(2, 243);
			this.controlsPanel.Name = "controlsPanel";
			this.controlsPanel.Size = new System.Drawing.Size(360, 33);
			this.controlsPanel.TabIndex = 14;
			this.controlsPanel.Resize += new System.EventHandler(this.controlsPanel_Resize);
			// 
			// frameCounter
			// 
			this.frameCounter.BackColor = System.Drawing.Color.Silver;
			this.frameCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.frameCounter.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.frameCounter.Location = new System.Drawing.Point(121, 17);
			this.frameCounter.Name = "frameCounter";
			this.frameCounter.Size = new System.Drawing.Size(21, 16);
			this.frameCounter.TabIndex = 15;
			this.frameCounter.Text = "1";
			// 
			// ctlViewport
			// 
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.Add(this.controlsPanel);
			this.Controls.Add(this.display);
			this.Controls.Add(this.backPanel);
			this.Controls.Add(this.stillDisplay);
			this.Name = "ctlViewport";
			this.Size = new System.Drawing.Size(364, 278);
			this.infoDisplay.ResumeLayout(false);
			this.frameDisplay.ResumeLayout(false);
			this.controlsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitializeToolTips()
		{
			this.m_wndToolTip = new System.Windows.Forms.ToolTip (this.components);
            m_wndToolTip.SetToolTip (playB, "Play/Pause video");
			m_wndToolTip.SetToolTip (stopB, "Stop video");
			m_wndToolTip.SetToolTip (revB, "Rewind to 1st frame");
			m_wndToolTip.SetToolTip (ffdB, "Goto last frame");
			m_wndToolTip.SetToolTip (timeFrameB, "Change time representation (Frame/Time)");
			m_wndToolTip.SetToolTip (loadB, "Load video file");
			m_wndToolTip.SetToolTip (startFrameB, "Set current frame as Start Frame");
			m_wndToolTip.SetToolTip (resetStartFrameB, "Reset Start Frame to frame no.0");
            m_wndToolTip.SetToolTip (frameForwardB, "Goto next frame (if paused only!)");
		 	m_wndToolTip.SetToolTip (frameBackwardB, "Goto previous frame (if paused only!)");
			m_wndToolTip.SetToolTip (infoDisplay, "Shows various information");
			m_wndToolTip.SetToolTip (infoDisplayValue, "Shows various information");
            m_wndToolTip.SetToolTip (frameDisplay, "Shows current time/frame");
			m_wndToolTip.SetToolTip (frameDisplayValue, "Shows current time/frame");
			m_wndToolTip.SetToolTip (display, "Displays video stream/captured frame");
			m_wndToolTip.Active=true;
		}
		
		private string LoadMedia(string FileName)
		{
			mediaFileName=FileName;

			if (dxVideo != null)
			{
				dxVideo.DisposeExt();
				dxVideo = null;
			}

			dxVideo = new DXVideoWrapper(mediaFileName);
			dxVideo.SetDisplay(this.display);
			dxVideo.Play();
			dxVideo.Pause();
			playB.Text="Play";

			display.Width=dxVideo.GetMediaWidth();
			display.Height=dxVideo.GetMediaHeight();
			stillDisplay.Width=display.Width;
			stillDisplay.Height=display.Height;

			videoLoaded=true;
			startFrame=0;
			currentFrame=0;
			mode="playback";
			status="pause";
			timeRepresentation=true;

			MediaLength=dxVideo.GetTotalTime();
			FrameRate=this.getFrameRate(mediaFileName);
			
			infoDisplayValue.Text="Video loaded and paused...";
			mainTimer.Start();

			contrastCorrection=0;
			brightnessCorrection=0;
			grayscale=false;
		    
			return FileName;
		}

		private string LoadMedia(string FileName, int resX, int resY)
		{
			mediaFileName=FileName;

			if (dxVideo != null)
			{
				
				dxVideo.DisposeExt();
				dxVideo = null;
			}

			dxVideo = new DXVideoWrapper(mediaFileName);
			dxVideo.SetDisplay(this.display);
			dxVideo.Play();
			dxVideo.Pause();
			playB.Text="Play";

			display.Width=resX;
			display.Height=resY;
			stillDisplay.Width=display.Width;
			stillDisplay.Height=display.Height;

			videoLoaded=true;
			startFrame=0;
			currentFrame=0;
			mode="playback";
			status="pause";
			timeRepresentation=true;
			
			MediaLength=dxVideo.GetTotalTime();
			FrameRate=this.getFrameRate(mediaFileName);
			
			infoDisplayValue.Text="Video loaded and paused...";
			mainTimer.Start();

			contrastCorrection=0;
			brightnessCorrection=0;
			grayscale=false;

			return FileName;
		}

		private string LoadMedia(string FileName, int scale)
		{
			mediaFileName=FileName;

			if (dxVideo != null)
			{
				
				dxVideo.DisposeExt();
				dxVideo = null;
			}

			dxVideo = new DXVideoWrapper(mediaFileName);
			dxVideo.SetDisplay(this.display);
			dxVideo.Play();
			dxVideo.Pause();
			playB.Text="Play";
			
			double scaleFactor = scale; 
			scaleFactor/=100;

			int w = dxVideo.GetMediaWidth();
			int h = dxVideo.GetMediaHeight();
			
			w=(int)(w*scaleFactor);
			h=(int)(h*scaleFactor);
			
			display.Width=w;
			display.Height=h;
			stillDisplay.Width=display.Width;
			stillDisplay.Height=display.Height;

			videoLoaded=true;
			startFrame=0;
			currentFrame=0;
			mode="playback";
			status="pause";
			timeRepresentation=true;

			MediaLength=dxVideo.GetTotalTime();
			FrameRate=this.getFrameRate(mediaFileName);
			
			infoDisplayValue.Text="Video loaded and paused...";
			mainTimer.Start();
			
			contrastCorrection=0;
			brightnessCorrection=0;
			grayscale=false;
		    
			return FileName;
		}
		
		public Bitmap GetFrame (bool postProcessing)
		{
			if (mode=="capture")
			{ 
                grabbedFrame= new Bitmap(GetFrameFromVideo(mediaFileName,dxVideo.GetCurrentTime(),new Size(display.Width,display.Height)));

				infoDisplayValue.Text="Frame captured (time:"+Convert.ToString(dxVideo.GetCurrentTime())+")";
				

					if (postProcessing)
					{
						if (contrastCorrection!=0) BitmapFilters.Contrast(grabbedFrame,Convert.ToSByte(contrastCorrection));

						if (brightnessCorrection!=0) BitmapFilters.Brightness(grabbedFrame,Convert.ToSByte(brightnessCorrection));

						if (grayscale) BitmapFilters.GrayScale(grabbedFrame);
					}
					return grabbedFrame;
			}
				
			else return null;
		}
	
		public void UpdateDisplay(Bitmap updatedFrame)
		{
          stillDisplay.Image=updatedFrame;
		  stillDisplay.Invalidate();

		}
		private static double Round(double x, int numerator, int denominator)
		{ 
			// zwraca liczbe z dokładnością numerator/denominator (Np. 5/100 = 0.05)
			long y = (long)Math.Floor(x * denominator + (double)numerator / 2.0);
			return (double)(y - y % numerator)/(double)denominator;
		}

		
		public void Play()
		{
			if (status!="play") playB_Click(null,null);
		}

		public void Stop()
		{
			stopB_Click(null,null);
		}

		public void Pause()
		{
		  	if (status!="pause") playB_Click(null,null);
		}
		public void Rewind()
		{
			revB_Click(null,null);
		}
		public void FastForward()
		{
			ffdB_Click(null,null);
		}
		public void PlaybackMode()
		{
           if (mode!="playback") playbackCaptureB_Click(null,null);
		}
		public void CaptureMode()
		{
          if (mode!="capture") playbackCaptureB_Click(null,null);
		}

		public void loadMedia()
		{
        loadB_Click(null,null);
		}

		public string getMediaFileName()
		{
         return mediaFileName;
		}
		public void loadMedia(string filename)
		{
         LoadMedia(filename);
		}

		public void loadMedia(string filename, int resX, int resY)
		{
         LoadMedia(filename, resX, resY);

		}

		public void loadMedia(string filename, int scaleFactor)
		{
			LoadMedia(filename, scaleFactor);
		}

		public uint getStartFrame()
		{
          return startFrame;
		}

		public int frameForward (uint frameCount)
		{
			if (mode=="playback" && status=="pause" && videoLoaded)
			{
            
				uint totalFrameCount=TimeToFrame(dxVideo.GetTotalTime());
				uint currentFrame=TimeToFrame(dxVideo.GetCurrentTime());
				
				if (currentFrame+frameCount<=totalFrameCount)
				{
				
					currentFrame+=frameCount;
					infoDisplayValue.Text="Step frame mode...";
					dxVideo.GotoPosition(FrameToTime(currentFrame)); 
				} 
				else 
				{
					infoDisplayValue.Text="Intended frame exceeds movie length!"; 
					dxVideo.GotoPosition(FrameToTime(totalFrameCount));
				} 
				return 1;
			}
			else
				if (mode=="capture" && videoLoaded)
			{
				
		
				uint totalFrameCount=TimeToFrame(dxVideo.GetTotalTime());
				uint currentFrame=TimeToFrame(dxVideo.GetCurrentTime());
				
				if (currentFrame+frameCount<=totalFrameCount)
				{
					
					currentFrame+=frameCount;
					dxVideo.GotoPosition(FrameToTime(currentFrame)); 
					infoDisplayValue.Text="Frame captured";
					stillDisplay.Image=this.GetFrame(false);
					stillDisplay.Invalidate();
				} 
				else 
				{
					infoDisplayValue.Text="Intended frame exceeds movie length! Frame captured"; 
					dxVideo.GotoPosition(FrameToTime(totalFrameCount));
					stillDisplay.Image=this.GetFrame(false);
				} 
				return 2;
			}
			else
			{
				infoDisplayValue.Text="No video loaded";
			    return 0;
			}
		}

		public int frameBackward (uint frameCount)
		{
			if (mode=="playback" && status=="pause" && videoLoaded)
			{
				
				uint totalFrameCount=TimeToFrame(dxVideo.GetTotalTime());
				uint currentFrame=TimeToFrame(dxVideo.GetCurrentTime());
				if (currentFrame-frameCount>=0)
				{
					
					currentFrame-=frameCount;
					infoDisplayValue.Text="Step frame mode...";
					dxVideo.GotoPosition(FrameToTime(currentFrame)); 
				
				} 
				else 
				{
					infoDisplayValue.Text="Intended frame is less than 0"; 
					dxVideo.GotoPosition(FrameToTime(0)); 
				}
				return 1;
			} 
			else
				if (mode=="capture" && videoLoaded)
			{
				uint totalFrameCount=TimeToFrame(dxVideo.GetTotalTime());
				uint currentFrame=TimeToFrame(dxVideo.GetCurrentTime());
				if (currentFrame-frameCount>=0)
				{
				
					currentFrame-=frameCount;
					dxVideo.GotoPosition(FrameToTime(currentFrame)); 
					infoDisplayValue.Text="Frame captured";
					stillDisplay.Image=this.GetFrame(false);
					stillDisplay.Invalidate();
				}
				else 
				{
					infoDisplayValue.Text="Intended frame is less than 0! Frame captured"; 
					dxVideo.GotoPosition(FrameToTime(0));
					stillDisplay.Image=this.GetFrame(false);
					stillDisplay.Invalidate();
				}
				return 2;
			}
			else
			{
				infoDisplayValue.Text="No video loaded";
				return 0;
			}

		}
	
		public void capMode()
		{
		if (videoLoaded)
			if (mode!="capture")
			{
				Pause();
				stillDisplay.BringToFront();
				mode="capture"; 
				playbackCaptureB.Text="CAP";
				stillDisplay.Image=this.GetFrame(true);
				stillDisplay.Invalidate();
				infoDisplayValue.Text="Frame capture mode";
			}
		} //forced

		public void plbMode()
		{
		if (videoLoaded)
			if (mode!="playback")
			{
				stillDisplay.SendToBack();
				mode="playback";
				playbackCaptureB.Text="PLB";
				infoDisplayValue.Text="Playback mode";
			} 
		}//forced
		public bool isCapture()
		{ 
			if (videoLoaded && mode=="capture")
			return true; else return false;
		}

		public double getFrameRate(string FileName)
		{ 
            double fr;
			 MediaDetClass mD = new MediaDetClass();
			
				mD.Filename=FileName;
				mD.CurrentStream=0;
				fr = mD.FrameRate;
			    mD=null;
			return fr;
		}


		public delegate void VideoLoadedEventHandler (ctlViewport sender);
		protected virtual void OnVideoLoaded()
		{

			if(VideoLoaded != null)
			{
				VideoLoaded(this);
			}
		}
		
		public event VideoLoadedEventHandler VideoLoaded;

		public delegate void EndOfMovieReachedEventHandler (ctlViewport sender);
		protected virtual void OnEndOfMovieReached()
		{
			
	
			if(EndOfMovieReached != null)
			{
				EndOfMovieReached(this);
			}
		}
		public event EndOfMovieReachedEventHandler EndOfMovieReached;

		public delegate void StartFrameUpdatedEventHandler(ctlViewport sender);
		protected virtual void OnStartFrameUpdated()
		{
			
	
			if(StartFrameUpdated != null)
			{
				StartFrameUpdated(this);
			}
		}
		public event StartFrameUpdatedEventHandler StartFrameUpdated;

		public delegate void PostProcessingUpdatedEventHandler (ctlViewport sender);
		protected virtual void OnPostProcessingUpdated()
		{
           if (PostProcessingUpdated != null)
		   PostProcessingUpdated(this);

		}
		public event PostProcessingUpdatedEventHandler PostProcessingUpdated;




		private void stopB_Click(object sender, System.EventArgs e)
		{
		if ((videoLoaded==true) &&(mode=="playback"))
			if (status!="stop")
			{
				dxVideo.GotoPosition(FrameToTime(startFrame));
				dxVideo.Pause();
				playB.Text="Play";
				status="stop";
				infoDisplayValue.Text="Video stopped";
             
			} else infoDisplayValue.Text="No video loaded or CAP mode";;
		}

		private void loadB_Click(object sender, System.EventArgs e)
		{
			openMediaDialog.Filter = "Video files (*.*)|*.avi";
			
			if((openMediaDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) &&
				(openMediaDialog.FileName!=""))
			{
				LoadMedia(openMediaDialog.FileName);
			    OnVideoLoaded();
			}
			else infoDisplayValue.Text="Video load aborted!";
		}

		private void startFrameB_Click(object sender, System.EventArgs e)
		{
			if (videoLoaded && mode=="playback")
			{
				startFrame=TimeToFrame(dxVideo.GetCurrentTime());
				infoDisplayValue.Text="New start frame is : "+Convert.ToString(startFrame);
				OnStartFrameUpdated();
			}
			else infoDisplayValue.Text="No video loaded or CAP mode";
		}
		
		private void timeFrameB_Click(object sender, System.EventArgs e)
		{
		 timeRepresentation=!timeRepresentation;
			if (timeRepresentation) timeFrameB.Text="T"; else timeFrameB.Text="F";
		}

		private void revB_Click(object sender, System.EventArgs e)
		{
			
			if (videoLoaded && mode=="playback")
			{
				dxVideo.GotoPosition(FrameToTime(startFrame));
				status="pause";
				playB.Text="Play";
				infoDisplayValue.Text="Video @"+Convert.ToString(startFrame)+ " frame";
			}
			else infoDisplayValue.Text="No video loaded or CAP mode";
			
			}

		private void ffdB_Click(object sender, System.EventArgs e)
		{
			if (videoLoaded && mode=="playback")
			{
				dxVideo.GotoPosition(dxVideo.GetTotalTime());
				status="stop";
				playB.Text="Play";
				infoDisplayValue.Text="Video @ last frame";
			}
			else infoDisplayValue.Text="No video loaded or CAP mode";
		}

		private void resetStartFrameB_Click(object sender, System.EventArgs e)
		{
			if (videoLoaded && mode=="playback")
			{
				startFrame=0;
				infoDisplayValue.Text="New start frame is : "+Convert.ToString(startFrame);
			} else infoDisplayValue.Text="No video loaded or CAP mode";
		}

		private void mainTimer_Tick(object sender, System.EventArgs e)
		{
		
			if (timeRepresentation)
				frameDisplayValue.Text=Convert.ToString(Round(dxVideo.GetCurrentTime(),1,1000))+" s";
			else
				frameDisplayValue.Text="frm: "+Convert.ToString(TimeToFrame(dxVideo.GetCurrentTime()));	
		
			
			currentFrame=TimeToFrame(dxVideo.GetCurrentTime());
			currentTime=dxVideo.GetCurrentTime();

			if (dxVideo.GetCurrentTime()==dxVideo.GetTotalTime())
			{
				OnEndOfMovieReached();
				infoDisplayValue.Text="End of file reached...";
				playB.Text="Play";
			
			}

		}

		private void frameForwardB_Click(object sender, System.EventArgs e)
		{
			frameForward(Convert.ToUInt32(frameCounter.Text));
		}

		private void frameBackwardB_Click(object sender, System.EventArgs e)
		{
			frameBackward(Convert.ToUInt32(frameCounter.Text));
		}

		private void playbackCaptureB_Click(object sender, System.EventArgs e)
		{
			if (videoLoaded && ((status=="stop") || (status=="pause")))

			if (mode=="playback") 
			{
			    stillDisplay.BringToFront();
				mode="capture"; 
				playbackCaptureB.Text="CAP";	
				stillDisplay.Image=this.GetFrame(true);
				stillDisplay.Invalidate();
				infoDisplayValue.Text="Frame capture mode";
			}
			
			else 
			{
				stillDisplay.SendToBack();
				mode="playback";
				playbackCaptureB.Text="PLB";
				infoDisplayValue.Text="Playback mode";
            
			} else infoDisplayValue.Text="No video loaded/video not paused";
		}

		private void manualCaptureB_Click(object sender, System.EventArgs e)
		{
			if (mode=="capture")
			{
				dxVideo.GotoPosition(FrameToTime(currentFrame)); 
				stillDisplay.Image=this.GetFrame(true);
				stillDisplay.Invalidate();
			}
		}

		private void playB_Click(object sender, System.EventArgs e)
		{
			if ((videoLoaded==true) &&(mode=="playback"))
				
				
				if (status=="stop")
				{
					dxVideo.GotoPosition(FrameToTime(startFrame));
					dxVideo.Play();
					playB.Text="Pause";
					status="play";
					infoDisplayValue.Text="Video playing...";
				}
				
				else if (status=="pause")
				{
					dxVideo.Play();
					playB.Text="Pause";
					status="play";
					infoDisplayValue.Text="Video playing...";
				} 
				else if (status=="play" && dxVideo.GetTotalTime()==dxVideo.GetCurrentTime())
				{
					dxVideo.GotoPosition(FrameToTime(startFrame));
					dxVideo.Pause();
					playB.Text="Play";
					status="pause";
					infoDisplayValue.Text="Video @"+Convert.ToString(startFrame)+ " frame";
				}
				else if (status=="play")
				{
					dxVideo.Pause();
					playB.Text="Play";
					status="pause";
					infoDisplayValue.Text="Video paused!";
				} 
				else infoDisplayValue.Text="No video loaded or in capture mode";

		}

		private void postProcessingB_Click(object sender, System.EventArgs e)
		{
			if (mode=="capture")
			using (PostProcessing xForm = new PostProcessing(brightnessCorrection,contrastCorrection,grayscale,GetFrame(false)))
			{
				if (xForm.ShowDialog(this) == DialogResult.OK) 
				{
				contrastCorrection=xForm.getContrast();
				brightnessCorrection=xForm.getBrightness();
				grayscale=xForm.getGrayscale();
				OnPostProcessingUpdated();
				}
			} 
			else infoDisplayValue.Text="Only in capture mode!";
		}

		private void display_Resize(object sender, System.EventArgs e)
		{
		stillDisplay.Size=display.Size;
        
			if (display.Width>=360)
			{
				this.Width=display.Width+4;
				backPanel.Width=display.Width+4;
				controlsPanel.Width=display.Width;
			}	
			else 
			{
				this.Width=364;
				backPanel.Width=364;
				controlsPanel.Width=360;
			}
				this.Height=display.Height+38;
				backPanel.Height=display.Height+38;
                controlsPanel.Left=2;
                controlsPanel.Top=this.Height-35;
		}

		private void controlsPanel_Resize(object sender, System.EventArgs e)
		{
		infoDisplay.Width=controlsPanel.Width-infoDisplay.Location.X;
			frameDisplay.Width=controlsPanel.Width-frameDisplay.Location.X;
		}

		public uint getCurrentFrame()
		{
			return currentFrame;
		}
        
		public void setStartFrame(uint sf)
		{
			if (videoLoaded)
			{
				startFrame = sf;
				dxVideo.GotoPosition(FrameToTime(startFrame));
			}
			else startFrame=sf;
		}
	

		public uint TimeToFrame (double time)
		{
			time = Round(time,2, 100);
			uint totalFrames = Convert.ToUInt32(MediaLength*FrameRate);

			return Convert.ToUInt32((time * totalFrames)/MediaLength);
		}

		public double FrameToTime (uint FrameNumber)
		{
			return Round((FrameNumber*MediaLength)/(FrameRate*MediaLength),2,100);
			
		}
	

		public static Size GetVideoSize(string videoFile)
		{
			MediaDetClass mediaDet;
			_AMMediaType mediaType;
			if (openVideoStream(videoFile, out mediaDet, out mediaType))
			{
				return getVideoSize(mediaType);
			}

			return Size.Empty;
		}
		private static bool openVideoStream(string videoFile, out MediaDetClass mediaDetClass, out _AMMediaType aMMediaType)
		{
			MediaDetClass mediaDet = new MediaDetClass();

			mediaDet.Filename=videoFile;
			
			int streamsNumber = mediaDet.OutputStreams;

			for (int i = 0; i < streamsNumber; i ++)
			{
				mediaDet.CurrentStream = i;

				_AMMediaType mediaType = mediaDet.StreamMediaType;

				if (mediaType.majortype == JockerSoft.Media.MayorTypes.MEDIATYPE_Video)
				{
					mediaDetClass = mediaDet;
					aMMediaType = mediaType;
					return true;
				}
			}
			mediaDetClass = null;
			aMMediaType = new _AMMediaType();
			return false;
		}

		
		public static Bitmap GetFrameFromVideo(string videoFile, double Position, Size target)
		{
			try 
			{
				MediaDetClass mediaDet;
				_AMMediaType mediaType;
				if (openVideoStream(videoFile, out mediaDet, out mediaType))
				{

					//calculates the REAL target size of our frame
					if (target == Size.Empty)
						target = getVideoSize(mediaType);
					else
						target = scaleToFit(target, getVideoSize(mediaType));


					unsafe 
					{
						Size s= GetVideoSize(videoFile);
						int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);
						
						//get size for buffer
						int bufferSize = (((s.Width * s.Height) * 24) / 8 ) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	
						
						//allocates enough memory to store the frame
						IntPtr frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
						byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();

						//gets bitmap, save in frameBuffer2
						mediaDet.GetBitmapBits(Position, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);
						
						//now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits
						
						Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));
						
						bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
						System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);

						return bmp; 

					}
				}
			}
			catch (COMException ex)
			{
				//GC.Collect();
				throw new InvalidVideoFileException(getErrorMsg((uint)ex.ErrorCode), ex);
			}

			//GC.Collect();
			throw new InvalidVideoFileException("No video stream was found");
		}



		private static Size getVideoSize(_AMMediaType mediaType)
		{
			WinStructs.VIDEOINFOHEADER videoInfo = (WinStructs.VIDEOINFOHEADER)Marshal.PtrToStructure(mediaType.pbFormat, typeof(WinStructs.VIDEOINFOHEADER));
			
			return new Size(videoInfo.bmiHeader.biWidth, videoInfo.bmiHeader.biHeight);
		}

		private static Size scaleToFit(Size target, Size original)
		{
			if (target.Height * original.Width > target.Width * original.Height)
				target.Height = target.Width * original.Height / original.Width;
			else
				target.Width = target.Height * original.Width / original.Height;

			return target;
		}
		private static Size scaleToFitSmart(Size target, Size original)
		{
			target = scaleToFit(target, original);

			if (target.Width > original.Width || target.Height > original.Height)
				return original;

			return target;
		}
		private static string getErrorMsg(uint errorCode)
		{
			string errorMsg = null;
			switch(errorCode)
			{
				case 0x80040200:	//VFW_E_INVALIDMEDIATYPE
					errorMsg = "An invalid media type was specified";
					break;
				case 0x80040201:	//VFW_E_INVALIDSUBTYPE
					errorMsg = "An invalid media subtype was specified";
					break;
				case 0x80040202:	//VFW_E_NEED_OWNER
					errorMsg = "This object can only be created as an aggregated object";
					break;
				case 0x80040203:	//VFW_E_ENUM_OUT_OF_SYNC
					errorMsg = "The enumerator has become invalid";
					break;
				case 0x80040204:	//VFW_E_ALREADY_CONNECTED
					errorMsg = "At least one of the pins involved in the operation is already connected";
					break;
				case 0x80040205:	//VFW_E_FILTER_ACTIVE
					errorMsg = "This operation cannot be performed because the filter is active";
					break;
				case 0x80040206:	//VFW_E_NO_TYPES
					errorMsg = "One of the specified pins supports no media types";
					break;
				case 0x80040207:	//VFW_E_NO_ACCEPTABLE_TYPES
					errorMsg = "There is no common media type between these pins";
					break;
				case 0x80040208:	//VFW_E_INVALID_DIRECTION
					errorMsg = "Two pins of the same direction cannot be connected together";
					break;
				case 0x80040209:	//VFW_E_NOT_CONNECTED
					errorMsg = "The operation cannot be performed because the pins are not connected";
					break;
				case 0x80040210:	//VFW_E_NO_ALLOCATOR
					errorMsg = "No sample buffer allocator is available";
					break;
				case 0x80040211:	//VFW_E_NOT_COMMITTED
					errorMsg = "Cannot allocate a sample when the allocator is not active";
					break;
				case 0x80040212:	//VFW_E_SIZENOTSET
					errorMsg = "Cannot allocate memory because no size has been set";
					break;
				case 0x80040213:	//VFW_E_NO_CLOCK
					errorMsg = "Cannot lock for synchronization because no clock has been defined";
					break;
				case 0x80040214:	//VFW_E_NO_SINK
					errorMsg = "Quality messages could not be sent because no quality sink has been defined";
					break;
				case 0x80040215:	//VFW_E_NO_INTERFACE
					errorMsg = "A required interface has not been implemented";
					break;
				case 0x80040216:	//VFW_E_NOT_FOUND
					errorMsg = "An object or name was not found";
					break;
				case 0x80040217:	//VFW_E_CANNOT_CONNECT
					errorMsg = "No combination of intermediate filters could be found to make the connection";
					break;
				case 0x80040218:	//VFW_E_CANNOT_RENDER
					errorMsg = "No combination of filters could be found to render the stream";
					break;
				case 0x80040219:	//VFW_E_CHANGING_FORMAT
					errorMsg = "Could not change formats dynamically";
					break;
				case 0x80040220:	//VFW_E_NO_COLOR_KEY_SET
					errorMsg = "No color key has been set";
					break;
				case 0x80040221:	//VFW_E_NO_DISPLAY_PALETTE
					errorMsg = "Display does not use a palette";
					break;
				case 0x80040222:	//VFW_E_TOO_MANY_COLORS
					errorMsg = "Too many colors for the current display settings";
					break;
				case 0x80040223:	//VFW_E_STATE_CHANGED
					errorMsg = "The state changed while waiting to process the sample";
					break;
				case 0x80040224:	//VFW_E_NOT_STOPPED
					errorMsg = "The operation could not be performed because the filter is not stopped";
					break;
				case 0x80040225:	//VFW_E_NOT_PAUSED
					errorMsg = "The operation could not be performed because the filter is not paused";
					break;
				case 0x80040226:	//VFW_E_NOT_RUNNING
					errorMsg = "The operation could not be performed because the filter is not running";
					break;
				case 0x80040227:	//VFW_E_WRONG_STATE
					errorMsg = "The operation could not be performed because the filter is in the wrong state";
					break;
				case 0x80040228:	//VFW_E_START_TIME_AFTER_END
					errorMsg = "The sample start time is after the sample end time";
					break;
				case 0x80040229:	//VFW_E_INVALID_RECT
					errorMsg = "The supplied rectangle is invalid";
					break;
				case 0x80040230:	//VFW_E_TYPE_NOT_ACCEPTED
					errorMsg = "This pin cannot use the supplied media type";
					break;
				case 0x80040231:	//VFW_E_CIRCULAR_GRAPH
					errorMsg = "The filter graph is circular";
					break;
				case 0x80040232:	//VFW_E_NOT_ALLOWED_TO_SAVE
					errorMsg = "Updates are not allowed in this state";
					break;
				case 0x80040233:	//VFW_E_TIME_ALREADY_PASSED
					errorMsg = "An attempt was made to queue a command for a time in the past";
					break;
				case 0x80040234:	//VFW_E_ALREADY_CANCELLED
					errorMsg = "The queued command has already been canceled";
					break;
				case 0x80040235:	//VFW_E_CORRUPT_GRAPH_FILE
					errorMsg = "Cannot render the file because it is corrupt";
					break;
				case 0x80040236:	//VFW_E_ADVISE_ALREADY_SET
					errorMsg = "An overlay advise link already exists";
					break;
				case 0x00040237:	//VFW_S_STATE_INTERMEDIATE
					errorMsg = "The state transition has not completed";
					break;
				case 0x80040239:	//VFW_E_NO_MODEX_AVAILABLE
					errorMsg = "This Advise cannot be canceled because it was not successfully set";
					break;
				case 0x80040240:	//VFW_E_NO_FULLSCREEN
					errorMsg = "The media type of this file is not recognized";
					break;
				case 0x80040241:	//VFW_E_CANNOT_LOAD_SOURCE_FILTER
					errorMsg = "The source filter for this file could not be loaded";
					break;
				case 0x00040242:	//VFW_S_PARTIAL_RENDER
					errorMsg = "Some of the streams in this movie are in an unsupported format";
					break;
				case 0x80040243:	//VFW_E_FILE_TOO_SHORT
					errorMsg = "A file appeared to be incomplete";
					break;
				case 0x80040244:	//VFW_E_INVALID_FILE_VERSION
					errorMsg = "The version number of the file is invalid";
					break;
				case 0x00040245:	//VFW_S_SOME_DATA_IGNORED
					errorMsg = "The file contained some property settings that were not used";
					break;
				case 0x00040246:	//VFW_S_CONNECTIONS_DEFERRED
					errorMsg = "Some connections have failed and have been deferred";
					break;
				case 0x00040103:	//VFW_E_INVALID_CLSID
					errorMsg = "A registry entry is corrupt";
					break;
				case 0x80040249:	//VFW_E_SAMPLE_TIME_NOT_SET
					errorMsg = "No time stamp has been set for this sample";
					break;
				case 0x00040250:	//VFW_S_RESOURCE_NOT_NEEDED
					errorMsg = "The resource specified is no longer needed";
					break;
				case 0x80040251:	//VFW_E_MEDIA_TIME_NOT_SET
					errorMsg = "No media time stamp has been set for this sample";
					break;
				case 0x80040252:	//VFW_E_NO_TIME_FORMAT_SET
					errorMsg = "No media time format has been selected";
					break;
				case 0x80040253:	//VFW_E_MONO_AUDIO_HW
					errorMsg = "Cannot change balance because audio device is mono only";
					break;
				case 0x00040260:	//VFW_S_MEDIA_TYPE_IGNORED
					errorMsg = "ActiveMovie cannot play MPEG movies on this processor";
					break;
				case 0x80040261:	//VFW_E_NO_TIME_FORMAT
					errorMsg = "Cannot get or set time related information on an object that is using a time format of TIME_FORMAT_NONE";
					break;
				case 0x80040262:	//VFW_E_READ_ONLY
					errorMsg = "The connection cannot be made because the stream is read only and the filter alters the data";
					break;
				case 0x00040263:	//VFW_S_RESERVED
					errorMsg = "This success code is reserved for internal purposes within ActiveMovie";
					break;
				case 0x80040264:	//VFW_E_BUFFER_UNDERFLOW
					errorMsg = "The buffer is not full enough";
					break;
				case 0x80040266:	//VFW_E_UNSUPPORTED_STREAM
					errorMsg = "Pins cannot connect due to not supporting the same transport";
					break;
				case 0x00040267:	//VFW_S_STREAM_OFF
					errorMsg = "The stream has been turned off";
					break;
				case 0x00040270:	//VFW_S_CANT_CUE
					errorMsg = "The stop time for the sample was not set";
					break;
				case 0x80040272:	//VFW_E_OUT_OF_VIDEO_MEMORY
					errorMsg = "The VideoPort connection negotiation process has failed";
					break;
				case 0x80040276:	//VFW_E_DDRAW_CAPS_NOT_SUITABLE
					errorMsg = "This User Operation is inhibited by DVD Content at this time";
					break;
				case 0x80040277:	//VFW_E_DVD_INVALIDDOMAIN
					errorMsg = "This Operation is not permitted in the current domain";
					break;
				case 0x00040280:	//VFW_E_DVD_NO_BUTTON
					errorMsg = "This object cannot be used anymore as its time has expired";
					break;
				case 0x80040281:	//VFW_E_DVD_WRONG_SPEED
					errorMsg = "The operation cannot be performed at the current playback speed";
					break;
				case 0x80040283:	//VFW_E_DVD_MENU_DOES_NOT_EXIST
					errorMsg = "The specified command was either cancelled or no longer exists";
					break;
				case 0x80040284:	//VFW_E_DVD_STATE_WRONG_VERSION
					errorMsg = "The data did not contain a recognized version";
					break;
				case 0x80040285:	//VFW_E_DVD_STATE_CORRUPT
					errorMsg = "The state data was corrupt";
					break;
				case 0x80040286:	//VFW_E_DVD_STATE_WRONG_DISC
					errorMsg = "The state data is from a different disc";
					break;
				case 0x80040287:	//VFW_E_DVD_INCOMPATIBLE_REGION
					errorMsg = "The region was not compatible with the current drive";
					break;
				case 0x80040288:	//VFW_E_DVD_NO_ATTRIBUTES
					errorMsg = "The requested DVD stream attribute does not exist";
					break;
				case 0x80040290:	//VFW_E_DVD_NO_GOUP_PGC
					errorMsg = "The current parental level was too low";
					break;
				case 0x80040291:	//VFW_E_DVD_INVALID_DISC
					errorMsg = "The specified path does not point to a valid DVD disc";
					break;
				case 0x80040292:	//VFW_E_DVD_NO_RESUME_INFORMATION
					errorMsg = "There is currently no resume information";
					break;
				case 0x80040295:	//VFW_E_PIN_ALREADY_BLOCKED_ON_THIS_THREAD
					errorMsg = "An operation failed due to a certification failure";
					break;
				case 0x80040296:	//VFW_E_VMR_NOT_IN_MIXER_MODE
					errorMsg = "The VMR could not find any ProcAmp hardware on the current display device";
					break;
				case 0x80040297:	//VFW_E_VMR_NO_AP_SUPPLIED
					errorMsg = "The application has not yet provided the VMR filter with a valid allocator-presenter object";
					break;
				case 0x80040298:	//VFW_E_VMR_NO_DEINTERLACE_HW
					errorMsg = "The VMR could not find any ProcAmp hardware on the current display device";
					break;
				case 0x80040299:	//VFW_E_VMR_NO_PROCAMP_HW
					errorMsg = "VMR9 does not work with VPE-based hardware decoders";
					break;
				case 0x8004029A:	//VFW_E_DVD_VMR9_INCOMPATIBLEDEC
					errorMsg = "VMR9 does not work with VPE-based hardware decoders";
					break;
				case 0x8004029B:	//VFW_E_NO_COPP_HW
					errorMsg = "The current display device does not support Content Output Protection Protocol (COPP) H/W";
					break;
			}
			return errorMsg;
		}

	



	}
	public class WinStructs
	{
		/// <summary>
		/// The VIDEOINFOHEADER structure describes the bitmap and color information for a video image
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct VIDEOINFOHEADER
		{
			/// <summary>RECT structure that specifies the source video window. This structure can be a clipping rectangle, to select a portion of the source video stream.</summary>
			public RECT rcSource;
			/// <summary>RECT structure that specifies the destination video window.</summary>
			public RECT rcTarget;
			/// <summary>Approximate data rate of the video stream, in bits per second</summary>
			public uint dwBitRate;
			/// <summary>Data error rate, in bit errors per second</summary>
			public uint dwBitErrorRate;
			/// <summary>The desired average display time of the video frames, in 100-nanosecond units. The actual time per frame may be longer. See Remarks.</summary>
			public long AvgTimePerFrame;
			/// <summary>BITMAPINFOHEADER structure that contains color and dimension information for the video image bitmap. If the format block contains a color table or color masks, they immediately follow the bmiHeader member. You can get the first color entry by casting the address of member to a BITMAPINFO pointer</summary>
			public BITMAPINFOHEADER bmiHeader;
		}

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{ 
			int left; 
			int top; 
			int right; 
			int bottom; 
		}

		/// <summary>
		/// The BITMAPINFOHEADER structure contains information about the dimensions and color format of a device-independent bitmap (DIB). 
		/// SEE MSDN
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct BITMAPINFOHEADER
		{
			/// <summary>Specifies the number of bytes required by the structure. This value does not include the size of the color table or the size of the color masks, if they are appended to the end of structure. See Remarks.</summary>
			public uint  biSize;
			/// <summary>Specifies the width of the bitmap, in pixels. For information about calculating the stride of the bitmap, see Remarks.</summary>
			public int   biWidth;
			/// <summary>Specifies the height of the bitmap, in pixels. SEE MSDN</summary>
			public int   biHeight;
			/// <summary>Specifies the number of planes for the target device. This value must be set to 1</summary>
			public ushort   biPlanes;
			/// <summary>Specifies the number of bits per pixel (bpp).  For uncompressed formats, this value gives to the average number of bits per pixel. For compressed formats, this value gives the implied bit depth of the uncompressed image, after the image has been decoded.</summary>
			public ushort   biBitCount;
			/// <summary>For compressed video and YUV formats, this member is a FOURCC code, specified as a DWORD in little-endian order. For example, YUYV video has the FOURCC 'VYUY' or 0x56595559. SEE MSDN</summary>
			public uint  biCompression;
			/// <summary>Specifies the size, in bytes, of the image. This can be set to 0 for uncompressed RGB bitmaps</summary>
			public uint  biSizeImage;
			/// <summary>Specifies the horizontal resolution, in pixels per meter, of the target device for the bitmap</summary>
			public int   biXPelsPerMeter;
			/// <summary>Specifies the vertical resolution, in pixels per meter, of the target device for the bitmap</summary>
			public int   biYPelsPerMeter;
			/// <summary>Specifies the number of color indices in the color table that are actually used by the bitmap. See Remarks for more information.</summary>
			public uint  biClrUsed;
			/// <summary>Specifies the number of color indices that are considered important for displaying the bitmap. If this value is zero, all colors are important</summary>
			public uint  biClrImportant;
		}
	}

		
	public class InvalidVideoFileException : System.Exception
	{
		public InvalidVideoFileException() : base () {}
		public InvalidVideoFileException(string message) : base (message) {}
		public InvalidVideoFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context) {}
		public InvalidVideoFileException(string message, Exception innerException) : base (message, innerException) {}
	}
}
