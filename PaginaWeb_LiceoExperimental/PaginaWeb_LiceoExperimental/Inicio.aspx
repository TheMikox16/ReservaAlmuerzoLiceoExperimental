<%@ Page Title="" Language="C#" MasterPageFile="~/NavInicio.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     

    <div class="container">
        <div class="row g-4">
            <div class="col-md-12 col-lg-12">
                <br />
                <br />
                <h3 id="titulo" runat="server" style="text-align: center;">Inicio</h3>
                <br />



                <form id="formulario" class="form-horizontal card" runat="server" style="background-size: 10% 10%; width: 40rem;">

                    <div class="row g-2 d-flex justify-content-center">

                        <div class="form-group">
                            <asp:Label class="control-label col-sm-8" ID="Label1" runat="server" Text="" ForeColor="DarkBlue"></asp:Label>
                        </div>

                        <div class="col-sm-3 image-with-text" align="center">
                            <a href="Eventos/Eventos.aspx" style="border: 0; background-color: transparent">
                                <img src="Imagenes/Eventos.png" name="partida_img" style="width: 120px; height: 120px" className="center" alt="" />
                                <br/>
                                <p textAlign="center" >Eventos</p>
                            </a>
                        </div>

                        <div class="col-sm-3 image-with-text" align="center">
                            <a href="Noticias/Noticias.aspx" style="border: 0; background-color: transparent">
                                <img src="Imagenes/Noticias.png" name="partida_img" style="width: 120px; height: 120px" className="center" alt="" />
                                <br/>
                                <p textAlign="center" >Noticias</p>
                            </a>
                        </div>

                        <div class="col-sm-3 image-with-text" align="center">
                            <a href="Profes/Profes.aspx" hrefstyle="border: 0; background-color: transparent">
                                <img src="Imagenes/Profesor.png" name="partida_img" style="width: 120px; height: 120px" className="center" alt="" />
                                <br/>
                                <p textAlign="center" >Profesores</p>
                            </a>
                        </div>

                        <div class="col-sm-3 image-with-text" align="center">
                            <a id="almuerzo_b" runat="server" hrefstyle="border: 0; background-color: transparent">
                                <img src="Imagenes/Almuerzos.png" name="partida_img" style="width: 120px; height: 120px" className="center" alt="" />
                                <br/>
                                <p textAlign="center" >Almuerzo</p>
                            </a>
                        </div>

                        <div id="usuario_img" runat="server" class="col-sm-3 image-with-text" align="center">
                            <a href="Usuarios/PaginaInicial.aspx" style="border: 0; background-color: transparent">
                                <img src="Imagenes/Usuarios.png" name="partida_img" style="width: 120px; height: 120px" className="center" alt="" />
                                <br/>
                                <p textAlign="center">Usuarios</p>
                            </a>
                        </div>

                        <div class="col-12">
                            <p>¡Bienvenido!</p>
                            <p>
                                Esta es la página de inicio del portal web del Liceo Experimental Bilingüe de Grecia
                            </p>
                            <p>
                                Elige la sección que mas te convenga usar el día de hoy o usa el botón guía en cualquier momento para ver las funcionalidades
                            </p>
                        </div>

                        
                    </div>
                </form>

            </div>
        </div>
     </div>

    <script>
        var myTour = {
            id: "myTour",
            steps: [
                {
                    title: "Bienvenido",
                    content: "Vamos a dar un pequeño recorrido a las opciones de la página web",
                    target: "#<%=formulario.ClientID%>",
                    placement: "top",
                    showCloseButton: true,
                },
                {
                    title: "Eventos",
                    content: "En eventos podrás encontrar todas las actividades que se realizaran recientemente en la institución",
                    target: "#eventos_a",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Noticias",
                    content: "En noticias podrás encontrar novedades sobre la institución asi como circulares importantes",
                    target: "#noticias_a",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Profesores",
                    content: "En este apartado podrás consultar información de los profesores incluyendo a los profesores guias de cada sección",
                    target: "#profesores_a",
                    placement: "bottom",
                    showCloseButton: true,
                    showPrevButton: true,
                },
                {
                    title: "Almuerzo",
                    content: "Podrás consultar el almuerzo de hoy o mañana (dependiendo de la hora). Recuerda que los tiempos para reservar el amuerzo de un determinado dia es de 4pm del día anterior a 9pm del día a almorzar",
                    target: "#almuerzo_a",
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
