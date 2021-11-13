Imports Oracle.DataAccess.Client

Public Class wfrmNuevaActividad
	Inherits System.Web.UI.Page
	Dim util As New clsFunciones
	Dim query As String
	Dim tableDefault As DataTable
	Dim rowDefault As DataRow

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then
				fillCombos(Cache, cboPrioridad, Application, , , False, )
				fillCombos(Cache, cboTipoProgreso, Application, , , False, )
				fillCombos(Cache, cboUsuario, Application, , , False, )
				TxtFechaInicial.Text = Date.Now.ToString("yyyy-MM-dd")
				txtFechaFinal.Text = Date.Now.ToString("yyyy-MM-dd")

				If Not Page.Request("idActividad") = "" Then
					lblTitulo.Text = "Modificar"
					ViewState("idActividad") = Page.Request("idActividad")
					buscarActividad()
				Else
					lblTitulo.Text = "Grabar"
				End If
			End If
		Catch ex As Exception
			'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje del Sistema")
			Console.WriteLine(ex.Message)
		End Try
	End Sub


	Public Sub fillCombos(ByVal Cache As Cache, ByRef xCombo As DropDownList, _
		 ByVal Application As HttpApplicationState, _
		 Optional ByVal xParameter1 As String = "", _
		 Optional ByVal xParameter2 As String = "", _
		 Optional ByVal AgregarTodos As Boolean = False, _
		 Optional ByVal xParameter3 As String = "")
		Try
			Dim Ds As New DataSet

			If Application(xCombo.ID) = True Then
				Cache.Remove(xCombo.ID)
				Application.Remove(xCombo.ID)
				xCombo.Items.Clear()
				xCombo.SelectedValue = Nothing
				xCombo.DataBind()
			Else


			End If
			Dim SqlQuery As String
			SqlQuery = ""

			If xCombo.ID = "cboPrioridad" Then
				SqlQuery = " SELECT IDPRIORIDAD, DESCRIPCION FROM PRIORIDAD "
			ElseIf xCombo.ID = "cboTipoProgreso" Then
				SqlQuery = " SELECT  IDTIPOPROGRESO, DESCRIPCION FROM  TIPOPROGRESO"
			ElseIf xCombo.ID = "cboUsuario" Then
				SqlQuery = " SELECT    USUARIO.IDUSUARIO, USUARIO.NOMBRE "
				SqlQuery &= " FROM RELACIONTIPOUSUARIO, USUARIO "
				SqlQuery &= " WHERE   RELACIONTIPOUSUARIO.TIPOUSUARIOHIJO = USUARIO.IDTIPODEUSUARIO "
				SqlQuery &= " AND RELACIONTIPOUSUARIO.TIPOUSUARIOPADRE = " & Session("idtipodeusuario").ToString
			End If

			Dim comando As New OracleCommand


			'Creamos el SelectCommand
			comando.CommandType = CommandType.Text
			comando.CommandText = SqlQuery
			comando.Connection = util.conn()

			'Creamos el Adapter
			Dim Adapter As New OracleDataAdapter
			Adapter.SelectCommand = comando
			'Creamos y llenamos el dataset
			Adapter.Fill(Ds, "Tabla")
			Cache.Insert(xCombo.ID, Ds)

			xCombo.DataSource = Ds
			xCombo.DataValueField = Ds.Tables(0).Columns(0).ColumnName.ToString
			xCombo.DataTextField = Ds.Tables(0).Columns(1).ColumnName.ToString
			xCombo.DataBind()
			If AgregarTodos Then
				Dim item As New ListItem
				item.Text = "-Todos-"
				item.Value = ""
				xCombo.Items.Add(item)
				xCombo.SelectedValue = ""
			End If
		Catch ex As Exception
			'MasterHelper.mostrarError("fillCombo", ex, Me)
			Console.WriteLine(ex)
		End Try
	End Sub


	Private Sub buscarActividad()
		Try
			query = ""
			query = " SELECT IDACTIVIDAD, FECHAINICIAL , FECHAFINAL , DESCRIPCION, IDUSUARIO, IDTIPOPROGRESO, IDPRIORIDAD"
			query &= " FROM ACTIVIDAD "
			query &= " WHERE IDACTIVIDAD = " & ViewState("idActividad")
			rowDefault = util.ConsultarFilaTabla(query)
			If Not IsNothing(rowDefault) Then
				TxtFechaInicial.Text = CDate(rowDefault.Item("FechaInicial")).ToString("yyyy-MM-dd")
				txtFechaFinal.Text = CDate(rowDefault.Item("FechaInicial")).ToString("yyyy-MM-dd")
				cboUsuario.SelectedValue = rowDefault.Item("IDUSUARIO").ToString
				cboTipoProgreso.SelectedValue = rowDefault.Item("IDTIPOPROGRESO").ToString
				cboPrioridad.SelectedValue = rowDefault.Item("IDPRIORIDAD").ToString
				txtActividad.Text = rowDefault.Item("DESCRIPCION").ToString
			Else
				Console.WriteLine("No se encontro datos")
			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub


	Private Sub btnGrabar_ServerClick(sender As Object, e As System.EventArgs) Handles btnGrabar.ServerClick
		Try
			query = ""
			If Not IsNothing(ViewState("idActividad")) AndAlso CInt(ViewState("idActividad")) > 0 Then
				query = " UPDATE ACTIVIDAD SET FECHAINICIAL = TO_DATE(" & util.Send(TxtFechaInicial.Text.ToString) & ",'RR-MM-DD') "
				query &= " , FECHAFINAL = TO_DATE(" & util.Send(txtFechaFinal.Text.ToString) & ",'RR-MM-DD') "
				query &= " , DESCRIPCION = " & util.Send(txtActividad.Text)
				query &= " , IDUSUARIO = " & cboUsuario.SelectedValue
				query &= " , IDTIPOPROGRESO = " & cboTipoProgreso.SelectedValue
				query &= " , IDPRIORIDAD = " & cboPrioridad.SelectedValue
				query &= " WHERE IDACTIVIDAD = " & ViewState("idActividad")
				util.ExecuteSQLQuery(query)
			Else
				ViewState("idActividad") = idNuevaTarea()
				query = " INSERT INTO ACTIVIDAD (IDACTIVIDAD, FECHAINICIAL, FECHAFINAL, DESCRIPCION, IDUSUARIO, IDTIPOPROGRESO, IDPRIORIDAD)"
				query &= " VALUES( " & ViewState("idActividad") & ",TO_DATE(" & util.Send(TxtFechaInicial.Text.ToString) & ",'RR-MM-DD'), TO_DATE(" & util.Send(txtFechaFinal.Text.ToString) & ",'RR-MM-DD'),"
				query &= util.Send(txtActividad.Text) & "," & cboUsuario.SelectedValue & "," & cboTipoProgreso.SelectedValue & "," & cboPrioridad.SelectedValue & " )"
				util.ExecuteSQLQuery(query)
			End If

			query = " INSERT INTO BITACORA (IDBITACORA, FECHACREACION, IDACTIVIDAD, IDTIPOPROGRESO, IDPRIORIDAD, FECHAINICIAL, FECHAFINAL, DESCRIPCION,IDUSUARIO)"
			query &= " VALUES( " & idNuevaBitacora() & ",TO_DATE(" & util.Send(Date.Now.ToString("yyyy-MM-dd HH:mm:ss")) & ",'RR-MM-DD HH24:mi:ss'),"
			query &= ViewState("idActividad") & "," & cboTipoProgreso.SelectedValue & "," & cboPrioridad.SelectedValue
			query &= ",TO_DATE(" & util.Send(TxtFechaInicial.Text.ToString) & ",'RR-MM-DD'), TO_DATE(" & util.Send(txtFechaFinal.Text.ToString) & ",'RR-MM-DD'),"
			query &= util.Send(txtActividad.Text) & "," & cboUsuario.SelectedValue & " )"
			util.ExecuteSQLQuery(query)

			limpiarCampos()
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub

	Private Function idNuevaTarea() As Integer
		Dim id As String = util.ConsultarEscalar("SELECT  MAX(IDACTIVIDAD) AS Actividad FROM  ACTIVIDAD")
		If String.IsNullOrEmpty(id) Then
			id = "1"
		Else
			id = CInt(id) + 1
		End If

		Return CInt(id)
	End Function


	Private Function idNuevaBitacora() As Integer
		Dim id As String = util.ConsultarEscalar("SELECT  MAX(IDBITACORA) AS Bitacora FROM  BITACORA")
		If String.IsNullOrEmpty(id) Then
			id = "1"
		Else
			id = CInt(id) + 1
		End If

		Return CInt(id)
	End Function

	Private Sub limpiarCampos()
		Try
			TxtFechaInicial.Text = Date.Now.ToString("yyyy-MM-dd")
			txtFechaFinal.Text = Date.Now.ToString("yyyy-MM-dd")
			txtActividad.Text = ""
			lblTitulo.Text = "Grabar"
			ViewState("idActividad") = 0

		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub
End Class