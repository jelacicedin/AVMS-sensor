using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;
using UnitTestsOpenTK;

namespace UnitTestsOpenTK.ToDo.PrincipalComponentAnalysis
{
    [TestFixture]
    [Category("UnitTest")]
    public class TileToDo : PCABase
    {
      
        [Test]
        public void AlignPCAToOriginAxes_008()
        {

            CreateTile(1);

           
            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);


           
            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
           
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, -1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            //----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }

        [Test]
        public void AlignPCAToOriginAxes_028()
        {

            CreateTile(2);
            lineMinLength = 2;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);


            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud = new PointCloudVertices();
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }

        [Test]
        public void AlignPCAToOriginAxes_064()
        {

            CreateTile(3);
            lineMinLength = 2;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);


            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud = new PointCloudVertices();
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }
    
        [Test]
        public void AlignPCAToOriginAxes_255()
        {

            CreateTile(5);
            lineMinLength = 1;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);



            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud = new PointCloudVertices();
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }
        [Test]
        public void AlignPCAToOriginAxes_512()
        {

            CreateTile(6);
            lineMinLength = 1;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);



            //-----------Show in Window
            if (UIMode)
            {
                //Show4PointCloudsInWindow(true);
                ShowResultsInWindow_Cube(true);
            }
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud = new PointCloudVertices();
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }
     
        [Test]
        public void AlignPCAToOriginAxes_9602()
        {

            CreateTileEmpty(40);
            lineMinLength = 1;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);



            //////-----------Show in Window
            //if (UIMode)
            //{
            //    //Show4PointCloudsInWindow(true);
            //    ShowResultsInWindow_Cube(true);
            //}
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud = new PointCloudVertices();
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }
        [Test]
        public void AlignPCAToOriginAxes_Million()
        {

            CreateTileEmpty(600);
            lineMinLength = 2;


            PointCloudVertices.RotateDegrees(pointCloudSource, 0, 0, -45);
            pca.PCA_OfPointCloud(pointCloudSource);

            pointCloudTarget = null;

            Matrix3d R = new Matrix3d();
            this.pointCloudResult = PointCloudVertices.CopyVertices(pointCloudSource);
            R = R.Rotation_ToOriginAxes(pointCloudResult.PCAAxes);
            PointCloudVertices.Rotate(pointCloudResult, R);
            pca.PCA_OfPointCloud(pointCloudResult);



            ////-----------Show in Window
            //if (UIMode)
            //{
            //    //Show4PointCloudsInWindow(true);
            //    ShowResultsInWindow_Cube(true);
            //}
            System.Diagnostics.Debug.Write(pointCloudResult.PCAAxes.PrintVectors());
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            ////----------------check Result
            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudResult.PCAAxes, this.threshold));


        }
      

    }
}
