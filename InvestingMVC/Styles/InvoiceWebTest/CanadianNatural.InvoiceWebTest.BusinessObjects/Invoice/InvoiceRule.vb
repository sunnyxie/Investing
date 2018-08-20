Public Class InvoiceRule
    Inherits AppRuleBase

#Region "Constructor/Destructor"

    Public Sub New(ByVal hostObject As ImmBusinessRuleHost)
        MyBase.New(hostObject)
    End Sub
    
#End Region

#Region "Properties"

#End Region

#Region "Public Methods"

    Public Overrides Function CreateEntity() As CNRLBusinessEntity
        Return New InvoiceEntity()
    End Function

    Public Overrides Function CheckBusinessRules(ByVal rulesEntity As mmBusinessEntity) As Boolean
        Dim currentEntity As InvoiceEntity = CType(rulesEntity, InvoiceEntity)
        If currentEntity IsNot Nothing AndAlso currentEntity.CurrentDataRow IsNot Nothing Then

            '	IdRequired(currentEntity)
		InvNumberLength(currentEntity)
		SubmitterLength(currentEntity)
		AfeLength(currentEntity)
		CurrencyLength(currentEntity)

		End If
        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

#End Region
    
#Region "Private/Protected Methods"
    

Protected Sub IdRequired(ByVal currentEntity as InvoiceEntity)
	If currentEntity.Id.HasValue = false Then _
		AddErrorMessage("Id", "Id is required.")
End Sub

Protected Sub InvNumberLength(ByVal currentEntity as InvoiceEntity)
	If currentEntity.InvNumber IsNot Nothing AndAlso currentEntity.InvNumber.Length > 20 Then _
		AddErrorMessage("InvNumber", "InvNumber has a maximum size of 20 characters.")
End Sub

Protected Sub SubmitterLength(ByVal currentEntity as InvoiceEntity)
	If currentEntity.Submitter IsNot Nothing AndAlso currentEntity.Submitter.Length > 20 Then _
		AddErrorMessage("Submitter", "Submitter has a maximum size of 20 characters.")
End Sub

Protected Sub AfeLength(ByVal currentEntity as InvoiceEntity)
	If currentEntity.Afe IsNot Nothing AndAlso currentEntity.Afe.Length > 20 Then _
		AddErrorMessage("Afe", "Afe has a maximum size of 20 characters.")
End Sub

Protected Sub CurrencyLength(ByVal currentEntity as InvoiceEntity)
	If currentEntity.Currency IsNot Nothing AndAlso currentEntity.Currency.Length > 20 Then _
		AddErrorMessage("Currency", "Currency has a maximum size of 20 characters.")
End Sub


#End Region
    
End Class