using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class CadMatricula : System.Web.UI.Page 
    {
        DatabaseEntities de = new DatabaseEntities();
        static int idDisciplina, idAluno;
        int id = 0;
        Aluno_Disciplina alunoDisciplina = new Aluno_Disciplina();

       

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

            if (Session["idAlunoDisciplina"] != null)
            {
                id = (int)Session["idAlunoDisciplina"];

                var result = de.Aluno_Disciplina.Select(x => new { x.id, x.nota, x.prova1, x.prova2, x.trabalho, x.Aluno, x.Disciplina }).Where(y => y.id == id).FirstOrDefault();
              
                alunoDisciplina.Aluno = result.Aluno;
                alunoDisciplina.Disciplina = result.Disciplina;
                alunoDisciplina.id = result.id;
                alunoDisciplina.nota = result.nota;
                alunoDisciplina.prova1 = result.prova1;
                alunoDisciplina.prova2 = result.prova2;
                alunoDisciplina.trabalho = result.trabalho;
               

                idAluno = alunoDisciplina.Aluno.id;
                idDisciplina = alunoDisciplina.Disciplina.id;
                dropdownAluno.SelectedValue = idAluno.ToString();
                dropdownDisciplina.SelectedValue = idDisciplina.ToString();
                prova1.Text = alunoDisciplina.prova1.ToString();
                prova2.Text = alunoDisciplina.prova2.ToString();
                trabalho.Text = alunoDisciplina.trabalho.ToString();
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

        protected void dropdownDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDisciplina = int.Parse(dropdownDisciplina.SelectedItem.Value);
        }

        protected void dropdownAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAluno = int.Parse(dropdownAluno.SelectedItem.Value);
        }

        protected void LimparCtrl(object sender, EventArgs e)
        {
            Limpar(this);
        }

        protected void Limpar(Control control)
        {
            dropdownAluno.SelectedValue = "0";
            dropdownDisciplina.SelectedValue = "0";
            foreach (Control ctrl in control.Controls)
            {
                //Limpa todos os campos TextBox
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }

                if (ctrl.HasControls())
                    Limpar(ctrl);
            }
        }

        protected void cadastrar_Click(object sender, EventArgs e)
        {
            alunoDisciplina = de.Aluno_Disciplina.Where(x => x.id == alunoDisciplina.id).FirstOrDefault();

            if (alunoDisciplina == null)
            {
                alunoDisciplina = new Aluno_Disciplina();

                alunoDisciplina.Aluno = de.Alunoes.Where(x => x.id == idAluno).FirstOrDefault();
                alunoDisciplina.Disciplina = de.Disciplinas.Where(x => x.id == idDisciplina).FirstOrDefault();
                alunoDisciplina.prova1 = Double.Parse(prova1.Text);
                alunoDisciplina.prova2 = Double.Parse(prova2.Text);
                alunoDisciplina.trabalho = Double.Parse(trabalho.Text);
                alunoDisciplina.nota = (Double.Parse(prova1.Text) + Double.Parse(prova2.Text) + Double.Parse(trabalho.Text)) / 3;

                de.AddToAluno_Disciplina(alunoDisciplina);
                de.SaveChanges();

                Response.Write("<script>alert('Salvo com Sucesso');</script>");
                Limpar(this);
            }
            else
            {
               
                alunoDisciplina = de.Aluno_Disciplina.Where(x => x.id == id).FirstOrDefault();

                alunoDisciplina.Aluno = de.Alunoes.Where(x => x.id == idAluno).FirstOrDefault();
                alunoDisciplina.Disciplina = de.Disciplinas.Where(x => x.id == idDisciplina).FirstOrDefault();
                alunoDisciplina.prova1 = Double.Parse(prova1.Text);
                alunoDisciplina.prova2 = Double.Parse(prova2.Text);
                alunoDisciplina.trabalho = Double.Parse(trabalho.Text);
                alunoDisciplina.nota = (Double.Parse(prova1.Text) + Double.Parse(prova2.Text) + Double.Parse(trabalho.Text)) / 3;
                
                de.ApplyPropertyChanges("Aluno_Disciplina", alunoDisciplina);
                
                de.SaveChanges();

                Response.Write("<script>alert('Alterado com Sucesso');</script>");
                Limpar(this);
            }
        }
    }
}