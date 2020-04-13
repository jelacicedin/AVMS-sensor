using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using ICPLib;
using UnitTestsOpenTK;


namespace UnitTestsOpenTK
{
  

    public class TestBaseICP : TestBase
    {
         
        protected double meanDistance;

        protected IterativeClosestPointTransform icpInstance = new IterativeClosestPointTransform();

        public TestBaseICP()
         {
             path = AppDomain.CurrentDomain.BaseDirectory + "TestData";
          
         }

      
        protected void ShowResultsInWindow_CubeLines(bool changeColor)
        {

            //color code: 
            //Target is green
            //source : white
            //result : red

            //so - if there is nothing red on the OpenTK control, the result overlaps the target
            PointCloudVertices.SetColorOfListTo(pointCloudTarget, Color.Green);
            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.White);
            if (pointCloudResult != null)
            {
                PointCloudVertices.SetColorOfListTo(pointCloudResult, Color.Red);
                
            }
           

            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, changeColor);
            fOTK.ShowDialog();


        }
        
         protected void ResetICP()
         {
             
             ResetTest();
             icpInstance = new IterativeClosestPointTransform();
                        
             this.icpInstance.Reset();
         }
      
      
       

      
        protected void CheckResult_MeanDistance(double threshold)
         {
             Assert.IsTrue(meanDistance - threshold < 0);


         }
     
        protected void CheckResult_Vectors()
        {
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));
        }
        protected void CheckResult_VectorsUltra()
        {
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        //protected void SettingsRealData()
        //{
        //    icpInstance.ICPSettings.MaximumNumberOfIterations = 10;
        //    IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
        //    this.icpInstance.ICPSettings.Normal_RemovePoints = false;
        //    this.icpInstance.ICPSettings.Normal_SortPoints = false;

        //    this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
        //    this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
        //    IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;

            

        //}
        //protected void SettingsGeometricObjects()
        //{
        //    IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 5;
        //    IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
        //    this.icpInstance.ICPSettings.ResetVertexToOrigin = false;
        //    this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
        //    this.icpInstance.ICPSettings.Normal_RemovePoints = false;
        //}

    }
}
