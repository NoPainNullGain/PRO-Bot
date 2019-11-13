using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROFridge.ViewModel.HelperClasses
{
    public class Coordinates
    {
        public int Id { get; set; }
        public float CoordX { get; set; }
        public float CoordY { get; set; }
        public float CoordXLast { get; set; }
        public float CoordYLast { get; set; }


    }
}
