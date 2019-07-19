<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="BCientificas.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 124px;
            width: 390px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h3>Roles</h3>
            <div>
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True">Codigo</asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtNombreRol" runat="server">Nombre</asp:TextBox>
                <asp:ListBox ID="lstbRoles" runat="server" Height="48px" Width="169px"></asp:ListBox>
            </div>
            <div>
                <asp:TextBox ID="txtDescripcion" runat="server">Descripcion</asp:TextBox>
            </div>
            <div class="auto-style2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
            </div>



        </div>
</asp:Content>
