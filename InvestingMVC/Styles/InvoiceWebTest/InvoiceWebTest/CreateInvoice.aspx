<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="InvoiceWebTest.CreateInvoice" Codebehind="CreateInvoice.aspx.vb" %>
<%@ Register assembly="InvoiceWebTest" namespace="InvoiceWebTest" tagprefix="cc1" %>
<%@ Register assembly="wwDataBinder" namespace="MsdnMag.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="div_noticetext" style="width:800px;">
    Create a New Invoice<br />
</div>
<div id="request_info" class="div_table" style="width:1000px;">
    <div class="div_row_header">Header<br />
    </div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Number:</div>
                    <asp:TextBox ID="txtNumber" runat="server" Width="80px"></asp:TextBox> &nbsp; &nbsp; &nbsp;
                </div>  
            </div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">AFE:</div>
                        <asp:TextBox ID="txtAFE" runat="server" Width="80px"></asp:TextBox> &nbsp; &nbsp; &nbsp;
                    </div>  
            </div>  
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Currency:</div>
                        <asp:DropDownList ID="dlCurrency" runat="server" Width="60px"> 
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>CAD</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                            <asp:ListItem>GBP</asp:ListItem>
                        </asp:DropDownList> &nbsp; &nbsp; &nbsp;
                    </div>  
                </div>  
<br />
<div id="lineitems" class="div_table" style="width:1000px;">
    <div class="div_row_header">Line Items<br />
    </div>
    <div class="div_column">
        <div class="div_row">
            <div class="div_cell">
            <asp:PlaceHolder ID="phLineItems" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</div>
</div>

<ww:wwErrorDisplay ID="ErrorDisplay" runat="server" Center="true" 
                UserMessage="Please correct the following errors:" Width="800px">
</ww:wwErrorDisplay>
<br />
 
<div id="Div1" style="width:800px;">
    <center>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    </center>																																																																																																														
</div>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<ww:wwdatabinder ID="dbObject1" runat="server">
    <DataBindingItems>
            <ww:wwDataBindingItem ID="WwDataBindingItem1" runat="server" BindingSource="mEntity" BindingSourceMember="Id" ControlId="txtID"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem2" runat="server" BindingSource="mEntity" BindingSourceMember="InvNumber" ControlId="txtNumber"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem3" runat="server" BindingSource="mEntity" BindingSourceMember="AFE" ControlId="txtAFE"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem4" runat="server" BindingSource="mEntity" BindingSourceMember="Currency" ControlId="dlCurrency"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem runat="server" ControlId="phLineItems">
            </ww:wwDataBindingItem>
    </DataBindingItems>
</ww:wwdatabinder>

</asp:Content>

