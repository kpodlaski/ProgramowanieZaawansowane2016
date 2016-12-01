using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    public interface ICommunicator {
        void Send(String msg);
        void RegisterRecepient(IDataReceiver r);
        }
    }
