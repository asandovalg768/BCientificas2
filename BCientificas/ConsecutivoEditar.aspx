<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConsecutivoEditar.aspx.cs" Inherits="BCientificas.Formulario_web111" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 492px;
            height: 214px;
        }
        .auto-style3 {
            width: 497px;
        }
        .auto-style4 {
            width: 491px;
        }
        .auto-style5 {
            width: 496px;
        }
        .auto-style6 {
            width: 495px;
        }
        .auto-style7 {
            width: 277px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<fieldset>
<h3 class="auto-style7">Consecutive Information</h3>
<div class="auto-style3">
    <asp:Label ID="lblDescripcion1" runat="server" class="col-md-4 control-label"  Text="Description"></asp:Label>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
&nbsp;<div class="col-md-4">
  </div>
</div>
<div class="auto-style4">
    Consecutive&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtConsecutivo" runat="server"></asp:TextBox>
    <br />
&nbsp;<div class="col-md-2">
&nbsp;</div>
</div>
    <div class="auto-style5">
   <asp:Label ID="lblPoseePrefijo" runat="server" Text="Does it have a prefix?"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkPoseePrefijo" runat="server" Text=" " OnCheckedChanged="chkPoseePrefijo_CheckedChanged" />
  <div class="col-md-1">
    
  </div>
        
</div>

<!-- Text input-->
<div class="auto-style6">
    Prefix&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <label class="col-md-4 control-label" for="lblConsecutivo0">
    <asp:TextBox ID="txtPrefijo" runat="server"></asp:TextBox>
    </label>
  &nbsp;<div class="col-md-2">
  &nbsp;</div>
</div>

<!-- Appended checkbox -->
<div class="form-group">
    Does it have a range?<span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;     
          <asp:CheckBox ID="chkPoseeRango" runat="server" Text=" " OnCheckedChanged="chkPoseePrefijo_CheckedChanged" />
    <br />
      </span>
    &nbsp;<div class="col-md-1">
    <div class="auto-style2">
        Initial Range&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	        <span class="input-group-addon">     
          &nbsp;<asp:TextBox ID="txtRangoIni" runat="server"></asp:TextBox>
        <br />
        <br />
        Final Range&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRangoFin" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" class="w3-button w3-green" Text="Accept" Width="94px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" class="w3-button w3-green" Text="Delete" Width="89px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" class="w3-button w3-green" Text="Close" Width="94px" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </span></div>
    
  </div>
     </div>

</fieldset>

        </div>
</asp:Content>
