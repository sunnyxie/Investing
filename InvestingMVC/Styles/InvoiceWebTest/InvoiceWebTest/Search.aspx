<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Search.aspx.vb" Inherits="InvoiceWebTest.Search" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" 
    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="False" 
    ShowFindControls="False" 
    ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
        InternalBorderColor="White" ShowCredentialPrompts="False" 
        ShowToolBar="True" Height="600px">
    <ServerReport ReportPath="/DEV/IS TCO/Invoices" 
        ReportServerUrl="http://sqlreportservertest/ssrs" />
</rsweb:ReportViewer>
<script type="text/javascript" language="javascript">
    function AdjustViewButton()
    {
        var ctrl = document.getElementById("ctl00_body_ReportViewer1_ctl04_ctl00");
       ctrl.value = "Search";
    }
    AdjustViewButton();

    function __doPostBack_Custom(eventTarget, eventArgs) {
        AdjustViewButton();
        oldDoPostBack(eventTarget, eventArgs);
    }
    var oldDoPostBack = window.__doPostBack;
    window.__doPostBack = __doPostBack_Custom;

</script>
</asp:Content>
