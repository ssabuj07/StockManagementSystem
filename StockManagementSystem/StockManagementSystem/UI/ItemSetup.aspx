﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetup.aspx.cs" Inherits="StockManagementSystem.UI.ItemSetup" %>

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
                    <h1>Item Setup</h1>
                </legend>
                <table>
                    <tr>
                        <td>Category</td>
                        <td>
                            <asp:DropDownList ID="categoryDropDownList" runat="server" Height="32px" Width="144px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Company</td>
                        <td>
                            <asp:DropDownList ID="companyDropDownList" runat="server" Height="32px" Width="144px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Item Name</td>
                        <td>
                            <asp:TextBox ID="itemNameTextBox" runat="server" Width="140px" Height="26px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>Reorder Level</td>
                        <td>
                            <asp:TextBox ID="itemReorderLevelTextBox" runat="server" Width="140px" Height="26px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="saveButton" runat="server" Text="Save" Height="34px" Style="margin-left: 79px" Width="66px" OnClick="saveButton_Click" />

                        </td>
                    </tr>

                </table>
                
                <br />
            <asp:Label ID="ItemMsgLabel" ForeColor="red" runat="server"></asp:Label>
            <br/><br/>

            </fieldset>
            
        </div>
    </form>
</body>
</html>
