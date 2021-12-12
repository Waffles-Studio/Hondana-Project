using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hondana_Project_Beta
{
    class Globales
    {
        //public static string conexion { get; set; }

        public static SqlConnection conexion { get; set; }

        public static string UserID { get; set; }
        public static string UserRole { get; set; }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserIcon { get; set; }
        public static int MensajeBienvendia { get; set; }
        public static int GrupoSel { get; set; }


    }
}
