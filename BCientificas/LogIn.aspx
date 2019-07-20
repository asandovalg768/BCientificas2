<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BCientificas.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <h1 class="h4">login</h1>


            <div class="user">
                <asp:TextBox class="form-control" ID="txtUserName"  type="text" placeholder="Usuario" runat="server"></asp:TextBox>
            </div>
            <div class="password">
                <asp:TextBox class="form-control" placeholder="Contraseña" type="password" ID="txtPass" runat="server"></asp:TextBox>
            </div>
                <asp:Button class="btn-primary" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        </div>
    </form>
</body>
</html>
