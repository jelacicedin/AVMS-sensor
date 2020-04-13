using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;


namespace UnitTestsOpenTK.KDTree
{
    [TestFixture]
    [Category("UnitTest")]
    public class KDTreeTest : KDTreeTestBase
    {
        private void CreateTestPoints()
        {
            target = new PointCloudVertices();
            target.Add(new Vertex(0.1, 0, 0));
            target.Add(new Vertex(0.2, 0, 0));
            target.Add(new Vertex(0, 0.3, 0));
            target.Add(new Vertex(0, 0.4, 0));
            target.Add(new Vertex(0, 0, 0.5));
            target.Add(new Vertex(0, 0, 0.6));
            for (int i = 0; i < target.Count; i++)
            {
                target[i].IndexInModel = i;
            }

           
        }
        [Test]
        public void KDTree_Rednaxela_Translation()
        {
            CubeCornersTest_Reset();
            PointCloudVertices.Translate(source, 10, 10, -10);

            GlobalVariables.ResetTime();

            KDTreeVertex kv = new KDTreeVertex();
            kv.BuildKDTree_Rednaxela(target);
            GlobalVariables.ShowLastTimeSpan("Build KDTree Rednaxela");

            this.resultVertices = kv.FindNearest_Rednaxela_ExcludePoints(source, target, false);
            //GlobalVariables.ShowLastTimeSpan("Find neighbours");




        }
         [Test]
        public void KDTree_Rednaxela_Translate()
        {
            CreateTestPoints();
            source = target.Clone();
            PointCloudVertices.Translate(source, 10, 10, -10);


            GlobalVariables.ResetTime();

            KDTreeVertex kv = new KDTreeVertex();
            kv.BuildKDTree_Rednaxela(target);
            GlobalVariables.ShowLastTimeSpan("Build KDTree Rednaxela");

            this.resultVertices = kv.FindNearest_Rednaxela_ExcludePoints(source, target, false);


            Assert.IsTrue(kv.MeanDistance < 17.33);

        }
         [Test]
         public void KDTree_Rednaxela_ShuffleFix()
         {

             CreateTestPoints();

             source = new PointCloudVertices();
             source.Add(new Vertex(0, 0, 0.5));
             source.Add(new Vertex(0, 0, 0.6));
             source.Add(new Vertex(0.1, 0, 0));
             source.Add(new Vertex(0.2, 0, 0));
             source.Add(new Vertex(0, 0.3, 0));
             source.Add(new Vertex(0, 0.4, 0));
             for (int i = 0; i < source.Count; i++)
             {
                 source[i].IndexInModel = i;
             }
             
            
             //PointCloudVertices.Shuffle(source);


             GlobalVariables.ResetTime();

             KDTreeVertex kv = new KDTreeVertex();
             kv.KDTreeMode = KDTreeMode.Rednaxela;

             kv.BuildKDTree_Rednaxela(target);
             GlobalVariables.ShowLastTimeSpan("Build KDTree Rednaxela");

             this.resultVertices = kv.FindNearest_Rednaxela_ExcludePoints(source, target, false);
          
             Assert.IsTrue(kv.MeanDistance == 0);



         }

         [Test]
         public void KDTree_Rednaxela_ShuffleRandom()
         {

             CreateTestPoints();
             source = target.Clone();
            

             PointCloudVertices.Shuffle(source);


             GlobalVariables.ResetTime();

             KDTreeVertex kv = new KDTreeVertex();
             kv.KDTreeMode = KDTreeMode.Rednaxela;

             kv.BuildKDTree_Rednaxela(target);
             GlobalVariables.ShowLastTimeSpan("Build KDTree Rednaxela");

             this.resultVertices = kv.FindNearest_Rednaxela_ExcludePoints(source, target, false);

             Assert.IsTrue(kv.MeanDistance == 0);



         }

        [Test]
        public void KDTreeTest_Stark()
        {

            CubeCornersTest_Reset();

            KDTree_Stark tree = KDTree_Stark.Build(target);

            for (int i = 0; i < target.Count; i++)
            {
                int indexNearest = tree.FindNearest_ExcludeTakenPoints(target[i]);
                resultVertices.Add(target[indexNearest]);
            }

            GlobalVariables.ShowLastTimeSpan("KDTree RednaxelaTest");

        }
     
        
    
     
        [Test]
        public void KDTreeTest_Stark_TranslationTrial2()
        {
            GlobalVariables.ResetTime();
           
            PointCloudVertices target = PointCloudVertices.CreateCube_Corners(10);
            PointCloudVertices source = PointCloudVertices.CopyVertices(target);

            PointCloudVertices.Translate(source, 100, 100, 100);

            PointCloudVertices result = new PointCloudVertices();

            KDTreeVertex kv = new KDTreeVertex();
            kv.BuildKDTree_Stark(target);
            kv.ResetVerticesLists(target);
            kv.NearestPointIndices_Stark(source);

         
            GlobalVariables.ShowLastTimeSpan("KDTree RednaxelaTest");

            
            


        }
        [Test]
        public void KDTreeTest_Stark_Translation_NotReallyWorking()
        {
            GlobalVariables.ResetTime();
            
            PointCloudVertices target = PointCloudVertices.CreateCube_Corners(10);
            PointCloudVertices source = PointCloudVertices.CopyVertices(target);

            PointCloudVertices.Translate(source, 100, 100, 100);

            PointCloudVertices result = new PointCloudVertices();
            KDTree_Stark tree = KDTree_Stark.Build(target);

            for (int i = 0; i < source.Count; i++)
            {

                int indexNearest = tree.FindNearest(source[i]);
                result.Add(target[indexNearest]);

            }
            //as it does not exclude the found points, the result contains the nearest vertex, which is the point 5,5,5

            GlobalVariables.ShowLastTimeSpan("KDTree RednaxelaTest");


        }
         [Test]
         public void KDTreeTest_StarkBruteForce()
         {

             target = PointCloud.CreateCube_RandomPointsOnPlanes(1, 1000).ToPointCloudVertices();



             PointCloudVertices source = PointCloudVertices.CopyVertices(target);
             PointCloudVertices.RotateVertices30Degrees(source);

             PointCloudVertices result = new PointCloudVertices();
             

             for (int i = 0; i < source.Count; i++)
             {
                 KDTree_Stark tree = KDTree_Stark.Build(target);
                 int indexNearest = tree.FindNearest(source[i]);
                 result.Add(target[indexNearest]);
                 target.RemoveAt(indexNearest);

             }


         }
   
      
    }
}
