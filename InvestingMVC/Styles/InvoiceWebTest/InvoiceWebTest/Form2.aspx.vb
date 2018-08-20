Imports Infragistics.Web.UI
Imports Infragistics.Web.UI.GridControls
Imports CanadianNatural.InvoiceWebTest.BusinessObjects

Public Class Form2
    Inherits System.Web.UI.Page

    ' DESCRIPTION:  This is a sample amster/detail view.  The business object is bound to the grid during the form load.  When the row is changed
    '   via a postback triggered by a client-side click, the detail form is loaded.
    '
    ' NOTE: Any code commented out needs to be uncommented when the form is created.
    '
    ' NOTE: In the designer set the dsMaster datasource type to your business object type (do this through the designer).  You
    '   can then update the grid's column settings within the infragistics designer.  

    Protected mMasterObject As CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceObj
    Protected mDetailEntity As CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceEntity
    Protected mLineDetailObject As CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
    Protected mLineDetailEntity As CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineEntity
    Protected mInvoiceID As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Reload the grid unless we have only changed the row.  Note that due to an infragistics bug we 
        ' cannot sort/filter purely client side, so we have to reload the grid when these postbacks occue

        ' Create dummy data
        'Dim obj As New InvoiceObj
        'obj.GetCNRLEntities(Nothing)
        'Dim rng As New Random
        'For j As Integer = 1 To 500
        '    Dim newInv As InvoiceEntity = obj.CreateNewObject
        '    Select Case rng.Next(1, 3)
        '        Case 1 : newInv.InvNumber = "AB" & rng.Next(560000, 1000000000).ToString("000000000")
        '        Case 3 : newInv.InvNumber = "BC" & rng.Next(560000, 1000000000).ToString("000000000")
        '        Case 2 : newInv.InvNumber = "SK" & rng.Next(560000, 1000000000).ToString("000000000")
        '    End Select
        '    newInv.Currency = "CAD"
        '    Dim number As Integer = rng.Next(1, 1000000000)
        '    Dim digits As String = number.ToString("000000000")
        '    newInv.Afe = digits
        '    For i As Integer = 1 To rng.Next(1, 12)
        '        Dim li As InvoiceLineEntity = obj.LineItems.CreateNewObject()
        '        li.InvoiceId = newInv.Id
        '        li.Description = "line description " & i
        '        li.Amount = rng.Next(15, 4500)
        '        Select Case rng.Next(1, 3)
        '            Case 1 : li.Category = "CAT A"
        '            Case 3 : li.Category = "CAT B"
        '            Case 2 : li.Category = "CAT C"
        '        End Select
        '        li.SubCategory = li.Category & " - " & rng.Next(1, 3)
        '    Next
        '    obj.Save()
        'Next

        Dim argumentId As String = Request.Form.Get(postEventArgumentID)
        mInvoiceID = Request.Params("ID")
        If Not argumentId = "ROW_CHANGED" Then
            LoadMaster()
        End If
    End Sub

#Region "MASTER SECTION"

    ' Load and bind the master grid
    Protected Sub LoadMaster()
        ' Load invoice detail
        mMasterObject = New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceObj
        mMasterObject.SetFilterValue("Id", mInvoiceID)
        mDetailEntity = mMasterObject.GetCNRLEntityByPK(Nothing)
        Me.dbDetail.DataBind()

        ' load line items
        mLineDetailObject = New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
        gridMaster.DataSourceID = Nothing
        mLineDetailObject.SetFilterValue("InvoiceID", mInvoiceID)
        gridMaster.DataSource = mLineDetailObject.GetCNRLEntities(Nothing, True)
        gridMaster.DataKeyFields = "Id"
        gridMaster.DataBind()
        'panelDetail.Enabled = False
        '    btnAddLine.Enabled = mLineDetailObject.CanAddObject
    End Sub

    Private Sub gridMaster_DataFiltered(sender As Object, e As Infragistics.Web.UI.GridControls.FilteredEventArgs) Handles gridMaster.DataFiltered
        ' Clear the detail panel
        txtPrimaryKey.Text = "-1"
        LoadDetailEntity(False)
    End Sub

    Private Sub gridMaster_RowSelectionChanged(sender As Object, e As Infragistics.Web.UI.GridControls.SelectedRowEventArgs) Handles gridMaster.RowSelectionChanged
        ' Find the primary Key then load the detail panel if found (otherwise lock down the panel)
        If e.CurrentSelectedRows.Count > 0 Then
            If txtPrimaryKey.Text <> e.CurrentSelectedRows.GetIDPair(0).Item("key")(0).ToString Then
                LoadDetailEntity(e.CurrentSelectedRows.GetIDPair(0).Item("key")(0).ToString)
            End If
        Else
            LoadDetailEntity("-1")
        End If

    End Sub

    ' Handle adding a new Item
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'txtPrimaryKey.Text = ""
        gridMaster.Enabled = False

        '' Create a new detail record (if it doesn't already exist)
        Dim objectInstance As New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
        mLineDetailEntity = objectInstance.CreateNewObject()
        mLineDetailEntity.InvoiceId = mInvoiceID
        objectInstance.ForceSave()

        panelDetail.Enabled = True

        '' Update Buttons
        btnDelete.Enabled = objectInstance.CanDeleteObject
        btnSave.Enabled = objectInstance.CanAddObject
        
        '' Now bind it to the detail form
        dbDetail.DataBind()

        Response.Redirect(Request.Url.ToString)
    End Sub

    ' Handle adding a new Item
    Protected Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        'txtPrimaryKey.Text = ""
        gridMaster.Enabled = False

        '' Create a new detail record (if it doesn't already exist)
        Dim objectInstance As New InvoiceLineObj
        objectInstance.SetFilterValue("Id", txtPrimaryKey.Text)
        mLineDetailEntity = objectInstance.GetCNRLEntityByPK(Nothing)
        Dim invoiceID As Integer = mLineDetailEntity.InvoiceId
        Dim desc As String = mLineDetailEntity.Description
        Dim category As String = mLineDetailEntity.Category
        Dim sub_category As String = mLineDetailEntity.SubCategory
        Dim amount As Decimal = mLineDetailEntity.Amount
        Dim newEntity As InvoiceLineEntity = objectInstance.CreateNewObject
        newEntity.InvoiceId = invoiceID
        newEntity.Description = desc
        newEntity.Category = category
        newEntity.SubCategory = sub_category
        newEntity.Amount = amount
        objectInstance.Save()
        mLineDetailEntity = newEntity
        txtPrimaryKey.Text = newEntity.Id

        Response.Redirect(Request.Url.ToString)
    End Sub

#End Region

#Region "DETAIL SECTION"

    Protected Sub SaveButton_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveDetailEntity()
    End Sub

    Protected Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteDetailEntity()
    End Sub

    Protected Sub LoadDetailEntity(key As String)
        panelDetail.Enabled = True

        ' '' Load the detail record and bind it
        Dim objectInstance As New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
        objectInstance.SetFilterValue("Id", key)
        txtPrimaryKey.Text = key
        mLineDetailEntity = objectInstance.GetCNRLEntityByPK(Nothing)

        '' Update Buttons
        btnDelete.Enabled = objectInstance.CanDeleteObject
        btnSave.Enabled = objectInstance.CanEditObject

        '' Now bind it to the detail form
        LoadSubCategories(mLineDetailEntity.Category)
        Me.dbDetail.DataBind()

        If mLineDetailEntity.CurrentDataRow Is Nothing Then panelDetail.Enabled = False
    End Sub

    Protected Sub SaveDetailEntity()
        '' Load the detail record 
        Dim objectInstance As New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
        objectInstance.SetFilterValue("Id", txtPrimaryKey.Text)
        mLineDetailEntity = objectInstance.GetCNRLEntityByPK(Nothing)

        '' Check for new record (if no record found create one)
        'If mDetailEntity.CurrentDataRow Is Nothing Then
        '    mDetailEntity = objectInstance.CreateNewObject()
        'End If

        ' Copy data to entity 
        Me.dbDetail.Unbind()

        ' Validate data
        Dim hasBrokenRules As Boolean = False
        ''objectInstance.ForceCheckRules()
        If Not mDetailEntity.IsValid Then
            For Each brokenRule As CanadianNatural.ApplicationServices.BusinessObjects.BrokenRuleInfo In mDetailEntity.GetBrokenRules
                dbDetail.AddBindingError("mDetailEntity", brokenRule.Attribute, brokenRule.Description)
                hasBrokenRules = True
            Next
        End If

        If hasBrokenRules Then
            panelDetail.Enabled = True
            ErrorDisplay.Text = dbDetail.BindingErrors.ToHtml()
            Exit Sub
        Else
            ' Save changes
            objectInstance.Save()
        End If

        ' Reload the master grid
        Response.Redirect(Request.Url.ToString)
    End Sub

    Protected Sub DeleteDetailEntity()
        '' Load the detail record 
        Dim objectInstance As New CanadianNatural.InvoiceWebTest.BusinessObjects.InvoiceLineObj
        objectInstance.SetFilterValue("Id", txtPrimaryKey.Text)
        mLineDetailEntity = objectInstance.GetCNRLEntityByPK(Nothing)

        '' Delete the entity record
        objectInstance.DeleteEntity(mLineDetailEntity)

        '' Save changes
        objectInstance.Save()

        '' Reload the page
        Response.Redirect(Request.Url.ToString)
    End Sub

#End Region

    Private Sub LoadSubCategories(category As String)
        dlSubCategory.Items.Clear()
        dlSubCategory.Items.Add(category & " - 1")
        dlSubCategory.Items.Add(category & " - 2")
        dlSubCategory.Items.Add(category & " - 3")
    End Sub

    Private Sub dlCategory_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dlCategory.SelectedIndexChanged
        LoadSubCategories(dlCategory.Text)
    End Sub
End Class