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
        List<SimObject> simsy = new List<SimObject>() ;
        //SimObject simWolf;
        public volatile bool continueSimulation = true;

       
        
        
        public SimPanel(int width, int height) {
            //SimObject.width = width;
            //imObject.height = height;
            for(int i = 0; i< 5; i++) {
                simsy.Add(new SimHorse(i*40+40));
            }
            //Random r = new Random();
            //simWolf = new SimObjectWolf(simsy[r.Next()%simsy.Count]);
            //simsy.Add(simWolf);
        }

        public void startSim() {
            SimHorse.distanceToEnd = 600;
            foreach (SimHorse sim in simsy) {
                Thread t = new Thread(new ThreadStart(
                    () => {
                        while (continueSimulation) {
                            sim.move();
                            if (sim.finished) break;
                            //check boundaries and rebound
                            //Thread.Sleep(10);
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
            Brush br2 = new SolidBrush(Color.Red);
            //g.FillEllipse(br, new Rectangle(20,40,x,y));
            //g.DrawRectangle(pen2, new Rectangle(20, 40, x, y));
            Brush _br;
            foreach (SimObject sim in simsy) {
                if (sim is SimObjectWolf) {
                    _br = br2;
                }
                else _br = br;
                g.FillEllipse(_br, new Rectangle((int)sim.x, (int)sim.y, 10, 10));              
            }
        }

        internal void countMeans() {
            double xs = 0, ys = 0;
            foreach (SimObject sim in simsy) {
                xs += sim.x;
                ys += sim.y;
            }
            SimObject.xs = (float) (xs / simsy.Count());
            SimObject.ys = (float) (ys / simsy.Count());
        }
    }

   
}
