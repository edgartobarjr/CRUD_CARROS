using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  //Referencia en Sistem.Configuration
using CapaEntidad;      //Se agregan las referencias de la clase Entidad

namespace CapaDatos
{
    public class ClassDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString); //Variable para mantener la conexion con sql server

        public DataTable D_listar_carros() //Tabla para los procedimientos almacenados de sql server
        {
            SqlCommand cmd = new SqlCommand("sp_listar_carros", cn); //Sql Command permite obtener el procedimiento, se necesita el nombre y la variable de la conexion / Se almacena en cmd
            SqlDataAdapter da = new SqlDataAdapter(cmd); //sqlDataAdapter funciona de puente entre la base de datos y la tabla
            DataTable dt = new DataTable(); //DataTable llamado dt
            da.Fill(dt); //Para devolver los nombres y tipos de columna que se usan para crear las tablas
            return dt; 
        }

        public DataTable D_buscar_carros(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_carros", cn);
            cmd.CommandType = CommandType.StoredProcedure; //CommandType ya que se usaran parametros o variables del sql server
            cmd.Parameters.AddWithValue("@Marca", obje.Marca); //Se buscara por la marca del carro 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_carros(ClassEntidad obje) 
        {
            String Accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_carros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo", obje.Codigo); //Se agregan todos los Parametros del formulario
            cmd.Parameters.AddWithValue("@Marca", obje.Marca);
            cmd.Parameters.AddWithValue("@Modelo", obje.Modelo);
            cmd.Parameters.AddWithValue("@Año", obje.Año);
            cmd.Parameters.AddWithValue("@Tipo", obje.Tipo);
            cmd.Parameters.AddWithValue("@Precio", obje.Precio);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = obje.Accion; //Parametro Accion va a recibir la opcion (1-3) y el mensaje que se coloco en el sql server
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery(); //realizar operaciones de catálogo (por ejemplo, consultar la estructura de una base de datos o crear objetos de base de datos
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            cn.Close();
            return Accion;
        }
    }
}
