using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice01.Models
{
    public class Data
    {
        public string Site { get; set; }
        public string County { get; set; }
        public double? PM25 { get; set; }
        public string DataCreationDate { get; set; }
        public string ItemUnit { get; set; }
    }
}
