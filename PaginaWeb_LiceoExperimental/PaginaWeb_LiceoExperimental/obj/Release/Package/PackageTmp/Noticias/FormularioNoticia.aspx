<%@ Page Title="" Language="C#" MasterPageFile="~/Noticias/NavNoticias.Master" AutoEventWireup="true" CodeBehind="FormularioNoticia.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Noticias.FormularioNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Formulario de Noticia</h3>
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
                                <div class="col-sm-7">
                                    <label for="titulo_txt" runat="server" class="form-label" id="titulo_lbl">Titular de Noticia:</label>
                                    <input type="text" runat="server" class="form-control" id="titulo_txt" placeholder="Introduzca el título de la noticia" required="required" maxlength="200" />
                                </div>

                        <!-- Descripcion-->
                                <div class="col-sm-12">
                                    <label for="descripcion_txt" runat="server" class="form-label" id="descripcion_lbl">Descripción:</label>
                                    <textarea  runat="server" class="form-control" id="descripcion_txt" placeholder="Introduzca descripción de la noticia" rows="4" required="required" maxlength="3000" />
                                </div>


                        <!-- Imagen -->
                        <div class="col-sm-7">
                            <label for="img_fld " class="form-label" id="img_lbl" runat="server">Imagen:</label>
                            <asp:FileUpload type="file" runat="server" class=" form-control" id="img_fld" accept=".png,.jpg,.jpeg" />
                            <small id="nota3" runat="server" class="form-text text-muted">Formatos aceptados: .png, .jpeg, .jpg. Máximo 2mb</small>
                            <p id="nota4" runat="server" class="form-text " style="color: red">NOTA: La imagen original será introducida si no selecciona una nueva imagen</p>
                        </div>

                        <!-- Archivo -->
                        <div class="col-sm-5">
                            <label for="doc_fld " class="form-label" id="doc_lbl" runat="server">Documentación:</label>
                            <asp:FileUpload type="file" runat="server" class="form-control" ID="doc_fld" accept=".pdf" />
                            <small id="nota" runat="server" class="form-text text-muted">Formatos aceptados: PDF. Máximo 10mb</small>
                            <p id="nota2" runat="server" class="form-text " style="color: red">NOTA: El archivo original sera introducido si no selecciona un nuevo archivo</p>
                        </div>

                        
                        <script>
                            window.onload = function () {
                                if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=nota2.ClientID%>').hide();
                                    $('#<%=nota4.ClientID%>').hide();
                                    $('#<%=titulo_h.ClientID%>').text("Crear Noticia");
                                    $('#<%=enviar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Noticia");
                                    $('#<%=enviar_btn.ClientID%>').attr('value', 'Modificar');
                                }
                            };

                            $('#<%=doc_fld.ClientID%>').change(function () {
                                $('#<%=nota2.ClientID%>').hide();
                            });

                            $('#<%=img_fld.ClientID%>').change(function () {
                                $('#<%=nota4.ClientID%>').hide();
                            });

                            var myTour = {
                                id: "myTour",
                                steps: [
                                    {
                                        title: "Formulario de noticia",
                                        content: "En esta sección puedes ya sea crear o modificar una noticia (dependiendo de la opción que escogistes)",
                                        target: "#<%=formulario.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                    },
                                    {
                                        title: "Nombre",
                                        content: "Aquí deberás introducir el nombre de la noticia (no más de 50 carácteres)",
                                        target: "#<%=titulo_txt.ClientID%>",
                                        placement: "right",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Descripción",
                                        content: "Aquí podemos ingresar la descripción de la noticia a realizarse, por ejemplo las personas que participarán",
                                        target: "#<%=descripcion_txt.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Imagen",
                                        content: "Aquí podremos seleccionar una imagen para la notica. Si estas modificando y ya se tenía una imagen, si modificas sin cambiar este campo se mantendrá la imagen original",
                                        target: "#<%=img_fld.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Documento",
                                        content: "Aquí se puede añadir un documento a la noticia que se quiere publicar y sea de utilidad para la audiencia",
                                        target: "#<%=doc_fld.ClientID%>",
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
                        
                    </div>
                </form>

            </div>
        </div>
         <br />
    </div>

    <br />

</asp:Content>
