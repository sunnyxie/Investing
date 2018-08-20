Public Class InvoiceLineRule
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
        Return New InvoiceLineEntity()
    End Function

    Public Overrides Function CheckBusinessRules(ByVal rulesEntity As mmBusinessEntity) As Boolean
        Dim currentEntity As InvoiceLineEntity = CType(rulesEntity, InvoiceLineEntity)
        If currentEntity IsNot Nothing AndAlso currentEntity.CurrentDataRow IsNot Nothing Then

            '	IdRequired(currentEntity)
		CategoryLength(currentEntity)
		SubCategoryLength(currentEntity)
		DescriptionLength(currentEntity)

		End If
        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

#End Region
    
#Region "Private/Protected Methods"
    

Protected Sub IdRequired(ByVal currentEntity as InvoiceLineEntity)
	If currentEntity.Id.HasValue = false Then _
		AddErrorMessage("Id", "Id is required.")
End Sub

Protected Sub CategoryLength(ByVal currentEntity as InvoiceLineEntity)
	If currentEntity.Category IsNot Nothing AndAlso currentEntity.Category.Length > 20 Then _
		AddErrorMessage("Category", "Category has a maximum size of 20 characters.")
End Sub

Protected Sub SubCategoryLength(ByVal currentEntity as InvoiceLineEntity)
	If currentEntity.SubCategory IsNot Nothing AndAlso currentEntity.SubCategory.Length > 20 Then _
		AddErrorMessage("SubCategory", "SubCategory has a maximum size of 20 characters.")
End Sub

Protected Sub DescriptionLength(ByVal currentEntity as InvoiceLineEntity)
	If currentEntity.Description IsNot Nothing AndAlso currentEntity.Description.Length > 20 Then _
		AddErrorMessage("Description", "Description has a maximum size of 20 characters.")
End Sub


#End Region
    
End Class