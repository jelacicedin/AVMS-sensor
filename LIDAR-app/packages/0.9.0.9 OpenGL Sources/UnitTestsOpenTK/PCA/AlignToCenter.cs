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
    public class AlignToCenter : PCABase
    {

        [Test]
        public void ScannerMan_Translate()
        {

            Model myModel = new Model(path + "\\1.obj");
            this.pointCloudSource = myModel.PointCloudVertices;
            this.pointCloudResult = pca.AlignToCenter(pointCloudSource);


          
            ShowPointCloudsInWindow_PCAVectors(true);


        }

        [Test]
        public void Cuboid_Translate()
        {
            lineMinLength = 1;
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);

            this.pointCloudSource = myModel.PointCloudVertices;
            
            this.pointCloudResult = pca.AlignToCenter(pointCloudSource);


            this.ShowResultsInWindow_Cube(true);

          

        }
        [Test]
        public void Cuboid_Rotate()
        {
            
            double cubeSizeY = 2;
            int numberOfPoints = 3;

            Model myModel = Example3DModels.Cuboid("Cuboid", lineMinLength, cubeSizeY, numberOfPoints, System.Drawing.Color.White, null);

            this.pointCloudSource = myModel.PointCloudVertices;
            PointCloudVertices.RotateDegrees(pointCloudSource, 45, 45, 128);



            this.pointCloudResult = pca.AlignToCenter(pointCloudSource);


           

            this.ShowResultsInWindow_Cube(true);

            

        }

     
        
      

    }
}
