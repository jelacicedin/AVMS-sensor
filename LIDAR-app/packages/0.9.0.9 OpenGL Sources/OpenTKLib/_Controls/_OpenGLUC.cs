﻿// Pogramming by
//     Douglas Andrade ( http://www.cmsoft.com.br, email: cmsoft@cmsoft.com.br)
//               Implementation of most of the functionality
//     Edgar Maass: (email: maass@logisel.de)
//               Code adaption, changed to user control
//
//Software used: 
//    OpenGL : http://www.opengl.org
//    OpenTK : http://www.opentk.com
//
// DISCLAIMER: Users rely upon this software at their own risk, and assume the responsibility for the results. Should this software or program prove defective, 
// users assume the cost of all losses, including, but not limited to, any necessary servicing, repair or correction. In no event shall the developers or any person 
// be liable for any loss, expense or damage, of any type or nature arising out of the use of, or inability to use this software or program, including, but not
// limited to, claims, suits or causes of action involving alleged infringement of copyrights, patents, trademarks, trade secrets, or unfair competition. 
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;



namespace OpenTKLib
{
    public partial class OpenGLUC : System.Windows.Forms.UserControl
    {

        Matrix4d registrationMatrix;
        PointCloud pSource;
        PointCloud pTarget;
        PointCloud pResult;

        PointCloud pointCloudFirstAfterLoad;

        public OpenGLUC()
        {
            InitializeComponent();
            if (!GLSettings.IsInitializedFromSettings)
                GLSettings.InitFromSettings();

            
            InitComboBox();
            comboRenderMode.SelectedText = GLSettings.ViewMode;
            

            this.initGLControl();
            
            this.glControl1.Invalidate();
        }
        private void InitComboBox()
        {
            comboBoxFill.Items.Add("Points/Lines");
            comboBoxFill.Items.Add("Fill");
            if (GLSettings.Fill)
                comboBoxFill.SelectedIndex = 1;
            else
            {
                comboBoxFill.SelectedIndex = 0;
            }


            int iPrev = -1;
            for (int i = 0; i < Enum.GetValues(typeof(PrimitiveType)).GetLength(0); i++)
            {
                string strVal = Enum.GetValues(typeof(PrimitiveType)).GetValue(i).ToString();
                int iVal = (int)Enum.GetValues(typeof(PrimitiveType)).GetValue(i);
                if (iVal != iPrev)
                    this.comboRenderMode.Items.Add(strVal);
                iPrev = iVal;
            }
        }
      


        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Drawing.Color color = System.Drawing.Color.Red;

            //Model Model1 = Example3DModels.Sphere("Sphere", 2, 8, color, (System.Drawing.Bitmap)null);
            //Model myModel = Model1.ToModel();
            //ShowModel(myModel);
            
        }

       

     
        private void toolStripLoadModel_Click(object sender, EventArgs e)
        {
            string fileName = LoadFileDialog();
            Model myModel = new Model(fileName);
            pointCloudFirstAfterLoad = myModel.PointCloud.Clone();

            ShowModel(myModel);
            
        }
        public void LoadModelFromFile(string fileName)
        {
            Model myModel = new Model(fileName);
            ShowModel(myModel);

        }




        private void comboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDisplay = Enum.GetValues(typeof(PrimitiveType)).GetValue(comboRenderMode.SelectedIndex).ToString();

            GLSettings.ViewMode = strDisplay;

            this.OGLControl.GLrender.PrimitiveTypes = PrimitiveType.Points;
            for (int i = 0; i < Enum.GetValues(typeof(PrimitiveType)).GetLength(0); i++)
            {
                string strVal = Enum.GetValues(typeof(PrimitiveType)).GetValue(i).ToString();
                if (strVal == strDisplay)
                {
                    this.OGLControl.GLrender.PrimitiveTypes = (PrimitiveType)Enum.GetValues(typeof(PrimitiveType)).GetValue(i);
                    break;
                }

            }
            this.OGLControl.Invalidate();

        }
      
        private void comboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OGLControl.GLrender.SelectedModelIndex = comboModels.SelectedIndex - 1;
            //if (comboModels.SelectedText == "All")
            //{
            //    comboCameraModel.SelectedText = "Model";

            //}
            //else
            //{
            //    comboCameraModel.SelectedItem = comboCameraModel.Items[0];
            //    //comboCameraModel.SelectedIndex = 0;
            //    //SelectedPointCloud
            //}
            //comboCameraModel.Invalidate();
        }

        private void comboCameraModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboCameraModel.Text == "Camera")
            {
                this.OGLControl.ModelViewMode = ModelViewMode.Camera;
            }
            else
            {
                this.OGLControl.ModelViewMode = ModelViewMode.ModelMove;
            }
            
        }
        public void SaveSettings()
        {
            GLSettings.SaveSettings();

        }

    
       

        private void showAxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showAxesToolStripMenuItem.Text == "Show Axis")
            {
                GLSettings.ShowAxes = true;
                showAxesToolStripMenuItem.Text = "Hide Axis";
                glControl1.Refresh();
            }
            else if (showAxesToolStripMenuItem.Text == "Hide Axis")
            {
                GLSettings.ShowAxes = false;
                showAxesToolStripMenuItem.Text = "Show Axis";
                glControl1.Refresh();
            }
        }

    
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm sf = new AboutForm();
            sf.ShowDialog();

        }

         private void toolStripSavePointCloud_Click(object sender, EventArgs e)
        {
            this.OGLControl.SaveSelectedModel();
        }

         private void toolStripSavePointCloudAs_Click(object sender, EventArgs e)
        {
            this.OGLControl.SaveSelectedModelAs();
        }

         private void toolStripChangeColor_Click(object sender, EventArgs e)
        {
            if (comboModels.SelectedIndex >= 0)
            {
                ColorDialog colDiag = new ColorDialog();
                // Sets the initial color select to the current text color.

                // Update the text box color if the user clicks OK 
                if (colDiag.ShowDialog() == DialogResult.OK)
                {
                    RenderableObject pcr = this.OGLControl.GLrender.RenderableObjects[this.OGLControl.GLrender.SelectedModelIndex];
                    PointCloud pc = pcr.PointCloud;
                    pc.SetColor(new Vector3(colDiag.Color.R / 255f, colDiag.Color.G / 255f, colDiag.Color.B / 255f));
                    this.OGLControl.Refresh();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please load a 3D object first");

            }

            
        }



      
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(this);
            if (sf.ShowDialog() == DialogResult.OK)
            {
                this.OGLControl.GLrender.Draw();
                //RefreshView(true);
                
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.glControl1.MouseWheelActions(e);
            base.OnMouseWheel(e);
        }
     
        public OGLControl OGLControl
        {
            get
            {
                return this.glControl1;
            }
        }

        private void comboBoxFill_SelectedIndexChanged(object sender, EventArgs e)
        {
           // this.OGLControl.GLrender.FillMode = 
            if (comboBoxFill.Text == "Fill")
            {
                this.OGLControl.GLrender.PoygonModes = PolygonMode.Fill;
                GLSettings.Fill = true;
               
            }
            else
            {
                this.OGLControl.GLrender.PoygonModes = PolygonMode.Line;
                GLSettings.Fill = false;
            }
            this.glControl1.Refresh();
        }

        private void toolStripRemoveAllModelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllModels();
            this.glControl1.GLrender.ClearAllObjects();

            this.Refresh();


        }
        private void removeSelectedModelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.glControl1.GLrender.ClearSelectedModel();
            this.Refresh();
        }


        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showGridToolStripMenuItem.Text == "Show Grid")
            {
                GLSettings.ShowGrid = true;
                showGridToolStripMenuItem.Text = "Hide Grid";
                glControl1.Refresh();
            }
            else if (showGridToolStripMenuItem.Text == "Hide Grid")
            {
                GLSettings.ShowGrid = false;
                showGridToolStripMenuItem.Text = "Show Grid";
                glControl1.Refresh();
            }
        }
        private void showCameraFOV_Click(object sender, EventArgs e)
        {
            if (showCameraFOVMenuItem.Text == "Show Camera FOV")
            {
                GLSettings.ShowCameraFOV = true;
                showCameraFOVMenuItem.Text = "Hide Camera FOV";
                glControl1.Refresh();
            }
            else if (showCameraFOVMenuItem.Text == "Hide Camera FOV")
            {
                GLSettings.ShowCameraFOV = false;
                showCameraFOVMenuItem.Text = "Show Camera FOV";
                glControl1.Refresh();
            }
        }
     

        private void RefreshView_MakeCurrent()
        {
            //this.glControl1.MakeCurrent();

            //this.GLrender.Draw();
            //this.glControl1.Refresh();


        }
        private void RefreshView(bool forceRedraw)
        {
            //for (int i = 0; i < GLrender.Models3D.Count; i++)
            //{
            //    GLrender.Models3D[i].ForceRedraw = true;

            //}
            //this.glControl1.Invalidate();


        }

        private void comboTransparency_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (comboModels.SelectedIndex >= 0)
            //{
            //    double transp;
            //    double.TryParse(comboTransparency.Text, out transp);
            //    transp *= 0.01f;
            //    double alpha = 1 - transp;
            //    for (int i = 0; i < GLrender.Models3D[comboModels.SelectedIndex].Parts.Count; i++)
            //    {
            //        PointCloud.ChangeTransparency(GLrender.Models3D[comboModels.SelectedIndex].Pointcloud, alpha);

            //    }
            //}

            //RefreshView(true);

        }

        //private void checkBoxFill_CheckedChanged(object sender, EventArgs e)
        //{



        //}
        private void convexHullToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //int indexModel = comboModels.SelectedIndex;
            //Model3D myModel = GLrender.Models3D[comboModels.SelectedIndex];



            //List<Vector3d> myListVectors = PointCloud.ToVectors(myModel.Pointcloud);
            //ConvexHull3D convHull = new ConvexHull3D(myListVectors);

        }

        private void triangulateNearestNeighbourToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveNormalsOfCurrentModelToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Model3D myModel = GLrender.Models3D[comboModels.SelectedIndex];
            //CheckNormals(myModel);
            //string path = AppDomain.CurrentDomain.BaseDirectory + "TestData";


            //Model3D.Save_OBJ(myModel, path, myModel.Name + ".obj");

        }

        private void showNormalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (showNormalsToolStripMenuItem.Text == "Show Normals")
            //{
            //    GLSettings.ShowNormals = true;
            //    showNormalsToolStripMenuItem.Text = "Hide Normals";

            //    UpdataNormals();

            //    RefreshView(true);

            //}
            //else if (showNormalsToolStripMenuItem.Text == "Hide Normals")
            //{
            //    GLSettings.ShowNormals = false;
            //    showNormalsToolStripMenuItem.Text = "Show Normals";
            //    for (int i = 0; i < GLrender.Models3D.Count; i++ )
            //    {
            //        Model3D myModel = GLrender.Models3D[i];
            //        myModel.Pointcloud.LinesNormals = null;
            //    }

            //    RefreshView(true);

            //}



        }

        private void toolStripRegistration_Click(object sender, EventArgs e)
        {
            
           
        }
        private void toolStripShowRegistrationMatrix_Click(object sender, EventArgs e)
        {


        }
        private void toolStripCalculateRegistration1_2_Click(object sender, EventArgs e)
        {
            registrationMatrix = this.OGLControl.CalculateRegistrationMatrix1_2();
            registrationMatrix.Save(GLSettings.PathModels, "registrationMatrix.txt");


        }
        private void toolStripCalculateRegistrationLoaded_Moved_Click(object sender, EventArgs e)
        {
            if (pointCloudFirstAfterLoad != null)
            {
                registrationMatrix = this.OGLControl.CalculateRegistrationMatrix(this.pointCloudFirstAfterLoad);
                registrationMatrix.Save(GLSettings.PathModels, "registrationMatrix.txt");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Point cloud available");
            }
        }

        private void toolStripAlignUsingRegistrationMatrix_Click(object sender, EventArgs e)
        {
            
            registrationMatrix.FromFile(GLSettings.PathModels, "registrationMatrix.txt");
            this.OGLControl.AlignFirstModelFromRegistratioMatrix(registrationMatrix);
            this.OGLControl.Refresh();

            //registrationMatrix = this.OGLControl.CalculateRegistrationMatrix();

        }
        private void toolStripLoadTwoPCL_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadTwoClouds();
            DisplayObjects();

            this.Cursor = Cursors.Default;
        }


        private void toolStripPCA_Axes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //TestLoadTwoClouds();

            Clouds_AlignPCAAxes();
            this.Cursor = Cursors.Default;
        }

        private void toolStripICP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //TestLoadTwoClouds();
            Clouds_ICP();
            this.Cursor = Cursors.Default;
        }

        private void toolStripPCA_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //TestLoadTwoClouds();
            Clouds_PCA();
            this.Cursor = Cursors.Default;
        }
        private void Clouds_AlignPCAAxes()
        {
            if (!GetFirstTwoCloudsFromOpenGLControl())
                return;




            PointCloudVertices pointCloudTarget = PointCloudVertices.FromPointCloud(this.pSource);
            pointCloudTarget = PCA.RotateToOriginAxes(pointCloudTarget);


            PointCloudVertices pointCloudSource = PointCloudVertices.FromPointCloud(this.pTarget);

            PointCloudVertices pointCloudResult = PCA.RotateToOriginAxes(pointCloudSource);
            pResult = pointCloudResult.ToPointCloud();
            //pResult.SetColor(new OpenTK.Vector3(1, 0, 0));

            pointCloudResult.AddPointCloud(this.pTarget.ToPointCloudVertices());
            SaveResultCloudAndShow(pointCloudResult);
            //DisplayResultPointCloud();
            //DisplayObjects();


        }


        private void LoadTwoClouds()
        {

            string fileName1 = GLSettings.FileNamePointCloudLast1;
            string fileName2 = GLSettings.FileNamePointCloudLast2;


            //tabControlImages.SelectTab(0);


            Model myModel1 = new Model(GLSettings.PathModels, fileName1);

            pSource = myModel1.PointCloud;
            pointCloudFirstAfterLoad = pSource.Clone();
            //pSource.SetColor(new OpenTK.Vector3(0, 1, 0));

            pSource.FileNameShort = GLSettings.FileNamePointCloudLast1;
            pSource.Path = GLSettings.PathModels;
            pSource.FileNameLong = pSource.Path + "\\" + pSource.FileNameShort;



            Model myModel2 = new Model(GLSettings.PathModels, fileName2);

            pTarget = myModel2.PointCloud;
            //pTarget.SetColor(new OpenTK.Vector3(1, 1, 1));
            pTarget.FileNameShort = GLSettings.FileNamePointCloudLast2;
            pTarget.Path = GLSettings.PathModels;
            pTarget.FileNameLong = pTarget.Path + "\\" + pTarget.FileNameShort;



        }
        private void Clouds_PCA()
        {
            if (!GetFirstTwoCloudsFromOpenGLControl())
                return;


            PCA pca = new PCA();
            pca.MaxmimumIterations = 1;
            PointCloudVertices pointCloudResult = pca.AlignPointClouds_SVD( this.pSource.ToPointCloudVertices(), this.pTarget.ToPointCloudVertices());

            pointCloudResult.AddPointCloud(this.pTarget.ToPointCloudVertices());

            SaveResultCloudAndShow(pointCloudResult);
            this.registrationMatrix = pca.Matrix;
            registrationMatrix.Save(GLSettings.PathModels, "registrationMatrix.txt");

        }
        private void SaveResultCloudAndShow(PointCloudVertices pointCloudResult)
        {
            //-------------------------------------
            //save
            if (pointCloudResult != null)
            {

                string path = string.Empty;
                string fileNameShort = string.Empty;
                IOUtils.ExtractDirectoryAndNameFromFileName(pSource.FileNameLong, ref fileNameShort, ref path);
                pointCloudResult.Save(this.pSource.Path, "Result.obj");


                this.pResult = pointCloudResult.ToPointCloud();
                //pResult.SetColor(new OpenTK.Vector3(1, 0, 0));

                DisplayResultPointCloud();


            }

        }
        private void DisplayObjects()
        {
            this.OGLControl.GLrender.ClearAllObjects();

            this.ShowPointCloud(this.pSource);
            this.ShowPointCloud(this.pTarget);

        }
        private void DisplayResultPointCloud()
        {
            if (this.pResult != null)
            {
                RenderableObject pcr = new PointCloudRenderable();
                pcr.PointCloud = this.pResult;
                this.OGLControl.GLrender.AddRenderableObject(pcr);
            }

        }
        private void Clouds_ICP()
        {

            if (!GetFirstTwoCloudsFromOpenGLControl())
                return;



            //------------------
            //ICP
            ICPLib.IterativeClosestPointTransform icpInstance = new ICPLib.IterativeClosestPointTransform();
            icpInstance.Settings_Reset_RealData();

            icpInstance.ICPSettings.ICPVersion = ICP_VersionUsed.Scaling_Zinsser;
            icpInstance.ICPSettings.MaximumNumberOfIterations = 50;
            //icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela_ExcludePoints;
            icpInstance.ICPSettings.KDTreeMode = KDTreeMode.Rednaxela;


            PointCloudVertices pointCloudResult = icpInstance.PerformICP(this.pSource.ToPointCloudVertices(), this.pTarget.ToPointCloudVertices());

            pointCloudResult.AddPointCloud(this.pTarget.ToPointCloudVertices());
            SaveResultCloudAndShow(pointCloudResult);
            this.registrationMatrix = icpInstance.Matrix;
            registrationMatrix.Save(GLSettings.PathModels, "registrationMatrix.txt");

        }

        private bool GetFirstTwoCloudsFromOpenGLControl()
        {
            if (this.OGLControl.GLrender.RenderableObjects.Count < 2)
                return false;

            this.pSource = this.OGLControl.GLrender.RenderableObjects[0].PointCloud;
            this.pTarget = this.OGLControl.GLrender.RenderableObjects[1].PointCloud;

            return true;
        }
    }
}
