using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROFridge.ViewModel.HelperClasses;

namespace PROFridge
{
    public class Singleton
    {
        private static Singleton _instance = null;

        public List<Coordinates> xy_List = new List<Coordinates>();
        //public Form1 form1 = new Form1(); 
        public bool IsSaved = false;
        
        private Singleton()
        {

        }
        
        public List<Coordinates> XYList
        {
            get { return xy_List; }
            set { xy_List = value; }
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;

            }
            set { _instance = value; }
        }
    }
}
