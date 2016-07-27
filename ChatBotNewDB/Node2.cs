namespace ChatBotNewDB
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class Node2
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
