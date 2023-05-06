<%@ Page Title="" Language="C#" MasterPageFile="~/Profes/NavProfesores.Master" AutoEventWireup="true" CodeBehind="FormularioProfesor.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Profes.FormularioProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Registro de Profesor</h3>
                <br />
                



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 50rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <!-- Nombre -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre:</label>
                            <input type="text" runat="server" class="form-control" id="nombre_txt" placeholder="Introduce nombre del profesor/a" required="required" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                        <!-- Primer Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Primer Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido1_txt" placeholder="Introduce primer apellido del profesor/a" required="required" maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" aria-required/>

                        </div>

                        <!-- Segundo Apellido -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Segundo Apellido:</label>
                            <input type="text" runat="server" class="form-control" id="apellido2_txt" placeholder="Introduce segundo apellido del profesor/a"  maxlength="50" pattern="[A-Za-zÀ-ž\s]{1,50}" />

                        </div>


                        <!-- Correo Electronico -->
                        <div class="col-8">
                            <label for="correo_electronico_txt" class="form-label control-label">Correo Electrónico:</label>
                            <input type="email" runat="server" class="form-control" id="correo_electronico_txt" placeholder="Introduce correo del profesor/a" required="required" maxlength="100" aria-required/>
                        </div>

                        <!-- Telefono -->
                        <div class="col-sm-4">
                            <label for="phone_txt" class="form-label control-label">Teléfono:</label>
                            <input type="number" runat="server" class="form-control" id="phone_txt" placeholder="Introduce número de teléfono del profesor/a" maxlength="50" pattern="[0-9]{1,50}"/>

                        </div>

                        <!-- Descripcion-->
                        <div class="col-sm-12">
                            <label for="descripcion_txt" runat="server" class="form-label" id="descripcion_lbl">Descripción del profesor:</label>
                            <textarea  runat="server" class="form-control" id="descripcion_txt" placeholder="Introduzca descripción del profesor/a" rows="4" required="required" maxlength="2000" />
                        </div>

                        <!-- Imagen -->
                        <div class="col-sm-5">
                            <label for="img_fld " class="form-label" id="img_lbl" runat="server">Imagen:</label>
                            <asp:FileUpload type="file" runat="server" class=" form-control" id="img_fld" accept=".png,.jpg,.jpeg" />
                            <small id="nota" runat="server" class="form-text text-muted">Formatos aceptados: .png, .jpeg, .jpg. Máximo 2mb</small>
                            <p id="nota2" runat="server" class="form-text " style="color: red">NOTA: La imagen original será introducida si no selecciona una nueva imagen</p>
                        </div>

                        

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <asp:Button ID="insertar_btn" runat="server" type="button" class="btn btn-success" Text="Aceptar" onClick="Enviar_Click"/>
                            &nbsp;
                            <asp:Button ID="cancelar_btn" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Cancelar_Click" formnovalidate />
                            &nbsp;
                        </div>

                        <script>
                            window.onload = function () {
                                if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=nota2.ClientID%>').hide();
                                    $('#<%=titulo_h.ClientID%>').text("Crear Profesor");
                                    $('#<%=insertar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Profesor");
                                    $('#<%=insertar_btn.ClientID%>').attr('value', 'Modificar');
                                }
                            };

                            $('#<%=img_fld.ClientID%>').change(function () {
                                $('#<%=nota2.ClientID%>').hide();
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
                                        title: "Nombre del profesor",
                                        content: "Se puede ingresar el nombre del profesor",
                                        target: "#<%=nombre_txt.ClientID%>",
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
                                        title: "Correo Electrónico",
                                        content: "Aquí se debe ingresar el correo electrónico del usuario (no más de 100 carácteres)",
                                        target: "#<%=correo_electronico_txt.ClientID%>",
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
                                        title: "Descripción",
                                        content: "Se escribe una descripción introductoria sobre el profesor y los datos que se crean pertinentes",
                                        target: "#<%=descripcion_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                    title: "Imagen del profesor",
                                    content: "Se ingresa la imagen del profesor el cual se le esta ingresando la información",
                                    target: "#<%=nota.ClientID%>",
                                    placement: "bottom",
                                    showCloseButton: true,
                                    showPrevButton: true,
                                    },

                            {
                                title: "Registrar",
                                content: "Una vez llenes todos los campos, pulsa este botón para hacer surtir efecto la operación que quieres realizar",
                                target: "#<%=insertar_btn.ClientID%>",
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
                        
                    </div>
                </form>

            </div>
        </div>
         
    </div>

    <br />
    <br />

</asp:Content>
