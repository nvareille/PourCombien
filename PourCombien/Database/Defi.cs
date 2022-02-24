using System;

namespace PourCombien.Database
{
    public class Defi
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public int Max { get; set; }
        public int Choix1 { get; set; }
        public int Choix2 { get; set; }
    }
}
