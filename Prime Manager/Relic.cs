using System.Collections.Generic;

namespace Prime_Manager
{
    class Relic
    {
        public string Name { get; set; }
        public int Id { get; set; }
        /*
         * 0 - Lith
         * 1 - Meso
         * 2 - Neo
         * 3 - Axi
         */
        public int Tier { get; set; }
        public IList<Item.Part> Parts { get; set; }
        public bool Vaulted { get; set; }
        public int Have { get; set; }
    }
}