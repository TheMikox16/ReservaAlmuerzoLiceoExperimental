<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirReserva.aspx.cs" Inherits="PaginaWeb_LiceoExperimental.Cocina.ImprimirReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script" rel="stylesheet">
    <link href="../CSS/Estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="col-12" style="overflow-x: auto">
                            <small id="Help" class="form-text text-muted">Si estás en móvil, deslice para mostrar más contenido</small>
                            <table id="dtBasicExample" class="table table-striped table-bordered" style="background-color: white">

                                <%= DataGridCreation()%>
                            </table>
                        </div>

            <asp:Button ID="imprimir_btn" runat="server" type="button" class="btn btn-success" Text="Imprimir" OnClientClick="javascript:window.print();" />
            <asp:Button ID="Button1" runat="server" type="button" class="btn btn-secondary" Text="Regresar" OnClick="Regresar_Click"/>
        </div>
    </form>
</body>
</html>
