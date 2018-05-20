<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenDates.aspx.cs" Inherits="StockManagementSystem.UI.ViewSalesBetweenDates" %>

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
                    <h1>View Sales Between Two Dates</h1>
                </legend>
                <table>
                    <tr>
                        <td>From Date</td>
                        <td>
                            <asp:TextBox ID="fromTextBox" runat="server" Height="24px"></asp:TextBox>
                            <asp:ImageButton ID="fromImageButton" runat="server" Style="margin-left: 0px" Height="21px" ImageUrl="~/UI/images/calendar.png" Width="52px" OnClick="fromImageButton_Click" />

                        </td>


                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Calendar ID="fromDateCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" VisibleDate="2018-05-04" Width="220px" OnSelectionChanged="fromDateCalendar_SelectionChanged">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>To Date</td>
                        <td>
                            <asp:TextBox ID="toTextBox" runat="server" Height="24px"></asp:TextBox>
                            <asp:ImageButton ID="toImageButton" runat="server" Height="21px" ImageUrl="~/UI/images/calendar.png" Width="51px" OnClick="toImageButton_Click" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Calendar ID="toDateCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" VisibleDate="2018-05-04" Width="220px" OnSelectionChanged="toDateCalendar_SelectionChanged">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search" Style="margin-left: 95px" Width="77px" OnClick="Button1_Click" Height="32px" /></td>
                    </tr>

                </table>
                <br />
                <asp:Label ID="salesMsgLabel" ForeColor="red" runat="server"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="viewSellsGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="68px" Width="473px">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("CompanyId")%>'></asp:Label>--%>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale Quantity">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("SellQuantity")%>'></asp:Label>
                            </ItemTemplate>
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

            </fieldset>
        </div>
    </form>
</body>
</html>
