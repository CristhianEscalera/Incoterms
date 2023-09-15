<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewShipper.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewShipper" %>
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
     <form id="form2" runat="server">
        <div class="form-box">

        <section class="content-header">
            <h1 style="color:white; font-family:Oswald; font-size:30px;">E M B A R C A D O R</h1>
        </section>

        <section class="content">
            <div class="row">
             <div class="col-md-12">
                <div class="box-body">
                   <div class="card card-primary">
                      <div class="card-header" style="background-color:#1B425E">
                        <h3 class="card-title">Administración Proveedor</h3>
                      </div>
                      <!-- /.card-header -->
                      <!-- form start -->
                      <div class="card-body">
                          <span id="txtError" class="error-message" style="color:red;"></span>
                          <div class="form-group">
                            <asp:Label runat="server">Nombre</asp:Label>
                            <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="row">
                              <div class="form-group col-md-6">
                                <asp:Label runat="server">Localizacion</asp:Label>
                                <asp:TextBox ID="txtLocalizacion" MaxLength="150" runat="server" class="form-control required" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                                </asp:TextBox>
                              </div>
                  
                              <div class="form-group col-md-6">
                                <asp:Label runat="server">Precio</asp:Label>
                                <asp:TextBox ID="txtPrecio" MaxLength="8" runat="server" class="form-control required"  onkeypress="return validateInput(event, this);" onkeyup="removeExtraSpaces(this);">
                                </asp:TextBox>
                              </div>
                         </div>
                          <div class="form-group">
                              <asp:Label runat="server">Tipo envio</asp:Label>
                              <asp:DropDownList ID="Envio" runat="server" class="form-control">
                                  <asp:ListItem Text="Aereo" Value="Aereo"></asp:ListItem>
                                  <asp:ListItem Text="Ferroviario" Value="Ferroviario"></asp:ListItem>
                                  <asp:ListItem Text="Maritimo" Value="Maritimo"></asp:ListItem>
                                  <asp:ListItem Text="Internacional Carretera" Value="Internacional Carretera"></asp:ListItem>
                              </asp:DropDownList>
                            </div>
                        <div class="card-footer">
                          <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnInsertar_Click"/>
                            <a class="btn btn-block btn-info btn-lg" href='WebAdmShipper.aspx'>Cancelar</a>
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
             } else if (value.length >= 5 && !value.includes(',')) {
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
         document.getElementById('<%= btnInsert.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtlocalizacion = document.getElementById('<%= txtLocalizacion.ClientID %>');
            var txtprecio = document.getElementById('<%= txtPrecio.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese el nombre del embarcador';
                return false; 
            }

            if (txtlocalizacion.value.trim() === '') {   
                txtlocalizacion.classList.add('error');        
                txtDescriptionError.textContent = 'Ingrese una dirección';
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
                     if (parts[0].length > 5 || parseFloat(precio.replace(",", ".")) <= 0) {
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
        };

    </script>
</asp:Content>
                                                                                           