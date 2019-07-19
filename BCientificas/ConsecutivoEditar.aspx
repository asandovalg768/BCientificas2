<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConsecutivoEditar.aspx.cs" Inherits="BCientificas.Formulario_web111" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 492px;
            height: 214px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<fieldset>
<h3>Consecutivo</h3>
<div class="form-group">
    <asp:Label ID="lblDescripcion" runat="server" class="col-md-4 control-label"  Text="Descripcion"></asp:Label>
  <div class="col-md-4">
      <asp:DropDownList ID="ddlDescripcion" runat="server"></asp:DropDownList>
  </div>
</div>
<div class="form-group">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
  <label class="col-md-4 control-label" for="lblConsecutivo">Consecutivo</label>  
  <div class="col-md-2">
  <input id="lblConsecutivo" name="lblConsecutivo" type="text" placeholder="" class="form-control input-md">
    
  </div>
</div>
    <div class="form-group">
   <asp:Label ID="lblPoseePrefijo" runat="server" Text="Posee Prefijo"></asp:Label>
        <asp:CheckBox ID="chkPoseePrefijo" runat="server" />
  <div class="col-md-1">
    
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="lblPrefijo">Prefijo</label>  
  <div class="col-md-2">
  <input id="lblPrefijo" name="lblPrefijo" type="text" placeholder="" class="form-control input-md">
    
  </div>
</div>

<!-- Appended checkbox -->
<div class="form-group">
  <label class="col-md-4 control-label" for="lblPoseeRango">Posee Rango</label>
  <div class="col-md-1">
    <div class="auto-style2">
      <input id="lblPoseeRango" name="lblPoseeRango" class="form-control" type="text" placeholder="">
	        <span class="input-group-addon">     
          <input type="checkbox">     
      </span>
    </div>
    
  </div>

</fieldset>

        </div>
</asp:Content>
