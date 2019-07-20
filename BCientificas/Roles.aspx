<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="BCientificas.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 124px;
            width: 390px;
            margin-left: 80px;
        }
        .auto-style3 {
            width: 471px;
            height: 280px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style3">
            <h3>Roles</h3>
            <div>
                Code :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True">Code</asp:TextBox>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbRoles" runat="server" Height="48px" Width="169px"></asp:ListBox>
            </div>
            <div>
                Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNombreRol" runat="server">Name</asp:TextBox>
            </div>
            <div>
                Description:
                <asp:TextBox ID="txtDescripcion" runat="server">Description</asp:TextBox>
                <br />
            </div>
            <div class="auto-style2">
                <asp:Button ID="btnGuardar" runat="server" Text="Save" Width="91px" />
            </div>



        </div>
</asp:Content>
