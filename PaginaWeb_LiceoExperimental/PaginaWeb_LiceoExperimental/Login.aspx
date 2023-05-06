<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1" />
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script" rel="stylesheet">

    <link href="CSS/Estilo.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-expand-md">
        <a class="navbar-brand" href="/Login.aspx">&nbsp;&nbsp;<img src="/Imagenes/Logo.png" width="70" height="100" alt="" />
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"><img src="/Imagenes/Tog.png"/ width="35" height="35" aling="center"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <a id="eventos_a" runat="server" class="nav-item nav-link" style="padding: 20px;" href="Eventos/Eventos.aspx">Eventos</a>
                <a id="noticias_a" runat="server" class="nav-item nav-link" style="padding: 20px;" href="Noticias/Noticias.aspx">Noticias</a>
            </div>
            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <a href="Resgistro.aspx" class="btn navbar-btn" style="color: white">
                        <img src="/Imagenes/User.png" width="20" height="20" alt="" />&nbsp;&nbsp;&nbsp;Registro</a>
                </li>
            </ul>
        </div>
    </nav>


     <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 style="text-align: center;">Liceo Experimental Bilingüe de Grecia</h3>
                <h3 style="text-align: center;">Inicio de Sesión al Portal</h3>
                <br />



                <form class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 22rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Label1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <div class="col-12">
                            <label for="correo_electronico_txt" class="form-label control-label">Correo:</label>
                            <input type="email" runat="server" class="form-control" id="correo_electronico_txt" placeholder="Introduce tu correo" required="required" maxlength="100" />

                        </div>


                        <div class="form-group">
                            <label class="control-label col-12" for="pwd">Contraseña:</label>
                            <div class="col-12">
                                <input class="form-control" runat="server" id="contrasenna_txt" type="password" placeholder="Introduce tu contraseña" required="required" data-toggle="password" maxlength="50" />
                                <input id="check1" for="contrasenna_txt" runat="server" type="checkbox" />
                                Mostrar Contraseña
                            </div>
                        </div>

                        <script>
                            $("#check1").on("change", function () {
                                if ($(this).prop('checked')) {
                                    $("#contrasenna_txt").attr("type", "text");
                                } else {
                                    $("#contrasenna_txt").attr("type", "password");
                                }
                            });
                        </script>

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <div align="center">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-10">
                                    <div class="col-sm-4">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <asp:Button ID="ingresar_btn" runat="server" type="button" class="btn btn-success" Text="Ingresar" OnClick="Ingresar_Click"/>
                            &nbsp;
                        </div>
                        
                    </div>
                </form>

            </div>
        </div>
         
    </div>

    <br />
    <br />
    <br />

    <footer  class="site-footer navbar" style="position: relative; background-color: #808080; width: 100%; height: 10%; bottom: 0">     
            <div class="col-4" style="margin-left: 0%">
                    <p  style="color: white; font-size: 15px; margin-left: 10px">
                        lic.exp.bilingue@mep.go.cr   
                    </p>
                    <p  style="color: white; font-size: 15px; margin-left: 10px">
                        Tel. (506) 2444-1220 / 2444-1318.&nbsp;
                    </p>
            </div> 
                <div class="col-7" align="left" style="margin-right: 0%; height: 100%">
                    <p  style="color: white; font-size: 20px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The Future Is Ours 
                    </p>
                </div>
        </footer>

</body>
</html>
