using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario");
        }

        [Obsolete]
        protected void btn_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                var login = txtLogin.Text;
                var senha = txtSenha.Text;

                Usuario user = null;
                user = UsuarioDAO.ObterUsuario(login);

                if (user != null)
                {
                    var senhaCriptografada = FormsAuthentication.
                        HashPasswordForStoringInConfigFile(senha, "SHA1");

                    if (user.Senha == senhaCriptografada)
                    {
                        //Usuário válido
                        FormsAuthentication.SetAuthCookie(login, true);

                        LogAcesso log = new LogAcesso();
                        log.UsuarioId = user.IdUsuario;
                        log.DataHoraAcesso = DateTime.Now;

                        LogAcessoDAO.CadastrarLogAcesso(log);

                        Session["User"] = user;
                        Session["Log"] = log;

                        Response.Redirect("Carta");

                    }
                }

                lblMensagem.InnerText = "Login ou senha invalidos";
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }


        }

        private void MensagemDeErro(Exception ex)
        {
            lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação: " + ex.Message;
        }

        protected void btnlinkCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario");
        }
    }
}