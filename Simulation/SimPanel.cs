using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation  {
    public class SimPanel   {
        SimObject[] simsy = new SimObject[20] ;
        
        public SimPanel(int width, int height) {
            SimObject.width = width;
            SimObject.height = height;
            for(int i = 0; i< simsy.Length; i++) {
                simsy[i] = new SimObject();
            }
        }

        public void startSim() {
            foreach (SimObject sim in simsy) {
                Thread t = new Thread(new ThreadStart(
                    () => {
                        while (true) {
                            sim.move();
                            //check boundaries and rebound
                            Thread.Sleep(10);
                        }
                    }));
                t.Start();
            }
        }
        

        public void drawSomething(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            //Pen pen = new Pen(System.Drawing.Color.BlueViolet, 4);
            //Pen pen2 = new Pen(System.Drawing.Color.BurlyWood, 1);
            Brush br = new SolidBrush(System.Drawing.Color.BlueViolet);
            //g.FillEllipse(br, new Rectangle(20,40,x,y));
            //g.DrawRectangle(pen2, new Rectangle(20, 40, x, y));
            foreach (SimObject sim in simsy) {
                g.FillEllipse(br, new Rectangle(sim.x, sim.y, 5, 5));
            }
        }
    }

   
}
