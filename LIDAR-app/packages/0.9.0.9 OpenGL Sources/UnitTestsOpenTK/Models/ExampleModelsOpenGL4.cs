using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;
using System.Threading;
using OpenTKLib.FastGLControl;

namespace UnitTestsOpenTK.Models
{
    [TestFixture]
    [Category("UnitTest")]
    public class ExampleModelsOpenGL4 : TestBase
    {
        
        System.Timers.Timer formOpenTKTimer = new System.Timers.Timer();
        private delegate void UpdateOpenGLDelegeate();
 

         [Test]
        public void BunnyNew()
        {

            
            OpenTKFormAlternative fOTK = new OpenTKFormAlternative();

            Model myModel = new Model(path + "\\Bunny.obj");
            fOTK.AddModel(myModel);
            fOTK.ShowDialog();
        }
         [Test]
         public void BunnyFace()
         {

             OpenTKFormAlternative fOTK = new OpenTKFormAlternative();

         
             fOTK.AddModel(new Model(path + "\\Bunny.obj"));
           
             fOTK.AddModel(new Model(path + "\\KinectFace_1_15000.obj"));
             fOTK.ShowDialog();
         }
        
       
        [Test]
        public void BunnyModel3D_Old()
        {
            
            Model myModel = new Model(path + "\\Bunny.obj");
            this.pointCloudSource = myModel.PointCloudVertices;


            PointCloud pgl = this.pointCloudSource.ToPointCloud();
            PointCloudRenderable pcr = new PointCloudRenderable();
            pcr.PointCloud = pgl;


            OpenTKFormAlternative fOTK = new OpenTKFormAlternative();

            fOTK.ReplaceRenderableObject(pcr);
            fOTK.ShowDialog();
        }
        [Test]
        public void Cube()
        {
            Model myModel = Example3DModels.Cuboid("Cuboid", 20f, 40f, 100, System.Drawing.Color.White, null);
            //Model3D myModel = Example3DModels.Cuboid("Cuboid", 1f, 2f, 100, System.Drawing.Color.White, null);
            pointCloudSource = myModel.PointCloudVertices;
            PointCloud pgl = this.pointCloudSource.ToPointCloud();
            PointCloudRenderable pcr = new PointCloudRenderable();
            pcr.PointCloud = pgl;

            OpenTKFormAlternative fOTK = new OpenTKFormAlternative();

            //UnitCube uc = new UnitCube();
            fOTK.ReplaceRenderableObject(pcr);
            fOTK.ShowDialog();


        }
        [Test]
        public void Cube1()
        {

            OpenTKFormAlternative fOTK = new OpenTKFormAlternative();
            UnitCube uc = new UnitCube();
            fOTK.ReplaceRenderableObject(uc);

            fOTK.ShowDialog();

        }

        [Test]
        public void EmptyWindow()
        {
            
            OpenTKFormAlternative fOTK = new OpenTKFormAlternative();
          
            fOTK.ShowDialog();

        }

         [Test]
            public void Face()
         {
           
             OpenTKFormAlternative fOTK = new OpenTKFormAlternative();

         
             fOTK.AddModel(new Model(path + "\\KinectFace_1_15000.obj"));
             fOTK.ShowDialog();

             fOTK.ShowDialog();

         }
      
        

         [Test]
         public void FaceOld()
         {
             Model myModel = new Model(path + "\\KinectFace_1_15000.obj");
             this.pointCloudSource = myModel.PointCloudVertices;
            

             PointCloud pgl = this.pointCloudSource.ToPointCloud();
             PointCloudRenderable pcr = new PointCloudRenderable();
             pcr.PointCloud = pgl;


             OpenTKFormAlternative fOTK = new OpenTKFormAlternative();
             
             fOTK.ReplaceRenderableObject(pcr);
             fOTK.ShowDialog();

         }
     
      
        private void NewOpenTKDialog()
        {

            if (GlobalVariables.FormFast != null)
            {
                GlobalVariables.FormFast.Close();
                GlobalVariables.FormFast.Dispose();
            }

            GlobalVariables.FormFast = new OpenTKFormAlternative();
            GlobalVariables.FormFast.Show();
        }

    
      
     
    }
}
