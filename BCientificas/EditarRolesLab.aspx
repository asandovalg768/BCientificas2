<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EditarRolesLab.aspx.cs" Inherits="BCientificas.Formulario_web110" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 461px;
            height: 274px;
        }
        .auto-style3 {
            margin-left: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
            <h3 dir="ltr">Role</h3>
            <div>
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True">Code</asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtNombreRol" runat="server">Name</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbRoles" runat="server" Height="105px" Width="169px"></asp:ListBox>
                <br />
            </div>
            <div class="auto-style3">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="322px">Description</asp:TextBox>
                <br />
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Delete" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar0" runat="server" Text="Update" />
            </div>



        </div>
</asp:Content>
