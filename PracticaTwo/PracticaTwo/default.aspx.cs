using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaTwo
{
    public partial class _default : System.Web.UI.Page
    {
        public static List<Book> books;
        ConexionDAO conexionDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            books = new List<Book>();
            conexionDAO = new ConexionDAO();
            books = conexionDAO.Select();
            //books.Add(new Book(11,"12341556","koipo",3,1234,"jijo","jojpoj","njiojiojomnhuh","jiojiohu","skjidllos"));
            DrawTable(books);
            
            //tblBooks.Rows.Add(tableRow);
        }

        private void DrawTable(List<Book> books)
        {
            TableHeaderRow tableRow = new TableHeaderRow();
            TableHeaderCell cell = new TableHeaderCell();
            TableHeaderCell cell1 = new TableHeaderCell();
            TableHeaderCell cell2 = new TableHeaderCell();
            TableHeaderCell cell3 = new TableHeaderCell();
            TableHeaderCell cell4 = new TableHeaderCell();
            TableHeaderCell cell5 = new TableHeaderCell();
            TableHeaderCell cell6 = new TableHeaderCell();
            TableHeaderCell cell7 = new TableHeaderCell();
            TableHeaderCell cell8 = new TableHeaderCell();
            TableHeaderCell cell9 = new TableHeaderCell();

            //TableRowCollection collection;
            cell.Text = "ID";
            tableRow.Cells.Add(cell);
            cell1.Text = "ISBN";
            tableRow.Cells.Add(cell1);
            cell2.Text = "Titulo";
            tableRow.Cells.Add(cell2);
            cell3.Text = "Número de edición";
            tableRow.Cells.Add(cell3);
            cell4.Text = "Año de publicación";
            tableRow.Cells.Add(cell4);
            cell5.Text = "Nombre de los autores";
            tableRow.Cells.Add(cell5);
            cell6.Text = "País de publicación";
            tableRow.Cells.Add(cell6);
            cell7.Text = "Sinopsis";
            tableRow.Cells.Add(cell7);
            cell8.Text = "Carrera";
            tableRow.Cells.Add(cell8);
            cell9.Text = "Materia";
            tableRow.Cells.Add(cell9);
            //tableRow.BorderWidth = 1;
            tblBooks.Rows.Add(tableRow);
            //tblBooks.BorderWidth = 1;
            //tblBooks.CellPadding = 5;

            TableCell cellI= new TableCell();
            TableCell cellI1 = new TableCell();
            TableCell cellI2 = new TableCell();
            TableCell cellI3 = new TableCell();
            TableCell cellI4 = new TableCell();
            TableCell cellI5 = new TableCell();
            TableCell cellI6 = new TableCell();
            TableCell cellI7 = new TableCell();
            TableCell cellI8 = new TableCell();
            TableCell cellI9 = new TableCell();
            TableRow tableRow1 = new TableRow();
            foreach (Book item in books)
            {
                cellI = new TableCell();
                cellI1 = new TableCell();
                cellI2 = new TableCell();
                cellI3 = new TableCell();
                cellI4 = new TableCell();
                cellI5 = new TableCell();
                cellI6 = new TableCell();
                cellI7 = new TableCell();
                cellI8 = new TableCell();
                cellI9 = new TableCell();
                tableRow1 = new TableRow();
                cellI.Text = item.id.ToString();
                tableRow1.Cells.Add(cellI);
                cellI1.Text = item.ISBN;
                tableRow1.Cells.Add(cellI1);
                cellI2.Text = item.title;
                tableRow1.Cells.Add(cellI2);
                cellI3.Text = item.editionNumber.ToString();
                tableRow1.Cells.Add(cellI3);
                cellI4.Text = item.yearOfPublication.ToString();
                tableRow1.Cells.Add(cellI4);
                cellI5.Text = item.authors;
                tableRow1.Cells.Add(cellI5);
                cellI6.Text = item.countryOfPublication;
                tableRow1.Cells.Add(cellI6);
                cellI7.Text = item.synopsis;
                tableRow1.Cells.Add(cellI7);
                cellI8.Text = item.career;
                tableRow1.Cells.Add(cellI8);
                cellI9.Text = item.subject;
                tableRow1.Cells.Add(cellI9);
                tblBooks.Rows.Add(tableRow1);
            }
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("New.aspx");
        }
    }
}