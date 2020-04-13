using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.Performance
{
    [TestFixture]
    [Category("UnitTest")]
    public class PCA_Bunny : PCABase
    {
        public PCA_Bunny()
        {
            UIMode = false;
        }
        [Test]
        public void Rotate_65()
        {

            ResetTest();
            Model model3DTarget = new Model(path + "\\bunny.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);
           
            PointCloudVertices.RotateDegrees(pointCloudSource, 60, 60, 65);
            //R = R.RotationXYZRadiants(65, 65, 65);


            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);
           
            CheckResultTargetAndShow_Cloud(this.threshold);

            double executionTime = Performance_Stop("PCA_Bunny_Rotate");//3 seconds on i3_2121 (3.3 GHz)
            Assert.IsTrue(executionTime < 3);
        }
         [Test]
        public void Rotate_Custom()
        {

            ResetTest();
            Model model3DTarget = new Model(path + "\\bunny.obj");
            this.pointCloudTarget = model3DTarget.PointCloudVertices;

            this.pointCloudSource = PointCloudVertices.CopyVertices(pointCloudTarget);

            PointCloudVertices.RotateDegrees(pointCloudSource, 124, 124, 124);
         

            this.pointCloudResult = pca.AlignPointClouds_SVD(this.pointCloudSource, this.pointCloudTarget);

            CheckResultTargetAndShow_Cloud(this.threshold);
             double executionTime = Performance_Stop("PCA_Bunny_Rotate");//5 seconds on i3_2121 (3.3 GHz)
             Assert.IsTrue(executionTime < 5);

        }

    

    }
}
