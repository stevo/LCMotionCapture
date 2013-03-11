using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalApp1
{
	/// <summary>
	/// Summary description for trackedPointsViewer.
	/// </summary>
	public class trackedPointsViewer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox xyCoordYTB;
		private System.Windows.Forms.TextBox xzCoordXTB;
		private System.Windows.Forms.TextBox xzCoordZTB;
		private System.Windows.Forms.TextBox yzCoordYTB;
		private System.Windows.Forms.TextBox yzCoordZTB;
		private System.Windows.Forms.TextBox worldCoordXTB;
		private System.Windows.Forms.TextBox worldCoordYTB;
		private System.Windows.Forms.TextBox worldCoordZTB;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button prevTimeFrameB;
		private System.Windows.Forms.Button nextTimeFrameB;
		private System.Windows.Forms.Button nextTrackingPointB;
		private System.Windows.Forms.Button pravTrackingPointB;
		private System.Windows.Forms.ListBox timeFrameLB;
		private System.Windows.Forms.ListBox trackingPointLB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		BaseTypes.trackingHistory TrackingHistory;
		private System.Windows.Forms.TextBox xyCoordXTB;
		private System.ComponentModel.Container components = null;

		public trackedPointsViewer(BaseTypes.trackingHistory TrackingHistory)
		{
			//
			// Required for Windows Form Designer support
			//
			this.TrackingHistory=new BaseTypes.trackingHistory();
			this.TrackingHistory=TrackingHistory;
			InitializeComponent();
			refreshData();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trackedPointsViewer));
            this.buttonOK = new System.Windows.Forms.Button();
            this.timeFrameLB = new System.Windows.Forms.ListBox();
            this.xyCoordXTB = new System.Windows.Forms.TextBox();
            this.xyCoordYTB = new System.Windows.Forms.TextBox();
            this.xzCoordXTB = new System.Windows.Forms.TextBox();
            this.xzCoordZTB = new System.Windows.Forms.TextBox();
            this.yzCoordYTB = new System.Windows.Forms.TextBox();
            this.yzCoordZTB = new System.Windows.Forms.TextBox();
            this.worldCoordXTB = new System.Windows.Forms.TextBox();
            this.worldCoordYTB = new System.Windows.Forms.TextBox();
            this.worldCoordZTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prevTimeFrameB = new System.Windows.Forms.Button();
            this.nextTimeFrameB = new System.Windows.Forms.Button();
            this.pravTrackingPointB = new System.Windows.Forms.Button();
            this.nextTrackingPointB = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.trackingPointLB = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(187, 342);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(87, 21);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // timeFrameLB
            // 
            this.timeFrameLB.BackColor = System.Drawing.Color.LightGray;
            this.timeFrameLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeFrameLB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeFrameLB.ItemHeight = 7;
            this.timeFrameLB.Location = new System.Drawing.Point(8, 16);
            this.timeFrameLB.Name = "timeFrameLB";
            this.timeFrameLB.Size = new System.Drawing.Size(113, 359);
            this.timeFrameLB.TabIndex = 5;
            this.timeFrameLB.SelectedIndexChanged += new System.EventHandler(this.timeFrameLB_SelectedIndexChanged);
            // 
            // xyCoordXTB
            // 
            this.xyCoordXTB.BackColor = System.Drawing.Color.DarkOrange;
            this.xyCoordXTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xyCoordXTB.Location = new System.Drawing.Point(151, 1);
            this.xyCoordXTB.Name = "xyCoordXTB";
            this.xyCoordXTB.Size = new System.Drawing.Size(123, 20);
            this.xyCoordXTB.TabIndex = 6;
            // 
            // xyCoordYTB
            // 
            this.xyCoordYTB.BackColor = System.Drawing.Color.DarkOrange;
            this.xyCoordYTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xyCoordYTB.Location = new System.Drawing.Point(151, 22);
            this.xyCoordYTB.Name = "xyCoordYTB";
            this.xyCoordYTB.Size = new System.Drawing.Size(123, 20);
            this.xyCoordYTB.TabIndex = 7;
            // 
            // xzCoordXTB
            // 
            this.xzCoordXTB.BackColor = System.Drawing.Color.DarkOrange;
            this.xzCoordXTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xzCoordXTB.Location = new System.Drawing.Point(151, 43);
            this.xzCoordXTB.Name = "xzCoordXTB";
            this.xzCoordXTB.Size = new System.Drawing.Size(123, 20);
            this.xzCoordXTB.TabIndex = 8;
            // 
            // xzCoordZTB
            // 
            this.xzCoordZTB.BackColor = System.Drawing.Color.DarkOrange;
            this.xzCoordZTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xzCoordZTB.Location = new System.Drawing.Point(151, 64);
            this.xzCoordZTB.Name = "xzCoordZTB";
            this.xzCoordZTB.Size = new System.Drawing.Size(123, 20);
            this.xzCoordZTB.TabIndex = 9;
            // 
            // yzCoordYTB
            // 
            this.yzCoordYTB.BackColor = System.Drawing.Color.DarkOrange;
            this.yzCoordYTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yzCoordYTB.Location = new System.Drawing.Point(151, 85);
            this.yzCoordYTB.Name = "yzCoordYTB";
            this.yzCoordYTB.Size = new System.Drawing.Size(123, 20);
            this.yzCoordYTB.TabIndex = 10;
            // 
            // yzCoordZTB
            // 
            this.yzCoordZTB.BackColor = System.Drawing.Color.DarkOrange;
            this.yzCoordZTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yzCoordZTB.Location = new System.Drawing.Point(151, 106);
            this.yzCoordZTB.Name = "yzCoordZTB";
            this.yzCoordZTB.Size = new System.Drawing.Size(123, 20);
            this.yzCoordZTB.TabIndex = 11;
            // 
            // worldCoordXTB
            // 
            this.worldCoordXTB.BackColor = System.Drawing.Color.DarkOrange;
            this.worldCoordXTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldCoordXTB.Location = new System.Drawing.Point(151, 127);
            this.worldCoordXTB.Name = "worldCoordXTB";
            this.worldCoordXTB.Size = new System.Drawing.Size(123, 20);
            this.worldCoordXTB.TabIndex = 12;
            // 
            // worldCoordYTB
            // 
            this.worldCoordYTB.BackColor = System.Drawing.Color.DarkOrange;
            this.worldCoordYTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldCoordYTB.Location = new System.Drawing.Point(151, 148);
            this.worldCoordYTB.Name = "worldCoordYTB";
            this.worldCoordYTB.Size = new System.Drawing.Size(123, 20);
            this.worldCoordYTB.TabIndex = 13;
            // 
            // worldCoordZTB
            // 
            this.worldCoordZTB.BackColor = System.Drawing.Color.DarkOrange;
            this.worldCoordZTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldCoordZTB.Location = new System.Drawing.Point(151, 169);
            this.worldCoordZTB.Name = "worldCoordZTB";
            this.worldCoordZTB.Size = new System.Drawing.Size(123, 20);
            this.worldCoordZTB.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.xyCoordXTB);
            this.panel1.Controls.Add(this.yzCoordYTB);
            this.panel1.Controls.Add(this.xzCoordXTB);
            this.panel1.Controls.Add(this.worldCoordXTB);
            this.panel1.Controls.Add(this.worldCoordYTB);
            this.panel1.Controls.Add(this.worldCoordZTB);
            this.panel1.Controls.Add(this.yzCoordZTB);
            this.panel1.Controls.Add(this.xyCoordYTB);
            this.panel1.Controls.Add(this.xzCoordZTB);
            this.panel1.Controls.Add(this.prevTimeFrameB);
            this.panel1.Controls.Add(this.nextTimeFrameB);
            this.panel1.Controls.Add(this.pravTrackingPointB);
            this.panel1.Controls.Add(this.nextTrackingPointB);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Location = new System.Drawing.Point(260, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 365);
            this.panel1.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 10);
            this.label9.TabIndex = 23;
            this.label9.Text = "World Coordinate Z :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 10);
            this.label8.TabIndex = 22;
            this.label8.Text = "World Coordinate Y :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "World coordinate X :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-7, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 10);
            this.label6.TabIndex = 20;
            this.label6.Text = "YZ Viewport coordinate Z :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-4, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 10);
            this.label5.TabIndex = 19;
            this.label5.Text = "YZ Viewport coordinate Y :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 10);
            this.label4.TabIndex = 18;
            this.label4.Text = "XZ Viewport coordinate Z :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 10);
            this.label3.TabIndex = 17;
            this.label3.Text = "XZ Viewport coordinate X :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-4, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 10);
            this.label2.TabIndex = 16;
            this.label2.Text = "XY Viewport coordinate Y :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 10);
            this.label1.TabIndex = 15;
            this.label1.Text = "XY Viewport coordinate X :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // prevTimeFrameB
            // 
            this.prevTimeFrameB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prevTimeFrameB.BackgroundImage")));
            this.prevTimeFrameB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevTimeFrameB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevTimeFrameB.Location = new System.Drawing.Point(1, 321);
            this.prevTimeFrameB.Name = "prevTimeFrameB";
            this.prevTimeFrameB.Size = new System.Drawing.Size(95, 20);
            this.prevTimeFrameB.TabIndex = 20;
            this.prevTimeFrameB.Text = "Prev frame";
            this.prevTimeFrameB.Click += new System.EventHandler(this.prevTimeFrameB_Click);
            // 
            // nextTimeFrameB
            // 
            this.nextTimeFrameB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextTimeFrameB.BackgroundImage")));
            this.nextTimeFrameB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextTimeFrameB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextTimeFrameB.Location = new System.Drawing.Point(97, 321);
            this.nextTimeFrameB.Name = "nextTimeFrameB";
            this.nextTimeFrameB.Size = new System.Drawing.Size(90, 20);
            this.nextTimeFrameB.TabIndex = 21;
            this.nextTimeFrameB.Text = "next frame";
            this.nextTimeFrameB.Click += new System.EventHandler(this.nextTimeFrameB_Click);
            // 
            // pravTrackingPointB
            // 
            this.pravTrackingPointB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pravTrackingPointB.BackgroundImage")));
            this.pravTrackingPointB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pravTrackingPointB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pravTrackingPointB.Location = new System.Drawing.Point(1, 342);
            this.pravTrackingPointB.Name = "pravTrackingPointB";
            this.pravTrackingPointB.Size = new System.Drawing.Size(95, 21);
            this.pravTrackingPointB.TabIndex = 22;
            this.pravTrackingPointB.Text = "prev point";
            this.pravTrackingPointB.Click += new System.EventHandler(this.pravTrackingPointB_Click);
            // 
            // nextTrackingPointB
            // 
            this.nextTrackingPointB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextTrackingPointB.BackgroundImage")));
            this.nextTrackingPointB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextTrackingPointB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextTrackingPointB.Location = new System.Drawing.Point(97, 342);
            this.nextTrackingPointB.Name = "nextTrackingPointB";
            this.nextTrackingPointB.Size = new System.Drawing.Size(90, 21);
            this.nextTrackingPointB.TabIndex = 23;
            this.nextTrackingPointB.Text = "next point";
            this.nextTrackingPointB.Click += new System.EventHandler(this.nextTrackingPointB_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(264, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 10);
            this.label10.TabIndex = 16;
            this.label10.Text = "Point parameters :";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 10);
            this.label11.TabIndex = 17;
            this.label11.Text = "Time frame:";
            // 
            // trackingPointLB
            // 
            this.trackingPointLB.BackColor = System.Drawing.Color.LightGray;
            this.trackingPointLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackingPointLB.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackingPointLB.ItemHeight = 7;
            this.trackingPointLB.Location = new System.Drawing.Point(122, 16);
            this.trackingPointLB.Name = "trackingPointLB";
            this.trackingPointLB.Size = new System.Drawing.Size(137, 359);
            this.trackingPointLB.TabIndex = 18;
            this.trackingPointLB.SelectedIndexChanged += new System.EventHandler(this.trackingPointLB_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(125, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 10);
            this.label12.TabIndex = 19;
            this.label12.Text = "Tracking point:";
            // 
            // trackedPointsViewer
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonOK;
            this.ClientSize = new System.Drawing.Size(548, 382);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackingPointLB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.timeFrameLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "trackedPointsViewer";
            this.ShowInTaskbar = false;
            this.Text = "Tracked points browser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void refreshData()
		{
			foreach (BaseTypes.trackingPointLite tpp in TrackingHistory.initialTrackingPointsSet)
			{
              trackingPointLB.Items.Add(tpp.pName);

			}

			foreach (BaseTypes.timeFrame tf in TrackingHistory.trackingHistorySet)
			{
             timeFrameLB.Items.Add(tf.frame);


			}

		}
		
	
		private void trackingPointLB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			
			
		   BaseTypes.timeFrame tf=null;

			foreach (BaseTypes.timeFrame TF in TrackingHistory.trackingHistorySet)
				if (TF.frame==Convert.ToInt32(timeFrameLB.SelectedItem))
				{
					tf=TF;
					break;
				} 

			if (tf!=null) 
			{
				BaseTypes.trackingPointLite tpp = tf.GetPoint(Convert.ToString(trackingPointLB.SelectedItem));

				xyCoordXTB.Text=Convert.ToString(tpp.xyCoordX);
				xyCoordYTB.Text=Convert.ToString(tpp.xyCoordY);

				xzCoordXTB.Text=Convert.ToString(tpp.xzCoordX);
				xzCoordZTB.Text=Convert.ToString(tpp.xzCoordZ);

				yzCoordYTB.Text=Convert.ToString(tpp.yzCoordY);
				yzCoordZTB.Text=Convert.ToString(tpp.yzCoordZ);

				worldCoordXTB.Text=Convert.ToString(tpp.worldCoordX);
				worldCoordYTB.Text=Convert.ToString(tpp.worldCoordY);
				worldCoordZTB.Text=Convert.ToString(tpp.worldCoordZ);
			
			}
		}

		private void timeFrameLB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BaseTypes.timeFrame tf=null;

			foreach (BaseTypes.timeFrame TF in TrackingHistory.trackingHistorySet)
				if (TF.frame==Convert.ToInt32(timeFrameLB.SelectedItem))
				{
					tf=TF;
					break;
				} 

			if (tf!=null) 
			{
				BaseTypes.trackingPointLite tpp = tf.GetPoint(Convert.ToString(trackingPointLB.SelectedItem));

				xyCoordXTB.Text=Convert.ToString(tpp.xyCoordX);
				xyCoordYTB.Text=Convert.ToString(tpp.xyCoordY);

				xzCoordXTB.Text=Convert.ToString(tpp.xzCoordX);
				xzCoordZTB.Text=Convert.ToString(tpp.xzCoordZ);

				yzCoordYTB.Text=Convert.ToString(tpp.yzCoordY);
				yzCoordZTB.Text=Convert.ToString(tpp.yzCoordZ);

				worldCoordXTB.Text=Convert.ToString(tpp.worldCoordX);
				worldCoordYTB.Text=Convert.ToString(tpp.worldCoordY);
				worldCoordZTB.Text=Convert.ToString(tpp.worldCoordZ);
			
			}
		}

		private void nextTimeFrameB_Click(object sender, System.EventArgs e)
		{
			if (timeFrameLB.SelectedIndex+1<timeFrameLB.Items.Count)
			timeFrameLB.SelectedIndex+=1;
		}

		private void prevTimeFrameB_Click(object sender, System.EventArgs e)
		{
			if (timeFrameLB.SelectedIndex-1>=0)
			timeFrameLB.SelectedIndex-=1;
		}

		private void nextTrackingPointB_Click(object sender, System.EventArgs e)
		{
			if (trackingPointLB.SelectedIndex+1<trackingPointLB.Items.Count)
			trackingPointLB.SelectedIndex+=1;
		}

		private void pravTrackingPointB_Click(object sender, System.EventArgs e)
		{
			if (trackingPointLB.SelectedIndex-1>=0)
			trackingPointLB.SelectedIndex-=1;
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=System.Windows.Forms.DialogResult.OK;
			this.Close();

		}
	}
}
