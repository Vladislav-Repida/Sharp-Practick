using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    class EditionComparer : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            return x.ReleaseDate.CompareTo(y.ReleaseDate);
        }
    }
}
