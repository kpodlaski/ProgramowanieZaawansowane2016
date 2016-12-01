using SimpleCommunicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCommunicator{
    public partial class ComWindow : Form, IDataReceiver {
        ICommunicator communicator;
        public ComWindow(ICommunicator communicator) {
            InitializeComponent();
            this.communicator = communicator;
            communicator.RegisterRecepient(this);

            }

        public void dataReceived(string msg) {
            SetText("Otrzymano:" + msg);
            }

        private void button1_Click(object sender, EventArgs e) {
                communicator.Send(textToSend.Text);
                SetText("Wysłano:" + textToSend.Text);
                //textToSend.Text = "";
            }

        delegate void SetTextCallback(string text);
        private void SetText(String text) {
            if (this.textReceived.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                }
            else {
                this.textReceived.Text += text;
                }
            }


        private void mydrag(object sender, DragEventArgs e) {

            }
        }
    }
