using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Resorts
{
    [Serializable]
    public class ListOfResorts
    {
        public List<Ski_Resort> Res { get; set; }
        public ListOfResorts(List<Ski_Resort> res)
        {
            Res = res;
        }
        public ListOfResorts()
        {

        }
    }
}
