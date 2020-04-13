using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;
using UnitTestsOpenTK;

namespace UnitTestsOpenTK.Automated.PrincipalComponentAnalysis
{
    [TestFixture]
    [Category("UnitTest")]
    public class Face_14000 : PCABase
    {

        public Face_14000()
        {
            UIMode = false;
        }
     
        [Test]
        public void ShowAxes_AlignedToOriginAxes()
        {
            ResetTest();

            Model myModel = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = myModel.PointCloudVertices;

            
            //PointCloud.ResizeVerticesTo1(pointCloudSource);
            pca.PCA_OfPointCloud(pointCloudSource);
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            myModel.PointCloud = pointCloudSource.ToPointCloud();


            //-----------Show in Window
            if (UIMode)
            {
                this.ShowModel(myModel);
               
                
            }

            //----------------check Result
           
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 1));

            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 0.3);

            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudSource.PCAAxesNormalized, this.threshold));

        }
        [Test]
        public void AlignPCAToOriginAxes_SecondCloud()
        {
            ResetTest();

            Model model3DTarget = new Model(path + "\\KinectFace_2_15000.obj");
            
            this.pointCloudSource = model3DTarget.PointCloudVertices;


            pointCloudResult = PCA.RotateToOriginAxes(pointCloudSource);


            //-----------Show in Window
            if (UIMode)
            {
                Show4PointCloudsInWindow(true);
                //ShowResultsInWindow_Cube(true);
            }
            
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 1));

            //----------------check Result
            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            //bool condition = true;
            Assert.LessOrEqual(executionTime, 0.25);
            //Assert.IsTrue(executionTime < 0.25);
        
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxesNormalized, this.threshold));

        }
        [Test]
        public void AlignPCAToOriginAxes()
        {
            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;
            
        
            pointCloudResult = PCA.RotateToOriginAxes(pointCloudSource);


            //-----------Show in Window
            if (UIMode)
            {
                Show4PointCloudsInWindow(true);
                //ShowResultsInWindow_Cube(true);
            }
           
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 1));

            //----------------check Result
            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxesNormalized, this.threshold));


        }

        [Test]
        public void Translate()
        {
            ResetTest();
            Model myModel = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = myModel.PointCloudVertices;

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.Translate(pointCloudSource, 0, -300, 0);
            //PointCloud.Translate(pointCloudSource, 10, -40, 40);


            this.pointCloudResult = pca.AlignPointClouds_SVD( this.pointCloudSource, this.pointCloudTarget);
            //-----------Show in Window

            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
            CheckResultTargetAndShow_Cloud(this.threshold);


        }
        [Test]
        public void Rotate()
        {
            ResetTest();
            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 90, 25);


            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);
            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void Rotate2()
        {

            ResetTest();
            Model m = new Model(path + "\\KinectFace_1_15000.obj");
            m.PointCloud.ToPointCloudVertices();

            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 60, 60, 0);


            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);
            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
            CheckResultTargetAndShow_Cloud(this.threshold);
        }
      
   
        [Test]
        public void Scale()
        {

            ResetTest();
            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.78f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
            CheckResultTargetAndShow_Cloud(this.threshold);


        }

       


        [Test]
        public void TranslateRotate()
        {

            ResetTest();
            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;


            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 60, 60, 90);
            PointCloudVertices.Translate(pointCloudSource, 10, -40, 40);


            this.pointCloudResult = pca.AlignPointClouds_SVD( this.pointCloudSource, this.pointCloudTarget);

            double executionTime = Performance_Stop("Execution Time");//on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 1);
            CheckResultTargetAndShow_Cloud(this.threshold);


        }
    }
}
