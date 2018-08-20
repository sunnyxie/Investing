Imports System.ComponentModel
Imports System.Web.Mail
Imports CanadianNatural.InvoiceWebTest.BusinessObjects

Public Class CreateInvoice
    Inherits System.Web.UI.Page

    ' DESCRIPTION:  This is a sample submission form.  The business object is bound during the form load, the data is then
    '   stored in the control's viewstate during postbacks.  When the submit button is created, a new object is created and
    '   data is unbound from the controls into that object, which is then saved.

    Const lineNumCount = 15

    Public mEntity As InvoiceEntity = Nothing
    Public mCurrentLineItem As Integer = 0
    Public mEventTargetID As String = ""

    ''' <summary>
    ''' Handles Page Load, Bind controls on first load (not postbacks)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            '' 1.  CREATE NEW ENTITY INSTANCE (GetCNRLEntityByPK is used to load data structure, required before call to CreateNewObject)
            Dim myObject As New InvoiceObj
            myObject.GetCNRLEntityByPK(Nothing)
            mEntity = myObject.CreateNewObject

            '' 2. SET DEFAULT VALUES (if not done elsewhere)
            mEntity.Currency = "CAD"

            '' 3. CALL DATABIND
            dbObject1.DataBind()

        End If

        ' CREATE LINE ITEMS TABLE
        Dim tblLineItems As New Table
        phLineItems.Controls.Add(tblLineItems)
        tblLineItems.Rows.Add(CreateHeaderRow)
        For i As Integer = 1 To lineNumCount
            tblLineItems.Rows.Add(CreateLineItemRow(i))
        Next

        ' update appropriate sub-category dropdown
        mEventTargetID = Page.Request.Params.Get("__EVENTTARGET")
        If mEventTargetID IsNot Nothing AndAlso mEventTargetID.Contains("$CATEGORY_") Then
            Dim eventSource As Control = Nothing
            eventSource = Page.FindControl(mEventTargetID)
            If eventSource IsNot Nothing Then
                mCurrentLineItem = CInt(eventSource.ID.Replace("CATEGORY_", ""))

                Dim newCat As String = Request.Form(mEventTargetID)
                Dim subcatdl As DropDownList = Page.FindControl(mEventTargetID.Replace("CATEGORY", "SUB_CATEGORY"))
                subcatdl.Items.Clear()
                subcatdl.Items.AddRange({New ListItem(newCat & " - 1"), New ListItem(newCat & " - 2"), New ListItem(newCat & " - 3")})
            End If
        End If
    End Sub

    Protected Function CreateHeaderRow() As TableRow
        Dim tr As New TableRow
        Dim a As New TableRow

        ' Description
        Dim tc1 As New TableCell()
        tr.Cells.Add(tc1)
        tc1.Text = "Description"

        ' Category
        Dim tc2 As New TableCell()
        tr.Cells.Add(tc2)
        tc2.Text = "Category"

        ' SubCategory
        Dim tc3 As New TableCell()
        tr.Cells.Add(tc3)
        tc3.Text = "Sub-Category"

        ' Amount
        Dim tc4 As New TableCell()
        tr.Cells.Add(tc4)
        tc4.Text = "Amount"

        Return tr
    End Function

    Protected Function CreateLineItemRow(i As Integer) As TableRow
        Dim tr As New TableRow

        ' Description
        Dim tc1 As New TableCell()
        tr.Cells.Add(tc1)
        Dim tbDesc As New TextBox()
        tbDesc.EnableViewState = True
        tbDesc.ID = "DESC_" & i
        tbDesc.Width = 300
        tc1.Controls.Add(tbDesc)

        ' Category
        Dim tc2 As New TableCell()
        tr.Cells.Add(tc2)
        Dim dlCat As New DropDownList
        dlCat.EnableViewState = True
        dlCat.AutoPostBack = True
        dlCat.Items.AddRange({New ListItem("CAT A"), New ListItem("CAT B"), New ListItem("CAT C")})
        dlCat.ID = "CATEGORY_" & i
        dlCat.Width = 100
        tc2.Controls.Add(dlCat)

        ' SUB-Category
        Dim tc3 As New TableCell()
        tr.Cells.Add(tc3)
        Dim dlSubCat As New DropDownList
        dlSubCat.EnableViewState = True
        dlSubCat.AutoPostBack = True
        dlSubCat.Items.AddRange({New ListItem("CAT A - 1"), New ListItem("CAT A - 2"), New ListItem("CAT A - 3")})
        dlSubCat.ID = "SUB_CATEGORY_" & i
        dlSubCat.Width = 100
        tc3.Controls.Add(dlSubCat)

        ' Amount
        Dim tc4 As New TableCell()
        tr.Cells.Add(tc4)
        Dim tbAmount As New TextBox()
        tbAmount.EnableViewState = True
        tbAmount.ID = "AMOUNT_" & i
        tbAmount.Width = 100
        tc4.Controls.Add(tbAmount)

        Return tr
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' 1.  CREATE NEW ENTITY INSTANCE (GetCNRLEntityByPK is used to load data structure, required before call to CreateNewObject)
        Dim myObject As New InvoiceObj
        myObject.GetCNRLEntityByPK(Nothing)
        mEntity = myObject.CreateNewObject

        ' 2. CALL UNBIND
        dbObject1.Unbind()

        ' CREATE LINE ITEMS
        For i As Integer = 1 To lineNumCount
            Dim descControl As TextBox = Page.FindControl("ctl00$body$DESC_" & i)
            If descControl IsNot Nothing AndAlso descControl.Text.Length > 0 Then
                Dim newLineObject As InvoiceLineEntity = myObject.LineItems.CreateNewObject()
                newLineObject.Description = descControl.Text
                newLineObject.Category = DirectCast(Page.FindControl("ctl00$body$CATEGORY_" & i), DropDownList).Text
                newLineObject.SubCategory = DirectCast(Page.FindControl("ctl00$body$SUB_CATEGORY_" & i), DropDownList).Text
                newLineObject.Amount = DirectCast(Page.FindControl("ctl00$body$AMOUNT_" & i), TextBox).Text
            End If
        Next

        ' 3. VALIDATE DATA
        Dim hasBrokenRules As Boolean = False
        myObject.ForceCheckRules()
        If Not mEntity.IsValid Then
            For Each brokenRule As CanadianNatural.ApplicationServices.BusinessObjects.BrokenRuleInfo In mEntity.GetBrokenRules
                dbObject1.AddBindingError("mEntity", brokenRule.Attribute, brokenRule.Description)
                hasBrokenRules = True
            Next
        End If
        If hasBrokenRules Then
            ErrorDisplay.Text = dbObject1.BindingErrors.ToHtml()
            Exit Sub
        Else
            ' Save changes
            myObject.ForceSave()

            ' Redirect to summary page
            Response.Redirect("Form2.aspx?ID=" & mEntity.Id)

        End If
    End Sub

End Class
