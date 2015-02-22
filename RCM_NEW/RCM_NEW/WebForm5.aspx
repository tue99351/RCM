<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="RCM_NEW.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GrossCHGGridView" runat="server" ShowFooter="true" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Undergraduate CHG">
                    
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle HorizontalAlign="Center" BackColor="White" Font-Bold="True" ForeColor="Black"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Undrgraduate Rate">
                    
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle HorizontalAlign="Center" BackColor="White" Font-Bold="True" ForeColor="Black"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Graduate CHG">
                    
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle HorizontalAlign="Center" BackColor="White" Font-Bold="True" ForeColor="Black"></FooterStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="17%"></HeaderStyle>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Graduate Rate">
                    
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White"></FooterStyle>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>

            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>

    </div>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            </Items>
        </asp:Menu>
    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </form>
    </body>
</html>
