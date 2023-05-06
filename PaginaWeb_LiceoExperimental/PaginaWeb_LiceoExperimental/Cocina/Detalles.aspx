<%@ Page Title="" Language="C#" MasterPageFile="~/Cocina/NavCocina.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Vista para la reserva de almuerzos para usuarios que no tengan permisos -->

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 id="titulo" style="text-align: center;">Detalles de Almuerzo</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 300rem;">

                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-5">

                            <img id="imgn_fld" runat="server" src="" style="width: 100%; height: 100%; border-radius: 10px; padding: 10px;"/>
                            
                        </div>

                        
                        

                        <div class="col-sm-7">
                            <label id="titulo_lbl" runat="server" class="form-label control-label col-sm-12" style="font-size: 30px;">Titulo Platillo</label> 
                            <label id="descripcion_lbl" runat="server" class="form-label control-label col-sm-12" style="background-color: white; color: gray; border-radius: 10px; padding: 15px;">Esta es una descripcion detallada y muy interesante del almuerzo que debe de interesarle al usuario. </label>
                            <p align="right">
                                <asp:Button ID="modificar_btn" runat="server" type="button" class="btn btn-warning" Text="Modificar" OnClick="Modificar_Click"  />
                                <asp:Button ID="eliminar_btn" OnClientClick="return confirm('¿Seguro/a que quieres borrar este platillo?');" runat="server" type="button" class="btn btn-danger" Text="Eliminar" OnClick="Eliminar_Click"  />
                                <asp:Button ID="seleccion_btn" OnClientClick="return confirm('¿Seguro/a que quieres seleccionar este platillo como almuerzo del dia?');" runat="server" type="button" class="btn btn-primary" Text="Seleccionar" OnClick="Seleccion_Click"  />
                                <asp:Button ID="cancelar_btn" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Cancelar_Click"  />
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

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Detalles de un platillo",
                    content: "En esta sección puedes administrar muchos aspectos de este platillo. Vamos a abarcar cada acción",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Nombre de platillo",
                    content: "Aquí podemos ver el nombre del almuerzo que haz seleccionado",
                    target: "#<%=titulo_lbl.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Descripción de platillo",
                    content: "Aquí podemos ver la descripcion del almuerzo que haz seleccionado",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Modificar",
                    content: "Si queremos modificar los aspectos anteriores del platillo y más (como la imagen) podemos hacerlo en el boton modificar",
                    target: "#<%=modificar_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Eliminar",
                    content: "Si no queremos tener mas registros de este almuerzo, podemos eliminarlo dando click aquí. Nos pedira una confirmación pero después de eso se eliminará el almuerzo",
                    target: "#<%=eliminar_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Plato del día",
                    content: "¿Ya sabes que se va a almorzar hoy o mañana? Selecciona el almuerzo. Si ya hay un almuerzo del día esto se te indicará. Recuerda fijarte si el almuerzo esta o no disponible",
                    target: "#<%=seleccion_btn.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Regresar",
                    content: "Pulsa este botón si quieres ir a la pantalla anterior",
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

</asp:Content>
