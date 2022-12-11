using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var login = txtLogin.Text;
                var pass = txtSenha.Text;

                if (login != "" && pass != "")
                {
                    Usuario usuario = new Usuario();
                    usuario.Login = login;

                   
                    var senhaCriptografada =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "SHA1");

                    usuario.Senha = senhaCriptografada;

                    var user = (Usuario)Session["user"];

                    UsuarioDAO.CadastrarUsuario(usuario);

                    LimparDados();
                    MostrarMensagem("Usuário cadastrado com sucesso!");

                }
                else
                {
                    MostrarMensagem("Login e senha são obrigatórios!");
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem(ex.Message);
            }
        }

        private void LimparDados()
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
        }

        private void MostrarMensagem(string message)
        {
            lblMensagem.InnerText = message;
        }
    }
}