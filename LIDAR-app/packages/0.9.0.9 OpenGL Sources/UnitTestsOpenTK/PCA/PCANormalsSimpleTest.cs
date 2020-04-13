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
    public class PCANormals_SimpleTest : TestBase
    {
        [Test]
        public void Cube_56_StartAt0()
        {
            ResetTest();
            lineMinLength = 1;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_StartAt0_Empty(1, 3);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 6, false, true);
            this.ShowCubeLinesAndNormals(lineMinLength, normals);
            //ShowCubeLinesAndNormals(cubeSize, normals);


        }
        [Test]
        public void Cube_64_StartAt0_Error()
        {
            ResetTest();
            lineMinLength = 1;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_StartAt0_Filled(1, 3);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 7, false, true);
           
            this.ShowCubeLinesAndNormals(lineMinLength, normals);

            //ShowCubeLinesAndNormals(cubeSize, normals);


        }
        [Test]
        public void Cube_56()
        {
            ResetTest();
            lineMinLength = 1;
            checkMultipleNormals = true;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 3);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            this.ShowCubeLinesAndNormals(lineMinLength, normals);
            //ShowCubeLinesAndNormals(cubeSize, normals);

            checkMultipleNormals = false;

        }
        [Test]
        public void Cube_64_Filled_Error()
        {
            ResetTest();
            lineMinLength = 1;
            checkMultipleNormals = true;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Filled(lineMinLength, 3);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            this.ShowCubeLinesAndNormals(lineMinLength, normals);
            //ShowCubeLinesAndNormals(cubeSize, normals);

            checkMultipleNormals = false;

        }
        [Test]
        public void Cube_26p_CM()
        {
            ResetTest();
            lineMinLength = 1;
            checkMultipleNormals = true;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 2);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            this.ShowCubeLinesAndNormals(lineMinLength, normals);
            //ShowCubeLinesAndNormals(cubeSize, normals);

            checkMultipleNormals = false;

        }
        [Test]
        public void Cube_26p_CM_Only3Neighbours_Error()
        {
            ResetTest();
            lineMinLength = 1;
            checkMultipleNormals = true;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 2);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, true, true);
            this.ShowCubeLinesAndNormals(lineMinLength, normals);
            checkMultipleNormals = false;

        }
        [Test]
        public void PlaneRotate()
        {
            ResetTest();
            lineMinLength = 1;

            pointCloudSource.Add(new Vertex(0, 0, 0, 0));
            pointCloudSource.Add(new Vertex(1, 0, 1, 0));
            pointCloudSource.Add(new Vertex(2, 1, 0, 0));
            pointCloudSource.Add(new Vertex(3, 1, 1, 0));
            
            Matrix3d R = Matrix3d.CreateRotationX(Convert.ToSingle(Math.PI / 20));


            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        [Test]
        public void PlaneXY()
        {
            ResetTest();
            lineMinLength = 1;

            pointCloudSource.Add(new Vertex(0, 0, 0, 0));
            pointCloudSource.Add(new Vertex(1, 0, 1, 0));
            pointCloudSource.Add(new Vertex(2, 1, 0, 0));
            pointCloudSource.Add(new Vertex(3, 1, 1, 0));


            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        [Test]
        public void PlaneRotate_CM()
        {
            ResetTest();
            lineMinLength = 1;

            pointCloudSource.Add(new Vertex(0, 0, 0, 0));
            pointCloudSource.Add(new Vertex(1, 0, 1, 0));
            pointCloudSource.Add(new Vertex(2, 1, 0, 0));
            pointCloudSource.Add(new Vertex(3, 1, 1, 0));

           
            Matrix3d R = Matrix3d.CreateRotationX(Convert.ToSingle(Math.PI / 20));
            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
   
        [Test]
        public void PlaneRotate_5p_CM_Alglib()
        {
            ResetTest();
            lineMinLength = 1;

            
            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, -1));
            pointCloudSource.Add(new Vertex(2, 1, 0, -1));
            pointCloudSource.Add(new Vertex(3, 1, 1, -1));

            pointCloudSource.Add(new Vertex(4, 2, 2.5f, -1));

            
            Matrix3d R = Matrix3d.CreateRotationX(45);
            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
            
        }
        [Test]
        public void PlaneRotate_5p()
        {
            ResetTest();
            lineMinLength = 1;

           
            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, -1));
            pointCloudSource.Add(new Vertex(2, 1, 0, -1));
            pointCloudSource.Add(new Vertex(3, 1, 1, -1));

            pointCloudSource.Add(new Vertex(4, 2, 2.5f, -1));

            Matrix3d R = Matrix3d.CreateRotationX(45);
            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        [Test]
        public void PlaneRotate_5p_CM()
        {
            ResetTest();
            lineMinLength = 1;

            
            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, -1));
            pointCloudSource.Add(new Vertex(2, 1, 0, -1));
            pointCloudSource.Add(new Vertex(3, 1, 1, -1));
            
            pointCloudSource.Add(new Vertex(4, 2, 2.5f, -1));

            Matrix3d R = Matrix3d.CreateRotationX(45);
            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        protected void CreatePlane()
        {
            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, -1));
            pointCloudSource.Add(new Vertex(2, 1, 0, -1));
            pointCloudSource.Add(new Vertex(3, 1, 1, -1));

            pointCloudSource.Add(new Vertex(4, 2, 2.5f, -1));

            //pointCloud.Add(new Vertex(4, 0, 0.5, -1));
            //pointCloud.Add(new Vertex(5, 0, 0.75, -1));
            //pointCloud.Add(new Vertex(6, 0.5, 0.5, -1));
            //pointCloud.Add(new Vertex(7, 0.25, 0.5, -1));


            //pointCloud.Add(new Vertex(9, -1, 0.5, -1));

        }
   
       
        [Test]
        public void PlaneShift()
        {
            ResetTest();
            lineMinLength = 1;

            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, -1));
            pointCloudSource.Add(new Vertex(2, 1, 0, -1));
            pointCloudSource.Add(new Vertex(3, 1, 1, -1));
            Matrix3d R = Matrix3d.CreateRotationX(45);
            PointCloudVertices.Rotate(pointCloudSource, R);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
    
      
      
        [Test]
        public void PlaneXY_CM()
        {
            ResetTest();
            lineMinLength = 1;
            CreatePlane();


            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        [Test]
        public void Facet1()
        {
            ResetTest();
            lineMinLength = 1;
          
            pointCloudSource.Add(new Vertex(0, 0, 0, -1));
            pointCloudSource.Add(new Vertex(1, 0, 1, 0));
            pointCloudSource.Add(new Vertex(2, 1, 0, 0));
            pointCloudSource.Add(new Vertex(3, 0, 0, 0));

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
        [Test]
        public void Facet2()
        {
            ResetTest();
            lineMinLength = 1;
          
            pointCloudSource.Add(new Vertex(0, 1, 1, 0));
            pointCloudSource.Add(new Vertex(1, 1, 0, 0));
            pointCloudSource.Add(new Vertex(2, 0, 1, 0));
            pointCloudSource.Add(new Vertex(3, 1, 1, 1));




            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);



        }
            
     
        [Test]
        public void Cube()
        {
            ResetTest();
            lineMinLength = 1;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);



        }
        [Test]
        public void CubeCorners_CM()
        {
            ResetTest();
            lineMinLength = 10;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(1, 1);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);


        }
        [Test]
        public void CubeCorners()
        {
            ResetTest();
            lineMinLength = 10;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_Empty(1, 1);

            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 3, false, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);
        }
      
     
      
        [Test]
        public void Cube_StartAt0_CM()
        {
            ResetTest();
            lineMinLength = 10;
            pointCloudSource = PointCloudVertices.CreateCube_RegularGrid_StartAt0_Filled(1, 1);


            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, true, true);
            ShowCubeLinesAndNormals(lineMinLength, normals);

        }
      
     

    }
}
