using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosophes
{
    class ChopStick
    {
        private volatile bool isUsed = false ;

        public void pickUp()
        {
            lock (this) {
                while(!isUsed){
                    isUsed = true;
                }
            }        
        }

        public void putDown()
        {
            lock (this)
            {
                isUsed = false;
            }
        }

        public bool canBeUsed () {
            lock (this)
            {
                return isUsed;
            }
        }


    }
}
