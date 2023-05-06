<%@ Page Title="" Language="C#" MasterPageFile="~/Eventos/NavEventos.Master" AutoEventWireup="true" CodeBehind="DetallesEvento.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Eventos.DetallesEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%">
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 id="titulo_h" runat="server" style="text-align: center;">Información de Evento</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 200rem;">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">

                        <ContentTemplate>

                            <div class="row g-2">

                                <div class="col-sm-12 d-flex justify-content-center" style="display:block; width: 100%; width: 100%; max-height: 400px;">
                                    <img id="imgn_fld" runat="server" src="" style="display:block; width: 80%; height: 100%;" />
                                </div>
                                <hr>
                                
                                <div class="col-sm-12">
                                    <label id="titulo_lbl" runat="server" class="form-label control-label" style="font-size: 30px;"></label> 
                                </div>

                                <div class="col-sm-12">
                                    <label id="fecha_lbl" runat="server" class="form-label control-label" style="color: blue;"> </label>
                                </div>

                                <div class="col-sm-12">
                                    <label id="descripcion_lbl" runat="server" class="form-label control-label" style="background-color: white; color: gray; border-radius: 10px; padding: 15px;"> </label>
                                </div>

                                <div class="col-sm-12 h-100 d-flex align-items-center justify-content-center">
                                    <asp:Button ID="regresar_btn" type="button" runat="server" class="btn btn-secondary" Text="Regresar" OnClick="Regresar_Click" formnovalidate />
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
                    title: "Detalles de un evento",
                    content: "En esta sección puedes observar la información de este evento. Vamos a abarcar cada acción",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showPrevButton: true,
                    showCloseButton: true,
                },
                {
                    title: "Descripción del evento",
                    content: "Aquí podemos ver la descripcion del evento que haz seleccionado",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Fecha del evento",
                    content: "Se muestra la fecha en la que realizara el evento",
                    target: "#<%=fecha_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Regresar",
                    content: "Pulsa este botón si quieres ir a la pantalla anterior",
                    target: "#<%=regresar_btn.ClientID%>" ,
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
