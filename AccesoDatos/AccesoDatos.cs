using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProblemaVeterinaria_1._5
{
    internal class AccesoDatos
    {
        SqlConnection cnn;
        SqlCommand cmd;
        static string cadenaConexion = @"Data Source=DESKTOP-33JGS32;Initial Catalog=Veteriniaria_Prog2;Integrated Security=True";
    
        public AccesoDatos()
        {
            cnn = new SqlConnection(cadenaConexion);
            cmd = new SqlCommand();
        }
        //public void Conectar()
        //{
        //    cnn.Open();
        //    cmd.Connection = cnn;
        //    cmd.CommandType = CommandType.Text;
        //}
        public void ConectarConSP()
        {
            cnn.Open();
        }   

        public void Desconectar()
        {
            cnn.Close();
        }
        //public DataTable ConsultarBD(string CionsultaSQL)
        //{
        //    //DataTable tabla = new DataTable();
        //    //Conectar();
        //    //cmd.CommandText = consultaSQL;
        //    //tabla.Load(cmd.ExecuteReader());
        //    //Desconectar();
        //    //return tabla;
        //}
        
        public DataTable ConsultarBD(string SP)
        {
            //con store procedure
            DataTable tabla = new DataTable();
            ConectarConSP();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            Desconectar();
            return tabla;
        }
        //public int InsertarBD(string consultaSQL)
        //{
        //    int filasAfectadas;
        //    Conectar();
        //    cmd.CommandText = consultaSQL;
        //    filasAfectadas = cmd.ExecuteNonQuery();
        //    Desconectar();
        //    return filasAfectadas;
        //}
        
        public int insertarBDSP(string SP)
        {   
            //con store procedure
            int filasAfectadas;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", /*AGREGAR VALOR DE PARAMETRO*/ "" );
            cmd.Parameters.AddWithValue("@sexo", /*AGREGAR VALOR DE PARAMETRO*/ 0);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }

        
    }
}
