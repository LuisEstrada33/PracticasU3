using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Tareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Estatus { get; set; }
    }
}
