using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation {
    class SimObject {
        static Random rand = new Random();
        public static int width, height;
        public static volatile float xs, ys;
        protected double ax, ay;
        public double x { set; get; }
        public double y { set; get; }
        public double vx { set; get; }
        public double vy { set; get; }

        public SimObject() {
            x = rand.Next() % 700;
            y = rand.Next() % 350;
            vx = rand.Next() % 3;
            vy = rand.Next() % 3;
        }

        public void move() {
            countForce();
            x +=  vx-0.5*ax;
            y += vy-0.5*ay;
            vx = vx-ax;
            vy = vx-ay;
            if (x > width || x < 0) {
                reverseX();
                if (x > width) x = width;
                else x = 0;
            }
            if (y > height || y < 0) {
                reverseY();
                if (y > height) y = height;
                else y = 0;
            }
        }

        protected virtual void countForce() {
            /*double dx = x - xs;
            double dy = y - ys;
            double r = Math.Sqrt(dx * dx + dy * dy);
            if (r == 0) {
                ax = 0; ay = 0;
            }
            else {
                ax =  0.5* dx / r;
                ay =  0.5*dy / r;
            }
            */
        }

        public void reverseX() {
            vx *= -1;
        }
        public void reverseY() {
            vy *= -1;
        }

    }

    
}
