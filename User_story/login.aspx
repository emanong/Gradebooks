<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="User_story.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <img src="Stock/background.jpg" class="panel" />
        </section>
        <div class="sec2">
            <div class="container">
                <div class="content">
                    <asp:TextBox ID="txtuser" placeholder="Username" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtpass" placeholder="Password"  runat="server"></asp:TextBox><br />
                    <asp:Button ID="btnlogin" runat="server" Text="Log In" OnClick="btnlogin_Click" />
                </div>
            </div>
        </div>
    </form>
           
</body>
</html>
