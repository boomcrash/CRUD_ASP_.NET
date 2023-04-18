//crear namespace ContactoDatos

using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace CRUDCORE.Datos
{
    public class ContactoDatos{

        public List<ContactoModel> Listar(){
            List<ContactoModel> lista = new List<ContactoModel>();
            Conexion conexion = new Conexion();
            string query = "sp_Listar";
            using(SqlConnection con = new SqlConnection(conexion.getCadenaSQL())){
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()){
                    ContactoModel contacto = new ContactoModel();
                    contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                    contacto.Nombre = dr["Nombre"].ToString();
                    contacto.Telefono = dr["Telefono"].ToString();
                    contacto.Correo = dr["Correo"].ToString();
                    lista.Add(contacto);
                }
                con.Close();
            }
            return lista;
        }

        public ContactoModel Obtener(int IdContacto){
            ContactoModel contacto = new ContactoModel();
            Conexion conexion = new Conexion();
            string query = "sp_Obtener";
            using(SqlConnection con = new SqlConnection(conexion.getCadenaSQL())){
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()){
                    contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                    contacto.Nombre = dr["Nombre"].ToString();
                    contacto.Telefono = dr["Telefono"].ToString();
                    contacto.Correo = dr["Correo"].ToString();
                }
                con.Close();
            }
            return contacto;
        }

        public bool Guardar(ContactoModel contacto){
            try
            {
                Conexion conexion = new Conexion();
                string query = "sp_Guardar";
                using(SqlConnection con = new SqlConnection(conexion.getCadenaSQL())){
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", contacto.Correo);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }catch(Exception ex){
                return false;
            }
        }

        public bool Editar(ContactoModel contacto){
            try
            {
                Conexion conexion = new Conexion();
                string query = "sp_Editar";
                using(SqlConnection con = new SqlConnection(conexion.getCadenaSQL())){
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdContacto", contacto.IdContacto);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", contacto.Correo);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }catch(Exception ex){
                return false;
            }
        }

        //erliminar 
        public bool Eliminar(int IdContacto){
            try
            {
                Conexion conexion = new Conexion();
                string query = "sp_Eliminar";
                using(SqlConnection con = new SqlConnection(conexion.getCadenaSQL())){
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }catch(Exception ex){
                return false;
            }
        }
    }

   
}