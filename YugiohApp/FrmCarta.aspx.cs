using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using YugiohApp.Tipo_Carta.TipoArmadilha;
using YugiohApp.Tipo_Carta.TipoMagia;
using YugiohApp.Tipo_Carta.TipoMonstro;
using YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito;
using YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito.Monstro_Pendulo;

namespace YugiohApp
{
    public partial class FrmCartas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Carta> lista = CartaDAO.ObterCartas();
                PopularLvCartas(lista);
                List<TipoCarta> listatipos = TipoDAO.ObterTipoCarta();
                PopularDdlTipo(listatipos);
                List<Icone> listaIcone = IconeDAO.ObterIcones();
                PopularDdlIcone(listaIcone);
                List<Atributo> listaAtributo = AtributoDAO.ObterAtributos();
                PopularDdlAtributo(listaAtributo);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Carta carta = null;

                if (!alterando)
                {
                    carta = new Carta();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    carta = CartaDAO.ObterCarta(codigo);
                }

                // Itens que não permitem nulo
                carta.NomeCarta = txtNomeCarta.Text;
                carta.NumeroCarta = txtNumCarta.Text;
                carta.DescricaoCarta = txtDescricaoCarta.Text;

                // Itens que permitem nulo
                var nivel = txtNivel.Text;
                var ataque = txtAtaque.Text;
                var defesa = txtDefesa.Text;

                if (nivel != "")
                {
                    carta.Nivel = Convert.ToInt32(nivel);
                }

                if (ataque != "")
                {
                    carta.Ataque = Convert.ToInt32(ataque);
                }

                if (defesa != "")
                {
                    carta.Defesa = Convert.ToInt32(defesa);
                }

                //selecionando o atributo
                var idSelecionado = ddlAtributo.SelectedIndex;
                if (idSelecionado > 0)
                {
                    var idAtb = Convert.ToInt32(ddlAtributo.SelectedValue);
                    carta.AtributoId = idAtb;
                }

                //selecionando o icone
                idSelecionado = ddlIcone.SelectedIndex;
                if (idSelecionado > 0)
                {
                    var idIcn = Convert.ToInt32(ddlIcone.SelectedValue);
                    carta.IconeId = idIcn;
                }

                //selecionando o tipo da carta
                idSelecionado = ddlTipoCarta.SelectedIndex;
                if (idSelecionado > 0)
                {
                    var idTC = Convert.ToInt32(ddlTipoCarta.SelectedValue);
                    carta.TipoCartaId = idTC;
                }

                var mensagem = "";

                if (!alterando)
                {
                    CartaDAO.CadastrarCarta(carta);
                    UploadImg(carta);
                    LimparTxt();
                    mensagem = "Carta cadastrada com sucesso!";
                }
                else
                {
                    CartaDAO.AlterarCarta(carta);
                    Response.Redirect("Carta");
                }

                PopularLvCartas(CartaDAO.ObterCartas());

                lblMensagem.InnerText = mensagem;
                txtNomeCarta.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvCartas(List<Carta> lista)
        {
            lvCartas.DataSource = lista;
            lvCartas.DataBind();
        }

        private void PreencherDados(int id)
        {
            Carta carta = CartaDAO.ObterCarta(id);
            try
            {
                if (carta != null)
                {
                    txtNomeCarta.Text = carta.NomeCarta;
                    txtNumCarta.Text = carta.NumeroCarta;
                    txtDescricaoCarta.Text = carta.DescricaoCarta;
                    txtNivel.Text = Convert.ToString(carta.Nivel);
                    txtAtaque.Text = Convert.ToString(carta.Ataque);
                    txtDefesa.Text = Convert.ToString(carta.Defesa);
                    ddlAtributo.SelectedValue = Convert.ToString(carta.AtributoId);
                    ddlIcone.SelectedValue = Convert.ToString(carta.IconeId);
                    ddlTipoCarta.SelectedValue = Convert.ToString(carta.TipoCartaId);
                }
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }


        private void ChecarQueryString()
        {
            var idQuery = Request.QueryString["id"];
            imgUser.Visible = false;

            if (idQuery != null)
            {
                var id = Convert.ToInt32(idQuery);

                var view = Request.QueryString["view"];

                if (view != null)
                {
                    VisualizarCartas(id);
                }
                else 
                {
                    AlterarCarta(id);
                }
            }
        }

        private void AlterarCarta(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
            imgUser.Visible = false;
        }

        private void VisualizarCartas(int id)
        {
            try
            {
                PreencherDados(id);
                var nomeCarta = txtNomeCarta.Text;
                imgUser.Src = "imagensCarta\\" + nomeCarta + ".png";
                txtNomeCarta.Enabled = false;
                txtNivel.Enabled = false;
                txtNumCarta.Enabled = false;
                txtAtaque.Enabled = false;
                txtDefesa.Enabled = false;
                txtDescricaoCarta.Enabled = false;
                ddlAtributo.Enabled = false;
                ddlIcone.Enabled = false;
                ddlTipoCarta.Enabled = false;
                btnCadastrar.Visible = false;
                imgUser.Visible = true;
                FupImagem.Visible = false;
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
           


        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    CartaDAO.RemoverCarta(id);
                }

                PopularLvCartas(CartaDAO.ObterCartas());
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

        private void PopularDdlTipo(List<TipoCarta> listatipos)
        {
            try
            {
                ddlTipoCarta.DataSource = listatipos.OrderBy(x => x.NomeTipoCarta);
                ddlTipoCarta.DataTextField = "NomeTipoCarta";
                ddlTipoCarta.DataValueField = "IdTipoCarta";
                ddlTipoCarta.DataBind();

                ddlTipoCarta.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }

        private void PopularDdlMonstro(List<Monstro> listaMonstro)
        {
            try
            {
                ddlSubtipo.DataSource = listaMonstro.OrderBy(x => x.NomeMonstro);
                ddlSubtipo.DataTextField = "NomeMonstro";
                ddlSubtipo.DataValueField = "IdMonstro";
                ddlSubtipo.DataBind();

                ddlSubtipo.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }
        private void PopularDdlArmadilha(List<Armadilha> listaArmadilhas)
        {
            try
            {
                ddlSubtipo.DataSource = listaArmadilhas.OrderBy(x => x.NomeArmadilha);
                ddlSubtipo.DataTextField = "NomeArmadilha";
                ddlSubtipo.DataValueField = "IdArmadilha";
                ddlSubtipo.DataBind();

                ddlSubtipo.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
           
        }
        private void PopularDdlMagia(List<Magia> listaMagias)
        {
            try
            {
                ddlSubtipo.DataSource = listaMagias.OrderBy(x => x.NomeMagia);
                ddlSubtipo.DataTextField = "NomeMagia";
                ddlSubtipo.DataValueField = "IdMagia";
                ddlSubtipo.DataBind();

                ddlSubtipo.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }    
        
        private void PopularDdlMonstroEfeito(List<MonstroEfeito> listamonstroEfeitos)
        {
            try
            {
                ddlStSecundario.DataSource = listamonstroEfeitos.OrderBy(x => x.NomeMonstroEfeito);
                ddlStSecundario.DataTextField = "NomeMonstroEfeito";
                ddlStSecundario.DataValueField = "IdMonstroEfeito";
                ddlStSecundario.DataBind();

                ddlStSecundario.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }

        private void PopularDdlPendulo(List<MonstroPendulo> listamonstroPendulo)
        {
            try
            {
                ddlStPendulo.DataSource = listamonstroPendulo.OrderBy(x => x.NomeMonstroPendulo);
                ddlStPendulo.DataTextField = "NomeMonstroPendulo";
                ddlStPendulo.DataValueField = "IdMonstroPendulo";
                ddlStPendulo.DataBind();

                ddlStPendulo.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }
        private void PopularDdlIcone(List<Icone> listaIcone)
        {
            try
            {
                ddlIcone.DataSource = listaIcone.OrderBy(x => x.NomeIcone);
                ddlIcone.DataTextField = "NomeIcone";
                ddlIcone.DataValueField = "IdIcone";
                ddlIcone.DataBind();

                ddlIcone.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }

        private void PopularDdlAtributo(List<Atributo> listaAtributo)
        {
            try
            {
                ddlAtributo.DataSource = listaAtributo.OrderBy(x => x.NomeAtributo);
                ddlAtributo.DataTextField = "NomeAtributo";
                ddlAtributo.DataValueField = "IdAtributo";
                ddlAtributo.DataBind();

                ddlAtributo.Items.Insert(0, "Selecione..");
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
            
        }

       
        private void PopularDdlArmadilha()
        {
            List<Armadilha> listaArmadilha = TipoArmadilhaDAO.ObterArmadilhas();
            PopularDdlArmadilha(listaArmadilha);
        }
        private void PopularDdlMagia()
        {

            List<Magia> listaMagias = TipoMagiaDAO.ObterMagias();
            PopularDdlMagia(listaMagias);
        }

        private void PopularDdlMonstro()
        {
            List<Monstro> listaMonstros = TipoMonstroDAO.ObterMonstros();
            PopularDdlMonstro(listaMonstros);
        }

        private void PopularDdlMonstroEfeito()
        {
            List<MonstroEfeito> listamonstroEfeitos = MonstroEfeitoDAO.ObterMonstrosEfeito();
            PopularDdlMonstroEfeito(listamonstroEfeitos);
        }

        private void PopularDdlPendulo()
        {
            List<MonstroPendulo> listamonstroPendulo = MonstroPenduloDAO.ObterMonstrosPendulo();
            PopularDdlPendulo(listamonstroPendulo);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Session["NumeroCarta"] = txtNumCarta.Text;

            if (fuImagem.HasFile)
            {
                var arquivo = fuImagem.PostedFile;

                var mapa = MapPath("~/");
                var caminho = mapa + "imagensCarta\\" +
                    ((Carta)Session["NumeroCarta"]).NumeroCarta + ".png";

                arquivo.SaveAs(caminho);
            }
        }

        protected void ddlTipoCarta_SelectedIndexChanged(object sender, EventArgs e)
        {

            var idx = Convert.ToInt32(ddlTipoCarta.SelectedIndex);
            if (idx == 1)
            {
                paragrafoSubtipo.Style.Add("display", "block");
                PopularDdlArmadilha();


            }
            else if (idx == 2)
            {
                paragrafoSubtipo.Style.Add("display", "block");
                PopularDdlMagia();
            }
            else if (idx == 3)
            {
                paragrafoSubtipo.Style.Add("display", "block");
                PopularDdlMonstro();
            }
            else
            {
                paragrafoSubtipo.Style.Add("display", "none");
            }
        }


        protected void ddlSubtipo_TextChanged(object sender, EventArgs e)
        {
            var nomex = Convert.ToString(ddlSubtipo.SelectedItem);
            if (nomex == "Efeito")
            {
                SubtipoSecundario.Style.Add("display", "block");
                PopularDdlMonstroEfeito();

            }
            else if (nomex != "Efeito")
            {
                SubtipoSecundario.Style.Add("display", "none");
            }

        }
       
        protected void ddlStSecundario_TextChanged(object sender, EventArgs e)
        {
            var nomeRecebido = Convert.ToString(ddlStSecundario.SelectedItem);

            if (nomeRecebido == "Pendulo")
            {
                SubtipoPendulo.Style.Add("display", "block");
                PopularDdlPendulo();

            }
            else if (nomeRecebido != "Pendulo")
            {
                SubtipoPendulo.Style.Add("display", "none");
            }

        }

        private void LimparTxt()
        {
            txtNomeCarta.Text = "";
            txtNivel.Text = "";
            txtNumCarta.Text = "";
            txtAtaque.Text = "";
            txtDefesa.Text = "";
            txtDescricaoCarta.Text = "";
            ddlAtributo.SelectedIndex = 0;
            ddlIcone.SelectedIndex = 0;
            ddlTipoCarta.SelectedIndex = 0;

        }

        private void UploadImg(Carta carta)
        {
            if (fuImagem.HasFile)
            {
                var arquivo = fuImagem.PostedFile;

                var mapa = MapPath("~/");
                var caminho = mapa + "imagensCarta\\" + carta.NomeCarta + ".png";

                arquivo.SaveAs(caminho);
            }
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carta");
        }
    }

}