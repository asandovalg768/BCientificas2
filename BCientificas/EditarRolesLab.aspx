<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EditarRolesLab.aspx.cs" Inherits="BCientificas.Formulario_web110" %>
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
            <h3 dir="ltr">Role</h3>
            <div>
                Code:
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div>
                Name:
                <asp:TextBox ID="txtNombreRol" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbRoles" runat="server" Height="105px" Width="169px"></asp:ListBox>
                <br />
            </div>
            
                <br />
                Description: <asp:TextBox ID="txtDescripcion" runat="server" Width="322px"></asp:TextBox>
                <br />
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Delete" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar0" runat="server" Text="Update" />
          



        </div>
</asp:Content>
