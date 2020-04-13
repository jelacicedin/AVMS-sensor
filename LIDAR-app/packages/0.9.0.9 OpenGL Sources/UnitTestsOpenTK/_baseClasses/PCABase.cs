using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;


namespace UnitTestsOpenTK
{
     
    public class PCABase : TestBase
    {
        protected PCA pca;
       
        public PCABase()
        {
            pca = new PCA();
            UIMode = false;
        }
      
      

       
        protected void CheckResultTargetAndShow_Cube()
        {
            
            //-----------Show in Window
            if (UIMode)
            {
                this.ShowResultsInWindow_CubeNew(true, true);
                //this.pointCloudResult.ShowLinesConnectingPoints = true;
                //this.ShowResultsInWindow_Cube(true);
            }
            //----------------check Result
            Assert.IsTrue(CheckResult(pca.MeanDistance, 0, this.threshold));
           
        }

        protected void CheckResultTargetAndShow_Cloud(double threshold)
        {
            
           
            //-----------Show in Window
            if (UIMode)
            {
                
                ShowPointCloudsInWindow_PCAVectors(true);
            }
            //----------------check Result
            Assert.IsTrue(CheckResult(pca.MeanDistance, 0, threshold));
            
        }


        
    }
}
