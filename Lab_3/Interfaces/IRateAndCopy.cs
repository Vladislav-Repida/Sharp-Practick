using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
