Public Class wfrmBitacora
    Inherits System.Web.UI.Page
	Dim util As New clsFunciones
	Dim query As String
	Dim tableDefault As DataTable
	Dim rowDefault As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then

				buscar()
			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
    End Sub


	Private Sub buscar()
		Try

			query = ""
			query = " SELECT BITACORA.IDBITACORA, BITACORA.IDACTIVIDAD, BITACORA.FECHAINICIAL, BITACORA.FECHAFINAL, BITACORA.DESCRIPCION, TIPOPROGRESO.IDTIPOPROGRESO, TIPOPROGRESO.DESCRIPCION AS IDTIPOPROGRESODESCRIPCION, "
			query &= "  USUARIO.IDUSUARIO, USUARIO.NOMBRE AS IDUSUARIODESCRIPCION, PRIORIDAD.IDPRIORIDAD, PRIORIDAD.DESCRIPCION AS IDPRIORIDADDESCRIPCION , BITACORA.FECHACREACION"
			query &= "  FROM  BITACORA, TIPOPROGRESO, USUARIO, PRIORIDAD , RELACIONTIPOUSUARIO "
			query &= " WHERE BITACORA.IDTIPOPROGRESO = TIPOPROGRESO.IDTIPOPROGRESO AND BITACORA.IDUSUARIO = USUARIO.IDUSUARIO AND BITACORA.IDPRIORIDAD = PRIORIDAD.IDPRIORIDAD AND USUARIO.IDTIPODEUSUARIO = RELACIONTIPOUSUARIO.TIPOUSUARIOHIJO "
			query &= " AND RELACIONTIPOUSUARIO.TIPOUSUARIOPADRE = " & Session("idtipodeusuario")
			
			If Not util.F_Null(txtIdActividad.Text) Then
				query &= " AND BITACORA.IDACTIVIDAD = " & txtIdActividad.Text.ToString
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