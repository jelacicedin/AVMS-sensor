using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;
using KDTreeRednaxela;

using MIConvexHull;
using VoronoiFortune;


namespace UnitTestsOpenTK.Triangulation
{
    [TestFixture]
    [Category("UnitTest")]
    public class TriangulateTest : TestBase
    {
        [Test]
        public void Face_VoronoiFortune_AsTriangles()
        {
            List<PointFortune> listPointsFortune = new List<PointFortune>();
            string fileNameLong = path + "\\KinectFace_1_15000.obj";

            pointCloudSource = IOUtils.ReadObjFile_ToPointCloud(fileNameLong);

            for (int i = 0; i < pointCloudSource.Count; i++)
            {
                PointFortune v = new PointFortune(pointCloudSource[i].Vector.X, pointCloudSource[i].Vector.Y, i);
                listPointsFortune.Add(v);

            }

            List<EdgeFortune> listEdges;

            Voronoi voronoi = new Voronoi(0.1f);

            listEdges = voronoi.GenerateVoronoi(listPointsFortune);
            
            List<Triangle> listTriangle = new List<Triangle>();
            for (int i = 0; i < listEdges.Count; i+=3)
            {
                EdgeFortune edge = listEdges[i];


                Triangle t = new Triangle();
               
                //t.IndVertices.Add(cell.Vertices[0].IndexInModel);
                //t.IndVertices.Add(cell.Vertices[1].IndexInModel);
                //t.IndVertices.Add(cell.Vertices[2].IndexInModel);
                listTriangle.Add(t);

                //myLines.Add(pointCloud[edge.PointIndex1]);
                //myLinesTo.Add(pointCloud[edge.PointIndex2]);

            }

            //-------------------
            Model myModel = new Model("Face");
            myModel.PointCloud = pointCloudSource.ToPointCloud();


            ShowModel(myModel);

        }
         [Test]
        public void Face_VoronoiFortune()
        {
            List<PointFortune> listPointsFortune = new List<PointFortune>();
            string fileNameLong = path + "\\KinectFace_1_15000.obj";
            
            pointCloudSource = IOUtils.ReadObjFile_ToPointCloud(fileNameLong);

            
            for (int i = 0; i < pointCloudSource.Count; i++)
            {
                PointFortune v = new PointFortune(pointCloudSource[i].Vector.X, pointCloudSource[i].Vector.Y, i);
                listPointsFortune.Add(v);

            }

            List<EdgeFortune> listEdges;
            
          
            Voronoi voronoi = new Voronoi(0.1f);

            listEdges = voronoi.GenerateVoronoi(listPointsFortune);
            List<Line> myLines = new List<Line>(); 
            
             
            for (int i = 0; i < listEdges.Count; i++)
            {
                EdgeFortune edge = listEdges[i];

                myLines.Add(new Line( pointCloudSource[edge.PointIndex1].Vector, pointCloudSource[edge.PointIndex2].Vector));

            }

            //-------------------
            Model myModel = new Model("Face");
            myModel.PointCloud = pointCloudSource.ToPointCloud();


            ShowModel(myModel);
            
        }
       
      
     
    }
}
