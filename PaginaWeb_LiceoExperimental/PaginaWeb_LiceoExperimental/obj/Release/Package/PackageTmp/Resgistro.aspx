<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resgistro.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Resgistro" %>

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

    <script src="../Scripts/hopscotch.js"></script>
    <link href="../Content/hopscotch.css" rel="stylesheet" />

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
                <a class="nav-item nav-link" href=""  onclick="event.preventDefault();" name="guia" >&nbsp;&nbsp;&nbsp;Guía </a>
                <li class="nav-item">
                    <a href="Login.aspx" class="btn navbar-btn" style="color: white">
                        <img src="/Imagenes/Login.png" width="20" height="20" alt="" />&nbsp;&nbsp;&nbsp;Iniciar Sesión</a>
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
                <h3 style="text-align: center;">Registro de usuario</h3>
                <br />
                



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 50rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>


                        <!-- Correo Electronico -->
                        <div class="col-8">
                            <label for="correo_electronico_txt" class="form-label control-label">Correo Electrónico:</label>
                            <input type="email" runat="server" class="form-control" id="correo_electronico_txt" placeholder="Introduce tu correo" required="required" maxlength="100" aria-required/>
                        </div>

                        <!-- Nombre de Usuario -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre de usuario:</label>
                            <input type="text" runat="server" class="form-control" id="nombre_txt" placeholder="Introduce tu nombre de usuario" required="required" minlength="3" maxlength="50" aria-required/>

                        </div>


                        <!-- Contraseña -->
                        <div class="form-group col-sm-6">
                            <label class="control-label col-12" for="password">Contraseña:</label>
                            <div class="col-12">
                                <input class="form-control" runat="server" id="contrasenna_txt" type="password" placeholder="Introduce tu contraseña" required="required" data-toggle="password" minlength="8" maxlength="50"  aria-required/>
                                <input id="check1" for="contrasenna_txt" runat="server" type="checkbox" />
                               Mostrar Contraseña
                            </div>
                        </div>


                        

                        <!-- Confirmar Contraseña -->
                        <div class="form-group col-sm-6">
                            <label class="control-label col-12" for="confirm_txt">Confirmar Contraseña:</label>
                            <div class="col-12">
                                <input class="form-control" runat="server" id="confirm_txt" type="password" placeholder="Confirma la contraseña" required="required" data-toggle="password" minlength="8" maxlength="50"  aria-required/>
                            </div>
                        </div>

                        <!-- Nombre -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre:</label>
                            <input type="text" runat="server" class="form-control" id="irlName_txt" placeholder="Introduce tu nombre" required="required" minlength="3" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                        <!-- Primer Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Primer Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido1_txt" placeholder="Introduce tu primer apellido" required="required" minlength="3" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                         <!-- Segundo Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Segundo Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido2_txt" placeholder="Introduce tu segundo apellido" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" />

                        </div>

                        <!-- ID -->
                        <div class="col-sm-5">
                            <label for="name_txt" class="form-label control-label">Identificación:</label>
                            <input type="text" runat="server" class="form-control" id="id_txt" placeholder="Introduce el valor de tu identificación" required="required" minlength="3" maxlength="100" aria-required/>

                        </div>

                        <!-- Telefono -->
                        <div class="col-sm-4">
                            <label for="phone_txt" class="form-label control-label">Teléfono:</label>
                            <input type="number" runat="server" class="form-control" id="phone_txt" placeholder="Introduce tu número de teléfono"  maxlength="20" minlenght="3" pattern="[0-9]{1,50}" aria-required/>

                        </div>

                        <!-- Tipo identificación -->
                        <div class="col-sm-3">
                            <label for="id_opt" runat="server" class="form-label" id="id_lbl">Tipo Identificación:</label>
                            <select class="form-control form-select" runat="server" id="id_opt">
                                <option>Cedula</option>
                                <option>DIMEX/Residencia</option>
                                <option>Pasaporte</option>
                                <option>Cedula Juridica</option>
                            </select>
                        </div>

                        <!-- Genero -->
                        <div class="col-sm-4">
                            <label for="id_opt" runat="server" class="form-label" id="Label1">Género:</label>
                            <select class="form-control form-select" runat="server" id="genero_opt">
                                <option>Masculino</option>
                                <option>Femenino</option>
                                <option>Otro</option>
                            </select>
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
                            <asp:Button ID="registrar_btn" runat="server" type="button" class="btn btn-success" Text="Registrarse" onClick="Registrar_Click"/>
                            &nbsp;
                        </div>
                        
                    </div>
                </form>

            </div>
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

        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Formulario de Usuario",
                    content: "En esta sección puedes ya sea crear o modificar un usuario (dependiendo de la opción que escogistes)",
                    target: "#formulario",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Correo Electrónico",
                    content: "Aquí se debe ingresar el correo electrónico del usuario (no más de 100 carácteres)",
                    target: "#correo_electronico_txt",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Nombre de usuario",
                    content: "Se puede ingresar el nombre de usuario único de cada persona",
                    target: "#nombre_txt",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Contraseña",
                    content: "Aquí se ingresa la contraseña propia de este usuario(mínimo de 8 caracteres)",
                    target: "#contrasenna_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Confirmar contraseña",
                    content: "Se vuelve ingresas la contraseña para confirmar que sea la correcta.",
                    target: "#confirm_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Nombre de la persona",
                    content: "Se tiene que ingresar el nombre de la persona(solo se aceptan letras)",
                    target: "#irlName_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: " Primer apellido de la persona",
                    content: "Se tiene que ingresar el primer apellido de la persona(solo se aceptan letras)",
                    target: "#apellido1_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: " Segundo apellido de la persona",
                    content: "Se tiene que ingresar el segundo apellido de la persona(solo se aceptan letras)",
                    target: "#apellido2_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Número de identificación",
                    content: "En este apartado se tiene que ingresar la identificación de la persona",
                    target: "#id_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Número de teléfono",
                    content: "Se tiene que ingresar el número de teléfono de la personas(solo se aceptan numeros)",
                    target: "#phone_txt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Tipo de identificación",
                    content: "Se escoge una de las opciones presentadas en el apartado y la que se ajuste a su identificación",
                    target: "#id_opt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Genero",
                    content: "Se escoge el genero que lo identifique(en caso de ser otro esta la opción de otro)",
                    target: "#genero_opt",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Registrar",
                    content: "Una vez llenes todos los campos, pulsa este botón para hacer surtir efecto la operación que quieres realizar",
                    target: "#registrar_btn",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },

            ]

        };

        $(document).on("click", "a[name='guia']", function (e) {
            hopscotch.startTour(myTour);
        });
    </script>


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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The Future Is Ours 
                    </p>
                </div>
        </footer>
</body>
</html>
