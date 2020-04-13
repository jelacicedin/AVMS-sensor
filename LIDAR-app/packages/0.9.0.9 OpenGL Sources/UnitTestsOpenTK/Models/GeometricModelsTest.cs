using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.Models
{
    [TestFixture]
    [Category("UnitTest")]
    public class GeometricModelsTest : TestBase
    {

        [Test]
        public void Cuboid_OldControl()
        {
            Model myModel = Example3DModels.Cuboid("Cuboid", 20f, 40f, 100, System.Drawing.Color.White, null);
            myModel.PointCloudVertices.ResizeVerticesTo1();
            ShowModel(myModel);
        }

        [Test]
        public void Cuboid_100()
        {

            this.pointCloudSource = PointCloudVertices.CreateCuboid(20f, 40f, 100);

//            myModel.Pointcloud.ResizeVerticesTo1();
            this.ShowResultsInWindow_Cube(true);
        }

       

        [Test]
        public void Cube_Corners()
        {
            
            List<Vector3> listVectors = Example3DModels.Cube_Corners(1, 1, 1);
            PointCloud pcl = PointCloud.FromVector3List(listVectors);
            PointCloud.SetIndicesForCubeCorners(pcl);


            ShowPointCloudForOpenGL(pcl);

            
        }
        [Test]
        public void Cube_56()
        {

            List<Vector3> listVectors = Example3DModels.CreateCube_RegularGrid_Empty(1, 3);
            PointCloud pcl = PointCloud.FromVector3List(listVectors);
            ShowPointCloudForOpenGL(pcl);


        }
        [Test]
        public void Cube_16()
        {
            CreateCube(4);
            this.ShowResultsInWindow_Cube(true);

        }
        [Test]
        public void Cube_32()
        {
            CreateCube(8);
            this.ShowResultsInWindow_Cube(true);

        }

    
       

     
     
    }
}
