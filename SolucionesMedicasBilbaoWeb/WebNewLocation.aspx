﻿<%@ Page Title="Nueva Dirección" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewLocation.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebAdmLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="leaflet/leaflet.css" />
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">D I R E C C I Ó N</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administración Dirección</h3>
                  </div>
                  <!-- /.card-header -->
                  <!-- form start -->
                   <div class="card-body">
                        <span id="txtError" class="error-message" style="color:red;"></span>
                        <div class="form-group">
                            <asp:Label runat="server">Dirección</asp:Label>
                            <asp:TextBox ID="txtNombreLugar" runat="server" class="form-control required" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-4">
                                <asp:Label runat="server">Cliente</asp:Label>
                                <asp:DropDownList ID="cmbCliente" runat="server" class="form-control required"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:Label runat="server">Municipalidad</asp:Label>
                                <asp:DropDownList ID="cmbMunicipalidad" runat="server" class="form-control required"></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:Label runat="server">Numero de casa</asp:Label>
                                <asp:TextBox ID="txtNum" MaxLength="4" runat="server" class="form-control required" placeholder="Ingrese numero de casa" onkeypress="validarCI(event)" onkeyup="removeExtraSpaces(this);">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:HiddenField ID="hdnLatitud" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:HiddenField ID="hdnLongitud" runat="server" />
                                </div>
                            </div>
                        </div>
                       <div class="form-group">
                            <div id="map" style="width: 100%; height: 300px;"></div>
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                            <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg" OnClick="btnInsertar_Click" />
                            <a class="btn btn-block btn-info btn-lg" href='WebAdmLocation.aspx'>Cancelar</a>
                        </div>
                    </div>
            </div>
        </div>
        </div>
    </section>

    </div>
    </form>
    <script src="leaflet/leaflet.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
   <script>
       // Código JavaScript para inicializar el mapa
       var map = L.map('map').setView([-17.4136, -66.1653], 13); // Centra el mapa en Bolivia y establece el nivel de zoom

       // Carga y muestra el mapa de teselas (tiles) utilizando una fuente gratuita, como OpenStreetMap
       L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
           attribution: 'Map data © OpenStreetMap contributors'
       }).addTo(map);

       // Crea un marcador para la ubicación actual
       var marker = L.marker([-17.4136, -66.1653]).addTo(map); // Aquí puedes especificar las coordenadas de la ubicación actual

       // Actualiza la ubicación y el nombre del lugar al hacer clic en el mapa
       map.on('click', function (e) {
           var latitud = e.latlng.lat.toFixed(6); // Obtiene la latitud con 6 decimales
           var longitud = e.latlng.lng.toFixed(6); // Obtiene la longitud con 6 decimales

           // Actualiza los valores de los campos ocultos
           document.getElementById('<%= hdnLatitud.ClientID %>').value = latitud;
        document.getElementById('<%= hdnLongitud.ClientID %>').value = longitud;

        // Realiza una solicitud de geocodificación inversa para obtener el nombre del lugar
        var url = 'https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=' + latitud + '&lon=' + longitud;

        fetch(url, {
            headers: {
                'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123 Safari/537.36'
            }
        })
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            if (data && data.display_name) {
                var nombreLugar = data.display_name;
                document.getElementById('<%= txtNombreLugar.ClientID %>').value = nombreLugar;
            }
        })
            .catch(function (error) {
                console.error('Error al obtener el nombre del lugar', error);
            });

        // Mueve el marcador a la nueva ubicación
        marker.setLatLng(e.latlng);
    });
   </script>
    <script>
        function validarCI(event) {
            var keyCode = event.which ? event.which : event.keyCode;
            var inputValue = String.fromCharCode(keyCode);

            // Solo permitir números
            if (!/^\d$/.test(inputValue)) {
                event.preventDefault();
            }
        }

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

        function removeExtraSpaces(textInput) {
            textInput.value = textInput.value.replace(/\s{2,}/g, ' ');
        }
    </script>
    <script>
        document.getElementById('<%= btnInsert.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtNombreLugar.ClientID %>');
            var txtNum = document.getElementById('<%= txtNum.ClientID %>');
            var txtlongitud = document.getElementById('<%= hdnLongitud.ClientID %>');
            var txtlatitud = document.getElementById('<%= hdnLatitud.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            // Verificar si los campos requeridos están vacíos
            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese Dirección';
                return false; // Evitar el envío del formulario
            }

            if (txtNum.value.trim() === '') {
                txtNum.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese numero de casa';
                return false; // Evitar el envío del formulario
            } else if (txtNum.value.trim().length <= 2) {
                txtNum.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese numero de casa valido';
                return false; // Evitar el envío del formulario
            }

            if (txtlongitud.value.trim() === '') {
                txtlongitud.classList.add('error');
                txtDescriptionError.textContent = 'Seleccione  una  dirección en el mapa';
                return false; // Evitar el envío del formulario
            }

            if (txtlatitud.value.trim() === '') {
                txtlatitud.classList.add('error');
                txtDescriptionError.textContent = 'Seleccione  una  dirección en el mapa';
                return false; // Evitar el envío del formulario
            }
        };
    </script>
</asp:Content>
