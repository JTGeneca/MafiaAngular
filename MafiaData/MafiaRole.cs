using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaData
{
    public class MafiaRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public MafiaRole(int id, string name, string url)
        {
            this.Id = id;
            this.Name = name;
            this.Url = url;
        }
    }

}
