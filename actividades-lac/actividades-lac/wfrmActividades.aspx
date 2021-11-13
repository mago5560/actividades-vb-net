<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
	CodeBehind="wfrmActividades.aspx.vb" Inherits="actividades_lac.wfrmActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1 class="h3 mb-4 text-gray-800">
		Actividades</h1>
	<!-- Begin Page Content -->
	<div class="container-fluid">
		<!-- DataTales Example -->
		<form id="Form1" class="user" runat="server">
		<div class="card shadow mb-4">
			<div class="card-header py-3">
				<h6 class="m-0 font-weight-bold text-primary">
					Filtro</h6>
			</div>
			<div class="card-body">
				<div class="row">
					<div class="col-sm-12 col-md-4 col-lg-4">
						<div class="form-group">
							<label>
								Fecha</label>
							<asp:TextBox ID="txtFecha" type="date" runat="server" PlaceHolder="dia/Mes/año"
								CssClass="form-control fecha datepicker" Width="100%"></asp:TextBox>
						</div>
					</div>
					<div class="col-sm-12 col-md-4 col-lg-4">
						<div class="form-group">
							<label>
								Prioridad</label>
							<asp:DropDownList ID="cboPrioridad" runat="server" CssClass="form-control" Width="100%">
							</asp:DropDownList>
						</div>
					</div>
						<div class="col-sm-12 col-md-4 col-lg-4">
						<div class="form-group">
							<label>
								Progreso</label>
							<asp:DropDownList ID="cboTipoProgreso" runat="server" CssClass="form-control" Width="100%">
							</asp:DropDownList>
						</div>
					</div>
				</div>
				<div class="row">
				
					<div class="col-sm-12 col-md-4 col-lg-4">
						<div class="form-group">
							<label>
								Actividad Id</label>
							<asp:TextBox ID="txtIdActividad" type="number" runat="server" CssClass="form-control"
								Width="100%"></asp:TextBox>
						</div>
					</div>
					<div class="col-sm-12 col-md-4 col-lg-4">
						<div class="form-group">
						<br />
								<a id="btnBuscar" runat="server" type="button" class="btn btn-primary btn-user btn-block">
								Buscar </a>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="card shadow mb-4">
			<div class="card-header py-3">
				<h6 class="m-0 font-weight-bold text-primary">
					Actividades Creada</h6>
			</div>
			<div class="card-body">
				<div class="table-responsive">
					<asp:GridView class="table table-bordered" ID="grdDatos" Width="100%" runat="server"
						AutoGenerateColumns="False">
						<Columns>
							<asp:TemplateField HeaderText="Id" SortExpression="IDACTIVIDAD">
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IDACTIVIDAD") %>'></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "wfrmNuevaActividad.aspx?IdActividad=" & Eval("IDACTIVIDAD") %>'
										Text='<%# Bind("IDACTIVIDAD") %>'></asp:HyperLink>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:BoundField DataField="FECHAINICIAL" HeaderText="Fecha Inicial" SortExpression="FECHAINICIAL"
								DataFormatString="{0:d}" />
							<asp:BoundField DataField="FECHAFINAL" HeaderText="Fecha Final" SortExpression="FECHAFINAL"
								DataFormatString="{0:d}" />
							<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" SortExpression="DESCRIPCION" />
							<asp:BoundField DataField="IDUSUARIO" HeaderText="Id Usuario" SortExpression="IDUSUARIO" />
							<asp:BoundField DataField="IDUSUARIODESCRIPCION" HeaderText="Usuario" SortExpression="IDUSUARIODESCRIPCION" />
							<asp:BoundField DataField="IDTIPOPROGRESO" HeaderText="Id Progreso" SortExpression="IDTIPOPROGRESO" />
							<asp:BoundField DataField="IDTIPOPROGRESODESCRIPCION" HeaderText="Progreso" SortExpression="IDTIPOPROGRESODESCRIPCION" />
							<asp:BoundField DataField="IDPRIORIDAD" HeaderText="Id Prioridad" SortExpression="IDPRIORIDAD" />
							<asp:BoundField DataField="IDPRIORIDADDESCRIPCION" HeaderText="Prioridad" SortExpression="IDPRIORIDADDESCRIPCION" />
						</Columns>
					</asp:GridView>
				</div>
			</div>
		</div>
		</form>
	</div>
	<!-- /.container-fluid -->
</asp:Content>
