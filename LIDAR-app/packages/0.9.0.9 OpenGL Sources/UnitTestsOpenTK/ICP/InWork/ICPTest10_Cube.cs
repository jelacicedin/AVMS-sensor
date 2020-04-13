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
    public class ICPTest10_Cube : TestBaseICP
    {
        [Test]
        public void Cube_98Points_Rotate_Umeyama_Normals()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            this.icpInstance.ICPSettings.Normal_RemovePoints = true;
            this.icpInstance.ICPSettings.Normal_SortPoints = true;
            this.icpInstance.ICPSettings.ShuffleEffect = false;

            
            this.icpInstance.ICPSettings.MaximumNumberOfIterations = 50;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube98p_Rotate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);
            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }

        [Test]
        public void Cube26_TranslateRotateScaleShuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;
            this.icpInstance.ICPSettings.Normal_RemovePoints = true;
            this.icpInstance.ICPSettings.MaximumNumberOfIterations = 50;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube26pRotateTranslateScaleShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);
            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }
        [Test]
        public void Cube26_RotateShuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            
            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube26p_RotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }
    

        [Test]
        public void Cube8_TranslateRotateScaleShuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            this.icpInstance.ICPSettings.ResetVertexToOrigin = true;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube8pRotateTranslateScaleShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);
            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }


        [Test]
        public void Cube8_TranslateRotateShuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;

            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube8pRotateTranslateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);
            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }


     
    
        
     
        [Test]
        public void Cube8_RotateShuffle()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_GeometricObject();
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = false;
            
            lineMinLength = 10;
            meanDistance = ICPTestData.Test10_Cube8pRotateShuffle(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult, lineMinLength);

            this.ShowResultsInWindow_Cube(true);


            CheckResult_MeanDistance(1e-7f);
        }

      
 
        
     
    }
}
