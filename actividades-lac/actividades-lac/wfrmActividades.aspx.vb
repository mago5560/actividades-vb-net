Imports Oracle.DataAccess.Client

Public Class wfrmActividades
	Inherits System.Web.UI.Page
	Dim util As New clsFunciones
	Dim query As String
	Dim tableDefault As DataTable
	Dim rowDefault As DataRow

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then
				fillCombos(Cache, cboPrioridad, Application, , , True, )
				fillCombos(Cache, cboTipoProgreso, Application, , , True, )

				buscar()
			End If
		Catch ex As Exception
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


	Private Sub buscar()
		Try

			query = ""
			query = " SELECT ACTIVIDAD.IDACTIVIDAD, ACTIVIDAD.FECHAINICIAL, ACTIVIDAD.FECHAFINAL, ACTIVIDAD.DESCRIPCION, TIPOPROGRESO.IDTIPOPROGRESO, TIPOPROGRESO.DESCRIPCION AS IDTIPOPROGRESODESCRIPCION, "
			query &= "  USUARIO.IDUSUARIO, USUARIO.NOMBRE AS IDUSUARIODESCRIPCION, PRIORIDAD.IDPRIORIDAD, PRIORIDAD.DESCRIPCION AS IDPRIORIDADDESCRIPCION "
			query &= "  FROM  ACTIVIDAD, TIPOPROGRESO, USUARIO, PRIORIDAD "
			query &= " WHERE ACTIVIDAD.IDTIPOPROGRESO = TIPOPROGRESO.IDTIPOPROGRESO AND ACTIVIDAD.IDUSUARIO = USUARIO.IDUSUARIO AND ACTIVIDAD.IDPRIORIDAD = PRIORIDAD.IDPRIORIDAD "
			query &= " AND USUARIO.IDUSUARIO = " & Session("idusuario")
			If Not util.F_Null(txtFecha.Text.ToString) Then
				query &= " AND TO_DATE(" & util.Send(txtFecha.Text.ToString) & ",'RR-MM-DD') BETWEEN ACTIVIDAD.FECHAINICIAL AND  ACTIVIDAD.FECHAFINAL "
			End If

			If Not util.F_Null(cboTipoProgreso.SelectedValue) Then
				query &= " AND ACTIVIDAD.IDTIPOPROGRESO = " & cboTipoProgreso.SelectedValue
			End If

			If Not util.F_Null(cboPrioridad.SelectedValue) Then
				query &= " AND ACTIVIDAD.IDPRIORIDAD = " & cboPrioridad.SelectedValue
			End If

			If Not util.F_Null(txtIdActividad.Text) Then
				query &= " AND ACTIVIDAD.IDACTIVIDAD = " & txtIdActividad.Text.ToString
			End If

			grdDatos.DataSource = util.ConsultarTabla(query)
			grdDatos.DataBind()

		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub

	Private Sub btnBuscar_ServerClick(sender As Object, e As System.EventArgs) Handles btnBuscar.ServerClick
		buscar()
	End Sub
End Class