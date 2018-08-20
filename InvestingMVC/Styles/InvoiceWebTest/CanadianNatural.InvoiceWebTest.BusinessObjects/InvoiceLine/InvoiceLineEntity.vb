Public Class InvoiceLineEntity
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

' Property LineNum
<ColumnMapping("LINE_NUM")> _
Public Property LineNum As Nullable(Of Decimal)
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("LineNum"), Nullable(Of Decimal))
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As Nullable(Of Decimal))
        SetData("LineNum", value)
    End Set
End Property

' Property Category
<ColumnMapping("CATEGORY")> _
Public Property Category As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Category"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("Category", value)
    End Set
End Property

' Property SubCategory
<ColumnMapping("SUB_CATEGORY")> _
Public Property SubCategory As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("SubCategory"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("SubCategory", value)
    End Set
End Property

' Property Description
<ColumnMapping("DESCRIPTION")> _
Public Property Description As String
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("Description"), String)
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As String)
        SetData("Description", value)
    End Set
End Property

' Property Amount
    <ColumnMapping("AMOUNT")> _
    Public Property Amount As Decimal
        <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return CType(GetData("Amount"), Decimal)
        End Get
        <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Set(ByVal value As Decimal)
            SetData("Amount", value)
        End Set
    End Property

    Public ReadOnly Property AmountFormatted As String
        Get
            Return FormatCurrency(Amount, 2, TriState.UseDefault, TriState.True, TriState.UseDefault)
        End Get
    End Property

' Property InvoiceId
<ColumnMapping("INVOICE_ID")> _
Public Property InvoiceId As Nullable(Of Decimal)
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Get
        Return CType(GetData("InvoiceId"), Nullable(Of Decimal))
    End Get
   <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
    Set(ByVal value As Nullable(Of Decimal))
        SetData("InvoiceId", value)
    End Set
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
End Sub

#End Region

End Class
