using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp.Tipo_Carta.TipoArmadilha
{
    public partial class FrmTipoArmadilha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Armadilha> lista = TipoArmadilhaDAO.ObterArmadilhas();
                PopularLvArmadilha(lista);
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Armadilha armadilha = null;

                if (!alterando)
                {
                    armadilha = new Armadilha();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    armadilha = TipoArmadilhaDAO.ObterArmadilha(codigo);
                }

                armadilha.NomeArmadilha = txtArmadilha.Text;

                var mensagem = "";

                if (!alterando)
                {
                    TipoArmadilhaDAO.CadastrarArmadilha(armadilha);
                    mensagem = "Tipo de munição cadastrado com sucesso!";
                }
                else
                {
                    TipoArmadilhaDAO.AlterarArmadilha(armadilha);
                    Response.Redirect("Armadilha");
                }

                PopularLvArmadilha(TipoArmadilhaDAO.ObterArmadilhas());

                lblMensagem.InnerText = mensagem;
                txtArmadilha.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvArmadilha(List<Armadilha> lista)
        {
            lvArmadilha.DataSource = lista;
            lvArmadilha.DataBind();
        }

        private void PreencherDados(int id)
        {
            Armadilha armadilha = TipoArmadilhaDAO.ObterArmadilha(id);
            if (armadilha != null)
            {
                txtArmadilha.Text = armadilha.NomeArmadilha;
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
                    VisualizarArmadilhas(id);
                }
                else
                {
                    AlterarArmadilha(id);
                }
            }
        }

        private void AlterarArmadilha(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarArmadilhas(int id)
        {
            PreencherDados(id);
            txtArmadilha.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    TipoArmadilhaDAO.RemoverArmadilha(id);
                }

                PopularLvArmadilha(TipoArmadilhaDAO.ObterArmadilhas());
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

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Armadilha");
        }
    }
}