using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YugiohApp.Tipo_Carta.TipoArmadilha;

namespace YugiohApp
{
    public partial class FrmTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<TipoCarta> lista = TipoDAO.ObterTipoCarta();
                PopularLvTipoCarta(lista);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                TipoCarta tipoCarta = null;

                if (!alterando)
                {
                    tipoCarta = new TipoCarta();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    tipoCarta = TipoDAO.ObterTipo(codigo);
                }

                var mensagem = "";

                tipoCarta.NomeTipoCarta = txtTipoCarta.Text;
 
                if (!alterando)
                {
                    TipoDAO.CadastrarTipoCarta(tipoCarta);
                    mensagem = "Tipo de carta cadastrado com sucesso!";
                }
                else
                {
                    TipoDAO.AlterarTipoCarta(tipoCarta);
                    Response.Redirect("~/Tipo_Carta/FrmTipo.aspx");
                }

                PopularLvTipoCarta(TipoDAO.ObterTipoCarta());

                lblMensagem.InnerText = mensagem;
                txtTipoCarta.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
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
                    VisualizarTipoCarta(id);
                }
                else
                {
                    AlterarTipoCarta(id);
                }
            }
        }

        private void AlterarTipoCarta(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void PreencherDados(int id)
        {
            TipoCarta tipoCarta = TipoDAO.ObterTipo(id);
            if (tipoCarta != null)
            {
                txtTipoCarta.Text = tipoCarta.NomeTipoCarta;
            }
        }

        private void VisualizarTipoCarta(int id)
        {
            PreencherDados(id);
            txtTipoCarta.Enabled = false;
            btnCadastrar.Visible = false;
        }


        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    TipoDAO.RemoverTipo(id);
                }

                PopularLvTipoCarta(TipoDAO.ObterTipoCarta());
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }

        }

        private void PopularLvTipoCarta(List<TipoCarta> lista)
        {
            lvTipoCarta.DataSource = lista;
            lvTipoCarta.DataBind();
        }


        protected void btnVerificar_Command(object sender, CommandEventArgs e)
        {
            var NomeTipoCarta = Convert.ToString(e.CommandArgument);

            if (NomeTipoCarta != null)
            {
                Response.Redirect("~/Tipo_Carta/Tipo" + NomeTipoCarta
                        + "/FrmTipo" + NomeTipoCarta + ".aspx");
            }

        }

        private void MensagemDeErro(Exception ex)
        {
            lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação: "+ ex.Message;
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tipo_Carta/FrmTipo.aspx");
        }
    }
}
