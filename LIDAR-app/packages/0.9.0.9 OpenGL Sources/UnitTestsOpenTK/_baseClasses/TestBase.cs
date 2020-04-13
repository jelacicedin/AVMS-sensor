using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK
{
    
    public class TestBase
    {
        protected static bool UIMode = true;
        protected static string path;

        protected PointCloudVertices pointCloudAddition1 = null;
        protected PointCloudVertices pointCloudAddition2 = null;
        protected PointCloudVertices expectedResultCloud = new PointCloudVertices();

        protected PointCloudVertices pointCloudTarget = null;
        protected PointCloudVertices pointCloudSource = null;
        protected PointCloudVertices pointCloudResult = null;

        protected PointCloud pclSource;
        protected PointCloud pclTarget;
        protected PointCloud pclResult;
        protected double threshold = 1e-5;

        DateTime CurrentTime;

        protected double lineMinLength = 1;

         
        protected bool checkMultipleNormals = false;
        public TestBase()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "Models\\UnitTests";
            ResetTest();
        }

        protected void ResetTest()
        {
            Performance_Start();
            expectedResultCloud = new PointCloudVertices();
            pointCloudTarget = null;
            pointCloudSource = null;
            pointCloudResult = null;
            pointCloudAddition1 = null;
            pointCloudAddition2 = null;
            

        }
        
        protected void Show3PointCloudsInWindow(bool changeColor)
        {
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, changeColor);
            fOTK.ShowDialog();


        }
        protected void ShowVerticesInWindow(byte[] colorModel1, byte[] colorModel2)
        {
            OpenTKForm fOTK = new OpenTKForm();
            PointCloudVertices.SetColorToList(pointCloudSource, colorModel1);
            fOTK.AddVerticesAsModel("Point Cloud", pointCloudSource);



            if (pointCloudResult != null && this.pointCloudResult.Count > 0)
            {


                PointCloudVertices.SetColorToList(pointCloudResult, colorModel2);
                fOTK.AddVerticesAsModel("Transformed", pointCloudResult);

            }

            //fOTK.ShowModels();

            fOTK.ShowDialog();



          
        }
        protected void ShowModel(Model myModel)
        {
            OpenTKForm fOTK = new OpenTKForm();

            fOTK.ShowModel(myModel);
          

            GlobalVariables.ShowLastTimeSpan("Show Model");
            fOTK.ShowDialog();

        }
       

        protected void ShowVector3dDInWindow(List<Vector3d> listResult)
        {

            pointCloudSource = PointCloudVertices.FromVectors(listResult);

            Model myModel = new Model("PCA");
            myModel.PointCloud = pointCloudSource.ToPointCloud();

            ShowModel(myModel);

        }
        protected void ShowPointCloudInWindow(PointCloudVertices listResult)
        {

           
            Model myModel = new Model("PCA");
            myModel.PointCloud = pointCloudSource.ToPointCloud();

            ShowModel(myModel);

        }

        protected void ShowModel_Cube(Model myModel)
        {
            OpenTKForm fOTK = new OpenTKForm();
            
            
            fOTK.ShowModel(myModel);


            GlobalVariables.ShowLastTimeSpan("Show Model");
            fOTK.ShowDialog();

        }
        protected void ShowModel_Normals(Model myModel)
        {
            OpenTKForm fOTK = new OpenTKForm();

            
            fOTK.ShowModel(myModel);


            GlobalVariables.ShowLastTimeSpan("Show Model");
            fOTK.ShowDialog();


        }
    
     


        //private void UpateModel_Faces(Model myModel, List<cFace> listFaces)
        //{
        //    List<Triangle> listTriangle = new List<Triangle>();

        //    System.Diagnostics.Debug.WriteLine("Number of faces " + listFaces.Count.ToString());
        //    for (int i = 0; i < listFaces.Count; i++)
        //    {
        //        cFace face = listFaces[i];
        //        Triangle a = new Triangle();

        //        for (int j = 0; j < face.Vertices.Length; j++)
        //        {
        //            a.IndVertices.Add(face.Vertices[j].IndexInModel);

        //        }

        //        listTriangle.Add(a);
        //    }


        //    Part p = new Part();
        //    //myModel.Triangles = listTriangle;
        //    //myModel.Parts.Add(p);

        //    //myModel.Helper_AdaptNormalsForEachVertex();
        //    myModel.PointCloud.CalculateCentroidBoundingBox();
        //}
        protected Model CreateModel(string modelName, PointCloud myList, List<cFace> listFaces)
        {
            Model myModel = new Model();
            myModel.Name = modelName;
            myModel.PointCloud = myList;

            //UpateModel_Faces(myModel, listFaces);




            return myModel;
        }


        protected bool CheckResult(double d1, double d2, double threshold)
        {
            double diff = Math.Abs(d1 - d2);
            if (diff > threshold)
                return false;
            return true;

        }
        protected void ShowCubeVerticesNormals(double cubeSize, List<Vector3d> normals)
        {

            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
            Model myModel = new Model("Cube");

            myModel.PointCloud = pointCloudSource.ToPointCloud();
          
            ShowModel_Cube(myModel);

        }
        protected void ShowVerticesNormals(List<Vector3> normals)
        {

            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
            Model myModel = new Model("Cube");

            myModel.PointCloud = pointCloudSource.ToPointCloud();
            myModel.Normals = normals;


          
            ShowModel(myModel);
            //ShowModel_CubeLines(myModel, 1, true);



        }
        protected void ShowCubeLinesAndNormals(double cubeSize, List<Vector3> normals)
        {

            //PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
            Model myModel = new Model("Cube");

            myModel.PointCloud = pointCloudSource.ToPointCloud();
            myModel.Normals = normals;


          
            ShowModel_Cube(myModel);

        }
        //protected void ShowCubeNormals(double cubeSize, List<Vector3> normals)
        //{

        //    PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
        //    Model myModel = new Model("Cube");

        //    myModel.PointCloud = pointCloudSource.ToPointCloud();
        //    myModel.Normals = normals;

          

        //    ShowModel_Normals(myModel);

        //}
     
     
      
        protected void Show4PointCloudsInWindow(bool changeColor)
        {
            OpenTKForm fOTK = new OpenTKForm();


            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, changeColor);
            if (pointCloudAddition1 != null)
                fOTK.AddVerticesAsModel("Original Data", this.pointCloudAddition1);
            fOTK.ShowDialog();


        }
        protected void ShowPointCloudsInWindow_PCAVectors(bool changeColor)
        {
            OpenTKForm fOTK = new OpenTKForm();

            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, changeColor);
                       
            fOTK.ShowDialog();


        }
       
        protected void CreateCube()
        {

            CreateCube(2);
            

        }
        protected void CreateCube(int numberOfPoints)
        {
            ResetTest();
            lineMinLength = 1;
          
            
            List<Vector3> listVectors = Example3DModels.Cube_Corners(1, 2, 1);
            //List<Vector3> listVectors = Example3DModels.CreateCube_RegularGrid_Empty(cubeSizeY, 1);

            this.pointCloudTarget = PointCloudVertices.FromVector3List(listVectors);


            //this.pointCloudSource = PointCloud.CreateCube_Corners(lineMinLength);

            
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

            this.pointCloudTarget.ShowLinesConnectingPoints = true;



        }
        protected void CreateTile(int numberOfPoints)
        {
            ResetTest();
            lineMinLength = 4;

            pointCloudTarget = Example3DModels.Tile(4, 2, 1, numberOfPoints, numberOfPoints, numberOfPoints).ToPointCloudVertices();
            
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

        }
        protected void CreateTileEmpty(int numberOfPoints)
        {
            ResetTest();
            lineMinLength = 4;

            pointCloudTarget = Example3DModels.TileEmpty(4, 2, 1, numberOfPoints, numberOfPoints, numberOfPoints).ToPointCloudVertices();
            //pointCloudTarget = Example3DModels.Tile(4, 2, 1, 5, 5, 5);


            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

        }
        protected void CreateRectangle()
        {
            ResetTest();
            lineMinLength = 2;

            pointCloudTarget = Example3DModels.Rectangle(4, 2, 2, 2).ToPointCloudVertices();
          
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

        }
        protected void CreateRectangleTranslated()
        {
            ResetTest();
            lineMinLength = 2;

            pointCloudTarget = Example3DModels.Rectangle(4, 2, 2, 2).ToPointCloudVertices();
            PointCloudVertices.Translate(pointCloudTarget, 3, 3, -1);
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

        }
        protected void ResetPointCloudForOpenGL()
        {
            this.pclSource = null;
            this.pclTarget = null;
            this.pclResult = null;

        }

        protected void ShowResultsInWindow_CubeNew(bool changeColor, bool showCornerLines)
        {

          
            //color code: 
            //Target is green
            //source : white
            //result : red

            //so - if there is nothing red on the OpenTK control, the result overlaps the target

            if (pointCloudSource != null)
            {
                this.pclSource = pointCloudSource.ToPointCloud();
                if(showCornerLines)
                    PointCloud.SetIndicesForCubeCorners(pclSource);

            }


            if (pointCloudTarget != null)
            {
                this.pclTarget = pointCloudTarget.ToPointCloud();
                if (showCornerLines)
                    PointCloud.SetIndicesForCubeCorners(pclTarget);
            }


            if (pointCloudResult != null)
            {
                this.pclResult = pointCloudResult.ToPointCloud();
                if (showCornerLines)
                    PointCloud.SetIndicesForCubeCorners(pclResult);
            }


            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointCloudOpenGL(pclSource, pclTarget, pclResult, true);
            fOTK.ShowDialog();


        }
        protected void ShowResultsInWindow_Cube(bool changeColor)
        {

            AddCubeLines();

            //color code: 
            //Target is green
            //source : white
            //result : red

            //so - if there is nothing red on the OpenTK control, the result overlaps the target
            if (changeColor)
            {
                if (pointCloudTarget != null)
                    PointCloudVertices.SetColorOfListTo(pointCloudTarget, Color.Green);
                PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.White);
            }


            if (pointCloudResult != null)
            {
                if (changeColor)
                    PointCloudVertices.SetColorOfListTo(pointCloudResult, Color.White);

            }


            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, false);
            fOTK.ShowDialog();


        }
        protected void AddCubeLines()
        {
            if (this.pointCloudSource != null)
                this.pointCloudSource.LinesGeometricalModels_Add(lineMinLength, System.Drawing.Color.FromArgb(255, 255, 255));
            if (this.pointCloudTarget != null)
                this.pointCloudTarget.LinesGeometricalModels_Add(lineMinLength, System.Drawing.Color.FromArgb(0, 255, 0));
            if (this.pointCloudResult != null)
                this.pointCloudResult.LinesGeometricalModels_Add(lineMinLength, System.Drawing.Color.FromArgb(255, 0, 0));

        }
        protected void ShowResultsInWindow_Cube_ProjectedPoints(bool changeColor)
        {


            AddCubeLines();

            if (pointCloudAddition1 != null)
            {
                PointCloudVertices.SetColorOfListTo(pointCloudAddition1, Color.Black);

            }


            //color code: green, red, violet axes
            //cube is white


            //so - if there is nothing red on the OpenTK control, the result overlaps the target
            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Black);

            if (pointCloudTarget != null)
            {
                PointCloudVertices.SetColorOfListTo(pointCloudTarget, Color.Red);
            }


            if (pointCloudResult != null)
            {
                PointCloudVertices.SetColorOfListTo(pointCloudResult, Color.Violet);

            }



            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, false);
            if (this.pointCloudAddition1 != null)
            {
                fOTK.AddVerticesAsModel("Cube", this.pointCloudAddition1);
            }
            if (pointCloudAddition2 != null)
            {

                fOTK.AddVerticesAsModel("Cube Transformed", this.pointCloudAddition2);
            }
            fOTK.ShowDialog();


        }
        protected void ShowPointCloudForOpenGL(PointCloud pcl)
        {

            OpenTKForm fOTK = new OpenTKForm();
            fOTK.ShowPointCloudOpenGL(pcl, true);
            fOTK.ShowDialog();

        }
        protected void Performance_Start()
        {
            CurrentTime = DateTime.Now;
           


        
        }
        protected double Performance_Stop(string nameOfTestcase)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - CurrentTime;

            System.Diagnostics.Debug.WriteLine("--Duration for " + nameOfTestcase + " : " + ts.TotalMilliseconds.ToString() + " - miliseconds");
            return ts.TotalMilliseconds/1000;

        }
    }
}
