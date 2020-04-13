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
    public class AlignTwoDifferentScans : PCABase
    {

        //Model3D model3DTarget = new Model3D(path + "\\KinectFace_1_15000.obj");

        [Test]
        public void Faces_SVD()
        {
            Model model3DTarget = new Model(path + "\\KinectFace_2_15000.obj");
            
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            //PointCloud.ResizeVerticesTo1(pointCloudTarget);
            Model model3DSource = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            //PointCloud.ResizeVerticesTo1(pointCloudSource);

            pca.MaxmimumIterations = 5;
            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void Faces_AlignToOriginAxes()
        {
            Model model3DTarget = new Model(path + "\\KinectFace_2_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);
            //PointCloud.ResizeVerticesTo1(pointCloudTarget);
            Model model3DSource = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);
            PointCloudVertices.RotateDegrees(pointCloudSource, 90, 0, 0);

            //PointCloud.ResizeVerticesTo1(pointCloudSource);
            pointCloudResult = null;
            pca.MaxmimumIterations = 5;
            //this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }

        [Test]
        public void Persons_SVD()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            
            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;

            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void Persons_SVD_XYZ()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);

            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);
            pca.MaxmimumIterations = 1;
            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void Persons_V()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            
            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
            
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            
        
            
           

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));
            if(UIMode)
                ShowPointCloudsInWindow_PCAVectors(true);
        }
      
        [Test]
        public void Persons_V_4()
        {
            Model model3DTarget = new Model(path + "\\2.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            

            Model model3DSource = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
           

            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 1, 1);
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 2, 2);
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 1, 1);
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);

            //this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);
            

            
            ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

        }

     
      
       
     
        
      

    }
}
