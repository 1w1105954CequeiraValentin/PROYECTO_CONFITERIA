<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROYECTO_CONFITERIA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="main-bg">
        <div class="login-container text-c animated flipInX">
                <div>
                    <h1 class="logo-badge text-whitesmoke"><span class="fa fa-user-circle"></span></h1>
                </div>
                    <h3 class="text-whitesmoke">Encode Confi</h3>
                    <p class="text-whitesmoke">Iniciar Sesión</p>
                <div class="container-content">
                    <form class="margin-t">
                        <div class="form-group">
                            <input type="text" class="form-control" placeholder="Nombre de Usuario" required="">
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control" placeholder="*****" required="">
                        </div>
                        <button type="submit" class="form-button button-l margin-b">Ingresar</button>
        
                        <a class="text-darkyellow" href="#"><small>Olvidó su contraseña?</small></a>
                        <p class="text-whitesmoke text-center"><small>Usted no tiene una cuenta?</small></p>
                        <a class="text-darkyellow" href="#"><small>Crear cuenta</small></a>
                    </form>
                    <p class="margin-t text-whitesmoke"><small> Encode Confi &copy; 2021</small> </p>
                </div>
            </div>
</body>
</asp:Content>
