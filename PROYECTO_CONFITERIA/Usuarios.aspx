<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PROYECTO_CONFITERIA.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function mostrarModal(x) {
            $(x).modal('show');
        }
    </script>
    <hr />
    <h2 class="logo">Usuarios</h2>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Nombre Usuario" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control bg-white" ID="txtNombreUsuario" placeholder="" />
        </div>
        <div class="form-group col-md-4">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" type="password" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label Text="Rol Usuario" runat="server" />
            <asp:DropDownList ID="cboRolUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:Label ID="lblSeleccioneRol" Text="Seleccione un Rol" Visible="false" runat="server" />
        </div>
        <div class="row">
            <div class="form-group col-md-4">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Registrar Usuario" runat="server" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" OnClientClick="Validar();" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <hr />
        <h2 class="logo">Listado de Usuarios</h2>
        <br />
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <div class="row justify-content-center">
                    <div class="table col-auto">
                        <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="false" CssClass="text-center table-hover" OnRowCommand="gvUsuarios_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="idUsuario" HeaderText="ID USUARIO" />
                                <asp:BoundField DataField="nombreUsuario" HeaderText="NOMBRE USUARIO" />
                                <asp:BoundField DataField="pass" HeaderText="PASSWORD" />
                                <asp:BoundField DataField="idRolUsuario" HeaderText="ROL USUARIO" />
                                <asp:TemplateField HeaderText="ACCIONES">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idUsuario") %>' Text="EDITAR" CssClass="btn btn-warning" OnClientClick="mostrarModal('#staticBackdrop');" />
                                        <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idUsuario") %>' Text="ELIMINAR" CssClass="btn btn-danger"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Modal USUARIOS -->

        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content" style="background-color: #f2f2f2;">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Modificar Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <asp:Label runat="server" ID="lblNomUsu" Text="Nombre Usuario"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtNombreUsuarioModificar" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <asp:Label runat="server" ID="lblPass" Text="Password"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtPassModificar" CssClass="form-control" type="password"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <asp:Label runat="server" ID="lblRol" Text="Rol Usuario"></asp:Label>
                                            <asp:DropDownList ID="cboRolUsuarioModificar" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificar" ID="btnModificarUsuario" OnClick="btnModificarUsuario_Click"></asp:Button>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" OnClientClick="CerrarModal();" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>
                </div>
            </div>
        </div>
         <!-- Modal USUARIOS -->

        <script>
            function Validar() {
                let nombre = document.getElementById('<%=txtNombreUsuario.ClientID%>').value;
                let pass = document.getElementById('<%=txtPassword.ClientID%>').value;
                if (nombre === "" || nombre === undefined) {
                    swal("Ingrese Nombre de Usuario");
                    nombre.focus();
                }
                if (pass === "" || pass === undefined) {
                    swal("Ingrese Password");
                    pass.focus();
                }
            }
            function CerrarModal() {
                $('#staticBackdrop').modal('hide');
            }

            function MsjDebeIngresarTodosLosDatos() {
                swal("Error", "Debe ingresar todos los datos", "error");
            }
            function RegistroExitoso() {
                swal("Éxito", "Registro Exitoso!", "success")
            }
            //function ConfirmDelete() {
            //    var x = swal("Esta seguro que desea Eliminar?");
            //    if (x)
            //        return true;
            //    else
            //        return false;
            //}
            //function funcionModal() {
            //    swal({
            //        title: "Eliminar Usuario",
            //        text: "¿Desea eliminar un Usuario?",
            //        icon: "warning",
            //        buttons: true,
            //        dangerMode: true,
            //    })
            //        .then((willDelete) => {
            //            if (willDelete) {
            //                swal("Usuario Eliminado", {
            //                    icon: "success",
            //                });
            //                return true;

            //            } else {
            //                return false;
            //            }
            //        });
            //}
        </script>
       
</asp:Content>
