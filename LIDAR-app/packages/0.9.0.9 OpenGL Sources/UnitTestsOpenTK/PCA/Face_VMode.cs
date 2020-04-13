using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.PrincipalComponentAnalysis
{
    [TestFixture]
    [Category("UnitTest")]
    public class Face_VMode : PCABase
    {

      

        [Test]
        public void V_Rotate_NotWorking()
        {
            ResetTest();
            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            //PointCloud.ResizeVerticesTo1(pointCloudTarget);

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            //Vertices.TranslateVertices(pointCloudTarget, 0, -300, 0);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 0, 0);


            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudSource = pointCloudResult;
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 1, 1);
            this.pointCloudSource = pointCloudResult;
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 2, 2);
            this.pointCloudSource = pointCloudResult;
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);


            CheckResultTargetAndShow_Cloud(1e-5f);
        }
        [Test]
        public void V_RotateNotWorking()
        {
            ResetTest();

            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            //PointCloud.ResizeVerticesTo1(pointCloudTarget);

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 60, 60, 90);


            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            

            ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

        }
       
    

    }
}
