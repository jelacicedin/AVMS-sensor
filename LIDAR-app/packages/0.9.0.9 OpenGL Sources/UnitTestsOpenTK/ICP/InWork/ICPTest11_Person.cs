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
    public class ICPTest11_Person : TestBaseICP
    {

       
       
        [Test]
        public void Person_TwoClouds_PCA_ICP()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            this.pointCloudResult = IterativeClosestPointTransform.Instance.PerformICP(pointCloudSource, pointCloudTarget);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

       
        }
        [Test]
        public void Person_TwoClouds_ICP()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            //pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;


            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            this.pointCloudResult = IterativeClosestPointTransform.Instance.PerformICP(pointCloudSource, pointCloudTarget);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));


        }
        [Test]
        public void Person_ICP()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;

            meanDistance = ICPTestData.Test11_Person(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Person_PCA_ICP()
        {
            ResetICP();
            this.icpInstance.Settings_Reset_RealData();

            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;

            meanDistance = ICPTestData.Test11_Person(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);

            Show3PointCloudsInWindow(true);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 1e-3f));

        }
        [Test]
        public void Person_PCA()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 10, 25);

            
            PCA pca = new PCA();
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 1, 1);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 2, 2);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);

           
            Show3PointCloudsInWindow(true);
            //ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, 4e-3f));

        }
        [Test]
        public void Person_PCA_V_TwoClouds()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
           
            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
           
            PCA pca = new PCA();
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 1, 1);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 2, 2);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);

            
            Show3PointCloudsInWindow(true);
            //ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

        }
        [Test]
        public void Person_PCA_V_TwoClouds_XYZ()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            PCA pca = new PCA();
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 1, 1);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 2, 2);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);


            Show3PointCloudsInWindow(true);
            //ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

            

        }
     
    }
}
