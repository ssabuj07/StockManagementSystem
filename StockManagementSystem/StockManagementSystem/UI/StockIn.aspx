<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="StockManagementSystem.UI.StockIn" %>

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

    <ul style="margin: 0 auto; width: 68.5%">
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
                    <h1>Stock In</h1>
                </legend>
                <table>
                    <tr>
                        <td>Company</td>
                        <td>
                            <asp:DropDownList ID="stockInCompanyDropDownList" runat="server" Height="30px" Width="144px" AutoPostBack="True" OnSelectedIndexChanged="stockInCompanyDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Item</td>
                        <td>
                            <asp:DropDownList ID="stockInItemDropDownList" runat="server" Height="30px" Width="144px" AutoPostBack="True" OnSelectedIndexChanged="stockInItemDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
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
                        <td>Stock In Quantity</td>
                        <td>
                            <asp:TextBox ID="stockInQuantityTextBox" runat="server" Width="140px" Height="24px"></asp:TextBox>
                            <asp:Label ID="stockLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="saveButton" runat="server" Text="Save" Style="margin-left: 84px" OnClick="saveButton_Click" Width="61px" Height="32px" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
