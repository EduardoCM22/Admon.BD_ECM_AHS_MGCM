<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PracticaTwo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Biblioteca</title>
    <link href="default.css" rel="stylesheet" />
</head>
<body style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">

    <div>
        <h1 id="titulo">Biblioteca</h1>
    </div>

    <form id="form1" runat="server">

        <div class="addLibro">
            <asp:LinkButton id="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">Agregar libro</asp:LinkButton>
        </div>

        <div class="tabla">
            <asp:Table id="tblBooks" runat="server" CssClass="TableBooks"></asp:Table>
        </div>

    </form>

    <br />
</body>
</html>
