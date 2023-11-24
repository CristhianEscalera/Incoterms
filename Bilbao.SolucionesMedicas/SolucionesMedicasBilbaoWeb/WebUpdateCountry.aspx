<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebUpdateCountry.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebUpdateCountry" %>
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">P A Í S</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administracion País</h3>
                  </div>
                  <div class="card-body">
                      <span id="txtError" class="error-message" style="color:red;"></span>
                      <div class="form-group">
                        <asp:Label runat="server">Nombre</asp:Label>
                        <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required"  placeholder="Ingrese nombre" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                    </div>

                    <div class="card-footer">
                        <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmCountry.aspx'>Cancelar</a>
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
    <script>
        function validateTextInput(event) {
            var key = event.keyCode || event.which;
            var keyChar = String.fromCharCode(key);

            var regex = /^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]*$/;

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
           

           if (txtName.value.trim() === '') {
               txtName.classList.add('error');
               return false; 
           }

       };

    </script>
</asp:Content>
