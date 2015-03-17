<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myRepeater-update.aspx.cs" Inherits="WebApplication2.myRepeater_update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <table border="1" cellpadding="0" cellspacing="1" style="width: 80%; border: 1px solid #ccc; font-size: 12px;">
                <tr>
                    <td align="center">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                            OnItemCommand="Repeater1_ItemCommand">
                            <HeaderTemplate>
                                <table border="0" cellpadding="0" cellspacing="1" style="background-color: #CCC;
                                    width: 80%;">
                                    <tr>
                                        <td style="background-color: #FFF; height: 25px;">
                                            A标题
                                        </td>
                                        <td style="background-color: #FFF;">
                                            B标题
                                        </td>
                                        <td style="background-color: #FFF;">
                                            C标题
                                        </td>
                                        <td style="background-color: #FFF;">
                                            编辑
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Panel ID="plItem" runat="server">
                                    <tr>
                                        <td style="background-color: #FFF; height: 25px; width: 30%;">
                                            <%# DataBinder.Eval(Container.DataItem, "a")%>
                                        </td>
                                        <td style="background-color: #FFF; width: 30%;">
                                            <%# DataBinder.Eval(Container.DataItem,"b") %>
                                        </td>
                                        <td style="background-color: #FFF; width: 30%;">
                                            <%# DataBinder.Eval(Container.DataItem,"c") %>
                                        </td>
                                        <td style="background-color: #FFF; width: 10%;">
                                            <asp:LinkButton runat="server" ID="lbtEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                CommandName="Edit" Text="编辑"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="lbtDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                CommandName="Delete" Text="删除"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="plEdit" runat="server">
                                    <tr>
                                        <td style="background-color: #FFF; height: 25px; width: 30%;">
                                            <asp:TextBox ID="txtA" Text='<%# DataBinder.Eval(Container.DataItem,"a") %>' runat="server"></asp:TextBox>
                                        </td>
                                        <td style="background-color: #FFF; width: 30%;">
                                            <asp:TextBox ID="txtB" Text='<%# DataBinder.Eval(Container.DataItem,"b") %>' runat="server"></asp:TextBox>
                                        </td>
                                        <td style="background-color: #FFF; width: 30%;">
                                            <asp:TextBox ID="txtC" Text='<%# DataBinder.Eval(Container.DataItem,"c") %>' runat="server"></asp:TextBox>
                                        </td>
                                        <td style="background-color: #FFF; width: 80px; width: 10%;">
                                            <asp:LinkButton runat="server" ID="lbtUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                CommandName="Update" Text="更新"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="lbtCancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                CommandName="Cancel" Text="取消"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table></FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height:80px;">
                        点<a href="http://www.x-wow.net/wow/Download/RepeaterTest.rar" title="源代码" style="color: Red;">这里</a>示例下载
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
