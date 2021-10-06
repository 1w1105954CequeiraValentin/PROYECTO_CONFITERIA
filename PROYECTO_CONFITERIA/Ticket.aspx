<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="PROYECTO_CONFITERIA.Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal(x) {
            $(x).modal('show');
        }
    </script>
    <hr />
    <h2 class="logo">Ticket</h2>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Artículo" runat="server" />
            <asp:DropDownList ID="cboArticulo" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboArticulo_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Cantidad" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCantidad" type="" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Mozo" runat="server" />
            <asp:DropDownList ID="cboMozo" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Button Text="Generar Detalle" runat="server" CssClass="btn btn-primary" ID="btnGenerarTicket" OnClick="btnGenerarTicket_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <h2 class="logo">Detalle de Ticket</h2>
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="table col-auto">
                    <asp:GridView runat="server" ID="gvDetalle" AutoGenerateColumns="true" CssClass="text-center table-hover" OnRowCommand="gvDetalle_RowCommand">
                        <Columns>
                            <%-- <asp:BoundField DataField="Codigo Articulo" HeaderText="Cod" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio Unitario" HeaderText="Precio Unitario" />
                                <asp:BoundField DataField="Importe" HeaderText="Importe" />--%>
                            <%--  <asp:TemplateField HeaderText="ACCIONES">--%>
                            <%-- <<%--ItemTemplate>
                                        <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idUsuario") %>' Text="EDITAR" CssClass="btn btn-warning" OnClientClick="mostrarModal('#staticBackdrop');" />
                                        <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idUsuario") %>' Text="ELIMINAR" CssClass="btn btn-danger" />
                                    </ItemTemplate>--%>
                            <%--</asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    <div class="row">
                        <div class="form-group col-md-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button Text="Generar Ticket" runat="server" CssClass="btn btn-primary" ID="btnCobrar" OnClick="btnCobrar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
