using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using ICPLib;

namespace UnitTestsOpenTK.InWork
{
    [TestFixture]
    [Category("UnitTest")]
    public class ICPTestOld : TestBaseICP
    {
        
        [Test]
        public void ICP_Show_KnownTransformation()
        {

            OpenTKForm fOTK = new OpenTKForm();
            fOTK.OpenGLControl.RemoveAllModels();
            string fileNameLong = path + "\\KinectFace_1_15000.obj";
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);

            fileNameLong = path + "\\transformed.obj";
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);
            fOTK.ICP_OnCurrentModels();
            fOTK.ShowDialog();


        }
        [Test]
        public void Translation_Horn_Old()
        {

            ResetICP();
            IterativeClosestPointTransform.Instance.ICPSettings.ICPVersion = ICP_VersionUsed.Horn;

            meanDistance = ICPTestData.Test1_Translation(ref pointCloudTarget, ref pointCloudSource, ref pointCloudResult);
            Assert.IsTrue(PointCloudVertices.CheckCloud(pointCloudTarget, pointCloudResult, this.threshold));


            OpenTKForm fOTK = new OpenTKForm();
            fOTK.Show3PointClouds(pointCloudSource, pointCloudTarget, pointCloudResult, true);
            fOTK.ShowDialog();

        }
        [Test]
        public void ICP_Face_Old()
        {

            OpenTKForm fOTK = new OpenTKForm();
            fOTK.IPCOnTwoPointClouds();
            fOTK.ShowDialog();

        }

     
    }
}
