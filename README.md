 

  

  

  

MANUAL TÉCNICO 

Proyecto “INCOTERMS” 

Soluciones Medicas Bilbao 

  

  

  

  

  

  

Materia: 		Proyecto de Sistemas 

Docente: 		Gastón Silva Sánchez 

Integrantes: 	Fabiana Mercedes Bilbao Mercado 

Cristhian Andrés Escalera Muñoz  

Nicole Katherin Herbas Fuentes 

 

 

 

 

Manual Técnico 

​​Contenido 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​ 

​​ 

 

 

 

 

 

 

 

 

 

1.Introducción 

 

El sistema permite el registro de todos los datos relevantes para la empresa “Soluciones Médicas Bilbao”. Les brindamos una herramienta para llevar el registro de sus productos, sus importaciones, los datos de sus proveedores y embarcadores. También les brindamos un sistema que les brinde la seguridad para sus datos  

El objetivo principal de este sistema es proporcionar a la empresa Soluciones Médicas Bilbao una herramienta integral para el registro y almacenamiento eficiente de todos sus datos críticos. Diseñado para optimizar la gestión de información, este sistema abarca el registro de productos, la documentación detallada de importaciones, así como la información clave de proveedores y embarcadores. 

  

Este software ha sido desarrollado con la finalidad de centralizar y organizar de manera efectiva la diversidad de datos que maneja la empresa, permitiendo un acceso rápido y seguro a la información esencial. Desde la catalogación de productos hasta el seguimiento detallado de las transacciones comerciales, nuestro sistema ofrece una solución integral que optimiza la eficiencia operativa y potencia el control administrativo. 

  

A través de una interfaz intuitiva, los usuarios podrán gestionar de manera sencilla y precisa cada aspecto relacionado con sus operaciones, facilitando la toma de decisiones informadas y la generación de informes estratégicos. Con el compromiso de ofrecer una herramienta robusta y adaptable, nuestro sistema busca elevar los estándares de eficiencia en la gestión de datos para Soluciones Médicas Bilbao, respaldando así el crecimiento y éxito continuo de la empresa en el sector de importación de equipos médicos. 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

2.Descripción de proyecto 

 

El proyecto “INCOTERMS” es un sistema integral de registro diseñado específicamente para la empresa “Soluciones Medicas Bilbao”, una importadora de equipos médicos con sede en Cochabamba-Bolivia. El objetivo principal de este sistema es optimizar y automatizar la gestión de datos relacionada con productos, importaciones, proveedores y embarcadores, mejorando la eficiencia operativa y proporcionando a la empresa un control administrativo más efectivo. 

 

El sistema “INCOTERMS” incluye las siguientes características clave: 

  

Registro de Productos: Permite la catalogación detallada de productos, incluyendo información relevante como especificaciones técnicas y registros históricos. 

 

Registro de los Proveedores y Embarcadores: Permite la catalogación detallada de la información de los proveedores y embarcadores con los que se relaciona la empresa “Soluciones Medicas Bilbao”, incluyendo información relevante como datos de contacto y registros históricos. 

  

Gestión de Importaciones: Facilita el seguimiento y registro de todas las transacciones de importación, desde la solicitud hasta la recepción de productos. 

  

Base de Datos Centralizada: Utiliza Microsoft SQL Server 2022 como sistema de gestión de bases de datos para garantizar un almacenamiento seguro y eficiente de la información. 

  

Interfaz Intuitiva: Proporciona una interfaz de usuario intuitiva basada en tecnologías web estándar (HTML5, CSS, JavaScript), facilitando la navegación y el uso del sistema. 

 

3.Roles / Integrantes 

Team Lider - Developer 

Bilbao Mercado Fabiana Mercedes  

Git Master - Developer 

Cristhian Andres Escalera Muñoz 

Database Arquitect - Developer 

Nicole Katherin Harbas Fuentes 

 

4. Arquitectura del software: 

La arquitectura del software se ha diseñado siguiendo el patrón de diseño DAO (Data Access Object) para proporcionar una estructura clara y modular. A continuación, se explica la organización del software, incluyendo los componentes principales, sus interacciones y el uso del patrón DAO. 

Estructura General: 

  

Organizamos el proyecto en una carpeta llamada: “SolucionesMedicasBilbaoWeb” dentro de esta carpeta podrá visualizar lo siguiente: 

 

Capa de Presentación (UI): 

Los archivos con terminación “.aspx” son donde se realiza la interacción con el usuario. 

Utiliza tecnologías como HTML, CSS, y JavaScript para crear una interfaz de usuario intuitiva. 

Se comunica con la capa de lógica de negocio para gestionar las solicitudes del usuario. 

 

Capa de Lógica de Negocio (Backend): 

Los archivos con terminación “.aspx.cs” es el backend que se comunica con la capa de acceso a datos (DAO) para realizar operaciones en la base de datos. 

Implementa la lógica empresarial y las reglas de negocio. 

 

En la carpeta llamada: “SolucionesMedicasBilbaoDAO” dentro de esta carpeta podrá visualizar lo siguiente: 

 

Capa de Acceso a Datos (DAO): 

En la subcarpeta llamada “Interfaces”: Aplicamos el patrón DAO para proporcionar una interfaz de acceso a la base de datos. 

En la subcarpeta llamada “Model”: Contiene clases DAO específicas para cada entidad. 

 

En la subcarpeta llamada “Implementacion”: Gestionamos la conexión y operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos. 

 

Base de Datos (DBMS): 

  

Utiliza Microsoft SQL Server 2022 como sistema de gestión de bases de datos. 

Almacena y gestiona los datos relacionados con productos, importaciones, proveedores y embarcadores. 

 

 

 

5.Requisitos del sistema 

Requerimientos de Hardware(mínimo): (cliente) 

Procesador: Intel Core i3 o equivalente 

Memoria RAM: 4 GB 

Conexión a Internet: Conexión de banda ancha 

Requerimientos de Software:(cliente) 

Sistema Operativo: Windows 10 o posterior  

Navegador Web: Última versión de Google Chrome, Mozilla Firefox, o Microsoft Edge 

Otros: .NET Framework (para sistemas Windows) 

Requerimientos de Hardware(server/hosting/BD): 

Memoria RAM: 8 GB o superior 

Almacenamiento: 256 GB de espacio disponible (SSD recomendado para mejor rendimiento) 

Conexión a Internet: Conexión de alta velocidad y ancho de banda adecuado para el tráfico esperado. 

Requerimientos de Software (server/hosting/BD): 

Sistema Operativo del Servidor: Windows Server 2022 o posterior 

Servidor Web: IIS (Internet Information Services) para entornos Windows  

Base de Datos: Microsoft SQL Server 2022 

Herramientas Adicionales: Utilice SQL Server Management Studio (SSMS) versión 2022 o posterior para gestionar la base de datos. 

 

6. Instalación y configuración: 

Para la configuración del programa y su uso por ahora se debe de tener tanto la base de datos “DBEquiposMedicos.bak” y el programa web “Bilbao.SolucionesMedicas”. Una vez se tenga ambos programas, inicie SQL Server e inicie la base de datos en este, una vez cargada por temas de seguridad y uso desactive y active la el id de la tabla “Person”. 

 

Lo siguiente que debe de hacer es abrir el proyecto Bilbao.SolucionesMedicas y en la parte de DAO, se dirige a la carpeta implementaciones y luego al archivo BaseImpl, ahí deberá poner la dirección de su conexión junto a la contraseña de este. Esta dirección la puede encontrar cuando se inicia el programa SQLServer, copia la dirección y deberá colocarla donde dice connectionString en la parte de Server y la contraseña en password. 

 

Después de haber realizado todos esto pasos solo haga correr el programa y este realizara todo el trabajo sin problema, recuerde que debe ingresar los datos default en el Login para poder ingresar y usar la página. 

 

7. PROCEDIMIENTOS DE HOSTEADO / HOSTING (configuración) 

Sitio Web 

BD 

API / servicio Web 

Otros (firebase, etc.) 

El siguiente error es del dockerizado, al momento de ejecutar el dockerizado nos sale ese error que fuimos tratando de solucionar, hasta ahora seguimos sin poder solucionarlo. 

 

8. GIT: 

Fabiana Bilbao 

 

Nicole Herbas 

 

Cristhian Escalera  

9. Personalización y configuración 

 

Contraseña Personalizada: 

Cambio de Contraseña: 

Proporciona a los usuarios la capacidad de cambiar su contraseña en cualquier momento. Esta funcionalidad puede ubicarse en la opción “Cambio de Contraseña”. 

Confirmación de Cambios: 

Implementa un proceso de confirmación para asegurarte de que el usuario haya realizado el cambio de contraseña intencionalmente, solicitando la contraseña actual antes de permitir el cambio. 

10. Seguridad 

 

Se asegura de que la página no se almacene en la caché del navegador a través de un bloque if (!IsPostBack) este se desactiva el almacenamiento en cache en el navegador para garantizar que no se almacene datos confidenciales, lo cual es esencial para evitar la retención de información sensible en el lado del cliente. Este enfoque se activa solo durante la carga inicial de la página, garantizando que la información no se conserve en la caché en situaciones de recarga o postback. 

  

Posteriormente, se realiza un bloque if (SessionClass.SessionRole != "Rol") que evalúa el rol del usuario almacenado en la sesión. Esto ayuda a controlar el acceso a secciones específicas de la aplicación según el rol del usuario. Por ejemplo, si el usuario tiene el rol de "Ingresos", se redirige a la página "Ingresos.aspx"; si es un "Empleado", se redirige a "Empleado.aspx". Si el rol no coincide con ninguno, la aplicación redirige al usuario a la página de inicio de sesión ("WebLogin.aspx"). 

  

El manejo de la encriptación de algunos datos al momento de ser ingresados a la base de datos también se ha visto, como el password/contraseña el cual se encripta al ser ingresado, además de los métodos de verificación de que sea una contraseña totalmente segura. 

 

 

 

 

11. Depuración y solución de problemas 

Mensajes de Error en la Interfaz de Usuario: 

Si un usuario encuentra un mensaje de error en la interfaz, este mensaje le proporcionara la información de lo que está fallando o de los pasos que faltan realizar para poder ejecutar alguna acción. 

Logs del Servidor: Revisar los logs del servidor para identificar mensajes de error y eventos anómalos. Establecer registros detallados para facilitar la depuración. 

Problemas de Rendimiento:  

Monitorizar el rendimiento del sistema para identificar cuellos de botella o áreas de mejora. Utilizar herramientas de perfilado de código si es necesario. 

Problemas de Compatibilidad del Navegador: 

Para evitar problemas con las compatibilidades del navegador, intentar manejar las últimas versiones de los navegadores comunes como Google Chrome, Mozilla Firefox, o Microsoft Edge 

Manejo de Excepciones: 

Es importante tener en cada acción el control try-catch que permite que el sistema capture la falla desplegando la excepción que se produce. 

Soporte Técnico Directo: 

Para soporte técnico directo en caso de problemas críticos no resueltos por los usuarios, ponerse en contacto con: 

Bilbao Mercado Fabiana Mercedes 

Telf: 79788863 

Email: bmf0031211@est.univalle.edu 

Escalera Muñoz Cristhian Andrés 

Telf:75934191 

Email: emc0031008@est.univalle.edu 

Herbas Fuentes Nicole Katherin 

Telf: 77492551 

Email: hfn5001384@est.univalle.edu 

 

 

 

 

 

12. Glosario de términos: 

Incoterm: Los Incoterms son términos de comercio internacional que definen las responsabilidades y costos del comprador y del vendedor en una transacción internacional. Estos términos especifican quién es responsable del transporte, seguro y otros aspectos logísticos durante el envío de mercancías. 

PostBack: se refiere a la acción de enviar datos desde una página web al servidor y recibir una respuesta. 

Dockerizado: Es un proceso en el cual convierte el proyecto en una imagen y lo guarda en un contenedor, con eso el proyecto puede ser buscado en el navegador sin necesidad de estar en ejecución. 

API: es un conjunto de reglas y definiciones que permite que diferentes aplicaciones se comuniquen entre sí. 

FrontEnd: Es la interfaz de usuario y todo lo que los usuarios experimentan visualmente al utilizar una aplicación o visitar un sitio web. 

 

13. Referencias y recursos adicionales: 

Dockerizado 

https://www.youtube.com/watch?v=bLVVj-3_wlA 



14. Herramientas de Implementación: 

Lenguajes de programación: 

Frontend (Cliente): 

HTML5 

CSS 

JavaScript  

Backend (Server): 

C# (utilizando ASP.NET) 

 

Framework: 

ASP.NET: 

Utilizando ASP.NET para el desarrollo del lado del servidor. 

Base de Datos: 

Sistema de Gestión de Bases de Datos (DBMS): 

Microsoft SQL Server 2022 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

15. Bibliografía: 

 

Microsoft. "HttpResponse.Cache Property." https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.cache?view=netframework-4.8.1   

Microsoft. "HttpResponse.Redirect Method." https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.redirect?view=netframework-4.8.1 	 

Microsoft. "ASP.NET Session State Overview." https://learn.microsoft.com/en-us/dotnet/api/system.web.sessionstate.httpsessionstate?view=netframework-4.8.1  

Microsoft. “GridView Class.” https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview?view=netframework-4.8.1  

Microsoft. “Client-side form validation.” https://developer.mozilla.org/en-US/docs/Learn/Forms/Form_validation  

Microsoft. “Realizar actualizaciones por lotes (VB).” https://learn.microsoft.com/es-es/aspnet/web-forms/overview/data-access/editing-and-deleting-data-through-the-datalist/performing-batch-updates-vb   

Microsoft. “SqlCommand.ExecuteScalar Method.” https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=dotnet-plat-ext-8.0  

Microsoft. “SqlCommand Clase” https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-7.0  

Microsoft. “SqlCommand.ExecuteNonQuery Method” https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executenonquery?view=dotnet-plat-ext-8.0  

Microsoft. “SqlTransaction Clase” https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqltransaction?view=dotnet-plat-ext-7.0  

 Stackoverflow. “Trying to pass SqlCommand in SqlDataAdapter as parameters”  https://stackoverflow.com/questions/44402669/trying-to-pass-sqlcommand-in-sqldataadapter-as-parameters  

Stackoverflow. “How to read SQL Table data into a C# DataTable” https://stackoverflow.com/questions/6073382/how-to-read-sql-table-data-into-a-c-sharp-datatable  

Stackoverflow. “error with addwithvalue sql parameter” https://stackoverflow.com/questions/38463844/error-with-addwithvalue-sql-parameter  

Stackoverflow. “La consulta espera el parametro @Nombre que no se ha proporcionado” https://es.stackoverflow.com/questions/32573/la-consulta-espera-el-parametro-nombre-que-no-se-ha-proporcionado  

Stackoverflow. “Input string was not in a correct format, Drop down list Selected Value.” https://stackoverflow.com/questions/10028046/input-string-was-not-in-a-correct-format-drop-down-list-selected-value 

 
