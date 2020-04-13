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
    public class Persons : PCABase
    {

        //Model3D model3DTarget = new Model3D(path + "\\KinectFace_1_15000.obj");

        [Test]
        public void Faces_SVD()
        {
            Model model3DTarget = new Model(path + "\\P0_01.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            Model model3DSource = new Model(path + "\\P0_03.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;
           

            pca.MaxmimumIterations = 1;
            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);

        }
        [Test]
        public void Faces_AlignToOriginAxes()
        {
            Model model3DTarget = new Model(path + "\\P0_01.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;
            Model model3DSource = new Model(path + "\\P0_03.obj");
            this.pointCloudSource = model3DSource.PointCloudVertices;

            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);
            pointCloudSource = PCA.RotateToOriginAxes(pointCloudSource);

            pca.MaxmimumIterations = 1;
            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);


            CheckResultTargetAndShow_Cloud(this.threshold);

        }

   
        
      

    }
}
