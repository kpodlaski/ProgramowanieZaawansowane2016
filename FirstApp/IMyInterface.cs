using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    interface IMyInterface
    {
        double CountTax(double value);
    }

    interface IMyInterface2
    {
        double CountTax(double value);
        double CountCost(double value);
    }
}
