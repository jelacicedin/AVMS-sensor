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
    public class ICPTest5_Cube : TestBaseICP
    {
             
        [Test]
        public void Cube_Translate()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            

            meanDistance = ICPTestData.Test5_CubeTranslation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, 50);
          
            this.ShowResultsInWindow_CubeLines(false);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_Translate_Horn_TreeRednaxela_OK()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            this.icpInstance.ICPSettings.FixedTestPoints = false;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_CubeTranslation2(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(this.threshold);
        }
        [Test]
        public void Cube_Rotate()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            

            meanDistance = ICPTestData.Test5_CubeRotate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            this.ShowResultsInWindow_CubeLines(false);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_Scale_Uniform()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
           

            meanDistance = ICPTestData.Test5_CubeScale_Uniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_ScaleInhomogenous_Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            
            meanDistance = ICPTestData.Test5_CubeScale_Inhomogenous(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
           

            this.ShowResultsInWindow_CubeLines(false);
            //
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }

        [Test]
        public void Cube_RotateTranslate_ScaleUniform_Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            
            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleUniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);
            //
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_RotateTranslate_ScaleUniform_Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            
            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleUniform(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);
            //
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
        }
        [Test]
        public void Cube_RotateTranslate_ScaleInhomegenous_Du()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
           
            meanDistance = ICPTestData.Test5_CubeRotateTranslate_ScaleInhomogenous(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);


            this.ShowResultsInWindow_CubeLines(false);
            //
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
            meanDistance = ICPTestData.Test5_Cube8Shuffle_60000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(this.threshold);
        }
        [Test]
        public void Cube_RotateShuffle_Horn()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(this.threshold);
        }
        [Test]
        public void Cube_RotateShuffle_Umeyama()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test5_Cube8RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);

            CheckResult_MeanDistance(this.threshold);
        }
 
     
    }
}
