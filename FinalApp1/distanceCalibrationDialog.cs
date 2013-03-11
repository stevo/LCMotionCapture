using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalApp1
{
	/// <summary>
	/// Summary description for distanceCalibrationDialog.
	/// </summary>
	public class distanceCalibrationDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox realWorldDistanceTB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox unitCB;
		private System.Windows.Forms.PictureBox previewPB;
		private System.Windows.Forms.Button cancelB;
		private System.Windows.Forms.Button okB;
		private System.Windows.Forms.GroupBox controlsGB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Point point1=new Point(0,0);
		private Point point2=new Point(1,1);
		private Bitmap clear_sample;
		private bool LMBPressed=false;
		double Distance=0;
		public double distance
		{
			get
			{
				return Distance;
			}
			set
			{
			}
		}

		public double relativeDistance
		{
			get
			{
              double mm=Convert.ToInt32(realWorldDistanceTB.Text);
				if (unitCB.SelectedIndex==1) mm*=10;
				if (unitCB.SelectedIndex==2) mm*=100;

				return mm/Distance;

			}
			set
			{
			}
		}



		public distanceCalibrationDialog(Bitmap sample)
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			previewPB.Width=sample.Width;
			previewPB.Height=sample.Height;
			previewPB_Resize(null,null);
			previewPB.Image=sample;
			
			clear_sample=sample;
			this.SetStyle(ControlStyles.DoubleBuffer | 
				ControlStyles.UserPaint | 
				ControlStyles.AllPaintingInWmPaint,
				true);
			this.UpdateStyles();


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(distanceCalibrationDialog));
            this.previewPB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.realWorldDistanceTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unitCB = new System.Windows.Forms.ComboBox();
            this.controlsGB = new System.Windows.Forms.GroupBox();
            this.cancelB = new System.Windows.Forms.Button();
            this.okB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewPB)).BeginInit();
            this.controlsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewPB
            // 
            this.previewPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPB.Location = new System.Drawing.Point(7, 7);
            this.previewPB.Name = "previewPB";
            this.previewPB.Size = new System.Drawing.Size(313, 187);
            this.previewPB.TabIndex = 0;
            this.previewPB.TabStop = false;
            this.previewPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewPB_MouseDown);
            this.previewPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.previewPB_MouseMove);
            this.previewPB.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPB_Paint);
            this.previewPB.Resize += new System.EventHandler(this.previewPB_Resize);
            this.previewPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.previewPB_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "First point    : 0x0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second point  : 0x0";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Distance (px)  : 0";
            // 
            // realWorldDistanceTB
            // 
            this.realWorldDistanceTB.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.realWorldDistanceTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.realWorldDistanceTB.Location = new System.Drawing.Point(187, 20);
            this.realWorldDistanceTB.Name = "realWorldDistanceTB";
            this.realWorldDistanceTB.Size = new System.Drawing.Size(60, 15);
            this.realWorldDistanceTB.TabIndex = 0;
            this.realWorldDistanceTB.Text = "10";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(187, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 7);
            this.label4.TabIndex = 5;
            this.label4.Text = "Real world distance";
            // 
            // unitCB
            // 
            this.unitCB.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.unitCB.Items.AddRange(new object[] {
            "mm",
            "cm",
            "m"});
            this.unitCB.Location = new System.Drawing.Point(253, 20);
            this.unitCB.Name = "unitCB";
            this.unitCB.Size = new System.Drawing.Size(54, 15);
            this.unitCB.TabIndex = 1;
            this.unitCB.Text = "mm";
            // 
            // controlsGB
            // 
            this.controlsGB.BackColor = System.Drawing.Color.Transparent;
            this.controlsGB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlsGB.BackgroundImage")));
            this.controlsGB.Controls.Add(this.cancelB);
            this.controlsGB.Controls.Add(this.okB);
            this.controlsGB.Controls.Add(this.label2);
            this.controlsGB.Controls.Add(this.label3);
            this.controlsGB.Controls.Add(this.label1);
            this.controlsGB.Controls.Add(this.realWorldDistanceTB);
            this.controlsGB.Controls.Add(this.unitCB);
            this.controlsGB.Controls.Add(this.label4);
            this.controlsGB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsGB.Location = new System.Drawing.Point(7, 201);
            this.controlsGB.Name = "controlsGB";
            this.controlsGB.Size = new System.Drawing.Size(313, 90);
            this.controlsGB.TabIndex = 23;
            this.controlsGB.TabStop = false;
            this.controlsGB.Text = "Point defining";
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelB.Location = new System.Drawing.Point(157, 62);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(150, 21);
            this.cancelB.TabIndex = 3;
            this.cancelB.Text = "Cancel";
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // okB
            // 
            this.okB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.okB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okB.Location = new System.Drawing.Point(7, 62);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(149, 21);
            this.okB.TabIndex = 2;
            this.okB.Text = "OK";
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // distanceCalibrationDialog
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(327, 303);
            this.Controls.Add(this.controlsGB);
            this.Controls.Add(this.previewPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(333, 326);
            this.Name = "distanceCalibrationDialog";
            this.Opacity = 0.9;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distance Calibration";
            ((System.ComponentModel.ISupportInitialize)(this.previewPB)).EndInit();
            this.controlsGB.ResumeLayout(false);
            this.controlsGB.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void previewPB_Resize(object sender, System.EventArgs e)
		{
			this.Width=previewPB.Width+24;
			this.Height=previewPB.Height+160;
			controlsGB.Left=8;
			controlsGB.Top=previewPB.Height+16;
		}

		private void previewPB_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			point1.X=e.X;
			point1.Y=e.Y;
			LMBPressed=true;
			label1.Text="First point    : "+point1.X.ToString()+"x"+point1.Y.ToString();
		}

		private void previewPB_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			point2.X=e.X;
			point2.Y=e.Y;
			label2.Text="Second point  : "+point2.X.ToString()+"x"+point2.Y.ToString();
			Distance = CalculateDistance();
			label3.Text="Distance (px)  : "+Distance.ToString();
			LMBPressed=false;
		}

		private double CalculateDistance()
		{
			if (point1.X==point2.X)
				return Math.Abs(point1.Y-point2.Y);
			else if (point1.Y==point2.Y)
				return Math.Abs(point1.X-point2.X);
			else 
			{
              int a = Math.Abs(point1.Y-point2.Y);
              int b = Math.Abs(point1.X-point2.X);
              return Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2));
			}
			
		}

		private void okB_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cancelB_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void previewPB_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (LMBPressed)
			{
				point2.X = e.X;
				point2.Y= e.Y;
				Distance = CalculateDistance();
				label3.Text="Distance (px)  : "+Distance.ToString();
				previewPB_Paint(null,null);

			}

		}

	

		private void previewPB_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			previewPB.Image=(Bitmap)clear_sample.Clone();
			previewPB.Invalidate();
			Graphics g = Graphics.FromImage( previewPB.Image );
			Pen pen = new Pen(Color.FromArgb(128,255,0,0),1);
			Brush brush = new SolidBrush(Color.FromArgb(128,200,0,0));
			Point startPoint = point1;
			Point endPoint = point2;
			g.DrawLine(pen, startPoint, endPoint);
			g.DrawEllipse(pen,point1.X,point1.Y,2,3);
			g.DrawEllipse(pen,point2.X,point2.Y,2,3);
			g.FillEllipse(brush,point2.X-1,point2.Y-1,2,3);
			g.FillEllipse(brush,point1.X-1,point1.Y-1,2,3);
			previewPB.Invalidate();

		}
	}
}
