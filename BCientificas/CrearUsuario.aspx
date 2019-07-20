<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="BCientificas.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 596px;
            height: 652px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div ="divInfo" class="auto-style2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        
            <br />
&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;
        
            Code:&nbsp;
        
        <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgFoto" runat="server" />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;Name:&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server" style="width: 128px"></asp:TextBox>
            &nbsp;&nbsp;Last Name:&nbsp;&nbsp;
        <asp:TextBox ID="txt1Apellido" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
&nbsp;&nbsp; Second Last Name:
        <asp:TextBox ID="txt2Apellido" runat="server" OnTextChanged="txt2Apellido_TextChanged" Width="123px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Role Type:&nbsp;
        <asp:TextBox ID="txtTipoRol" runat="server" Width="103px"></asp:TextBox>
        &nbsp;&nbsp;<br />
            <br />
&nbsp;&nbsp; Phone:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTel0" runat="server" TextMode="Number"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Position:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPuesto" runat="server" Width="119px"></asp:TextBox>
            <br />
        <br />
        &nbsp;&nbsp; Nickname:
        <asp:TextBox ID="txtNickName" runat="server" Width="127px"></asp:TextBox>
&nbsp;Academic Level:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNivelAca" runat="server" Width="115px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;Password:&nbsp;&nbsp;
        <asp:TextBox ID="txtContra" runat="server" OnTextChanged="txtNickName0_TextChanged" Width="117px" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;Confirm Password:&nbsp;
        <asp:TextBox ID="txtConfContra" runat="server" Width="103px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chkCambioContra" runat="server" Text="Change Password" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" class="w3-button w3-green" Text="Save" Width="140px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgFirma" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            </div>
</asp:Content>
