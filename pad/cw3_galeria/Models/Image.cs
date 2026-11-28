using System;
using System.Collections.Generic;
using System.Text;

namespace cw3_galeria.Models
{
    public class Image
    {
        public int id { get; set; }
        public string filename { get; set; }
        public string  alt { get; set; }
        public int category { get; set; }
        public int downloads { get; set; }
    }
}
