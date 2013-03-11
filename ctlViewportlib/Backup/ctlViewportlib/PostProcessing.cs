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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PostProcessing));
			this.previewDisplay = new System.Windows.Forms.PictureBox();
			this.cancelB = new System.Windows.Forms.Button();
			this.okB = new System.Windows.Forms.Button();
			this.contrastCorrectionCB = new System.Windows.Forms.CheckBox();
			this.brightnessCorrectionCB = new System.Windows.Forms.CheckBox();
			this.enableGrayscalerCB = new System.Windows.Forms.CheckBox();
			this.contrastCorrectionNUD = new System.Windows.Forms.NumericUpDown();
			this.brightnessCorrectionNUD = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.contrastCorrectionNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessCorrectionNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// previewDisplay
			// 
			this.previewDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewDisplay.Location = new System.Drawing.Point(8, 8);
			this.previewDisplay.Name = "previewDisplay";
			this.previewDisplay.Size = new System.Drawing.Size(264, 248);
			this.previewDisplay.TabIndex = 0;
			this.previewDisplay.TabStop = false;
			// 
			// cancelB
			// 
			this.cancelB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelB.BackgroundImage")));
			this.cancelB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cancelB.Location = new System.Drawing.Point(280, 216);
			this.cancelB.Name = "cancelB";
			this.cancelB.Size = new System.Drawing.Size(136, 16);
			this.cancelB.TabIndex = 2;
			this.cancelB.Text = "Cancel";
			this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
			// 
			// okB
			// 
			this.okB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okB.BackgroundImage")));
			this.okB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.okB.Location = new System.Drawing.Point(280, 240);
			this.okB.Name = "okB";
			this.okB.Size = new System.Drawing.Size(136, 16);
			this.okB.TabIndex = 3;
			this.okB.Text = "OK";
			this.okB.Click += new System.EventHandler(this.okB_Click);
			// 
			// contrastCorrectionCB
			// 
			this.contrastCorrectionCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contrastCorrectionCB.BackgroundImage")));
			this.contrastCorrectionCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.contrastCorrectionCB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.contrastCorrectionCB.Location = new System.Drawing.Point(280, 8);
			this.contrastCorrectionCB.Name = "contrastCorrectionCB";
			this.contrastCorrectionCB.Size = new System.Drawing.Size(136, 24);
			this.contrastCorrectionCB.TabIndex = 4;
			this.contrastCorrectionCB.Text = "Enable Contrast Correction";
			this.contrastCorrectionCB.CheckedChanged += new System.EventHandler(this.contrastCorrectionCB_CheckedChanged);
			// 
			// brightnessCorrectionCB
			// 
			this.brightnessCorrectionCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brightnessCorrectionCB.BackgroundImage")));
			this.brightnessCorrectionCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.brightnessCorrectionCB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.brightnessCorrectionCB.Location = new System.Drawing.Point(280, 48);
			this.brightnessCorrectionCB.Name = "brightnessCorrectionCB";
			this.brightnessCorrectionCB.Size = new System.Drawing.Size(136, 24);
			this.brightnessCorrectionCB.TabIndex = 5;
			this.brightnessCorrectionCB.Text = "Enable Brightness Correction";
			this.brightnessCorrectionCB.CheckedChanged += new System.EventHandler(this.brightnessCorrectionCB_CheckedChanged);
			// 
			// enableGrayscalerCB
			// 
			this.enableGrayscalerCB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enableGrayscalerCB.BackgroundImage")));
			this.enableGrayscalerCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.enableGrayscalerCB.Font = new System.Drawing.Font("Silkscreen", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.enableGrayscalerCB.Location = new System.Drawing.Point(280, 88);
			this.enableGrayscalerCB.Name = "enableGrayscalerCB";
			this.enableGrayscalerCB.Size = new System.Drawing.Size(136, 24);
			this.enableGrayscalerCB.TabIndex = 6;
			this.enableGrayscalerCB.Text = "Enable Grayscaler";
			this.enableGrayscalerCB.CheckedChanged += new System.EventHandler(this.enableGrayscalerCB_CheckedChanged);
			// 
			// contrastCorrectionNUD
			// 
			this.contrastCorrectionNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.contrastCorrectionNUD.Font = new System.Drawing.Font("Silkscreen Expanded", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.contrastCorrectionNUD.Location = new System.Drawing.Point(280, 32);
			this.contrastCorrectionNUD.Minimum = new System.Decimal(new int[] {
																				  100,
																				  0,
																				  0,
																				  -2147483648});
			this.contrastCorrectionNUD.Name = "contrastCorrectionNUD";
			this.contrastCorrectionNUD.Size = new System.Drawing.Size(136, 16);
			this.contrastCorrectionNUD.TabIndex = 7;
			this.contrastCorrectionNUD.ValueChanged += new System.EventHandler(this.contrastCorrectionNUD_ValueChanged);
			// 
			// brightnessCorrectionNUD
			// 
			this.brightnessCorrectionNUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.brightnessCorrectionNUD.Font = new System.Drawing.Font("Silkscreen Expanded", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.brightnessCorrectionNUD.Location = new System.Drawing.Point(280, 72);
			this.brightnessCorrectionNUD.Maximum = new System.Decimal(new int[] {
																					255,
																					0,
																					0,
																					0});
			this.brightnessCorrectionNUD.Minimum = new System.Decimal(new int[] {
																					255,
																					0,
																					0,
																					-2147483648});
			this.brightnessCorrectionNUD.Name = "brightnessCorrectionNUD";
			this.brightnessCorrectionNUD.Size = new System.Drawing.Size(136, 16);
			this.brightnessCorrectionNUD.TabIndex = 8;
			this.brightnessCorrectionNUD.ValueChanged += new System.EventHandler(this.brightnessCorrectionNUD_ValueChanged);
			// 
			// PostProcessing
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(424, 262);
			this.Controls.Add(this.brightnessCorrectionNUD);
			this.Controls.Add(this.contrastCorrectionNUD);
			this.Controls.Add(this.enableGrayscalerCB);
			this.Controls.Add(this.brightnessCorrectionCB);
			this.Controls.Add(this.contrastCorrectionCB);
			this.Controls.Add(this.okB);
			this.Controls.Add(this.cancelB);
			this.Controls.Add(this.previewDisplay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PostProcessing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Post Processing Settings";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.PostProcessing_Load);
			this.Enter += new System.EventHandler(this.contrastCorrectionNUD_ValueChanged);
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
