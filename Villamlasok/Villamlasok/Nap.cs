using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villamlasok
{
    internal class Nap
    {
        public List<int> Orak { get; set; }

        public Nap(string sor)
        {
            var v = sor.Split(';');
            this.Orak = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                Orak.Add(int.Parse(v[i]));
            }
        }

        public override string ToString()
        {
            return $"{string.Join(" ", Orak)}";
        }
    }
}
