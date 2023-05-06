<%@ Page Title="" Language="C#" MasterPageFile="~/Usuarios/NavUsuarios.Master" AutoEventWireup="true" CodeBehind="Becas.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Usuarios.Becas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Vista para cambiar las condiciones de beca d los estudiantes -->
    
    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Lista de Estudiantes</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 200rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-6">

                            <input type="text" runat="server" class="form-control" id="buscar_txt" placeholder="Buscar nombre estudiante" maxlength="150" />
                            <br />
                        </div>

                        

                        <div class="col-sm-6">
                            <asp:Button ID="buscar_btn" type="button" runat="server" class="btn btn-info" Text="Buscar" OnClick="Buscar_Click" />
                            <asp:Button ID="cancelar_btn" type="button" runat="server" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar_Click" formnovalidate />
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


                            </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>
        </div>
         
    </div>

    <br />
    <br />

    <script>
         var myTour = {
             id: "myTour",
             steps: [
                 {
                     title: "Lista de Administración de becas",
                     content: "En esta sección puedes administrar a los estudiantes para cambiar su condición de beca",
                     target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Filtro de búsqueda",
                    content: "Aquí podemos filtrar la tabla de las estudiantes por el nombre del estudiante y así hacer más fácil su localización",
                    target: "#<%=buscar_txt.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Cambio de estado de beca",
                    content: "Si queremos cambiar la beca de un estudiante (de no-becado a becado y viceversa) debemos presionar el botón de cambiar de dicho estudiante",
                    target: "#<%=Help.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Regresar",
                    content: "Volver a la pantalla anterior",
                    target: "#<%=regresar_btn.ClientID%>",
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

</asp:Content>
