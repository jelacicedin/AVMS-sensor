using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using UnitTestsOpenTK;
using ICPLib;


namespace UnitTestsOpenTK.Automated
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest5_Cube : TestBaseICP
    {
             
      
        [Test]
        public void Cuboid_Rotate()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;

            meanDistance = ICPTestData.Test5_CuboidIdentity(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cuboid_Identity()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;

            meanDistance = ICPTestData.Test5_CuboidIdentity(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_RotateTranslate_ScaleUniform_Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;

            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleUniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
  
        [Test]
        public void Cube_Shuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8Shuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            

            CheckResult_MeanDistance(this.threshold);
        }
    }
}
