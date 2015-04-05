<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="LoginSystem.RegisterForm" %>

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
            <td>First Name:</td>
            <td><asp:TextBox ID="txtboxfname" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ControlToValidate="txtboxfname" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required Field"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td><asp:TextBox ID="txtboxlname" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ControlToValidate="txtboxlname" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required Field"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txtboxemail" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required Field" ControlToValidate="txtboxemail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ErrorMessage="Invalid Email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtboxemail"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>    
            <td>Confirm Email:</td>
            <td><asp:TextBox ID="txtboxcemail" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required Field" ControlToValidate="txtboxcemail"></asp:RequiredFieldValidator>
                <asp:CompareValidator ControlToCompare="txtboxemail" ID="CompareValidator1" runat="server" ErrorMessage="*Must match Email" ControlToValidate="txtboxcemail"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox TextMode="Password" ID="txtboxpwrd" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required Field" ControlToValidate = "txtboxpwrd"></asp:RequiredFieldValidator></td>
            </tr>
        <tr>    
            <td>Confirm Password:</td>
            <td><asp:TextBox TextMode="Password" ID="txtboxcpwrd" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ErrorMessage="*Required Field" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtboxcpwrd"></asp:RequiredFieldValidator>
                <asp:CompareValidator ControlToValidate="txtboxcpwrd" ControlToCompare="txtboxpwrd" ID="CompareValidator2" runat="server" ErrorMessage="*Must Match Password"></asp:CompareValidator></td>
        </tr>
        <tr>    
            <td></td>
            <td colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Register" 
                    onclick="btnSubmit_Click" /></td>
           
        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
