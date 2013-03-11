using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms; 
using System.Threading;

namespace FinalApp1
{
	/// <summary>
	/// Base class for tracking point...
	/// </summary>
	

	public class trackingPoint
	{

		//Nested class performing point tracking as thread
		public class locatePointThread
		{
			// State information used in the task.
			BaseTypes.viewport vprt;
			Rectangle scanArea;
			Bitmap bmp;
			int acceptanceThreshold;
			int Radius;
			NeuralNetwork Ann;
			private locatePointThreadCallback callback;


			// The constructor obtains the state information.
			public locatePointThread( BaseTypes.viewport Vprt,Rectangle ScanArea,Bitmap Bmp,int AcceptanceThreshold,int radius, NeuralNetwork aan, locatePointThreadCallback callbackDelegate) 
			{
				this.vprt = Vprt;
				this.scanArea = ScanArea;
				this.bmp = Bmp;
				this.acceptanceThreshold = AcceptanceThreshold;
				this.Radius=radius;
				this.Ann=aan;
				callback = callbackDelegate;
			}
           
			// The thread procedure performs the task
			public void ThreadProc() 
			{
				ArrayList pointsFound = new ArrayList();
				Point TL = new Point(0,0);
				Point BR = new Point(0,0);
			
				Rectangle crop;
				double[] answer=new double[4];
				double[] answerYes=new double[4]{1,1,1,1};
				double threshold=acceptanceThreshold;
				threshold/=100;
				int xAvg=0,yAvg=0;
			
				for (int i=scanArea.Left; i<scanArea.Width-(Radius*2); i++)
				{
					for (int j=scanArea.Top;j<scanArea.Height-(Radius*2); j++) 
					{

						TL.X=scanArea.Left+((i+1)-scanArea.Left);
						TL.Y=scanArea.Top+((j+1)-scanArea.Top);
						BR.X=Radius*2;
						BR.Y=Radius*2;
						crop=new Rectangle(TL.X,TL.Y,BR.X,BR.Y);
						ByteVector tempByteVector= new ByteVector(BitmapFilters.CropBitmap(bmp,crop));
					
						answer=Ann.Calculate(tempByteVector.GetDoubleVector());
						
					
						if
							(
							(answer[0]>answerYes[0]*threshold) &&
							(answer[1]>answerYes[1]*threshold) &&
							(answer[2]>answerYes[2]*threshold) &&
							(answer[3]>answerYes[3]*threshold) 
							)
					
						{
					
							pointsFound.Add(new Point(crop.X+Radius, crop.Y+Radius));
							break;
						}

					}
		
				}
				bool tracked=true;
			
				if (pointsFound.Count>0)
				{
				
					foreach (Point pt in pointsFound)
					{
						xAvg+=pt.X;
						yAvg+=pt.Y;
					}

					xAvg=(int)(xAvg/pointsFound.Count);
					yAvg=(int)(yAvg/pointsFound.Count);

				} 
				else 
				{
					 MessageBox.Show("Alert! Point not found!!! Viewport: " + Convert.ToString(this.vprt),"Point tracking failed!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                      xAvg=(int)(scanArea.Left);
                      yAvg=(int)(scanArea.Top);
					  tracked=false;
					  
				}
				if (callback != null)
					callback(xAvg, yAvg,vprt,tracked);


			}
	
		}


        //delegate used to pass result from class above
		public delegate void locatePointThreadCallback(int xAvg, int yAvg, BaseTypes.viewport vprt, bool tracked);
        
		//delegate to handle an event of processing points in all viewports
		public delegate void FrameProcessedEventHandler(trackingPoint sender);
		
		//vector used to store training data for ann training purposes
		private  ArrayList trainingSet;

		private bool Trained=false;
		public bool isTrained
		{
			get 
			{
				return Trained;
			}
			set
			{
			}
		}


		//indicates, how many viewports are not processed yet (tracked)
		private  int leftToProcess=3;
        
		//indicates in which viewport application failed to track point
		BaseTypes.viewport vprtNotTracked;

		//used for visualization purposes 
		Graphics gr;

		//stores poin name (followed by property)
		private string pName;
		public string PName
		{
			get
			{
				return pName;
			}
			set
			{
				pName=value;
			}
		}
		

		//stores color of tracking point (to implement)
		private System.Drawing.Color pColor;
		public System.Drawing.Color PColor
		{
			get
			{
				return pColor;
			}
			set
			{
			}
		}

        //coordinates of tracking point in each viewport (followed by properties)
		private int xyCoordX;
		public int XyCoordX
		{	 
			get 
			{
				return xyCoordX; 
			}
			set 
			{
						  
			}	
		}

		private int xyCoordY;
		public int XyCoordY
		{	 
			get 
			{
				return xyCoordY; 
			}
			set 
			{
						  
			}	
		}

		private int xzCoordX;
		public int XzCoordX
		{	 
			get 
			{
				return xzCoordX; 
			}
			set 
			{
						  
			}	
		}

		private int xzCoordZ;
		public int XzCoordZ
		{	 
			get 
			{
				return xzCoordZ; 
			}
			set 
			{
						  
			}	
		}

		private int yzCoordY;
		public int YzCoordY
		{	 
			get 
			{
				return yzCoordY; 
			}
			set 
			{
						  
			}	
		}

		private int yzCoordZ;
		public int YzCoordZ
		{	 
			get 
			{
				return yzCoordZ; 
			}
			set 
			{
						  
			}	
		}


		//radius tracking point in each viewport (followed by properties)
		private int xyRadius;
		public int XyRadius
		{	 
			get 
			{
				return xyRadius; 
			}
			set 
			{
				xyRadius=value;		  
			}	
		}

		private int xzRadius;
		public int XzRadius
		{	 
			get 
			{
				return xzRadius; 
			}
			set 
			{
				xzRadius=value;		  
			}	
		}

		private int yzRadius;
		public int YzRadius
		{	 
			get 
			{
				return yzRadius; 
			}
			set 
			{
				yzRadius=value;		  
			}	
		}


		//world coordinates of point (esitmated on 3 viewports) (followed by properties)
		private int worldCoordX;
		public int WorldCoordX
		{	 
			get 
			{
				return worldCoordX; 
			}
			set 
			{
						  
			}	
		}
		private int worldCoordY;
		public int WorldCoordY
		{	 
			get 
			{
				return worldCoordY; 
			}
			set 
			{
						  
			}	
		}
		private int worldCoordZ;
		public int WorldCoordZ
		{	 
			get 
			{
				return worldCoordZ; 
			}
			set 
			{
						  
			}	
		}
        
		private int prevXYCoordX;
		private int prevXYCoordY;
		private int prevXZCoordX;
		private int prevXZCoordZ;
		private int prevYZCoordY;
		private int prevYZCoordZ;

		static private double DistanceQuotientXY=1;
		static private double DistanceQuotientXZ=1;
		static private double DistanceQuotientYZ=1;

		static public double distanceQuotientXY
		{
			get
			{
				return DistanceQuotientXY;
			}

			set
			{
				if (value>0) 
					DistanceQuotientXY=value;
			}
		}

		static public double distanceQuotientXZ
		{
			get
			{
				return DistanceQuotientXZ;
			}

			set
			{
				if (value>0) 
					DistanceQuotientXZ=value;
			}
		}
		static public double distanceQuotientYZ
		{
			get
			{
				return DistanceQuotientYZ;
			}

			set
			{
				if (value>0) 
					DistanceQuotientYZ=value;
			}
		}

	    //stores image of tracking point for training purposes
		private Bitmap xyTrackPointImage;
		private Bitmap xzTrackPointImage;
		private Bitmap yzTrackPointImage;
		
		//neural network object for each viewport
		private NeuralNetwork xyAnn;
		private NeuralNetwork xzAnn;
		private NeuralNetwork yzAnn;

		//byte vector for each viewport (training purposes)
		private ByteVector xyVector;
		private ByteVector xzVector;
		private ByteVector yzVector;
		
		//constructors
		public trackingPoint(string name, int defaultRadius, Color col)
		{
			xyCoordX=defaultRadius;
			xyCoordY=defaultRadius;
			xzCoordX=defaultRadius;
			xzCoordZ=defaultRadius;
			yzCoordY=defaultRadius;
			yzCoordZ=defaultRadius;

			xyRadius=defaultRadius;
			xzRadius=defaultRadius;
			yzRadius=defaultRadius;

			calculateWorldCoords();
            
			pColor=col;
			pName=name;		
		}

		public trackingPoint(string name, int xyCoordX, int xyCoordY, int xzCoordX, int xzCoordZ, int yzCoordY, int yzCoordZ, int xyRadius, int xzRadius, int yzRadius, Color col)
		{
			this.xyCoordX=xyCoordX;
			this.xyCoordY=xyCoordY;
			this.xzCoordX=xzCoordX;
			this.xzCoordZ=xzCoordZ;
			this.yzCoordY=yzCoordY;
			this.yzCoordZ=yzCoordZ;

			this.xyRadius=xyRadius;
			this.xzRadius=xzRadius;
			this.yzRadius=yzRadius;

			calculateWorldCoords();
            
			this.pColor=col;
			this.pName=name;	
		}

		public trackingPoint(string name, trackingPoint tp, Color col)
		{  
			this.pColor = tp.pColor;
			this.xyAnn = tp.xyAnn;
			this.xyCoordX=tp.xyCoordX;
			this.xyCoordY=tp.XyCoordY;
			this.xyRadius=tp.xyRadius;
			this.xyTrackPointImage=tp.xyTrackPointImage;

			this.xzAnn = tp.xzAnn;
			this.xzCoordX=tp.xzCoordX;
			this.xzCoordZ=tp.xzCoordZ;
			this.xzRadius=tp.xzRadius;
			this.xzTrackPointImage=tp.xzTrackPointImage;

			this.yzAnn = tp.yzAnn;
			this.yzCoordZ=tp.yzCoordZ;
			this.yzCoordY=tp.yzCoordY;
			this.yzRadius=tp.yzRadius;
			this.yzTrackPointImage=tp.yzTrackPointImage;

			this.calculateWorldCoords();
			 
			this.pColor=col;
			this.pName=name;

		}

		
		//explicit mngmt of tracking point coords in each viewport (calls worldCoord recalculation)
		public void setXYCoords(int xCoord,int yCoord)
		{
			xyCoordX=xCoord;
			xyCoordY=yCoord;
			calculateWorldCoords();
		}
		public void setXZCoords(int xCoord,int zCoord)
		{
			xzCoordX=xCoord;
			xzCoordZ=zCoord;
			calculateWorldCoords();
		}
		public void setYZCoords(int yCoord, int zCoord)
		{
			yzCoordY=yCoord;
			yzCoordZ=zCoord;
			calculateWorldCoords();
		}


		//initialize track point images for each viewport
		public void initPointBitmaps(Bitmap TL, Bitmap TR, Bitmap BL)
		{
			
			
			Rectangle crop = new Rectangle(xyCoordX-xyRadius,xyCoordY-xyRadius,xyRadius*2,xyRadius*2);
			xyTrackPointImage = new Bitmap(BitmapFilters.CropBitmap(TL,crop));

			crop = new Rectangle(xzCoordX-xzRadius,xzCoordZ-xzRadius,xzRadius*2,xzRadius*2);
			xzTrackPointImage=new Bitmap(BitmapFilters.CropBitmap(TR,crop));
        
			crop = new Rectangle(yzCoordY-yzRadius,yzCoordZ-yzRadius,yzRadius*2,yzRadius*2);
			yzTrackPointImage=new Bitmap(BitmapFilters.CropBitmap(BL,crop));;

			
		}

		
		//visualization function
		public Bitmap visualizePoint(Bitmap inputPicture, BaseTypes.viewport vprt)
		{

			//bledne paramtery sa--> nie wiadomo dlaczego!!
			int x1, y1, x2, y2;
			
			switch (vprt)
			{
                 
				case  BaseTypes.viewport.TopLeft:
				{
					x1 = xyCoordX-xyRadius;
					y1 = xyCoordY-xyRadius;
					x2 = xyRadius * 2;
					y2 = xyRadius * 2;
					break;
				}

      
				case  BaseTypes.viewport.TopRight:
				{
					x1 = xzCoordX-xzRadius;
					y1 = xzCoordZ-xzRadius;
					x2 = xzRadius * 2;
					y2 = xzRadius * 2;
					break;
				}

       
				case  BaseTypes.viewport.BottomLeft:
				{
					x1 = yzCoordY-yzRadius;
					y1 = yzCoordZ-yzRadius;
					x2 = yzRadius * 2;
					y2 = yzRadius * 2;
					break;
				}
				default :
				{
					x1 = xyCoordX-xyRadius;
					y1 = xyCoordY-xyRadius;
					x2 = xyRadius * 2;
					y2 = xyRadius * 2;
					break;
				}
			}

			gr = Graphics.FromImage(inputPicture);
			Pen pen = new System.Drawing.Pen(pColor);
    
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			Rectangle tRect = new Rectangle(x1,y1,x2,y2);

			gr.DrawRectangle(pen,tRect);
			gr.FillRectangle(new SolidBrush(Color.FromArgb(30, 255, 255, 255)), tRect);
			    
			gr.DrawLine(pen,x1,y1,x1+x2,y1+y2);
			gr.DrawLine(pen,x1+x2,y1,x1,y1+y2);
			gr.DrawLine(pen,x1+(int)(x2/2),y1+(int)(y2/2),x1+x2+5,y1+(int)(y2/2));
			
			StringFormat sf=(StringFormat)StringFormat.GenericTypographic.Clone();

			sf.Alignment=StringAlignment.Near;
			sf.LineAlignment=StringAlignment.Near;

			gr.DrawString(pName,new Font("Silkscreen",5,GraphicsUnit.Point),Brushes.Orange,new Rectangle(x1,y1-10,100,y1),sf);
			gr.DrawString("Px#: \n"+Convert.ToString(x2*y2),new Font("Silkscreen",5,GraphicsUnit.Point),Brushes.Orange,new Rectangle(x1,y1+y2,60,y1+y2+10),sf);
			gr.DrawString("x: "+Convert.ToString(x1+(int)(x2/2))+"\n"+"y: "+Convert.ToString(y1+(int)(y2/2)),new Font("Silkscreen",5,GraphicsUnit.Point),Brushes.Orange,new Rectangle(x1+x2+6,y1+(int)(y2/2)-5,60,y1+(int)(y2/2)+5),sf);

			gr.Dispose();

			return inputPicture;
		}

		
		//calculate world coordinates based on coordinates from each viewport
		protected void calculateWorldCoords()
		{
			worldCoordX=(int)(xyCoordX+xzCoordX)/2;
			worldCoordY=(int)(xyCoordY+yzCoordY)/2;
			worldCoordZ=(int)(xzCoordZ+yzCoordZ)/2;
		}
	    

		//train neural networks with given tracking point images
		public void initAndTrainANN(int trainingIterationsCount, double trainingRate, int outputVectorSize,
									int hiddenLayersCount, int hiddenLayersSize, int minimumWeight, int maximumWeight, 
									Bitmap xy1stFrame, Bitmap xz1stFrame, Bitmap yz1stFrame)
		{
			
			//define and initialize activationFunction for Ann's
			iActivationFunction activationFunction = new LogisticCurve();

			

			//generate ByteVectors for each viewport
			xyVector=new ByteVector(xyTrackPointImage);
			xzVector=new ByteVector(xzTrackPointImage);
			yzVector=new ByteVector(yzTrackPointImage);

            //train points in each viewport (to be threaded ;))
			trainPoint(BaseTypes.viewport.XY,xy1stFrame,ref xyAnn,
				hiddenLayersSize, outputVectorSize, hiddenLayersCount, 
				activationFunction, trainingRate, trainingIterationsCount,
				minimumWeight, maximumWeight);
			
			trainPoint(BaseTypes.viewport.XZ,xy1stFrame,ref xzAnn,
				hiddenLayersSize, outputVectorSize, hiddenLayersCount, 
				activationFunction, trainingRate, trainingIterationsCount,
				minimumWeight, maximumWeight);

			trainPoint(BaseTypes.viewport.YZ,xy1stFrame,ref yzAnn,
				hiddenLayersSize, outputVectorSize, hiddenLayersCount, 
				activationFunction, trainingRate, trainingIterationsCount,
				minimumWeight, maximumWeight);

			Trained=true;

		}

	
		//train single neural network with given training set and parameters
		private void trainNetwork(ArrayList trainingSet, ref NeuralNetwork Ann, double trainingRate, int trainingIterationsCount)
		{
			//set answers
			double[] answerYes=new double[4]{1,1,1,1};
			double[] answerNo=new double[4]{0,0,0,0};
			
			int Iteration;
			int index;

			Random R = new Random();
			
			for (Iteration=0; Iteration<trainingIterationsCount; Iteration++)
			{
				//random-pick training set index
				index=(int)Math.Round((R.NextDouble() * ((32-1)-1)));
				
				//get tranining sample from training set
				double[] a = (double[])trainingSet[index];

				//train network with set 
				if (index>15)
					Ann.TrainNetwork(answerYes,a,trainingRate);
				else 
					Ann.TrainNetwork(answerNo,a,trainingRate);
			}

		}
	

		//generate training set for given viewport (training purposes)
		private ArrayList generateTrainingSet(BaseTypes.viewport vprt, Bitmap bmp)
		{
			int smallShift; 
			int largeShift;
			int CoordX,CoordY, Radius = 0,Width,Height;
			Point TL = new Point(0,0);
			double[] temporaryDoubleVector; //training set element
			ByteVector temporaryByteVector; //reqd to obtain double vector
			ArrayList trainingSet=new ArrayList();
			Rectangle crop;

			switch (vprt)
			{
				case BaseTypes.viewport.XY:
				{
					smallShift=xyRadius+(int)(0.5*xyRadius);
					largeShift=xyRadius*2;//+(int)(0.5*xyRadius);
					CoordX=xyCoordX;
					CoordY=xyCoordY;
					Radius=xyRadius;
		
					break;
				}

				case BaseTypes.viewport.XZ:
				{
					smallShift=xzRadius+(int)(0.5*xzRadius);
					largeShift=xzRadius*2;//+(int)(0.5*xzRadius);
					CoordX=xzCoordX;
					CoordY=xzCoordZ;
					Radius=xzRadius;

					break;
				}

				case BaseTypes.viewport.YZ:
				{
					smallShift=yzRadius+(int)(0.5*yzRadius);
					largeShift=yzRadius*2;//+(int)(0.5*yzRadius);
					CoordX=yzCoordY;
					CoordY=yzCoordZ;
					Radius=yzRadius;

					break;
				}
				default :
				{
					smallShift=xyRadius+(int)(0.5*xyRadius);
					largeShift=xyRadius*2;//+(int)(0.5*xyRadius);
					CoordX=xyCoordX;
					CoordY=xyCoordY;
					Radius=xyRadius;
					break;
				}
			}
			
			smallShift=Radius; 
			largeShift=Radius+(int)(0.5*xyRadius);
			Width=Height=Radius*2;

			//add sixteen wrong answers (image shifted by 50% and 75%)
			for (int x=-1; x<2; x++)
				for (int y=-1; y<2; y++)
				{ 
					if (!((x==0) && (y==0))) //To bylaby poprawna dana
					{	
						int a = (int)x*(int)smallShift;
						TL.X=(CoordX-Radius)+a;
					
						a =(int)y*(int)smallShift;
						TL.Y=(CoordY-Radius)+a;
						
						crop = new Rectangle(TL.X,TL.Y,Width,Height);
						temporaryByteVector=new ByteVector(BitmapFilters.CropBitmap(bmp, crop));
						temporaryDoubleVector=temporaryByteVector.GetDoubleVector();
						trainingSet.Add(temporaryDoubleVector);
						
						a = (int)x*(int)largeShift;
						TL.X=(CoordX-Radius)+a;
						
						a =(int)y*(int)largeShift;
						TL.Y=(CoordY-Radius)+a;
						
						crop = new Rectangle(TL.X,TL.Y,Width,Height);
						temporaryByteVector=new ByteVector(BitmapFilters.CropBitmap(bmp, crop));
						temporaryDoubleVector=temporaryByteVector.GetDoubleVector();
						trainingSet.Add(temporaryDoubleVector);
					}
				}
           
			//the following code caused not really good results during precise tracking, but still helps
			//add eight correct answers (genuine image shifted by 1) 
			for (int x=-1; x<2; x++)
				for (int y=-1; y<2; y++)
				{ 
					if (!((x==0) && (y==0))) //To bylaby poprawna dana
					{	
						int a = (int)x*(int)1;
						TL.X=(CoordX-Radius)+a;
						
						a =(int)y*(int)1;
						TL.Y=(CoordY-Radius)+a;
						
						crop = new Rectangle(TL.X,TL.Y,Width,Height);
						temporaryByteVector=new ByteVector(BitmapFilters.CropBitmap(bmp, crop));
						temporaryDoubleVector=temporaryByteVector.GetDoubleVector();
						trainingSet.Add(temporaryDoubleVector);
					}
				}
             
			//add eight answer vectors from genuine image
			for (int x=0; x<8; x++)
			{
				crop = new Rectangle((CoordX-Radius),(CoordY-Radius),Width,Height);
				temporaryByteVector=new ByteVector(BitmapFilters.CropBitmap(bmp, crop));
				temporaryDoubleVector=temporaryByteVector.GetDoubleVector();
				trainingSet.Add(temporaryDoubleVector);
			}

			return trainingSet;
		}


        //train point in certain viewport (generate training set and train neural network)
		private void trainPoint(BaseTypes.viewport vprt,Bitmap bmp, ref NeuralNetwork Ann, int hls, int ovs, int hlc, iActivationFunction af, double tr, int tic, int miw, int maw)
		{
			trainingSet=new ArrayList(); 

			switch (vprt)
			{

				case BaseTypes.viewport.XY:
				{
					trainingSet=(ArrayList)(generateTrainingSet(BaseTypes.viewport.XY,bmp).Clone());
					//create new neural network object
					Ann =  new NeuralNetwork((int)Math.Pow((xyRadius*2),2),hls, ovs,hlc,af);
					//initialize weights
					Ann.DrawWeights(miw, maw);
					//train network
					trainNetwork(trainingSet,ref Ann,tr,tic);
					break;
				}
				case BaseTypes.viewport.XZ:
				{
					trainingSet=(ArrayList)(generateTrainingSet(BaseTypes.viewport.XZ,bmp).Clone());
					//create new neural network object
					Ann =  new NeuralNetwork((int)Math.Pow((xzRadius*2),2),hls, ovs,hlc,af);
					//initialize weights
					Ann.DrawWeights(miw, maw);
					//train network
					trainNetwork(trainingSet,ref Ann,tr,tic);
					break;
				}
				case BaseTypes.viewport.YZ:
				{
					trainingSet=(ArrayList)(generateTrainingSet(BaseTypes.viewport.YZ,bmp).Clone());
					//create new neural network object
					Ann =  new NeuralNetwork((int)Math.Pow((yzRadius*2),2),hls, ovs,hlc,af);
					//initialize weights
					Ann.DrawWeights(miw, maw);
					//train network
					trainNetwork(trainingSet,ref Ann,tr,tic);
					break;
				}
			}
		}
	

        //updates point coordinates for given frames, and with given acceptance threshold and presumed position offset
		public void trackPoint(Bitmap xyFrame, Bitmap xzFrame, Bitmap yzFrame, int acceptanceThreshold, int lastPositionOffset)
		{
            vprtNotTracked=BaseTypes.viewport.None;
			prevXYCoordX=xyCoordX;
			prevXYCoordY=xyCoordY;
			prevXZCoordX=xzCoordX;
			prevXZCoordZ=xzCoordZ;
			prevYZCoordY=yzCoordY;
			prevYZCoordZ=yzCoordZ;
			
			Rectangle xyArea, xzArea, yzArea;
			
			xyArea = new Rectangle(xyCoordX - lastPositionOffset, xyCoordY-lastPositionOffset, xyCoordX+(2*xyRadius)+lastPositionOffset, xyCoordY+(2*xyRadius)+lastPositionOffset);
			xzArea = new Rectangle(xzCoordX - lastPositionOffset, xzCoordZ-lastPositionOffset, xzCoordX+(2*xzRadius)+lastPositionOffset, xzCoordZ+(2*xzRadius)+lastPositionOffset);
			yzArea = new Rectangle(yzCoordY - lastPositionOffset, yzCoordZ-lastPositionOffset, yzCoordY+(2*yzRadius)+lastPositionOffset, yzCoordZ+(2*yzRadius)+lastPositionOffset);
		
			locatePointThread lptXY = new locatePointThread(BaseTypes.viewport.XY,
			xyArea,xyFrame,acceptanceThreshold,xyRadius,xyAnn,new locatePointThreadCallback(locatePointThreadCallbackResult));
			
			locatePointThread lptXZ = new locatePointThread(BaseTypes.viewport.XZ,
			xzArea,xzFrame,acceptanceThreshold,xzRadius,xzAnn,new locatePointThreadCallback(locatePointThreadCallbackResult));
			
			locatePointThread lptYZ = new locatePointThread(BaseTypes.viewport.YZ,
				yzArea,yzFrame,acceptanceThreshold,yzRadius,yzAnn,new locatePointThreadCallback(locatePointThreadCallbackResult));

			Thread xyTrackingThread = new Thread(new ThreadStart(lptXY.ThreadProc));
			Thread xzTrackingThread = new Thread(new ThreadStart(lptXZ.ThreadProc));
			Thread yzTrackingThread = new Thread(new ThreadStart(lptYZ.ThreadProc));
			
			xyTrackingThread.Start();
			xzTrackingThread.Start();
			yzTrackingThread.Start();

			calculateWorldCoords();
	}
	    
		
		//event raising procedure
		protected virtual void OnFrameProcessed()
		{
			
			//raise event, when all three points are tracked
			if(FrameProcessed != null)
			{
			    leftToProcess=3;
				FrameProcessed(this);
			}
		}
		

		//event (raised, if all three viewports have points tracked) 
		public event FrameProcessedEventHandler FrameProcessed;
		
		//callback procedure used to retrieve results from tracking thread
		public void locatePointThreadCallbackResult(int xA, int yA, BaseTypes.viewport vPrt, bool tracked) 
		{
			if (!tracked) vprtNotTracked=vPrt;

			switch (vPrt)
			{
				case BaseTypes.viewport.XY:
				{
					this.xyCoordX=xA;
					this.xyCoordY=yA;
					break;
				}
				case BaseTypes.viewport.XZ:
				{
					this.xzCoordX=xA;
					this.xzCoordZ=yA;
					break;
				}
				case BaseTypes.viewport.YZ:
				{
					this.yzCoordY=xA;
					this.yzCoordZ=yA;
					break;
				}

			}
			leftToProcess--;
			
			if (leftToProcess==0)
			{
				if (vprtNotTracked!=BaseTypes.viewport.None)
				{
					//locating missing point, using data from other viewports
					switch (vprtNotTracked)
					{

						case BaseTypes.viewport.XY:
						{
							this.xyCoordX=
						(int)((trackingPoint.DistanceQuotientXY*(this.xzCoordX - prevXZCoordX))/trackingPoint.DistanceQuotientXZ); 
							
							this.xyCoordY=
						(int)((trackingPoint.DistanceQuotientXY*(this.yzCoordY - prevYZCoordY))/trackingPoint.DistanceQuotientYZ); 		
								
							break;
						}

						case BaseTypes.viewport.XZ:
						{
							this.xzCoordX=
						(int)((trackingPoint.DistanceQuotientXZ*(this.xyCoordX - prevXYCoordX))/trackingPoint.DistanceQuotientXY); 
							
							this.xzCoordZ=
						(int)((trackingPoint.DistanceQuotientXZ*(this.yzCoordZ - prevYZCoordZ))/trackingPoint.DistanceQuotientYZ); 		
							break;
						}
						case BaseTypes.viewport.YZ:
						{
							this.yzCoordY=
						(int)((trackingPoint.DistanceQuotientYZ*(this.xyCoordY - prevXYCoordY))/trackingPoint.DistanceQuotientXY); 
								
							this.yzCoordZ=
						(int)((trackingPoint.DistanceQuotientYZ*(this.xzCoordZ - prevXZCoordZ))/trackingPoint.DistanceQuotientXZ); 
							break;
						}

					}
                   


				}
	 
				 
				 
				OnFrameProcessed();
			}
		}
	}
}


