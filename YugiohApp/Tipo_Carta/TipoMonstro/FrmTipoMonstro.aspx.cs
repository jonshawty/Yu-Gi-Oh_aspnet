using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace YugiohApp.Tipo_Carta.TipoMonstro
{
    public partial class FrmTipoMonstro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Monstro> lista = TipoMonstroDAO.ObterMonstros();
                PopularLvMonstro(lista);
                lblMensagem.InnerText = "";
            }
            lblMensagem.InnerText = "";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Monstro monstro = null;

                if (!alterando)
                {
                    monstro = new Monstro();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    monstro = TipoMonstroDAO.ObterMonstro(codigo);
                }

                monstro.NomeMonstro = txtMonstro.Text;
                var mensagem = "";

                if (!alterando)
                {
                    TipoMonstroDAO.CadastrarMonstro(monstro);
                    mensagem = "Monstro de monstro cadastrado com sucesso!";
                }
                else
                {
                    TipoMonstroDAO.AlterarMonstro(monstro);
                    Response.Redirect("Monstro");
                }

                PopularLvMonstro(TipoMonstroDAO.ObterMonstros());

                lblMensagem.InnerText = mensagem;
                txtMonstro.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvMonstro(List<Monstro> lista)
        {
            lvMonstro.DataSource = lista;
            lvMonstro.DataBind();
        }

        private void PreencherDados(int id)
        {
            Monstro monstro = TipoMonstroDAO.ObterMonstro(id);
            if (monstro != null) 
            {
                txtMonstro.Text = monstro.NomeMonstro;
            }
        }


        private void ChecarQueryString()
        {
            var idQuery = Request.QueryString["id"];

            if (idQuery != null)
            {
                var id = Convert.ToInt32(idQuery);
                var view = Request.QueryString["view"];

                if (view != null)
                {
                    VisualizarMonstros(id);
                }
                else 
                {
                    AlterarMonstro(id);
                }
            }
        }

        private void AlterarMonstro(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarMonstros(int id)
        {
            PreencherDados(id);
            txtMonstro.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    TipoMonstroDAO.RemoverMonstro(id);
                }

                PopularLvMonstro(TipoMonstroDAO.ObterMonstros());
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

        protected void btn_VerificaTipo_Command(object sender, CommandEventArgs e)
        {
            var NomeTipoCarta = Convert.ToString(e.CommandArgument);

            if (NomeTipoCarta == "Efeito")
            {
                Response.Redirect("Monstro_Efeito/FrmMonstroEfeito.aspx");
            }
            else
            {
                lblMensagem.InnerText = "Não é possivel cadastrar subtipo";
            }
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Monstro");
        }
    }
}