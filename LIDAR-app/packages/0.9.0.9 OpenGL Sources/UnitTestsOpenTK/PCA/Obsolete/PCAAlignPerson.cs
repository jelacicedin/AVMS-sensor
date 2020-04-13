﻿using System;
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
    public class PCAAlignPerson : PCABase
    {

        [Test]
        public void ScannerPerson_SVD_Rotate()
        {
            Model model3DTarget = new Model(path + "\\1.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 10, 25);
            

            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void ScannerPerson_V_Rotate()
        {
            Model model3DTarget = new Model(path + "\\1.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            //PointCloud.ResizeVerticesTo1(pointCloudTarget);

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            //Vertices.TranslateVertices(pointCloudTarget, 0, -300, 0);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 10, 25);


            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 1, 1);
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 2, 2);
            
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);
            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);
            

            //this.pointCloudSource = Vertices.CopyVertices(pointCloudResult);
            //this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 1, 1);


           // this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);

            //this.pointCloudResult = pca.AlignPointClouds_OneVector(pointCloudResult, this.pointCloudTarget, 1, 2);

            //pointCloudResult = null;

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
      
        [Test]
        public void ScannerPerson_V_SVD_Rotate()
        {
            Model model3DTarget = new Model(path + "\\1.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
           
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
            //Vertices.TranslateVertices(pointCloudTarget, 0, -300, 0);
            PointCloudVertices.RotateDegrees(pointCloudSource, 25, 10, 25);
            //Vertices.Rotate(pointCloudSource, 25, 90, 25);

            this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudSource, this.pointCloudTarget, 0, 0);
            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudResult);

            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            // this.pointCloudResult = pca.AlignPointClouds_OneVector(this.pointCloudResult, this.pointCloudTarget, 0, 0);

            //this.pointCloudResult = pca.AlignPointClouds_OneVector(pointCloudResult, this.pointCloudTarget, 1, 2);

            //pointCloudResult = null;

            
            ShowPointCloudsInWindow_PCAVectors(true);

            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));

        }

     
        
      

    }
}
