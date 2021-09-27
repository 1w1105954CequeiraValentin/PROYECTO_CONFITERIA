<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="PROYECTO_CONFITERIA.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idArticulo" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="idArticulo" HeaderText="idArticulo" InsertVisible="False" ReadOnly="True" SortExpression="idArticulo" />
        <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
        <asp:BoundField DataField="stock" HeaderText="stock" SortExpression="stock" />
        <asp:BoundField DataField="precio_articulo" HeaderText="precio_articulo" SortExpression="precio_articulo" />
        <asp:BoundField DataField="idRubro" HeaderText="idRubro" SortExpression="idRubro" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConfiteriaConnectionString %>" SelectCommand="SELECT * FROM [ARTICULOS]"></asp:SqlDataSource>
    


</asp:Content>
