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
    public class ICPTest1_Translation : TestBaseICP
    {
         
        
        [Test]
        public void Translation_Horn()
        {

            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;
            meanDistance = ICPTestData.Test1_Translation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));


        }
        [Test]
        public void Translation_Umeyama()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Umeyama;
            meanDistance = ICPTestData.Test1_Translation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            //have to check why Umeyama is not exact to e-10 - perhaps because of diagonalization lib (for the scale factor) 
            if (!PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold))
            {
                System.Diagnostics.Debug.WriteLine("Translation Umeyama failed");
                Assert.Fail("Translation Umeyama failed");
            }
            
        }
        [Test]
        public void Translation_Du()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Du;
            meanDistance = ICPTestData.Test1_Translation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            if (!PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold))
            {
                System.Diagnostics.Debug.WriteLine("Translation Du failed");
                Assert.Fail("Translation Du failed");
            }

        }
        [Test]
        public void Translation_Zinsser()
        {
            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            meanDistance = ICPTestData.Test1_Translation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            if (!PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold))
            {
                System.Diagnostics.Debug.WriteLine("Translation Zinsser failed");
                Assert.Fail("Translation Zinsser failed");
            }

        }
   
     
    }
}
