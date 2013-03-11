using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalApp1
{
	/// <summary>
	/// Summary description for pointsToTrackDialog.
	/// </summary>
	public class framesToTrackDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox framesToTrackTB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox pictureBox1;

        private int FramesCount;
		public int framesCount
		{
			get
			{
             return FramesCount;

			}
			set
			{
            
			}
		}

		public framesToTrackDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            framesToTrackTB.Text=Convert.ToString(FramesCount);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(framesToTrackDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.framesToTrackTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 6);
            this.label1.TabIndex = 7;
            this.label1.Text = "How many frames to track??";
            // 
            // buttonOK
            // 
            this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(150, 61);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(83, 21);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Silkscreen", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(258, 61);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 21);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // framesToTrackTB
            // 
            this.framesToTrackTB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.framesToTrackTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.framesToTrackTB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.framesToTrackTB.Location = new System.Drawing.Point(150, 35);
            this.framesToTrackTB.Name = "framesToTrackTB";
            this.framesToTrackTB.Size = new System.Drawing.Size(192, 15);
            this.framesToTrackTB.TabIndex = 0;
            this.framesToTrackTB.Text = "10";
            this.framesToTrackTB.TextChanged += new System.EventHandler(this.framesToTrackTB_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 118);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // framesToTrackDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(454, 158);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.framesToTrackTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "framesToTrackDialog";
            this.Opacity = 0.9;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Number of frames to track";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.framesToTrackDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
 		{
			bool exception=false;
			try 
			{
   
				FramesCount=Convert.ToInt32(framesToTrackTB.Text);

			} 
			catch (System.InvalidCastException) 
			{
				MessageBox.Show("Invalid parameter entered - please provide natural number");
			    exception=true;
			}
			catch (System.FormatException)
			{
				MessageBox.Show("Invalid parameter entered - please provide natural number");
			    exception=true;
			}
			
			if (!exception)
			{
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			
		}

		private void framesToTrackTB_TextChanged(object sender, System.EventArgs e)
		{
		

	
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			
		
			
				this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			
		}

		private void framesToTrackDialog_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
