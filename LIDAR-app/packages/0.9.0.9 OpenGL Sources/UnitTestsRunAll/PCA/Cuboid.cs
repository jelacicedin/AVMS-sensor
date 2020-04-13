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
    public class Cuboid : PCABase
    {
        public Cuboid()
        {
            UIMode = false;
        }
        [Test]
        public void PCA_Axes()
        {
            ResetTest();
            lineMinLength = 1;

            //this.pointCloudSource = PointCloud.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            this.pointCloudSource = PointCloudVertices.CreateCube_Corners(lineMinLength);

            pointCloudSource.ResizeVerticesTo1();
            pca.PCA_OfPointCloud(pointCloudSource);


            //----------------check Result
            //expectedResultCloud.Add(new Vertex(-1, 0, 0));
            //expectedResultCloud.Add(new Vertex(0, -1, 0));
            //expectedResultCloud.Add(new Vertex(0, 0, -1));

            expectedResultCloud.Add(new Vertex(1, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 1));




            //-----------Show in Window
            if (UIMode)
            {
                //lineMinLength = 2;
                //ShowResultsInWindow_Cube(true);
                //-----------Show in Window
               
                this.ShowResultsInWindow_CubeNew(true, true);
                
            }
            Assert.IsTrue(PointCloudVertices.CheckCloud(expectedResultCloud, pointCloudSource.PCAAxes, 1e-3f));

        }
        [Test]
        public void PCA_Axes_Translated()
        {
          
            ResetTest();
            lineMinLength = 1;

            this.pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            PointCloudVertices.Translate(pointCloudSource, 2, 4, 3);
            pca.PCA_OfPointCloud(pointCloudSource);

            //----------------check Result
            //expectedResultCloud.Add(new Vertex(-0.5f, 0, 0));
            //expectedResultCloud.Add(new Vertex(0, -0.5f, 0));
            //expectedResultCloud.Add(new Vertex(0, 0, -0.5f));

            expectedResultCloud.Add(new Vertex(0.5f, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 0.5f, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            //-----------Show in Window
            if (UIMode)
            {
                lineMinLength = 2;
                ShowResultsInWindow_Cube(true);
            }
            Assert.IsTrue(PointCloudVertices.CheckCloud(expectedResultCloud, pointCloudSource.PCAAxes, 1e-3f));

        }
     
        [Test]
        public void Translate()
        {

            CreateCube();
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
           
            CheckResultTargetAndShow_Cube();
        }

    
        [Test]
        public void Scale()
        {
            CreateCube();
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.4f);
           
            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
           
            CheckResultTargetAndShow_Cube();
        }
        [Test]
        public void Rotate()
        {
            CreateCube();
            //pointCloudTarget.ResizeVerticesTo1();
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);
            
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 0, 0);
           
            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
            lineMinLength = 2;
            CheckResultTargetAndShow_Cube();

        }
        [Test]
        public void TranslateRotate()
        {
            CreateCube();
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 0, 0);
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
            
            
            CheckResultTargetAndShow_Cube();



        }
       
     
        [Test]
        public void AlignToItself()
        {
            CreateCube();

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
            
            CheckResultTargetAndShow_Cube();

        }
       
     
      
      

    }
}
