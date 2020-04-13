using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;


using System.Linq;
namespace UnitTestsOpenTK.Triangulation
{
    [TestFixture]
    [Category("UnitTest")]
    public class ConvexHullTest : TestBase
    {


        [Test]
        public void Cube_ConvexHull()
        {

            pointCloudSource = PointCloudVertices.CreateCube_Corners(0.1f);
            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
            List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

            ConvexHull3D convHull = new ConvexHull3D(myListVectors);

            Model myModel = CreateModel("Convex Hull", pointCloudSource.ToPointCloud(), convHull.Faces.ListFaces);


            ShowModel(myModel);
            System.Diagnostics.Debug.WriteLine("Number of faces: " + convHull.Faces.ListFaces.Count.ToString());

        }
        [Test]
        public void Cube_ConvexHull_RandomPoints()
        {

            pointCloudSource = PointCloud.CreateCube_RandomPointsOnPlanes(1, 10).ToPointCloudVertices();

            PointCloudVertices.SetColorOfListTo(pointCloudSource, Color.Red);
            List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

            ConvexHull3D convHull = new ConvexHull3D(myListVectors);

            Model myModel = CreateModel("Convex Hull", pointCloudSource.ToPointCloud(), convHull.Faces.ListFaces);

            ShowModel(myModel);

            System.Diagnostics.Debug.WriteLine("Number of faces: " + convHull.Faces.ListFaces.Count.ToString());

        }
     
        [Test]
        public void Bunny_Hull()
        {
            string fileNameLong = path + "\\bunny.xyz";
            pointCloudSource = IOUtils.ReadXYZFile_ToVertices(fileNameLong, false);
            PointCloudVertices.SetColorOfListTo(pointCloudSource, System.Drawing.Color.Red);

            List<Vector3d> myListVectors = PointCloudVertices.ToVectors(pointCloudSource);

            ConvexHull3D cHull = new ConvexHull3D(myListVectors);

            Model myModel = CreateModel("Bunny Hull", pointCloudSource.ToPointCloud(), cHull.Faces.ListFaces);

            ShowModel(myModel);

        }
      
     
    }
}
