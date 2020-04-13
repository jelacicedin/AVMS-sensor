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
    public class PCANormalsModels : TestBase
    {
        [Test]
        public void Bunny()
        {
            ResetTest();

            string fileNameLong = path + "\\bunny.xyz";
            pointCloudSource = IOUtils.ReadXYZFile_ToVertices(fileNameLong, false);
            PointCloudVertices.SetColorOfListTo(pointCloudSource, System.Drawing.Color.Red);
            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 4, false, false);
            ShowVerticesNormals(normals);
        }
   
          [Test]
        public void Face()
        {
            ResetTest();

            string fileNameLong = path + "\\KinectFace_1_15000.obj";
            pointCloudSource = IOUtils.ReadObjFile_ToPointCloud(fileNameLong);


            PointCloudVertices.ResetCentroid(pointCloudSource, true);

            PointCloudVertices.SetColorOfListTo(pointCloudSource, System.Drawing.Color.Red);
            List<Vector3> normals = Model.CalculateNormals_PCA(pointCloudSource, 5, false, true);
            ShowVerticesNormals(normals);
        }
         

    }
}
