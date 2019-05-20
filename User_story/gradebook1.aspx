<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gradebook1.aspx.cs" Inherits="User_story.gradebook1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Группа АА-11</h2>
        <asp:GridView ID="gvstudent_grade1" runat="server" AutoGenerateColumns="false" DataKeyNames="student_grade_ID" OnRowEditing="gvstudent_grade1_RowEditing" OnRowCancelingEdit="gvstudent_grade1_RowCancelingEdit" OnRowUpdating="gvstudent_grade1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="№">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("num") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtnum" Text='<%# Eval("num") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ФИО">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("fio") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtfio" Text='<%# Eval("fio") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Средний балл">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("avggrade") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtavggrade" Text='<%# Eval("avggrade") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Stock/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Stock/save.png" runat="server" CommandName="Update" ToolTip="Save" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Stock/cancel.jpg" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
        <br />
        <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
    </div>
    </form>
</body>
</html>
