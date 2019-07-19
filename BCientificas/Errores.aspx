<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Errores.aspx.cs" Inherits="BCientificas.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 557px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="auto-style2">
<fieldset>
<h3>Errores</h3>

<div class="form-group">
  <div class="col-md-4">
      <div class="form-group">
  <label class="col-md-4 control-label" for="txtFechaError">Fecha</label>  
  <div class="col-md-4">
      <asp:TextBox ID="txtFechaError" name="txtFechaError" type="date" placeholder="" class="form-control input-md" runat="server"></asp:TextBox>
       
  </div>
           <br/>
</div>
      <div class="error-desc">
        
                       
                                <asp:ListBox ID="lstbErrores" runat="server" Width="135px" >
                    </asp:ListBox>
                            &nbsp;&nbsp;<asp:TextBox class="form-control" ID="txaDescripcionError" name="txaDescripcionError" runat="server" Height="63px" Width="186px">Descripcion del error</asp:TextBox>               
                                &nbsp;<div class="form-group">
                                    &nbsp;</div>
         
 
              
              
          </div>
  </div>
</div>
    <div />
    </fieldset>
    </div>

</asp:Content>
