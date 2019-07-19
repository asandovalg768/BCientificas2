<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="BCientificas.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 541px;
            height: 413px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div ="divInfo" class="auto-style2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Crear Usuario<br />
        
            <br />
&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;
        
        <asp:TextBox ID="txtCodigo" runat="server" ForeColor="Silver" ReadOnly="True">Codigo</asp:TextBox>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server" ForeColor="Silver">Nombre</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt1Apellido" runat="server" ForeColor="Silver">1er Apellido</asp:TextBox>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt2Apellido" runat="server" ForeColor="Silver">2ndo Apellido</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTel" runat="server" ForeColor="Silver">Telefono</asp:TextBox>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNickName" runat="server" ForeColor="Silver">LogIn (nickname)</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRol" runat="server" ForeColor="Silver">Tipo de Rol</asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="140px" />
        <br />
        <br />
            </div>
</asp:Content>
