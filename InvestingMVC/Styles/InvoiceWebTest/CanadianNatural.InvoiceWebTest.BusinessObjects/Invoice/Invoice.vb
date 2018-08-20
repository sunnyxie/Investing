Public Class InvoiceObj
    Inherits Invoice(Of InvoiceEntity)
End Class

Public Class Invoice(Of EntityType As {InvoiceEntity, New})
    Inherits AppObjectBase(Of EntityType)

#Region "Constructor/Destructor"
    
    Public Sub New(Optional ByVal parent As mmBusinessObject = Nothing)
        Me.DatabaseKey = Constants.Values.ApplicationKey
        If parent IsNot Nothing Then
            parent.RegisterChildBizObj(Me)
            Me.AutoSaveOnParentSaved = True
        End If
    End Sub
    
#End Region

#Region "Properties"
    Dim mInvoiceLines As New InvoiceLine(Of InvoiceLineEntity)(Me)
    Public ReadOnly Property LineItems As InvoiceLine(Of InvoiceLineEntity)
        Get
            Return mInvoiceLines
        End Get
    End Property


#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Factory method that creates data access object
    ''' </summary>
    ''' <returns>Reference to the data access object</returns>
    Public Overrides Function GetDataAccessObject() As OakLeaf.MM.Main.Data.mmDataAccessBase
        Return New InvoiceDataAccess(Me)
    End Function

	    ' Loads an empty recordset to allow binding before larger data loads
    Public Sub LoadEmptyDataset()
        ' Load Dataset
        LoadData("SelectEmpty", DatabaseKey, Nothing)

        ' Populate Entity List
        GetCNRLEntities(Nothing, False)
    End Sub

    Public Overrides Function ItemSelected(item As ApplicationServices.BusinessObjects.IBusinessObject) As Boolean
        MyBase.ItemSelected(item)
        mInvoiceLines.SetFilterValue("InvoiceID", DirectCast(item, InvoiceEntity).Id)
        mInvoiceLines.LoadData(Nothing)
        Return True
    End Function
#End Region
	
#Region "Private/Protected Methods"

    ''' <summary>
    ''' Factory method that creates a business rule object
    ''' </summary>
    ''' <returns>Reference to the business rule object</returns>
    Protected Overrides Function CreateBusinessRuleObject() As OakLeaf.MM.Main.Business.mmBusinessRule
        Return New InvoiceRule(Me)
    End Function

#End Region

End Class
