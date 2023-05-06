<%@ Page Title="" Language="C#" MasterPageFile="~/Usuarios/NavUsuarios.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Usuarios.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Lista de Usuarios</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 200rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-6">

                            <input type="text" runat="server" class="form-control" id="buscar_txt" placeholder="Buscar por correo electrónico" maxlength="100" />
                            <br />
                        </div>

                        

                        <div class="col-sm-6">
                            <asp:Button ID="buscar_btn" type="button" runat="server" class="btn btn-info" Text="Buscar" OnClick="Buscar_Click" />
                            <asp:Button ID="cancelar_btn" type="button" runat="server" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar_Click" formnovalidate />
                            <asp:Button ID="insertar_btn" type="button" runat="server" class="btn btn-success" Text="Crear" OnClick="Crear_Click" formnovalidate />
                            <asp:Button ID="regresar_btn" type="button" runat="server" class="btn btn-dark" Text="Regresar" OnClick="Regresar_Click" formnovalidate />
                        </div>

                        <!-- Tabla -->
                        <div class="col-12" style="overflow-x: auto">
                            <small id="Help" runat="server" class="form-text text-muted">Si estás en móvil, deslice para mostrar más contenido</small>
                            <table id="dtBasicExample" class="table table-striped table-bordered" style="background-color: white">

                                <%= DataGridCreation()%>
                            </table>
                        </div>

                        
                    </div>

                            <br />
                            <br />

                            </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>
        </div>
         <br />
    </div>
    
    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Lista de usuarios",
                    content: "En esta sección pueden visualizar todos los usuarios que estan ingresados en el entorno",
                    target: "#<%=formulario.ClientID%>",
                   placement: "top",
                   showCloseButton: true,
               },
               {
                   title: "Buscador de usuarios",
                   content: "En este espacio se puede ingresar el nombre del usuario y así realizar su busqueda",
                   target: "#<%=buscar_txt.ClientID%>",
                   placement: "top",
                   showCloseButton: true,
                   showPrevButton: true,
               },
               {
                   title: "Botón de buscar",
                   content: "Este botón efectua la busqueda del nombre del usuario que se ingreso en el espacio a la par",
                   target: "#<%=buscar_btn.ClientID%>",
                   placement: "bottom",
                   showCloseButton: true,
                   showPrevButton: true,
               },
               {
                   title: "Botón de cancelar",
                   content: "Este botón cancela la busqueda anterior que se haya realizado",
                   target: "#<%=cancelar_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de crear",
                    content: "Este botón abre un apartado el cual permite ingresar un nuevo usuario por parte de la institución",
                    target: "#<%=insertar_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Botón de regresar",
                    content: "Este botón regresa al usuario al apartado anterior a este",
                    target: "#<%=regresar_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Modificar o eliminar usuario",
                    content: "En caso de querer realizar más acciones con los usuarios, se puede presionar el botón de modificar la noticia y el de eliminarla",
                    target: "#<%=Help.ClientID%>",
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

</asp:Content>
