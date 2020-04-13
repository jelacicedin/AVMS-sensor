using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;

using UnitTestsOpenTK;

namespace UnitTestsOpenTK.PrincipalComponentAnalysis
{
    [TestFixture]
    [Category("UnitTest")]
    public class Cube : PCABase
    {
      

        [Test]
        public void Cuboid_VectorInWork()
        {

            CreateCube();

            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 98, 124);
            

            this.pointCloudResult = pca.AlignPointClouds_OneVector(pointCloudSource, pointCloudTarget, 0, 0);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(pointCloudResult, pointCloudTarget, 1, 1);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(pointCloudResult, pointCloudTarget, 2, 2);

            CheckResultTargetAndShow_Cube();
            

        }
      
    

       

        [Test]
        public void Cube_NotWorking()
        {
            
            lineMinLength = 5;
            this.pointCloudTarget = PointCloudVertices.CreateCube_RegularGrid_Empty(lineMinLength, 1);
            this.pointCloudSource = PointCloudVertices.CloneVertices(pointCloudTarget);

            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);


            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);
                      

            this.ShowResultsInWindow_Cube(true);
        

        }
        [Test]
        public void Cuboid_TranslateScale_SVD_NotWorking()
        {

            CreateCube();
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.4f);

            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
            //this.pointCloudSource = this.pointCloudResult;
            //this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            

            this.ShowResultsInWindow_Cube(true);

        }


        [Test]
        public void Cuboid_Rotate_SVD_NotWorking()
        {

            CreateCube();
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 123, -321);
           

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);
            //this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudResult, pointCloudTarget);

            

            this.ShowResultsInWindow_Cube(true);

        }
        [Test]
        public void Cuboid_TranslateRotateScale_SVD_NotWorking()
        {

            CreateCube();

            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 127, 287);
            PointCloudVertices.Translate(pointCloudSource, 3, 2, 5);
            PointCloudVertices.ScaleByFactor(pointCloudSource, 0.4f);

            this.pointCloudResult = pca.AlignPointClouds_SVD(pointCloudSource, pointCloudTarget);

            CheckResultTargetAndShow_Cube();



        }

     
        
      

    }
}
