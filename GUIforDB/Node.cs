using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot
{
    [Serializable]
    public class Node
    {
        public int id { get; set; }
        public String question { get; set; }
        public List<int> parents { get; set; }
        public List<int> children { get; set; }
        public string answer { get; set; }
        public string intent { get; set; }
    }
}
