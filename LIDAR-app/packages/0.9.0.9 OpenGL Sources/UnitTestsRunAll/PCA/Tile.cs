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
    public class Tile : PCABase
    {
        [Test]
        public void ShowAxes()
        {
            
            CreateTile(1);
            pointCloudTarget = null;
            pca.PCA_OfPointCloud(pointCloudSource);

            //-----------Show in Window
            if (UIMode)
            {

                ShowResultsInWindow_Cube(true);
            }
            //----------------check Result
            expectedResultCloud.Add(new Vertex(2, 0, 0));
            expectedResultCloud.Add(new Vertex(0, 1, 0));
            expectedResultCloud.Add(new Vertex(0, 0, 0.5f));

            Assert.IsTrue(PointCloudVertices.CheckCloudAbs(expectedResultCloud, pointCloudSource.PCAAxes, this.threshold)) ;

           
        }

   
        [Test]
        public void AlignToItself()
        {
            CreateTile(1);
            pointCloudSource.ResizeVerticesTo1();
            pointCloudTarget.ResizeVerticesTo1();

            this.pointCloudResult = pca.AlignPointClouds_SVD( pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();

        }
       
        [Test]
        public void Translate()
        {

            CreateTile(1);
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);

            this.pointCloudResult = pca.AlignPointClouds_SVD( pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }

        [Test]
        public void Rotate()
        {

            CreateTile(1);
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 124, 297);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }
        [Test]
        public void Scale()
        {

            CreateTile(1);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.8f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }
        [Test]
        public void TranslateRotateScale()
        {

            CreateTile(1);
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 124, 297);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.8f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();
        }
     
      
      

    }
}
