<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="PROYECTO_CONFITERIA.Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet"/>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/style.css"/>
    <link href="css/cssLogin/styleLogin.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.bundle.min.js"></script>
    <script src="https://use.fontawesome.com/releases/v5.8.1/css/all.css"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body class="main-bg">
    <div class="login-container text-c animated flipInX">
        <div>
            <h1 class="logo-badge text-whitesmoke"><span class="fa fa-user-circle"></span></h1>
        </div>
        <h3 class="text-whitesmoke">Encode Confi</h3>
        <p class="text-whitesmoke">Iniciar Sesión</p>
        <div class="container-content">
            <form runat="server" class="margin-t">
                <div class="form-group">
                    <asp:TextBox runat="server" type="text" CssClass="form-control" placeholder="Nombre de Usuario" required="" ID="txtNombreUsuario" />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" type="password" CssClass="form-control" placeholder="*****" required="" ID="txtPassword" />
                </div>
                <asp:Button ID="btnIniciarSesion" runat="server" type="submit" class="form-button button-l margin-b" Text="Ingresar" OnClick="btnIniciarSesion_Click"></asp:Button>

                <a class="text-darkyellow" href="#"><small>Olvidó su contraseña?</small></a>
                <p class="text-whitesmoke text-center"><small>Usted no tiene una cuenta?</small></p>
                <a class="text-darkyellow" href="#"><small>Crear cuenta</small></a>
            </form>
            <p class="margin-t text-whitesmoke"><small>Encode Confi &copy; 2021</small> </p>
        </div>
    </div>
</body>
</html>
