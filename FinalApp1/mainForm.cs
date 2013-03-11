using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ctlViewportlib;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace FinalApp1
{
	/// <summary>
	/// Main application form
	/// </summary>
	
	
	
	public class mainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Button quitB;
		private System.Windows.Forms.Button newProjectB;
		private System.Windows.Forms.GroupBox mainFrame;
		private System.Windows.Forms.Button preferencesB;
		private System.Windows.Forms.Button addTrackingPointB;
		private System.Windows.Forms.ListBox messagesLB;
		private System.Windows.Forms.Panel masterControlPanelP;
		private System.Windows.Forms.Button playB;
		private System.Windows.Forms.Button pauseB;
		private System.Windows.Forms.Button stopB;
		private System.Windows.Forms.Button frameFfdB;
		private System.Windows.Forms.Button frameBckB;
		private System.Windows.Forms.Button revB;
		private System.Windows.Forms.Button ffdB;
		private System.Windows.Forms.Button modeChangeB;
		private System.Windows.Forms.TextBox masterControlPanelDisplayTB;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Button saveProjectB;
		private System.Windows.Forms.Button closeProjectB;
		private System.Windows.Forms.Button loadProjectB;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.TextBox frameCounter;
		private System.Windows.Forms.ListBox trackingPointsLB;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.OpenFileDialog loadProjectD;
		private System.Windows.Forms.SaveFileDialog saveProjectD;
		private System.Windows.Forms.Button modifyPointParamsB;
		private System.Windows.Forms.Button deletePointB;
		private System.Windows.Forms.Button initializeTrackingB;
		private System.Windows.Forms.Button trackFullMovieB;
		private System.Windows.Forms.SaveFileDialog exportResultsSaveFileD;
		private System.Windows.Forms.Button calibrateDistanceXYB;
		private System.Windows.Forms.Button calibrateDistanceXZB;
        private System.Windows.Forms.Button calibrateDistanceYZB;
        private IContainer components;

		//____________________________DESIGNER VARIABLES________________________________________

		private ctlViewport viewportXY;//Top left
		private ctlViewport viewportXZ; //Top right
		private ctlViewport viewportYZ;//Bottom left
		
		private BaseTypes.Settings projectSettings; //structure containing project settings
		
		private string currentMode; //indicates if viewports are in capture or playback mode
		private bool addingPoint; //indicates if user is adding new point @ moment
		private bool RMBDown;  //indicates if right mouse button is pressed (while resizing)
		 
		
		private trackingPointProperties tForm; //form used during adding point
		private trackingPoint tempTrackingPoint; //temporary tracking point used during adding point
		
		private BaseTypes.timeFrame tf; //point coord + time of occurence

		private ArrayList trackingPointsBasicInfo;
		private ArrayList trackingPoints; //fully defined tracking points
		private int totalTrackingPoints; //number of tracking points defined
		private BaseTypes.trackingHistory trackingHist;
        DateTime TimeStart, TimeFinish;

		bool trackingPaused = false;
		private System.Windows.Forms.Button pauseTrackingB;
		private System.Windows.Forms.Button trackedPointsBrowserB;
		//	private trackingPoint temporaryTrackingPoint;
		private string oldPointName;

		int framesToTrack=0;

		private bool projectSaved=true;
		private bool trackingCompleted=false;
		private System.Windows.Forms.Button exportResultsB;
		private System.Windows.Forms.Button trackCertainMovieLenB;
		private System.Windows.Forms.Label version;
		private System.Windows.Forms.GroupBox postProcessingGB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Panel toolBoxP;
		private System.Windows.Forms.GroupBox definedPointsGB;
        private Timer timer1;
		

		//list of tracking points (in future, - in current frame)
	
		private System.Drawing.Point RMBClickCoords; //contains information, where in vprt, RMB was pressed

		//______________________________________________________________________________________	






		public mainForm()
		{
			InitializeComponent();
			Message("Application started :)");
			app_status.SetStatus(_app_status.started);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.toolBoxP = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addTrackingPointB = new System.Windows.Forms.Button();
            this.deletePointB = new System.Windows.Forms.Button();
            this.modifyPointParamsB = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.postProcessingGB = new System.Windows.Forms.GroupBox();
            this.saveProjectB = new System.Windows.Forms.Button();
            this.newProjectB = new System.Windows.Forms.Button();
            this.loadProjectB = new System.Windows.Forms.Button();
            this.closeProjectB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pauseTrackingB = new System.Windows.Forms.Button();
            this.trackCertainMovieLenB = new System.Windows.Forms.Button();
            this.trackedPointsBrowserB = new System.Windows.Forms.Button();
            this.trackFullMovieB = new System.Windows.Forms.Button();
            this.initializeTrackingB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.preferencesB = new System.Windows.Forms.Button();
            this.exportResultsB = new System.Windows.Forms.Button();
            this.quitB = new System.Windows.Forms.Button();
            this.definedPointsGB = new System.Windows.Forms.GroupBox();
            this.trackingPointsLB = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.calibrateDistanceXYB = new System.Windows.Forms.Button();
            this.calibrateDistanceYZB = new System.Windows.Forms.Button();
            this.calibrateDistanceXZB = new System.Windows.Forms.Button();
            this.mainFrame = new System.Windows.Forms.GroupBox();
            this.masterControlPanelP = new System.Windows.Forms.Panel();
            this.masterControlPanelDisplayTB = new System.Windows.Forms.TextBox();
            this.frameCounter = new System.Windows.Forms.TextBox();
            this.modeChangeB = new System.Windows.Forms.Button();
            this.ffdB = new System.Windows.Forms.Button();
            this.revB = new System.Windows.Forms.Button();
            this.frameBckB = new System.Windows.Forms.Button();
            this.frameFfdB = new System.Windows.Forms.Button();
            this.stopB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.playB = new System.Windows.Forms.Button();
            this.messagesLB = new System.Windows.Forms.ListBox();
            this.loadProjectD = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectD = new System.Windows.Forms.SaveFileDialog();
            this.exportResultsSaveFileD = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolBoxP.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.postProcessingGB.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.definedPointsGB.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.mainFrame.SuspendLayout();
            this.masterControlPanelP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem12,
            this.menuItem6,
            this.menuItem16,
            this.menuItem14});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem8,
            this.menuItem5});
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // menuItem2
            // 
            this.menuItem2.DefaultItem = true;
            this.menuItem2.Index = 0;
            resources.ApplyResources(this.menuItem2, "menuItem2");
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            resources.ApplyResources(this.menuItem3, "menuItem3");
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            resources.ApplyResources(this.menuItem4, "menuItem4");
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            resources.ApplyResources(this.menuItem8, "menuItem8");
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            resources.ApplyResources(this.menuItem5, "menuItem5");
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13});
            resources.ApplyResources(this.menuItem12, "menuItem12");
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 0;
            resources.ApplyResources(this.menuItem13, "menuItem13");
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click_1);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem18});
            resources.ApplyResources(this.menuItem6, "menuItem6");
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem10,
            this.menuItem11});
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            resources.ApplyResources(this.menuItem9, "menuItem9");
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            resources.ApplyResources(this.menuItem10, "menuItem10");
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 1;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem19,
            this.menuItem20,
            this.menuItem21,
            this.menuItem22,
            this.menuItem23,
            this.menuItem25,
            this.menuItem26,
            this.menuItem24});
            resources.ApplyResources(this.menuItem18, "menuItem18");
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 0;
            resources.ApplyResources(this.menuItem19, "menuItem19");
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            resources.ApplyResources(this.menuItem20, "menuItem20");
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 2;
            resources.ApplyResources(this.menuItem21, "menuItem21");
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 3;
            resources.ApplyResources(this.menuItem22, "menuItem22");
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 4;
            resources.ApplyResources(this.menuItem23, "menuItem23");
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 5;
            resources.ApplyResources(this.menuItem25, "menuItem25");
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 6;
            resources.ApplyResources(this.menuItem26, "menuItem26");
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 7;
            resources.ApplyResources(this.menuItem24, "menuItem24");
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 3;
            this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem17});
            resources.ApplyResources(this.menuItem16, "menuItem16");
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 0;
            resources.ApplyResources(this.menuItem17, "menuItem17");
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 4;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15});
            resources.ApplyResources(this.menuItem14, "menuItem14");
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            resources.ApplyResources(this.menuItem15, "menuItem15");
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // toolBoxP
            // 
            this.toolBoxP.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.toolBoxP, "toolBoxP");
            this.toolBoxP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBoxP.Controls.Add(this.groupBox2);
            this.toolBoxP.Controls.Add(this.version);
            this.toolBoxP.Controls.Add(this.postProcessingGB);
            this.toolBoxP.Controls.Add(this.groupBox3);
            this.toolBoxP.Controls.Add(this.groupBox1);
            this.toolBoxP.Controls.Add(this.definedPointsGB);
            this.toolBoxP.Controls.Add(this.groupBox5);
            this.toolBoxP.ForeColor = System.Drawing.Color.Gray;
            this.toolBoxP.Name = "toolBoxP";
            this.toolBoxP.Resize += new System.EventHandler(this.toolBoxP_Resize);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.addTrackingPointB);
            this.groupBox2.Controls.Add(this.deletePointB);
            this.groupBox2.Controls.Add(this.modifyPointParamsB);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // addTrackingPointB
            // 
            this.addTrackingPointB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.addTrackingPointB, "addTrackingPointB");
            this.addTrackingPointB.ForeColor = System.Drawing.Color.Black;
            this.addTrackingPointB.Name = "addTrackingPointB";
            this.addTrackingPointB.UseVisualStyleBackColor = false;
            this.addTrackingPointB.Click += new System.EventHandler(this.addTrackingPointB_Click);
            // 
            // deletePointB
            // 
            this.deletePointB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.deletePointB, "deletePointB");
            this.deletePointB.ForeColor = System.Drawing.Color.Black;
            this.deletePointB.Name = "deletePointB";
            this.deletePointB.UseVisualStyleBackColor = false;
            this.deletePointB.Click += new System.EventHandler(this.deletePointB_Click);
            // 
            // modifyPointParamsB
            // 
            this.modifyPointParamsB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.modifyPointParamsB, "modifyPointParamsB");
            this.modifyPointParamsB.ForeColor = System.Drawing.Color.Black;
            this.modifyPointParamsB.Name = "modifyPointParamsB";
            this.modifyPointParamsB.UseVisualStyleBackColor = false;
            this.modifyPointParamsB.Click += new System.EventHandler(this.modifyPointParamsB_Click);
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.version, "version");
            this.version.ForeColor = System.Drawing.Color.Red;
            this.version.Name = "version";
            // 
            // postProcessingGB
            // 
            this.postProcessingGB.BackColor = System.Drawing.Color.Transparent;
            this.postProcessingGB.Controls.Add(this.saveProjectB);
            this.postProcessingGB.Controls.Add(this.newProjectB);
            this.postProcessingGB.Controls.Add(this.loadProjectB);
            this.postProcessingGB.Controls.Add(this.closeProjectB);
            resources.ApplyResources(this.postProcessingGB, "postProcessingGB");
            this.postProcessingGB.ForeColor = System.Drawing.Color.Black;
            this.postProcessingGB.Name = "postProcessingGB";
            this.postProcessingGB.TabStop = false;
            // 
            // saveProjectB
            // 
            this.saveProjectB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.saveProjectB, "saveProjectB");
            this.saveProjectB.ForeColor = System.Drawing.Color.Black;
            this.saveProjectB.Name = "saveProjectB";
            this.saveProjectB.UseVisualStyleBackColor = false;
            this.saveProjectB.Click += new System.EventHandler(this.saveProjectB_Click);
            // 
            // newProjectB
            // 
            this.newProjectB.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.newProjectB, "newProjectB");
            this.newProjectB.ForeColor = System.Drawing.Color.Black;
            this.newProjectB.Name = "newProjectB";
            this.newProjectB.UseVisualStyleBackColor = false;
            this.newProjectB.Click += new System.EventHandler(this.newProjectB_Click);
            // 
            // loadProjectB
            // 
            this.loadProjectB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.loadProjectB, "loadProjectB");
            this.loadProjectB.ForeColor = System.Drawing.Color.Black;
            this.loadProjectB.Name = "loadProjectB";
            this.loadProjectB.UseVisualStyleBackColor = false;
            this.loadProjectB.Click += new System.EventHandler(this.loadProjectB_Click);
            // 
            // closeProjectB
            // 
            this.closeProjectB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.closeProjectB, "closeProjectB");
            this.closeProjectB.ForeColor = System.Drawing.Color.Black;
            this.closeProjectB.Name = "closeProjectB";
            this.closeProjectB.UseVisualStyleBackColor = false;
            this.closeProjectB.Click += new System.EventHandler(this.closeProjectB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.pauseTrackingB);
            this.groupBox3.Controls.Add(this.trackCertainMovieLenB);
            this.groupBox3.Controls.Add(this.trackedPointsBrowserB);
            this.groupBox3.Controls.Add(this.trackFullMovieB);
            this.groupBox3.Controls.Add(this.initializeTrackingB);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // pauseTrackingB
            // 
            this.pauseTrackingB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.pauseTrackingB, "pauseTrackingB");
            this.pauseTrackingB.ForeColor = System.Drawing.Color.Black;
            this.pauseTrackingB.Name = "pauseTrackingB";
            this.pauseTrackingB.UseVisualStyleBackColor = false;
            this.pauseTrackingB.Click += new System.EventHandler(this.pauseTrackingB_Click);
            // 
            // trackCertainMovieLenB
            // 
            this.trackCertainMovieLenB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.trackCertainMovieLenB, "trackCertainMovieLenB");
            this.trackCertainMovieLenB.ForeColor = System.Drawing.Color.Black;
            this.trackCertainMovieLenB.Name = "trackCertainMovieLenB";
            this.trackCertainMovieLenB.UseVisualStyleBackColor = false;
            this.trackCertainMovieLenB.Click += new System.EventHandler(this.trackCertainMovieLenB_Click);
            // 
            // trackedPointsBrowserB
            // 
            this.trackedPointsBrowserB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.trackedPointsBrowserB, "trackedPointsBrowserB");
            this.trackedPointsBrowserB.ForeColor = System.Drawing.Color.Black;
            this.trackedPointsBrowserB.Name = "trackedPointsBrowserB";
            this.trackedPointsBrowserB.UseVisualStyleBackColor = false;
            this.trackedPointsBrowserB.Click += new System.EventHandler(this.trackedPointsBrowserB_Click);
            // 
            // trackFullMovieB
            // 
            this.trackFullMovieB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.trackFullMovieB, "trackFullMovieB");
            this.trackFullMovieB.ForeColor = System.Drawing.Color.Black;
            this.trackFullMovieB.Name = "trackFullMovieB";
            this.trackFullMovieB.UseVisualStyleBackColor = false;
            this.trackFullMovieB.Click += new System.EventHandler(this.trackFullMovieB_Click);
            // 
            // initializeTrackingB
            // 
            this.initializeTrackingB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.initializeTrackingB, "initializeTrackingB");
            this.initializeTrackingB.ForeColor = System.Drawing.Color.Black;
            this.initializeTrackingB.Name = "initializeTrackingB";
            this.initializeTrackingB.UseVisualStyleBackColor = false;
            this.initializeTrackingB.Click += new System.EventHandler(this.initializeTrackingB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.preferencesB);
            this.groupBox1.Controls.Add(this.exportResultsB);
            this.groupBox1.Controls.Add(this.quitB);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // preferencesB
            // 
            this.preferencesB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.preferencesB, "preferencesB");
            this.preferencesB.ForeColor = System.Drawing.Color.Black;
            this.preferencesB.Name = "preferencesB";
            this.preferencesB.UseVisualStyleBackColor = false;
            this.preferencesB.Click += new System.EventHandler(this.preferencesB_Click);
            // 
            // exportResultsB
            // 
            this.exportResultsB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.exportResultsB, "exportResultsB");
            this.exportResultsB.ForeColor = System.Drawing.Color.Black;
            this.exportResultsB.Name = "exportResultsB";
            this.exportResultsB.UseVisualStyleBackColor = false;
            this.exportResultsB.Click += new System.EventHandler(this.exportResultsB_Click);
            // 
            // quitB
            // 
            this.quitB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.quitB, "quitB");
            this.quitB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitB.ForeColor = System.Drawing.Color.Black;
            this.quitB.Name = "quitB";
            this.quitB.UseVisualStyleBackColor = false;
            this.quitB.Click += new System.EventHandler(this.quitB_Click);
            // 
            // definedPointsGB
            // 
            this.definedPointsGB.BackColor = System.Drawing.Color.Transparent;
            this.definedPointsGB.Controls.Add(this.trackingPointsLB);
            resources.ApplyResources(this.definedPointsGB, "definedPointsGB");
            this.definedPointsGB.ForeColor = System.Drawing.Color.Black;
            this.definedPointsGB.Name = "definedPointsGB";
            this.definedPointsGB.TabStop = false;
            this.definedPointsGB.Resize += new System.EventHandler(this.definedPointsGB_Resize);
            // 
            // trackingPointsLB
            // 
            this.trackingPointsLB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.trackingPointsLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.trackingPointsLB, "trackingPointsLB");
            this.trackingPointsLB.ForeColor = System.Drawing.Color.Black;
            this.trackingPointsLB.Name = "trackingPointsLB";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.calibrateDistanceXYB);
            this.groupBox5.Controls.Add(this.calibrateDistanceYZB);
            this.groupBox5.Controls.Add(this.calibrateDistanceXZB);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // calibrateDistanceXYB
            // 
            this.calibrateDistanceXYB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.calibrateDistanceXYB, "calibrateDistanceXYB");
            this.calibrateDistanceXYB.ForeColor = System.Drawing.Color.Black;
            this.calibrateDistanceXYB.Name = "calibrateDistanceXYB";
            this.calibrateDistanceXYB.UseVisualStyleBackColor = false;
            this.calibrateDistanceXYB.Click += new System.EventHandler(this.calibrateDistanceXYB_Click);
            // 
            // calibrateDistanceYZB
            // 
            this.calibrateDistanceYZB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.calibrateDistanceYZB, "calibrateDistanceYZB");
            this.calibrateDistanceYZB.ForeColor = System.Drawing.Color.Black;
            this.calibrateDistanceYZB.Name = "calibrateDistanceYZB";
            this.calibrateDistanceYZB.UseVisualStyleBackColor = false;
            this.calibrateDistanceYZB.Click += new System.EventHandler(this.calibrateDistanceYZB_Click);
            // 
            // calibrateDistanceXZB
            // 
            this.calibrateDistanceXZB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.calibrateDistanceXZB, "calibrateDistanceXZB");
            this.calibrateDistanceXZB.ForeColor = System.Drawing.Color.Black;
            this.calibrateDistanceXZB.Name = "calibrateDistanceXZB";
            this.calibrateDistanceXZB.UseVisualStyleBackColor = false;
            this.calibrateDistanceXZB.Click += new System.EventHandler(this.calibrateDistanceXZB_Click);
            // 
            // mainFrame
            // 
            resources.ApplyResources(this.mainFrame, "mainFrame");
            this.mainFrame.Controls.Add(this.masterControlPanelP);
            this.mainFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainFrame.Name = "mainFrame";
            this.mainFrame.TabStop = false;
            this.mainFrame.Resize += new System.EventHandler(this.mainFrame_Resize);
            // 
            // masterControlPanelP
            // 
            this.masterControlPanelP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.masterControlPanelP.Controls.Add(this.masterControlPanelDisplayTB);
            this.masterControlPanelP.Controls.Add(this.frameCounter);
            this.masterControlPanelP.Controls.Add(this.modeChangeB);
            this.masterControlPanelP.Controls.Add(this.ffdB);
            this.masterControlPanelP.Controls.Add(this.revB);
            this.masterControlPanelP.Controls.Add(this.frameBckB);
            this.masterControlPanelP.Controls.Add(this.frameFfdB);
            this.masterControlPanelP.Controls.Add(this.stopB);
            this.masterControlPanelP.Controls.Add(this.pauseB);
            this.masterControlPanelP.Controls.Add(this.playB);
            resources.ApplyResources(this.masterControlPanelP, "masterControlPanelP");
            this.masterControlPanelP.Name = "masterControlPanelP";
            this.masterControlPanelP.Resize += new System.EventHandler(this.masterControlPanelP_Resize);
            // 
            // masterControlPanelDisplayTB
            // 
            this.masterControlPanelDisplayTB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.masterControlPanelDisplayTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.masterControlPanelDisplayTB, "masterControlPanelDisplayTB");
            this.masterControlPanelDisplayTB.Name = "masterControlPanelDisplayTB";
            // 
            // frameCounter
            // 
            this.frameCounter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.frameCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.frameCounter, "frameCounter");
            this.frameCounter.Name = "frameCounter";
            // 
            // modeChangeB
            // 
            this.modeChangeB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.modeChangeB, "modeChangeB");
            this.modeChangeB.ForeColor = System.Drawing.Color.Black;
            this.modeChangeB.Name = "modeChangeB";
            this.modeChangeB.UseVisualStyleBackColor = false;
            this.modeChangeB.Click += new System.EventHandler(this.modeChangeB_Click);
            // 
            // ffdB
            // 
            this.ffdB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.ffdB, "ffdB");
            this.ffdB.ForeColor = System.Drawing.Color.Black;
            this.ffdB.Name = "ffdB";
            this.ffdB.UseVisualStyleBackColor = false;
            this.ffdB.Click += new System.EventHandler(this.ffdB_Click);
            // 
            // revB
            // 
            this.revB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.revB, "revB");
            this.revB.ForeColor = System.Drawing.Color.Black;
            this.revB.Name = "revB";
            this.revB.UseVisualStyleBackColor = false;
            this.revB.Click += new System.EventHandler(this.revB_Click);
            // 
            // frameBckB
            // 
            this.frameBckB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.frameBckB, "frameBckB");
            this.frameBckB.ForeColor = System.Drawing.Color.Black;
            this.frameBckB.Name = "frameBckB";
            this.frameBckB.UseVisualStyleBackColor = false;
            this.frameBckB.Click += new System.EventHandler(this.frameBckB_Click);
            // 
            // frameFfdB
            // 
            this.frameFfdB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.frameFfdB, "frameFfdB");
            this.frameFfdB.ForeColor = System.Drawing.Color.Black;
            this.frameFfdB.Name = "frameFfdB";
            this.frameFfdB.UseVisualStyleBackColor = false;
            this.frameFfdB.Click += new System.EventHandler(this.frameFfdB_Click);
            // 
            // stopB
            // 
            this.stopB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.stopB, "stopB");
            this.stopB.ForeColor = System.Drawing.Color.Black;
            this.stopB.Name = "stopB";
            this.stopB.UseVisualStyleBackColor = false;
            this.stopB.Click += new System.EventHandler(this.stopB_Click);
            // 
            // pauseB
            // 
            this.pauseB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.pauseB, "pauseB");
            this.pauseB.ForeColor = System.Drawing.Color.Black;
            this.pauseB.Name = "pauseB";
            this.pauseB.UseVisualStyleBackColor = false;
            this.pauseB.Click += new System.EventHandler(this.pauseB_Click);
            // 
            // playB
            // 
            this.playB.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.playB, "playB");
            this.playB.ForeColor = System.Drawing.Color.Black;
            this.playB.Name = "playB";
            this.playB.UseVisualStyleBackColor = false;
            this.playB.Click += new System.EventHandler(this.playB_Click);
            // 
            // messagesLB
            // 
            this.messagesLB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.messagesLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.messagesLB, "messagesLB");
            this.messagesLB.Name = "messagesLB";
            // 
            // loadProjectD
            // 
            resources.ApplyResources(this.loadProjectD, "loadProjectD");
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.quitB;
            this.Controls.Add(this.messagesLB);
            this.Controls.Add(this.mainFrame);
            this.Controls.Add(this.toolBoxP);
            this.Menu = this.mainMenu1;
            this.Name = "mainForm";
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            this.toolBoxP.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.postProcessingGB.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.definedPointsGB.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.mainFrame.ResumeLayout(false);
            this.masterControlPanelP.ResumeLayout(false);
            this.masterControlPanelP.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new mainForm());
		}

		//_______________________________________________________________________

		//create viewports and add event handlers to them
		private int InitializeViewports()
		{
			this.viewportXY =  new ctlViewport();
			this.viewportXZ =  new ctlViewport();
			this.viewportYZ =  new ctlViewport();
		
			this.viewportXY.Location = new System.Drawing.Point(8, 16);
			this.viewportXY.Name = "viewportXY";
			this.viewportXY.Size = new System.Drawing.Size(364, 278);
			this.viewportXY.TabIndex = 10;
			this.mainFrame.Controls.Add(this.viewportXY);
			this.viewportXY.Resize += new System.EventHandler(vprtXY_Rsz);
			this.viewportXY.stillDisplay.MouseDown+= new System.Windows.Forms.MouseEventHandler(updateCoordsXY);
			this.viewportXY.stillDisplay.MouseMove+=new MouseEventHandler(XYpointResize);
			this.viewportXY.stillDisplay.MouseUp+=new MouseEventHandler(XYpointEndResize);
			this.viewportXY.VideoLoaded+=new ctlViewportlib.ctlViewport.VideoLoadedEventHandler (VideoLoadedByViewport);
			this.viewportXY.PostProcessingUpdated+=new ctlViewportlib.ctlViewport.PostProcessingUpdatedEventHandler(UpdateViewportSettings);
			this.viewportXY.StartFrameUpdated+=new ctlViewportlib.ctlViewport.StartFrameUpdatedEventHandler(UpdateViewportSettings);
			this.viewportXY.EndOfMovieReached+=new ctlViewportlib.ctlViewport.EndOfMovieReachedEventHandler(EndOfMovieReached);

			this.viewportXZ.Location = new System.Drawing.Point(viewportXY.Location.X+viewportXY.Width+8, 16);
			this.viewportXZ.Name = "viewportXZ";
			this.viewportXZ.Size = new System.Drawing.Size(364, 278);
			this.viewportXZ.TabIndex = 11;
			this.mainFrame.Controls.Add(this.viewportXZ);
			this.viewportXZ.Resize += new System.EventHandler(vprtXZ_Rsz);
			this.viewportXZ.stillDisplay.MouseDown+= new System.Windows.Forms.MouseEventHandler(updateCoordsXZ);
			this.viewportXZ.stillDisplay.MouseMove+=new MouseEventHandler(XZpointResize);
			this.viewportXZ.stillDisplay.MouseUp+=new MouseEventHandler(XZpointEndResize);
			this.viewportXZ.VideoLoaded+=new ctlViewportlib.ctlViewport.VideoLoadedEventHandler (VideoLoadedByViewport);
			this.viewportXZ.PostProcessingUpdated+=new ctlViewportlib.ctlViewport.PostProcessingUpdatedEventHandler(UpdateViewportSettings);
			this.viewportXZ.StartFrameUpdated+=new ctlViewportlib.ctlViewport.StartFrameUpdatedEventHandler(UpdateViewportSettings);
			this.viewportXZ.EndOfMovieReached+=new ctlViewportlib.ctlViewport.EndOfMovieReachedEventHandler(EndOfMovieReached);

			this.viewportYZ.Location = new System.Drawing.Point(8, viewportXY.Location.Y+viewportXY.Height+8);
			this.viewportYZ.Name = "viewportYZ";
			this.viewportYZ.Size = new System.Drawing.Size(364, 278);
			this.viewportYZ.TabIndex = 12;
			this.mainFrame.Controls.Add(this.viewportYZ);
			this.viewportYZ.Resize += new System.EventHandler(vprtYZ_Rsz);
			this.viewportYZ.stillDisplay.MouseDown+= new System.Windows.Forms.MouseEventHandler(updateCoordsYZ);
			this.viewportYZ.stillDisplay.MouseMove+=new MouseEventHandler(YZpointResize);
			this.viewportYZ.stillDisplay.MouseUp+=new MouseEventHandler(YZpointEndResize);
			this.viewportYZ.VideoLoaded+=new ctlViewportlib.ctlViewport.VideoLoadedEventHandler (VideoLoadedByViewport);
			this.viewportYZ.PostProcessingUpdated+=new ctlViewportlib.ctlViewport.PostProcessingUpdatedEventHandler(UpdateViewportSettings);
			this.viewportYZ.StartFrameUpdated+=new ctlViewportlib.ctlViewport.StartFrameUpdatedEventHandler(UpdateViewportSettings);
			this.viewportYZ.EndOfMovieReached+=new ctlViewportlib.ctlViewport.EndOfMovieReachedEventHandler(EndOfMovieReached);
			
			this.Invalidate();

			currentMode="playback";
			
			return 1;
		}
		
		//create and initialize new settings object
		private int InitializeSettings(string projectName)
		{
			projectSettings = new BaseTypes.Settings();
			
			projectSettings.projectName=projectName;

			projectSettings.viewportXY1pxDistance=-1;
			projectSettings.viewportXZ1pxDistance=-1;
			projectSettings.viewportYZ1pxDistance=-1;
			
			projectSettings.neuralNetworkHiddenLayersCount=2;
			projectSettings.neuralNetworkHiddenLayersSize=80;
			projectSettings.neuralNetworkMaximumWeight=4;
			projectSettings.neuralNetworkMinimumWeight=-4;
			projectSettings.neuralNetworkTrainingIterations=2300;
			projectSettings.neuralNetworkTrainingRate=0.1;
			
			projectSettings.frameIterator=1;
			projectSettings.defaultRadius=4;

			projectSettings.viewportXYBrightnessCorrectionValue=0;
			projectSettings.viewportXYContrastCorrectionValue=0;
			projectSettings.viewportXYFileName=null;
			projectSettings.viewportXYGreyScale=false;
			projectSettings.viewportXYHorizontalRes=320;
			projectSettings.viewportXYScalingFactor=100;
			projectSettings.viewportXYScalingType=BaseTypes.scalingType.Native;
			projectSettings.viewportXYStartFrame=0;
			projectSettings.viewportXYVerticalRes=240;
			

			projectSettings.viewportXZBrightnessCorrectionValue=0;
			projectSettings.viewportXZContrastCorrectionValue=0;
			projectSettings.viewportXZFileName=null;
			projectSettings.viewportXZGreyScale=false;
			projectSettings.viewportXZHorizontalRes=320;
			projectSettings.viewportXZScalingFactor=100;
			projectSettings.viewportXZScalingType=BaseTypes.scalingType.Native;
			projectSettings.viewportXZStartFrame=0;
			projectSettings.viewportXZVerticalRes=240;

			projectSettings.viewportYZBrightnessCorrectionValue=0;
			projectSettings.viewportYZContrastCorrectionValue=0;
			projectSettings.viewportYZFileName=null;
			projectSettings.viewportYZGreyScale=false;
			projectSettings.viewportYZHorizontalRes=320;
			projectSettings.viewportYZScalingFactor=100;
			projectSettings.viewportYZScalingType=BaseTypes.scalingType.Native;
			projectSettings.viewportYZStartFrame=0;
			projectSettings.viewportYZVerticalRes=240;

			projectSettings.minimumOrientPointRadius=4;
			projectSettings.maximumOrientPointRadius=25;

			projectSettings.scanAreaOffset=10;
			projectSettings.preciseAcceptanceThreshold=80;
			projectSettings.fineAcceptanceThreshold=60;
			projectSettings.lowAcceptanceThreshold=50;

			this.Text="LW3d Motion Capture Utility : "+projectName;
			return 1;
		}
		
		//handles application exit (dialog)
		private int AppExit()
		{ 
			Message("Application exiting...");
			saveQuery();
			using (exit xForm = new exit())
			{
				if (xForm.ShowDialog(this)== DialogResult.OK)
				{
				
					Application.Exit();	
					return 1;
				} 
				else 
				{
					
					Message("Application exiting aborted");
					return 0;
				}
           

			}

		}
		
		//handles creating new project
		private void NewProject()
		{
			Message("Building new project");

			using (projectName xForm = new projectName())
			{
				if (xForm.ShowDialog(this) == DialogResult.OK) 
				{
					if (viewportXY!=null || viewportXZ!=null || viewportYZ!=null)
					
						CloseCurrentProject();
					InitializeSettings(xForm.pName);
					InitializeViewports();
					
					Message("Project loaded"); 
					
					trackingPoints = new ArrayList();
					trackingPointsBasicInfo=new ArrayList();
					app_status.SetStatus(_app_status.project_active);
				}
				else Message("Creating new project canceled");
			}
			
		}

		//handles closing project (to re-implement)
		private void CloseCurrentProject() 
		{
			if (app_status.GetStatus()>=_app_status.project_active)
			{
				saveQuery();
				trackingPoints=null;
				projectSettings=null;
			
				viewportXY.Dispose();
				viewportXZ.Dispose();
				viewportYZ.Dispose();
		        tempTrackingPoint=null;
            	tf=null;
                trackingPointsBasicInfo=null;
		        trackingPoints=null; 
		        totalTrackingPoints=0;

                trackingHist = null;
                viewportXY=null;
				viewportXZ=null;
				viewportYZ=null;
				trackingPointsLB.Items.Clear();
				app_status.SetStatus(_app_status.started);
			}
			else Message("No active project detected");
		}

		//handles saving project
		private void SaveProject()
		{
			if (app_status.GetStatus()>=_app_status.viewports_ready)
			if (projectSettings!=null)
			{
			
				projectSettings.viewportXYGreyScale=viewportXY.grayscale;
				projectSettings.viewportXYBrightnessCorrectionValue=viewportXY.brightnessCorrection;
				projectSettings.viewportXYContrastCorrectionValue=viewportXY.contrastCorrection;
				projectSettings.viewportXZGreyScale=viewportXZ.grayscale;
				projectSettings.viewportXZBrightnessCorrectionValue=viewportXZ.brightnessCorrection;
				projectSettings.viewportXZContrastCorrectionValue=viewportXZ.contrastCorrection;
				projectSettings.viewportYZGreyScale=viewportYZ.grayscale;
				projectSettings.viewportYZBrightnessCorrectionValue=viewportYZ.brightnessCorrection;
				projectSettings.viewportYZContrastCorrectionValue=viewportYZ.contrastCorrection;

				saveProjectD.Filter = "Motion capture project files (*.mcp)|*.mcp";
			
				if((saveProjectD.ShowDialog() == System.Windows.Forms.DialogResult.OK) &&
					(saveProjectD.FileName!=""))
				{
				
					IFormatter formatter = new BinaryFormatter();
					Stream stream = new FileStream(saveProjectD.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
					formatter.Serialize(stream, projectSettings);
					stream.Close();

					if (trackingHist!=null)
						if (trackingHist.projectName==projectSettings.projectName)
						{
						
							IFormatter formatter2 = new BinaryFormatter();
							Stream stream2 = new FileStream(saveProjectD.FileName+"th", FileMode.Create, FileAccess.Write, FileShare.None);
							formatter2.Serialize(stream2, trackingHist);
							stream2.Close();
							Message("Tracking history file created: "+saveProjectD.FileName+"th");
						}
					
					Message("Project saved successuly: "+saveProjectD.FileName);
					projectSaved=true;
					
				
				} 
				else Message("Project saving failed/aborted");
			}
			else Message("No project loaded - saving failed...");
        else Message("No relevant project info has been supplied!");
		}

		//handles loading project
		private void LoadProject()
		{	
			Message("Loading project");
			
			loadProjectD.Filter = "Motion capture project files (*.mcp)|*.mcp";
			
			if((loadProjectD.ShowDialog() == System.Windows.Forms.DialogResult.OK) &&
				(loadProjectD.FileName!=""))
			{
			
				if (viewportXY!=null || viewportXZ!=null || viewportYZ!=null)
					CloseCurrentProject();
					
				InitializeSettings("temp");
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(loadProjectD.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				projectSettings = new BaseTypes.Settings();
				projectSettings= (BaseTypes.Settings)formatter.Deserialize(stream);
				stream.Close();
				InitializeViewports();
				trackingPoints = new ArrayList();
				app_status.SetStatus(_app_status.project_active);

				
				
				if (projectSettings.viewportXYScalingType==BaseTypes.scalingType.Custom)
					viewportXY.loadMedia(projectSettings.viewportXYFileName,(int)projectSettings.viewportXYHorizontalRes,(int)projectSettings.viewportXYVerticalRes);
				else if (projectSettings.viewportXYScalingType==BaseTypes.scalingType.ScaleBy)
					viewportXY.loadMedia(projectSettings.viewportXYFileName,projectSettings.viewportXYScalingFactor);
				else viewportXY.loadMedia(projectSettings.viewportXYFileName);
				
	
				if (projectSettings.viewportXZScalingType==BaseTypes.scalingType.Custom)
					viewportXZ.loadMedia(projectSettings.viewportXZFileName,(int)projectSettings.viewportXZHorizontalRes,(int)projectSettings.viewportXZVerticalRes);
				else if (projectSettings.viewportXZScalingType==BaseTypes.scalingType.ScaleBy)
					viewportXZ.loadMedia(projectSettings.viewportXZFileName,projectSettings.viewportXZScalingFactor);
				else viewportXZ.loadMedia(projectSettings.viewportXZFileName);


				if (projectSettings.viewportYZScalingType==BaseTypes.scalingType.Custom)
					viewportYZ.loadMedia(projectSettings.viewportYZFileName,(int)projectSettings.viewportYZHorizontalRes,(int)projectSettings.viewportYZVerticalRes);
				else if (projectSettings.viewportYZScalingType==BaseTypes.scalingType.ScaleBy)
					viewportYZ.loadMedia(projectSettings.viewportYZFileName,projectSettings.viewportYZScalingFactor);
				else viewportYZ.loadMedia(projectSettings.viewportYZFileName);
				

				viewportXY.setStartFrame(projectSettings.viewportXYStartFrame);
				viewportXZ.setStartFrame(projectSettings.viewportXZStartFrame);
				viewportYZ.setStartFrame(projectSettings.viewportYZStartFrame);
				viewportXY.grayscale=projectSettings.viewportXYGreyScale;
				viewportXY.brightnessCorrection=projectSettings.viewportXYBrightnessCorrectionValue;
				viewportXY.contrastCorrection=projectSettings.viewportXYContrastCorrectionValue;
				viewportXZ.grayscale=projectSettings.viewportXZGreyScale;
				viewportXZ.brightnessCorrection=projectSettings.viewportXZBrightnessCorrectionValue;
				viewportXZ.contrastCorrection=projectSettings.viewportXZContrastCorrectionValue;
				viewportYZ.grayscale=projectSettings.viewportYZGreyScale;
				viewportYZ.brightnessCorrection=projectSettings.viewportYZBrightnessCorrectionValue;
				viewportYZ.contrastCorrection=projectSettings.viewportYZContrastCorrectionValue;
                app_status.SetStatus(_app_status.viewports_ready);

				
				if (File.Exists(loadProjectD.FileName+"th"))
				{
					formatter = new BinaryFormatter();
					stream = new FileStream(loadProjectD.FileName+"th", FileMode.Open, FileAccess.Read, FileShare.Read);
					trackingHist = new BaseTypes.trackingHistory();
					trackingHist= (BaseTypes.trackingHistory)formatter.Deserialize(stream);
					stream.Close();
					foreach (BaseTypes.trackingPointLite tpp in trackingHist.initialTrackingPointsSet)
					{

						trackingPoint tempTrackingPoint  = new trackingPoint(tpp.pName,tpp.xyCoordX,tpp.xyCoordY,tpp.xzCoordX,tpp.xzCoordZ,tpp.yzCoordY,tpp.yzCoordZ,tpp.xyRadius,tpp.xzRadius,tpp.yzRadius, tpp.pColor);
						trackingPoints.Add(tempTrackingPoint);
						
						if (trackingPointsBasicInfo==null) trackingPointsBasicInfo = new ArrayList();
						trackingPointsBasicInfo.Add(tpp);

					}
					vprtsChngMode(); //visualizePoints() doesn't work in playback mode
					visualizePoints();
					trackingPointsLB.Items.Clear();
					foreach (trackingPoint tp in trackingPoints)
						trackingPointsLB.Items.Add(tp.PName);
                   
			        app_status.SetStatus(_app_status.distance_calibrated);
					app_status.SetStatus(_app_status.points_defined);
						
					
				} else
				
					if (projectSettings.viewportXY1pxDistance!=-1 && projectSettings.viewportXZ1pxDistance!=-1 && projectSettings.viewportYZ1pxDistance!=-1)
					 app_status.SetStatus(_app_status.distance_calibrated);

				
				this.Text="LW3d Motion Capture Utility : "+projectSettings.projectName;


				Message("New project loaded: "+loadProjectD.FileName); 
				
			}
			else Message("New project aborted");
		}

		private void saveQuery()
		{
			if (!projectSaved)
				using (saveProject xForm = new saveProject())
				{
					if (xForm.ShowDialog()==System.Windows.Forms.DialogResult.Yes)
					
						SaveProject(); else projectSaved=true;
				}

		}
	
		//handles preferences window (dialog)
		private void OpenPreferences()
		{
			if (projectSettings!=null)
				using (preferencesForm xForm = new preferencesForm(projectSettings))
				{
					Message("Opening preferences window...");
					if (xForm.ShowDialog(this)==DialogResult.OK)
					{
						
					
						//if ( (projectSettings.viewportXYScalingType!=xForm.localSettingsInstance.viewportXYScalingType) ||
						//	(projectSettings.viewportXZScalingType!=xForm.localSettingsInstance.viewportXZScalingType) ||
						//	(projectSettings.viewportYZScalingType!=xForm.localSettingsInstance.viewportYZScalingType) )
							  
						//{
						//TU MA BYÆ OSTRZE¯ENIE O RESKALOWANIU!!!
						viewportXY.Dispose();
						viewportXZ.Dispose();
						viewportYZ.Dispose();

						InitializeViewports();	
						
						if (xForm.localSettingsInstance.viewportXYScalingType==BaseTypes.scalingType.Custom)
							viewportXY.loadMedia(xForm.localSettingsInstance.viewportXYFileName,(int)xForm.localSettingsInstance.viewportXYHorizontalRes,(int)xForm.localSettingsInstance.viewportXYVerticalRes);
						else if (xForm.localSettingsInstance.viewportXYScalingType==BaseTypes.scalingType.ScaleBy)
							viewportXY.loadMedia(xForm.localSettingsInstance.viewportXYFileName,xForm.localSettingsInstance.viewportXYScalingFactor);
						else viewportXY.loadMedia(xForm.localSettingsInstance.viewportXYFileName);
				
	
						if (xForm.localSettingsInstance.viewportXZScalingType==BaseTypes.scalingType.Custom)
							viewportXZ.loadMedia(xForm.localSettingsInstance.viewportXZFileName,(int)xForm.localSettingsInstance.viewportXZHorizontalRes,(int)xForm.localSettingsInstance.viewportXZVerticalRes);
						else if (xForm.localSettingsInstance.viewportXZScalingType==BaseTypes.scalingType.ScaleBy)
							viewportXZ.loadMedia(xForm.localSettingsInstance.viewportXZFileName,xForm.localSettingsInstance.viewportXZScalingFactor);
						else viewportXZ.loadMedia(xForm.localSettingsInstance.viewportXZFileName);


						if (xForm.localSettingsInstance.viewportYZScalingType==BaseTypes.scalingType.Custom)
							viewportYZ.loadMedia(xForm.localSettingsInstance.viewportYZFileName,(int)xForm.localSettingsInstance.viewportYZHorizontalRes,(int)xForm.localSettingsInstance.viewportYZVerticalRes);
						else if (xForm.localSettingsInstance.viewportYZScalingType==BaseTypes.scalingType.ScaleBy)
							viewportYZ.loadMedia(xForm.localSettingsInstance.viewportYZFileName,xForm.localSettingsInstance.viewportYZScalingFactor);
						else viewportYZ.loadMedia(xForm.localSettingsInstance.viewportYZFileName);
				
						
				

						projectSettings=xForm.localSettingsInstance; 

						viewportXY.setStartFrame(projectSettings.viewportXYStartFrame);
						viewportXZ.setStartFrame(projectSettings.viewportXZStartFrame);
						viewportYZ.setStartFrame(projectSettings.viewportYZStartFrame);

						viewportXY.capMode();
						viewportXZ.capMode();
						viewportYZ.capMode();

						visualizePoints();
					}
					Message("Updating preferences complete");
					projectSaved=false;
				} 
			else Message("No project active - load or create new project first");
		}

		//displays message in message list
        delegate void SetTextCallback(string msg);

        private void Message(string msg)
		{
            if (this.messagesLB.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Message);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.messagesLB.Items.Insert(0,msg);
            }


            
		}

		//updates project setting, if changes occured in viewport
		private void UpdateViewportSettings(ctlViewportlib.ctlViewport vprt) 
		{
			projectSettings.viewportXYBrightnessCorrectionValue=viewportXY.brightnessCorrection;
			projectSettings.viewportXYContrastCorrectionValue=viewportXY.contrastCorrection;
			projectSettings.viewportXYStartFrame=viewportXY.getStartFrame();
			projectSettings.viewportXYFileName=viewportXY.getMediaFileName();
			projectSettings.viewportXYGreyScale=viewportXY.grayscale;
        
			projectSettings.viewportXZBrightnessCorrectionValue=viewportXZ.brightnessCorrection;
			projectSettings.viewportXZContrastCorrectionValue=viewportXZ.contrastCorrection;
			projectSettings.viewportXZStartFrame=viewportXZ.getStartFrame();
			projectSettings.viewportXZFileName=viewportXZ.getMediaFileName();
			projectSettings.viewportXZGreyScale=viewportXZ.grayscale;

			projectSettings.viewportYZBrightnessCorrectionValue=viewportYZ.brightnessCorrection;
			projectSettings.viewportYZContrastCorrectionValue=viewportYZ.contrastCorrection;
			projectSettings.viewportYZStartFrame=viewportYZ.getStartFrame();
			projectSettings.viewportYZFileName=viewportYZ.getMediaFileName();
			projectSettings.viewportYZGreyScale=viewportYZ.grayscale;
		    
			projectSaved=false;
		}

		//TO IMPLEMENT
		private void ApplySettings() //from structure to forms? //TO IMPLEMENT
		{


		}

		//aligns viewports, after media loading
		private void AlignViewports()
		{
			viewportXY.Top=16; //always the same
			viewportXY.Left=8; //always the same
			
			if (viewportYZ.Width>viewportXY.Width)
				viewportXZ.Left=viewportYZ.Right+8; 
			else
				viewportXZ.Left=viewportXY.Right+8;

			if (viewportXZ.Height>viewportXY.Height)
				viewportYZ.Top=viewportXZ.Bottom+8;
			else
				viewportYZ.Top=viewportXY.Bottom+8;

			Message("Aligning viewports...");
		}

		//starts playback in viewports
		private void vprtsPlay()
		{ //no synchro provided
			viewportXY.Play();
			viewportXZ.Play();
			viewportYZ.Play();
		}

		//stop playback in viewports
		private void vprtsStop()
		{//no synchro provided
			viewportXY.Stop();
			viewportXZ.Stop();
			viewportYZ.Stop();
		}

		//pauses playback in viewports
		private void vprtsPause()
		{//no synchro provided
			viewportXY.Pause();
			viewportXZ.Pause();
			viewportYZ.Pause();
		}

		//rewinds media to start frame in viewports
		private void vprtsRev()
		{//no synchro provided
			viewportXY.Rewind();
			viewportXZ.Rewind();
			viewportYZ.Rewind();
		}

		//goes to last frame in viewports
		private void vprtsFfd()
		{//no synchro provided
			viewportXY.FastForward();
			viewportXZ.FastForward();
			viewportYZ.FastForward();
		}

		//change viewports mode
		private void vprtsChngMode()
		{
			if (currentMode=="playback")
			{
				viewportXY.capMode();
				viewportXZ.capMode();
				viewportYZ.capMode();
				currentMode="capture";
				modeChangeB.Text="PLB";
				if (trackingPoints!=null) visualizePoints();
			}
			else 
			{
				viewportXY.plbMode();
				viewportXZ.plbMode();
				viewportYZ.plbMode();
				currentMode="playback";
				modeChangeB.Text="CAP";
			}
		}

		//Displays message in master control panel
		private void mpMessage(string msg)
		{
			masterControlPanelDisplayTB.Text=msg;
		}
		
		//handles adding new tracking point (dialog?)
		private void addTrackingPoint()
		{
	
			if	(	app_status.GetStatus()>=_app_status.distance_calibrated)
			if (viewportXY.isCapture() && viewportXZ.isCapture() && viewportYZ.isCapture())
			{
				tForm = new trackingPointProperties(trackingPointsBasicInfo);
				tForm.Closing+=new CancelEventHandler(trackingPointPropertiesClosingHandler);
				tForm.Show();
				
				addingPoint=true;
				tempTrackingPoint =new trackingPoint("temporary",projectSettings.defaultRadius, System.Drawing.Color.Orange); 
			} 
			else Message("One or more viewports not in capture mode/has no video loaded");
		else Message ("Calibrate distance in all viewports first");
		}

		//visualizes existing tracking points in viewports
		public void visualizePoints()
		{
			Bitmap TL, TR, BL;

			

			TL = new Bitmap(viewportXY.GetFrame(false)); //!!!!!!!!!!!!!!!!
			TR = new Bitmap(viewportXZ.GetFrame(false));
			BL = new Bitmap(viewportYZ.GetFrame(false));


			foreach (trackingPoint tp in trackingPoints)
			{
				TL = tp.visualizePoint(TL,BaseTypes.viewport.TopLeft);
				TR = tp.visualizePoint(TR,BaseTypes.viewport.TopRight);
				BL = tp.visualizePoint(BL,BaseTypes.viewport.BottomLeft);
			}

			viewportXY.UpdateDisplay(TL);
			viewportXZ.UpdateDisplay(TR);
			viewportYZ.UpdateDisplay(BL);

		}

		private void InitializeTracking()
		{
            
			if (app_status.GetStatus()>=_app_status.points_defined)
			{
                if (MessageBox.Show("Attempting to train neural networks. Application may be not responsive during training.", "ANN Training", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    DateTime start = DateTime.Now;
                   // string timeStarted = DateTime.Now.ToString("mm:ss:fff");
                    trackingHist = new BaseTypes.trackingHistory(projectSettings.projectName, trackingPointsBasicInfo, (int)viewportXY.getStartFrame(), (int)viewportXZ.getStartFrame(), (int)viewportYZ.getStartFrame());



                    foreach (trackingPoint tp in trackingPoints)

                        tp.FrameProcessed += new trackingPoint.FrameProcessedEventHandler(frameTrackingCompletedHandler);


                    if ((viewportXY.getStartFrame() == viewportXY.currentFrame) &&
                        (viewportXY.getStartFrame() == viewportXY.currentFrame) &&
                        (viewportXY.getStartFrame() == viewportXY.currentFrame))
                    {


                        foreach (trackingPoint tp in trackingPoints)
                        {

                            tp.initPointBitmaps(viewportXY.GetFrame(true), viewportXZ.GetFrame(true), viewportYZ.GetFrame(true));//just in case



                            tp.initAndTrainANN(projectSettings.neuralNetworkTrainingIterations,
                                projectSettings.neuralNetworkTrainingRate,
                                4,//const
                                projectSettings.neuralNetworkHiddenLayersCount,
                                projectSettings.neuralNetworkHiddenLayersSize,
                                projectSettings.neuralNetworkMinimumWeight,
                                projectSettings.neuralNetworkMaximumWeight,
                                viewportXY.GetFrame(true),
                                viewportXZ.GetFrame(true),
                                viewportYZ.GetFrame(true));
                        }
                        TimeSpan total =DateTime.Now- start;        //DateTime.Now.ToString("mm:ss:fff");

                        Message("Training completed!"); 
                        Message("Time: " +total.Seconds+"s "+total.Milliseconds+"msec");
                    

                        MessageBox.Show("Training sucessful :)","Training completed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        projectSaved = false;
                        app_status.SetStatus(_app_status.points_trained);


                    }
                    else Message("Unable to proceed with training. Check if viewports are in first frame...");
                }
             } else Message("No points defined yet...");
		}

		//handler for event triggered when loading movie via viewport button "LOAD"
		public void VideoLoadedByViewport(ctlViewport sender)
		{

			if (sender.Name==viewportXY.Name)
			{
				viewportXZ.Left=viewportXY.Location.X+viewportXY.Width+8;
				viewportYZ.Top =viewportXY.Location.Y+viewportXY.Height+8;
				projectSettings.viewportXYFileName=viewportXY.getMediaFileName();
			} 
			else if (sender.Name==viewportXZ.Name)
			{
				if (viewportYZ.Top+8<viewportXZ.Bottom+8)
					viewportYZ.Top=viewportXZ.Location.X+viewportXZ.Height+8;
				projectSettings.viewportXZFileName=viewportXZ.getMediaFileName();
			}
			else
			{
				projectSettings.viewportYZFileName=viewportYZ.getMediaFileName();
			}

			if (viewportXY.getMediaFileName()!=null && viewportXZ.getMediaFileName()!=null && viewportYZ.getMediaFileName()!=null)

				if (app_status.GetStatus()<_app_status.viewports_ready)
					app_status.SetStatus(_app_status.viewports_ready);
			
		}

		//Write string into fileStream (used in result exporting)
		private static void AddData(FileStream fs, string value) 
		{
			byte[] info = new UTF8Encoding(true).GetBytes(value);
			fs.Write(info, 0, info.Length);
		}

		//Handler of situtation when movie has reached end in one of viewports
		private void EndOfMovieReached(ctlViewport sender)
		{
			trackingCompleted=true;
		    if (app_status.GetStatus()==_app_status.tracking) app_status.SetStatus(_app_status.tracking_completed);
		}

		//Exporting tracking results to text file
		private void exportResults()
		{
			if (app_status.GetStatus()==_app_status.tracking_completed)
			{
				exportResultsSaveFileD.Filter = "Motion tracking result (*.mtr)|*.mtr";
			
				if((exportResultsSaveFileD.ShowDialog() == System.Windows.Forms.DialogResult.OK) &&
					(exportResultsSaveFileD.FileName!=""))
				{
					string NewLine="\r\n";
				
					using (FileStream fs = File.Create(exportResultsSaveFileD.FileName)) 
					{
					
					
						AddData(fs, "FrameCount="+Convert.ToString(trackingHist.trackingHistorySet.Count)+NewLine);
						AddData(fs, "PointCount="+Convert.ToString(trackingHist.initialTrackingPointsSet.Count)+NewLine);

						foreach (BaseTypes.timeFrame tf in trackingHist.trackingHistorySet)
						{
							AddData(fs,"frm="+tf.frame.ToString()+NewLine+"<"+NewLine);
							for (int i=0; i<=tf.count()-1; i++)
							{
								BaseTypes.trackingPointLite tpl = new FinalApp1.BaseTypes.trackingPointLite();
								tpl = tf.GetPoint(i);
								if (tpl!=null)
								{
									AddData(fs,"point="+Convert.ToString(i)+NewLine);
									AddData(fs,"x="+Convert.ToString(tpl.worldCoordX * projectSettings.viewportXY1pxDistance)+NewLine); //mm from top-left (treated as ground)
									AddData(fs,"y="+Convert.ToString(tpl.worldCoordY * projectSettings.viewportXZ1pxDistance)+NewLine);
									AddData(fs,"z="+Convert.ToString(tpl.worldCoordZ * projectSettings.viewportYZ1pxDistance)+NewLine);
								}
							}
							AddData(fs,">"+NewLine);
						}
					}
				}
			} else Message("You can export data only just after completing tracking session");
		}

		private void trackCurrentFrame()
		{
			//bitmap null reference tracking procedure
			tf = new BaseTypes.timeFrame((int)(viewportXY.getCurrentFrame()-viewportXY.getStartFrame()));
		
            
			foreach (trackingPoint tp in trackingPoints)
			{
				tp.trackPoint( viewportXY.GetFrame(true),
					viewportXZ.GetFrame(true),
					viewportYZ.GetFrame(true),projectSettings.preciseAcceptanceThreshold,projectSettings.scanAreaOffset);

			}
             
		}
		
		private void processFrame(int frameCount)
		{ 
			trackingHist.addTimeFrame(tf);

			if ((viewportXY.getCurrentFrame()-viewportXY.getStartFrame()<framesToTrack || framesToTrack==0) && trackingCompleted!=true)
			{
				if (!trackingPaused)
				{

					if (viewportXY.frameForward((uint)frameCount)==2)
						if (viewportXZ.frameForward((uint)frameCount)==2)
							viewportYZ.frameForward((uint)frameCount);
					if (framesToTrack!=0)
						Message("Frame processed - moved to next ("+Convert.ToString(framesToTrack-(viewportXY.getCurrentFrame()-viewportXY.getStartFrame()))+" left to process...)");
					else Message("Frame processed - moved to next");
					
					totalTrackingPoints=trackingPoints.Count;
					visualizePoints();
					trackCurrentFrame();
				}
		
				else
				{
					Message("Tracking paused");
					visualizePoints();
				} 
			}
			else
			{
                TimeFinish = DateTime.Now;
                TimeSpan TotalTime = TimeFinish - TimeStart;        //DateTime.Now.ToString("mm:ss:fff");

                
                
				Message("Tracking completed");
                Message("Tracking duration: " + TotalTime.Minutes + "m "+TotalTime.Seconds + "s " + TotalTime.Milliseconds + "msec");

				using (trackingCompleted tc= new trackingCompleted())
				{

					tc.ShowDialog();
				}
				
					app_status.SetStatus(_app_status.tracking_completed);
				visualizePoints();
			}

		}
	   
		private bool checkPointsStatus()
		{
         
			foreach (trackingPoint tp in trackingPoints)
			{
				if (!tp.isTrained) return false;
			}
			return true;

		}
		
		private void trackCertainMovieLen()
		{

			if (app_status.GetStatus()>=_app_status.points_trained)
			{
				Message("Number of frames querying...");
				using (framesToTrackDialog xForm = new framesToTrackDialog())
				{
					if (xForm.ShowDialog(this) == DialogResult.OK) 
					{
                        TimeStart = DateTime.Now;
						trackingCompleted=false;
						framesToTrack=xForm.framesCount;
						trackingHist=new BaseTypes.trackingHistory(projectSettings.projectName, trackingPointsBasicInfo,(int)viewportXY.getStartFrame(),(int)viewportXZ.getStartFrame(),(int)viewportYZ.getStartFrame() );
						tf = new BaseTypes.timeFrame(0);
						totalTrackingPoints=trackingPoints.Count;
						Message("Frames to track :"+Convert.ToString(framesToTrack));
						Message("Points to track : "+Convert.ToString(totalTrackingPoints));
						app_status.SetStatus(_app_status.tracking);
						trackCurrentFrame();
					
				
					}
					else Message("Tracking certain movie length cancelled...");
				} 
			}
			else Message("Unable to begin tracking! Some points are not trained!");

		}
		
		private void pauseTracking()
		{
			if (app_status.GetStatus()==_app_status.tracking)
			if (!trackingPaused)
			{
				Message("Please wait until frame is processed...");
				trackingPaused=!trackingPaused;
				pauseTrackingB.Text="Continue tracking";
			}
			else 
			{
				trackingPaused=!trackingPaused;
				Message("Tracking...");
				pauseTrackingB.Text="Pause tracking";
				processFrame(projectSettings.frameIterator);
			}
			else Message("No tracking being performed at the moment");

		}
		
		private void trackFullMovie()
		{
			if (app_status.GetStatus()>=_app_status.points_trained) 
			{
                TimeStart = DateTime.Now;
				trackingCompleted=false;
				framesToTrack=0;//viewportXY.;
				trackingHist=new BaseTypes.trackingHistory(projectSettings.projectName, trackingPointsBasicInfo,(int)viewportXY.getStartFrame(),(int)viewportXZ.getStartFrame(),(int)viewportYZ.getStartFrame() );
				tf = new BaseTypes.timeFrame(0);
				totalTrackingPoints=trackingPoints.Count;
				Message("Points to track : "+Convert.ToString(totalTrackingPoints));
				app_status.SetStatus(_app_status.tracking);
				trackCurrentFrame();
			} 
			else Message("Unable to begin tracking! Some points are not trained!");
		}

		private void showTrackedPointsBrowser()
		{
			if (app_status.GetStatus()>=_app_status.points_defined)
			{
				trackedPointsViewer tForm = new trackedPointsViewer(trackingHist);
				tForm.Show();	
			}
			else Message("No points defined yet");
		}

		private void deleteTrackingPoint()
		{
			if (app_status.GetStatus()>=_app_status.points_defined)
			{
				using (deletePointDialog xForm = new deletePointDialog(trackingPoints))
				{
					if (xForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
					{
						for(int x = 0; x <= xForm.trackingPointsCLB.CheckedItems.Count - 1 ; x++)
						{
							for (int i=0; i<trackingPoints.Count; i++)									  
								if 
									(((trackingPoint)trackingPoints[i]).PName==xForm.trackingPointsCLB.CheckedItems[x].ToString())
								{
									trackingPoints.RemoveAt(i);
									app_status.SetStatus(_app_status.points_defined);
                                    if (trackingPoints.Count<1)
										app_status.SetStatus(_app_status.distance_calibrated);

								}
					
							for (int i=0; i<trackingPointsBasicInfo.Count; i++)									  
								if (((BaseTypes.trackingPointLite)trackingPointsBasicInfo[i]).pName==xForm.trackingPointsCLB.CheckedItems[x].ToString())
									trackingPointsBasicInfo.RemoveAt(i);
						}

						trackingPointsLB.Items.Clear();
						foreach (trackingPoint tp in trackingPoints)
							trackingPointsLB.Items.Add(tp.PName);
						projectSaved=false;   
					}

				}
				visualizePoints();
			} else Message("No points defined yet");
		}
		private void modifyPointParameters()
		{
           if (app_status.GetStatus()>=_app_status.points_defined)
			if (trackingPointsLB.SelectedItem!=null)
			{
				Message("Attempting to modify point params...");
				
				foreach (trackingPoint tp in trackingPoints)
					if (tp.PName==trackingPointsLB.SelectedItem.ToString())
					{
						tempTrackingPoint = new trackingPoint(tp.PName,tp,tp.PColor);
						break;
					}

				oldPointName=tempTrackingPoint.PName;
			
				if (viewportXY.isCapture() && viewportXZ.isCapture() && viewportYZ.isCapture())
				{
					tForm = new trackingPointProperties(tempTrackingPoint);
					tForm.Closing+=new CancelEventHandler(trackingPointPropertiesUpdateClosingHandler);
					tForm.Show();
				
					addingPoint=true;
					
				} 
				else Message("One or more viewports not in capture mode/has no video loaded");
		
			} 
			else Message("Please select tracking point from Defined Points list");
		   else Message("No points defined yet");

		}
		


		//GUI invoked events
		//_______________________________________________________________________

		//Quit
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			AppExit();
		}

		//Open preferences
		private void menuItem13_Click_1(object sender, System.EventArgs e)
		{
			OpenPreferences();
		}

		//Quit
		private void quitB_Click(object sender, System.EventArgs e)
		{
			
			AppExit();
		}

		//New project
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			NewProject();
		}

		//New project
		private void newProjectB_Click(object sender, System.EventArgs e)
		{
			NewProject();
		}

		//Load Media XY
		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			viewportXY.loadMedia();
			viewportXZ.Left=viewportXY.Location.X+viewportXY.Width+8;
			viewportYZ.Top =viewportXY.Location.Y+viewportXY.Height+8;
			projectSettings.viewportXYFileName=viewportXY.getMediaFileName();	
			if (viewportXY.getMediaFileName()!=null && viewportXZ.getMediaFileName()!=null && viewportYZ.getMediaFileName()!=null)
            
				      app_status.SetStatus(_app_status.viewports_ready);

		}

		//Load Media XZ
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			viewportXZ.loadMedia();
			if (viewportYZ.Top+8<viewportXZ.Bottom+8)
				viewportYZ.Top=viewportXZ.Location.X+viewportXZ.Height+8;
			projectSettings.viewportXZFileName=viewportXZ.getMediaFileName();

			if (viewportXY.getMediaFileName()!=null && viewportXZ.getMediaFileName()!=null && viewportYZ.getMediaFileName()!=null)

				app_status.SetStatus(_app_status.viewports_ready);
		}

		//Load Media YZ
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			viewportYZ.loadMedia();
			projectSettings.viewportYZFileName=viewportYZ.getMediaFileName();

			if (viewportXY.getMediaFileName()!=null && viewportXZ.getMediaFileName()!=null && viewportYZ.getMediaFileName()!=null)

				app_status.SetStatus(_app_status.viewports_ready);
		}

		//Open preferences
		private void preferencesB_Click(object sender, System.EventArgs e)
		{
			OpenPreferences();
		}

		//Viewports play
		private void playB_Click(object sender, System.EventArgs e)
		{
			vprtsPlay();
		}

		//Viewports pausecompleted

		private void pauseB_Click(object sender, System.EventArgs e)
		{
			vprtsPause();
		}

		//Viewports stop
		private void stopB_Click(object sender, System.EventArgs e)
		{
			vprtsStop();
		}

		//viewports rewind
		private void revB_Click(object sender, System.EventArgs e)
		{
			vprtsRev();
		}

		//viewports fast forward
		private void ffdB_Click(object sender, System.EventArgs e)
		{
			vprtsFfd();
		}
	
		//Close project
		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			CloseCurrentProject();
		}

		//Close project
		private void closeProjectB_Click(object sender, System.EventArgs e)
		{
			CloseCurrentProject();
		}

		//Show about window
		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			using (aboutForm xForm = new aboutForm())
			{
				xForm.ShowDialog();

			}
		}

		//Viewports media Frame Forward
		private void frameFfdB_Click(object sender, System.EventArgs e)
		{
            try
            {
                viewportXY.frameForward(Convert.ToUInt32(frameCounter.Text));
                viewportXZ.frameForward(Convert.ToUInt32(frameCounter.Text));
                viewportYZ.frameForward(Convert.ToUInt32(frameCounter.Text));
            }
            catch
            {
                Message("Cannot proceed! Invalid data entered?");
            }
		}

		//Viewports media Frame Backward
        private void frameBckB_Click(object sender, System.EventArgs e)
        {
            try
            {
                viewportXY.frameBackward(Convert.ToUInt32(frameCounter.Text));
                viewportXZ.frameBackward(Convert.ToUInt32(frameCounter.Text));
                viewportYZ.frameBackward(Convert.ToUInt32(frameCounter.Text));
            }
            catch
            {
                Message("Cannot proceed! Invalid data entered?");
            }
        }

		//Change mode in viewports (playback/capture)
		private void modeChangeB_Click(object sender, System.EventArgs e)
		{
			vprtsChngMode();
		}

		//Add tracking point
		private void addTrackingPointB_Click(object sender, System.EventArgs e)
		{
			addTrackingPoint();
		}

		//Save project
		private void saveProjectB_Click(object sender, System.EventArgs e)
		{
			SaveProject();
		}

		//Load project
		private void loadProjectB_Click(object sender, System.EventArgs e)
		{
			LoadProject();
		}

		//Load project
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			LoadProject();
		}

		//Save project
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			SaveProject();
		}

		//Initialize tracking
		private void initializeTrackingB_Click(object sender, System.EventArgs e)
		{
			InitializeTracking();
		}

		private void exportResultsB_Click(object sender, System.EventArgs e)
		{
			exportResults();
		}

		//Calibrate distance in viewport XY
		private void calibrateDistanceXYB_Click(object sender, System.EventArgs e)
		{
			if (app_status.GetStatus()>=_app_status.viewports_ready)	
				
			{
				viewportXY.capMode();
				using (distanceCalibrationDialog xForm = new distanceCalibrationDialog(viewportXY.GetFrame(false)))
				{
					if (xForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				
						projectSettings.viewportXY1pxDistance=xForm.relativeDistance;
					trackingPoint.distanceQuotientXY=projectSettings.viewportXY1pxDistance;
					projectSaved=false;
					if (projectSettings.viewportXY1pxDistance!=-1 && projectSettings.viewportXZ1pxDistance!=-1 &&projectSettings.viewportYZ1pxDistance!=-1)
						if(app_status.GetStatus()<_app_status.distance_calibrated)
							 app_status.SetStatus(_app_status.distance_calibrated);
				}
			}
			else Message("Please load video first");
		}

		//Calibrate distance in viewport XZ
		private void calibrateDistanceXZB_Click(object sender, System.EventArgs e)
		{
			if (app_status.GetStatus()>=_app_status.viewports_ready)
			{
				viewportXZ.capMode();
				using (distanceCalibrationDialog xForm = new distanceCalibrationDialog(viewportXZ.GetFrame(false)))
				{
					if (xForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				
						projectSettings.viewportXZ1pxDistance=xForm.relativeDistance;
					trackingPoint.distanceQuotientXZ=projectSettings.viewportXZ1pxDistance;
					projectSaved=false;
					if (projectSettings.viewportXY1pxDistance!=-1 && projectSettings.viewportXZ1pxDistance!=-1 &&projectSettings.viewportYZ1pxDistance!=-1)
						if(app_status.GetStatus()<_app_status.distance_calibrated)
							app_status.SetStatus(_app_status.distance_calibrated);
				}
			}
			else Message("Please load video first");
		}

		//Calibrate distance in viewport YZ
		private void calibrateDistanceYZB_Click(object sender, System.EventArgs e)
		{
			if (app_status.GetStatus()>=_app_status.viewports_ready)
			{
				viewportYZ.capMode();
				using (distanceCalibrationDialog xForm = new distanceCalibrationDialog(viewportYZ.GetFrame(false)))
				{
					if (xForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				
						projectSettings.viewportYZ1pxDistance=xForm.relativeDistance;
					trackingPoint.distanceQuotientYZ=projectSettings.viewportYZ1pxDistance;
					projectSaved=false;
					if (projectSettings.viewportXY1pxDistance!=-1 && projectSettings.viewportXZ1pxDistance!=-1 &&projectSettings.viewportYZ1pxDistance!=-1)
						if(app_status.GetStatus()<_app_status.distance_calibrated)
							app_status.SetStatus(_app_status.distance_calibrated);

				}
			}
			else Message("Please load video first");
		}

		private void trackFullMovieB_Click(object sender, System.EventArgs e)
		{
			trackFullMovie();
		}

		private void pauseTrackingB_Click(object sender, System.EventArgs e)
		{
			pauseTracking();
		}

		private void trackedPointsBrowserB_Click(object sender, System.EventArgs e)
		{	
			showTrackedPointsBrowser();
		}

		private void deletePointB_Click(object sender, System.EventArgs e)
		{
			deleteTrackingPoint();
		}

		private void modifyPointParamsB_Click(object sender, System.EventArgs e)
		{
			modifyPointParameters();
		}

		private void trackCertainMovieLenB_Click(object sender, System.EventArgs e)
		{
			trackCertainMovieLen();
		}

		//resize invoked events
		//_______________________________________________________________________

		//positioning/resizing point for viewport XY
		private void updateCoordsXY (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				RMBDown = true; 
				RMBClickCoords = new System.Drawing.Point();
				RMBClickCoords.X = e.X;
			}
			
			else
			
				if (addingPoint)
			{
				tempTrackingPoint.setXYCoords(e.X,e.Y);
				tForm.xyLocXL.Text=Convert.ToString(tempTrackingPoint.XyCoordX);
				tForm.xyLocYL.Text=Convert.ToString(tempTrackingPoint.XyCoordY);
				
				viewportXY.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportXY.GetFrame(true),BaseTypes.viewport.TopLeft));
			} 

		}

		//positioning/resizing point for viewport XZ
		private void updateCoordsXZ (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				RMBDown = true; 
				RMBClickCoords = new System.Drawing.Point();
				RMBClickCoords.X = e.X;
			}
			
			else
				if (addingPoint)
			{
				tempTrackingPoint.setXZCoords(e.X,e.Y);
				tForm.xzLocXL.Text=Convert.ToString(tempTrackingPoint.XzCoordX);
				tForm.xzLocZL.Text=Convert.ToString(tempTrackingPoint.XzCoordZ);

				viewportXZ.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportXZ.GetFrame(true),BaseTypes.viewport.TopRight));
			}

		}
		//positioning/resizing point for viewport YZ
		private void updateCoordsYZ(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				RMBDown = true; 
				RMBClickCoords = new System.Drawing.Point();
				RMBClickCoords.X = e.X;
			}
			
			else
				if (addingPoint)
			{
				tempTrackingPoint.setYZCoords(e.X,e.Y);
				tForm.yzLocYL.Text=Convert.ToString(tempTrackingPoint.YzCoordY);
				tForm.yzLocZL.Text=Convert.ToString(tempTrackingPoint.YzCoordZ);
				
				viewportYZ.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportYZ.GetFrame(true),BaseTypes.viewport.BottomLeft));
			}

		}

		//Track point resize handling
		private void XYpointResize(object sender, MouseEventArgs e)
		{
			if (RMBDown && addingPoint)
			{
				if (e.X > RMBClickCoords.X)
				{
					if (tempTrackingPoint.XyRadius+1<=projectSettings.maximumOrientPointRadius)
						tempTrackingPoint.XyRadius++;
				}
				
				else if (e.X < RMBClickCoords.X) 
				{
					if (tempTrackingPoint.XyRadius-1>=projectSettings.minimumOrientPointRadius)
						tempTrackingPoint.XyRadius--;
				}
				RMBClickCoords.X=e.X;
				
				tForm.xyRadL.Text=Convert.ToString(tempTrackingPoint.XyRadius);
				viewportXY.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportXY.GetFrame(true),BaseTypes.viewport.TopLeft));

			}  
		}

		private void XYpointEndResize(object sender, MouseEventArgs e)
		{
			RMBDown=false;
		}
		private void XZpointResize(object sender, MouseEventArgs e)
		{
			if (RMBDown && addingPoint)
			{
				if (e.X > RMBClickCoords.X)
				{
					if (tempTrackingPoint.XzRadius+1<=projectSettings.maximumOrientPointRadius)
						tempTrackingPoint.XzRadius++;
				}
				else if (e.X < RMBClickCoords.X) 
				{
					if (tempTrackingPoint.XzRadius-1>=projectSettings.minimumOrientPointRadius)
						tempTrackingPoint.XzRadius--;
				}

				RMBClickCoords.X=e.X;
				
				tForm.xzRadL.Text=Convert.ToString(tempTrackingPoint.XzRadius);
				viewportXZ.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportXZ.GetFrame(true),BaseTypes.viewport.TopRight));
			}
		}

		private void XZpointEndResize(object sender, MouseEventArgs e)
		{
			RMBDown=false;
		}

		private void YZpointResize(object sender, MouseEventArgs e)
		{
			if (RMBDown && addingPoint)
			{
				if (e.X > RMBClickCoords.X)
				{
					if (tempTrackingPoint.YzRadius+1<=projectSettings.maximumOrientPointRadius)
						tempTrackingPoint.YzRadius++;
				}
				else if (e.X < RMBClickCoords.X) 
				{
					if (tempTrackingPoint.YzRadius-1>=projectSettings.minimumOrientPointRadius)
						tempTrackingPoint.YzRadius--;
				}

				RMBClickCoords.X=e.X;
				
				tForm.yzRadL.Text=Convert.ToString(tempTrackingPoint.YzRadius);
				viewportYZ.UpdateDisplay(tempTrackingPoint.visualizePoint(viewportYZ.GetFrame(true),BaseTypes.viewport.BottomLeft));

			}
			           
		}

		private void YZpointEndResize(object sender, MouseEventArgs e)
		{
			RMBDown=false;
		}

		//handles main window resizing
        private void mainForm_SizeChanged(object sender, System.EventArgs e)
		{
            mainFrame.Width=this.Width-185;
            mainFrame.Height=this.Height-115;
            messagesLB.Left=167;
            messagesLB.Top = this.Height - 103;
            messagesLB.Width=this.Width-187;
		}

		//following three proc's are invoked when one of viewports is resized
		private void vprtXY_Rsz(object sender, System.EventArgs e)
		{	
			AlignViewports();
		}

		private void vprtXZ_Rsz(object sender, System.EventArgs e)
		{
			AlignViewports();
		}

		private void vprtYZ_Rsz(object sender, System.EventArgs e)
		{
			AlignViewports();
		}

		//handles resizing viewports frame
        private void mainFrame_Resize(object sender, System.EventArgs e)
        {

            toolBoxP.Height = this.Height - 71;
            masterControlPanelP.Left = 5;
            masterControlPanelP.Top = mainFrame.Height - 25;
            masterControlPanelP.Width = mainFrame.Width - 11;
        }

		private void definedPointsGB_Resize(object sender, System.EventArgs e)
		{
            trackingPointsLB.Height=definedPointsGB.Height-15;
		}
        
        private void toolBoxP_Resize(object sender, System.EventArgs e)
		{
            version.Top=toolBoxP.Height-13;
            definedPointsGB.Height=toolBoxP.Height-407;
		}
		//handles resizing master control panel
		
        private void masterControlPanelP_Resize(object sender, System.EventArgs e)
		{
            masterControlPanelDisplayTB.Width=masterControlPanelP.Width-(masterControlPanelDisplayTB.Left+3);
		}

		//handles finalizing of adding point
		private void trackingPointPropertiesClosingHandler(object sender, CancelEventArgs e)
		{
			if (tForm.DialogResult==System.Windows.Forms.DialogResult.OK)
			{
				Message("New tracking point created");

				tempTrackingPoint.initPointBitmaps(viewportXY.GetFrame(true), viewportXZ.GetFrame(true), viewportYZ.GetFrame(true));
				
				trackingPoints.Add(new trackingPoint(tForm.pointNameTB.Text,tempTrackingPoint, tForm.color));
             

				BaseTypes.trackingPointLite temp = new BaseTypes.trackingPointLite(tForm.pointNameTB.Text,tempTrackingPoint.XyCoordX,
					tempTrackingPoint.XyCoordY,tempTrackingPoint.XzCoordX,tempTrackingPoint.XzCoordZ,tempTrackingPoint.YzCoordY,
					tempTrackingPoint.YzCoordZ,tempTrackingPoint.XyRadius,tempTrackingPoint.XzRadius,tempTrackingPoint.YzRadius,tForm.color);
				
				if (trackingPointsBasicInfo==null) trackingPointsBasicInfo = new ArrayList();
				if (temp!=null)
					trackingPointsBasicInfo.Add(temp);
					

				addingPoint=false;
           
				trackingPointsLB.Items.Clear();

				foreach (trackingPoint tp in trackingPoints)
					trackingPointsLB.Items.Add(tp.PName);	
				visualizePoints();
				projectSaved=false;
				app_status.SetStatus(_app_status.points_defined);
			} 
			else //tForm.DialogResult == Cancel...
			{
				Message("Creating tracking point cancelled");
				visualizePoints();
				addingPoint=false;
			}
		}

		private void trackingPointPropertiesUpdateClosingHandler(object sender, CancelEventArgs e)
		{
			if (tForm.DialogResult==System.Windows.Forms.DialogResult.OK)
			{
				Message("Tracking point updated");

				tempTrackingPoint.initPointBitmaps(viewportXY.GetFrame(true), viewportXZ.GetFrame(true), viewportYZ.GetFrame(true));
				
				for (int i=0; i<=trackingPoints.Count; i++)

					if (((trackingPoint)trackingPoints[i]).PName==oldPointName)
					{
						trackingPoints.RemoveAt(i);
						break;
					}

				for (int i=0; i<=trackingPointsBasicInfo.Count; i++)

					if (((BaseTypes.trackingPointLite)trackingPointsBasicInfo[i]).pName==oldPointName)
					{
						trackingPointsBasicInfo.RemoveAt(i);
						break;
					}
					
				trackingPoints.Add(new trackingPoint(tForm.pointNameTB.Text,tempTrackingPoint, tForm.color));
				
				
				BaseTypes.trackingPointLite temp = new BaseTypes.trackingPointLite(tForm.pointNameTB.Text,tempTrackingPoint.XyCoordX,
					tempTrackingPoint.XyCoordY,tempTrackingPoint.XzCoordX,tempTrackingPoint.XzCoordZ,tempTrackingPoint.YzCoordY,
					tempTrackingPoint.YzCoordZ,tempTrackingPoint.XyRadius,tempTrackingPoint.XzRadius,tempTrackingPoint.YzRadius,tForm.color);
				
				if (trackingPointsBasicInfo==null) trackingPointsBasicInfo = new ArrayList();
				if (temp!=null) trackingPointsBasicInfo.Add(temp);
					

				addingPoint=false;
           
				trackingPointsLB.Items.Clear();

				foreach (trackingPoint tp in trackingPoints)
					trackingPointsLB.Items.Add(tp.PName);	
				visualizePoints();
				projectSaved=false;
				app_status.SetStatus(_app_status.points_defined);
			} 
			else 
			{
				Message("Updating tracking point cancelled");
				visualizePoints();
				addingPoint=false;
			}
		}

		private void frameTrackingCompletedHandler(trackingPoint sender)
		{
           // try
         //   {
                Message(sender.PName + " tracking for current frame completed");
                totalTrackingPoints--;

                tf.AddPoint(new BaseTypes.trackingPointLite(sender.PName, sender.XyCoordX, sender.XyCoordY, sender.XzCoordX, sender.XzCoordZ, sender.YzCoordY, sender.YzCoordZ,
                    sender.XyRadius, sender.XzRadius, sender.YzRadius, sender.PColor));



                if (totalTrackingPoints == 0)
                    processFrame(projectSettings.frameIterator);
                projectSaved = false;
        //    }
         //   catch (InvalidOperationException)
         //   {
            //    MessageBox.Show("Application internal error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

		}

		

	}

	

	//application flow control...
	public enum _app_status {started = 1, project_active = 2, viewports_ready = 3, distance_calibrated = 4, points_defined = 5, points_trained = 6, tracking = 7,tracking_completed = 8};
	
	public class app_status
	{
		private static _app_status applicationStatus=_app_status.started;

		public app_status()
		{
		
		}

		public static _app_status GetStatus()
		{
			return applicationStatus;
		}

		public static bool SetStatus(_app_status appStatus)
		{
			if ((appStatus==applicationStatus+1) || (appStatus<applicationStatus))
			{
				
				applicationStatus=appStatus;
			//	MessageBox.Show("Setting status: "+Convert.ToString(app_status.GetStatus()),"Status changed",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return true;
			} 
			else return false;

		}

		public static void ResetStatus()
		{
			applicationStatus=_app_status.started;
		}
		
	
	}
}

