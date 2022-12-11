<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMonstroPendulo.aspx.cs" Inherits="YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito.Monstro_Pendulo.FrmMonstroPendulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciamento de Monstro Pêndulo</title>
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
     <link href="../../../../css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
</head>
<body id="page-top">
    <!-- Navigation-->
    <nav class="navbar navbar-expand-lg bg-secondary text-uppercase fixed-top" id="mainNav">
        <div class="container px-4">
            <a class="navbar-brand" href="#">Gerenciador de Cartas</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item"><a class="nav-link" href="../../../../Carta">Cadastrar Cartas</a></li>
                    <li class="nav-item"><a class="nav-link" href="../../../FrmTipo.aspx">Gerenciar Tipos</a></li>
                    <li class="nav-item"><a class="nav-link" href="../../../../Atributo">Gerenciar Atributos</a></li>
                    <li class="nav-item"><a class="nav-link" href="../../../../Icone">Gerenciar Icones</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- Header-->
    <header class="masthead bg-primary text-white text-center">
        <div class="container px-4 text-center">
            <h1 class="fw-bolder">Sistema de Gerenciamento de Cartas!</h1>
            <h2 class="fw-bold">Cadastre uma Monstro Pêndulo!</h2>
        </div>
    </header>
    <style>
        #portfolio {
            padding-top: 100px;
        }

        #TituloGaleria {
            padding-bottom: 70px
        }
    </style>

    <main>
        <br />
        <br />
        <div class="row justify-content-center">
            <div class="col-lg-8 col-xl-7">
                <form id="form1" runat="server" style="border-style: groove; padding: 1.5rem; border-radius: 10px; box-shadow: 15px;">
                    <div class="form-floating mb-3">
                        <div>
                            <label>Adicionar Monstro Pêndulo:</label>
                        </div>
                        <div>
                            <asp:TextBox
                                runat="server" ID="txtMonstroPendulo" class="form-control" data-sb-validations="required" />
                        </div>
                    </div>
                    <div class="font-weight-normal mb-3" id="Div_btnCadastrar" runat="server">
                        <asp:Button
                            Text="Cadastrar"
                            runat="server"
                            ID="btnCadastrar"
                            OnClick="btnCadastrar_Click" class="col-12 btn btn-primary" />
                    </div>

                     <div class="font-weight-normal mb-3" id="Div_btnVoltar" runat="server">
                        <asp:Button Text="Voltar"
                            ID="Limparlbl"
                            OnClick="Limparlbl_Click"
                            runat="server" class="col-12 btn btn-primary" />
                    </div>

                    <label runat="server" id="lblMensagem"></label>

                    <table border="1" class="list-group-item-action bg-gradient">
                        <thead>
                            <tr>
                                <td>Código</td>
                                <td>Nome Monstro Pêndulo</td>
                                <td colspan="3">Ações</td>
                            </tr>
                        </thead>
                        <asp:ListView runat="server" ID="lvMonstroPendulo">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("IdMonstroPendulo") %>
                                    </td>
                                    <td>
                                        <%# Eval("NomeMonstroPendulo") %>
                                    </td>

                                    <td>
                                        <a href='<%# "~/MonstroPendulo?view=1&id=" + Eval("IdMonstroPendulo") %>'
                                            runat="server">
                                            <img src="../../../../imagens/view-details.png" style="max-width: 20px;" />
                                        </a>

                                    </td>

                                    <td>
                                        <a href='<%# "~/MonstroPendulo?id=" + Eval("IdMonstroPendulo") %>'
                                            runat="server">
                                            <img src="../../../../imagens/edit.png" style="max-width: 20px;" />
                                        </a>
                                    </td>
                                    <td>
                                        <asp:ImageButton
                                            ID="btn_Excluir"
                                            ImageUrl="~/imagens/delete.jpg"
                                            runat="server"
                                            Style="max-width: 20px;"
                                            OnCommand="btn_Excluir_Command"
                                            CommandArgument='<%# Eval("IdMonstroPendulo") %>'
                                            CommandName="Excluir"
                                            OnClientClick="return confirm('Deseja realmente excluir esse item??')" />

                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EmptyItemTemplate>
                                <%--Não existem itens!!--%>
                                <strong>Não existem Monstro Pêndulos cadastrados!</strong>
                            </EmptyItemTemplate>
                        </asp:ListView>
                    </table>
                </form>
            </div>
        </div>
    </main>
    <br />
    <!-- Footer-->
    <footer class="footer text-center p-5">
        <div class="container">
            <div class="row">
                <!-- Footer Location-->
                <div class="col-lg-4 mb-5 mb-lg-0">
                    <h4 class="text-uppercase mb-4">Programação para internet 2</h4>
                </div>
                <!-- Footer Social Icons-->
                <div class="col-lg-4 mb-5 mb-lg-0">
                    <h4 class="text-uppercase mb-4">Redes Sociais</h4>
                    <a class="btn btn-outline-light btn-social mx-1" href="#!"><i class="fab fa-fw fa-instagram"></i></a>
                    <a class="btn btn-outline-light btn-social mx-1" href="#!"><i class="fab fa-fw fa-twitter"></i></a>
                    <a class="btn btn-outline-light btn-social mx-1" href="#!"><i class="fab fa-fw fa-linkedin-in"></i></a>
                    <a class="btn btn-outline-light btn-social mx-1" href="#!"><i class="fab fa-fw fa-github"></i></a>
                </div>
                <!-- Footer About Text-->
                <div class="col-lg-4">
                    <h4 class="text-uppercase mb-4">Sobre os Dev's</h4>
                    <p class="lead mb-0">
                        Sistema desenvolvivo por Jonata, Maria, Nathan e Rafael
                        
                    </p>
                </div>
            </div>
        </div>
    </footer>

    <!-- Bootstrap core JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Core theme JS-->
    <script src="js/scripts.js"></script>
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <!-- * *                               SB Forms JS                               * *-->
    <!-- * * Activate your form at https://startbootstrap.com/solution/contact-forms * *-->
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

