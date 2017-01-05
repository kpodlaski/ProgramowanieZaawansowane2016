using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation {
    public partial class Form1 : Form {
        private SimPanel simPanel ;
        private Random rand = new Random();
        private System.Threading.Timer timer;
        public Form1() {
            InitializeComponent();
            simPanel = new SimPanel(viewPanel.Width, viewPanel.Height);
            viewPanel.Paint += new PaintEventHandler(simPanel.drawSomething);
        }

       

        delegate void RefreshCallback();
        public void properRefresh() {
            if (!simPanel.continueSimulation) return;
            if ( this.viewPanel.InvokeRequired) {
                RefreshCallback rC = new RefreshCallback(properRefresh);
                try {
                    this.Invoke(rC, null);
                }
                catch(System.ObjectDisposedException e) {
                    Console.WriteLine(e.Message );
                    return;
                }
            }
            else
                viewPanel.Refresh();
        }

        private void startButton_Click(object sender, EventArgs e) {

            simPanel.startSim();
            this.timer = new System.Threading.Timer((et) =>
            {
                this.properRefresh();
                simPanel.countMeans();
            }, null, 0, 30);
            
        }

        private void Form1_Deactivate(object sender, EventArgs e) {
            Console.WriteLine("END FORM");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Console.WriteLine("END FORM 1");
            simPanel.continueSimulation = false;
            if (timer != null) timer.Dispose();
            Thread.Sleep(150);
        }
    }
}
