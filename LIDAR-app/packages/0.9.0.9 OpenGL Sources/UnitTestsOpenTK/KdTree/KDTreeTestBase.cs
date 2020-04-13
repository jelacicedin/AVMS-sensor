using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTKLib;
using OpenTK;


namespace UnitTestsOpenTK.KDTree
{
   
    public class KDTreeTestBase 
    {
        protected List<int> expectedResultIndices;
        protected List<int> resultIndices;

        protected PointCloudVertices target;
        protected PointCloudVertices source;
        protected PointCloudVertices resultVertices;

        protected void CubeCornersTest_Reset()
        {
            GlobalVariables.ResetTime();
            resultVertices = new PointCloudVertices();

            target = PointCloudVertices.CreateCube_Corners(10);
            source = PointCloudVertices.CopyVertices(target);
            expectedResultIndices = new List<int>();
            resultIndices = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                expectedResultIndices.Add(i);
            }
        }
        protected void CheckResultCubeCorner()
        {
            GlobalVariables.ShowLastTimeSpan("KDTree Test");

            for (int i = 0; i < expectedResultIndices.Count; i++)
            {
                Assert.AreEqual(expectedResultIndices[i], resultIndices[i]);

            }
        }

     
    }
}
