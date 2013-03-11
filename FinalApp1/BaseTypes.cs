using System;
using System.IO;
using System.Security.Permissions;
using System.Collections;

namespace FinalApp1
{
	/// <summary>
	/// Stores various types used within application
	/// </summary>
	public class BaseTypes 
	{
		//enum type for identifying viewport position
		public enum viewport {None = 0, XY = 1, TopLeft =1, XZ = 2, TopRight=2, YZ = 3, BottomLeft = 3};

		//enum type for idetyfifying scaling performed on viewport video
		public enum scalingType {Native = 1, ScaleBy = 2, Custom = 3};
		

		//structure used for archiving point world coordinates in certain time
		[Serializable]
		public class timeFrame
		{


			//frame in which point was tracked
			public int frame;
		
			private ArrayList trackingPoints;

			public timeFrame(int frameNumber)
			{
			 trackingPoints=new ArrayList();
             frame = frameNumber;	  
			}

			public void AddPoint(trackingPointLite trackingPoint)
			{
             trackingPoints.Add(trackingPoint);
			}

			public trackingPointLite GetPoint(string pointName)
			{
				foreach (trackingPointLite tpl in trackingPoints)
				{
                  if (tpl.pName==pointName)
					  return tpl;
				}
				return new trackingPointLite();
			}

			public int count()
			{
             return trackingPoints.Count;
			}

			public trackingPointLite GetPoint (int index)
			{
				if (index>-1 && index<=count())
              return (trackingPointLite)trackingPoints[index];
				else return null;
			}
		}

		[Serializable]
			public class trackingPointLite
		{
			public int xyCoordX;
			public int xyCoordY;
			public int xzCoordX;
			public int xzCoordZ;
			public int yzCoordY;
			public int yzCoordZ;

			public int xyRadius;
			public int xzRadius;
			public int yzRadius;

			public int worldCoordX;
			public int worldCoordY;
			public int worldCoordZ;
	
			public System.Drawing.Color  pColor;
			public string pName;

			public trackingPointLite(string name, int xyCoordX, int xyCoordY, int xzCoordX, int xzCoordZ, int yzCoordY, int yzCoordZ, int xyRadius, int xzRadius, int yzRadius, System.Drawing.Color color)
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
				this.pName=name;
				this.pColor=color;
				this.calculateWorldCoords();
			}

			public trackingPointLite(trackingPointLite tp)
			{
				this.xyCoordX=tp.xyCoordX;
				this.xyCoordY=tp.xyCoordY;
				this.xzCoordX=tp.xzCoordX;
				this.xzCoordZ=tp.xzCoordZ;
				this.yzCoordY=tp.yzCoordY;
				this.yzCoordZ=tp.yzCoordZ;

				this.xyRadius=tp.xyRadius;
				this.xzRadius=tp.xzRadius;
				this.yzRadius=tp.yzRadius;
				this.pName=tp.pName;
				this.pColor=tp.pColor;
				this.calculateWorldCoords();
			}

			public trackingPointLite()
			{
			}
			
			protected void calculateWorldCoords()
			{
				worldCoordX=(int)(xyCoordX+xzCoordX)/2;
				worldCoordY=(int)(xyCoordY+yzCoordY)/2;
				worldCoordZ=(int)(xzCoordZ+yzCoordZ)/2;
			}
		}
		

		//class used for storing initial tracking points set and trackingMoments during tracking
		[Serializable]    
			public class trackingHistory

		{
			//project name to which this history should be attached
			public string projectName;   

			//base tracking points, defined in first frame 
			public ArrayList initialTrackingPointsSet;

			//parameters of points tracked in following frames
			public ArrayList trackingHistorySet;

			public int xyStartFrame, xzStartFrame,yzStartFrame;


			public trackingHistory()
			{
			}

			public trackingHistory(string ProjectName, ArrayList InitialTrackingPointSet, int xyStartFrame, int xzStartFrame, int yzStartFrame)
			{
				initialTrackingPointsSet = new ArrayList();
				initialTrackingPointsSet=(ArrayList)InitialTrackingPointSet.Clone();
				projectName = ProjectName;
				this.trackingHistorySet=new ArrayList();   
			}
			
			
			public void addTimeFrame(timeFrame TimeFrame)
			{
             trackingHistorySet.Add(TimeFrame);
			}

			public timeFrame getTimeFrame(int frameNumber)
			{
				foreach (timeFrame tf in trackingHistorySet)
				{
                    if (tf.frame==frameNumber) return tf;
				}
				return new timeFrame(1);


			}
		
		
		}
	


		//class used for storing project settings
		[Serializable] 
			public class Settings 
		{
			//project name
			public string projectName;

			//how many frames app should proceed forward after tracking current frame
			public int frameIterator;

			//default radius for new points
			public int defaultRadius;
		  
			//media file name for each viewport
			public string viewportXYFileName;
			public string viewportXZFileName;
			public string viewportYZFileName;

			public double viewportXY1pxDistance;
			public double viewportXZ1pxDistance;
			public double viewportYZ1pxDistance;
  
			//scaling type for each viewport
			public scalingType viewportXYScalingType;
			public scalingType viewportXZScalingType;
			public scalingType viewportYZScalingType;

            //scaling factor for each viewport (if scaling type == ScaleBy)
			public int viewportXYScalingFactor;
			public int viewportXZScalingFactor;
			public int viewportYZScalingFactor;
		
            //media dimensions for each viewport (if scaling type == Custom)
			public uint viewportXYHorizontalRes;
			public uint viewportXYVerticalRes;
			public uint viewportXZHorizontalRes;
			public uint viewportXZVerticalRes;
			public uint viewportYZHorizontalRes;
			public uint viewportYZVerticalRes;
	
			//post processing setting "greyscale" for each viewport
			public bool viewportXYGreyScale;		
			public bool viewportXZGreyScale;
			public bool viewportYZGreyScale;
			
			//contrast and brightness correction values for each viewport (PostProcessing)
			public int viewportXYContrastCorrectionValue;
			public int viewportXYBrightnessCorrectionValue;
			public int viewportXZContrastCorrectionValue;
			public int viewportXZBrightnessCorrectionValue;
			public int viewportYZContrastCorrectionValue;
			public int viewportYZBrightnessCorrectionValue;
		
			//start frame number for each viewport (from this frame tracking should start)
			public uint viewportXYStartFrame;
			public uint viewportXZStartFrame;
			public uint viewportYZStartFrame;

			//value indicating, how long ann's training should take
			public int neuralNetworkTrainingIterations;

			//max and min weights for ann's
			public int neuralNetworkMinimumWeight;
			public int neuralNetworkMaximumWeight;

			//value indicating, how rapid ann training should be
			public double neuralNetworkTrainingRate;

			//ann's hidden layers count and size 
			public int neuralNetworkHiddenLayersCount;
			public int neuralNetworkHiddenLayersSize;

            //defines minimum and maximum orient point size, that can be defined in app
			public int minimumOrientPointRadius;
			public int maximumOrientPointRadius;

			public int scanAreaOffset;
			public int preciseAcceptanceThreshold;
			public int fineAcceptanceThreshold;
			public int lowAcceptanceThreshold;

			public Settings()
			{

			}

		}

		
		
	
	}
}
		


