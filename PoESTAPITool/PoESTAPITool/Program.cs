using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoESTAPITool
{
    class Program
    {


        static void Main(string[] args)
        {
            var stashTab = new StashTab();

            while (true) {
                stashTab.DownloadJsonIntoDir();
            }

        }

        
    }
}
