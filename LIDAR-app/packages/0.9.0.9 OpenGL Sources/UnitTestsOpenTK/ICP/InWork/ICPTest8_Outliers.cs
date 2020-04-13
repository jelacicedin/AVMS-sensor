using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using UnitTestsOpenTK;
using ICPLib;


namespace UnitTestsOpenTK.InWork
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest8_Outliers : TestBaseICP
    {

        [Test]
        public void Outliers_CubeTranslate_FixedPoints()
        {
            ResetICP();
            
            
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            //KDTreeVertex.KDTreeMode = KDTreeMode.Rednaxela;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;


            meanDistance = ICPTestData.Test8_CubeOutliers_Translate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            this.ShowResultsInWindow_CubeLines(false);

            
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Outliers_CubeTranslate_NotGood()
        {
            ResetICP();
           

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;

            meanDistance = ICPTestData.Test8_CubeOutliers_Translate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            this.ShowResultsInWindow_CubeLines(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Outliers_CubeTranslate_DistanceOptimization()
        {
            ResetICP();


            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;
            this.icpInstance.ICPSettings.DistanceOptimization = true;

            meanDistance = ICPTestData.Test8_CubeOutliers_Translate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            this.ShowResultsInWindow_CubeLines(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Outliers_CubeTranslate_NormalsCheck()
        {
            ResetICP();
            

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;
            this.icpInstance.ICPSettings.Normal_RemovePoints = true;

            meanDistance = ICPTestData.Test8_CubeOutliers_Translate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            this.ShowResultsInWindow_CubeLines(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));
            
        }
        [Test]
        public void Face_NormalsCheck()
        {
            ResetICP();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;
            this.icpInstance.ICPSettings.Normal_RemovePoints = true;

            meanDistance = ICPTestData.Test9_Face_Stitch(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Outliers_CubeRotate()
        {
            ResetICP();
      
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;
            this.icpInstance.ICPSettings.SimulatedAnnealing = true;



            meanDistance = ICPTestData.Test8_CubeOutliers_Rotate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 2e-1f));
           
        }
       
     
     
    }
}
