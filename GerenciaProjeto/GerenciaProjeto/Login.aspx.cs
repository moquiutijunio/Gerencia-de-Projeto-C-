using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerenciaProjeto
{
    public partial class Login : System.Web.UI.Page
    {
        DatabaseEntities de = new DatabaseEntities();
        static Boolean erro;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            if (!erro || erro==null) {
                msgErro.Visible = false;
            }
        }

        protected void acessar_login(object sender, EventArgs e)
        {
            string usu = usuario.Text;
            string sen = senha.Text;

            Usuario user = de.Usuarios.Where(x => x.login == usu && x.senha == sen).FirstOrDefault();

            if (user != null)
            {
                erro = false;
                Session["usuario"] = user;
                Response.Redirect("Principal.aspx");
            }
            else
            {
                erro = true;
                msgErro.Visible = true;
            }
        }
    }
}