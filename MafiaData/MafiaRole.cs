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
        public bool IsSelected { get; set; }
        public int Count { get; set; }
        public string PlayerName { get; set; }

        public MafiaRole(int id, string name, string url)
        {
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.IsSelected = true;
            this.Count = 0;
            this.PlayerName = "";
        }
    }

}
