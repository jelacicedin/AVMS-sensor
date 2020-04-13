using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;


using ICPLib;

namespace UnitTestsOpenTK
{
    [TestFixture]
    [Category("UnitTest")]
    public class KDTreeTest_ICP : TestBaseICP
    {

        public KDTreeTest_ICP()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "TestData";
           
        }


        [Test]
        public void Cube_RotateScaleTranslate_KDTree_Stark()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Stark;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleUniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);
            
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_RotateScaleTranslate_KDTreeBruteForce()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.BruteForce;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleUniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);
            //
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
   
   
    }
}
