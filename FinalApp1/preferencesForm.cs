using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalApp1
{
	/// <summary>
	/// Form designed to handle setting all properties of project/application
	/// (ogólnie masa przypisywania i if'ów :))
	/// </summary>
	public class preferencesForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		public BaseTypes.Settings localSettingsInstance;
		private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button okB;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox frameIteratorTB;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox preciseAcceptanceThresholdTB;
        private System.Windows.Forms.TextBox scanAreaOffsetTB;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox minWeightTB;
		private System.Windows.Forms.TextBox maxWeightTB;
		private System.Windows.Forms.TextBox hiddenLayersSizeTB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox hiddenLayersCountTB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox trainingRateTB;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox neuralNetworksInitialLearningDurationTB;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox verticalResTB;
		private System.Windows.Forms.TextBox horizontalResTB;
		private System.Windows.Forms.TextBox scalingFactorTB;
		private System.Windows.Forms.RadioButton customResolutionRB;
		private System.Windows.Forms.RadioButton scaleByRB;
        private System.Windows.Forms.RadioButton keepNativeSizeRB;
		private System.Windows.Forms.RadioButton yzViewportRB;
		private System.Windows.Forms.RadioButton xzViewportRB;
        private System.Windows.Forms.RadioButton xyViewportRB;
		private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox minimumTrackingPointRadiusTB;
        private System.Windows.Forms.TextBox maximumTrackingPointRadiusTB;
        private ErrorProvider errorProvider1;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private IContainer components;

        private BaseTypes.viewport last_viewport = BaseTypes.viewport.XY;

		public preferencesForm(BaseTypes.Settings settings)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			localSettingsInstance=new FinalApp1.BaseTypes.Settings();
			InitializeValues(settings);

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(preferencesForm));
            this.okB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.minimumTrackingPointRadiusTB = new System.Windows.Forms.TextBox();
            this.maximumTrackingPointRadiusTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.frameIteratorTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.preciseAcceptanceThresholdTB = new System.Windows.Forms.TextBox();
            this.scanAreaOffsetTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenLayersCountTB = new System.Windows.Forms.TextBox();
            this.neuralNetworksInitialLearningDurationTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trainingRateTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxWeightTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hiddenLayersSizeTB = new System.Windows.Forms.TextBox();
            this.minWeightTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.verticalResTB = new System.Windows.Forms.TextBox();
            this.horizontalResTB = new System.Windows.Forms.TextBox();
            this.scalingFactorTB = new System.Windows.Forms.TextBox();
            this.customResolutionRB = new System.Windows.Forms.RadioButton();
            this.scaleByRB = new System.Windows.Forms.RadioButton();
            this.keepNativeSizeRB = new System.Windows.Forms.RadioButton();
            this.yzViewportRB = new System.Windows.Forms.RadioButton();
            this.xzViewportRB = new System.Windows.Forms.RadioButton();
            this.xyViewportRB = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okB
            // 
            this.okB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okB.Font = new System.Drawing.Font("Silkscreen Expanded", 5F);
            this.okB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.okB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okB.Location = new System.Drawing.Point(224, 303);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(107, 21);
            this.okB.TabIndex = 1;
            this.okB.Text = "OK";
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelB.Font = new System.Drawing.Font("Silkscreen Expanded", 5F);
            this.cancelB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelB.Location = new System.Drawing.Point(337, 303);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(107, 21);
            this.cancelB.TabIndex = 2;
            this.cancelB.Text = "Cancel";
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(110, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(175, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Maximum tracking point radius";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(110, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(195, 10);
            this.label18.TabIndex = 14;
            this.label18.Text = "Minimum tracking point radius";
            // 
            // minimumTrackingPointRadiusTB
            // 
            this.minimumTrackingPointRadiusTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minimumTrackingPointRadiusTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.minimumTrackingPointRadiusTB.Location = new System.Drawing.Point(6, 35);
            this.minimumTrackingPointRadiusTB.Name = "minimumTrackingPointRadiusTB";
            this.minimumTrackingPointRadiusTB.Size = new System.Drawing.Size(80, 15);
            this.minimumTrackingPointRadiusTB.TabIndex = 13;
            this.minimumTrackingPointRadiusTB.Text = "4";
            this.minimumTrackingPointRadiusTB.Leave += new System.EventHandler(this.minimumTrackingPointRadiusTB_Leave);
            // 
            // maximumTrackingPointRadiusTB
            // 
            this.maximumTrackingPointRadiusTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maximumTrackingPointRadiusTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.maximumTrackingPointRadiusTB.Location = new System.Drawing.Point(6, 19);
            this.maximumTrackingPointRadiusTB.Name = "maximumTrackingPointRadiusTB";
            this.maximumTrackingPointRadiusTB.Size = new System.Drawing.Size(80, 15);
            this.maximumTrackingPointRadiusTB.TabIndex = 11;
            this.maximumTrackingPointRadiusTB.Text = "15";
            this.maximumTrackingPointRadiusTB.Leave += new System.EventHandler(this.maximumTrackingPointRadiusTB_Leave);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(110, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 10);
            this.label9.TabIndex = 20;
            this.label9.Text = "Frame iterator (between 1 and 10)";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(110, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(222, 10);
            this.label13.TabIndex = 12;
            this.label13.Text = "Scan area offset (10-30px recommended)";
            // 
            // frameIteratorTB
            // 
            this.frameIteratorTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameIteratorTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.frameIteratorTB.Location = new System.Drawing.Point(6, 88);
            this.frameIteratorTB.Name = "frameIteratorTB";
            this.frameIteratorTB.Size = new System.Drawing.Size(80, 15);
            this.frameIteratorTB.TabIndex = 18;
            this.frameIteratorTB.Text = "1";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(110, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 7);
            this.label12.TabIndex = 14;
            this.label12.Text = "Precise acceptance threshold (~80%)";
            // 
            // preciseAcceptanceThresholdTB
            // 
            this.preciseAcceptanceThresholdTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preciseAcceptanceThresholdTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.preciseAcceptanceThresholdTB.Location = new System.Drawing.Point(6, 72);
            this.preciseAcceptanceThresholdTB.Name = "preciseAcceptanceThresholdTB";
            this.preciseAcceptanceThresholdTB.Size = new System.Drawing.Size(80, 15);
            this.preciseAcceptanceThresholdTB.TabIndex = 13;
            this.preciseAcceptanceThresholdTB.Text = "80";
            // 
            // scanAreaOffsetTB
            // 
            this.scanAreaOffsetTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scanAreaOffsetTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.scanAreaOffsetTB.Location = new System.Drawing.Point(6, 56);
            this.scanAreaOffsetTB.Name = "scanAreaOffsetTB";
            this.scanAreaOffsetTB.Size = new System.Drawing.Size(80, 15);
            this.scanAreaOffsetTB.TabIndex = 11;
            this.scanAreaOffsetTB.Text = "15";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(107, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 7);
            this.label1.TabIndex = 1;
            this.label1.Text = "ANN Learning duration (1k - 10k recommended)";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(107, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 11);
            this.label2.TabIndex = 3;
            this.label2.Text = "Training rate (0,1 or less recommended)";
            // 
            // hiddenLayersCountTB
            // 
            this.hiddenLayersCountTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenLayersCountTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.hiddenLayersCountTB.Location = new System.Drawing.Point(6, 51);
            this.hiddenLayersCountTB.Name = "hiddenLayersCountTB";
            this.hiddenLayersCountTB.Size = new System.Drawing.Size(80, 15);
            this.hiddenLayersCountTB.TabIndex = 4;
            this.hiddenLayersCountTB.Text = "2";
            // 
            // neuralNetworksInitialLearningDurationTB
            // 
            this.neuralNetworksInitialLearningDurationTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neuralNetworksInitialLearningDurationTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.neuralNetworksInitialLearningDurationTB.Location = new System.Drawing.Point(6, 19);
            this.neuralNetworksInitialLearningDurationTB.Name = "neuralNetworksInitialLearningDurationTB";
            this.neuralNetworksInitialLearningDurationTB.Size = new System.Drawing.Size(80, 15);
            this.neuralNetworksInitialLearningDurationTB.TabIndex = 0;
            this.neuralNetworksInitialLearningDurationTB.Text = "4000";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(107, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(366, 7);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hidden layers count (2 recommended)";
            // 
            // trainingRateTB
            // 
            this.trainingRateTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trainingRateTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.trainingRateTB.Location = new System.Drawing.Point(6, 35);
            this.trainingRateTB.Name = "trainingRateTB";
            this.trainingRateTB.Size = new System.Drawing.Size(80, 15);
            this.trainingRateTB.TabIndex = 2;
            this.trainingRateTB.Text = "0,09";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(107, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 10);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max weight (5 by default)";
            // 
            // maxWeightTB
            // 
            this.maxWeightTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxWeightTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.maxWeightTB.Location = new System.Drawing.Point(6, 83);
            this.maxWeightTB.Name = "maxWeightTB";
            this.maxWeightTB.Size = new System.Drawing.Size(80, 15);
            this.maxWeightTB.TabIndex = 7;
            this.maxWeightTB.Text = "5";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(107, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 7);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hidden Layers Size (recommended 80 - 120)";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(107, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min weight (-5 by default)";
            // 
            // hiddenLayersSizeTB
            // 
            this.hiddenLayersSizeTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenLayersSizeTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.hiddenLayersSizeTB.Location = new System.Drawing.Point(6, 67);
            this.hiddenLayersSizeTB.Name = "hiddenLayersSizeTB";
            this.hiddenLayersSizeTB.Size = new System.Drawing.Size(80, 15);
            this.hiddenLayersSizeTB.TabIndex = 6;
            this.hiddenLayersSizeTB.Text = "80";
            // 
            // minWeightTB
            // 
            this.minWeightTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minWeightTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.minWeightTB.Location = new System.Drawing.Point(6, 99);
            this.minWeightTB.Name = "minWeightTB";
            this.minWeightTB.Size = new System.Drawing.Size(80, 15);
            this.minWeightTB.TabIndex = 8;
            this.minWeightTB.Text = "-5";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(9, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 6);
            this.label8.TabIndex = 7;
            this.label8.Text = "Vertical res (px)";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(9, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 7);
            this.label7.TabIndex = 6;
            this.label7.Text = "Horizontal res (px)";
            // 
            // verticalResTB
            // 
            this.verticalResTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.verticalResTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.verticalResTB.Location = new System.Drawing.Point(9, 163);
            this.verticalResTB.Name = "verticalResTB";
            this.verticalResTB.Size = new System.Drawing.Size(173, 15);
            this.verticalResTB.TabIndex = 5;
            this.verticalResTB.Text = "240";
            this.verticalResTB.Enter += new System.EventHandler(this.verticalResTB_Enter);
            // 
            // horizontalResTB
            // 
            this.horizontalResTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.horizontalResTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.horizontalResTB.Location = new System.Drawing.Point(9, 136);
            this.horizontalResTB.Name = "horizontalResTB";
            this.horizontalResTB.Size = new System.Drawing.Size(173, 15);
            this.horizontalResTB.TabIndex = 4;
            this.horizontalResTB.Text = "320";
            this.horizontalResTB.Enter += new System.EventHandler(this.horizontalResTB_Enter);
            // 
            // scalingFactorTB
            // 
            this.scalingFactorTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scalingFactorTB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.scalingFactorTB.Location = new System.Drawing.Point(9, 80);
            this.scalingFactorTB.Name = "scalingFactorTB";
            this.scalingFactorTB.Size = new System.Drawing.Size(173, 15);
            this.scalingFactorTB.TabIndex = 3;
            this.scalingFactorTB.Text = "100%";
            this.scalingFactorTB.Enter += new System.EventHandler(this.scalingFactorTB_Enter);
            // 
            // customResolutionRB
            // 
            this.customResolutionRB.BackColor = System.Drawing.Color.Transparent;
            this.customResolutionRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customResolutionRB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.customResolutionRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customResolutionRB.Location = new System.Drawing.Point(9, 108);
            this.customResolutionRB.Name = "customResolutionRB";
            this.customResolutionRB.Size = new System.Drawing.Size(173, 21);
            this.customResolutionRB.TabIndex = 2;
            this.customResolutionRB.Text = "Custom resolution";
            this.customResolutionRB.UseVisualStyleBackColor = false;
            this.customResolutionRB.CheckedChanged += new System.EventHandler(this.customResolutionRB_CheckedChanged);
            // 
            // scaleByRB
            // 
            this.scaleByRB.BackColor = System.Drawing.Color.Transparent;
            this.scaleByRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scaleByRB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.scaleByRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.scaleByRB.Location = new System.Drawing.Point(9, 59);
            this.scaleByRB.Name = "scaleByRB";
            this.scaleByRB.Size = new System.Drawing.Size(173, 21);
            this.scaleByRB.TabIndex = 1;
            this.scaleByRB.Text = "Scale by";
            this.scaleByRB.UseVisualStyleBackColor = false;
            this.scaleByRB.CheckedChanged += new System.EventHandler(this.scaleByRB_CheckedChanged);
            // 
            // keepNativeSizeRB
            // 
            this.keepNativeSizeRB.BackColor = System.Drawing.Color.Transparent;
            this.keepNativeSizeRB.Checked = true;
            this.keepNativeSizeRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keepNativeSizeRB.Font = new System.Drawing.Font("Silkscreen", 6F);
            this.keepNativeSizeRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keepNativeSizeRB.Location = new System.Drawing.Point(9, 25);
            this.keepNativeSizeRB.Name = "keepNativeSizeRB";
            this.keepNativeSizeRB.Size = new System.Drawing.Size(173, 21);
            this.keepNativeSizeRB.TabIndex = 0;
            this.keepNativeSizeRB.TabStop = true;
            this.keepNativeSizeRB.Text = "Keep native size";
            this.keepNativeSizeRB.UseVisualStyleBackColor = false;
            this.keepNativeSizeRB.CheckedChanged += new System.EventHandler(this.keepNativeSizeRB_CheckedChanged);
            // 
            // yzViewportRB
            // 
            this.yzViewportRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.yzViewportRB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yzViewportRB.BackgroundImage")));
            this.yzViewportRB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.yzViewportRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yzViewportRB.Location = new System.Drawing.Point(6, 100);
            this.yzViewportRB.Name = "yzViewportRB";
            this.yzViewportRB.Size = new System.Drawing.Size(90, 75);
            this.yzViewportRB.TabIndex = 2;
            this.yzViewportRB.Text = "YZ Viewport";
            this.yzViewportRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.yzViewportRB.CheckedChanged += new System.EventHandler(this.yzViewportRB_CheckedChanged);
            // 
            // xzViewportRB
            // 
            this.xzViewportRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.xzViewportRB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xzViewportRB.BackgroundImage")));
            this.xzViewportRB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.xzViewportRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xzViewportRB.Location = new System.Drawing.Point(102, 19);
            this.xzViewportRB.Name = "xzViewportRB";
            this.xzViewportRB.Size = new System.Drawing.Size(90, 75);
            this.xzViewportRB.TabIndex = 1;
            this.xzViewportRB.Text = "XZ Viewport";
            this.xzViewportRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xzViewportRB.CheckedChanged += new System.EventHandler(this.xzViewportRB_CheckedChanged);
            // 
            // xyViewportRB
            // 
            this.xyViewportRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.xyViewportRB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xyViewportRB.BackgroundImage")));
            this.xyViewportRB.Checked = true;
            this.xyViewportRB.Font = new System.Drawing.Font("Silkscreen Expanded", 6F);
            this.xyViewportRB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xyViewportRB.Location = new System.Drawing.Point(6, 19);
            this.xyViewportRB.Name = "xyViewportRB";
            this.xyViewportRB.Size = new System.Drawing.Size(90, 75);
            this.xyViewportRB.TabIndex = 0;
            this.xyViewportRB.TabStop = true;
            this.xyViewportRB.Text = "XY Viewport";
            this.xyViewportRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xyViewportRB.CheckedChanged += new System.EventHandler(this.xyViewportRB_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 291);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(428, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Viewports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.Controls.Add(this.keepNativeSizeRB);
            this.groupBox4.Controls.Add(this.verticalResTB);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.scalingFactorTB);
            this.groupBox4.Controls.Add(this.scaleByRB);
            this.groupBox4.Controls.Add(this.customResolutionRB);
            this.groupBox4.Controls.Add(this.horizontalResTB);
            this.groupBox4.Location = new System.Drawing.Point(216, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 186);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.Controls.Add(this.xyViewportRB);
            this.groupBox3.Controls.Add(this.yzViewportRB);
            this.groupBox3.Controls.Add(this.xzViewportRB);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 187);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Viewport";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.maximumTrackingPointRadiusTB);
            this.groupBox2.Controls.Add(this.minimumTrackingPointRadiusTB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.frameIteratorTB);
            this.groupBox2.Controls.Add(this.scanAreaOffsetTB);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.preciseAcceptanceThresholdTB);
            this.groupBox2.Location = new System.Drawing.Point(6, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 110);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.neuralNetworksInitialLearningDurationTB);
            this.groupBox1.Controls.Add(this.hiddenLayersSizeTB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.minWeightTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maxWeightTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trainingRateTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hiddenLayersCountTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 123);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neural networks";
            // 
            // preferencesForm
            // 
            this.AcceptButton = this.okB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.cancelB;
            this.ClientSize = new System.Drawing.Size(449, 328);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.okB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "preferencesForm";
            this.Opacity = 0.9;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


        //Event handling
		private void InitializeValues(BaseTypes.Settings settings)  //OK
		{
            localSettingsInstance = settings;
			this.neuralNetworksInitialLearningDurationTB.Text=Convert.ToString(settings.neuralNetworkTrainingIterations);
			this.trainingRateTB.Text=Convert.ToString(settings.neuralNetworkTrainingRate);
			this.maxWeightTB.Text=Convert.ToString(settings.neuralNetworkMaximumWeight);
			this.minWeightTB.Text=Convert.ToString(settings.neuralNetworkMinimumWeight);
			this.hiddenLayersCountTB.Text=Convert.ToString(settings.neuralNetworkHiddenLayersCount);
			this.hiddenLayersSizeTB.Text=Convert.ToString(settings.neuralNetworkHiddenLayersSize);
			this.scalingFactorTB.Text=Convert.ToString(settings.viewportXYScalingFactor);
			this.horizontalResTB.Text=Convert.ToString(settings.viewportXYHorizontalRes);
			this.verticalResTB.Text=Convert.ToString(settings.viewportXYVerticalRes);
			this.scanAreaOffsetTB.Text=Convert.ToString(settings.scanAreaOffset);
			this.preciseAcceptanceThresholdTB.Text=Convert.ToString(settings.preciseAcceptanceThreshold);
			this.frameIteratorTB.Text=Convert.ToString(settings.frameIterator);
			this.minimumTrackingPointRadiusTB.Text=Convert.ToString(settings.minimumOrientPointRadius);
			this.maximumTrackingPointRadiusTB.Text=Convert.ToString(settings.maximumOrientPointRadius);
			
			if (settings.viewportXYScalingType==BaseTypes.scalingType.Native)
				this.keepNativeSizeRB.Checked=true; else if
		       (settings.viewportXYScalingType==BaseTypes.scalingType.ScaleBy)
				this.scaleByRB.Checked=true; else this.customResolutionRB.Checked=true;	
		}

		private void updateViewport()
		{
			if (xyViewportRB.Checked)
			{
				this.scalingFactorTB.Text=Convert.ToString(localSettingsInstance.viewportXYScalingFactor);
				this.horizontalResTB.Text=Convert.ToString(localSettingsInstance.viewportXYHorizontalRes);
				this.verticalResTB.Text=Convert.ToString(localSettingsInstance.viewportXYVerticalRes);
				if (localSettingsInstance.viewportXYScalingType==BaseTypes.scalingType.Native) this.keepNativeSizeRB.Checked=true;
				if (localSettingsInstance.viewportXYScalingType==BaseTypes.scalingType.ScaleBy) this.scaleByRB.Checked=true;
				if (localSettingsInstance.viewportXYScalingType==BaseTypes.scalingType.Custom) this.customResolutionRB.Checked=true;

                last_viewport = BaseTypes.viewport.XY;
            }
			else if (xzViewportRB.Checked)
			{
				this.scalingFactorTB.Text=Convert.ToString(localSettingsInstance.viewportXZScalingFactor);
				this.horizontalResTB.Text=Convert.ToString(localSettingsInstance.viewportXZHorizontalRes);
				this.verticalResTB.Text=Convert.ToString(localSettingsInstance.viewportXZVerticalRes);
				if (localSettingsInstance.viewportXZScalingType==BaseTypes.scalingType.Native) this.keepNativeSizeRB.Checked=true;
				if (localSettingsInstance.viewportXZScalingType==BaseTypes.scalingType.ScaleBy) this.scaleByRB.Checked=true;
				if (localSettingsInstance.viewportXZScalingType==BaseTypes.scalingType.Custom) this.customResolutionRB.Checked=true;
                last_viewport = BaseTypes.viewport.XZ;
			}
			else 
			{
				this.scalingFactorTB.Text=Convert.ToString(localSettingsInstance.viewportYZScalingFactor);
				this.horizontalResTB.Text=Convert.ToString(localSettingsInstance.viewportYZHorizontalRes);
				this.verticalResTB.Text=Convert.ToString(localSettingsInstance.viewportYZVerticalRes);
				if (localSettingsInstance.viewportYZScalingType==BaseTypes.scalingType.Native) this.keepNativeSizeRB.Checked=true;
				if (localSettingsInstance.viewportYZScalingType==BaseTypes.scalingType.ScaleBy) this.scaleByRB.Checked=true;
				if (localSettingsInstance.viewportYZScalingType==BaseTypes.scalingType.Custom) this.customResolutionRB.Checked=true;
                last_viewport = BaseTypes.viewport.YZ;
			}
		}


		
	

        //GUI Invoked events (Clicks)
		private void cancelB_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
			this.Close();
		}
        private void okB_Click(object sender, System.EventArgs e)
		{
            validateViewportData(); 
            uint uinteger;
            int integer;
            TextBox Sender = (TextBox)scanAreaOffsetTB;
            double floatingPoint;
            try
            {
                
                Sender = (TextBox)scanAreaOffsetTB;
                uinteger = uint.Parse(scanAreaOffsetTB.Text);
                Sender = (TextBox)preciseAcceptanceThresholdTB;
                uinteger = uint.Parse(preciseAcceptanceThresholdTB.Text);
                Sender = (TextBox)maximumTrackingPointRadiusTB;
                uinteger = uint.Parse(maximumTrackingPointRadiusTB.Text);
                Sender = (TextBox)minimumTrackingPointRadiusTB;
                uinteger = uint.Parse(minimumTrackingPointRadiusTB.Text);
                Sender = (TextBox)frameIteratorTB;
                uinteger = uint.Parse(frameIteratorTB.Text);
                Sender = (TextBox)maxWeightTB;
                integer = int.Parse(maxWeightTB.Text);
                Sender = (TextBox)minWeightTB;
                integer = int.Parse(minWeightTB.Text);
                Sender = (TextBox)neuralNetworksInitialLearningDurationTB;
                uinteger = uint.Parse(neuralNetworksInitialLearningDurationTB.Text);
                Sender = (TextBox)trainingRateTB;
                floatingPoint = double.Parse(trainingRateTB.Text);
                Sender = (TextBox)hiddenLayersCountTB;
                uinteger = uint.Parse(hiddenLayersCountTB.Text);
                Sender = (TextBox)hiddenLayersSizeTB;
                uinteger = uint.Parse(hiddenLayersSizeTB.Text);
                Sender = (TextBox)scalingFactorTB;
                uinteger = uint.Parse(scalingFactorTB.Text);
                Sender = (TextBox)horizontalResTB;
                uinteger = uint.Parse(horizontalResTB.Text);
                Sender = (TextBox)verticalResTB;
                uinteger = uint.Parse(verticalResTB.Text);

                


            }
            catch (ArgumentNullException ane)
            {
                this.errorProvider1.SetError(Sender, ane.Message);
                this.label1.Text = "Invalid data entered";
                return;
            }
            catch (FormatException fe)
            {
                this.errorProvider1.SetError(Sender, fe.Message);
                this.label1.Text = "Invalid data entered";
                return;
            }
            catch (OverflowException oe)
            {
                this.errorProvider1.SetError(Sender, oe.Message);
                this.label1.Text = "Invalid data entered";
                return;
            }


           this.errorProvider1.SetError(scanAreaOffsetTB, "");
           this.errorProvider1.SetError(preciseAcceptanceThresholdTB, "");
           this.errorProvider1.SetError(maximumTrackingPointRadiusTB, "");
           this.errorProvider1.SetError(minimumTrackingPointRadiusTB, "");
           this.errorProvider1.SetError(frameIteratorTB, "");
           this.errorProvider1.SetError(maxWeightTB, "");
           this.errorProvider1.SetError(minWeightTB, "");
           this.errorProvider1.SetError(neuralNetworksInitialLearningDurationTB, "");
           this.errorProvider1.SetError(trainingRateTB, "");
           this.errorProvider1.SetError(hiddenLayersCountTB, "");
           this.errorProvider1.SetError(hiddenLayersSizeTB, "");
           this.errorProvider1.SetError (scalingFactorTB, "");
           this.errorProvider1.SetError (horizontalResTB, "");
           this.errorProvider1.SetError(verticalResTB, "");






           localSettingsInstance.neuralNetworkTrainingIterations=Convert.ToInt32(this.neuralNetworksInitialLearningDurationTB.Text);
           localSettingsInstance.neuralNetworkTrainingRate = Convert.ToDouble(this.trainingRateTB.Text);
           localSettingsInstance.neuralNetworkMaximumWeight=Convert.ToInt32(this.maxWeightTB.Text);
           localSettingsInstance.neuralNetworkMinimumWeight=Convert.ToInt32(this.minWeightTB.Text);
           localSettingsInstance.neuralNetworkHiddenLayersCount=Convert.ToInt32(this.hiddenLayersCountTB.Text);
           localSettingsInstance.neuralNetworkHiddenLayersSize=Convert.ToInt32(this.hiddenLayersSizeTB.Text);
           localSettingsInstance.scanAreaOffset=Convert.ToInt32(this.scanAreaOffsetTB.Text);
           localSettingsInstance.preciseAcceptanceThreshold=Convert.ToInt32(this.preciseAcceptanceThresholdTB.Text);
           localSettingsInstance.frameIterator=Convert.ToInt32(this.frameIteratorTB.Text);
           localSettingsInstance.minimumOrientPointRadius=Convert.ToInt32(this.minimumTrackingPointRadiusTB.Text);
           localSettingsInstance.maximumOrientPointRadius=Convert.ToInt32(this.maximumTrackingPointRadiusTB.Text);

   
            
            
            
            
            this.DialogResult=DialogResult.OK;
			this.Close();
		}

        private void validateViewportData()
        {

            
            try
            {
                uint uinteger;
                TextBox Sender = (TextBox)scanAreaOffsetTB;
                try
                {

                    Sender = (TextBox)scalingFactorTB;
                    uinteger = uint.Parse(scalingFactorTB.Text);
                    Sender = (TextBox)horizontalResTB;
                    uinteger = uint.Parse(horizontalResTB.Text);
                    Sender = (TextBox)verticalResTB;
                    uinteger = uint.Parse(verticalResTB.Text);

                }
                catch (ArgumentNullException ane)
                {
                    this.errorProvider1.SetError(Sender, ane.Message);
                    this.label1.Text = "Invalid data entered";
                    return;
                }
                catch (FormatException fe)
                {
                    this.errorProvider1.SetError(Sender, fe.Message);
                    this.label1.Text = "Invalid data entered";
                    return;
                }
                catch (OverflowException oe)
                {
                    this.errorProvider1.SetError(Sender, oe.Message);
                    this.label1.Text = "Invalid data entered";
                    return;
                }

                //likwidujê znacznik b³êdu
                this.errorProvider1.SetError(scalingFactorTB, "");
                this.errorProvider1.SetError(horizontalResTB, "");
                this.errorProvider1.SetError(verticalResTB, "");

                if (last_viewport == BaseTypes.viewport.XY)
                {
                    localSettingsInstance.viewportXYScalingFactor = Convert.ToInt32(this.scalingFactorTB.Text);
                    localSettingsInstance.viewportXYVerticalRes = Convert.ToUInt32(this.verticalResTB.Text);
                    localSettingsInstance.viewportXYHorizontalRes = Convert.ToUInt32(this.horizontalResTB.Text);
                    if (scaleByRB.Checked) localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.ScaleBy;
                    else if (customResolutionRB.Checked) localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.Custom;
                    else localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.Native;

                }
                else if (last_viewport == BaseTypes.viewport.XZ)
                {
                    localSettingsInstance.viewportXZScalingFactor = Convert.ToInt32(this.scalingFactorTB.Text);
                    localSettingsInstance.viewportXZVerticalRes = Convert.ToUInt32(this.verticalResTB.Text);
                    localSettingsInstance.viewportXZHorizontalRes = Convert.ToUInt32(this.horizontalResTB.Text);
                    if (scaleByRB.Checked) localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.ScaleBy;
                    else if (customResolutionRB.Checked) localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.Custom;
                    else localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.Native;
                }
                else
                {
                    localSettingsInstance.viewportYZScalingFactor = Convert.ToInt32(this.scalingFactorTB.Text);
                    localSettingsInstance.viewportYZVerticalRes = Convert.ToUInt32(this.verticalResTB.Text);
                    localSettingsInstance.viewportYZHorizontalRes = Convert.ToUInt32(this.horizontalResTB.Text);
                    if (scaleByRB.Checked) localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.ScaleBy;
                    else if (customResolutionRB.Checked) localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.Custom;
                    else localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.Native;
                }

                updateViewport();
            }

            finally
            {
                if (last_viewport == BaseTypes.viewport.XY) xyViewportRB.Checked = true;
                else if (last_viewport == BaseTypes.viewport.XZ) xzViewportRB.Checked = true;
                else yzViewportRB.Checked = true;

            }
        
        }


        private void yzViewportRB_CheckedChanged(object sender, EventArgs e)
        {
            if (last_viewport != BaseTypes.viewport.YZ)
            validateViewportData(); 
        }



        private void xyViewportRB_CheckedChanged(object sender, EventArgs e)
        {
            if (last_viewport != BaseTypes.viewport.XY)
                validateViewportData();
        }

        private void xzViewportRB_CheckedChanged(object sender, EventArgs e)
        {
            if (last_viewport != BaseTypes.viewport.XZ)
                validateViewportData();
        }



		private void keepNativeSizeRB_CheckedChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (xyViewportRB.Checked)
                    localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.Native;
                else if (xzViewportRB.Checked)
                    localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.Native;
                else
                    localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.Native;
            }
            catch { MessageBox.Show("Error in Preferences Form! Entering invalid data suspected!", "ERROR OCCURED", MessageBoxButtons.OK, MessageBoxIcon.Error); }

		}
		private void scaleByRB_CheckedChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (xyViewportRB.Checked)
                    localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.ScaleBy;
                else if (xzViewportRB.Checked)
                    localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.ScaleBy;
                else
                    localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.ScaleBy;
            }
            catch { MessageBox.Show("Error in Preferences Form! Entering invalid data suspected!", "ERROR OCCURED", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void customResolutionRB_CheckedChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (xyViewportRB.Checked)
                    localSettingsInstance.viewportXYScalingType = BaseTypes.scalingType.Custom;
                else if (xzViewportRB.Checked)
                    localSettingsInstance.viewportXZScalingType = BaseTypes.scalingType.Custom;
                else
                    localSettingsInstance.viewportYZScalingType = BaseTypes.scalingType.Custom;
            }
            catch { MessageBox.Show("Error in Preferences Form! Entering invalid data suspected!", "ERROR OCCURED", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
        
     
        
        private void scalingFactorTB_Enter(object sender, System.EventArgs e)
		{
			this.scaleByRB.Checked=true;
		}
		private void horizontalResTB_Enter(object sender, System.EventArgs e)
		{
			this.customResolutionRB.Checked=true;
		}
		private void verticalResTB_Enter(object sender, System.EventArgs e)
		{
			this.customResolutionRB.Checked=true;
		}


		private void maximumTrackingPointRadiusTB_Leave(object sender, System.EventArgs e)
		{
			bool exception=false;
			try 
			{
				this.localSettingsInstance.maximumOrientPointRadius=Convert.ToInt32(this.maximumTrackingPointRadiusTB.Text);
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
			
			if (exception)
			{
				maximumTrackingPointRadiusTB.Focus();
			}

			if (Convert.ToInt32(this.minimumTrackingPointRadiusTB.Text)>Convert.ToInt32(this.maximumTrackingPointRadiusTB.Text))
			{
				MessageBox.Show("Maximum radius and minimum radius cannot be mixed!");
				maximumTrackingPointRadiusTB.Focus();
			}
		}
		private void minimumTrackingPointRadiusTB_Leave(object sender, System.EventArgs e)
		{
			bool exception=false;
			try 
			{
				this.localSettingsInstance.minimumOrientPointRadius=Convert.ToInt32(this.minimumTrackingPointRadiusTB.Text);
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
			
			if (exception)
			{
				
			}

			if (Convert.ToInt32(this.minimumTrackingPointRadiusTB.Text)>Convert.ToInt32(this.maximumTrackingPointRadiusTB.Text))
			{
              MessageBox.Show("Maximum radius and minimum radius cannot be mixed!");
              minimumTrackingPointRadiusTB.Focus();
			}


		}







      


	

	

	
	}
}
