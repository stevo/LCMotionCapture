using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalApp1
{
	/// <summary>
	/// Summary description for trackingPointProperties.
	/// </summary>
	public class trackingPointProperties : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label xyLocYL;
		public System.Windows.Forms.Label xyLocXL;
		public System.Windows.Forms.Label xzLocZL;
		private System.Windows.Forms.Label label;
		public System.Windows.Forms.Label xzLocXL;
		public System.Windows.Forms.Label yzLocZL;
		public System.Windows.Forms.Label yzLocYL;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.Label xyRadL;
		public System.Windows.Forms.Label xzRadL;
		public System.Windows.Forms.Label yzRadL;
		private System.Windows.Forms.ColorDialog ColorDialog;
		private System.Windows.Forms.Button changeColorB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		

		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.TextBox pointNameTB;

		private Color col;
		public Color color
		{ 
			get
			{
				return col;
			}
			set
			{
			}
		}
        private ArrayList trackingPoints;
		private System.Windows.Forms.PictureBox pictureBox1;
	
		bool updating=false;
		public trackingPointProperties(ArrayList TrackingPoints)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
           this.trackingPoints=TrackingPoints;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public trackingPointProperties(trackingPoint tp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.col=tp.PColor;
			this.pointNameTB.Text=tp.PName;
			this.xyLocXL.Text=Convert.ToString(tp.XyCoordX);
			this.xyLocYL.Text=Convert.ToString(tp.XyCoordY);
			this.xzLocXL.Text=Convert.ToString(tp.XzCoordX);
			this.xzLocZL.Text=Convert.ToString(tp.XzCoordZ);
			this.yzLocYL.Text=Convert.ToString(tp.YzCoordY);
			this.yzLocZL.Text=Convert.ToString(tp.YzCoordZ);
			this.xyRadL.Text=Convert.ToString(tp.XyRadius);
			this.xzRadL.Text=Convert.ToString(tp.XzRadius);
			this.yzRadL.Text=Convert.ToString(tp.YzRadius);

			updating=true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trackingPointProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.xyLocYL = new System.Windows.Forms.Label();
            this.xyLocXL = new System.Windows.Forms.Label();
            this.xzLocZL = new System.Windows.Forms.Label();
            this.xzLocXL = new System.Windows.Forms.Label();
            this.yzLocZL = new System.Windows.Forms.Label();
            this.yzLocYL = new System.Windows.Forms.Label();
            this.pointNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.xyRadL = new System.Windows.Forms.Label();
            this.xzRadL = new System.Windows.Forms.Label();
            this.yzRadL = new System.Windows.Forms.Label();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.changeColorB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 7);
            this.label1.TabIndex = 0;
            this.label1.Text = "XY Location";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 7);
            this.label2.TabIndex = 1;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 7);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 6);
            this.label4.TabIndex = 5;
            this.label4.Text = "Z:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 7);
            this.label5.TabIndex = 4;
            this.label5.Text = "X:";
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(7, 35);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(113, 7);
            this.label.TabIndex = 3;
            this.label.Text = "XZ Location";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 7);
            this.label7.TabIndex = 8;
            this.label7.Text = "Z:";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 7);
            this.label8.TabIndex = 7;
            this.label8.Text = "Y:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 7);
            this.label9.TabIndex = 6;
            this.label9.Text = "YZ Location";
            // 
            // xyLocYL
            // 
            this.xyLocYL.BackColor = System.Drawing.Color.Transparent;
            this.xyLocYL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xyLocYL.Location = new System.Drawing.Point(20, 21);
            this.xyLocYL.Name = "xyLocYL";
            this.xyLocYL.Size = new System.Drawing.Size(100, 7);
            this.xyLocYL.TabIndex = 10;
            // 
            // xyLocXL
            // 
            this.xyLocXL.BackColor = System.Drawing.Color.Transparent;
            this.xyLocXL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xyLocXL.Location = new System.Drawing.Point(20, 14);
            this.xyLocXL.Name = "xyLocXL";
            this.xyLocXL.Size = new System.Drawing.Size(100, 7);
            this.xyLocXL.TabIndex = 9;
            // 
            // xzLocZL
            // 
            this.xzLocZL.BackColor = System.Drawing.Color.Transparent;
            this.xzLocZL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xzLocZL.Location = new System.Drawing.Point(20, 49);
            this.xzLocZL.Name = "xzLocZL";
            this.xzLocZL.Size = new System.Drawing.Size(100, 6);
            this.xzLocZL.TabIndex = 12;
            // 
            // xzLocXL
            // 
            this.xzLocXL.BackColor = System.Drawing.Color.Transparent;
            this.xzLocXL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xzLocXL.Location = new System.Drawing.Point(20, 42);
            this.xzLocXL.Name = "xzLocXL";
            this.xzLocXL.Size = new System.Drawing.Size(100, 7);
            this.xzLocXL.TabIndex = 11;
            // 
            // yzLocZL
            // 
            this.yzLocZL.BackColor = System.Drawing.Color.Transparent;
            this.yzLocZL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yzLocZL.Location = new System.Drawing.Point(20, 76);
            this.yzLocZL.Name = "yzLocZL";
            this.yzLocZL.Size = new System.Drawing.Size(100, 7);
            this.yzLocZL.TabIndex = 14;
            // 
            // yzLocYL
            // 
            this.yzLocYL.BackColor = System.Drawing.Color.Transparent;
            this.yzLocYL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yzLocYL.Location = new System.Drawing.Point(20, 69);
            this.yzLocYL.Name = "yzLocYL";
            this.yzLocYL.Size = new System.Drawing.Size(100, 7);
            this.yzLocYL.TabIndex = 13;
            // 
            // pointNameTB
            // 
            this.pointNameTB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pointNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointNameTB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointNameTB.Location = new System.Drawing.Point(7, 104);
            this.pointNameTB.Name = "pointNameTB";
            this.pointNameTB.Size = new System.Drawing.Size(160, 15);
            this.pointNameTB.TabIndex = 15;
            this.pointNameTB.Text = "point1";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 6);
            this.label6.TabIndex = 16;
            this.label6.Text = "Enter point name:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAccept.BackgroundImage")));
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.Location = new System.Drawing.Point(3, 179);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(80, 20);
            this.buttonAccept.TabIndex = 18;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(90, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 20);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(124, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 5);
            this.label10.TabIndex = 22;
            this.label10.Text = "XY Radius";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(123, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 5);
            this.label11.TabIndex = 23;
            this.label11.Text = "XZ Radius";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(122, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 6);
            this.label12.TabIndex = 24;
            this.label12.Text = "YZ Radius";
            // 
            // xyRadL
            // 
            this.xyRadL.BackColor = System.Drawing.Color.Transparent;
            this.xyRadL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xyRadL.Location = new System.Drawing.Point(124, 14);
            this.xyRadL.Name = "xyRadL";
            this.xyRadL.Size = new System.Drawing.Size(55, 14);
            this.xyRadL.TabIndex = 25;
            this.xyRadL.Text = "4";
            // 
            // xzRadL
            // 
            this.xzRadL.BackColor = System.Drawing.Color.Transparent;
            this.xzRadL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xzRadL.Location = new System.Drawing.Point(124, 42);
            this.xzRadL.Name = "xzRadL";
            this.xzRadL.Size = new System.Drawing.Size(55, 13);
            this.xzRadL.TabIndex = 26;
            this.xzRadL.Text = "4";
            // 
            // yzRadL
            // 
            this.yzRadL.BackColor = System.Drawing.Color.Transparent;
            this.yzRadL.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yzRadL.Location = new System.Drawing.Point(123, 69);
            this.yzRadL.Name = "yzRadL";
            this.yzRadL.Size = new System.Drawing.Size(55, 6);
            this.yzRadL.TabIndex = 27;
            this.yzRadL.Text = "4";
            // 
            // changeColorB
            // 
            this.changeColorB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("changeColorB.BackgroundImage")));
            this.changeColorB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeColorB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeColorB.Location = new System.Drawing.Point(7, 122);
            this.changeColorB.Name = "changeColorB";
            this.changeColorB.Size = new System.Drawing.Size(160, 18);
            this.changeColorB.TabIndex = 28;
            this.changeColorB.Text = "change color";
            this.changeColorB.Click += new System.EventHandler(this.changeColorB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(217, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 118);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // trackingPointProperties
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 208);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.changeColorB);
            this.Controls.Add(this.yzRadL);
            this.Controls.Add(this.xzRadL);
            this.Controls.Add(this.xyRadL);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pointNameTB);
            this.Controls.Add(this.yzLocZL);
            this.Controls.Add(this.yzLocYL);
            this.Controls.Add(this.xzLocZL);
            this.Controls.Add(this.xzLocXL);
            this.Controls.Add(this.xyLocYL);
            this.Controls.Add(this.xyLocXL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "trackingPointProperties";
            this.Opacity = 0.9;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trackpoint Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			bool alreadyDefined=false;
			
			if (!updating)
			 if (trackingPoints!=null)
				foreach (BaseTypes.trackingPointLite tp in trackingPoints)
			{
				if (tp.pName==this.pointNameTB.Text)
				{
					MessageBox.Show("Point with the same name is already defined!");
					alreadyDefined=true;
					break;

				}

			}
			
			if(!alreadyDefined)
			{
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}

		private void changeColorB_Click(object sender, System.EventArgs e)
		{
			if (ColorDialog.ShowDialog() == DialogResult.OK)
				col =  ColorDialog.Color; else col=System.Drawing.Color.Orange;

		}

	
	}
}
