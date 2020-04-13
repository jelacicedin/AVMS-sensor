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
    public class ICPTest9_Face : TestBaseICP
    {
        
        [Test]
        public void Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 100;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
           

            meanDistance = ICPTestData.Test9_Face_Stitch(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
          [Test]
        public void Umeyama_SA()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.SimulatedAnnealing = true;


            meanDistance = ICPTestData.Test9_Face_Stitch(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
          
     
    }
}
