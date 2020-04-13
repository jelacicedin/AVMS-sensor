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
    public class ICPTest5_Cube : TestBaseICP
    {

        
        [Test]
        public void Cube_RotateShuffle_Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(1e-7f);
        }
        [Test]
        public void Cube_RotateShuffle_Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(1e-7f);
        }
         [Test]
        public void Cube_RotateShuffle_Normals_Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            IterativeClosestPointTransform.Instance.ICPSettings.Normal_RemovePoints = true;
            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(1e-7f);
        }
        [Test]
        public void Cube_Translate_TreeRednaxela()
        {
            //gives NAN
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela_ExcludePoints;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_CubeTranslation2(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(1e-7f);
        }
    
      
       
    }
}
