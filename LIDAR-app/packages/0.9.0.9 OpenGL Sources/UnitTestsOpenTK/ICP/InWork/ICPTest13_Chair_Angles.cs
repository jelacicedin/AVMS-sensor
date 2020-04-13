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
    public class ICPTest14_Chair_Angles : TestBaseICP
    {

       
       
        [Test]
        public void Chair_Angles()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            Model model3DTarget = new Model(path + "\\G1.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\G2.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 5;
            //IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;

            this.pointCloudResult = IterativeClosestPointTransform.Instance.PerformICP(pointCloudSource, pointCloudTarget);

            this.pointCloudResult.Save(path, "Result.obj");
            IterativeClosestPointTransform.Instance.PMerged.Save(path, "Result_Merged.obj");
            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

       
        }
      
    }
}
