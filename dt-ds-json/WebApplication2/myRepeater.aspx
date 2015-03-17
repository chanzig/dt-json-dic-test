<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myRepeater.aspx.cs" Inherits="WebApplication2.myRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnNew" runat="server" Text="新建" onclick="btnNew_OnClick" />
         <asp:Repeater ID="rpCustomerInfo" runat="server" onitemcommand="rpCustomerInfo_ItemCommand">
             <HeaderTemplate>
                      <table>
                             <tr>
                                 <th>ID</th><th>Name</th><th>Telephone</th><th>RegisterDate</th><th>删除</th>
                             </tr>
             </HeaderTemplate>
             <ItemTemplate>
                             <tr>
                                 <td><asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("ID")%>' ></asp:TextBox></td>
                                 <td><asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("Name")%>' ></asp:TextBox></td>
                                 <td><asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("Telephone")%>' ></asp:TextBox></td>
                                 <td><asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("RegisterDate")%>' ></asp:TextBox></td>
                                 <td><asp:LinkButton ID="lbnDelete" runat="server" CommandName="Delete" >删除</asp:LinkButton></td>
                             </tr>
              </ItemTemplate>
                             <FooterTemplate>
                       </table>
             </FooterTemplate>
             </asp:Repeater>
    </div>
    </form>
</body> 
</html>
