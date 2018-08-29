using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe
{
    class prime
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Constructed { get; set; }
        public bool Vaulted { get; set; }
        public IList<Part> Parts { get; set; }

        public class Part
        {
            public string PartName { get; set; }
            public string ItemŃame { get; set; }
            public string Rarity { get; set; }
            public ushort Needed { get; set; }
            public ushort Have { get; set; }
        }
    }
}
