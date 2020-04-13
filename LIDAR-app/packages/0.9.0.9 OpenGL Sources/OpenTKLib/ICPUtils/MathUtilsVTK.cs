/*=========================================================================

  Program:   Visualization Toolkit
  Module:    $RCSfile: vtkMath.cxx,v $

  Copyright (c) Ken Martin, Will Schroeder, Bill Lorensen
  All rights reserved.
  See Copyright.txt or http://www.kitware.com/Copyright.htm for details.

     This software is distributed WITHOUT ANY WARRANTY; without even
     the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
     PURPOSE.  See the above copyright notice for more information.

=========================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Windows.Media;
using OpenTK;
using OpenTKLib;

namespace ICPLib
{ 
  //  class TypeRange
  //{
  
  //  int Type;
  //  double Min;
  //  double Max;
  //};

    public class MathUtilsVTK
    {
       

        static long Seed = 2247; 

        //
        // some constants we need
        //
        static long VTK_K_A = 16807;
        static long VTK_K_M = 2147483647;/* Mersenne prime 2^31 -1 */
        static long VTK_K_Q = 127773;                /* VTK_K_M div VTK_K_A */
        static long VTK_K_R = 2836;                /* VTK_K_M mod VTK_K_A */
        static double VTK_SMALL_NUMBER = 1.0e-12f;
        static double VTK_LARGE_FLOAT = 1.0F + 12f;


        static long VTK_MAX_ROTATIONS = 20;

        //
        // Some useful macros and functions
        //
        //define VTK_SIGN(x)              (( (x) < 0 )?( -1 ):( 1 ))

        public static double Distance2BetweenPoints(double[] point1, double[] point2)
        {
            return (Convert.ToSingle(Math.Sqrt((point1[0] - point2[0]) * (point1[0] - point2[0]) + (point1[1] - point2[1]) * (point1[1] - point2[1]) +
                    (point1[2] - point2[2]) * (point1[2] - point2[2]))));
        }

       
  

        //----------------------------------------------------------------------------
        //public static double Distance2BetweenPoints(double[] x, double[] y)
        //{
        //    return (Math.Sqrt((x[0] - y[0]) * (x[0] - y[0]) + (x[1] - y[1]) * (x[1] - y[1]) +
        //            (x[2] - y[2]) * (x[2] - y[2])));
        //}

        public static void VTK_ROTATE(double[,] a, int i, int j, int k, int l, double tau, double s)
        {
            double g = a[i, j];
            double h = a[k, l]; 
            a[i, j] = g - s * (h + g * tau);
            a[k, l] = h + s * (g - h * tau);

        }
     
        //----------------------------------------------------------------------------
        public static double Norm(double[] x)
        {
            return Convert.ToSingle(Math.Sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]));
        }
       

        // Description:
        // Compute the norm of 3-vector (double-precision version).

        public static double Normalize(double[] x)
        {
            double den;
            if ((den = Norm(x)) != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    x[i] /= den;
                }
            }
            return den;
        }
        //double Normalize(double[,] x, int xIndex)
        //{
        //    double[] xVector = VectorFromMatrix(xIndex, x);
        //    double den;
        //    if ((den = Norm(xVector)) != 0)
        //    {
        //        for (int i = 0; i < 3; i++)
        //        {
        //            x[i, xIndex] /= den;
        //        }
        //    }
        //    return den;
        //}
        public static double Normalize(int xIndex, double[,] x)
        {
            double[] xVector = VectorFromMatrix(xIndex, x);
            double den;
            if ((den = Norm(xVector)) != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    x[i, xIndex] /= den;
                }
            }
            return den;
        }

      
      

        //----------------------------------------------------------------------------
        public static double Determinant3x3(double[] c1,
                                             double[] c2,
                                             double[] c3)
        {
            return c1[0] * c2[1] * c3[2] + c2[0] * c3[1] * c1[2] + c3[0] * c1[1] * c2[2] -
                   c1[0] * c3[1] * c2[2] - c2[0] * c1[1] * c3[2] - c3[0] * c2[1] * c1[2];
        }

       

     
        //----------------------------------------------------------------------------
        public static double Random(double min, double max)
        {
            return (min + Random() * (max - min));
        }

        //----------------------------------------------------------------------------
        // Cross product of two 3-vectors. Result vector in z.
        public static void Cross(double[] x, double[] y, double[] z)
        {
            double Zx = x[1] * y[2] - x[2] * y[1];
            double Zy = x[2] * y[0] - x[0] * y[2];
            double Zz = x[0] * y[1] - x[1] * y[0];
            z[0] = Zx; z[1] = Zy; z[2] = Zz;
        }
          //----------------------------------------------------------------------------
        // Cross product of two 3-vectors. Result vector in z.
        public static void Cross(double[,] x, double[,] y, double[,] z, int XIndex, int YIndex, int ZIndex)
        {
            double Zx = x[XIndex, 1] * y[YIndex, 2] - x[XIndex, 2] * y[YIndex, 1];
            double Zy = x[XIndex, 2] * y[YIndex, 0] - x[XIndex, 0] * y[YIndex, 2];
            double Zz = x[XIndex, 0] * y[YIndex, 1] - x[XIndex, 1] * y[YIndex, 0];
            z[ZIndex, 0] = Zx; z[ZIndex, 1] = Zy; z[ZIndex, 2] = Zz;
        }
        
        //----------------------------------------------------------------------------
       
        //----------------------------------------------------------------------------
      
        //BTX
        //----------------------------------------------------------------------------

        public static double vtkDeterminant3x3(double[,] A)
        {
            return A[0, 0] * A[1, 1] * A[2, 2] + A[1, 0] * A[2, 1] * A[0, 2] +
                   A[2, 0] * A[0, 1] * A[1, 2] - A[0, 0] * A[2, 1] * A[1, 2] -
                   A[1, 0] * A[0, 1] * A[2, 2] - A[2, 0] * A[1, 1] * A[0, 2];
        }
        //ETX



        //----------------------------------------------------------------------------
        public static double Determinant3x3(double[,] A)
        {
            return vtkDeterminant3x3(A);
        }

        //----------------------------------------------------------------------------
        public static void ClampValue(double value, double[] range)
        {
            if (value != 0 && range != null)
            {
                if (value < range[0])
                {
                    value = range[0];
                }
                else if (value > range[1])
                {
                    value = range[1];
                }
            }
        }

        //----------------------------------------------------------------------------
        public static void ClampValue(
         double value, double[] range, double clamped_value)
        {
            if (range != null && clamped_value != 0)
            {
                if (value < range[0])
                {
                    clamped_value = range[0];
                }
                else if (value > range[1])
                {
                    clamped_value = range[1];
                }
                else
                {
                    clamped_value = value;
                }
            }
        }

        //----------------------------------------------------------------------------
        // Generate random numbers between 0.0 and 1.0.
        // This is used to provide portability across different systems.
        public static double Random()
        {
            long hi, lo;

            // Based on code in "Random Number Generators: Good Ones are Hard to Find,"
            // by Stephen K. Park and Keith W. Miller in Communications of the ACM,
            // 31, 10 (Oct. 1988) pp. 1192-1201.
            // Borrowed from: Fuat C. Baran, Columbia University, 1988.
            hi = Seed / VTK_K_Q;
            lo = Seed % VTK_K_Q;
            if ((Seed = VTK_K_A * lo - VTK_K_R * hi) <= 0)
            {
                Seed += VTK_K_M;
            }
            return ((double)Seed / VTK_K_M);
        }

        //----------------------------------------------------------------------------
        // Initialize seed value. NOTE: Random() has the bad property that 
        // the first random number returned after RandomSeed() is called 
        // is proportional to the seed value! To help solve this, call 
        // RandomSeed() a few times inside seed. This doesn't ruin the 
        // repeatability of Random().
        //
        public static void RandomSeed(long s)
        {
            Seed = s;

            Random();
            Random();
            Random();
        }

        //----------------------------------------------------------------------------
        // Find unit vectors which is perpendicular to this one and to
        // each other.
        public static void Perpendiculars(double[] x, double[] y, double[] z,
                                     double theta)
        {
            int dx, dy, dz;
            double x2 = x[0] * x[0];
            double y2 = x[1] * x[1];
            double z2 = x[2] * x[2];
            double r = Convert.ToSingle(Math.Sqrt(x2 + y2 + z2));

            // transpose the vector to avoid divide-by-zero error
            if (x2 > y2 && x2 > z2)
            {
                dx = 0; dy = 1; dz = 2;
            }
            else if (y2 > z2)
            {
                dx = 1; dy = 2; dz = 0;
            }
            else
            {
                dx = 2; dy = 0; dz = 1;
            }

            double a = x[dx] / r;
            double b = x[dy] / r;
            double c = x[dz] / r;

            double tmp = Convert.ToSingle(Math.Sqrt(a * a + c * c));

            if (theta != 0)
            {
                double sintheta = Convert.ToSingle(Math.Sin(theta));
                double costheta = Convert.ToSingle(Math.Cos(theta));

                if (y != null)
                {
                    y[dx] = (c * costheta - a * b * sintheta) / tmp;
                    y[dy] = sintheta * tmp;
                    y[dz] = (-a * costheta - b * c * sintheta) / tmp;
                }

                if (z != null)
                {
                    z[dx] = (-c * sintheta - a * b * costheta) / tmp;
                    z[dy] = costheta * tmp;
                    z[dz] = (a * sintheta - b * c * costheta) / tmp;
                }
            }
            else
            {
                if (y != null)
                {
                    y[dx] = c / tmp;
                    y[dy] = 0;
                    y[dz] = -a / tmp;
                }

                if (z != null)
                {
                    z[dx] = -a * b / tmp;
                    z[dy] = tmp;
                    z[dz] = -b * c / tmp;
                }
            }
        }

    
        // Description:
        // Compute determinant of 2x2 matrix. Two columns of matrix are input.
        public static double Determinant2x2(double[] c1, double[] c2)
        {
            return (c1[0] * c2[1] - c2[0] * c1[1]);
        }

        // Description:
        // Calculate the determinant of a 2x2 matrix: | a b | | c d |
        public static double Determinant2x2(double a, double b, double c, double d)
        {
            return (a * d - b * c);
        }

   

        //----------------------------------------------------------------------------
        // Solve linear equations Ax = b using Crout's method. Input is square matrix A
        // and load vector x. Solution x is written over load vector. The dimension of
        // the matrix is specified in size. If error is found, method returns a 0.
        public static int SolveLinearSystem(double[,] A, double[] x, int size)
        {
            // if we solving something simple, just solve it
            //
            if (size == 2)
            {
                double det;
                double[] y = new double[2];

                det = Determinant2x2(A[0, 0], A[0, 1], A[1, 0], A[1, 1]);

                if (det == 0)
                {
                    // Unable to solve linear system
                    return 0;
                }

                y[0] = (A[1, 1] * x[0] - A[0, 1] * x[1]) / det;
                y[1] = (-A[1, 0] * x[0] + A[0, 0] * x[1]) / det;

                x[0] = y[0];
                x[1] = y[1];
                return 1;
            }
            else if (size == 1)
            {
                if (A[0, 0] == 0)
                {
                    // Unable to solve linear system
                    return 0;
                }

                x[0] /= A[0, 0];
                return 1;
            }

            //
            // System of equations is not trivial, use Crout's method
            //

            // Check on allocation of working vectors
            //
            int[] index = null;
            int[] scratch = new int[10];
            if (size < 10)
            {
                index = new int[size];
                scratch = new int[size];
            }

            //
            // Factor and solve matrix
            //
            if (LUFactorLinearSystem(A, index, size) == 0)
            {
                return 0;
            }
            LUSolveLinearSystem(A, index, x, size);

            if (size >= 10)
                index = null;
            return 1;
        }

        //----------------------------------------------------------------------------
        // Invert input square matrix A into matrix AI. Note that A is modified during
        // the inversion. The size variable is the dimension of the matrix. Returns 0
        // if inverse not computed.
        public static int InvertMatrix(double[,] A, double[,] AI, int size)
        {
            int[] index;
            double[] column;
            int[] iScratch = new int[10];

            double[] dScratch = new double[10];

            // Check on allocation of working vectors
            //
            if (size <= 10)
            {
                index = iScratch;
                column = dScratch;
            }
            else
            {
                index = new int[size];
                column = new double[size];
            }

            int retVal = InvertMatrix(A, AI, size, index, column);

            if (size > 10)
            {
                index = null;
                column = null;
            }

            return retVal;
        }

        //----------------------------------------------------------------------------
        // Factor linear equations Ax = b using LU decompostion A = LU where L is
        // lower triangular matrix and U is upper triangular matrix. Input is 
        // square matrix A, integer array of pivot indices index[0->n-1], and size
        // of square matrix n. Output factorization LU is in matrix A. If error is 
        // found, method returns 0. 
        public static int LUFactorLinearSystem(double[,] A, int[] index, int size)
        {
            double[] scratch = new double[10];
            double[] scale = (size < 10 ? scratch : new double[size]);

            int i, j, k;
            int maxI = 0;
            double largest, temp1, temp2, sum;

            //
            // Loop over rows to get implicit scaling information
            //
            for (i = 0; i < size; i++)
            {
                for (largest = 0.0f, j = 0; j < size; j++)
                {
                    if ((temp2 = Math.Abs(A[i, j])) > largest)
                    {
                        largest = temp2;
                    }
                }

                if (largest == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Warning - - Unable to factor linear system");
                    return 0;
                }
                scale[i] = 1.0f/ largest;
            }
            //
            // Loop over all columns using Crout's method
            //
            for (j = 0; j < size; j++)
            {
                for (i = 0; i < j; i++)
                {
                    sum = A[i, j];
                    for (k = 0; k < i; k++)
                    {
                        sum -= A[i, k] * A[k, j];
                    }
                    A[i, j] = sum;
                }
                //
                // Begin search for largest pivot element
                //
                for (largest = 0 , i = j; i < size; i++)
                {
                    sum = A[i, j];
                    for (k = 0; k < j; k++)
                    {
                        sum -= A[i, k] * A[k, j];
                    }
                    A[i, j] = sum;

                    if ((temp1 = scale[i] * Math.Abs(sum)) >= largest)
                    {
                        largest = temp1;
                        maxI = i;
                    }
                }
                //
                // Check for row interchange
                //
                if (j != maxI)
                {
                    for (k = 0; k < size; k++)
                    {
                        temp1 = A[maxI, k];
                        A[maxI, k] = A[j, k];
                        A[j, k] = temp1;
                    }
                    scale[maxI] = scale[j];
                }
                //
                // Divide by pivot element and perform elimination
                //
                index[j] = maxI;

                if (Math.Abs(A[j, j]) <= VTK_SMALL_NUMBER)
                {
                    System.Diagnostics.Debug.WriteLine("Warning - Unable to factor linear system");
                    return 0;
                }

                if (j != (size - 1))
                {
                    temp1 = 1.0f/ A[j, j];
                    for (i = j + 1; i < size; i++)
                    {
                        A[i, j] *= temp1;
                    }
                }
            }

            if (size >= 10)
                scale = null;

            return 1;
        }

        //----------------------------------------------------------------------------
        // Solve linear equations Ax = b using LU decompostion A = LU where L is
        // lower triangular matrix and U is upper triangular matrix. Input is 
        // factored matrix A=LU, integer array of pivot indices index[0->n-1],
        // load vector x[0->n-1], and size of square matrix n. Note that A=LU and
        // index[] are generated from method LUFactorLinearSystem). Also, solution
        // vector is written directly over input load vector.
        public static void LUSolveLinearSystem(double[,] A, int[] index,
                                          double[] x, int size)
        {
            int i, j, ii, idx;
            double sum;
            //
            // Proceed with forward and backsubstitution for L and U
            // matrices.  First, forward substitution.
            //
            for (ii = -1, i = 0; i < size; i++)
            {
                idx = index[i];
                sum = x[idx];
                x[idx] = x[i];

                if (ii >= 0)
                {
                    for (j = ii; j <= (i - 1); j++)
                    {
                        sum -= A[i, j] * x[j];
                    }
                }
                else if (sum > 0)
                {
                    ii = i;
                }

                x[i] = sum;
            }
            //
            // Now, back substitution
            //
            for (i = size - 1; i >= 0; i--)
            {
                sum = x[i];
                for (j = i + 1; j < size; j++)
                {
                    sum -= A[i, j] * x[j];
                }
                x[i] = sum / A[i, i];
            }
        }



        //#undef VTK_MAX_ROTATIONS

        //#define VTK_MAX_ROTATIONS 50

        // Jacobi iteration for the solution of eigenvectors/eigenvalues of a nxn
        // real symmetric matrix. Square nxn matrix a; size of matrix in n;
        // output eigenvalues in w; and output eigenvectors in v. Resulting
        // eigenvalues/vectors are sorted in decreasing order; eigenvectors are
        // normalized.

        public static int vtkJacobiN(double[,] a, int n, double[] w, double[,] v)
        {
            int i, j, k, iq, ip, numPos;
            double tresh;
            double theta, tau, t, sm, s, h, g, c, tmp;
            double[] bspace = new double[4];
            double[] zspace = new double[4];

            double[] b = bspace;
            double[] z = zspace;

            // only allocate memory if the matrix is large
            if (n > 4)
            {
                b = new double[n];
                z = new double[n];
            }

            // initialize
            for (ip = 0; ip < n; ip++)
            {
                for (iq = 0; iq < n; iq++)
                {
                    v[ip, iq] = 0.0f;
                }
                v[ip, ip] = 1.0f;
            }
            for (ip = 0; ip < n; ip++)
            {
                b[ip] = w[ip] = a[ip, ip];
                z[ip] = 0.0f;
            }

            // begin rotation sequence
            for (i = 0; i < VTK_MAX_ROTATIONS; i++)
            {
                sm = 0.0f;
                for (ip = 0; ip < n - 1; ip++)
                {
                    for (iq = ip + 1; iq < n; iq++)
                    {
                        sm += Math.Abs(a[ip, iq]);
                    }
                }
                if (sm == 0)
                {
                    break;
                }

                if (i < 3)                                // first 3 sweeps
                {
                    tresh = 0.2f * sm / (n * n);
                }
                else
                {
                    tresh = 0.0f;
                }

                for (ip = 0; ip < n - 1; ip++)
                {
                    for (iq = ip + 1; iq < n; iq++)
                    {
                        g = Convert.ToSingle(100.0 * Math.Abs(a[ip, iq]));

                        // after 4 sweeps
                        if (i > 3 && (Math.Abs(w[ip]) + g) == Math.Abs(w[ip])
                        && (Math.Abs(w[iq]) + g) == Math.Abs(w[iq]))
                        {
                            a[ip, iq] = 0.0f;
                        }
                        else if (Math.Abs(a[ip, iq]) > tresh)
                        {
                            h = w[iq] - w[ip];
                            if ((Math.Abs(h) + g) == Math.Abs(h))
                            {
                                t = (a[ip, iq]) / h;
                            }
                            else
                            {
                                theta = 0.5f * h / (a[ip, iq]);
                                t =Convert.ToSingle( 1.0f/ (Math.Abs(theta) + Math.Sqrt(1.0f+ theta * theta)));
                                if (theta < 0)
                                {
                                    t = -t;
                                }
                            }
                            c = Convert.ToSingle(1.0f/ Math.Sqrt(1 + t * t));
                            s = t * c;
                            tau = s / (1.0f+ c);
                            h = t * a[ip, iq];
                            z[ip] -= h;
                            z[iq] += h;
                            w[ip] -= h;
                            w[iq] += h;
                            a[ip, iq] = 0.0f;

                            // ip already shifted left by 1 unit
                            for (j = 0; j <= ip - 1; j++)
                            {
                                VTK_ROTATE(a, j, ip, j, iq, tau, s);
                            }
                            // ip and iq already shifted left by 1 unit
                            for (j = ip + 1; j <= iq - 1; j++)
                            {
                                VTK_ROTATE(a, ip, j, j, iq, tau, s);
                            }
                            // iq already shifted left by 1 unit
                            for (j = iq + 1; j < n; j++)
                            {
                                VTK_ROTATE(a, ip, j, iq, j, tau, s);
                            }
                            for (j = 0; j < n; j++)
                            {
                                VTK_ROTATE(v, j, ip, j, iq, tau, s);
                            }
                        }
                    }
                }

                for (ip = 0; ip < n; ip++)
                {
                    b[ip] += z[ip];
                    w[ip] = b[ip];
                    z[ip] = 0.0f;
                }
            }

            //// this is NEVER called
            if (i >= VTK_MAX_ROTATIONS)
            {
                //System.Windows.Forms.MessageBox.Show("Jacobi: Error extracting eigenfunctions");
                System.Diagnostics.Debug.WriteLine("Error in Jacobi: No eigenfunctions");
                return 0;
            }

            // sort eigenfunctions                 these changes do not affect accuracy 
            for (j = 0; j < n - 1; j++)                  // boundary incorrect
            {
                k = j;
                tmp = w[k];
                for (i = j + 1; i < n; i++)                // boundary incorrect, shifted already
                {
                    if (w[i] >= tmp)                   // why exchage if same?
                    {
                        k = i;
                        tmp = w[k];
                    }
                }
                if (k != j)
                {
                    w[k] = w[j];
                    w[j] = tmp;
                    for (i = 0; i < n; i++)
                    {
                        tmp = v[i, j];
                        v[i, j] = v[i, k];
                        v[i, k] = tmp;
                    }
                }
            }
            // insure eigenvector consistency (i.e., Jacobi can compute vectors that
            // are negative of one another (.707,.707,0) and (-.707,-.707,0). This can
            // reek havoc in hyperstreamline/other stuff. We will select the most
            // positive eigenvector.
            int ceil_half_n = (n >> 1) + (n & 1);
            for (j = 0; j < n; j++)
            {
                for (numPos = 0, i = 0; i < n; i++)
                {
                    if (v[i, j] >= 0)
                    {
                        numPos++;
                    }
                }
                //    if ( numPos < ceil(double(n)/double(2)) )
                if (numPos < ceil_half_n)
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i, j] *= -1.0f;
                    }
                }
            }

            if (n > 4)
            {
                b = null;
                z = null;
            }
            return 1;
        }
        // Jacobi iteration for the solution of eigenvectors/eigenvalues of a nxn
        // real symmetric matrix. Square nxn matrix a; size of matrix in n;
        // output eigenvalues in w; and output eigenvectors in v. Resulting
        // eigenvalues/vectors are sorted in decreasing order; eigenvectors are
        // normalized.

        public static int JacobiN1(double[,] a, int n, double[] w, double[,] v)
        {
            int i, j, k, iq, ip, numPos;
            double tresh;
            double theta, tau, t, sm, s, h, g, c, tmp;
            double[] bspace = new double[4];
            double[] zspace = new double[4];

            double[] b = bspace;
            double[] z = zspace;

            // only allocate memory if the matrix is large
            if (n > 4)
            {
                b = new double[n];
                z = new double[n];
            }

            // initialize
            for (ip = 0; ip < n; ip++)
            {
                for (iq = 0; iq < n; iq++)
                {
                    v[ip, iq] = 0.0F;
                }
                v[ip, ip] = 1.0F;
            }
            for (ip = 0; ip < n; ip++)
            {
                b[ip] = w[ip] = a[ip, ip];
                z[ip] = 0.0F;
            }

            // begin rotation sequence
            for (i = 0; i < VTK_MAX_ROTATIONS; i++)
            {
                sm = 0.0F;
                for (ip = 0; ip < n - 1; ip++)
                {
                    for (iq = ip + 1; iq < n; iq++)
                    {
                        sm += Math.Abs(a[ip, iq]);
                    }
                }
                if (sm == 0)
                {
                    break;
                }

                if (i < 3)                                // first 3 sweeps
                {
                    tresh = 0.2F * sm / (n * n);
                }
                else
                {
                    tresh = 0.0F;
                }

                for (ip = 0; ip < n - 1; ip++)
                {
                    for (iq = ip + 1; iq < n; iq++)
                    {
                        g = 100.0F * Math.Abs(a[ip, iq]);

                        // after 4 sweeps
                        if (i > 3 && (Math.Abs(w[ip]) + g) == Math.Abs(w[ip])
                        && (Math.Abs(w[iq]) + g) == Math.Abs(w[iq]))
                        {
                            a[ip, iq] = 0.0F;
                        }
                        else if (Math.Abs(a[ip, iq]) > tresh)
                        {
                            h = w[iq] - w[ip];
                            if ((Math.Abs(h) + g) == Math.Abs(h))
                            {
                                t = (a[ip, iq]) / h;
                            }
                            else
                            {
                                theta = 0.5F * h / (a[ip, iq]);
                                t = Convert.ToSingle(  1.0F / (Math.Abs(theta) + Math.Sqrt(1.0f+ theta * theta)) );
                                if (theta < 0)
                                {
                                    t = -t;
                                }
                            }
                            c = Convert.ToSingle( 1.0F / Math.Sqrt(1 + t * t) );
                            s = t * c;
                            tau = s / (1.0F + c);
                            h = t * a[ip, iq];
                            z[ip] -= h;
                            z[iq] += h;
                            w[ip] -= h;
                            w[iq] += h;
                            a[ip, iq] = 0.0F;

                            // ip already shifted left by 1 unit
                            for (j = 0; j <= ip - 1; j++)
                            {
                                VTK_ROTATE(a, j, ip, j, iq, tau, s);
                            }
                            // ip and iq already shifted left by 1 unit
                            for (j = ip + 1; j <= iq - 1; j++)
                            {
                                VTK_ROTATE(a, ip, j, j, iq, tau, s);
                            }
                            // iq already shifted left by 1 unit
                            for (j = iq + 1; j < n; j++)
                            {
                                VTK_ROTATE(a, ip, j, iq, j, tau, s);
                            }
                            for (j = 0; j < n; j++)
                            {
                                VTK_ROTATE(v, j, ip, j, iq, tau, s);
                            }
                        }
                    }
                }

                for (ip = 0; ip < n; ip++)
                {
                    b[ip] += z[ip];
                    w[ip] = b[ip];
                    z[ip] = 0.0F;
                }
            }

            //// this is NEVER called
            if (i >= VTK_MAX_ROTATIONS)
            {
                //System.Windows.Forms.MessageBox.Show("Jacobi: Error extracting eigenfunctions");
                System.Diagnostics.Debug.WriteLine("Error in Jacobi: No eigenfunctions");
                return 0;
            }

            // sort eigenfunctions                 these changes do not affect accuracy 
            for (j = 0; j < n - 1; j++)                  // boundary incorrect
            {
                k = j;
                tmp = w[k];
                for (i = j + 1; i < n; i++)                // boundary incorrect, shifted already
                {
                    if (w[i] >= tmp)                   // why exchage if same?
                    {
                        k = i;
                        tmp = w[k];
                    }
                }
                if (k != j)
                {
                    w[k] = w[j];
                    w[j] = tmp;
                    for (i = 0; i < n; i++)
                    {
                        tmp = v[i, j];
                        v[i, j] = v[i, k];
                        v[i, k] = tmp;
                    }
                }
            }
            // insure eigenvector consistency (i.e., Jacobi can compute vectors that
            // are negative of one another (.707,.707,0) and (-.707,-.707,0). This can
            // reek havoc in hyperstreamline/other stuff. We will select the most
            // positive eigenvector.
            int ceil_half_n = (n >> 1) + (n & 1);
            for (j = 0; j < n; j++)
            {
                for (numPos = 0, i = 0; i < n; i++)
                {
                    if (v[i, j] >= 0)
                    {
                        numPos++;
                    }
                }
                //    if ( numPos < ceil(double(n)/double(2)) )
                if (numPos < ceil_half_n)
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i, j] *= -1.0F;
                    }
                }
            }

            if (n > 4)
            {
                b = null;
                z = null;
            }
            return 1;
        }


        //----------------------------------------------------------------------------
        public static int JacobiN(double[,] a, int n, double[] w, double[,] v)
        {
            return JacobiN1(a, n, w, v);
        }

     


        ////----------------------------------------------------------------------------
        //// Jacobi iteration for the solution of eigenvectors/eigenvalues of a 3x3
        //// real symmetric matrix. Square 3x3 matrix a; output eigenvalues in w;
        //// and output eigenvectors in v. Resulting eigenvalues/vectors are sorted
        //// in decreasing order; eigenvectors are normalized.
        //int Jacobi(double a, double w, double v)
        //{
        //    return JacobiN(a, 3, w, v);
        //}

        //----------------------------------------------------------------------------
        public static int Jacobi(double[,] a, double[] w, double[,] v)
        {
            return JacobiN(a, 3, w, v);
        }

        //----------------------------------------------------------------------------
        // Estimate the condition number of a LU factored matrix. Used to judge the
        // accuracy of the solution. The matrix A must have been previously factored
        // using the method LUFactorLinearSystem. The condition number is the ratio
        // of the infinity matrix norm (i.e., maximum value of matrix component)
        // divided by the minimum diagonal value. (This works for triangular matrices
        // only: see Conte and de Boor, Elementary Numerical Analysis.)
        public static double EstimateMatrixCondition(double[,] A, int size)
        {
            int i;
            int j = 0;
            double min = VTK_LARGE_FLOAT;
            double max = (-VTK_LARGE_FLOAT);

            // find the maximum value
            for (i = 0; i < size; i++)
            {
                for (j = i; j < size; j++)
                {
                    if (Math.Abs(A[i, j]) > max)
                    {
                        max = Math.Abs(A[i, j]);
                    }
                }
            }

            // find the minimum diagonal value
            for (i = 0; i < size; i++)
            {
                if (Math.Abs(A[i, i]) < min)
                {
                    min = Math.Abs(A[i, i]);
                }
            }

            if (min == 0)
            {
                return VTK_LARGE_FLOAT;
            }
            else
            {
                return (max / min);
            }
        }

        //----------------------------------------------------------------------------
        // Solves a cubic equation c0*t^3  + c1*t^2  + c2*t + c3 = 0 when
        // c0, c1, c2, and c3 are REAL.
        // Solution is motivated by Numerical Recipes In C 2nd Ed.
        // Return array contains number of (real) roots (counting multiple roots as one)
        // followed by roots themselves. The value in roots[4] is a integer giving
        // further information about the roots (see return codes for int SolveCubic()).
        public static double[] SolveCubic(double c0, double c1, double c2, double c3)
        {
            double[] roots = new double[5];
            roots[1] = 0.0f;
            roots[2] = 0.0f;
            roots[3] = 0.0f;
            int num_roots = 0;

            roots[4] = SolveCubic(c0, c1, c2, c3, ref roots, ref num_roots);
            roots[0] = num_roots;
            return roots;
        }
        public static double VTK_SIGN(double r)
        {
            if (r < 0)
                return -1;
            else
                return 1;
        }
        //----------------------------------------------------------------------------
        // Solves a cubic equation when c0, c1, c2, And c3 Are REAL.  Solution
        // is motivated by Numerical Recipes In C 2nd Ed.  Roots and number of
        // real roots are stored in user provided variables r1, r2, r3, and
        // num_roots. Note that the function can return the following integer
        // values describing the roots: (0)-no solution; (-1)-infinite number
        // of solutions; (1)-one distinct real root of multiplicity 3 (stored
        // in r1); (2)-two distinct real roots, one of multiplicity 2 (stored
        // in r1 & r2); (3)-three distinct real roots; (-2)-quadratic equation
        // with complex conjugate solution (real part of root returned in r1,
        // imaginary in r2); (-3)-one real root and a complex conjugate pair
        // (real root in r1 and real part of pair in r2 and imaginary in r3).
        public static int SolveCubic(double c0, double c1, double c2, double c3,
                                 ref double[] roots, ref int num_roots)
        {
            roots = new double[3];
            double Q, R;
            double R_squared;      /* R*R */
            double Q_cubed;        /* Q*Q*Q */
            double theta;
            double A, B;
            double r1, r2, r3;
            // Cubic equation: c0*t^3  + c1*t^2  + c2*t + c3 = 0 
            //                                               
            //   r1, r2, r3 are roots and num_roots is the number
            //   of real roots                               

            // Make Sure This Is A Bonafide Cubic Equation 
            if (c0 != 0)
            {
                //Put Coefficients In Right Form 
                c1 = c1 / c0;
                c2 = c2 / c0;
                c3 = c3 / c0;

                Q = ((c1 * c1) - 3 * c2) / 9.0f;

                R = (2* (c1 * c1 * c1) - 9 * (c1 * c2) + 27 * c3) / 54.0f;

                R_squared = R * R;
                Q_cubed = Q * Q * Q;

                if (R_squared <= Q_cubed)
                {
                    if (Q_cubed == 0)
                    {
                        r1 = -c1 / 3.0f;
                        r2 = r1;
                        r3 = r1;
                        num_roots = 1;
                        return 1;
                    }
                    else
                    {
                        theta =Convert.ToSingle( Math.Acos(R / (Math.Sqrt(Q_cubed))));

                        r1 =Convert.ToSingle( -2* Math.Sqrt(Q) * Math.Cos(theta / 3) - c1 / 3.0f);
                        r2 =Convert.ToSingle( -2* Math.Sqrt(Q) * Math.Cos((theta + 2* 3.141592653589) / 3) - c1 / 3.0f);
                        r3 =Convert.ToSingle( -2* Math.Sqrt(Q) * Math.Cos((theta - 2* 3.141592653589) / 3) - c1 / 3.0f);

                        num_roots = 3;

                        // Reduce Number Of Roots To Two 
                        if (r1 == r2)
                        {
                            num_roots = 2;
                            r2 = r3;
                        }
                        else if (r1 == r3)
                        {
                            num_roots = 2;
                        }

                        if ((r2 == r3) && (num_roots == 3))
                        {
                            num_roots = 2;
                        }

                        // Reduce Number Of Roots To One 
                        if ((r1 == r2))
                        {
                            num_roots = 1;
                        }
                        
                    }

                    roots[0] = r1;
                    roots[1] = r2;
                    roots[2] = r3;
                    return num_roots;
                }
                else //single real and complex conjugate pair
                {
                    A =Convert.ToSingle( -VTK_SIGN(R) * Math.Pow(Math.Abs(R) + Math.Sqrt(R_squared - Q_cubed), 0.33333333f));

                    if (A == 0)
                    {
                        B = 0.0f;
                    }
                    else
                    {
                        B = Q / A;
                    }

                    r1 = (A + B) - c1 / 3.0f;
                    r2 = -0.5f * (A + B) - c1 / 3.0f;
                    r3 = Convert.ToSingle(Math.Sqrt(3) / 2* (A - B));

                    num_roots = 1;
                    roots[0] = r1;
                    roots[1] = r2;
                    roots[2] = r3;
                    return (-3);
                }
            } //if cubic equation

            else // Quadratic Equation: c1*t  + c2*t + c3 = 0 
            {
                // Okay this was not a cubic - lets try quadratic
                int intvatl =  SolveQuadratic(c1, c2, c3, ref roots, ref num_roots);
              
                
                return intvatl;
                
            }
        }

        //----------------------------------------------------------------------------
        // Solves a quadratic equation c1*t^2 + c2*t + c3 = 0 when c1, c2, and
        // c3 are REAL.  Solution is motivated by Numerical Recipes In C 2nd
        // Ed.  Return array contains number of (real) roots (counting
        // multiple roots as one) followed by roots themselves. Note that 
        // roots contains a return code further describing solution - see
        // documentation for SolveCubic() for meaining of return codes.
        public static double[] SolveQuadratic(double c1, double c2, double c3)
        {
            double[] roots = new double[4];
            roots[0] = 0.0f;
            roots[1] = 0.0f;
            roots[2] = 0.0f;
            int num_roots = 0;

            roots[3] = SolveQuadratic(c1, c2, c3, ref roots,
                                                ref num_roots);
            roots[0] = num_roots;
            return roots;
        }

        //----------------------------------------------------------------------------
        // Solves A Quadratic Equation c1*t^2  + c2*t  + c3 = 0 when 
        // c1, c2, and c3 are REAL.
        // Solution is motivated by Numerical Recipes In C 2nd Ed.
        // Roots and number of roots are stored in user provided variables
        // r1, r2, num_roots
        public static int SolveQuadratic(double c1, double c2, double c3,
                                     ref double[] roots, ref int num_roots)
        {
            double Q;
            double determinant;
            roots = new double[3];
            double r1 = 0;
                double r2;
            // Quadratic equation: c1*t^2 + c2*t + c3 = 0 

            // Make sure this is a quadratic equation
            if (c1 != 0)
            {
                determinant = c2 * c2 - 4 * c1 * c3;

                if (determinant >= 0)
                {
                    Q = Convert.ToSingle(-0.5f * (c2 + VTK_SIGN(c2) * Math.Sqrt(determinant)));

                    r1 = Q / c1;

                    if (Q == 0)
                    {
                        r2 = 0.0f;
                    }
                    else
                    {
                        r2 = c3 / Q;
                    }

                    num_roots = 2;

                    // Reduce Number Of Roots To One 
                    if (r1 == r2)
                    {
                        num_roots = 1;
                    }
                    return num_roots;
                }
                else        // Equation Does Not Have Real Roots 
                {
                    num_roots = 0;
                    return (-2);
                }
            }

            else // Linear Equation: c2*t + c3 = 0 
            {
                // Okay this was not quadratic - lets try linear
                return SolveLinear(c2, c3, ref r1, ref num_roots);
            }
        }

        //----------------------------------------------------------------------------
        // Solves a linear equation c2*t  + c3 = 0 when c2 and c3 are REAL.
        // Solution is motivated by Numerical Recipes In C 2nd Ed.
        // Return array contains number of roots followed by roots themselves.
        public static double[] SolveLinear(double c2, double c3)
        {
            double[] roots = new double[3];
            int num_roots = 0;
            roots[1] = 0.0f;
            roots[2] = SolveLinear(c2, c3, ref roots[1], ref num_roots);
            roots[0] = num_roots;
            return roots;
        }

        //----------------------------------------------------------------------------
        // Solves a linear equation c2*t + c3 = 0 when c2 and c3 are REAL.
        // Solution is motivated by Numerical Recipes In C 2nd Ed.
        // Root and number of (real) roots are stored in user provided variables
        // r2 and num_roots.
        public static int SolveLinear(double c2, double c3, ref double r1, ref int num_roots)
        {
            // Linear equation: c2*t + c3 = 0 
            // Now this had better be linear 
            if (c2 != 0)
            {
                r1 = -c3 / c2;
                num_roots = 1;
                return num_roots;
            }
            else
            {
                num_roots = 0;
                if (c3 == 0)
                {
                    return (-1);
                }
            }

            return num_roots;
        }

        //----------------------------------------------------------------------------
        // Solves for the least squares best fit matrix for the homogeneous equation X'M' = 0'.
        // Uses the method described on pages 40-41 of Computer Vision by 
        // Forsyth and Ponce, which is that the solution is the eigenvector 
        // associated with the minimum eigenvalue of T(X)X, where T(X) is the
        // transpose of X.
        // The inputs and output are transposed matrices.
        //    Dimensions: X' is numberOfSamples by xOrder,
        //                M' dimension is xOrder by 1.
        // M' should be pre-allocated. All matrices are row major. The resultant
        // matrix M' should be pre-multiplied to X' to get 0', or transposed and
        // then post multiplied to X to get 0
        public static int SolveHomogeneousLeastSquares(int numberOfSamples, double[,] xt, int xOrder,
                                        ref double[,] mt)
        {
            // check dimensional consistency
            if (numberOfSamples < xOrder)
            {
                System.Diagnostics.Debug.WriteLine("Warning - Insufficient number of samples. Underdetermined.");
                return 0;
            }

            int i, j, k;

            // set up intermediate variables
            // Allocate matrix to hold X times transpose of X
            double[,] XXt = new double[xOrder, xOrder];     // size x by x
            // Allocate the array of eigenvalues and eigenvectors
            double[] eigenvals = new double[xOrder];
            double[,] eigenvecs = new double[xOrder, xOrder];


            // Clear the upper triangular region (and btw, allocate the eigenvecs as well)
            for (i = 0; i < xOrder; i++)
            {
                //eigenvecs[i] = new double[xOrder];
                //XXt[i] = new double[xOrder];
                for (j = 0; j < xOrder; j++)
                {
                    XXt[i, j] = 0.0f;
                }
            }

            // Calculate XXt upper half only, due to symmetry
            for (k = 0; k < numberOfSamples; k++)
            {
                for (i = 0; i < xOrder; i++)
                {
                    for (j = i; j < xOrder; j++)
                    {
                        XXt[i, j] += xt[k, i] * xt[k, j];
                    }
                }
            }

            // now fill in the lower half of the XXt matrix
            for (i = 0; i < xOrder; i++)
            {
                for (j = 0; j < i; j++)
                {
                    XXt[i, j] = XXt[j, i];
                }
            }

            // Compute the eigenvectors and eigenvalues
            JacobiN(XXt, xOrder, eigenvals, eigenvecs);

            // Smallest eigenval is at the end of the list (xOrder-1), and solution is
            // corresponding eigenvec. 
            for (i = 0; i < xOrder; i++)
            {
                mt[i, 0] = eigenvecs[i, xOrder - 1];
            }

            // Clean up:
            for (i = 0; i < xOrder; i++)
            {
                for (int l = 0; l < xOrder; l++)
                {
                    XXt[i, l] = 0;
                    eigenvecs[i, l] = 0;
                }
            }
            XXt = null;
            eigenvecs = null;
            eigenvals = null;

            return 1;
        }


        //----------------------------------------------------------------------------
        // Solves for the least squares best fit matrix for the equation X'M' = Y'.
        // Uses pseudoinverse to get the ordinary least squares. 
        // The inputs and output are transposed matrices.
        //    Dimensions: X' is numberOfSamples by xOrder,
        //                Y' is numberOfSamples by yOrder,
        //                M' dimension is xOrder by yOrder.
        // M' should be pre-allocated. All matrices are row major. The resultant
        // matrix M' should be pre-multiplied to X' to get Y', or transposed and
        // then post multiplied to X to get Y
        // By default, this method checks for the homogeneous condition where Y==0, and
        // if so, invokes SolveHomogeneousLeastSquares. For better performance when
        // the system is known not to be homogeneous, invoke with checkHomogeneous=0.
        public static int SolveLeastSquares(int numberOfSamples, double[,] xt, int xOrder,
                                       double[,] yt, int yOrder, double[,] mt, bool checkHomogeneous)
        {
            // check dimensional consistency
            if ((numberOfSamples < xOrder) || (numberOfSamples < yOrder))
            {
                System.Diagnostics.Debug.WriteLine("Warning -Insufficient number of samples. Underdetermined.");
                return 0;
            }

            int i, j, k;

            bool someHomogeneous = false;
            bool allHomogeneous = false;
            double[,] hmt = new double[xOrder, yOrder];
            int homogRC = 0;
            bool[] homogenFlags = new bool[yOrder];

            // Ok, first init some flags check and see if all the systems are homogeneous
            if (checkHomogeneous)
            {
                // If Y' is zero, it's a homogeneous system and can't be solved via
                // the pseudoinverse method. Detect this case, warn the user, and
                // invoke SolveHomogeneousLeastSquares instead. Note that it doesn't
                // really make much sense for yOrder to be greater than one in this case,
                // since that's just yOrder occurrences of a 0 vector on the RHS, but
                // we allow it anyway. N


                // Initialize homogeneous flags on a per-right-hand-side basis
                for (j = 0; j < yOrder; j++)
                {
                    homogenFlags[j] = true;
                }
                for (i = 0; i < numberOfSamples; i++)
                {
                    for (j = 0; j < yOrder; j++)
                    {
                        if (Math.Abs(yt[i, j]) > VTK_SMALL_NUMBER)
                        {
                            allHomogeneous = false;
                            homogenFlags[j] = false;
                        }
                    }
                }

                // If we've got one system, and it's homogeneous, do it and bail out quickly.
                if (!allHomogeneous  && yOrder == 1)
                {
                    System.Diagnostics.Debug.WriteLine("Warning -Detected homogeneous system (Y=0), calling SolveHomogeneousLeastSquares()");
                    return SolveHomogeneousLeastSquares(numberOfSamples, xt, xOrder, ref mt);
                }


                // Ok, we've got more than one system of equations.
                // Figure out if we need to calculate the homogeneous equation solution for 
                // any of them.
                if (!allHomogeneous)
                {
                    someHomogeneous = false;
                }
                else
                {
                    for (j = 0; j < yOrder; j++)
                    {
                        if (!homogenFlags[j] )
                        {
                            someHomogeneous = false;
                        }
                    }
                }
            }

            // If necessary, solve the homogeneous problem
            if (!someHomogeneous)
            {
                // hmt is the homogeneous equation version of mt, the general solution.
                hmt = new double[xOrder, yOrder];
                for (j = 0; j < xOrder; j++)
                {
                    // Only allocate 1 here, not yOrder, because here we're going to solve
                    // just the one homogeneous equation subset of the entire problem
                    //hmt[j] = new double[1];
                }

                // Ok, solve the homogeneous problem
                homogRC = SolveHomogeneousLeastSquares(numberOfSamples, xt, xOrder, ref hmt);
            }


            // set up intermediate variables
            double[,] XXt = new double[xOrder, yOrder];     // size x by x
            double[,] XXtI = new double[xOrder, yOrder];    // size x by x
            double[,] XYt = new double[xOrder, yOrder];     // size x by y
            for (i = 0; i < xOrder; i++)
            {
                //XXt[i] = new double[xOrder];
                //XXtI[i] = new double[xOrder];

                for (j = 0; j < xOrder; j++)
                {
                    XXt[i, j] = 0.0f;
                    XXtI[i, j] = 0.0f;
                }

                //XYt[i] = new double[yOrder];
                for (j = 0; j < yOrder; j++)
                {
                    XYt[i, j] = 0.0f;
                }
            }

            // first find the pseudoinverse matrix
            for (k = 0; k < numberOfSamples; k++)
            {
                for (i = 0; i < xOrder; i++)
                {
                    // first calculate the XXt matrix, only do the upper half (symmetrical)
                    for (j = i; j < xOrder; j++)
                    {
                        XXt[i, j] += xt[k, i] * xt[k, j];
                    }

                    // now calculate the XYt matrix
                    for (j = 0; j < yOrder; j++)
                    {
                        XYt[i, j] += xt[k, i] * yt[k, j];
                    }
                }
            }

            // now fill in the lower half of the XXt matrix
            for (i = 0; i < xOrder; i++)
            {
                for (j = 0; j < i; j++)
                {
                    XXt[i, j] = XXt[j, i];
                }
            }

            // next get the inverse of XXt
            if ( InvertMatrix(XXt, XXtI, xOrder) != 0)
            {
                return 0;
            }

            // next get m
            for (i = 0; i < xOrder; i++)
            {
                for (j = 0; j < yOrder; j++)
                {
                    mt[i, j] = 0.0f;
                    for (k = 0; k < xOrder; k++)
                    {
                        mt[i, j] += XXtI[i, k] * XYt[k, j];
                    }
                }
            }

            // Fix up any of the solutions that correspond to the homogeneous equation
            // problem.
            if (!someHomogeneous)
            {
                for (j = 0; j < yOrder; j++)
                {
                    if (!homogenFlags[j] )
                    {
                        // Fix this one
                        for (i = 0; i < xOrder; i++)
                        {
                            mt[i, j] = hmt[i, 0];
                        }
                    }
                }

                // Clean up
                for (i = 0; i < xOrder; i++)
                {
                    for (j = 0; j < xOrder; j++)
                    {
                        hmt[i, j] = 0;
                    }
                }
                hmt = null;
            }
            SetMatrixRowTo0(i, XXt);
            // clean up:
            // set up intermediate variables
            for (i = 0; i < xOrder; i++)
            {
                SetMatrixRowTo0(i, XXt);
                SetMatrixRowTo0(i, XXtI);
                SetMatrixRowTo0(i, XYt);

            
            }
            XXt = null;
            XXtI = null;
            XYt = null;
            homogenFlags = null;

            if (!someHomogeneous )
            {
                return homogRC;
            }
            else
            {
                return 1;
            }
        }
        public static void SetMatrixRowTo0(int rowIndex, double[,] a)
        {

            for (int i = 0; i < a.GetLength(1); i++)
            {
                a[rowIndex, i] = 0;
            }
        }
        //=============================================================================
        // Thread safe versions of math methods.
        //=============================================================================


        // Invert input square matrix A into matrix AI. Note that A is modified during
        // the inversion. The size variable is the dimension of the matrix. Returns 0
        // if inverse not computed.
        // -----------------------
        // For thread safe behavior, temporary arrays tmp1SIze and tmp2Size
        // of length size must be passsed in.
        public static int InvertMatrix(double[,] A, double[,] AI, int size,
                                  int[] tmp1Size, double[] tmp2Size)
        {
            int i, j;

            //
            // Factor matrix; then begin solving for inverse one column at a time.
            // Note: tmp1Size returned value is used later, tmp2Size is just working
            // memory whose values are not used in LUSolveLinearSystem
            //
            if (LUFactorLinearSystem(A, tmp1Size, size, tmp2Size) == 0)
            {
                return 0;
            }

            for (j = 0; j < size; j++)
            {
                for (i = 0; i < size; i++)
                {
                    tmp2Size[i] = 0.0f;
                }
                tmp2Size[j] = 1.0f;

                LUSolveLinearSystem(A, tmp1Size, tmp2Size, size);

                for (i = 0; i < size; i++)
                {
                    AI[i, j] = tmp2Size[i];
                }
            }

            return 1;
        }




        // Factor linear equations Ax = b using LU decompostion A = LU where L is
        // lower triangular matrix and U is upper triangular matrix. Input is 
        // square matrix A, integer array of pivot indices index[0->n-1], and size
        // of square matrix n. Output factorization LU is in matrix A. If error is 
        // found, method returns 0.
        //------------------------------------------------------------------
        // For thread safe, temporary memory array tmpSize of length size
        // must be passed in.
        public static int LUFactorLinearSystem(double[,] A, int[] index, int size,
                                          double[] tmpSize)
        {
            int i, j, k;
            int maxI = 0;
            double largest, temp1, temp2, sum;

            //
            // Loop over rows to get implicit scaling information
            //
            for (i = 0; i < size; i++)
            {
                for (largest = 0 , j = 0; j < size; j++)
                {
                    if ((temp2 = Math.Abs(A[i, j])) > largest)
                    {
                        largest = temp2;
                    }
                }

                if (largest == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Warning -Unable to factor linear system");
                    return 0;
                }
                tmpSize[i] = 1.0f/ largest;
            }
            //
            // Loop over all columns using Crout's method
            //
            for (j = 0; j < size; j++)
            {
                for (i = 0; i < j; i++)
                {
                    sum = A[i, j];
                    for (k = 0; k < i; k++)
                    {
                        sum -= A[i, k] * A[k, j];
                    }
                    A[i, j] = sum;
                }
                //
                // Begin search for largest pivot element
                //
                for (largest = 0 , i = j; i < size; i++)
                {
                    sum = A[i, j];
                    for (k = 0; k < j; k++)
                    {
                        sum -= A[i, k] * A[k, j];
                    }
                    A[i, j] = sum;

                    if ((temp1 = tmpSize[i] * Math.Abs(sum)) >= largest)
                    {
                        largest = temp1;
                        maxI = i;
                    }
                }
                //
                // Check for row interchange
                //
                if (j != maxI)
                {
                    for (k = 0; k < size; k++)
                    {
                        temp1 = A[maxI, k];
                        A[maxI, k] = A[j, k];
                        A[j, k] = temp1;
                    }
                    tmpSize[maxI] = tmpSize[j];
                }
                //
                // Divide by pivot element and perform elimination
                //
                index[j] = maxI;

                if (Math.Abs(A[j, j]) <= VTK_SMALL_NUMBER)
                {
                    System.Diagnostics.Debug.WriteLine("Warning -Unable to factor linear system");
                    return 0;
                }

                if (j != (size - 1))
                {
                    temp1 = 1.0f/ A[j, j];
                    for (i = j + 1; i < size; i++)
                    {
                        A[i, j] *= temp1;
                    }
                }
            }

            return 1;
        }



        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        // All of the following methods are for dealing with 3x3 matrices
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------

        //----------------------------------------------------------------------------
        // helper function, swap two 3-vectors

        public static void SwapVectors3(int i, int j, double[,] v1, double[,] v2)
        {
            for (int k = 0; k < 3; k++)
            {
                double tmp = v1[i,k];
                v1[i, k] = v2[j, k];
                v2[j, k] = tmp;
            }
        }

        //----------------------------------------------------------------------------
        // Unrolled LU factorization of a 3x3 matrix with pivoting.
        // This decomposition is non-standard in that the diagonal
        // elements are inverted, to convert a division to a multiplication
        // in the backsubstitution.

        public static void LUFactor3x3_1(double[,] A, int[] index)
        {
            int i, maxI;
            double tmp;
            double largest;
            double[] scale = new double[3];

            // Loop over rows to get implicit scaling information

            for (i = 0; i < 3; i++)
            {
                largest = Math.Abs(A[i, 0]);
                if ((tmp = Math.Abs(A[i, 1])) > largest)
                {
                    largest = tmp;
                }
                if ((tmp = Math.Abs(A[i, 2])) > largest)
                {
                    largest = tmp;
                }
                scale[i] = 1.0f/ largest;
            }

            // Loop over all columns using Crout's method

            // first column
            largest = scale[0] * Math.Abs(A[0, 0]);
            maxI = 0;
            if ((tmp = scale[1] * Math.Abs(A[1, 0])) >= largest)
            {
                largest = tmp;
                maxI = 1;
            }
            if ((tmp = scale[2] * Math.Abs(A[2, 0])) >= largest)
            {
                maxI = 2;
            }
            if (maxI != 0)
            {
                SwapVectors3(maxI, 0, A, A);
                scale[maxI] = scale[0];
            }
            index[0] = maxI;

            A[0, 0] = 1.0f/ A[0, 0];
            A[1, 0] *= A[0, 0];
            A[2, 0] *= A[0, 0];

            // second column
            A[1, 1] -= A[1, 0] * A[0, 1];
            A[2, 1] -= A[2, 0] * A[0, 1];
            largest = scale[1] * Math.Abs(A[1, 1]);
            maxI = 1;
            if ((tmp = scale[2] * Math.Abs(A[2, 1])) >= largest)
            {
                maxI = 2;
                SwapVectors3(2, 1, A, A);
                scale[2] = scale[1];
            }
            index[1] = maxI;
            A[1, 1] = (1) / A[1, 1];
            A[2, 1] *= A[1, 1];

            // third column
            A[1, 2] -= A[1, 0] * A[0, 2];
            A[2, 2] -= A[2, 0] * A[0, 2] + A[2, 1] * A[1, 2];
            largest = scale[2] * Math.Abs(A[2, 2]);
            index[2] = 2;
            A[2, 2] = (1) / A[2, 2];
        }

        ////----------------------------------------------------------------------------
        //void LUFactor3x3(double[,] A, int[] index)
        //{
        //    vtkLUFactor3x3(A, index);
        //}

        //----------------------------------------------------------------------------
        public static void LUFactor3x3(double[,] A, int[] index)
        {
            LUFactor3x3_1(A, index);
        }

        //----------------------------------------------------------------------------
        // Backsubsitution with an LU-decomposed matrix.  This is the standard
        // LU decomposition, except that the diagonals elements have been inverted.

        public static void vtkLUSolve3x3(double[,] A, int[] index, double[] x)
        {
            double sum;

            // forward substitution

            sum = x[index[0]];
            x[index[0]] = x[0];
            x[0] = sum;

            sum = x[index[1]];
            x[index[1]] = x[1];
            x[1] = sum - A[1, 0] * x[0];

            sum = x[index[2]];
            x[index[2]] = x[2];
            x[2] = sum - A[2, 0] * x[0] - A[2, 1] * x[1];

            // back substitution

            x[2] = x[2] * A[2, 2];
            x[1] = (x[1] - A[1, 2] * x[2]) * A[1, 1];
            x[0] = (x[0] - A[0, 1] * x[1] - A[0, 2] * x[2]) * A[0, 0];
        }

      
        //----------------------------------------------------------------------------
        public static void LUSolve3x3(double[,] A, int[] index, double[] x)
        {
            vtkLUSolve3x3(A, index, x);
        }

        //----------------------------------------------------------------------------
        // this method solves Ay = x for y
        public static void LinearSolve3x3_1(double[,] A, double[] x, double[] y)
        {
            int[] index = new int[3];
            double[,] B = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                B[i, 0] = A[i, 0];
                B[i, 1] = A[i, 1];
                B[i, 2] = A[i, 2];
                y[i] = x[i];
            }

            LUFactor3x3(B, index);
            LUSolve3x3(B, index, y);
        }

       
        //----------------------------------------------------------------------------
        public static void LinearSolve3x3(double[,] A,
                                      double[] x, double[] y)
        {
            LinearSolve3x3_1(A, x, y);
        }

        //----------------------------------------------------------------------------
        public static void vtkMultiply3x3(double[,] A, double[] v, double[] u)
        {
            double x = A[0, 0] * v[0] + A[0, 1] * v[1] + A[0, 2] * v[2];
            double y = A[1, 0] * v[0] + A[1, 1] * v[1] + A[1, 2] * v[2];
            double z = A[2, 0] * v[0] + A[2, 1] * v[1] + A[2, 2] * v[2];

            u[0] = x;
            u[1] = y;
            u[2] = z;
        }
        public double[] Multiply3x3(double[,] A, double[] v)
        {
            double[] u = new double[3];
            double x = A[0, 0] * v[0] + A[0, 1] * v[1] + A[0, 2] * v[2];
            double y = A[1, 0] * v[0] + A[1, 1] * v[1] + A[1, 2] * v[2];
            double z = A[2, 0] * v[0] + A[2, 1] * v[1] + A[2, 2] * v[2];

            u[0] = x;
            u[1] = y;
            u[2] = z;
            return u;
        }

    
        //----------------------------------------------------------------------------
        public static void Multiply3x3(double[,] A, double[] v, double[] u)
        {
            vtkMultiply3x3(A, v, u);
        }

        //----------------------------------------------------------------------------
        public static void vtkMultiplyMatrix3dx3(double[,] A, double[,] B,
                                                double[,] C)
        {
            double[,] D = new double[3,3];

            for (int i = 0; i < 3; i++)
            {
                D[0, i] = A[0, 0] * B[0, i] + A[0, 1] * B[1, i] + A[0, 2] * B[2, i];
                D[1, i] = A[1, 0] * B[0, i] + A[1, 1] * B[1, i] + A[1, 2] * B[2, i];
                D[2, i] = A[2, 0] * B[0, i] + A[2, 1] * B[1, i] + A[2, 2] * B[2, i];
            }

            for (int j = 0; j < 3; j++)
            {
                C[j, 0] = D[j, 0];
                C[j, 1] = D[j, 1];
                C[j, 2] = D[j, 2];
            }
        }

     
        public static void Transpose3x3_1(double[,] A, double[,] AT)
        {
            double tmp;
            tmp = A[1, 0];
            AT[1, 0] = A[0, 1];
            AT[0, 1] = tmp;
            tmp = A[2, 0];
            AT[2, 0] = A[0, 2];
            AT[0, 2] = tmp;
            tmp = A[2, 1];
            AT[2, 1] = A[1, 2];
            AT[1, 2] = tmp;

            AT[0, 0] = A[0, 0];
            AT[1, 1] = A[1, 1];
            AT[2, 2] = A[2, 2];
        }

      
        //----------------------------------------------------------------------------
        public static void Transpose3x3(double[,] A, double[,] AT)
        {
            Transpose3x3_1(A, AT);
        }

        //----------------------------------------------------------------------------
        public static double[] VectorFromMatrix(int rowIndex, double[,] matrix)
        {
            double[] vector = new double[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                vector[i] = matrix[rowIndex, i];
            }
            return vector;
        }
        public static double[,] CopyMatrix(double[,] original)
        {
            double[,] copied = new double[original.GetLength(0), original.GetLength(1)];
            int nCount = original.GetLength(0);
            for (int i = 0; i < nCount; i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                    copied[i, j] = original[i, j];
            }
            return copied;

        }
        public static void Invert3x3_1(double[,] A, double[,] AI)
        {
            int[] index = new int[3];
            double[,] tmp = new double[3, 3];

            for (int k = 0; k < 3; k++)
            {
                AI[k, 0] = A[k, 0];
                AI[k, 1] = A[k, 1];
                AI[k, 2] = A[k, 2];
            }
            // invert one column at a time
            LUFactor3x3(AI, index);
            for (int i = 0; i < 3; i++)
            {
                double[] x = VectorFromMatrix(i, tmp);
                
                
                x[0] = x[1] = x[2] = 0.0f;
                x[i] = 1.0f;
                LUSolve3x3(AI, index, x);
            }
            for (int j = 0; j < 3; j++)
            {
                double[] x = VectorFromMatrix(j, tmp);
                
               
                AI[0, j] = x[0];
                AI[1, j] = x[1];
                AI[2, j] = x[2];
            }
        }

       
        //----------------------------------------------------------------------------
        public static void Invert3x3(double[,] A, double[,] AI)
        {
            Invert3x3_1(A, AI);
        }

        //----------------------------------------------------------------------------

        public static void Identity3x3_1(double[,] A)
        {
            for (int i = 0; i < 3; i++)
            {
                A[i, 0] = A[i, 1] = A[i, 2] = 0.0f;
                A[i, i] = 1.0f;
            }
        }

      

        //----------------------------------------------------------------------------
        public static void Identity3x3(double[,] A)
        {
            Identity3x3_1(A);
        }

        //----------------------------------------------------------------------------

        public static void QuaternionToMatrix3dx3_1(double[] quat, double[,] A)
        {
            double ww = quat[0] * quat[0];
            double wx = quat[0] * quat[1];
            double wy = quat[0] * quat[2];
            double wz = quat[0] * quat[3];

            double xx = quat[1] * quat[1];
            double yy = quat[2] * quat[2];
            double zz = quat[3] * quat[3];

            double xy = quat[1] * quat[2];
            double xz = quat[1] * quat[3];
            double yz = quat[2] * quat[3];

            double rr = xx + yy + zz;
            // normalization factor, just in case quaternion was not normalized
            double f = Convert.ToSingle( 1 / Math.Sqrt(ww + rr));
            double s = (ww - rr) * f;
            f *= 2;

            A[0, 0] = xx * f + s;
            A[1, 0] = (xy + wz) * f;
            A[2, 0] = (xz - wy) * f;

            A[0, 1] = (xy - wz) * f;
            A[1, 1] = yy * f + s;
            A[2, 1] = (yz + wx) * f;

            A[0, 2] = (xz + wy) * f;
            A[1, 2] = (yz - wx) * f;
            A[2, 2] = zz * f + s;
        }

       
        //----------------------------------------------------------------------------
        public static void QuaternionToMatrix3dx3(double[] quat, double[,] A)
        {
            QuaternionToMatrix3dx3_1(quat, A);
        }

        //----------------------------------------------------------------------------
        //  The solution is based on
        //  Berthold K. P. Horn (1987),
        //  "Closed-form solution of absolute orientation using unit quaternions,"
        //  Journal of the Optical Society of America A, 4:629-642

        public static void Matrix3dx3ToQuaternion_1(double[,] A, double[] quat)
        {
            double[,] N = new double[4, 4];

            // on-diagonal elements
            N[0, 0] = A[0, 0] + A[1, 1] + A[2, 2];
            N[1, 1] = A[0, 0] - A[1, 1] - A[2, 2];
            N[2, 2] = -A[0, 0] + A[1, 1] - A[2, 2];
            N[3, 3] = -A[0, 0] - A[1, 1] + A[2, 2];

            // off-diagonal elements
            N[0, 1] = N[1, 0] = A[2, 1] - A[1, 2];
            N[0, 2] = N[2, 0] = A[0, 2] - A[2, 0];
            N[0, 3] = N[3, 0] = A[1, 0] - A[0, 1];

            N[1, 2] = N[2, 1] = A[1, 0] + A[0, 1];
            N[1, 3] = N[3, 1] = A[0, 2] + A[2, 0];
            N[2, 3] = N[3, 2] = A[2, 1] + A[1, 2];

            double[,] eigenvectors = new double[4, 4];
            double[] eigenvalues = new double[4];

            // convert into format that JacobiN can use,
            // then use Jacobi to find eigenvalues and eigenvectors

            double[,] NTemp = CopyMatrix(N);
            double[,] eigenvectorsTemp = CopyMatrix(eigenvectors);

        
            JacobiN(NTemp, 4, eigenvalues, eigenvectorsTemp);

            // the first eigenvector is the one we want
            quat[0] = eigenvectors[0, 0];
            quat[1] = eigenvectors[1, 0];
            quat[2] = eigenvectors[2, 0];
            quat[3] = eigenvectors[3, 0];
        }

      

        //----------------------------------------------------------------------------
        public static void Matrix3dx3ToQuaternion(double[,] A, double[] quat)
        {
            Matrix3dx3ToQuaternion_1(A, quat);
        }

        //----------------------------------------------------------------------------
        //  The orthogonalization is done via quaternions in order to avoid
        //  having to use a singular value decomposition algorithm.  
        public static void Orthogonalize3x3_1(double[,] A, double[,] B)
        {
            int i;

            // copy the matrix
            for (i = 0; i < 3; i++)
            {
                B[0, i] = A[0, i];
                B[1, i] = A[1, i];
                B[2, i] = A[2, i];
            }

            // Pivot the matrix to improve accuracy
            double[] scale = new double[3];
            int[] index = new int[3];
            double tmp, largest;

            // Loop over rows to get implicit scaling information
            for (i = 0; i < 3; i++)
            {
                largest = Math.Abs(B[i, 0]);
                if ((tmp = Math.Abs(B[i, 1])) > largest)
                {
                    largest = tmp;
                }
                if ((tmp = Math.Abs(B[i, 2])) > largest)
                {
                    largest = tmp;
                }
                scale[i] = 1.0f;
                if (largest != 0)
                {
                    scale[i] = (1) / largest;
                }
            }

            // first column
            index[0] = 0;
            largest = scale[0] * Math.Abs(B[0, 0]);
            if ((tmp = scale[1] * Math.Abs(B[1, 0])) >= largest)
            {
                largest = tmp;
                index[0] = 1;
            }
            if ((tmp = scale[2] * Math.Abs(B[2, 0])) >= largest)
            {
                index[0] = 2;
            }
            if (index[0] != 0)
            {
                SwapVectors3(index[0], 0, B, B);
                scale[index[0]] = scale[0];
            }

            // second column
            index[1] = 1;
            largest = scale[1] * Math.Abs(B[1, 1]);
            if ((tmp = scale[2] * Math.Abs(B[2, 1])) >= largest)
            {
                index[1] = 2;
                SwapVectors3(2, 1,  B, B);
            }

            // third column
            index[2] = 2;

            // A quaternian can only describe a pure rotation, not
            // a rotation with a flip, therefore the flip must be
            // removed before the matrix is converted to a quaternion.
            double d = vtkDeterminant3x3(B);
            if (d < 0)
            {
                for (i = 0; i < 3; i++)
                {
                    B[0, i] = -B[0, i];
                    B[1, i] = -B[1, i];
                    B[2, i] = -B[2, i];
                }
            }

            // Do orthogonalization using a quaternion intermediate
            // (this, essentially, does the orthogonalization via
            // diagonalization of an appropriately constructed symmetric
            // 4x4 matrix rather than by doing SVD of the 3x3 matrix)
            double[] quat = new double[4];
            Matrix3dx3ToQuaternion(B, quat);
            QuaternionToMatrix3dx3(quat, B);

            // Put the flip back into the orthogonalized matrix.
            if (d < 0)
            {
                for (i = 0; i < 3; i++)
                {
                    B[0, i] = -B[0, i];
                    B[1, i] = -B[1, i];
                    B[2, i] = -B[2, i];
                }
            }

            // Undo the pivoting
            if (index[1] != 1)
            {
                SwapVectors3(index[1], 1,  B, B);
            }
            if (index[0] != 0)
            {
                SwapVectors3(index[0], 0, B, B);
                
            }
        }

    

        //----------------------------------------------------------------------------
        public static void Orthogonalize3x3(double[,] A, double[,] B)
        {
            Orthogonalize3x3_1(A, B);
        }

     
        //----------------------------------------------------------------------------
        public static double Norm(double[] x, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += x[i] * x[i];
            }

            return Convert.ToSingle(Math.Sqrt(sum));
        }

        //----------------------------------------------------------------------------
        // Extract the eigenvalues and eigenvectors from a 3x3 matrix.
        // The eigenvectors (the columns of V) will be normalized. 
        // The eigenvectors are aligned optimally with the x, y, and z
        // axes respectively.
        public static void Diagonalize3x3_1(double[,] A, double[] w, double[,] V)
        {
            int i, j,  k, maxI;
            double tmp, maxVal;

            // do the matrix[3,3] to matrix conversion for Jacobi
            double[,] C = new double[3, 3];
            double[,] ATemp = new double[3,3];
            double[,] VTemp = new double[3,3];
            for (i = 0; i < 3; i++)
            {
                C[i, 0] = A[i, 0];
                C[i, 1] = A[i, 1];
                C[i, 2] = A[i, 2];
                for (j = 0; j < 3; j++)
                {
                    ATemp[i,j] = C[i,j];
                    VTemp[i,j] = V[i,j];
                }
               
            }

            // diagonalize using Jacobi
            JacobiN(ATemp, 3, w, VTemp);

            // if all the eigenvalues are the same, return identity matrix
            if (w[0] == w[1] && w[0] == w[2])
            {
                Identity3x3(V);
                return;
            }

            // transpose temporarily, it makes it easier to sort the eigenvectors
            Transpose3x3(V, V);

            // if two eigenvalues are the same, re-orthogonalize to optimally line
            // up the eigenvectors with the x, y, and z axes
            for (i = 0; i < 3; i++)
            {
                if (w[(i + 1) % 3] == w[(i + 2) % 3]) // two eigenvalues are the same
                {
                    // find maximum element of the independant eigenvector
                    maxVal = Math.Abs(V[i, 0]);
                    maxI = 0;
                    for (j = 1; j < 3; j++)
                    {
                        if (maxVal < (tmp = Math.Abs(V[i, j])))
                        {
                            maxVal = tmp;
                            maxI = j;
                        }
                    }
                    // swap the eigenvector into its proper position
                    if (maxI != i)
                    {
                        tmp = w[maxI];
                        w[maxI] = w[i];
                        w[i] = tmp;
                        SwapVectors3(i, maxI, V, V);
                    }
                    // maximum element of eigenvector should be positive
                    if (V[maxI, maxI] < 0)
                    {
                        V[maxI, 0] = -V[maxI, 0];
                        V[maxI, 1] = -V[maxI, 1];
                        V[maxI, 2] = -V[maxI, 2];
                    }

                    // re-orthogonalize the other two eigenvectors
                    j = (maxI + 1) % 3;
                    k = (maxI + 2) % 3;

                    V[j, 0] = 0.0f;
                    V[j, 1] = 0.0f;
                    V[j, 2] = 0.0f;
                    V[j, j] = 1.0f;
                    Cross(V, V, V, maxI, j, k);
                    Normalize(k, V);
                    Cross(V, V, V, k, maxI, j);
                    

                    // transpose vectors back to columns
                    Transpose3x3(V, V);
                    return;
                }
            }

            // the three eigenvalues are different, just sort the eigenvectors
            // to align them with the x, y, and z axes

            // find the vector with the largest x element, make that vector
            // the first vector
            maxVal = Math.Abs(V[0, 0]);
            maxI = 0;
            for (i = 1; i < 3; i++)
            {
                if (maxVal < (tmp = Math.Abs(V[i, 0])))
                {
                    maxVal = tmp;
                    maxI = i;
                }
            }
            // swap eigenvalue and eigenvector
            if (maxI != 0)
            {
                tmp = w[maxI];
                w[maxI] = w[0];
                w[0] = tmp;
                SwapVectors3(maxI, 0, V, V);
            }
            // do the same for the y element
            if (Math.Abs(V[1, 1]) < Math.Abs(V[2, 1]))
            {
                tmp = w[2];
                w[2] = w[1];
                w[1] = tmp;
                SwapVectors3(2, 1, V, V);
            }

            // ensure that the sign of the eigenvectors is correct
            for (i = 0; i < 2; i++)
            {
                if (V[i, i] < 0)
                {
                    V[i, 0] = -V[i, 0];
                    V[i, 1] = -V[i, 1];
                    V[i, 2] = -V[i, 2];
                }
            }
            // set sign of final eigenvector to ensure that determinant is positive
            if (Determinant3x3(V) < 0)
            {
                V[2, 0] = -V[2, 0];
                V[2, 1] = -V[2, 1];
                V[2, 2] = -V[2, 2];
            }

            // transpose the eigenvectors back again
            Transpose3x3(V, V);
        }

        ////----------------------------------------------------------------------------
        //void Diagonalize3x3(double[,] A, double[] w, double[,] V)
        //{
        //    vtkDiagonalize3x3(A, w, V);
        //}

        //----------------------------------------------------------------------------
        public static void Diagonalize3x3(double[,] A, double[] w, double[,] V)
        {
            Diagonalize3x3_1(A, w, V);
        }

        //----------------------------------------------------------------------------
        // Perform singular value decomposition on the matrix A:
        //    A = U * W * VT
        // where U and VT are orthogonal W is diagonal (the diagonal elements
        // are returned in vector w).
        // The matrices U and VT will both have positive determinants.
        // The scale factors w are ordered according to how well the
        // corresponding eigenvectors (in VT) match the x, y and z axes
        // respectively.
        //
        // The singular value decomposition is used to decompose a linear
        // transformation into a rotation, followed by a scale, followed
        // by a second rotation.  The scale factors w will be negative if
        // the determinant of matrix A is negative.
        //
        // Contributed by David Gobbi (dgobbi@irus.rri.on.ca)

        public static void SingularValueDecomposition3x3_1(double[,] A,
                                                           double[,] U, double[] w,
                                                           double[,] VT)
        {
            int i;
            double[,] B = new double[3, 3];

            // copy so that A can be used for U or VT without risk
            for (i = 0; i < 3; i++)
            {
                B[0, i] = A[0, i];
                B[1, i] = A[1, i];
                B[2, i] = A[2, i];
            }

            // temporarily flip if determinant is negative
            double d = Determinant3x3(B);
            if (d < 0)
            {
                for (i = 0; i < 3; i++)
                {
                    B[0, i] = -B[0, i];
                    B[1, i] = -B[1, i];
                    B[2, i] = -B[2, i];
                }
            }

            // orthogonalize, diagonalize, etc.
            
            
            Orthogonalize3x3(B, U);
            //double[,] Bf = OpenTKLib.MatrixUtilsNumerics.ToFloat(B);
            //double[,] Uf = OpenTKLib.MatrixUtilsNumerics.ToFloat(U);


            //OpenTKLib.MatrixUtilsNumerics.Orthogonalize(ref Bf, ref Uf);

            Transpose3x3(B, B);
            vtkMultiplyMatrix3dx3(B, U, VT);
            //Multiply3x3(B, U, VT);
            Diagonalize3x3(VT, w, VT);
            vtkMultiplyMatrix3dx3(U, VT, U);
            //Multiply3x3(U, VT, U);
            Transpose3x3(VT, VT);

            // re-create the flip
            if (d < 0)
            {
                w[0] = -w[0];
                w[1] = -w[1];
                w[2] = -w[2];
            }


        }
     
        //----------------------------------------------------------------------------
        public static void SingularValueDecomposition3x3(double[,] A,
                                                    double[,] U, double[] w,
                                                    double[,] VT)
        {
            SingularValueDecomposition3x3_1(A, U, w, VT);
        }

        //----------------------------------------------------------------------------
        public static void RGBToHSV(double r, double g, double b,
                               ref double h, ref double s, ref double v)
        {
            double dh = 0;
            double ds = 0;
            double dv = 0;
            RGBToHSV(r, g, b, ref dh, ref ds, ref dv);
            h = Convert.ToSingle(dh);
            s = Convert.ToSingle(ds);
            v = Convert.ToSingle(dv);
        }

        //----------------------------------------------------------------------------
        public static double[] RGBToHSV(double[] rgb)
        {
            return RGBToHSV(rgb[0], rgb[1], rgb[2]);
        }

        //----------------------------------------------------------------------------
        public static double[] RGBToHSV(double r, double g, double b)
        {
            double[] hsv = new double[3];
            RGBToHSV(r, g, b, ref hsv[0], ref hsv[1], ref hsv[2]);
            return hsv;
        }

        //----------------------------------------------------------------------------
     

        //----------------------------------------------------------------------------
        public static void HSVToRGB(double h, double s, double v,
                               double r, double g, double b)
        {
            double dr = 0;
            double dg = 0;
                double db = 0;
            HSVToRGB(h, s, v, ref dr, ref dg, ref db);
            r = Convert.ToSingle(dr);
            g = Convert.ToSingle(dg);
            b = Convert.ToSingle(db);
        }

        //----------------------------------------------------------------------------
        public static double[] HSVToRGB(double[] hsv)
        {
            return HSVToRGB(hsv[0], hsv[1], hsv[2]);
        }

        //----------------------------------------------------------------------------
        public static double[] HSVToRGB(double h, double s, double v)
        {
            double[] rgb = new double[3];
            HSVToRGB(h, s, v, ref rgb[0], ref rgb[1], ref rgb[2]);
            return rgb;
        }

        //----------------------------------------------------------------------------
        public static void HSVToRGB(double h, double s, double v,
                               ref double r, ref double g, ref double b)
        {
            double onethird = 1.0f/ 3.0f;
            double onesixth = 1.0f/ 6.0f;
            double twothird = 2/ 3.0f;
            double fivesixth = 5.0f / 6.0f;

            // compute RGB from HSV
            if (h > onesixth && h <= onethird) // green/red
            {
                g = 1.0f;
                r = (onethird - h) / onesixth;
                b = 0.0f;
            }
            else if (h > onethird && h <= 0.5) // green/blue
            {
                g = 1.0f;
                b = (h - onethird) / onesixth;
                r = 0.0f;
            }
            else if (h > 0.5f && h <= twothird) // blue/green
            {
                b = 1.0f;
                g = (twothird - h) / onesixth;
                r = 0.0f;
            }
            else if (h > twothird && h <= fivesixth) // blue/red
            {
                b = 1.0f;
                r = (h - twothird) / onesixth;
                g = 0.0f;
            }
            else if (h > fivesixth && h <= 1) // red/blue
            {
                r = 1.0f;
                b = (1.0f- h) / onesixth;
                g = 0.0f;
            }
            else // red/green
            {
                r = 1.0f;
                g = h / onesixth;
                b = 0.0f;
            }

            // add Saturation to the equation.
            r = (s * r + (1.0f- s));
            g = (s * g + (1.0f- s));
            b = (s * b + (1.0f- s));

            r *= v;
            g *= v;
            b *= v;
        }

        //----------------------------------------------------------------------------
        public static void LabToOriginAxes(double[] lab, double[] xyz)
        {
            //LAB to XYZ
            double var_Y = (lab[0] + 16) / 116;
            double var_X = lab[1] / 500 + var_Y;
            double var_Z = var_Y - lab[2] / 200;

            if (Math.Pow(var_Y, 3) > 0.008856) var_Y = Convert.ToSingle(Math.Pow(var_Y, 3));
            else var_Y = (var_Y - 16 / 116) / 7.787f;

            if (Math.Pow(var_X, 3) > 0.008856f) var_X = Convert.ToSingle(Math.Pow(var_X, 3));
            else var_X = (var_X - 16 / 116) / 7.787f;

            if (Math.Pow(var_Z, 3) > 0.008856f) var_Z = Convert.ToSingle(Math.Pow(var_Z, 3));
            else var_Z = (var_Z - 16 / 116) / 7.787f;
            double ref_X = 95.047f;
            double ref_Y = 100.000f;
            double ref_Z = 108.883f;
            xyz[0] = ref_X * var_X;     //ref_X =  95.047  Observer= 2 Illuminant= D65
            xyz[1] = ref_Y * var_Y;     //ref_Y = 100.000
            xyz[2] = ref_Z * var_Z;     //ref_Z = 108.883
        }


        //----------------------------------------------------------------------------
        public static void XYZToRGB(double[] xyz, double[] rgb)
        {

            //double ref_X =  95.047;        //Observer = 2° Illuminant = D65
            //double ref_Y = 100.000;
            //double ref_Z = 108.883;

            double var_X = xyz[0] / 100;        //X = From 0 to ref_X
            double var_Y = xyz[1] / 100;        //Y = From 0 to ref_Y
            double var_Z = xyz[2] / 100;        //Z = From 0 to ref_Y

            double var_R = var_X * 3.2406f + var_Y * -1.5372f + var_Z * -0.4986f;
            double var_G = var_X * -0.9689f + var_Y * 1.8758f + var_Z * 0.0415f;
            double var_B = var_X * 0.0557f + var_Y * -0.2040f + var_Z * 1.0570f;

            if (var_R > 0.0031308f) var_R = Convert.ToSingle( 1.055f * (Math.Pow(var_R, (1 / 2.4f))) - 0.055f);
            else var_R = 12.92f * var_R;
            if (var_G > 0.0031308f) var_G =Convert.ToSingle(1.055f * (Math.Pow(var_G, (1 / 2.4f))) - 0.055f);
            else var_G = 12.92f * var_G;
            if (var_B > 0.0031308f) var_B =Convert.ToSingle(1.055f * (Math.Pow(var_B, (1 / 2.4f))) - 0.055f);
            else var_B = 12.92f * var_B;

            rgb[0] = var_R;
            rgb[1] = var_G;
            rgb[2] = var_B;

            //clip colors. ideally we would do something different for colors
            //out of gamut, but not really sure what to do atm.
            if (rgb[0] < 0) rgb[0] = 0;
            if (rgb[1] < 0) rgb[1] = 0;
            if (rgb[2] < 0) rgb[2] = 0;
            if (rgb[0] > 1) rgb[0] = 1;
            if (rgb[1] > 1) rgb[1] = 1;
            if (rgb[2] > 1) rgb[2] = 1;

        }
        //----------------------------------------------------------------------------
        public static void ClampValues(double values,
                                  int nb_values,
                                   double[] range)
        {
            if (values != 0 || nb_values <= 0 || range != null)
            {
                return;
            }

            double values_end = values + nb_values;
            while (values < values_end)
            {
                if (values < range[0])
                {
                    values = range[0];
                }
                else if (values > range[1])
                {
                    values = range[1];
                }
                values++;
            }
        }

        //----------------------------------------------------------------------------
        public static void ClampValues(double values, int nb_values, double[] range, double clamped_values)
        {
            if (values == 0 || nb_values <= 0 || range == null || clamped_values == 0)
            {
                return;
            }

            double values_end = values + nb_values;
            while (values < values_end)
            {
                if (values < range[0])
                {
                    clamped_values = range[0];
                }
                else if (values > range[1])
                {
                    clamped_values = range[1];
                }
                else
                {
                    clamped_values = values;
                }
                values++;
                clamped_values++;
            }
        }


        public static int ExtentIsWithinOtherExtent(int[] extent1, int[] extent2)
        {
            if ( extent1 == null || extent2 == null)
            {
                return 0;
            }

            int i;
            for (i = 0; i < 6; i += 2)
            {
                if (extent1[i] < extent2[i] || extent1[i] > extent2[i + 1] ||
                    extent1[i + 1] < extent2[i] || extent1[i + 1] > extent2[i + 1])
                {
                    return 0;
                }
            }

            return 1;
        }

        //----------------------------------------------------------------------------

        public static int BoundsIsWithinOtherBounds(double[] bounds1, double[] bounds2, double[] delta)
        {
            if ( bounds1 == null || bounds2 == null)
            {
                return 0;
            }
            for (int i = 0; i < 6; i += 2)
            {

                if (bounds1[i] + delta[i / 2] < bounds2[i] || bounds1[i] - delta[i / 2] > bounds2[i + 1] ||
                   bounds1[i + 1] + delta[i / 2] < bounds2[i] || bounds1[i + 1] - delta[i / 2] > bounds2[i + 1])
                    return 0;
            }
            return 1;
        }

        //----------------------------------------------------------------------------
        public static int PointIsWithinBounds(double[] point, double[] bounds, double[] delta)
        {
            if (point == null || bounds == null || delta == null)
            {
                return 0;
            }
            for (int i = 0; i < 3; i++)
                if (point[i] + delta[i] < bounds[2 * i] || point[i] - delta[i] > bounds[2 * i + 1])
                    return 0;
            return 1;

        }
    
        public static double[] TransformPointdoubleMatTranspose(double[] pointSource, double[,] matrix)
        {
            double[] pointReturn = new double[3];
            pointReturn[0] = matrix[0, 0] * pointSource[0] + matrix[1, 0] * pointSource[1] + matrix[2, 0] * pointSource[2] + matrix[3, 0];
            pointReturn[1] = matrix[0, 1] * pointSource[0] + matrix[1, 1] * pointSource[1] + matrix[2, 1] * pointSource[2] + matrix[3, 1];
            pointReturn[2] = matrix[0, 2] * pointSource[0] + matrix[1, 2] * pointSource[1] + matrix[2, 2] * pointSource[2] + matrix[3, 2];

            return pointReturn;

        }
        public static double[] TransformPointFloat(double[] pointSource, double[,] matrix)
        {
            double[] pointReturn = new double[3];
            pointReturn[0] = matrix[0, 0] * pointSource[0] + matrix[0, 1] * pointSource[1] + matrix[0, 2] * pointSource[2] + matrix[0, 3];
            pointReturn[1] = matrix[1, 0] * pointSource[0] + matrix[1, 1] * pointSource[1] + matrix[1, 2] * pointSource[2] + matrix[1, 3];
            pointReturn[2] = matrix[2, 0] * pointSource[0] + matrix[2, 1] * pointSource[1] + matrix[2, 2] * pointSource[2] + matrix[2, 3];

            return pointReturn;

        }
      
        public static PointCloudVertices TransformPoints(PointCloudVertices a, Matrix4d matrix)//, bool matInverse)
        {

            PointCloudVertices b = new PointCloudVertices();

            double[,] matrixdouble = matrix.ToDoubleArray();

            double[] pointTransformed = null;
            for (int i = 0; i < a.Count; i++)
            {
                Vertex p1 = a[i];

                double[] pointSource = new double[3] { p1.Vector.X, p1.Vector.Y, p1.Vector.Z };
                pointTransformed = Matrix4dExtension.TransformPointdouble(pointSource, matrixdouble);
                //if(matInverse)
                //    pointTransformed = MathUtils.TransformPointdoubleMatTranspose(pointSource, matrixdouble);
                Vertex v = new Vertex(pointTransformed[0], pointTransformed[1], pointTransformed[2]);
                v.Color = p1.Color;
                b.Add(v);
            }


            return b;
        }
     

        public static void FindTransformationMatrix(List<Vector3d> pointsSource, List<Vector3d> pointsTarget, LandmarkTransform myLandmarkTransform)
        {
            myLandmarkTransform.Matrix = new Matrix4d();
            myLandmarkTransform.SourceLandmarks = pointsSource;
            myLandmarkTransform.TargetLandmarks = pointsTarget;
            myLandmarkTransform.Update();

        }
     

    }
}
