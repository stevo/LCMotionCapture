using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ctlViewportlib
{
	/// <summary>
	/// Summary description for PostProcessing.
	/// </summary>
	public class PostProcessing : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox previewDisplay;
		private System.Windows.Forms.Button cancelB;
		private System.Windows.Forms.Button okB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		int Contrast;
		int Brightness;
		bool Grayscale;
		//bool contrastCorrection;
		//bool brightnessCorrection;

		Bitmap temp;
		Bitmap previewSample;

		private System.Windows.Forms.CheckBox contrastCorrectionCB;
		private System.Windows.Forms.CheckBox brightnessCorrectionCB;
		private System.Windows.Forms.CheckBox enableGrayscalerCB;
		private System.Windows.Forms.NumericUpDown contrastCorrectionNUD;
		private System.Windows.Forms.NumericUpDown brightnessCorrectionNUD;

		private System.ComponentModel.Container components = null;

		public PostProcessing(int BC, int CC, bool GS, Bitmap PS)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			previewSample = new Bitmap(PS);
			if (CC!=0) 
			{
				contrastCorrectionCB.Checked=true;
				contrastCorrectionNUD.Value=CC;
             
			}

			if (BC!=0) 
			{
				brightnessCorrectionCB.Checked=true;
				brightnessCorrectionNUD.Value=BC;
			}

			if (GS)  enableGrayscalerCB.Checked=true;
			

			UpdatePreview();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostProcessing));
            this.previewDisplay = new System.Windows.Forms.PictureBox();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            this.contrastCorrectionCB = new System.Windows.Forms.CheckBox();
            this.brightnessCorrectionCB = new System.Windows.Forms.CheckBox();
            this.enableGrayscalerCB = new System.Windows.Forms.CheckBox();
            this.contrastCorrectionNUD = new System.Windows.Forms.NumericUpDown();
            this.brightnessCorrectionNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.previewDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastCorrectionNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessCorrectionNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // previewDisplay
            // 
            this.previewDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewDisplay.Location = new System.Drawing.Point(7, 7);
            this.previewDisplay.Name = "previewDisplay";
            this.previewDisplay.Size = new System.Drawing.Size(220, 215);
            this.previewDisplay.TabIndex = 0;
            this.previewDisplay.TabStop = false;
            // 
            // cancelB
            // 
            this.cancelB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelB.BackgroundImage")));
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelB.Location = new System.Drawing.Point(233, 178);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(114, 22);
            this.cancelB.TabIndex = 2;
            this.cancelB.Text = "Cancel";
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // okB
            // 
            this.okB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okB.BackgroundImage")));
            this.okB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okB.Location = new System.Drawing.Point(233, 201);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(114, 21);
            this.okB.TabIndex = 3;
            this.okB.Text = "OK";
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // contrastCorrectionCB
            // 
            this.contrastCorrectionCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contrastCorrectionCB.BackgroundImage")));
            this.contrastCorrectionCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contrastCorrectionCB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastCorrectionCB.Location = new System.Drawing.Point(233, 7);
            this.contrastCorrectionCB.Name = "contrastCorrectionCB";
            this.contrastCorrectionCB.Size = new System.Drawing.Size(114, 21);
            this.contrastCorrectionCB.TabIndex = 4;
            this.contrastCorrectionCB.Text = "Enable Contrast Correction";
            this.contrastCorrectionCB.CheckedChanged += new System.EventHandler(this.contrastCorrectionCB_CheckedChanged);
            // 
            // brightnessCorrectionCB
            // 
            this.brightnessCorrectionCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brightnessCorrectionCB.BackgroundImage")));
            this.brightnessCorrectionCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brightnessCorrectionCB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessCorrectionCB.Location = new System.Drawing.Point(233, 42);
            this.brightnessCorrectionCB.Name = "brightnessCorrectionCB";
            this.brightnessCorrectionCB.Size = new System.Drawing.Size(114, 20);
            this.brightnessCorrectionCB.TabIndex = 5;
            this.brightnessCorrectionCB.Text = "Enable Brightness Correction";
            this.brightnessCorrectionCB.CheckedChanged += new System.EventHandler(this.brightnessCorrectionCB_CheckedChanged);
            // 
            // enableGrayscalerCB
            // 
            this.enableGrayscalerCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enableGrayscalerCB.BackgroundImage")));
            this.enableGrayscalerCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableGrayscalerCB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableGrayscalerCB.Location = new System.Drawing.Point(233, 76);
            this.enableGrayscalerCB.Name = "enableGrayscalerCB";
            this.enableGrayscalerCB.Size = new System.Drawing.Size(114, 21);
            this.enableGrayscalerCB.TabIndex = 6;
            this.enableGrayscalerCB.Text = "Enable Grayscaler";
            this.enableGrayscalerCB.CheckedChanged += new System.EventHandler(this.enableGrayscalerCB_CheckedChanged);
            // 
            // contrastCorrectionNUD
            // 
            this.contrastCorrectionNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contrastCorrectionNUD.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastCorrectionNUD.Location = new System.Drawing.Point(233, 28);
            this.contrastCorrectionNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.contrastCorrectionNUD.Name = "contrastCorrectionNUD";
            this.contrastCorrectionNUD.Size = new System.Drawing.Size(114, 15);
            this.contrastCorrectionNUD.TabIndex = 7;
            this.contrastCorrectionNUD.ValueChanged += new System.EventHandler(this.contrastCorrectionNUD_ValueChanged);
            // 
            // brightnessCorrectionNUD
            // 
            this.brightnessCorrectionNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brightnessCorrectionNUD.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessCorrectionNUD.Location = new System.Drawing.Point(233, 62);
            this.brightnessCorrectionNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.brightnessCorrectionNUD.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.brightnessCorrectionNUD.Name = "brightnessCorrectionNUD";
            this.brightnessCorrectionNUD.Size = new System.Drawing.Size(114, 15);
            this.brightnessCorrectionNUD.TabIndex = 8;
            this.brightnessCorrectionNUD.ValueChanged += new System.EventHandler(this.brightnessCorrectionNUD_ValueChanged);
            // 
            // PostProcessing
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 8);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(356, 227);
            this.Controls.Add(this.brightnessCorrectionNUD);
            this.Controls.Add(this.contrastCorrectionNUD);
            this.Controls.Add(this.enableGrayscalerCB);
            this.Controls.Add(this.brightnessCorrectionCB);
            this.Controls.Add(this.contrastCorrectionCB);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.previewDisplay);
            this.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostProcessing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Post Processing Settings";
            this.TopMost = true;
            this.Enter += new System.EventHandler(this.contrastCorrectionNUD_ValueChanged);
            this.Load += new System.EventHandler(this.PostProcessing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastCorrectionNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessCorrectionNUD)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	
		private void UpdatePreview()

		{

			temp = (Bitmap) previewSample.Clone();

			if (contrastCorrectionCB.Checked) BitmapFilters.Contrast(temp,Convert.ToSByte(contrastCorrectionNUD.Value));

			if (brightnessCorrectionCB.Checked) BitmapFilters.Brightness(temp,Convert.ToSByte(brightnessCorrectionNUD.Value));

			if (enableGrayscalerCB.Checked) BitmapFilters.GrayScale(temp);

            previewDisplay.Image=temp;
			previewDisplay.Invalidate();

		}

		public int getBrightness()
		{
		return Brightness;
		}
		public int getContrast()
		{
		return Contrast;
		}
		public bool getGrayscale()
		{
		return Grayscale;
		}

		


		private void cancelB_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
			this.Hide();
		}

		private void okB_Click(object sender, System.EventArgs e)
		{
			if (contrastCorrectionCB.Checked)
				 Contrast=(int)contrastCorrectionNUD.Value;
			        else Contrast=0;
			if (brightnessCorrectionCB.Checked)
				Brightness=(int)brightnessCorrectionNUD.Value;
					else Brightness=0;

			Grayscale=enableGrayscalerCB.Checked;

			 this.DialogResult=System.Windows.Forms.DialogResult.OK;
             this.Hide();
		}

		private void enableGrayscalerCB_CheckedChanged(object sender, System.EventArgs e)
		{
		UpdatePreview();
		}

		private void brightnessCorrectionCB_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdatePreview();
		}

		private void contrastCorrectionCB_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdatePreview();
		}

		private void contrastCorrectionNUD_ValueChanged(object sender, System.EventArgs e)
		{
			UpdatePreview();
		}

		private void brightnessCorrectionNUD_ValueChanged(object sender, System.EventArgs e)
		{
			UpdatePreview();
		}

		private void PostProcessing_Load(object sender, System.EventArgs e)
		{
			UpdatePreview();
		}

	

	


	}
}
