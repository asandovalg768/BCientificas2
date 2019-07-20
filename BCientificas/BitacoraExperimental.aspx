<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="BitacoraExperimental.aspx.cs" Inherits="BCientificas.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 618px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="auto-style2">
            <h2>Experimental Binnacle</h2>

            <div>
                <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombreProyecto" runat="server" Text="Project name:"></asp:Label>
                            &nbsp;&nbsp;
                                </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:DropDownList ID="ddlProyectos" runat="server" Width="388px" Height="19px"></asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodigoProyecto" runat="server" Text="Project Code:"></asp:Label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCodigoProyecto" CssClass="form-control input-md" Width="388px" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                </table>
            </div>

            <div class="col-md-4">
                <table>
                        <tr>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:DropDownList ID="ddlNombreCompleto" runat="server" Width="216px" Height="19px"></asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:DropDownList ID="ddlFirma" runat="server"  Width="216px" Height="19px"></asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                </table>
            </div>
            <div>
                <asp:ImageButton ID="imgFirma" runat="server" Height="110px" />
            </div>

            <div>
                <table>
                        <tr>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:Label ID="lblNombreExp" runat="server" Text="Name of the experiment:"></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:TextBox ID="txtNombreExp" type="text" CssClass="form-control input-md" Width="198px" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:Label ID="lblFecha" runat="server" Text="Date:"></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:TextBox ID="txtFecha" type="Date" CssClass="form-control input-md" Width="108px" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                </table>
            </div>

            <div>
                <table>
                        <tr>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:ImageButton ID="imgMuestras" runat="server" Height="78px" Width="88px" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:Label ID="lblDetalleEx" runat="server" Text="Experiment Detail:"></asp:Label>
                                </div>
                            </td>
                        <tr>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:Button ID="btnSubir" runat="server" Text="Upload" class="w3-button w3-green"  Width="103px" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<textarea id="txaDetalleExp" class="auto-style1"></textarea>
                                </div>
                            </td>
                        </tr>
                            
                        </tr>
                </table>

                <div>
                <table>
                        <tr>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:Image ID="imgFirmaa" runat="server" Height="54px" Width="89px" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    &nbsp;<asp:DropDownList ID="ddlFirmaTetigo" runat="server" Width="388px" Height="19px"></asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button class="w3-button w3-green" ID="btnGuardarBitacoraEx" runat="server" Text="Save" Width="109px" />
                            </td>
                        </tr>
                </table>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Font-Italic="True"></asp:Label>
            </div>
            </div>

        </div>
            
    
</asp:Content>
