<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.Reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Vista para la reserva de almuerzos para usuarios que no tengan permisos -->

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Almuerzo del día</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 300rem;">

                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-5">

                            <img id="img_fld" runat="server" src="" style="width: 100%; height: 100%; border-radius: 10px; padding: 10px;"/>
                            
                        </div>

                        
                        

                        <div class="col-sm-7">
                            <label id="titulo_lbl" runat="server" class="form-label control-label col-sm-12" style="font-size: 30px;"></label> 
                            <label id="descripcion_lbl" runat="server" class="form-label control-label col-sm-12" style="background-color: white; color: gray; border-radius: 10px; padding: 15px;"></label>
                            <p align="right">
                                <asp:Button ID="reservar_btn" runat="server" type="button" class="btn btn-success" Text="Reservar" OnClick="Reservar_Click"  />
                            </p>
                        </div>

                        

                        
                    </div>

                </form>

            </div>
        </div>
     </div>
    <br />
    <br />
    <br />
    <br />
    <br />

    <script>
         var myTour = {
             id: "myTour",
             steps: [
                 {
                     title: "Reserva",
                     content: "En esta pantalla puedes reservar tu almuerzo si es que ya se ha seleccionado un almuerzo para el día de hoy o mañana",
                     target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "No Becados y Profesores",
                    content: "Si eres un estudiante y no tienes beca o eres un profesor y quieres un almuerzo, debes comunicarte con el/la encargada de la gestión de pagos de almuerzo para que te habilite tu reserva en el sistema. Si quieres confirmar tu reserva una vez procesada, haz click en el botón de reserva y un mensaje de confirmará esto",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Becados",
                    content: "Si eres un estudiante becado, simplemente da click al botón de reserva y tu solicitud se procesará automáticamente. Recuerda que solo puedes reservar una vez y este proceso no puede deshacerse",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                 },
                 {
                     title: "Sobre la seleccion de almuerzo",
                     content: "En el momento, el almuerzo que hará la unidad académica decidido aún. Esto se te indicará si es el caso. Si esto ocurre, por favor intenta reservar más tarde",
                     target: "#<%=titulo_lbl.ClientID%>",
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
