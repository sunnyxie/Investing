Public Class InvoiceEntity
    Inherits AppEntityBase

#Region "Constructor/Destructor"

#End Region

#Region "Properties"

' Property Id
<ColumnMapping("ID")> _
Public Property Id As Nullable(Of Decimal)
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Id"), Nullable(Of Decimal))
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As Nullable(Of Decimal))
        SetData("Id", value)
    End Set
End Property

    ReadOnly Property InvID As Decimal
        Get
            Return Id
        End Get
    End Property

' Property InvNumber
<ColumnMapping("INV_NUMBER")> _
Public Property InvNumber As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("InvNumber"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("InvNumber", value)
    End Set
End Property

' Property Submitter
<ColumnMapping("SUBMITTER")> _
Public Property Submitter As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Submitter"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("Submitter", value)
    End Set
End Property

' Property Afe
<ColumnMapping("AFE")> _
Public Property Afe As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Afe"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("Afe", value)
    End Set
End Property

' Property Currency
<ColumnMapping("CURRENCY")> _
Public Property Currency As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Currency"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("Currency", value)
    End Set
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Dim returnVal As Decimal = 0
            For Each ent As Object In DirectCast(Me.ParentBizObject, Invoice(Of InvoiceEntity)).LineItems.GetCNRLEntities(Nothing, False)
                If DirectCast(ent, InvoiceLineEntity).Amount Then returnVal = returnVal + DirectCast(ent, InvoiceLineEntity).Amount
            Next
            Return returnVal
        End Get
    End Property


#End Region

#Region "Public Methods"

#End Region
	
#Region "Private/Protected Methods"

''' <summary>
''' This method is used to set default values on a new Entity instance.
''' Use the entities public Properties to set default values as required.
''' </summary>
Public Overrides Sub SetDefaultValues()
	Currency = "CAD"
End Sub

#End Region

End Class
