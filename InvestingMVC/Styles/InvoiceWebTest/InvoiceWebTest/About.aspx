<%@ Page Title="InvoiceWebTest - About" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="About.aspx.vb" Inherits="InvoiceWebTest.About1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="about_app_detail" class="div_table" style="width:330px;">
    <div class="div_row_header">Application Detail</div>
    <div class="div_column">
        <div class="div_row">
                <div class="div_cell_label">Application Name:</div>
                <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
        </div>
        <div class="div_row">
                <div class="div_cell_label">Version:</div>
                <asp:TextBox ID="txtVersion" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
        </div>
        <div class="div_row">
                <div class="div_cell_label">Environment:</div>
                <asp:TextBox ID="txtEnvironment" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
        </div>
    </div>
</div>
<div id="about_user_detail" class="div_table" style="width:330px;">
    <div class="div_row_header">User Detail</div>
    <div class="div_column">
        <div class="div_row">
                <div class="div_cell_label">Name:</div>
                <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
        </div>
        <div class="div_row">
                <div class="div_cell_label">User ID:</div>
                <asp:TextBox ID="txtUserID" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
        </div>
        <div class="div_row">
                <div class="div_cell_label">Application Roles:</div>
                <asp:TextBox ID="txtRoles" runat="server" ReadOnly="True" Rows="5" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </div>
        <div class="div_row">
                <div class="div_cell_label">Application Operations:</div>
                <asp:TextBox ID="txtOperations" runat="server" ReadOnly="True" Rows="5" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </div>
    </div>
</div>
</asp:Content>
