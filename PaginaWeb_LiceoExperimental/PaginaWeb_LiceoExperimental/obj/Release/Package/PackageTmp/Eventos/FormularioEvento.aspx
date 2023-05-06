<%@ Page Title="" Language="C#" MasterPageFile="~/Eventos/NavEventos.Master" AutoEventWireup="true" CodeBehind="FormularioEvento.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Eventos.FormularioEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css"type="text/css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"type="text/javascript"></script>




    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Formulario de Evento</h3>
                <br />

                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 60rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Label1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>


                        <!-- Titulo-->
                                <div class="col-sm-8">
                                    <label for="titulo_txt" runat="server" class="form-label" id="titulo_lbl">Nombre/Título de Evento:</label>
                                    <input type="text" runat="server" class="form-control" id="titulo_txt" placeholder="Introduzca título o nombre del evento" required="required" maxlength="200" aria-required/>
                                </div>

                        <!-- Descripcion-->
                                <div class="col-sm-12">
                                    <label for="descripcion_txt" runat="server" class="form-label" id="descripcion_lbl">Descripción:</label>
                                    <textarea  runat="server" class="form-control" id="descripcion_txt" placeholder="Introduzca descripción del evento" rows="4" required="required" maxlength="3000" />
                                </div>

                        <!-- Fecha -->
                            <div class="col-sm-3" >
                                <label for="fecha_txt" runat="server" class="form-label" id="fecha_lbl">Fecha de Evento:</label>
                                <input runat="server" style="cursor: pointer" class="form-control" id="fecha_txt" type="date" aria-required/>
                            </div>

                        <!-- Hora -->
                        <div class="col-sm-3">
                                <label for="fecha_txt" runat="server" class="form-label" id="Label2">Hora de Evento:</label>
                                <input runat="server" style="cursor: pointer" class="form-control" id="hora_txt" type="time" aria-required/>
                            </div>

                        <!-- Imagen -->
                        <div class="col-sm-5">
                            <label for="img_fld " class="form-label" id="img_lbl" runat="server">Imagen:</label>
                            <asp:FileUpload type="file" runat="server" class=" form-control" id="img_fld" accept=".png,.jpg,.jpeg" />
                            <small id="nota1" runat="server" class="form-text text-muted">Formatos aceptados: .png, .jpeg, .jpg. Máximo 2mb</small>
                            <p id="nota2" runat="server" class="form-text " style="color: red">NOTA: La imagen original será introducida si no selecciona una nueva imagen</p>
                        </div>

                        
                        <br />
                        <br />

                        

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="enviar_btn" runat="server" type="button" class="btn btn-success" Text="Enviar" OnClick="Enviar_Click" />
                            &nbsp;
                            <asp:Button ID="regresar_btn" runat="server" type="button" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar_Click" formnovalidate/>
                        </div>

                        <script>
                            window.onload = function () {
                                if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=nota2.ClientID%>').hide();
                                    $('#<%=titulo_h.ClientID%>').text("Crear Evento");
                                    $('#<%=enviar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Evento");
                                    $('#<%=enviar_btn.ClientID%>').attr('value', 'Modificar');
                                }
                            };

                            $('#<%=img_fld.ClientID%>').change(function () {
                                $('#<%=nota2.ClientID%>').hide();
                            });

                            var myTour = {
                                id: "myTour",
                                steps: [
                                    {
                                        title: "Formulario de evento",
                                        content: "En esta sección puedes ya sea crear o modificar un evento (dependiendo de la opción que escogistes)",
                                        target: "#<%=formulario.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                    },
                                    {
                                        title: "Nombre",
                                        content: "Aquí deberás introducir el nombre del evento (no más de 50 carácteres)",
                                        target: "#<%=titulo_txt.ClientID%>",
                                        placement: "right",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Descripción",
                                        content: "Aquí podemos ingresar la descripción del evento a realizarse, por ejemplo las personas que participarán",
                                        target: "#<%=descripcion_txt.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Fecha",
                                        content: "Aquí podemos añadir la fecha en la que se celebrará el evento",
                                        target: "#<%=fecha_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Hora",
                                        content: "Aquí podemos añadir la fecha en la que se celebrará el evento",
                                        target: "#<%=hora_txt.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                            {
                                title: "Imagen",
                                content: "Aquí podremos seleccionar una imagen para el evento. Si estas modificando y ya se tenía una imagen, si modificas sin cambiar este campo se mantendrá la imagen original",
                                target: "#<%=img_fld.ClientID%>",
                                placement: "bottom",
                                showCloseButton: true,
                                showPrevButton: true,
                                    },
                            {
                                title: "Confirmar",
                                content: "Una vez llenes todos los campos, pulsa este botón para hacer surtir efecto la operación que quieres realizar (modificar o crear)",
                                target: "#<%=enviar_btn.ClientID%>",
                                placement: "top",
                                showCloseButton: true,
                                showPrevButton: true,
                            },
                            {
                                title: "Regresar",
                                content: "Pulsa este botón si quieres ir a la pantalla anterior si te arrepientes",
                                        target: "#<%=regresar_btn.ClientID%>",
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
