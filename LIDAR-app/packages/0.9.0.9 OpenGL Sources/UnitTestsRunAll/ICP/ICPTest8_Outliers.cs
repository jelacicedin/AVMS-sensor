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
    public class ICPTest8_Outliers : TestBaseICP
    {

        [Test]
        public void Outliers_CubeTranslate_FixedPoints()
        {
            ResetICP();

            
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            IterativeClosestPointTransform.Instance.ICPSettings.FixedTestPoints = true;
            //KDTreeVertex.KDTreeMode = KDTreeMode.Rednaxela;
            IterativeClosestPointTransform.Instance.ICPSettings.MaximumNumberOfIterations = 10;
          //  this.icpInstance.ICPSettings.SimulatedAnnealing = true;

            meanDistance = ICPTestData.Test8_CubeOutliers_Translate(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
           // this.ShowResultsInWindowIncludingLines(false);

            
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
    
     
     
    }
}
