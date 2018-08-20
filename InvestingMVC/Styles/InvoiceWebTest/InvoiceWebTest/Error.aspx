<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.vb" Inherits="InvoiceWebTest._Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1 class="error_label">An unhandled error has occurred and has been logged.  Please notify the application 
        owner for assistance.</h1>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
