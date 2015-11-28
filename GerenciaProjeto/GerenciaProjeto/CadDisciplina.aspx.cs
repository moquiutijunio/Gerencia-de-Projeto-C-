using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class CadDisciplina : System.Web.UI.Page
    {
        DatabaseEntities de = new DatabaseEntities();
        int id = 0;
        Disciplina disciplina = new Disciplina();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["idDisciplina"] != null)
            {
                id = (int)Session["idDisciplina"];
                disciplina = de.Disciplinas.Where(x => x.id == id).FirstOrDefault();
                nome.Text = disciplina.nome;
                descricao.Text = disciplina.descricao;
            }
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            disciplina = de.Disciplinas.Where(x => x.id == disciplina.id).FirstOrDefault();

            if (disciplina == null)
            {
                disciplina = new Disciplina();

                disciplina.nome = nome.Text;
                disciplina.descricao = descricao.Text;
                de.AddToDisciplinas(disciplina);
                de.SaveChanges();

                Response.Write("<script>alert('Salvo com Sucesso');</script>");
                Limpar(this);
            }
            else
            {
                disciplina = de.Disciplinas.Where(x => x.id == id).FirstOrDefault();

                disciplina.nome = nome.Text;
                disciplina.descricao = descricao.Text;

                de.ApplyPropertyChanges("Disciplinas", disciplina);

                de.SaveChanges();

                Response.Write("<script>alert('Alterado com Sucesso');</script>");
                Limpar(this);
            }


        }

        protected void LimparCtrl(object sender, EventArgs e)
        {
            Limpar(this);
        }

        protected void Limpar(Control control)
        {
            Session["idDisciplina"] = null;

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
    }
}