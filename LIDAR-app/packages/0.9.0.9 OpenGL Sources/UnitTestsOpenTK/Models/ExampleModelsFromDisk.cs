using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.Models
{
    [TestFixture]
    [Category("UnitTest")]
    public class ExampleModelsFromDisk : TestBase
    {
        [Test]
        public void KinectFace_ObjFile()
        {
            string fileNameLong = path + "\\KinectFace_1_15000.obj";
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);
            fOTK.ShowDialog();


        }

        [Test]
        public void EmptyWindow()
        {
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.ShowDialog();


        }
   
        [Test]
        public void Bunny_obj_Triangulated()
        {
            string fileNameLong = path + "\\Bunny.obj";
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);
            fOTK.ShowDialog();


        }
        [Test]
        public void Bunny_xyz()
        {
            string fileNameLong = path + "\\Bunny.xyz";
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);
            fOTK.ShowDialog();


        }
        public void ShowDialog()
        {
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.ShowDialog();

        }

        [Test]
        public void Bunny_Face()
        {
            string fileNameLong = path + "\\Bunny.obj";
            OpenTKForm fOTK = new OpenTKForm();
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);

            fileNameLong = path + "\\KinectFace_1_15000.obj";
            fOTK.OpenGLControl.LoadModelFromFile(fileNameLong);

            fOTK.ShowDialog();


        }
    }
}
