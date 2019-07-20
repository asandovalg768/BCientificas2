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
    <asp:Label ID="lblDescripcion" runat="server" class="col-md-4 control-label"  Text="Description"></asp:Label>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:DropDownList ID="ddlDescripcion" runat="server" OnSelectedIndexChanged="ddlDescripcion_SelectedIndexChanged" Width="124px"></asp:DropDownList>
  <div class="col-md-4">
  </div>
</div>
<div class="auto-style4">
    <label class="col-md-4 control-label" for="lblConsecutivo">
    Consecutive&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="lblConsecutivo" name="lblConsecutivo" type="text" placeholder="" class="form-control input-md"><br />
    </label>
&nbsp;<div class="col-md-2">
&nbsp;</div>
</div>
    <div class="auto-style5">
   <asp:Label ID="lblPoseePrefijo" runat="server" Text="Does it have a prefix?"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkPoseePrefijo" runat="server" Text=" " />
  <div class="col-md-1">
    
  </div>
</div>

<!-- Text input-->
<div class="auto-style6">
  <label class="col-md-4 control-label" for="lblPrefijo">Prefix&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <input id="lblPrefijo" name="lblPrefijo" type="text" placeholder="" class="form-control input-md"></label>  
  <div class="col-md-2">
  &nbsp;</div>
</div>

<!-- Appended checkbox -->
<div class="form-group">
  <label class="col-md-4 control-label" for="lblPoseeRango">Does it have a range?</label><span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;     
          <input type="checkbox"><br />
      </span>
    &nbsp;<div class="col-md-1">
    <div class="auto-style2">
        Initial Range&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input id="lblPoseeRango" name="lblPoseeRango" class="form-control" type="text" placeholder="">
	        <span class="input-group-addon">     
          &nbsp;<br />
        <br />
        Final Range&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input id="lblPoseeRango0" name="lblPoseeRango0" class="form-control" type="text" placeholder=""><br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Accept" Width="82px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Delete" Width="87px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Close" Width="94px" />
        c</span></div>
    
  </div>

</fieldset>

        </div>
</asp:Content>
