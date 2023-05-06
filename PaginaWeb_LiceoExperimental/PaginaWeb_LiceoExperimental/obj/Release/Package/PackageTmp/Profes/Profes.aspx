<%@ Page Title="" Language="C#" MasterPageFile="~/Profes/NavProfesores.Master" AutoEventWireup="true" CodeBehind="Profes.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Profes.Profes1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%">
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Profesores</h3>
                <br />

                <style>
                    .card {
                        box-sizing: content-box;
                        margin-left: auto;
                        border: 2px solid #000000;
                        padding: 5px;
                        width: 100%;
                        max-width: 70%;
                        padding: 15px;
                        margin: auto;
                        background: #EFEFEF left;
                        background-size: 40% 40%;
                        background-repeat: no-repeat;
                        background-origin: content-box;
                    }
}
                </style>

                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 40% 40%; width: 250rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">

                        <ContentTemplate>

                            <div class="row ">

                                    

                                <div class="col-sm-6">

                                    <h3 style="text-align: center;">Todos los Profesores</h3>
                                    
                                    <br />
                                    <div class="row col-12" >

                                        <div class="col-sm-9">

                                            <input type="text" runat="server" class="form-control" id="buscar1_txt" placeholder="Buscar nombre de profesor" maxlength="150" />
                                            
                                        </div>


                                        <div class="col-sm-2">
                                            <asp:Button ID="buscar1_btn" type="button" runat="server" class="btn btn-info" Text="Buscar" OnClick="Buscar1_Click" formnovalidate />
                                            <asp:Button ID="cancelar1_btn" type="button" runat="server" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar1_Click" formnovalidate />
                                        </div>

                                    </div>
                                

                                  
                                    <!-- Tabla Profesores -->
                                    <div class="col-sm-12" style="overflow-x: auto">
                                        <div class="col-12">
                                            <small id="Help" class="form-text text-muted">Si estás en móvil, deslice para mostrar más contenido</small>
                                        </div>
                                        <table id="dtBasicExample" class="table table-striped table-bordered" style="background-color: white">
                                             <%= DataGridCreation1()%>
                                        </table>
                                        <asp:Button ID="admin_btn" type="button" runat="server" class="btn btn-success" Text="Administrar" OnClick="Administrar_Click" formnovalidate />
                                    </div>
                                    
                                    <br />
                                </div>

                                

                                <div class="col-sm-6">
                                     <h3 style="text-align: center;">Secciones</h3>
                                     
                                     <br />
                                    
                                    <div class="row col-12">
                                        <div class="col-sm-9">

                                            <input type="text" runat="server" class="form-control" id="buscar2_txt" placeholder="Buscar sigla de sección" maxlength="5" />
                                            
                                        </div>

                                        <div class="col-sm-2">
                                            <asp:Button ID="buscar2_btn" type="button" runat="server" class="btn btn-info" Text="Buscar" OnClick="Buscar2_Click" formnovalidate />
                                            <asp:Button ID="cancelar2_btn" type="button" runat="server" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar2_Click" formnovalidate />
                                        </div>
                                    
                                    </div>

                                    
                                    <!-- Tabla Secciones -->
                                    <div class="col-sm-12" style="overflow-x: auto">
                                        <div class="col-12">
                                            <small id="Help" class="form-text text-muted">Si estás en móvil, deslice para mostrar más contenido</small>
                                        </div>
                                        <table id="dtBasicExample" class="table table-striped table-bordered" style="background-color: white">
                                             <%= DataGridCreation2()%>
                                        </table>
                                        
                                    </div>
                                    <asp:Button ID="admin_btn2" type="button" runat="server" class="btn btn-success" Text="Administrar" OnClick="Administrar2_Click" formnovalidate />
                                    
                                </div>

                                <br />

                            </div>

                            

                            

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Profesores y secciones",
                    content: "En este apartado se puede buscar un profesor ya sea por su nombre o por medio de la sección de la que sea guía.",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Buscador de profesores",
                    content: "En este espacio se puede ingresar el nombre del profesor y así realizar su busqueda",
                    target: "#<%=buscar1_txt.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de buscar profesor",
                    content: "Este botón efectua la busqueda del nombre de la noticia que se ingreso en el espacio a la par",
                    target: "#<%=buscar1_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de cancelar",
                    content: "Este botón cancela la busqueda realizada",
                    target: "#<%=cancelar1_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de administrar profesores",
                    content: "Al presionar este botón permite ingresar al apartado donde se pueden adminitrar todos los profesores, ya sea eliminarlos, modificarlos o ingresar nuevos profesores",
                    target: "#<%=admin_btn.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Buscador de secciones",
                    content: "En este espacio se puede ingresar el número de sección y así realizar su busqueda",
                    target: "#<%=buscar2_txt.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de buscar profesor",
                    content: "Este botón efectua la busqueda del número de seccion de la sección que se ingreso en el espacio a la par",
                    target: "#<%=buscar2_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de cancelar",
                    content: "Este botón cancela la busqueda realizada",
                    target: "#<%=cancelar2_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de administrar profesores",
                    content: "Al presionar este botón permite ingresar al apartado donde se pueden adminitrar todos las secciones, ya sea eliminarlas, modificarlas o ingresar nuevas secciones, además de asignarles un profesor",
                    target: "#<%=admin_btn2.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                }
                
            ]

        };

        $(document).on("click", "a[name='guia']", function (e) {
            hopscotch.startTour(myTour);
        });


    </script>
</asp:Content>
