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
    public class MathTest
    {
         private static string path;
         public MathTest()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "TestData";
            //string str = 

        }


         [Test]
   
        
         public void Matrix3dDTest()
         {
             Matrix3d a = new Matrix3d();
             

             a[0, 0] = 2.8f;
             a[0, 1] = 1.26f;
             a[0, 2] = -2.04f;
             
             a[1, 0] = 1.26f;
             a[1, 1] = 1.15f;
             a[1, 2] = -1.877f;

             a[2, 0] = -2.04f;
             a[2, 1] = -1.877f;
             a[2, 2] = 3.04f;


             //Matrix3d a = new Matrix3d();

             Matrix3d c;

             double[,] Harray = a.ToDoubleArray();
             double[,] Uarray = new double[3, 3];
             double[,] VTarray = new double[3, 3];
             double[] eigenvalues = new double[3];
             

             //trial 3:
             alglib.svd.rmatrixsvd(Harray, 3, 3, 2, 2, 2, ref eigenvalues, ref Uarray, ref VTarray);

             Vector3d EV = new Vector3d(Convert.ToSingle(eigenvalues[0]), Convert.ToSingle(eigenvalues[1]), Convert.ToSingle(eigenvalues[2]));
             Matrix3d S = new Matrix3d();
             S[0, 0] = EV.X;
             S[1, 1] = EV.Y;
             S[2, 2] = EV.Y;

             Matrix3d U = new Matrix3d();
             U.FromDoubleArray(Uarray);
             Matrix3d UT = Matrix3d.Transpose(U);
             c = Matrix3d.Mult(U, UT);//should give I Matrix
             Matrix3d VT = new Matrix3d();
             VT.FromDoubleArray(VTarray);
             
             Matrix3d V = Matrix3d.Transpose(VT);
             c = Matrix3d.Mult(V, VT);//should give I Matrix
             //check solution

             //Matrix3d checkShouldGiveI = Matrix3d.Mult(U, VT);
             Matrix3d R = Matrix3d.Mult(U, VT);

             Matrix3d test = Matrix3d.Mult(S, VT);
             test = Matrix3d.Mult(U, test);
             Assert.That(test, Is.EqualTo(a).Within(1e-7f));

             Matrix3d RT = Matrix3d.Transpose(R);

             c = Matrix3d.Mult(RT, R);//should give I Matrix
             
             test = Matrix3d.Mult(a, V);
             test = Matrix3d.Mult(U, a);

         }
     
    }
}
