using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Warframe
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<warframe> warframeList = warframe.Get("PRIME");
            IList<weapon> weaponList = weapon.Get("PRIME");
            IList<relic> relicList = relic.Get();

            foreach (warframe item in warframeList)
            {
                warframe.DumpDebug(item);
            }

            foreach (weapon item in weaponList)
            {
                weapon.DumpDebug(item);
            }

            foreach (relic item in relicList)
            {
                relic.DumpDebug(item);
            }
        }
    }
}
