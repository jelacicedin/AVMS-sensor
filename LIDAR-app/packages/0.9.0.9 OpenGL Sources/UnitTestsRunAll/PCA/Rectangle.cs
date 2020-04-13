using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.Automated.PrincipalComponentAnalysis
{
    [TestFixture]
    [Category("UnitTest")]
    public class Rectangle : PCABase
    {
        public Rectangle()
        {
            UIMode = false;
        }
        [Test]
        public void ShowAxes()
        {

            CreateRectangle();
            pointCloudTarget = null;
            pca.PCA_OfPointCloud(pointCloudSource);

            //-----------Show in Window
            if (UIMode)
            {

                ShowResultsInWindow_Cube(true);
            }
            //----------------check Result
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 0.5f, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0));

            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudSource.PCAAxes, this.threshold));

           
        }
        [Test]
        public void ShowAxes_Rotated()
        {

            CreateRectangle();
            pointCloudTarget = null;
            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);

            pca.PCA_OfPointCloud(pointCloudSource);

            //-----------Show in Window
            if (UIMode)
            {

                ShowResultsInWindow_Cube(true);
            }
            System.Diagnostics.Debug.Write(pointCloudSource.PCAAxes.PrintVectors());

            //----------------check Result
            expectedResultCloud.Add(new Vertex(-0.707106781186548f, -0.707106781186548f, 0));
            expectedResultCloud.Add(new Vertex(-0.353553390593274f, 0.353553390593274f, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0));

            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudSource.PCAAxes, this.threshold));
        }
    
        [Test]
        public void ShowAxes_RotateToOriginAxes()
        {

            CreateRectangle();
            pointCloudTarget = null;
            pca.PCA_OfPointCloud(pointCloudSource);

            
            //-----------Show in Window
            if (UIMode)
            {

                ShowResultsInWindow_Cube(true);
            }
            //----------------check Result
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 0.5f, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0));

            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudSource.PCAAxes, this.threshold));


        }
        [Test]
        public void AlignToItself()
        {
            CreateRectangle();
            pointCloudSource.ResizeVerticesTo1();
            pointCloudTarget.ResizeVerticesTo1();

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();

        }
        [Test]
        public void AlignPCAToOriginAxes()
        {

            CreateRectangle();
            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            
            pointCloudTarget = null;
            
            pointCloudResult = PCA.RotateToOriginAxes(pointCloudSource);



            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0));

            //----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxesNormalized, this.threshold));


            //----------------check Result
           
        }
        [Test]
        public void Translate()
        {

            CreateRectangle();
            PointCloudVertices.Translate(pointCloudTarget, -2, 3, -1);
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }

   
        [Test]
        public void Scale()
        {

            CreateRectangle();
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.8f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }
        [Test]
        public void TranslateRotateScale()
        {

            CreateRectangle();
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 124, 297);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.8f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }
     
      
      

    }
}
