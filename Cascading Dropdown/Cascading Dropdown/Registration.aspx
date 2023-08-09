<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Cascading_Dropdown.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <style>
        .table_container{
            display: flex;
            align-items: center;
            justify-content: center;
            height: 500px;
        }
        table{
            display:flex;
            justify-content:center;
            align-items:center;
        }
        table tbody {
            background: gainsboro;
            padding: 10px;
            border-radius: 10px;
        }
        .center{
            display:flex;
            justify-content:center;
        }
        .center td h3{
            width: fit-content;
            margin: 5px 0px;
            font-family: sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table_container">
            <table>
                <tr class="center">
                    <td colspan="2"><h3>Create Account</h3></td>
                </tr>

                <tr>
                    <td>Full Name: </td>
                    <td><asp:TextBox ID="name_Text" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Email: </td>
                    <td><asp:TextBox ID="email_Text" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Gender: </td>
                    <td><asp:RadioButtonList ID="gender_rbl" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
                </tr>

                <tr>
                    <td>Country: </td>
                    <td><asp:DropDownList ID="country_ddl" runat="server" OnSelectedIndexChanged="country_ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>State: </td>
                    <td><asp:DropDownList ID="state_ddl" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>Password: </td>
                    <td><asp:TextBox ID="pass_Text" runat="server"></asp:TextBox></td>
                </tr>

                <tr class="center">
                    <td colspan="2"><asp:Button ID="create_btn" runat="server" Text="Create Account" OnClick="create_btn_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
