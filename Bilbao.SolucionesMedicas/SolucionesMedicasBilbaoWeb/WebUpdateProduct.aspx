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
                  <div class="card-body">
                    <span id="txtError" class="error-message" style="color:red;"></span>
                    <div class="form-group">
                      <asp:Label runat="server">Nombre</asp:Label>
                      <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required"  placeholder="Ingrese nombre" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                      </asp:TextBox>
                    </div>
                    <div class="form-group">
                      <asp:Label runat="server">Precio Base</asp:Label>
                     <asp:TextBox ID="txtPrecio" MaxLength="12" runat="server" class="form-control required" placeholder="Ingrese el Precio" onkeypress="return validateInput(event, this);" onkeyup="removeExtraSpaces(this);">
                      </asp:TextBox>
                    </div>
                    <div class="form-group">
                      <asp:Label runat="server">Stock</asp:Label>
                      <asp:TextBox ID="TxtStock" MaxLength="8" runat="server" class="form-control required" placeholder="Ingrese el stock" onkeypress="validarNum(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server">Unidad de medida</asp:Label>
                        <asp:TextBox ID="TxtMeasureUnit" MaxLength="8" runat="server" class="form-control required" placeholder="Ingrese la medida" onkeypress="validarNum(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                      </div>
                      <asp:Label runat="server">Marca</asp:Label>
                      <div class="row">
                          <div class="form-group col-md-6">
                                <asp:DropDownList ID="cmbBrand" runat="server" class="form-control required"></asp:DropDownList>
                           </div>
                          <div class="form-group col-md-6">
                               <a class="btn btn-block btn-info btn-lg" href='WebAdmBrand.aspx'>Agregar nueva marca</a>
                         </div>
                      </div>
                      <asp:Label runat="server">Categoria</asp:Label>
                      <div class ="row">
                          <div class="form-group col-md-6">
                            <asp:DropDownList ID="cmbCategory" runat="server" class="form-control required"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                             <a class="btn btn-block btn-info btn-lg" href='WebAdmCategory.aspx'>Agregar nueva categoria</a>
                       </div>
                    </div>
                    <div class="form-group">
                          <asp:Label runat="server">Modelo</asp:Label>
                          <asp:TextBox ID="TxtModel" MaxLength="80" runat="server" class="form-control required" placeholder="Ingrese el modelo" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="card-footer">
                        <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmProduct.aspx'>Cancelar</a>
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

     function validateInput(event, textBox) {
         var value = textBox.value;
         var allowedCharacters = /[0-9,]/;

         if (!allowedCharacters.test(event.key)) {
             event.preventDefault();
             return false;
         }

         if (event.key === ',') {
             if (value.includes(',')) {
                 event.preventDefault();
                 return false;
             }
         } else if (event.key === '0' && value.includes(',')) {
             var parts = value.split(',');
             if (parts.length > 1 && parts[1].length >= 2) {
                 event.preventDefault();
                 return false;
             }
         } else if (value.length >= 10 && !value.includes(',')) {
             event.preventDefault();
             return false;
         }

         if (parseFloat(value.replace(',', '.')) <= 0) {
             event.preventDefault();
             return false;
         }
         return true;
     }


     function removeExtraSpaces(textBox) {
         textBox.value = textBox.value.replace(/\s+/g, ' ').trim();
     }

     function validateTelefono(textbox) {
         var minCaracteres = 7;
         var telefono = textbox.value.trim();

         if (telefono.length < minCaracteres) {
             textbox.style.borderColor = 'red';
         } else {
             textbox.style.borderColor = '';
         }
     }

     function disallowSpaces(event) {
         var key = event.key;

         if (key === " ") {
             event.preventDefault();
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
    function removeExtraSpaces2(element) {
        var phoneNumber = element.value.trim();
        var phoneNumberWithoutExtraSpaces = phoneNumber.replace(/\s{2,}/g, ' ');
        var phoneNumberPattern = /^(\+)?(\d|\s)*$/;

        if (!phoneNumberPattern.test(phoneNumberWithoutExtraSpaces)) {
            element.classList.add('error');
        } else {
            element.classList.remove('error');
            element.value = phoneNumberWithoutExtraSpaces;
        }
    }
</script>
 <script>
     document.getElementById('<%= btnModificar.ClientID %>').onclick = function () {
         var txtName = document.getElementById('<%= txtName.ClientID %>');
         var txtprecio = document.getElementById('<%= txtPrecio.ClientID %>');
         var txtUnidadMedida = document.getElementById('<%= TxtMeasureUnit.ClientID %>');
         var txtStock = document.getElementById('<%= TxtStock.ClientID %>');
         var txtModel = document.getElementById('<%= TxtModel.ClientID %>');
         var txtDescriptionError = document.getElementById('txtError');
         if (txtName.value.trim() === '') {
             txtName.classList.add('error');
             txtDescriptionError.textContent = 'Ingrese Nombre del producto';
             return false;
         }

         if (txtprecio.value.trim() === '') {
             txtprecio.classList.add('error');
             txtDescriptionError.textContent = 'Ingrese un precio valido';
             return false;
         } else {
             var precio = txtprecio.value.trim();
             if (/^[0-9]+(,[0-9]*)?$/.test(precio)) {
                 var parts = precio.split(",");
                 if (parts[0].length > 10 || parseFloat(precio.replace(",", ".")) <= 0) {
                     txtprecio.classList.add('error');
                     txtDescriptionError.textContent = 'El precio ingresado no es válido';
                     return false;
                 }
             } else {
                 txtprecio.classList.add('error');
                 txtDescriptionError.textContent = 'El precio ingresado no es válido';
                 return false;
             }
         }
         if (txtUnidadMedida.value.trim() === '') {
             txtUnidadMedida.classList.add('error');
             txtDescriptionError.textContent = 'Ingrese una unidad de medida';
             return false;
         }
         if (txtStock.value.trim() === '') {
             txtStock.classList.add('error');
             txtDescriptionError.textContent = 'Ingrese un Stock';
             return false;
         }
         if (txtModel.value.trim() === '') {
             txtModel.classList.add('error');
             txtDescriptionError.textContent = 'Ingrese un Modelo';
             return false;
         }
     };

 </script>
</asp:Content>
