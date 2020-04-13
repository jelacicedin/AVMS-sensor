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
    public class ICPTest7_Face_KnownTransformation : TestBaseICP
    {
        

        [Test]
        public void Horn()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 100;
            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(false);
            CheckResult_MeanDistance(1e-3f);
           
        }
    
        [Test]
        public void Du()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
           
            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            
            Show3PointCloudsInWindow(false);
            CheckResult_MeanDistance(1e-3f);

        }
        [Test]
        public void Zinsser()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
           
            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            Show3PointCloudsInWindow(false);
            CheckResult_MeanDistance(1e-7f);

        }
        [Test]
        public void Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(false);
            CheckResult_MeanDistance(1e-7f);

        }
     
    }
}
