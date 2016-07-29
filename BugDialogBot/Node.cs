﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BugDialogBot
{
    [Serializable]
    public class Node
    {
        public int id { get; set; }
        public String question { get; set; }
        public Dictionary<int,string> answers { get; set; }
    }
}
