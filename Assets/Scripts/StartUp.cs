using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StartUp
    {
        static public void Main(String[] args)
        {

            BeastManager bm = new BeastManager();
            bm.Start();
        }
    }
}
