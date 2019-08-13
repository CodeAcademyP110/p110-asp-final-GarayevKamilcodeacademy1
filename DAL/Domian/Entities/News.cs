using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Entities
{
    public class News
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhotoDirectory { get; set; }
        public string Title { get; set; }
        public string TextDirectory { get; set; }

    }
}
