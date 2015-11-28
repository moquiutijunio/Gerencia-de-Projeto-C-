using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class CadAluno : System.Web.UI.Page
    {
        DatabaseEntities de = new DatabaseEntities();
        int id = 0;
        Aluno aluno = new Aluno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["idAluno"]!=null)
            {
                id = (int)Session["idAluno"];
                aluno = de.Alunoes.Where(x => x.id == id).FirstOrDefault();
                nome.Text = aluno.nome;
                cidade.Text = aluno.cidade;
                estado.SelectedValue = aluno.estado;
                listSexo.SelectedValue = aluno.sexo;
            }
        }

        protected void Cadastrar(object sender, EventArgs e)
        {

            aluno = de.Alunoes.Where(x => x.id == aluno.id).FirstOrDefault() ;

            if (aluno == null)
            {
                aluno = new Aluno();

                aluno.nome = nome.Text;
                aluno.cidade = cidade.Text;
                aluno.estado = estado.Text;
                aluno.sexo = listSexo.SelectedValue;

                //salvando aluno
                de.AddToAlunoes(aluno);
                de.SaveChanges();

                Response.Write("<script>alert('Salvo com Sucesso');</script>");
                LimparCampos();
            }
            else
            {
                aluno = de.Alunoes.Where(x => x.id == id).FirstOrDefault();

                aluno.nome = nome.Text;
                aluno.cidade = cidade.Text;
                aluno.estado = estado.Text;
                aluno.sexo = listSexo.SelectedValue;

                de.ApplyPropertyChanges("Alunoes", aluno);

                de.SaveChanges();

                Response.Write("<script>alert('Alterado com Sucesso');</script>");
                LimparCampos();
            }
        }

        protected void Limpar(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            nome.Text = null;
            cidade.Text = null;
            estado.SelectedValue = "0";
            listSexo.SelectedValue = null;
            Session["idAluno"] = null;
        }
    }
}
