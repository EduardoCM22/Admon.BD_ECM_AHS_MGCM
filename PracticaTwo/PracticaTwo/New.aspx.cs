using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaTwo
{
    public partial class New : System.Web.UI.Page
    {

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(!txtId.Text.Equals("") && !txtISBN.Text.Equals("") && !txtTitle.Text.Equals("") && 
                !txtEdition.Text.Equals("") && !txtPublicationYear.Text.Equals("") && 
                !txtAuthor.Text.Equals("") && !txtPublicationCountry.Text.Equals("") && 
                !txtSynopsis.Text.Equals("") && !txtCareer.Text.Equals("") && !txtSubject.Text.Equals("")){

                if (txtISBN.Text.Length==10 || txtISBN.Text.Length == 13)
                {
                    Book book = new Book(Convert.ToInt32(txtId.Text), txtISBN.Text, txtTitle.Text,
                    Convert.ToInt32(txtEdition.Text), Convert.ToInt32(txtPublicationYear.Text), txtAuthor.Text,
                    txtPublicationCountry.Text, txtSynopsis.Text, txtCareer.Text, txtSubject.Text);
                    ConexionDAO conexion = new ConexionDAO();
                    conexion.Insert(book);
                    txtId.Text = "";
                    txtISBN.Text = "";
                    txtTitle.Text = "";
                    txtEdition.Text = "";
                    txtPublicationYear.Text = "";
                    txtAuthor.Text = "";
                    txtPublicationCountry.Text = "";
                    txtSynopsis.Text = "";
                    txtCareer.Text = "";
                    txtSubject.Text = "";

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Libro agregado');", true);
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Llene los datos correctamente');", true);
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}