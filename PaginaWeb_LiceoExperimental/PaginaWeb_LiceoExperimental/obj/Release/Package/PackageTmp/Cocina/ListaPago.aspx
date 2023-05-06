<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="ListaPago.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.ListaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Lista de Reservas de Pago</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 200rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-6">

                            <input type="text" runat="server" class="form-control" id="buscar_txt" placeholder="Introducir parámetro de búsqueda" maxlength="100" required/>
                            <br />
                        </div>

                        

                        <div class="col-sm-6">
                            <asp:Button ID="buscar_btn" type="button" runat="server" class="btn btn-info" Text="Buscar" OnClick="Buscar_Click" />
                            <asp:Button ID="cancelar_btn" type="button" runat="server" class="btn btn-secondary" Text="Cancelar" OnClick="Cancelar_Click" formnovalidate />
                            <asp:Button ID="regresar_btn" type="button" runat="server" class="btn btn-dark" Text="Regresar" OnClick="Regresar_Click" formnovalidate />
                        </div>

                        <div class="col-sm-12">
                            <input class="form-check-input" name="radios" id="rad1" for="bus_txt" runat="server" type="radio" checked/> Por Nombre
                            <input class="form-check-input" name="radios" id="rad2" for="bus_txt" runat="server" type="radio" /> Por ID
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

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Lista de Pagos",
                    content: "En esta sección puedes administrar y ver todos los profesores y estudiantes no becados a los cuales se les puede hacer una reserva del almuerzo del día.",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Filtro de búsqueda",
                    content: "Aquí podemos filtrar la tabla de los pagos con el nombre o id de un estudiante para que sea más fácil encontrar la entrada",
                    target: "#<%=buscar_txt.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Modo de búsqueda 1",
                    content: "Si queremos buscar por nombre, seleccionamos este espacio",
                    target: "#<%=rad1.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Modo de búsqueda 2",
                    content: "Si queremos buscar por identificación, seleccionamos este espacio",
                    target: "#<%=rad2.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Reservar",
                    content: "Si queremos reservar el almuerzo a un estudiante o profesor, basta con presionar el boton de reservar que se encuentra",
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

    <br />
        <br />
        <br />

</asp:Content>
