using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FireLearn.Models
{
    public class Kelime
    {

        public int kelime_id { get; set; }
        public string KelimeTR { get; set; }
        public string KelimeING { get; set; }
        public string Kelime_Turu { get; set; }
        public string Kelime_video { get; set; }
        public int KelimeDerece { get; set; }
    }
    
    
}