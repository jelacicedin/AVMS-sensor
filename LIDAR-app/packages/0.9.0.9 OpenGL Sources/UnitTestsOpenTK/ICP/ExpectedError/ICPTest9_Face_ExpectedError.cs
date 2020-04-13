using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using UnitTestsOpenTK;
using ICPLib;


namespace UnitTestsOpenTK.ExpectedError
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest9_Face_ExpectedError : TestBaseICP
    {
        

        [Test]
        public void Horn()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            //as it does not converge anyway, keep the iteration number low
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            
           
            meanDistance = ICPTestData.Test9_Face_Stitch(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));
           
        }
        [Test]
        public void Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
           
            
            meanDistance = ICPTestData.Test9_Face_Stitch(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
      
          
     
    }
}
