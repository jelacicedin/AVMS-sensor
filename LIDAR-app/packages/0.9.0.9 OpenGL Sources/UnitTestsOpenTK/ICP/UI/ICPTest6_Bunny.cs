using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using ICPLib;


namespace UnitTestsOpenTK.UI
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest6_Bunny : TestBaseICP
    {
        
        
        [Test]
        public void Horn()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            
            meanDistance = ICPTestData.Test6_Bunny(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);

            CheckResult_MeanDistance(1e-3f);
           
        }
        [Test]
        public void Umeyama()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            
            meanDistance = ICPTestData.Test6_Bunny(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            Show3PointCloudsInWindow(true);

            CheckResult_MeanDistance(1e-3f);


        }
        [Test]
        public void Du()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            
            meanDistance = ICPTestData.Test6_Bunny(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);

            CheckResult_MeanDistance(1e-3f);

        }
        [Test]
        public void Zinsser()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            

            meanDistance = ICPTestData.Test6_Bunny(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            CheckResult_MeanDistance(1e-3f);

        }
     
     
    }
}
