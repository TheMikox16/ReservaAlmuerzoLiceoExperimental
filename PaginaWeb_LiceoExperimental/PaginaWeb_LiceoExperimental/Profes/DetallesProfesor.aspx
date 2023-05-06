<%@ Page Title="" Language="C#" MasterPageFile="~/Profes/NavProfesores.Master" AutoEventWireup="true" CodeBehind="DetallesProfesor.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Profes.DetallesProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="max-width: 100%">
        <div class="row g-4" style="max-width: 150%" >
            <div class="col-md-12 " style="width: 200rem">
                <br />
                <br />
                <h3 style="text-align: center;">Detalles de Profesor</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 20% 20%; width: 300rem;">

                        
                        <ContentTemplate>

                    <div class="row g-2">

                        <div class="col-sm-5">

                            <img id="img_fld" runat="server" src="" style="width: 100%; height: 100%; border-radius: 10px; padding: 10px;"/>
                            
                        </div>

                        
                        

                        <div class="col-sm-7">
                            <label id="nombre_lbl" runat="server" class="form-label control-label col-sm-12" style="color: gray; border-radius: 10px; padding: 15px;"></label> 
                            <label id="descripcion_lbl" runat="server" class="form-label control-label col-sm-12" style="color: gray; border-radius: 10px; padding: 15px;"></label>
                            <label id="correo_lbl" runat="server" class="form-label control-label col-sm-12" style="color: gray; border-radius: 10px; padding: 15px;"></label>
                            <label id="telefono_lbl" runat="server" class="form-label control-label col-sm-12" style="color: gray; border-radius: 10px; padding: 15px;"></label>

                        </div>

                        
                        <p align="right">
                             <asp:Button ID="modificar_btn" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Regresar_Click"  />
                        </p>
                        
                    </div>

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
                    title: "Detalles del profesor",
                    content: "En esta sección puede visualizar la información del profesor que se haya seleccionado",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Nombre del profesor",
                    content: "Aquí podemos ver el nombre del profesor",
                    target: "#<%=nombre_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Descripción del profesor",
                    content: "Se puede visualiza la información que la institución quiera mostrar del profesor",
                    target: "#<%=descripcion_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Correo Electrónico",
                    content: "Se puede visualizar la dirección de correo eletrónico que el profesor quiso proporcionar",
                    target: "#<%=correo_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Número de teléfono",
                    content: "En caso del profesor querer proporcionar este método de comunicación se veria reflejado en este apartado",
                    target: "#<%=telefono_lbl.ClientID%>",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Regresar",
                    content: "En caso de querer regresar al apartado anterior se presiona este botón",
                    target: "#<%=modificar_btn.ClientID%>",
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
