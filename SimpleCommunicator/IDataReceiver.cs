﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    public interface IDataReceiver {
        void dataReceived(String msg);
        }
    }
