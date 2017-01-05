using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation {
    class SimObjectWolf  : SimObject{
        SimObject preySim;
        public SimObjectWolf(SimObject sim) {
            preySim = sim;
        }

        override protected void countForce() {
            double dx = x - preySim.x;
            double dy = y - preySim.y;
            double r = Math.Sqrt(dx * dx + dy * dy);
            if (r == 0) {
                ax = 0; ay = 0;
            }
            else {
                ax = 0.5 * dx / r;
                ay = 0.5 * dy / r;
            }
        }

    }
}
