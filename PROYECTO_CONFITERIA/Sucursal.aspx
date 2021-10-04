<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Sucursal.aspx.cs" Inherits="PROYECTO_CONFITERIA.Sucursal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal(x) {
            $(x).modal('show');
        }
    </script>
    <hr />
    <h2 class="logo">Sucursal</h2>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Direccion" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control bg-white" ID="txtDireccion" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Razón Social" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtRazonSocial" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Nro. Cuit" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCuit" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Ing. Brutos" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtIngresosBrutos" />           
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Tipo Iva" runat="server" />
            <asp:DropDownList ID="cboTipoIva" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Button Text="Registrar Sucursal" runat="server" CssClass="btn btn-primary" ID="btnRegistrar" />
        </div>
    </div>
    <hr />
    <h2 class="logo">Listado de Sucursales</h2>
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="table col-auto">
                    <asp:GridView runat="server" ID="gvSucursales" AutoGenerateColumns="false" CssClass="text-center table-hover" OnRowCommand="gvSucursales_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idSucursal" HeaderText="ID SUCURSAL" />
                            <asp:BoundField DataField="direccion" HeaderText="DIRECCIÓN" />
                            <asp:BoundField DataField="razonSocial" HeaderText="RAZÓN SOCIAL" />
                            <asp:BoundField DataField="nroCuit" HeaderText="NRO. CUIT" />
                            <asp:BoundField DataField="idTipoIva" HeaderText="TIPO IVA" />
                            <asp:TemplateField HeaderText="ACCIONES">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idSucursal") %>' Text="EDITAR" CssClass="btn btn-warning" OnClientClick="mostrarModal('#staticBackdrop');" />
                                    <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idSucursal") %>' Text="ELIMINAR" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal Sucursal -->

    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="background-color: #f2f2f2;">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Modificar Sucursal</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblDireccion" Text="Direccion"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDireccionModificar" CssClass="form-control " placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblRazonSocial" Text="Razón Social"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtRazonSocialModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblNroCuit" Text="Nro. Cuit"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCuitModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Label runat="server" ID="lblTipoIva" Text="Tipo Iva"></asp:Label>
                                        <asp:DropDownList ID="cboTipoIvaModificar" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificar" ID="btnModificarArticulo"></asp:Button>

                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger"/>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Sucursal -->
</asp:Content>
