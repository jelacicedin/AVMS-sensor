using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using UnitTestsOpenTK;
using ICPLib;


namespace UnitTestsOpenTK.Performance
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTest5_Cube : TestBaseICP
    {
             
      
    
        [Test]
        public void Cube_Shuffle_60000p()
        {
            Vertex v = new Vertex();

            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8Shuffle_60000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);



            CheckResult_MeanDistance(this.threshold);
            
            double executionTime = Performance_Stop("ICP_Cube_Shuffle_60000");//1.4 seconds on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 1.4);


        }
        [Test]
        public void Cube_Shuffle_1MilionPoints()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8Shuffle_1Milion(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);



            CheckResult_MeanDistance(this.threshold);
            double executionTime = Performance_Stop("ICP_Cube_Shuffle_1Million");//66 - 71 seconds on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 75);

         
        }
     
    }
}
