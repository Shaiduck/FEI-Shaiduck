<%@ Page Title="Formulario de Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="ProyectoEstudiantesWeb.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0px" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="idNum" runat="server" Text="ID"/>
            </td>
            <td>
                <asp:TextBox ID="id" runat="server" Width="200"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="nom" runat="server" Text="Nombre"/>
            </td>
            <td>
                <asp:TextBox ID="Nombre" runat="server" Width="200"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ApPat" runat="server" Text="Apellido Paterno"/>
            </td>
            <td>
                <asp:TextBox ID="ApPaterno" runat="server" Width="200"/>
            </td>
            <td>
                <asp:Button ID="Add" Text="Agregar" runat="server" width="100" 
                    onclick="Add_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ApMat" runat="server" Text="Apellido Materno"/>
            </td>
            <td>
                <asp:TextBox ID="ApMaterno" runat="server" Width="200"/>
            </td>
            <td>
                <asp:Button ID="Eliminar" Text="Eliminar" runat="server" width="100" 
                    onclick="Eliminar_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Mat" runat="server" Text="Matrícula"/>
            </td>
            <td>
                <asp:TextBox ID="Matricula" runat="server" Width="200"/>
            </td>
            <td>
                <asp:Button ID="Buscar" Text="Buscar" runat="server" width="100" 
                    onclick="Buscar_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Prom" runat="server" Text="Promedio"/>
            </td>
            <td>
                <asp:TextBox ID="Promedio" runat="server" Width="200"/>
            </td>
        </tr>
    </table>
</asp:Content>
