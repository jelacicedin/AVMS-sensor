using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTKLib;
using OpenTK;

namespace UnitTestsOpenTK.ToDo
{
    [TestFixture]
    [Category("UnitTest")]
    public class VertextTest : TestBase
    {

        public void TimeElapsed()
        {
            DateTime CurrentTime = DateTime.Now;
            string namePerformedOperation = "performedOperation";


            DateTime now = DateTime.Now;
            TimeSpan ts = now - CurrentTime;
            System.Diagnostics.Debug.WriteLine("--Duration for " + namePerformedOperation + " : " + ts.TotalMilliseconds.ToString() + " - miliseconds");
        }

        //[Test]
        //public void Vertex()
        //{
        //    Random r = new Random();
        //    PointCloudVertices pc = new PointCloudVertices();
        //    Vector3d v = new Vector3d(Convert.ToSingle(r.NextDouble()),
        //                               Convert.ToSingle(r.NextDouble()),
        //                               Convert.ToSingle(r.NextDouble()));
        //    Color c = Color.AliceBlue;

        //    for (int i = 0; i < 1e20; i++)
        //    {
               
        //        Vertex vv = new Vertex(i, v, c);
        //        VertexSimple v1 = new VertexSimple(i, v, c);

        //        //pc.Add(vv);
        //    }
         

        //}
    
     
    }
}
