<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="LoginSystem.LoginForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Username:</td>
                <td><asp:TextBox runat="server" ID="tbxuname"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox TextMode="Password" runat="server" ID="tbxpwd"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" /></td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
