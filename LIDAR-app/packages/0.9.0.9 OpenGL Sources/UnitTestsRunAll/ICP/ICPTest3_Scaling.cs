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
    public class ICPTest3_Scaling : TestBaseICP
    {
         
       
        [Test]
        public void Scale_Horn()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test3_Scale(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            //this.ShowResultsInWindowIncludingLines(false);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
            Performance_Stop("Scale_Horn");
        }
        [Test]
        public void Scale_Umeyama()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test3_Scale(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Performance_Stop("Scale_Umeyama");//7 miliseconds on i3_2121 (3.3 GHz)
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

        }
        [Test]
        public void Scale_Zinsser()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test3_Scale(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Scale_Du()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test3_Scale(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Scale_AllAxes_Du()
        {
           

            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            meanDistance = ICPTestData.Test3_Scale(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        
      
    }
}
