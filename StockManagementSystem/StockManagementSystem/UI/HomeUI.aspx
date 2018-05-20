<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Inherits="StockManagementSystem.UI.HomeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />

</head>
<body>
<header>
    <div class="row">
        <div class="logo">
            Stock Management System
        </div>
        <ul class="main-nav">
            <li class="active"><a href="HomeUI.aspx">Home</a></li>
            <li><a href="CategorySet.Up.aspx">Category Setup</a></li>
            <li><a href="CompanySetup.aspx">Company Setup</a></li>
            <li><a href="ItemSetup.aspx">Item Setup</a></li>
            <li><a href="StockIn.aspx">Stock In</a></li>
            <li><a href="StockOut.aspx">Stock Out</a></li>
            <li><a href="SearchAndView.aspx">Item Summary</a></li>
            <li><a href="ViewSalesBetweenDates.aspx">View Sales</a></li>

        </ul>

    </div>
</header>
</body>
</html>
