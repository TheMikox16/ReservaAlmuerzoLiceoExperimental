<%@ Page Title="" Language="C#" MasterPageFile="~/Profes/NavProfesores.Master" AutoEventWireup="true" CodeBehind="FormularioSeccion.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Profes.FormularioSeccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Registro de Sección</h3>
                <br />
                



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 50rem;">

                    <div class="row g-2">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Lbl_Error" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <!-- Nombre de Sección -->
                        <div class="col-sm-4">
                            <label for="name_txt" class="form-label control-label">Nombre de Sección:</label>
                            <input type="text" runat="server" class="form-control" id="nombre_txt" placeholder="Introduce sigla de sección" required="required" minlength="3" maxlength="50" pattern="\d{1,2}-\d{1,2}" aria-required/>
                            <small id="nota" runat="server" class="form-text text-muted">Formato: XX-XX. Ej: 9-1, 11-10, 11-2, 9-10</small>
                        </div>

                        <!-- Profesor -->
                        <div class="col-sm-4">
                            <label for="id_opt" runat="server" class="form-label" id="Label2">Profesor Asignado:</label>
                            <select class="form-control form-select" runat="server" id="profesor_opt">
                                <option value="1">No Asignado</option>
                            </select>
                        </div>

                        

                        <div class="d-flex h-100 align-items-center justify-content-center">
                            <br />
                            <asp:Button ID="insertar_btn" runat="server" type="button" class="btn btn-success" Text="Aceptar" onClick="Enviar_Click"/>
                            &nbsp;
                            <asp:Button ID="cancelar_btn" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Cancelar_Click"  formnovalidate/>
                            &nbsp;
                        </div>

                        <script>
                            window.onload = function () {
                                if (<%=Session["insertar"]+""%> == "1") {
                                    $('#<%=titulo_h.ClientID%>').text("Crear Sección");
                                    $('#<%=insertar_btn.ClientID%>').attr('value', 'Crear');
                                } else {
                                    $('#<%=titulo_h.ClientID%>').text("Modificar Sección");
                                    $('#<%=insertar_btn.ClientID%>').attr('value', 'Modificar');
                                }
                            };


                            window.addEventListener('load', function () {
                                var i = <%=Session["SPId"]%>+"";
                                if (i != null && i != "") {
                                    $('#<%=profesor_opt.ClientID%>').val("" + i);
                                }
                            });

                            var myTour = {
                                id: "myTour",
                                steps: [
                                    {
                                        title: "Formulario de secciones",
                                        content: "En esta sección puedes administrar las secciones de la institución de la manera que sea más comoda para el usuario",
                                        target: "#<%=formulario.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                    },
                                    {
                                        title: "Número de la seccion",
                                        content: "En este espacio se ingresa una sección que tiene que seguir el formato indicado en la nota(Formato: XX-XX. Ej: 9-1, 11-10, 11-2, 9-10)",
                                        target: "#<%=nombre_txt.ClientID%>",
                                        placement: "top",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Botón de ingresar profesor",
                                        content: "Este botón carga todos lo profesores que esten registrados en la base de datos, por lo que se puede ingresar de una manera sencilla",
                                        target: "#<%=profesor_opt.ClientID%>",
                                       placement: "bottom",
                                       showCloseButton: true,
                                       showPrevButton: true,
                                   },
                                   {
                                       title: "Botón de crear o modificar",
                                       content: "Este botón crea la sección con el profesor asignado de ser el caso, en caso de estarse modificando se realizan los cambios hechos por el usuario y se mantienen los datos anteriores",
                                       target: "#<%=insertar_btn.ClientID%>",
                                        placement: "bottom",
                                        showCloseButton: true,
                                        showPrevButton: true,
                                    },
                                    {
                                        title: "Botón de regresar",
                                        content: "Este botón abre permite al usuario volver al apartado anterior sin realizar ningún cambio en la sección",
                                        target: "#<%=cancelar_btn.ClientID%>",
                                        placement: "bottom",
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
    <br /><br />
    <br /><br />
    <br />

</asp:Content>
