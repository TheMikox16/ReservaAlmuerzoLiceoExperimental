<%@ Page Title="" Language="C#" MasterPageFile="~/Usuarios/NavUsuarios.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Usuarios.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script" rel="stylesheet">

    <link href="../CSS/Estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Registro de usuario</h3>
                <br />
                
                


                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 50rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>


                        <!-- Correo Electronico -->
                        <div class="col-8">
                            <label for="correo_electronico_txt" class="form-label control-label">Correo Electronico:</label>
                            <input type="email" runat="server" class="form-control" id="correo_electronico_txt" placeholder="Introduce el email" required="required" maxlength="100" aria-required/>
                        </div>

                        <!-- Nombre de Usuario -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre de usuario:</label>
                            <input type="text" runat="server" class="form-control" id="nombre_txt" placeholder="Introduce el nombre de usuario" required="required" minlength="3" maxlength="50" aria-required/>

                        </div>


                        <!-- Contraseña -->
                        <div class="form-group col-sm-6">
                            <label class="control-label col-12" for="password">Contraseña:</label>
                            <div class="col-12">
                                <input class="form-control" runat="server" id="contrasenna_txt" type="password" placeholder="Introduce la contraseña" required="required" data-toggle="password" minlength="8" maxlength="50"  aria-required/>
                                <input id="check2" for="contrasenna_txt" runat="server" type="checkbox" />
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

                        <!-- Rol -->
                        <div class="col-sm-4">
                            <label for="id_opt" runat="server" class="form-label" id="Label2">Rol:</label>
                            <select class="form-control form-select" runat="server" id="rol_opt">
                                <option>Admin</option>
                                <option selected>Estudiante/Padre</option>
                                <option>Profesor/a</option>
                                <option>Cocinero/a</option>
                            </select>
                        </div>

                        <!-- Beca -->
                        <div class="col-sm-4">
                            <label for="id_opt" runat="server" class="form-label" id="Label3">Becado:</label>
                            <select class="form-control form-select" runat="server" id="beca_opt">
                                <option>No</option>
                                <option>Si</option>
                            </select>
                        </div>

                        <!-- Permiso -->
                        <div class="col-sm-4">
                            <label for="id_opt" runat="server" class="form-label" id="Label4">Permiso:</label>
                            <select class="form-control form-select" runat="server" id="permiso_opt" disabled>
                                <option>No</option>
                                <option>Si</option>
                            </select>
                        </div>

                        <script>
                            window.onload = function () {
                                if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=titulo_h.ClientID%>').text("Crear Usuario");
                                    $('#<%=registrar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Usuario");
                                    $('#<%=registrar_btn.ClientID%>').attr('value', 'Modificar');
                                }

                                var v = $("#<%=rol_opt.ClientID%>").val();
                                if (v == "Estudiante/Padre") {
                                    $("#<%=permiso_opt.ClientID%>").attr("disabled", true);
                                    $("#<%=beca_opt.ClientID%>").attr("disabled", false);
                                } else if (v == "Profesor/a") {
                                    $("#<%=permiso_opt.ClientID%>").attr("disabled", false);
                                    $("#<%=beca_opt.ClientID%>").attr("disabled", true);
                                }
                            };

                            $("#<%=check2.ClientID%>").on("change", function () {
                                if ($(this).prop('checked')) {
                                    $("#<%=contrasenna_txt.ClientID%>").attr("type", "text");
                                } else {
                                    $("#<%=contrasenna_txt.ClientID%>").attr("type", "password");
                                }
                            });
                            $("#<%=rol_opt.ClientID%>").change(function () {
                                if ($(this).val() === "Estudiante/Padre") {
                                    $("#<%=beca_opt.ClientID%>").attr("disabled", false);
                                    $("#<%=permiso_opt.ClientID%>").attr("disabled", true);
                                } else if ($(this).val() === "Profesor/a") {
                                    $("#<%=beca_opt.ClientID%>").attr("disabled", true);
                                    $("#<%=permiso_opt.ClientID%>").attr("disabled", false);
                                } else {
                                    $("#<%=beca_opt.ClientID%>").attr("disabled", true);
                                    $("#<%=permiso_opt.ClientID%>").attr("disabled", true);
                                }
                            });

                            var myTour = {
                                id: "myTour",
                                steps: [
                                    {
                                        title: "Formulario de Usuario",
                                        content: "En esta sección puedes ya sea crear o modificar un usuario (dependiendo de la opción que escogistes)",
                                        target: "#<%=formulario.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                    },
                                    {
                                        title: "Correo Electrónico",
                                        content: "Aquí se debe ingresar el correo electrónico del usuario (no más de 100 carácteres)",
                                        target: "#<%=correo_electronico_txt.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Nombre de usuario",
                                        content: "Se puede ingresar el nombre de usuario único de cada persona",
                                        target: "#<%=nombre_txt.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Contraseña",
                                        content: "Aquí se ingresa la contraseña propia de este usuario(mínimo de 8 caracteres)",
                                        target: "#<%=contrasenna_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Confirmar contraseña",
                                        content: "Se vuelve ingresas la contraseña para confirmar que sea la correcta.",
                                        target: "#<%=confirm_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Rol",
                                        content: "Aquí se define el papel que juega este usuario dentro del portal",
                                        target: "#<%=rol_opt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Beca",
                                        content: "En caso de ser un estudiante se puede definir si este es becado o no.",
                                        target: "#<%=beca_opt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Permisos",
                                        content: "En caso de ser un profesor se puede escoger que tenga permisos o no.",
                                        target: "#<%=permiso_opt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Nombre de la persona",
                                        content: "Se tiene que ingresar el nombre de la persona(solo se aceptan letras)",
                                        target: "#<%=irlName_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: " Primer apellido de la persona",
                                        content: "Se tiene que ingresar el primer apellido de la persona(solo se aceptan letras)",
                                        target: "#<%=apellido1_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: " Segundo apellido de la persona",
                                        content: "Se tiene que ingresar el segundo apellido de la persona(solo se aceptan letras)",
                                        target: "#<%=apellido2_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Número de identificación",
                                        content: "En este apartado se tiene que ingresar la identificación de la persona",
                                        target: "#<%=id_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Número de teléfono",
                                        content: "Se tiene que ingresar el número de teléfono de la personas(solo se aceptan numeros)",
                                        target: "#<%=phone_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Tipo de identificación",
                                        content: "Se escoge una de las opciones presentadas en el apartado y la que se ajuste a su identificación",
                                        target: "#<%=id_opt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },

                                    {
                                        title: "Genero",
                                        content: "Se escoge el genero que lo identifique(en caso de ser otro esta la opción de otro)",
                                        target: "#<%=genero_opt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },

                            {
                                title: "Registrar",
                                content: "Una vez llenes todos los campos, pulsa este botón para hacer surtir efecto la operación que quieres realizar",
                                target: "#<%=registrar_btn.ClientID%>",
                                placement: "top",
                                showCloseButton: true,
                                showPrevButton: true,
                            },
                            {
                                title: "Cancelar",
                                content: "Pulsa este botón si quieres ir a la pantalla anterior si te arrepientes",
                                        target: "#<%=cancelar_btn.ClientID%>",
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
                        
                        <!-- Nombre -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre:</label>
                            <input type="text" runat="server" class="form-control" id="irlName_txt" placeholder="Introduce el nombre" required="required" minlength="3" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                        <!-- Primer Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Primer Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido1_txt" placeholder="Introduce el primer apellido" required="required" minlength="3" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                        <!-- Segundo Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Segundo Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido2_txt" placeholder="Introduce el segundo apellido" required="required" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" />

                        </div>

                        <!-- ID -->
                        <div class="col-sm-5">
                            <label for="name_txt" class="form-label control-label">Identificación:</label>
                            <input type="text" runat="server" class="form-control" id="id_txt" placeholder="Introduce el valor de la identificación" required="required" maxlength="100" aria-required/>

                        </div>

                        <!-- Telefono -->
                        <div class="col-sm-4">
                            <label for="phone_txt" class="form-label control-label">Teléfono:</label>
                            <input type="number" runat="server" class="form-control" id="phone_txt" placeholder="Introduce el número de telefono" required="required" maxlength="20" minlenght="3" pattern="[0-9]{1,50}" aria-required/>

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
                            <asp:Button ID="registrar_btn" runat="server" type="button" class="btn btn-success" Text="Aceptar" onClick="Enviar_Click"/>
                            &nbsp;
                            <asp:Button ID="cancelar_btn" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Cancelar_Click"  formnovalidate/>
                            &nbsp;
                        </div>
                        
                    </div>
                </form>

            </div>
        </div>
         
    </div>

    <br />
    <br />

</asp:Content>
