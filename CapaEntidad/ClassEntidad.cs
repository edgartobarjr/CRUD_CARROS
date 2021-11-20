using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntidad
    {
        //Variables entre SQL y el Formulario
            public String Marca { get; set; } //Se van a enviar y recibir datos (Setters y Getters)
            public String Codigo { get; set; }
            public String Modelo { get; set; }
            public String Año { get; set; }
            public String Tipo { get; set; }
            public Decimal Precio { get; set; }
            public String Accion { get; set; }

    }
}
