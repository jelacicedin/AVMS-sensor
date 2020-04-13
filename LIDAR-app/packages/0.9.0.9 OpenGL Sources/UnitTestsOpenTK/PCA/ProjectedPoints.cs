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
    public class ProjectedPoints : PCABase
    {

      
      
        [Test]
        public void CuboidRotated_Projected()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);


            this.pointCloudSource = myModel.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);

            this.pointCloudAddition1 = PointCloudVertices.CloneVertices(pointCloudSource);

            pca.PCA_OfPointCloud(pointCloudSource);

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            //Show4PointCloudsInWindow(true);
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

        }
        [Test]
        public void Cuboid_RotateCenter_Projected()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);


            this.pointCloudSource = myModel.PointCloudVertices;
            pointCloudSource.ResizeVerticesTo1();
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);

            this.pointCloudAddition1 = PointCloudVertices.CloneVertices(pointCloudSource);

            pca.PCA_OfPointCloud(pointCloudSource);

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            //Show4PointCloudsInWindow(true);
            lineMinLength = 2;
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

        }
       
     
      
        [Test]
        public void Cube_Projected()
        {
            lineMinLength = 100;

            this.pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            

            //Show4PointCloudsInWindow(true);
            
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

            //Show4PointCloudsInWindow(true);

        }
      
     
      

        [Test]
        public void CubeRotated()
        {
            lineMinLength = 2;

            this.pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);

            this.pointCloudAddition1 = PointCloudVertices.CloneVertices(pointCloudSource);

            pca.PCA_OfPointCloud(pointCloudSource);
            

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            //Show4PointCloudsInWindow(true);
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

        }

        [Test]
        public void CubeRotated_X()
        {
            lineMinLength = 2;

            this.pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 0, 0);

            this.pointCloudAddition1 = PointCloudVertices.CloneVertices(pointCloudSource);

            pca.PCA_OfPointCloud(pointCloudSource);
          

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            //Show4PointCloudsInWindow(true);
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

        }
    
       
        [Test]
        public void CuboidRotated_X()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);

            
            this.pointCloudSource = myModel.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 0, 0);


            pca.PCA_OfPointCloud(pointCloudSource);
            

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            //Show4PointCloudsInWindow(true);
            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

        }
     

        [Test]
        public void Cube_ProjectedPoints()
        {
            lineMinLength = 100;
           
            this.pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            this.pointCloudAddition1 = PointCloudVertices.CloneVertices(pointCloudSource);

            pca.PCA_OfPointCloud(pointCloudSource);
           
            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            this.ShowResultsInWindow_Cube_ProjectedPoints(true);

            //Show4PointCloudsInWindow(true);

        }
       

   
     
        [Test]
        public void Face_TranslateRotateScale2()
        {


            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;

            PointCloudVertices.RotateDegrees(pointCloudSource, 60, 60, 90);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.9f);
            PointCloudVertices.Translate(pointCloudSource, 0.3f, 0.5f, -0.4f);

            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);
            

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            Show4PointCloudsInWindow(true);

        }


        [Test]
        public void Face()
        {


            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;
            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);
            



            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            Show4PointCloudsInWindow(true);

        }

        [Test]
        public void Face_TranslateRotateScale()
        {


            Model model3DTarget = new Model(path + "\\KinectFace_1_15000.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);
            //Vertices.RotateVertices(pointCloudSource, 60, 60, 90);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.9f);
            PointCloudVertices.Translate(pointCloudSource, 0.3f, 0.5f, -0.4f);

            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);


            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            Show4PointCloudsInWindow(true);

        }

        [Test]
        public void Person()
        {


            Model model3DTarget = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;


            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            Show4PointCloudsInWindow(true);

        }
        [Test]
        public void Person_Rotate_Projected()
        {


            Model model3DTarget = new Model(path + "\\1.obj");
            this.pointCloudSource = model3DTarget.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 90, 25);


            this.pointCloudAddition1 = pointCloudSource;

            pca.PCA_OfPointCloud(pointCloudSource);

            this.pointCloudSource = PointCloudVertices.FromVectors(pca.PointsResult0);
            this.pointCloudTarget = PointCloudVertices.FromVectors(pca.PointsResult1);
            this.pointCloudResult = PointCloudVertices.FromVectors(pca.PointsResult2);

            Show4PointCloudsInWindow(true);

        }
     
    

    }
}
