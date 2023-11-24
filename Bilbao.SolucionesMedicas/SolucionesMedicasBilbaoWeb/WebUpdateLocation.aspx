<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebUpdateLocation.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebUpdateLocation" %>
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

                    <div class="card-footer">
                            <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
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


    <script>
        
        var map = L.map('map').setView([-17.4136, -66.1653], 13); 

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data © OpenStreetMap contributors'
        }).addTo(map);

        var marker = L.marker([-17.4136, -66.1653]).addTo(map);

        map.on('click', function (e) {
            var latitud = e.latlng.lat.toFixed(6); 
            var longitud = e.latlng.lng.toFixed(6); 

            document.getElementById('<%= hdnLatitud.ClientID %>').value = latitud;
        document.getElementById('<%= hdnLongitud.ClientID %>').value = longitud;

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

        marker.setLatLng(e.latlng);
    });

     var initialLatitud = document.getElementById('<%= hdnLatitud.ClientID %>').value;
    var initialLongitud = document.getElementById('<%= hdnLongitud.ClientID %>').value;
    var initialNombreLugar = document.getElementById('<%= txtNombreLugar.ClientID %>').value;

    if (initialLatitud && initialLongitud) {
        var initialLatLng = L.latLng(initialLatitud, initialLongitud);
        marker.setLatLng(initialLatLng);

        map.setView(initialLatLng);
    }

    if (initialNombreLugar) {
        var nombreLugar = initialNombreLugar;
        document.getElementById('<%= txtNombreLugar.ClientID %>').value = nombreLugar;
        }
    </script>

    <script>
        function validarCI(event) {
            var keyCode = event.which ? event.which : event.keyCode;
            var inputValue = String.fromCharCode(keyCode);

            if (!/^\d$/.test(inputValue)) {
                event.preventDefault();
            }
        }

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

        function removeExtraSpaces(textInput) {
            textInput.value = textInput.value.replace(/\s{2,}/g, ' ');
        }
    </script>
    <script>
        document.getElementById('<%= btnModificar.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtNombreLugar.ClientID %>');
            var txtNum = document.getElementById('<%= txtNum.ClientID %>');
            var txtlongitud = document.getElementById('<%= hdnLatitud.ClientID %>');
            var txtlatitud = document.getElementById('<%= hdnLongitud.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese Dirección';
                return false; 
            }

            if (txtNum.value.trim() === '') {
                txtNum.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese numero  de  casa';
                return false; 
            } else if (txtNum.value.trim().length <= 2) {
                txtNum.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese numero de casa valido';
                return false; 
            }

            if (txtlongitud.value.trim() === '') {
                txtlongitud.classList.add('error');
                txtDescriptionError.textContent = 'Seleccione  una  dirección en el mapa';
                return false; 
            }

            if (txtlatitud.value.trim() === '') {
                txtlatitud.classList.add('error');
                txtDescriptionError.textContent = 'Seleccione  una  dirección en el mapa';
                return false; 
            }
        };

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
              
</asp:Content>