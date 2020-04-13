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
    public class ICPTest2_Rotation : TestBaseICP
    {

        [Test]
        public void RotationIdentity()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_Identity(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        
        [Test]
        public void RotationX_Horn()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationX30Degrees(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        
        [Test]
        public void RotationX_Umeyama()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationX30Degrees(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationX_Zinsser()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationX30Degrees(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationX_Du()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationX30Degrees(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationXYZ_Horn()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationXYZ(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            //this.ShowResultsInWindowIncludingLines(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationXYZ_Umeyama()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationXYZ(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationXYZ_Zinsser()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationXYZ(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void RotationXYZ_Du()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test2_RotationXYZ(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
     
    }
}
