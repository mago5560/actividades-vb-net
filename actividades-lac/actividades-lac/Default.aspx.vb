Public Class _Default
    Inherits System.Web.UI.Page
	Dim util As New clsFunciones
	Dim query As String
	Dim tableDefault As DataTable
	Dim rowDefault As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then
				fillDatos()
				buscar()
			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub

	Private Sub fillDatos()
		lblTotalActividades.Text = totalActividades()
		lblActividadesNoIniciadas.Text = totalProgreso(1)
		lblActividadesIniciadas.Text = totalProgreso(2)
		lblActividadesFinalizadas.Text = totalProgreso(3)
	End Sub

	Private Function totalActividades() As String
		query = ""
		query = " SELECT        COUNT(ACTIVIDAD.IDACTIVIDAD) AS Total"
		query &= " FROM ACTIVIDAD, USUARIO, TIPODEUSUARIO, RELACIONTIPOUSUARIO "
		query &= " WHERE     ACTIVIDAD.IDUSUARIO = USUARIO.IDUSUARIO AND USUARIO.IDTIPODEUSUARIO = TIPODEUSUARIO.IDTIPODEUSUARIO AND TIPODEUSUARIO.IDTIPODEUSUARIO = RELACIONTIPOUSUARIO.TIPOUSUARIOHIJO  "
		query &= " AND (RELACIONTIPOUSUARIO.TIPOUSUARIOPADRE = " & Session("idtipodeusuario") & ")"
		Return util.ConsultarEscalar(query)
	End Function

	Private Function totalProgreso(ByVal idProgreso As Integer) As String
		query = ""
		query = " SELECT        COUNT(ACTIVIDAD.IDACTIVIDAD) AS Total"
		query &= " FROM ACTIVIDAD, USUARIO, TIPODEUSUARIO, RELACIONTIPOUSUARIO "
		query &= " WHERE     ACTIVIDAD.IDUSUARIO = USUARIO.IDUSUARIO AND USUARIO.IDTIPODEUSUARIO = TIPODEUSUARIO.IDTIPODEUSUARIO AND TIPODEUSUARIO.IDTIPODEUSUARIO = RELACIONTIPOUSUARIO.TIPOUSUARIOHIJO  "
		query &= " AND (RELACIONTIPOUSUARIO.TIPOUSUARIOPADRE = " & Session("idtipodeusuario") & ")"
		query &= " AND (ACTIVIDAD.IDTIPOPROGRESO = " & idProgreso & ")"
		Return util.ConsultarEscalar(query)
	End Function


	Private Sub buscar()
		Try
			query = ""
			query = " SELECT ACTIVIDAD.IDACTIVIDAD, ACTIVIDAD.FECHAINICIAL, ACTIVIDAD.FECHAFINAL, ACTIVIDAD.DESCRIPCION, USUARIO.NOMBRE AS USUARIO, TIPODEUSUARIO.DESCRIPCION AS TIPODEUSUARIO, "
			query &= " TIPOPROGRESO.DESCRIPCION AS TIPODEPROGRESO, PRIORIDAD.DESCRIPCION AS PRIORIDAD "
			query &= " FROM            ACTIVIDAD, USUARIO, TIPODEUSUARIO, RELACIONTIPOUSUARIO, TIPOPROGRESO, PRIORIDAD "
			query &= " WHERE        ACTIVIDAD.IDUSUARIO = USUARIO.IDUSUARIO AND USUARIO.IDTIPODEUSUARIO = TIPODEUSUARIO.IDTIPODEUSUARIO AND TIPODEUSUARIO.IDTIPODEUSUARIO = RELACIONTIPOUSUARIO.TIPOUSUARIOHIJO "
			query &= " AND ACTIVIDAD.IDTIPOPROGRESO = TIPOPROGRESO.IDTIPOPROGRESO AND ACTIVIDAD.IDPRIORIDAD = PRIORIDAD.IDPRIORIDAD "
			query &= " AND (RELACIONTIPOUSUARIO.TIPOUSUARIOPADRE = " & Session("idtipodeusuario") & ")"

			grdDatos.DataSource = util.ConsultarTabla(query)
			grdDatos.DataBind()
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub
End Class