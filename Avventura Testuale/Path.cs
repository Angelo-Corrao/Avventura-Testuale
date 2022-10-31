using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avventura_Testuale
{
    public class Path
    {
        public List<string> narrative = new List<string>();

        public Path(List<string> narrative)
        {
            this.narrative = narrative;
        }
    }
}
