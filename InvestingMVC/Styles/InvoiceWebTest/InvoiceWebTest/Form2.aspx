<%@ Page Title="Edit Invoice" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Form2.aspx.vb" Inherits="InvoiceWebTest.Form2" %>
<%@ Register assembly="InvoiceWebTest" namespace="InvoiceWebTest" tagprefix="cc1" %>
<%@ Register assembly="wwDataBinder" namespace="MsdnMag.Web.Controls" tagprefix="ww" %>
<%@ Register assembly="Infragistics4.Web.v12.2, Version=12.2.20122.1007, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics4.Web.v12.2, Version=12.2.20122.1007, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<%@ Register assembly="Infragistics4.Web.v12.2, Version=12.2.20122.1007, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" id="igClientScript">
<!--
        // Handle the grid's RowSelectionChanged event on the client, prevent Grid from fully reloading
        function gridMaster_Selection_RowSelectionChanged(sender, eventArgs) {
            // Trigger the postback
            __doPostBack("<%= btnTrigger.ClientID %>", "ROW_CHANGED");
            }

            function dlCategory_Changed(sender, eventArgs) {
                // Trigger the postback
                __doPostBack("<%= btnTrigger.ClientID %>", "CATEGORY_CHANGED");
            }

// -->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600"></asp:ScriptManager>
        <div id="Div1" class="div_table" style="Width:1000px;">
            <div class="div_row_header">Header</div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Number:</div>
                    <asp:TextBox ID="txtNumber" runat="server" Width="80px"></asp:TextBox>
                </div>  
            </div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">AFE:</div>
                        <asp:TextBox ID="txtAFE" runat="server" Width="80px"></asp:TextBox>
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
                        </asp:DropDownList>
                    </div>  
                </div>  
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Total:</div>
                        <asp:TextBox ID="txtTotal" runat="server" Width="80px"></asp:TextBox>
                    </div>  
                </div>  
            </div>  

        <div id="Div2" class="div_table" style="Width:1000px;">
            <div class="div_row_header" style="Width:1000px;">Line Items</div>
                <div class="div_row">
    <div id="Master">
    <ig:WebDataGrid ID="gridMaster" runat="server" AutoGenerateColumns="False" 
        DataSourceID="dsMaster" Height="262px" Width="980px" 
    EnableTheming="False">
        <Columns>
                                <ig:BoundDataField DataFieldName="Description" Key="Description">
                                    <Header Text="Description" />
                                </ig:BoundDataField>
                                <ig:BoundDataField DataFieldName="Category" Key="Category">
                                    <Header Text="Category" />
                                </ig:BoundDataField>
                                <ig:BoundDataField DataFieldName="SubCategory" Key="SubCategory">
                                    <Header Text="SubCategory" />
                                </ig:BoundDataField>
                                <ig:BoundDataField DataFieldName="AmountFormatted" Key="AmountFormatted">
                                    <Header Text="Amount" />
                                </ig:BoundDataField>
        </Columns>
        <Behaviors>
            <ig:Filtering>
            </ig:Filtering>
            <ig:Sorting SortingMode="Multi">
            </ig:Sorting>
            <ig:Selection CellClickAction="Row" RowSelectType="Single">
                <SelectionClientEvents RowSelectionChanged="gridMaster_Selection_RowSelectionChanged" />
            </ig:Selection>
            <ig:EditingCore>
            </ig:EditingCore>
        </Behaviors>
    </ig:WebDataGrid>
    </div>
    </div>
                            <asp:ObjectDataSource ID="dsLines" runat="server" 
                                DataObjectTypeName="CanadianNatural.ApplicationServices.BusinessObjects.MereMortals.CNRLBusinessEntity" 
                                DeleteMethod="DeleteObject" InsertMethod="InsertObject" 
                                SelectMethod="SelectObject" TypeName="CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj" 
                                UpdateMethod="UpdateObject"></asp:ObjectDataSource>
    <div id="grid_buttons" style="width:980px; float:left; text-align:right;"><asp:LinkButton ID="btnAdd" runat="server">Add</asp:LinkButton></div>
    <asp:UpdatePanel ID="upDetail" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
        <ContentTemplate>
        <asp:TextBox ID="txtPrimaryKey" runat="server" style="display:none;"/>
        <asp:Button ID="btnTrigger" runat="server" style="display:none;"/>
        <br />
        <br />
        <asp:Panel ID="panelDetail" runat="server" Enabled="false">
        <div id="about_app_detail" class="div_table" style="Width:983px;">
            <div class="div_row_header">Line Item Detail</div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Description:</div>
                    <asp:TextBox ID="txtDesription" runat="server" Width="160px"></asp:TextBox>
                </div>  
            </div>
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Category:</div>
                        <asp:DropDownList ID="dlCategory" runat="server" Width="80px" AutoPostBack="true">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>CAT A</asp:ListItem>
                            <asp:ListItem>CAT B</asp:ListItem>
                            <asp:ListItem>CAT C</asp:ListItem>
                        </asp:DropDownList>
                </div>  
                <div class="div_row">
                    <div class="div_cell_label">Sub Category:</div>
                        <asp:DropDownList ID="dlSubCategory" runat="server" Width="80px">
                        </asp:DropDownList>
                </div>  
            </div>  
            <div class="div_column">
                <div class="div_row">
                    <div class="div_cell_label">Amount:</div>
                    <asp:TextBox ID="txtAmount" runat="server" Width="80px"></asp:TextBox>
                </div>  
            </div>
            <div class="div_row_buttons">
                    <ww:wwErrorDisplay ID="ErrorDisplay" runat='server' Width="100%"
                       UserMessage="Please correct the following errors:" 
                       Center="true"></ww:wwErrorDisplay>
            </div>  
            <div class="div_row_buttons">
                <asp:LinkButton ID="btnSave" runat="server" CausesValidation="False" 
                    CommandName="Save" Text="Save" />&nbsp;&nbsp;
                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />&nbsp;&nbsp;
                <asp:LinkButton ID="btnCopy" runat="server">Copy</asp:LinkButton>
            </div>  
        </div>
        </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <br />
    <ww:wwDataBinder ID="dbDetail" runat="server">
        <DataBindingItems>
            <ww:wwDataBindingItem ID="WwDataBindingItem1" runat="server" BindingSource="mDetailEntity" BindingSourceMember="Id" ControlId="txtID"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem2" runat="server" BindingSource="mDetailEntity" BindingSourceMember="InvNumber" ControlId="txtNumber"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem3" runat="server" BindingSource="mDetailEntity" BindingSourceMember="AFE" ControlId="txtAFE"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem4" runat="server" BindingSource="mDetailEntity" BindingSourceMember="Currency" ControlId="dlCurrency"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem5" runat="server" BindingSource="mDetailEntity" BindingSourceMember="Total" ControlId="txtTotal"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem6" runat="server" BindingSource="mLineDetailEntity" BindingSourceMember="Description" ControlId="txtDesription"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem7" runat="server" BindingSource="mLineDetailEntity" BindingSourceMember="Category" ControlId="dlCategory"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem8" runat="server" BindingSource="mLineDetailEntity" BindingSourceMember="SubCategory" ControlId="dlSubCategory"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem ID="WwDataBindingItem9" runat="server" BindingSource="mLineDetailEntity" BindingSourceMember="Amount" ControlId="txtAmount"></ww:wwDataBindingItem>
            <ww:wwDataBindingItem runat="server" ControlId="ErrorDisplay">
            </ww:wwDataBindingItem>
        </DataBindingItems>
    </ww:wwDataBinder>
</asp:Content>
