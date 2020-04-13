using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.LinearAlgebra
{
    [TestFixture]
    [Category("UnitTest")]
    public class MatrixOperationsTest : TestBase
    {
      
      
        [Test]
        public void TranslateCuboid()
        {
            this.pointCloudSource = PointCloudVertices.CreateCuboid(5, 8, 60);
            pointCloudResult = PointCloudVertices.CloneVertices(pointCloudSource);
            PointCloudVertices.Translate(pointCloudResult, 30, -20, 12);
            ShowVerticesInWindow(new byte[4] { 255, 255, 255, 255 }, new byte[4] { 255, 0, 0, 255 });
                      
        }
        [Test]
        public void RotateCuboid()
        {
            this.pointCloudSource = PointCloudVertices.CreateCuboid(5, 8, 60);
            pointCloudResult = PointCloudVertices.CloneVertices(pointCloudSource);

            Matrix3d R = new Matrix3d();
            R = R.RotationXYZDegrees(90, 124, -274);

            
            PointCloudVertices.Rotate(pointCloudResult, R);

            ShowVerticesInWindow(new byte[4] { 255, 255, 255, 255 }, new byte[4] { 255, 0, 0, 255 });
        }
        [Test]
        public void ScaleCuboid()
        {
            this.pointCloudSource = PointCloudVertices.CreateCuboid(5, 8, 60);
            pointCloudResult = PointCloudVertices.CloneVertices(pointCloudSource);

            PointCloudVertices.ScaleByVertex(pointCloudResult, new Vertex(1, 2, 3));
            ShowVerticesInWindow(new byte[4] { 255, 255, 255, 255 }, new byte[4] { 255, 0, 0, 255 });
        }

        [Test]
        public void RotateScaleTranslate()
        {
            this.pointCloudSource = PointCloudVertices.CreateCuboid(5, 8, 60);

            pointCloudResult = PointCloudVertices.CloneVertices(pointCloudSource);
            Matrix3d R = new Matrix3d();
            R = R.RotationXYZDegrees(90, 124, -274);

            PointCloudVertices.Rotate(pointCloudResult, R);
            PointCloudVertices.Translate(pointCloudResult, 30, -20, 12);
            PointCloudVertices.ScaleByVertex(pointCloudResult, new Vertex(1, 2, 3));
            ShowVerticesInWindow(new byte[4] { 255, 255, 255, 255 }, new byte[4] { 255, 0, 0, 255 });
        }
     
    }
}
