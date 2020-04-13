// original from the Java matrix package JAMA http://math.nist.gov/javanumerics/jama/
// converted to C# by Ken Johnson, added units tests, (2010)
// http://www.codeproject.com/Articles/91458/MaNet-A-matrix-library-for-NET-Rational-Computing
//adapted to use OpenTK 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;

using OpenTK;
using OpenTKLib;

namespace UnitTestsOpenTK.LinearAlgebra
{
    [TestFixture]
 public class Matrix_IOTests
    {
        [Test]
        public void ToString_Test()
        {
            Matrix3d A = new Matrix3d();
            Assert.That(A.ToString() , Is.EqualTo( "[0 0;0 0]"));
            Assert.That(A.ToString("<", "{", "\n", ", ", "}", ">"), Is.EqualTo("<{0, 0}\n{0, 0}>"));
            A = new Matrix3d();
            Assert.That(A.ToString(), Is.EqualTo("[9 9;9 9]"));
            Assert.That(A.ToString("<", "{", "\n", ", ", "}", ">"), Is.EqualTo("<{9, 9}\n{9, 9}>"));

        }


        [Test]
        public void Parse_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.Parse("9 9\n9 9");
            Assert.That(A.ToArray(), Is.EqualTo(new Matrix3d().ToArray()));
            A = A.Parse("<{9, 9}\n{9, 9}>", "<", "{", "\n", ", ", "}", ">");
            Assert.That(A.ToArray(), Is.EqualTo(new Matrix3d().ToArray()));
        }

        [Test]
        [TestCase(2, 2, 1)]
        public void ToStringParse_CycleTest(int m, int n, int timesToRun)
        {
            Rectangular rand = new Rectangular();
            

            for (int i = 0; i < timesToRun; i++)
            {
                Matrix3d A = rand.Randomdouble(m, n);
                string strA = A.ToString();
                Matrix3d AReconstituted = new Matrix3d();
                AReconstituted.Parse(strA);
                Assert.That(AReconstituted.ToArray(), Is.EqualTo(A.ToArray()));
            }

            for (int i = 0; i < timesToRun; i++)
            {
                Matrix3d A = rand.Randomdouble(m, n);
                string strA = A.ToString("<", "{", "\n", ", ", "}", ">");
                Matrix3d AReconstituted = new Matrix3d(); 
                AReconstituted.Parse(strA, "<", "{", "\n", ", ", "}", ">");
                Assert.That(AReconstituted.ToArray(), Is.EqualTo(A.ToArray()));
            }

        }
        

        [Test]
        public void ToMatLabString_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.Parse("1 2\n3 4");
            Assert.That(A.ToMatLabString(), Is.EqualTo("[1 2;3 4]"));
        }


        [Test]
        public void ParseMatLab_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.ParseMatLab("[1 2;3 4]");
            Assert.That(A.ToArray(), Is.EqualTo(A.Parse("1 2\n3 4").ToArray()));
        }


        [Test]
        [TestCase(2, 2, 1)]
        public void ToMatLabStringParse_CycleTest(int m, int n, int timesToRun)
        {
            Rectangular rand = new Rectangular();

            for (int i = 0; i < timesToRun; i++)
            {
                Matrix3d A = rand.Randomdouble(m, n);
                string strA = A.ToMatLabString();
                Matrix3d AReconstituted = new Matrix3d(); 
                AReconstituted.ParseMatLab(strA);
                Assert.That(AReconstituted, Is.EqualTo(A));
            }
        }

        [Test]
        public void ToMathematicaString_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.Parse("1 2\n3 4");
            Assert.That(A.ToMathematicaString(), Is.EqualTo("{{1, 2}, {3, 4}}"));
        }


        [Test]
        public void ParseMathematica_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.ParseMathematica("{{1, 2}, {3, 4}}");
            Assert.That(A.ToArray(), Is.EqualTo(A.Parse("1 2\n3 4").ToArray()));
        }


        [Test]
        [TestCase(2, 2, 1)]
        public void ToMathematicaStringParse_CycleTest(int m, int n, int timesToRun)
        {
            Rectangular rand = new Rectangular();

            for (int i = 0; i < timesToRun; i++)
            {
                Matrix3d A = rand.Randomdouble(m, n);
                string strA = A.ToMathematicaString();
                Matrix3d AReconstituted = new Matrix3d(); 
                AReconstituted.ParseMathematica(strA);
                Assert.That(AReconstituted.ToArray(), Is.EqualTo(A.ToArray()));
            }
        }

       
        [Test]
        public void FromDataTable_Test()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col0", typeof(double));
            dt.Columns.Add("Col1", typeof(double));
            dt.Rows.Add(1, 2);
            dt.Rows.Add(3, 4);
            dt.Rows.Add(5, 6);

            Matrix3d A = new Matrix3d(); 
            A.FromDataTable(dt);
            Assert.That(A.ToMatLabString(), Is.EqualTo("[1 2;3 4;5 6]"));


        }


        [Test]
        public void ToDataTable_Test()
        {
            Matrix3d A = new Matrix3d(); 
            A.ParseMatLab("[1 2;3 4;5 6]");
            DataTable dt = A.ToDataTable();
            Assert.That((double)dt.Rows[0][0], Is.EqualTo(1)) ;
            Assert.That((double)dt.Rows[0][1], Is.EqualTo(2));
            Assert.That((double)dt.Rows[1][0], Is.EqualTo(3));
            Assert.That((double)dt.Rows[1][1], Is.EqualTo(4));
            Assert.That((double)dt.Rows[2][0], Is.EqualTo(5));
            Assert.That((double)dt.Rows[2][1], Is.EqualTo(6));


        }

        [Test]
        [TestCase(2, 3, 4)]
        public void ToFromDataTable_CycleTest(int m, int n, int timesToRun)
        {
            Rectangular rand = new Rectangular();

               for (int i = 0; i < timesToRun; i++)
               {
                   Matrix3d A = rand.Randomdouble(m, n);
                   DataTable dt = A.ToDataTable();
                   Matrix3d AReconstituted = A.FromDataTable(dt);
                   Assert.That(AReconstituted, Is.EqualTo(A));

               }

        }



     

    }
}
