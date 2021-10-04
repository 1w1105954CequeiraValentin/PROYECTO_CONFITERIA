<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Mozos.aspx.cs" Inherits="PROYECTO_CONFITERIA.Mozos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal(x) {
            $(x).modal('show');
        }
    </script>
    <hr />
    <h2 class="logo">Mozos</h2>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Documento" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control bg-white" ID="txtDocumento" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Nombre" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Apellido" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Comision" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtComision" />
        </div>
    </div>
    <%--<div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Fecha Ingreso" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaIngreso" />
        </div>
    </div>--%>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Button Text="Registrar Mozo" runat="server" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
        </div>
    </div>
    <hr />
    <h2 class="logo">Listado de Mozos</h2>
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="table col-auto">
                    <asp:GridView runat="server" ID="gvMozos" AutoGenerateColumns="false" CssClass="text-center table-hover" OnRowCommand="gvMozos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idMozo" HeaderText="ID MOZO" />
                            <asp:BoundField DataField="nroDoc" HeaderText="NRO. DOCUMENTO" />
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="apellido" HeaderText="APELLIDO" />
                            <asp:BoundField DataField="comision" HeaderText="COMISION(%)" />
                            <asp:BoundField DataField="fechaIngreso" HeaderText="FECHA INGRESO" />
                            <asp:TemplateField HeaderText="ACCIONES">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idMozo") %>' Text="EDITAR" CssClass="btn btn-warning" OnClientClick="mostrarModal('#staticBackdrop');" />
                                    <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idMozo") %>' Text="ELIMINAR" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

        <!-- Modal Mozos -->

    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="background-color: #f2f2f2;">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Modificar Mozo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblNroDoc" Text="Nro. Documento"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNroDocModificar" CssClass="form-control " placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblNombre" Text="Nombre"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNombreModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblApellido" Text="Precio del Articulo"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtApellidoModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblComision" Text="Comisión"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtComisionModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>
                                    <%--<div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblFechaIngreso" Text="Fecha Ingreso"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtFechaModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>--%>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificar" ID="btnModificarMozo" OnClick="btnModificarMozo_Click"></asp:Button>

                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Mozos -->
</asp:Content>
