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
    public class PCA2D : PCABase
    {
        
      
        [Test]
        public void PCA_2D_InWork()
        {
            List<Vector3d> pointsSource = new List<Vector3d>();

            Vector3d v = new Vector3d(1, 2, 0);
            pointsSource.Add(v);
            v = new Vector3d(2, 3, 0);
            pointsSource.Add(v);
            v = new Vector3d(3, 2, 0);
            pointsSource.Add(v);
            v = new Vector3d(4, 4, 0);
            pointsSource.Add(v);
            v = new Vector3d(5, 4, 0);
            pointsSource.Add(v);
            v = new Vector3d(6, 7, 0);
            pointsSource.Add(v);
            v = new Vector3d(7, 6, 0);
            pointsSource.Add(v);
            v = new Vector3d(9, 7, 0);
            pointsSource.Add(v);


            PCA pca = new PCA();

            List<Vector3d> listResult = pca.CalculatePCA(pointsSource, 0);

            ////expected result
            //List<Vector3d> listExpectedResult = new List<Vector3d>();
            //Vector3d v1 = new Vector3d(2.371258964, 2.51870600832217, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(0.605025583745627, 0.603160886338143, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(2.48258428755, 2.63944241997847, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(1.99587994658902, 2.11159364495307, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(2.94598120291464, 3.1420134339185, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(2.42886391124136, 2.58118069424077, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(1.74281634877673, 1.83713685698813, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(1.03412497746524, 1.06853497544495, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(1.51306017656077, 1.58795783010856, 0);
            //listExpectedResult.Add(v1);
            //v1 = new Vector3d(0.980404601156606, 1.01027324970724, 0);
            //listExpectedResult.Add(v1);

            //for (int i = 0; i < listExpectedResult.Count; i++)
            //{
            //    Assert.IsTrue(PointCloud.CheckCloud(listExpectedResult[i].X, listResult[i].X, this.threshold));
            //    Assert.IsTrue(PointCloud.CheckCloud(listExpectedResult[i].Y, listResult[i].Y, this.threshold));


            //}


            // ShowVector3dDInWindow(listResult);
            this.pointCloudSource = PointCloudVertices.FromVectors(pointsSource);
            this.pointCloudTarget = PointCloudVertices.FromVectors(listResult);

            List<Vector3d> listResult2 = pca.CalculatePCA(pointsSource, 1);
            this.pointCloudResult = PointCloudVertices.FromVectors(listResult2);

            if (UIMode)
                Show4PointCloudsInWindow(true);


        }
        
      

    }
}
