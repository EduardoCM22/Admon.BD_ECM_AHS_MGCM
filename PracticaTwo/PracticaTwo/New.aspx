<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="PracticaTwo.New" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Add new book</title>
    <link href="New.css" rel="stylesheet" />
</head>
<body style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">

    

    <h1 id="titulo">Registro de un nuevo libro</h1>

    <form id="form1" runat="server">

        <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="col-4">
            <asp:Label ID="Label1" runat="server" Text="ID" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtId" runat="server" CssClass="inputText" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label2" runat="server" Text="ISBN " CssClass="labelText"></asp:Label>

            <asp:TextBox ID="txtISBN" runat="server" CssClass="inputText" TextMode="Number" MaxLength="13"
                placeholder="10 o 13 caracteres" ></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label3" runat="server" Text="Titulo" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="inputText"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label4" runat="server" Text="Número de edición" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtEdition" runat="server" CssClass="inputText" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label5" runat="server" Text="Año de publicación" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtPublicationYear" runat="server" CssClass="inputText" TextMode="Number" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label6" runat="server" Text="Nombre de los autores" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="inputText" placeholder=""></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label7" runat="server" Text="País de publicación" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtPublicationCountry" runat="server" CssClass="inputText"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label10" runat="server" Text="Materia" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" CssClass="inputText"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label9" runat="server" Text="Carrera" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtCareer" runat="server" CssClass="inputText"></asp:TextBox>
        </div>
        <div class="col-9">
            <asp:Label ID="Label8" runat="server" Text="Sinopsis" CssClass="labelText"></asp:Label>
            <asp:TextBox ID="txtSynopsis" runat="server" CssClass="inputText" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-12">
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Añadir" CssClass="inputButton" Height="30px" Width="70px" />
            <asp:Button ID="btnBack" runat="server" OnClick="Button1_Click" Text="Regresar" CssClass="inputButton" Height="30px" Width="70px" />
        </div>
    </form>
</body>
</html>
