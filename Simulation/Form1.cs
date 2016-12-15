using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation {
    public partial class Form1 : Form {
        private SimPanel simPanel ;
        private Random rand = new Random();
        public Form1() {
            InitializeComponent();
            simPanel = new SimPanel(viewPanel.Width, viewPanel.Height);
            viewPanel.Paint += new PaintEventHandler(simPanel.drawSomething);

        }

       

        delegate void RefreshCallback();
        public void properRefresh() {
            if (this.viewPanel.InvokeRequired) {
                RefreshCallback rC = new RefreshCallback(properRefresh);
                this.Invoke(rC, null);
            }
            else
                viewPanel.Refresh();
        }

        private void startButton_Click(object sender, EventArgs e) {

            simPanel.startSim();
            var timer = new System.Threading.Timer((et) =>
            {
                this.properRefresh();
            }, null, 0, 300);
            
        }
    }
}
