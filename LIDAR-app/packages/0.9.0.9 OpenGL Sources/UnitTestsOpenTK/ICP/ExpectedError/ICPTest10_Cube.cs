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
    public class ICPTest10_Cube : TestBaseICP
    {

        [Test]
        public void Cube_125Points_Rotate_Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            
            this.icpInstance.ICPSettings.FixedTestPoints = false;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;


            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube98p_Rotate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(false);

            CheckResult_MeanDistance(this.threshold);
        }

     
     
        
     
    }
}
