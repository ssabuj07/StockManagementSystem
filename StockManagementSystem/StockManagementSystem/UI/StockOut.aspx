<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOut.aspx.cs" Inherits="StockManagementSystem.UI.StockOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            /*background-color: #302466;*/
            background-color: mediumblue;
        }

        li {
            float: left;
        }

            li a, .dropbtn {
                display: inline-block;
                color: white;
                font-family: cursive;
                text-align: center;
                padding: 15px 12px;
                text-decoration: none;
                font-weight: bold;
                font-size: 16.4px;
            }

                li a:hover, .dropdown:hover .dropbtn {
                    background-color: purple;
                }

            li.dropdown {
                display: inline-block;
            }


        .containt {
            width: 500px;
            margin: 0 auto;
            /*//background-color: gray;*/
        }
    </style>
</head>
<body>
    <br />

    <ul style="margin: 0 auto; width: 70%">
        <li><a href="HomeUI.aspx">Home</a></li>
        <li><a href="CategorySet.Up.aspx">Category Setup</a></li>
        <li><a href="CompanySetup.aspx">Company Setup</a></li>
        <li><a href="ItemSetup.aspx">Item Setup</a></li>

        <li><a href="StockIn.aspx">Stock In </a></li>
        <li><a href="StockOut.aspx">Stock Out</a></li>
        <li><a href="SearchAndView.aspx">Item Summary</a></li>
        <li><a href="ViewSalesBetweenDates.aspx">View Sales</a></li>

    </ul>
    <form id="form1" runat="server">
        <div class="containt">
            <fieldset>
                <legend style="color: blue">
                    <h1>Stock Out</h1>
                </legend>
                <table>
                    <tr>
                        <td>Company</td>
                        <td>
                            <asp:DropDownList ID="stockOutCompanyDropDownList" runat="server" Height="30px" Width="144px" AutoPostBack="True" OnSelectedIndexChanged="stockOutCompanyDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Item</td>
                        <td>
                            <asp:DropDownList ID="stockOutItemDropDownList" runat="server" Height="30px" Width="144px" AutoPostBack="True" OnSelectedIndexChanged="stockOutItemDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Reorder Level</td>
                        <td>
                            <asp:TextBox ID="showReorderLevelTextBox" runat="server" ReadOnly="True" Width="140px" Height="24px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Available Quantity</td>
                        <td>
                            <asp:TextBox ID="showAvailableQuantityTextBox" runat="server" ReadOnly="True" Width="140px" Height="24px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Stock Out Quantity</td>
                        <td>
                            <asp:TextBox ID="stockOutQuantityTextBox" runat="server" Width="140px" Height="24px"></asp:TextBox>
                            <asp:Label ID="stockLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="addButton" runat="server" Text="Add" Style="margin-left: 76px" OnClick="addButton_Click" Width="70px" Height="35px" /></td>
                    </tr>
                </table>
                <%--<asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="434px" >
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CompanyId")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CompanyName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <%--<asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AvailableQuantity")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
        </asp:GridView>--%>

                <br />
                <asp:Label ID="stockOutMsgLabel" ForeColor="red" runat="server" Text=""></asp:Label>
                <br/><br/>
                <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="35px" Width="425px">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="SL">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label ID="itemNameLabel" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label ID="companyNameLabel" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("SellQuantity") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <br />
                <table style="margin-left: 304px">
                    <tr>
                        <td>

                            <asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" Style="margin-left: 0px" Height="37px" Width="70px" />

                        </td>
                        <td>
                            <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" Height="37px" /></td>
                        <td>
                            <asp:Button ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" Height="35px" Width="70px" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
