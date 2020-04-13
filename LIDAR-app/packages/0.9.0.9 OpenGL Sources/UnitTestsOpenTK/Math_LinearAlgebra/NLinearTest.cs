using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


using OpenTKLib;
using OpenTK;
using NLinear;
using System.Numerics;

namespace UnitTestsOpenTK.LinearAlgebra
{
    [TestFixture]
    [Category("UnitTest")]
    public class NLinearTest : TestBase
    {


        [Test]
        public void MatrixReal()
        {
            //Declare a 4x4 matrix
            Matrix4d4<double> m44 = new Matrix4d4<double>(6, -7, 10, 4, 0, 3, -1, 8, 0, 5, -7, 0, 1, 2, 7, 6);
            //Declare an identity matrix
            Matrix4d4<double> id = Matrix4d4<double>.Identity(1);

            System.Diagnostics.Debug.WriteLine(m44 * id == m44); //True
            System.Diagnostics.Debug.WriteLine(id * m44 == m44); //True

            //Declare a 3x3 matrix
            Matrix3d3<double> m33 = new Matrix3d3<double>(6, -7, 10, 0, 3, -1, 0, 5, -7);

            Matrix3d3<double> m33Inv = m33.Inverse(1);
            Matrix3d3<double> id2 = m33 * m33Inv;

            System.Diagnostics.Debug.WriteLine(id2 == Matrix3d3<double>.Identity(1)); //True

            //Console.ReadKey();

        }

        [Test]
        public void MatrixComplex()
        {
            var i = Complex.ImaginaryOne;

            //Declare a 4x4 matrix
            Matrix4d4<Complex> m44 = new Matrix4d4<Complex>(1, 1, 1, 1, 1, i, -1, -i, 1, -i, 1, -1, 1, -i, -1, i);

            //Declare an identity matrix
            Matrix4d4<Complex> id = Matrix4d4<Complex>.Identity(1);

            System.Diagnostics.Debug.WriteLine(id * m44 == m44);//true

            //Console.ReadKey();
        }
        [Test]
        public void BigInteger()
        {
            //Declare two unit vectors e1, e2
            Vector3d<BigInteger> e1 = new Vector3d<BigInteger>(1, 0, 0);
            Vector3d<BigInteger> e2 = new Vector3d<BigInteger>(0, 1, 0);

            Vector3d<BigInteger> e3 = e1.Cross(e2);

            System.Diagnostics.Debug.WriteLine(e3);

           // Console.ReadKey();
        }
        [Test]
        public void Vector3dFloat()
        {
            //Declare two unit vectors e1, e2
            Vector3d<double> e1 = new Vector3d<double>(1, 0, 0);
            Vector3d<double> e2 = new Vector3d<double>(0, 1, 0);

            Vector3d<double> e3 = e1.Cross(e2);

            System.Diagnostics.Debug.WriteLine(e3);

            //Console.ReadKey();
        }
        [Test]
        public void Vector2Int()
        {
            //Declare two unit vectors e1, e2
            Vector2<int> v1 = new Vector2<int>(1, 0);
            Vector2<int> v2 = new Vector2<int>(0, 1);

            int proj = v1.Dot(v2);
            proj = v1 ^ v2;

            //Check if proj == 0
            System.Diagnostics.Debug.WriteLine(proj == 0); //True

            //Console.ReadKey();
        }
    }
}
