using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class WebForm1 : System.Web.UI.Page
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

            var dados = de.Alunoes.Select(x => new
            {
                Id = x.id,
                Nome = x.nome,
                Cidade = x.cidade,
                Estado = x.estado,
                Sexo = x.sexo
            }).OrderBy(y => y.Id);

            GridViewAluno.DataSource = dados;

            GridViewAluno.DataBind();

        }

        protected void GridViewAluno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewAluno.Rows[linha].Cells[3].Text);

                Aluno a = de.Alunoes.Where(x => x.id == id).FirstOrDefault();

                de.DeleteObject(a);
                de.SaveChanges();
                Response.Redirect("ConAluno.aspx");
            }
            if (e.CommandName.Equals("Editar"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewAluno.Rows[linha].Cells[3].Text);

                Session["idAluno"] = id;
                Response.Redirect("CadAluno.aspx");
            }
            if (e.CommandName.Equals("Matriculas"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewAluno.Rows[linha].Cells[3].Text);

                Session["idAluno"] = id;
                Response.Redirect("ConMatricula.aspx");
            }
        }
    }
}