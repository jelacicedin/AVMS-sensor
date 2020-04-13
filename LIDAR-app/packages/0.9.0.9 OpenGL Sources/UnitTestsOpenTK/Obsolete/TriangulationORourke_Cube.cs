using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;


using System.Linq;
namespace UnitTestsOpenTK
{
    [TestFixture]
    [Category("UnitTest")]
    public class TriangulationORourke_Cube : TestBase
    {

    
         [Test]
         public void Cube_Delaunay_RandomPoints()
         {
            
             pointCloudSource = PointCloudVertices.CreateCube_Corners(2);
             
             PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
             List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

             DelaunayTri delaunay = new DelaunayTri(myListVectors);

             Model myModel = CreateModel("Cube Delaunay", pointCloudSource.ToPointCloud(), delaunay.Faces.ListFaces);

             ShowModel(myModel);


         }
         [Test]
         public void Cube_DelaunayOLD_RandomPoints()
         {
             
             pointCloudSource = PointCloudVertices.CreateCube_Corners(2);

             //pointCloud = Vertices.CreateCube_Corners(0.1);
             PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
             List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

             DelaunayTri_Old delaunay = new DelaunayTri_Old(myListVectors);

             Model myModel = CreateModel("Cube Delaunay", pointCloudSource.ToPointCloud(), delaunay.Faces.ListFaces);

             ShowModel(myModel);


         }
         [Test]
         public void Cube_Voronoi_RandomPoints()
         {
             pointCloudSource = PointCloud.CreateCube_RandomPointsOnPlanes(1, 10).ToPointCloudVertices();

             //pointCloud = Vertices.CreateCube_Corners(0.1);
             PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
             List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

             DelaunayTri delaunay = new DelaunayTri();
             delaunay.Voronoi(myListVectors);

             Model myModel = CreateModel("Cube Voronoi", pointCloudSource.ToPointCloud(), delaunay.Faces.ListFaces);

             ShowModel(myModel);


         }
    
    }
}
