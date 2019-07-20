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
<h3 class="auto-style7">Informacion de Consecutivo</h3>
<div class="auto-style3">
    <asp:Label ID="lblDescripcion" runat="server" class="col-md-4 control-label"  Text="Descripcion"></asp:Label>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:DropDownList ID="ddlDescripcion" runat="server" OnSelectedIndexChanged="ddlDescripcion_SelectedIndexChanged" Width="124px"></asp:DropDownList>
  <div class="col-md-4">
  </div>
</div>
<div class="auto-style4">
    <label class="col-md-4 control-label" for="lblConsecutivo">
    Consecutivo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="lblConsecutivo" name="lblConsecutivo" type="text" placeholder="" class="form-control input-md"><br />
    </label>
&nbsp;<div class="col-md-2">
&nbsp;</div>
</div>
    <div class="auto-style5">
   <asp:Label ID="lblPoseePrefijo" runat="server" Text="Posee Prefijo"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkPoseePrefijo" runat="server" Text=" " />
  <div class="col-md-1">
    
  </div>
</div>

<!-- Text input-->
<div class="auto-style6">
  <label class="col-md-4 control-label" for="lblPrefijo">Prefijo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <input id="lblPrefijo" name="lblPrefijo" type="text" placeholder="" class="form-control input-md"></label>  
  <div class="col-md-2">
  &nbsp;</div>
</div>

<!-- Appended checkbox -->
<div class="form-group">
  <label class="col-md-4 control-label" for="lblPoseeRango">Posee Rango</label><span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;     
          <input type="checkbox"><br />
      </span>
    &nbsp;<div class="col-md-1">
    <div class="auto-style2">
        Rango Inicial&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input id="lblPoseeRango" name="lblPoseeRango" class="form-control" type="text" placeholder="">
	        <span class="input-group-addon">     
          &nbsp;<br />
        <br />
        Rango Final&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input id="lblPoseeRango0" name="lblPoseeRango0" class="form-control" type="text" placeholder=""><br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aceptar" Width="82px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Borrar" Width="87px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Cerrar" Width="94px" />
        c</span></div>
    
  </div>

</fieldset>

        </div>
</asp:Content>
