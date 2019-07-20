<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Descargas.aspx.cs" Inherits="BCientificas.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 479px;
            height: 212px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
<fieldset>
<h3>Downloads</h3>

<div class="form-group">
  <div class="col-md-4">
      <div class="form-group">
  <label class="col-md-4 control-label" for="txtFechaError">Date</label>  
  <div class="col-md-4">
      <asp:TextBox ID="txtFechaError" name="txtFechaError" type="date" placeholder="" class="form-control input-md" runat="server"></asp:TextBox>
       
  </div>
           <br/>
</div>
      <div class="error-desc">
        
                       
                                <asp:ListBox ID="lstbDescargas" runat="server" Width="135px" >
                    </asp:ListBox>
                            &nbsp;&nbsp;<asp:TextBox class="form-control" ID="txaDescripcionError" name="txaDescripcionError" runat="server" Height="63px" Width="186px" OnTextChanged="txaDescripcionError_TextChanged">Error Description</asp:TextBox>               
                                &nbsp;<div class="form-group">
                                    &nbsp;</div>
         
 
              
              
          </div>
  </div>
</div>
    <div />
    </fieldset>
    </div>
</asp:Content>
