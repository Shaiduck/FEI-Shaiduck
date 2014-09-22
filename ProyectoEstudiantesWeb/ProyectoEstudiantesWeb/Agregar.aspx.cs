using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoEstudiantesWeb
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            ProyEstudiantesWeb.Util.MSSQLConexion con = new ProyEstudiantesWeb.Util.MSSQLConexion();
            string insert_sql = "INSERT INTO [dbo].[Tbl_Estudiantes]  ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('" + Nombre.Text + " ', '" + ApPaterno.Text + "',  '" + ApMaterno.Text + "', '" + Promedio.Text + "', '" + Matricula.Text + "')";
            con.NonQuery(insert_sql);
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
            ProyEstudiantesWeb.Util.MSSQLConexion con = new ProyEstudiantesWeb.Util.MSSQLConexion();
            string query = "select * from Tbl_Estudiantes where Matricula = '"+ Matricula.Text + "';";
            DataSet dr = con.Query(query, "Tbl_Estudiantes");
            Estudiante usuario = null;
            usuario = dr.Tables[0].Rows.Cast<DataRow>().
                Select(
                    x =>
                        new Estudiante
                        {
                            Id = x[0].ToString(),
                            Nombre = x[1].ToString(),
                            ApellidoPaterno = x[2].ToString(),
                            ApellidoMaterno = x[3].ToString(),
                            PromedioGeneral = x[5].ToString(),
                            Matricula = x[4].ToString()
                        }
                        ).ToList<Estudiante>()[0];
            id.Text = usuario.Id;
            Nombre.Text = usuario.Nombre;
            ApPaterno.Text = usuario.ApellidoPaterno;
            ApMaterno.Text = usuario.ApellidoMaterno;
            Matricula.Text = usuario.Matricula;
            Promedio.Text = usuario.PromedioGeneral;
            
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                ProyEstudiantesWeb.Util.MSSQLConexion con = new ProyEstudiantesWeb.Util.MSSQLConexion();
                string insert_sql = "DELETE  FROM [dbo].[Tbl_Estudiantes] WHERE Matricula = '" + Matricula.Text + "'";
                con.NonQuery(insert_sql);
                result = true;
            }
            catch
            {

            }
            if (result)
            {
                MessageBox.Show("Estudiante eliminado");
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar");
            }
        }
    }
}