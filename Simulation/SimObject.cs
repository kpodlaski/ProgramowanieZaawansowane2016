using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation {
    class SimObject {
        static Random rand = new Random();
        public static int width, height;
        public int x { set; get; }
        public int y { set; get; }
        public int vx { set; get; }
        public int vy { set; get; }

        public SimObject() {
            x = rand.Next() % 700;
            y = rand.Next() % 350;
            vx = rand.Next() % 3;
            vy = rand.Next() % 3;
        }

        public void move() {
            x += vx;
            y += vy;
            if (x > width || x < 0) reverseX();
            if (y > height || y < 0) reverseY();
        }

        public void reverseX() {
            vx *= -1;
        }
        public void reverseY() {
            vy *= -1;
        }

    }

    
}
