Public Class InvoiceDataAccess
    Inherits AppDataAccessBase(Of InvoiceEntity)

#Region "Constructor/Destructor"

    ''' <summary>
    ''' Default Constructor 
    ''' </summary>
    Public Sub New(ByVal ownerObject As mmBusinessObject)
        MyBase.New(ownerObject)
    End Sub

#End Region

#Region "Properties"

#End Region

#Region "Public Methods"

	' Override commands in this region to bind objects to stored procedures.
	' Note: If object is read-only comment out (or delete) CreateInsertCommand, CreateUpdateCommand(), and CreateDeleteCommand().

    ' <summary>
    ' Creates the Select command which is used to populate the business object, returns a cursor.
    ' </summary>
    ' <returns>Select Command</returns>
    Public Overrides Function CreateSelectCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.READALL")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))


        ' Map Parameters 

        Return oCommand
    End Function
    
	Public Overrides Function CreateSelectByPkCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.READBYPK")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))



        ' Map Parameters 
		MapParameterToValue(oCommand, "i_id", GetFilterValue("Id"),ParameterDirection.Input)


        Return oCommand
    End Function
    	
    ' <summary>
    ' Creates the Insert command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Insert Command</returns>
    Public Overrides Function CreateInsertCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.CREATE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("o_id", System.Data.OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_inv_number", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_submitter", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_afe", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_currency", System.Data.OracleClient.OracleType.VarChar))


        ' Map Parameters
		MapParameterToColumn(oCommand, "o_id", GetPropertyMapping("Id"))
		MapParameterToColumn(oCommand, "i_inv_number", GetPropertyMapping("InvNumber"))
		MapParameterToColumn(oCommand, "i_submitter", GetPropertyMapping("Submitter"))
		MapParameterToColumn(oCommand, "i_afe", GetPropertyMapping("Afe"))
		MapParameterToColumn(oCommand, "i_currency", GetPropertyMapping("Currency"))

        Return oCommand
    End Function

    ' <summary>
    ' Creates the Update command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Update Command</returns>
    Public Overrides Function CreateUpdateCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.UPDATE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_inv_number", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_submitter", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_afe", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_currency", System.Data.OracleClient.OracleType.VarChar))


        ' Map Parameters
		MapParameterToColumn(oCommand, "i_id", GetPropertyMapping("Id"))
		MapParameterToColumn(oCommand, "i_inv_number", GetPropertyMapping("InvNumber"))
		MapParameterToColumn(oCommand, "i_submitter", GetPropertyMapping("Submitter"))
		MapParameterToColumn(oCommand, "i_afe", GetPropertyMapping("Afe"))
		MapParameterToColumn(oCommand, "i_currency", GetPropertyMapping("Currency"))


        Return oCommand
    End Function

    ' <summary>
    ' Creates the Update command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Delete Command</returns>
    Public Overrides Function CreateDeleteCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.DELETE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))


        ' Map Parameters
		MapParameterToColumn(oCommand, "i_id", GetPropertyMapping("Id"))


        Return oCommand
    End Function

	    ' <summary>
    ' Select Empty DataSet Factory method
    ' </summary>
    ' <returns>Select Command</returns>
    Public Function CreateSelectEmptyCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICE.READEMPTY")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        Return oCommand
    End Function


    ' Override method to hook custom commands
    Public Overrides Function CreateCommand(cmdText As String) As System.Data.IDbCommand
            Select cmdText
            Case "SelectEmpty" : Return CreateSelectEmptyCommand()
        End Select
        Return MyBase.CreateCommand(cmdText)
    End Function

#End Region
	
#Region "Private/Protected Methods"
   
#End Region

End Class