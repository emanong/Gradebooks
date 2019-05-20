<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_prof.aspx.cs" Inherits="User_story.user_prof" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Page</title>
    <link href="Style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <section>
            <img src="Stock/background.jpg" class="panel" />
        </section>
        <div class="sec2">
            <div class="container">
                <div class="content">
                    <asp:Label ID="txtuser" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="gradebooks" runat="server" Text="Журналы успеваемости студентов:"></asp:Label><br />
                    <asp:Button ID="gradebook1" runat="server" Text="Группа АА-11" OnClick="gradebook1_Click" /><br />
                    <asp:Button ID="gradebook2" runat="server" Text="Группа ББ-22" OnClick="gradebook2_Click" /><br />

                    <asp:Button ID="btnlogout" runat="server" Text="Log Out" OnClick="btnlogout_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
