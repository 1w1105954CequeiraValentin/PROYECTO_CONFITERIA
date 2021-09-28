<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="PROYECTO_CONFITERIA.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h2 class="logo">Articulos</h2>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Descripcion" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control bg-white" ID="txtDescripcion"/>
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Stock" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtStock" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Precio" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Rubro" runat="server" />
            <asp:DropDownList ID="cboRubroArticulo" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Button Text="Registrar Articulo" runat="server" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" ID="btnRegistrar"/>
        </div>
    </div>
    <hr />
    <h2 class="logo">Listado de Articulos</h2>
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="table col-auto">
                    <asp:GridView runat="server" ID="gvArticulos" AutoGenerateColumns="false" CssClass="text-center table-hover" OnRowCommand="gvArticulos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idArticulo" HeaderText="ID ARTICULO" />
                            <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                            <asp:BoundField DataField="stock" HeaderText="STOCK" />
                            <asp:BoundField DataField="precio_articulo" HeaderText="PRECIO" />
                            <asp:BoundField DataField="idRubro" HeaderText="RUBRO" />
                            <asp:TemplateField HeaderText="ACCIONES">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idArticulo") %>' Text="EDITAR" CssClass="btn btn-warning" />
                                    <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idArticulo") %>' Text="ELIMINAR" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
