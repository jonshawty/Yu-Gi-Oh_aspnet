using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito
{
    public partial class FrmMonstroEfeito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<MonstroEfeito> lista = MonstroEfeitoDAO.ObterMonstrosEfeito();
                PopularLvMonstroEfeito(lista);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                MonstroEfeito monstroEfeito = null;

                if (!alterando)
                {
                    monstroEfeito = new MonstroEfeito();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    monstroEfeito = MonstroEfeitoDAO.ObterMonstroEfeito(codigo);
                }

                monstroEfeito.NomeMonstroEfeito = txtMonstroEfeito.Text;

                var mensagem = "";

                if (!alterando)
                {
                    MonstroEfeitoDAO.CadastrarMonstroEfeito(monstroEfeito);
                    mensagem = "Subtipo de Monstro Efeito cadastrado com sucesso!";
                }
                else
                {
                    MonstroEfeitoDAO.AlterarMonstroEfeito(monstroEfeito);
                    Response.Redirect("MonstroEfeito");
                }

                PopularLvMonstroEfeito(MonstroEfeitoDAO.ObterMonstrosEfeito());

                lblMensagem.InnerText = mensagem;
                txtMonstroEfeito.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvMonstroEfeito(List<MonstroEfeito> lista)
        {
            lvMonstroEfeito.DataSource = lista;
            lvMonstroEfeito.DataBind();
        }

        private void PreencherDados(int id)
        {
            MonstroEfeito monstroEfeito = MonstroEfeitoDAO.ObterMonstroEfeito(id);
            if (monstroEfeito != null)
            {
                txtMonstroEfeito.Text = monstroEfeito.NomeMonstroEfeito;
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
                    VisualizarMonstroEfeitos(id);
                }
                else 
                {
                    AlterarMonstroEfeito(id);
                }
            }
        }

        private void AlterarMonstroEfeito(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarMonstroEfeitos(int id)
        {
            PreencherDados(id);
            txtMonstroEfeito.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    MonstroEfeitoDAO.RemoverMonstroEfeito(id);
                }

                PopularLvMonstroEfeito(MonstroEfeitoDAO.ObterMonstrosEfeito());
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

        protected void btn_VerificaMonstro_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Monstro_Pendulo/FrmMonstroPendulo.aspx");
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonstroEfeito");
        }
    }
}