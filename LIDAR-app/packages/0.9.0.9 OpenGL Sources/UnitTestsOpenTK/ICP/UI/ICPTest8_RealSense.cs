using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using UnitTestsOpenTK;
using ICPLib;


namespace UnitTestsOpenTK.UI
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest8_RealSense : TestBaseICP
    {
        

     
        [Test]
        public void Stitch1()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            Model model3DTarget = new Model(path + "\\Stitch1\\0.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\Stitch1\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            this.pointCloudResult = IterativeClosestPointTransform.Instance.PerformICP(pointCloudSource, pointCloudTarget);

            this.pointCloudResult.Save(path + "\\Stitch1\\", "result.obj");


            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));


        }
     
     
    }
}
