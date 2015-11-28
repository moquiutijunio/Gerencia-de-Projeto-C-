using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class ConMatricula : System.Web.UI.Page
    {
        DatabaseEntities de = new DatabaseEntities();
        static int idDisciplina, idAluno;
        List<String> filtros = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CarregarDisciplinas();
                CarregarAlunos();
            }

            CarregarGrid();

            if (Session["idAluno"] != null)
            {
                int id = (int)Session["idAluno"];
                //Selecionar aluno da sessão no dropdonwnlist
                dropdownAluno.SelectedValue = id.ToString();
                var dados = de.Aluno_Disciplina.Select(x => new
                {
                    Id = x.id,
                    Aluno = x.Aluno.nome,
                    Disciplina = x.Disciplina.nome,
                    Média = x.nota
                }).Where(y => y.Id == id).OrderBy(y => y.Aluno);

                GridViewMatricula.DataSource = dados;

                GridViewMatricula.DataBind();
                Session["idAluno"] = null;
            }
        }

        public void CarregarDisciplinas()
        {

            var dados = de.Disciplinas.Select(x => new { x.id, x.nome }).ToList();
            if (dados.Count > 0)
            {
                dropdownDisciplina.DataSource = dados;
                dropdownDisciplina.DataValueField = "id";
                dropdownDisciplina.DataTextField = "nome";
                dropdownDisciplina.DataBind();
                dropdownDisciplina.Items.Add(new ListItem("Selecione uma Disciplina", "0"));
                dropdownDisciplina.SelectedValue = "0";
            }
        }

        public void CarregarAlunos()
        {

            var dados = de.Alunoes.Select(x => new { x.id, x.nome }).ToList();
            if (dados.Count > 0)
            {
                dropdownAluno.DataSource = dados;
                dropdownAluno.DataValueField = "id";
                dropdownAluno.DataTextField = "nome";
                dropdownAluno.DataBind();
                dropdownAluno.Items.Add(new ListItem("Selecione um Aluno", "0"));
                dropdownAluno.SelectedValue = "0";
            }
        }

        private void CarregarGrid()
        {

            var dados = de.Aluno_Disciplina.Select(x => new
            {
                Id = x.id,
                Aluno = x.Aluno.nome,
                Disciplina = x.Disciplina.nome,
                Média = x.nota
            }).OrderBy(y => y.Aluno);

            GridViewMatricula.DataSource = dados;

            GridViewMatricula.DataBind();

        }

        protected void GridViewMatricula_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewMatricula.Rows[linha].Cells[3].Text);

                Aluno_Disciplina ad = de.Aluno_Disciplina.Where(x => x.id == id).FirstOrDefault();

                de.DeleteObject(ad);
                de.SaveChanges();
                Response.Redirect("ConMatricula.aspx");
            }
            if (e.CommandName.Equals("Editar"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewMatricula.Rows[linha].Cells[3].Text);

                Session["idAlunoDisciplina"] = id;
                Response.Redirect("CadMatricula.aspx");
            }
            if (e.CommandName.Equals("Notas"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewMatricula.Rows[linha].Cells[3].Text);

                var dados = de.Aluno_Disciplina.Select(x => new
                {
                    ID = x.id,
                    P1 = x.prova1,
                    P2 = x.prova2,
                    Trabalho = x.trabalho
                }).Where(y => y.ID == id);

                GridViewNotas.DataSource = dados;

                GridViewNotas.DataBind();
            }
        }

        protected void dropdownDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDisciplina = int.Parse(dropdownDisciplina.SelectedItem.Value);
        }

        protected void dropdownAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAluno = int.Parse(dropdownAluno.SelectedItem.Value);
        }

        protected void filtrar_Click(object sender, EventArgs e)
        {
            if (idAluno > 0 && idDisciplina > 0)
            {
                Aluno aluno = de.Alunoes.Where(x => x.id == idAluno).FirstOrDefault();
                Disciplina disciplina = de.Disciplinas.Where(x => x.id == idDisciplina).FirstOrDefault();

                if (maioresNotas.Checked)
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Aluno == aluno.nome && y.Disciplina == disciplina.nome).OrderByDescending(y => y.Média);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
                else
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Aluno == aluno.nome && y.Disciplina == disciplina.nome).OrderBy(y => y.Aluno);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
            }
            else if (idAluno > 0 && idDisciplina <=0)
            {
                Aluno aluno = de.Alunoes.Where(x => x.id == idAluno).FirstOrDefault();

                if (maioresNotas.Checked)
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Aluno == aluno.nome).OrderByDescending(y => y.Média);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
                else
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Aluno == aluno.nome).OrderBy(y => y.Aluno);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
            }
            else if (idDisciplina > 0 && idAluno <= 0)
            {
                Disciplina disciplina = de.Disciplinas.Where(x => x.id == idDisciplina).FirstOrDefault();

                if (maioresNotas.Checked)
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Disciplina == disciplina.nome).OrderByDescending(y => y.Média);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
                else
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).Where(y => y.Disciplina == disciplina.nome).OrderBy(y => y.Aluno);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
            }
            else
            {
                if (maioresNotas.Checked)
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).OrderByDescending(y => y.Média);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
                else
                {
                    var dados = de.Aluno_Disciplina.Select(x => new
                    {
                        Id = x.id,
                        Aluno = x.Aluno.nome,
                        Disciplina = x.Disciplina.nome,
                        Média = x.nota
                    }).OrderBy(y => y.Aluno);

                    GridViewMatricula.DataSource = dados;

                    GridViewMatricula.DataBind();
                }
            }
        }
    }
}