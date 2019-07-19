<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RolesEditar.aspx.cs" Inherits="BCientificas.Formulario_web110" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 461px;
            height: 274px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
            <h3>Roles</h3>
            <div>
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True">Codigo</asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtNombreRol" runat="server">Nombre</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbRoles" runat="server" Height="48px" Width="169px"></asp:ListBox>
            </div>
            <div>
                <asp:TextBox ID="txtDescripcion" runat="server">Descripcion</asp:TextBox>
                <br />
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
            &nbsp;&nbsp;&nbsp;
            </div>



        </div>
</asp:Content>
