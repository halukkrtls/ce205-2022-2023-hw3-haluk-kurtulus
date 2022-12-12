using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw3_gui
{
    public class Node
    {

        public string key;
        public int height;
        public Node left, right;
        public string idLingkaran;
        public string idGaris;

        public Node(string key, string idLingkaran)
        {
            this.key = key;
            this.idLingkaran = idLingkaran;
            height = 1;

        }
    }
}

