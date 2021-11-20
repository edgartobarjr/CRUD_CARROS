using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos; //Hacer Referencia a la capa datos y capa entidad
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos(); //Variable que representa la clase datos

        public DataTable N_listar_carros() //Llamar a la tabla de listar carros
        {
            return objd.D_listar_carros();
        }

        public DataTable N_buscar_carros (ClassEntidad obje) //Llamar a la tabla de buscar carros / Su parametro es la clase entidad
        {
            return objd.D_buscar_carros(obje);
        }

        public String N_mantenimiento_carros (ClassEntidad obje) //Llamar a la tabla de mantenimiento carros / Igual con su parametro
        {
            return objd.D_mantenimiento_carros(obje);
        }
    }
}
