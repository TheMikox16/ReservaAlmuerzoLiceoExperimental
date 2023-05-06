<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="FormularioPlatillo.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.FormularioPlatillo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Formulario de Platillo</h3>
                <br />

                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 60rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Label1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>


                        <!-- Nombre Plato-->
                                <div class="col-sm-5">
                                    <label for="nombre_txt" runat="server" class="form-label" id="nombre_lbl">Nombre de Almuerzo:</label>
                                    <input type="text" runat="server" class="form-control" id="nombre_txt" placeholder="Introduzca nombre del platillo" required="required"  maxlength="50" />
                                </div>

                        <!-- Disponible -->
                        <div class="col-sm-2">
                            <label for="id_opt" runat="server" class="form-label" id="id_lbl">Disponible:</label>
                            <select class="form-control form-select" runat="server" id="id_opt">
                                <option>Si</option>
                                <option>No</option>
                            </select>
                        </div>


                        <!-- Imagen -->
                        <div class="col-sm-5">
                            <label for="img_fld " class="form-label" id="img_lbl" runat="server">Imagen:</label>
                            <asp:FileUpload type="file" runat="server" class=" form-control col-sm-12" id="img_fld" accept=".png,.jpg,.jpeg" />
                            <small id="nota1" runat="server" class="form-text text-muted">Formatos aceptados: .png, .jpeg, .jpg. Máximo 2mb</small>
                            <p id="nota2" runat="server" class="form-text " style="color: red">NOTA: La imagen original será introducida si no selecciona una nueva imagen</p>
                        </div>



                        <!-- Descripcion-->
                                <div class="col-sm-12">
                                    <label for="descripcion_txt" runat="server" class="form-label" id="descripcion_lbl">Descripción:</label>
                                    <textarea  runat="server" class="form-control" id="descripcion_txt" placeholder="Introduzca descripción del platillo" rows="4" required="required" maxlength="1000" />
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

                        </div>
                   </form>

                <script>
                    window.onload = function () {
                        if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=nota2.ClientID%>').hide();
                                    $('#<%=titulo_h.ClientID%>').text("Crear Platillo");
                                    $('#<%=enviar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Platillo");
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
                                title: "Formulario de platillo",
                                content: "En esta sección puedes ya sea crear o modificar un platillo (dependiendo de la opción que escogistes)",
                                target: "#<%=formulario.ClientID%>",
                                placement: "top",
                                showCloseButton: true,
                            },
                            {
                                title: "Nombre",
                                content: "Aquí deberás introducir el nombre del platillo (no más de 50 carácteres)",
                                target: "#<%=nombre_txt.ClientID%>",
                                placement: "bottom",
                                showCloseButton: true,
                                showPrevButton: true,
                            },
                            {
                                title: "Disponible",
                                content: "Aquí podemos seleccionar si un platillo esta disponible o no, asi podemos evitar que sea seleccionado como platillo del día",
                                target: "#<%=id_opt.ClientID%>",
                                placement: "bottom",
                                showCloseButton: true,
                                showPrevButton: true,
                            },
                            {
                                title: "Imagen",
                                content: "Aquí podremos seleccionar una imagen para la comida. Si estas modificando y ya se tenía una imagen, si modificas sin cambiar este campo se mantendrá la imagen original",
                                target: "#<%=img_fld.ClientID%>",
                                placement: "bottom",
                                showCloseButton: true,
                                showPrevButton: true,
                            },
                            {
                                title: "Descripcion",
                                content: "Aquí podemos añadir detalles del platillo. Por ejemplo, ingredientes, cómo esta cocinado, las porciones, descripción de la comida, etc.",
                                target: "#<%=descripcion_lbl.ClientID%>",
                                placement: "top",
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
        </div>
         
    </div>
    <br />
    <br />

</asp:Content>
