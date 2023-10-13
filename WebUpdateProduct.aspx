<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebUpdateProduct.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebUpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" href="plugins/datatables-bs4/css/dataTables.bootstrap4.min.css">
  <link rel="stylesheet" href="plugins/datatables-responsive/css/responsive.bootstrap4.min.css">
  <link rel="stylesheet" href="plugins/datatables-buttons/css/buttons.bootstrap4.min.css">
    <style>
        .required {
          border: 1px solid #ccc;
        }
        .required.error {
          border: 1px solid red;
        }
        .selected-row {
          background-color: #ffcc66; /* Color de fondo para la fila seleccionada */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
    <div class="form-box">

    <section class="content-header">
        <h1 style="color:white; font-family:Oswald; font-size:30px;">C A T E G O R Í A</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administración Categoría</h3>
                  </div>
                  <!-- /.card-header -->
                  <!-- form start -->
                  <div class="card-body">
                      <div class="form-group">
                          <asp:Label runat="server">Nombre</asp:Label>
                          <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required"  placeholder="Ingrese nombre" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                          </asp:TextBox>
                        </div>
                        <div class="form-group">
                          <asp:Label runat="server">Precio Base</asp:Label>
                          <asp:TextBox ID="txtBasePrice" MaxLength="80" runat="server" class="form-control required" placeholder="Ingrese el precio" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <asp:Label runat="server">Stock</asp:Label>
                          <asp:TextBox ID="TxtStock" MaxLength="80" runat="server" class="form-control required" placeholder="Ingrese el stock" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server">Unidad de medida</asp:Label>
                            <asp:TextBox ID="TxtMeasureUnit" MaxLength="80" runat="server" class="form-control required" placeholder="Ingrese la medida" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                          </div>
                        <div class="form-group col-md-4">
                              <asp:Label runat="server">Marca</asp:Label>
                              <asp:DropDownList ID="cmbBrand" runat="server" class="form-control required"></asp:DropDownList>
                          </div>
                          <div class="form-group col-md-4">
                              <asp:Label runat="server">Categoria</asp:Label>
                              <asp:DropDownList ID="cmbCategory" runat="server" class="form-control required"></asp:DropDownList>
                          </div>
                        <div class="form-group">
                              <asp:Label runat="server">Modelo</asp:Label>
                              <asp:TextBox ID="TxtModel" MaxLength="80" runat="server" class="form-control required" placeholder="Ingrese el modelo" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                            </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmCategory.aspx'>Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </section>

    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
        <!-- DataTables  & Plugins -->
<script src="plugins/datatables/jquery.dataTables.min.js"></script>
<script src="plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"></script>
<script src="plugins/datatables-responsive/js/dataTables.responsive.min.js"></script>
<script src="plugins/datatables-responsive/js/responsive.bootstrap4.min.js"></script>
<script src="plugins/datatables-buttons/js/dataTables.buttons.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.bootstrap4.min.js"></script>
<script src="plugins/jszip/jszip.min.js"></script>
<script src="plugins/pdfmake/pdfmake.min.js"></script>
<script src="plugins/pdfmake/vfs_fonts.js"></script>
<script src="plugins/datatables-buttons/js/buttons.html5.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.print.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.colVis.min.js"></script>

    <!-- Page specific script -->
<script>
    $(function () {
        $('#example2').DataTable({
            "paging": true,
            "lengthChange": false,
            "searching": false,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "responsive": true,
        });
    });
</script>

    <script>
        function validateTextInput(event) {
            var key = event.keyCode || event.which;
            var keyChar = String.fromCharCode(key);

            // Expresión regular para permitir letras con tilde y la letra "ñ"
            var regex = /^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]*$/;

            // Verifica si la tecla presionada es una letra con tilde, la letra "ñ" o un espacio
            if (!regex.test(keyChar)) {
                event.preventDefault();
                return false;
            }
        }

        function removeExtraSpaces(textInput) {
            textInput.value = textInput.value.replace(/\s{2,}/g, ' ');
        }

        function removeLeadingTrailingSpaces(textInput) {
            textInput.value = textInput.value.trim();
        }

        function validateSpaces(textInput) {
            textInput.value = textInput.value.replace(/^\s+|\s+$/g, '');
        }
    </script>
    <script>
        document.getElementById('<%= btnModificar.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDescription = document.getElementById('<%= TxtModel.ClientID %>');

            // Verificar si los campos requeridos están vacíos
            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                return false; // Evitar el envío del formulario
            }

            if (txtDescription.value.trim() === '') {
                txtDescription.classList.add('error');
                return false; // Evitar el envío del formulario
            }
        };

    </script>
</asp:Content>
