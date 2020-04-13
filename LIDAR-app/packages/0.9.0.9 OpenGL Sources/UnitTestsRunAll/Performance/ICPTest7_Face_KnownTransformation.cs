﻿using System;
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
    public class ICPTest7_Face_KnownTransformation : TestBaseICP
    {
        

      
        [Test]
        public void Zinsser_15000()
        {

            ResetICP();
            
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;


            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            //on error of testcases, check: 
            //Show3PointCloudsInWindow(false);
            

            double executionTime = Performance_Stop("Zinsser_15000");//7 miliseconds on i3_2121 (3.3 GHz)
            
            CheckResult_MeanDistance(this.threshold);
            Assert.IsTrue(this.icpInstance.NumberOfIterations <= 43);

            Assert.IsTrue(executionTime < 7);

        }
        [Test]
        public void Umeyama_15000()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();
            icpInstance.ICPSettings.MaximumNumberOfIterations = 43;
           

            meanDistance = ICPTestData.Test7_Face_KnownTransformation_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
          
           
           
            double executionTime = Performance_Stop("Umeyama_15000");//10 (cold) - 7  seconds on i3_2121 (3.3 GHz)   appr. 14,000 points
            
            CheckResult_MeanDistance(this.threshold);
            Assert.IsTrue(executionTime < 10);
            Assert.IsTrue(this.icpInstance.NumberOfIterations <= 43);

        }
        [Test]
        public void Umeyama_15000_PCA()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

           

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            this.icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 50;


            meanDistance = ICPTestData.Test7_Face_KnownTransformation_PCA_15000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
           // Assert.IsTrue(this.icpInstance.NumberOfIterations == 43);

           
            
          
            double executionTime = Performance_Stop("Umeyama_15000_PCA");//one ICP iteration - 1.3 seconds on i3_2121 (3.3 GHz)   appr. 14,000 points - compared to 9 s without PCA
            
            CheckResult_MeanDistance(this.threshold);
            Assert.IsTrue(executionTime < 7);

        }
        [Test]
        public void Umeyama_55000_PCA()
        {

            ResetICP();
            this.icpInstance.Settings_Reset_RealData();


            meanDistance = ICPTestData.Test7_Face_KnownTransformation_PCA_55000(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
           
           
            double executionTime = Performance_Stop("Umeyama_55000_PCA");//one ICP iteration - 1.3 seconds on i3_2121 (3.3 GHz)   appr. 14,000 points - compared to 9 s without PCA
            Assert.IsTrue(executionTime < 1213);

            CheckResult_MeanDistance(this.threshold);
            
            
            
        }
     
    }
}
