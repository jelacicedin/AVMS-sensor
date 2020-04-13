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
    public class CubeShowAxes : PCABase
    {

        [Test]
        public void Cuboid_New()
        {
            ResetPointCloudForOpenGL();

            
            
            List<Vector3> listVectors = Example3DModels.Cube_Corners(1, 1, 1);
            pclSource = PointCloud.FromVector3List(listVectors);
            
            this.pointCloudSource = PointCloudVertices.FromPointCloud(pclSource);

            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);

            
            pclSource = pointCloudSource.ToPointCloud();
            
            pca.PCA_OfPointCloud(pointCloudSource);
            //-----------Show in Window
            if (UIMode)
            {
                this.ShowResultsInWindow_CubeNew(true, true);
                //ShowResultsInWindow_Cube(true);
            }

        }
       

        [Test]
        public void Cuboid_RotateCenter_Axes()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);


            this.pointCloudSource = myModel.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);
            pointCloudSource.ResizeVerticesTo1();

            
            pca.PCA_OfPointCloud(pointCloudSource);
            //-----------Show in Window
            if (UIMode)
            {
                
                ShowResultsInWindow_Cube(true);
            }

        }



        [Test]
        public void Cuboid_Rotate_Axes()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;
            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);
            


            this.pointCloudSource = myModel.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 45);
           
            pca.PCA_OfPointCloud(pointCloudSource);

            //-----------Show in Window
            if (UIMode)
            {
                
                ShowPointCloudInWindow(pointCloudSource);
           
                
            }
        }
       
   
    
      
     

    }
}
