using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class ConDisciplina : System.Web.UI.Page
    {
        DatabaseEntities de = new DatabaseEntities();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            CarregarGrid();
        }

        private void CarregarGrid()
        {

            var dados = de.Disciplinas.Select(x => new
            {
                Id = x.id,
                Nome = x.nome,
                Descrição = x.descricao
            }).OrderBy(y => y.Id);

            GridViewDisciplina.DataSource = dados;

            GridViewDisciplina.DataBind();

        }

        protected void GridViewDisciplina_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewDisciplina.Rows[linha].Cells[1].Text);

                Disciplina d = de.Disciplinas.Where(x => x.id == id).FirstOrDefault();

                de.DeleteObject(d);
                de.SaveChanges();
                Response.Redirect("ConDisciplina.aspx");
            }
            if (e.CommandName.Equals("Editar"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewDisciplina.Rows[linha].Cells[2].Text);

                Session["idDisciplina"] = id;
                Response.Redirect("CadDisciplina.aspx");
            }
        }
        
    }
}