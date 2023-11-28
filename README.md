![](RackMultipart20231128-1-6pfiff_html_bf3a12c5dbdad514.png)

# **MANUAL TÉCNICO**

# **Proyecto "INCOTERMS"**

**Soluciones Medicas Bilbao**

Materia: Proyecto de Sistemas

Docente: Gastón Silva Sánchez

Integrantes: Fabiana Mercedes Bilbao Mercado

Cristhian Andrés Escalera Muñoz

Nicole Katherin Herbas Fuentes

Manual Técnico

# Contenido

[1.Introducción 3](#_Toc151676226)

[2.Descripción de proyecto 4](#_Toc151676227)

[3.Roles / Integrantes 4](#_Toc151676228)

[4. Arquitectura del software: 5](#_Toc151676229)

[5.Requisitos del sistema 6](#_Toc151676230)

[6. Instalación y configuración: 6](#_Toc151676231)

[7. PROCEDIMIENTOS DE HOSTEADO / HOSTING (configuración) 7](#_Toc151676232)

[8. GIT: 7](#_Toc151676233)

[9. Personalización y configuración 8](#_Toc151676234)

[10. Seguridad 8](#_Toc151676235)

[11. Depuración y solución de problemas 9](#_Toc151676236)

[12. Glosario de términos: 10](#_Toc151676237)

[13. Referencias y recursos adicionales: 10](#_Toc151676238)

[14. Herramientas de Implementación: 11](#_Toc151676239)

[15. Bibliografía: 12](#_Toc151676240)

#

#

# 1.Introducción

El sistema permite el registro de todos los datos relevantes para la empresa "Soluciones Médicas Bilbao". Les brindamos una herramienta para llevar el registro de sus productos, sus importaciones, los datos de sus proveedores y embarcadores. También les brindamos un sistema que les brinde la seguridad para sus datos

El objetivo principal de este sistema es proporcionar a la empresa Soluciones Médicas Bilbao una herramienta integral para el registro y almacenamiento eficiente de todos sus datos críticos. Diseñado para optimizar la gestión de información, este sistema abarca el registro de productos, la documentación detallada de importaciones, así como la información clave de proveedores y embarcadores.

Este software ha sido desarrollado con la finalidad de centralizar y organizar de manera efectiva la diversidad de datos que maneja la empresa, permitiendo un acceso rápido y seguro a la información esencial. Desde la catalogación de productos hasta el seguimiento detallado de las transacciones comerciales, nuestro sistema ofrece una solución integral que optimiza la eficiencia operativa y potencia el control administrativo.

A través de una interfaz intuitiva, los usuarios podrán gestionar de manera sencilla y precisa cada aspecto relacionado con sus operaciones, facilitando la toma de decisiones informadas y la generación de informes estratégicos. Con el compromiso de ofrecer una herramienta robusta y adaptable, nuestro sistema busca elevar los estándares de eficiencia en la gestión de datos para Soluciones Médicas Bilbao, respaldando así el crecimiento y éxito continuo de la empresa en el sector de importación de equipos médicos.

# 2.Descripción de proyecto

El proyecto "INCOTERMS" es un sistema integral de registro diseñado específicamente para la empresa "Soluciones Medicas Bilbao", una importadora de equipos médicos con sede en Cochabamba-Bolivia. El objetivo principal de este sistema es optimizar y automatizar la gestión de datos relacionada con productos, importaciones, proveedores y embarcadores, mejorando la eficiencia operativa y proporcionando a la empresa un control administrativo más efectivo.

El sistema "INCOTERMS" incluye las siguientes características clave:

Registro de Productos: Permite la catalogación detallada de productos, incluyendo información relevante como especificaciones técnicas y registros históricos.

Registro de los Proveedores y Embarcadores: Permite la catalogación detallada de la información de los proveedores y embarcadores con los que se relaciona la empresa "Soluciones Medicas Bilbao", incluyendo información relevante como datos de contacto y registros históricos.

Gestión de Importaciones: Facilita el seguimiento y registro de todas las transacciones de importación, desde la solicitud hasta la recepción de productos.

Base de Datos Centralizada: Utiliza Microsoft SQL Server 2022 como sistema de gestión de bases de datos para garantizar un almacenamiento seguro y eficiente de la información.

Interfaz Intuitiva: Proporciona una interfaz de usuario intuitiva basada en tecnologías web estándar (HTML5, CSS, JavaScript), facilitando la navegación y el uso del sistema.

# 3.Roles / Integrantes

- Team Lider - Developer

Bilbao Mercado Fabiana Mercedes

- Git Master - Developer

Cristhian Andres Escalera Muñoz

- Database Arquitect - Developer

Nicole Katherin Harbas Fuentes

# 4. Arquitectura del software:

La arquitectura del software se ha diseñado siguiendo el patrón de diseño DAO (Data Access Object) para proporcionar una estructura clara y modular. A continuación, se explica la organización del software, incluyendo los componentes principales, sus interacciones y el uso del patrón DAO.

Estructura General:

Organizamos el proyecto en una carpeta llamada: "SolucionesMedicasBilbaoWeb" dentro de esta carpeta podrá visualizar lo siguiente:

Capa de Presentación (UI):

Los archivos con terminación ".aspx" son donde se realiza la interacción con el usuario.

Utiliza tecnologías como HTML, CSS, y JavaScript para crear una interfaz de usuario intuitiva.

Se comunica con la capa de lógica de negocio para gestionar las solicitudes del usuario.

Capa de Lógica de Negocio (Backend):

Los archivos con terminación ".aspx.cs" es el backend que se comunica con la capa de acceso a datos (DAO) para realizar operaciones en la base de datos.

Implementa la lógica empresarial y las reglas de negocio.

En la carpeta llamada: "SolucionesMedicasBilbaoDAO" dentro de esta carpeta podrá visualizar lo siguiente:

Capa de Acceso a Datos (DAO):

En la subcarpeta llamada "Interfaces": Aplicamos el patrón DAO para proporcionar una interfaz de acceso a la base de datos.

En la subcarpeta llamada "Model": Contiene clases DAO específicas para cada entidad.

En la subcarpeta llamada "Implementacion": Gestionamos la conexión y operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos.

Base de Datos (DBMS):

Utiliza Microsoft SQL Server 2022 como sistema de gestión de bases de datos.

Almacena y gestiona los datos relacionados con productos, importaciones, proveedores y embarcadores.

# 5.Requisitos del sistema

- Requerimientos de Hardware(mínimo): (cliente)

Procesador: Intel Core i3 o equivalente

Memoria RAM: 4 GB

Conexión a Internet: Conexión de banda ancha

- Requerimientos de Software:(cliente)

Sistema Operativo: Windows 10 o posterior

Navegador Web: Última versión de Google Chrome, Mozilla Firefox, o Microsoft Edge

Otros: .NET Framework (para sistemas Windows)

- Requerimientos de Hardware(server/hosting/BD):

Memoria RAM: 8 GB o superior

Almacenamiento: 256 GB de espacio disponible (SSD recomendado para mejor rendimiento)

Conexión a Internet: Conexión de alta velocidad y ancho de banda adecuado para el tráfico esperado.

- Requerimientos de Software (server/hosting/BD):

Sistema Operativo del Servidor: Windows Server 2022 o posterior

Servidor Web: IIS (Internet Information Services) para entornos Windows

Base de Datos: Microsoft SQL Server 2022

Herramientas Adicionales: Utilice SQL Server Management Studio (SSMS) versión 2022 o posterior para gestionar la base de datos.

# 6. Instalación y configuración:

Antes de empezar debe descargar el proyecto de la rama " **Main**" del git [https://github.com/CristhianEscalera/Incoterms.git](https://github.com/CristhianEscalera/Incoterms.git) y descomprimirla

- Configuración SQLServer

Para usar el proyecto primeramente tendremos que iniciar la base de datos "[BDEquiposMedicosFinal (1).bak](https://github.com/CristhianEscalera/Incoterms/blob/main/BDEquiposMedicosFinal%20(1).bak)" mediante SQLServer

**En caso de que lo tenga y no sepa como iniciar la base siga los siguientes pasos:**

1. **Instalación de SqlServer**

Diríjase a la siguiente pagina

[https://www.microsoft.com/es-es/sql-server/sql-server-downloads](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)

Una vez ahí diríjase a la siguiente pestaña y haga clic en descargar

![Insertando imagen...](RackMultipart20231128-1-6pfiff_html_d2a4dde58addc468.png](https://github.com/CristhianEscalera/Incoterms/blob/main/Imagenes/Imagenes/Imagen1.png)

Una vez el programa este descargado inícielo sin problema alguno, una vez ahí seleccione lo siguiente

![](RackMultipart20231128-1-6pfiff_html_db988f3c01094fe9.png)

Acepte todos los términos, una vez hecho eso seleccione la dirección donde desea que se encuentre el sql y luego presione instalar

![](RackMultipart20231128-1-6pfiff_html_da68ed5392cb51c6.png)

Una vez realizada la instalación le aparecerá lo siguiente

![Insertando imagen...](RackMultipart20231128-1-6pfiff_html_fdb1f5d50454b70e.png)

Seleccione **Instalar SSMS** , este lo enviara a una página de Microsoft donde tendra que descargar lo siguiente

![](RackMultipart20231128-1-6pfiff_html_9fa72b2e9e6f611c.png)

Si el link no le aparece aquí tiene el SSMS

[https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Una vez lo tenga descargado inícielo, solo tendrá que seleccionar donde desea que el programa se guarde (puede dejarlo en el default sin problema)

![](RackMultipart20231128-1-6pfiff_html_46e63f27c07f9829.png)

Una vez termine la descarda reinicie su computadora para que los cambios sean ejecutados correctamente. Una vez el equipo sea reiniciado busque en sus aplicaciones " **SQL Server Management Studio Management Studio 19**", si tiene problemas puede consultar las siguientes paginas

- Instalacion SQLServer

[https://codigosql.top/sql-server/instalar-sql-server-management-studio/](https://codigosql.top/sql-server/instalar-sql-server-management-studio/)

- Instalacion SMSS

[https://serverspace.io/es/support/help/install-sql-server-management-studio/](https://serverspace.io/es/support/help/install-sql-server-management-studio/)

1. **Habilitación del usuario sa**

Para poder iniciar o restaurar la base de datos tiene que iniciar el SQLServer mediante el usuario **sa**. Si usted no lo tiene habilitado o recién a descargado el SQLServer siga los siguientes pasos para su habilitación:

Al iniciar SQLServer le aparecerá un marco de conexión el cual debe estar realizando autenticacion mediante windows para poder realizar los cambios, por lo que su marco de conexión deberá verse de la siguiente manera antes de que pulse el botón " **Connect**" (No cambie el nombre del Servidor)

![](RackMultipart20231128-1-6pfiff_html_df90e72c5cfc1ff3.png)

Una vez iniciado a un costado de su pantalla aparecerá el Object Explorer. Una vez ahí tendrá que seleccionar la carpeta **Security** , una vez abierta habrá la carpeta **Logins** y haga click derecho sobre sa , una vez hecho le saldrá un pequeño menú, elija "Properties" se encuentra al final del menú

![](RackMultipart20231128-1-6pfiff_html_27fe1770fc079e74.png)

Una vez abierto diríjase a Status y verifique que la configuración sea la siguiente (Asegúrese de que todo esté de acuerdo a la imagen)

![](RackMultipart20231128-1-6pfiff_html_beef77313aafdaff.png)

Una vez realizado nos dirigiremos hacia General donde cambiaremos la contraseña del sa, puede cambiar la contraseña a lo que usted guste

![](RackMultipart20231128-1-6pfiff_html_bae9ce0372241696.png)

Luego de haber realizado todo presione el botón Ok para guardar los cambios realizados. Una vez realizado los pasos debemos refrescar logins de la siguiente manera

![](RackMultipart20231128-1-6pfiff_html_32ff3f276294a3ab.png)

Una vez refresquemos logins nos dirigiremos a nuestro servidor donde haremos click derecho y nos dirigiremos a Properties

![](RackMultipart20231128-1-6pfiff_html_d6339cee679b525f.png)

Nos dirigiremos a la seccion de Security y verifique que la configuración sea la siguiente (Asegúrese de que todo esté de acuerdo a la imagen)

![](RackMultipart20231128-1-6pfiff_html_63b1682cd691deef.png)

Una vez realizados todos los cambios pulse el boton de "Ok" y realice lo siguiente. Diríjase hacia el servidor y haga clic derecho, luego presione "Restart"

![](RackMultipart20231128-1-6pfiff_html_9a3afbf415f698b5.png)

Este le pedirá permiso para realizar cambios a los cuales deberá aceptar, una vez aceptados le aparecerá lo siguiente el cual deberá aceptar de igual manera.

![Insertando imagen...](RackMultipart20231128-1-6pfiff_html_f382937178490662.png)

Una vez haya terminado, si es que sigue conectado deberá desconectarse apretando este boton

![](RackMultipart20231128-1-6pfiff_html_2251c170f19061a7.png)

Para volver a conectarse presione el siguiente botón

![](RackMultipart20231128-1-6pfiff_html_5c88a139d280f1a5.png)

Una vez presionado volveremos a la pantalla de "Connect Server", solo que ahora seleccionaremos lo siguiente, en Authentication ingresaremos mediante "SQL Server Authentication", en login pondremos el nombre del usuario el cual es "sa" y finalmente en Password la contraseña que ingresamos con anterioridad. Una vez todo realizado aprete el boton "Connect" ![](RackMultipart20231128-1-6pfiff_html_ee80acdd621aecea.png)

Si a tenido problemas para poder conectarse puede consultar con el siguiente video

[https://www.youtube.com/watch?v=yXhjFOvNyR4&t=9s](https://www.youtube.com/watch?v=yXhjFOvNyR4&t=9s)

[![Video titulado:HABILITAR Usuario sa en SQL Server | SQL Server 2019 |SQL Server Managment 2023](RackMultipart20231128-1-6pfiff_html_fc0a7950c654b4b4.jpg)](https://www.youtube.com/watch?v=yXhjFOvNyR4&t=9s)

En caso de que le haya salido el siguiente error (El cual es muy normal al momento de iniciar SQL)

![](RackMultipart20231128-1-6pfiff_html_998ac7b66f209477.png)

Puede consultar el siguiente video para solucionarlo

[https://www.youtube.com/watch?v=kmU0LiNP68o](https://www.youtube.com/watch?v=kmU0LiNP68o)

[![Video titulado:How To Fix Login Failed for User Microsoft SQL Server Error 18456 || Step-By-Step](RackMultipart20231128-1-6pfiff_html_343907dc693b085a.jpg)](https://www.youtube.com/watch?v=kmU0LiNP68o)

1. **Restauracion de la Base de datos**

Para restaurar la base de datos augúrese haber descargado "[BDEquiposMedicosFinal (1).bak](https://github.com/CristhianEscalera/Incoterms/blob/main/BDEquiposMedicosFinal%20(1).bak)"

Para poder realizar su recuperación debe estar **logeado en SQLServer con el usuario sa** , una vez este logeado debe realizar lo siguiente:

Diríjase a la carpeta database y de clic derecho, seleccione del menu la opcion "Restore Database"

![](RackMultipart20231128-1-6pfiff_html_3249137eff34d430.png)

Una vez seleccionado se abrirá la siguiente ventana, en esta deberá dirigirse a la pestaña "General" y seleccionar la opción "Device", luego presione el boton donde se encuentra los tres puntos

![](RackMultipart20231128-1-6pfiff_html_8b4cef9cc61f4a8a.png)

En la nueva ventana abierta presione el boton "Add"

![](RackMultipart20231128-1-6pfiff_html_6134569aa2fac9a8.png)

Debe mover el archivo "[BDEquiposMedicosFinal (1).bak](https://github.com/CristhianEscalera/Incoterms/blob/main/BDEquiposMedicosFinal%20(1).bak)" dentro del disco C:\ de su computador en este caso Y COMO EJEMPLO puede crear una carpeta en el disco C y mover el archivo a esta

![](RackMultipart20231128-1-6pfiff_html_c3348a566f590183.png)

Para que al momento de seleccionar el archivo se le sea más fácil y rápido de encontrar, en estos momentos solo debe seleccionar el archivo descargado y continuar

![](RackMultipart20231128-1-6pfiff_html_3effbc8ed4014f52.png)

Una vez todo este hecho deberá aparecerle el archivo seleccionado de la siguiente manera, en este momento solo presione "Ok" y habrá finalizado con la recuperación de la base de datos

![](RackMultipart20231128-1-6pfiff_html_50b4618780fd1f5c.png)

Para poder visualizar la base deberá dirigirse nuevamente a "Database" donde esta vez le aparecerá la base de datos "BDEquiposMedicos" debera hacer clic a esta, luego abrir "Database Diagrams" y finalmente hacer clic en "dbo.BDEquiposMedicos"

![](RackMultipart20231128-1-6pfiff_html_5f9fe309b693ab0a.png)

Si a realizado todo de manera correcta su pantalla cargara la base de datos de manera correcta y deberia verse de la siguiente manera

![](RackMultipart20231128-1-6pfiff_html_4b9208f9287b2841.png)

1. **Ambientación de Base**

Como ultimo para configurar y evitar problemas en la base de datos tenemos que habilitar y deshabilitar el id de la tabla **"Person"** lo cual haremos de la siguiente manera

Nos dirigiremos a la tabla "Person" y haremos clic donde dice "id", luego en la tabla de propiedades nos dirigiremos a "Identity Specifications" y hacermos clic donde dice "Yes"

![](RackMultipart20231128-1-6pfiff_html_cc9c3d9988137fc4.png)

Iremos a la parte donde dice (Is Identity) y haremos doble clic para que este cambie a "No"

![](RackMultipart20231128-1-6pfiff_html_50ccc6834b91d1dd.png)

Una vez realizado el cambio, iremos al icono de guardado que esta encima del todo y lo presionaremos, nos saldrá la siguiente ventana y apretaremos "Yes"

![](RackMultipart20231128-1-6pfiff_html_66fa54d1fcbf1ad.png)

i

Una vez hecho deberemos realizar lo mismo, pero en reversa, que quiere decir eso que repetiremos los pasos dejando esta vez el iremos a la parte donde dice (Is Identity) y haremos doble clic para que este cambie a "Yes" y volveremos a guardar los cambios. Con esto ya tendriamos la base de datos en perfecto funcionamiento.

Si tiene un problema

Configuración Visual Studio

Para inicializar el programa o hacer correr el "[Bilbao.SolucionesMedicas](https://github.com/CristhianEscalera/Incoterms/tree/main/Bilbao.SolucionesMedicas)" se requiere del programa. Si no tiene Visual Studio Realice los siguientes pasos:

Ingrese a la página oficial de **Visual Studio** para descargarlo

[https://visualstudio.microsoft.com/es/](https://visualstudio.microsoft.com/es/)

![](RackMultipart20231128-1-6pfiff_html_4e9e1bc95cefb714.png)

Busca la opción de descarga y descarga el " **Community 2022**" o puede entrar a este link para descargar directamente [https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false](https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)

![](RackMultipart20231128-1-6pfiff_html_a7b183716c2398b4.png) Despúes de hacer click te llevara a esta página y comenzara automáticamente la descarga

![](RackMultipart20231128-1-6pfiff_html_c0346eee0020de7a.png)

Concluida la descarga te aparecerá lo siguiente, seleccionas **Guardar**

![](RackMultipart20231128-1-6pfiff_html_6bcc6cc2aafc5806.png)

Diríjase a Descargas en su explorador de archivos y haga doble click en la aplicación que descargamos para ejecutarlo

![](RackMultipart20231128-1-6pfiff_html_9052933338a2838e.png)

Presione aceptar en las ventanas que le vayan apareciendo

![](RackMultipart20231128-1-6pfiff_html_9c7a7e6e67b94908.png)

Se descargará e instalará el **Instalador de Visual Studio**

![](RackMultipart20231128-1-6pfiff_html_2bce61834e82209a.png)

Seleccione las opciones de paquetes que necesitara, asegúrese de que tenga instalado **Desarrollo de ASP.NET y web** , también revise los detalles de instalación y revise que tenga todas las opciones seleccionadas

![](RackMultipart20231128-1-6pfiff_html_31141a6c1509a806.png)

Además, también diríjase a la parte de **Componentes Individuales**

![](RackMultipart20231128-1-6pfiff_html_c4de86fe68201ec.png)

Busque **Plantillas de proyecto y de elemento de .NET Framework** y selecciónelo.

![Inserting image...](RackMultipart20231128-1-6pfiff_html_a3d0858e138dd39d.png)

Con todo eso seleccionado le aparecerá el botón **Instalar** en la esquina inferior derecha

![](RackMultipart20231128-1-6pfiff_html_1c524da4f416d5d2.png) Comenzara a instalarse todos los componentes que seleccionamos

![](RackMultipart20231128-1-6pfiff_html_43da3305579655ad.png)

Una vez concluida la instalación se vera de la siguiente manera. Ya podrá iniciar y usar Visual Studio sin ningún problema

![Inserting image...](RackMultipart20231128-1-6pfiff_html_b93b7b49e4a244c5.png)

Si llega a tener algún problema con la falta del asp.net revise este video [https://youtu.be/ZcXamRtPJ2U?feature=shared](https://youtu.be/ZcXamRtPJ2U?feature=shared)

Configuración Programa

Ingrese al git para descargar el proyecto [https://github.com/CristhianEscalera/Incoterms.git](https://github.com/CristhianEscalera/Incoterms.git)

![](RackMultipart20231128-1-6pfiff_html_b1f8445015cd1253.png)

Presione el botón **Code** esto le desplegara una mini ventana donde deberá presionar **Download ZIP** esto comenzara la descarga

![](RackMultipart20231128-1-6pfiff_html_f17779c8894eb750.png)

En Descargas de su Explorador de Archivos realice clic izquierdo sobre el zip del proyecto descargado y realice la descompresión del mismo

![](RackMultipart20231128-1-6pfiff_html_95c3df988eb136d0.png)

Ingrese en la carpeta del proyecto **Incoterms-main**

![](RackMultipart20231128-1-6pfiff_html_5691644ea55641df.png)

Ingrese dentro la carpeta **Bilbao.SolucionesMedicas**

![Inserting image...](RackMultipart20231128-1-6pfiff_html_5a95d5988db5d53d.png)

Una vez ahí presione **Bilbao.SolucionesMedicas.sln** como ya tiene descargado el programa de Visual Studio podrá abrir sin ningún problema el proyecto. En caso de tener algún problema consulte los puntos anteriores para revisar que no se equivocase en otra parte

![](RackMultipart20231128-1-6pfiff_html_39e9730123259abc.png)

# 7. PROCEDIMIENTOS DE HOSTEADO / HOSTING (configuración)

- Sitio Web
- BD
- API / servicio Web
- Otros (firebase, etc.) ![](RackMultipart20231128-1-6pfiff_html_72bec1d8dc3fc04f.jpg)

El siguiente error es del dockerizado, al momento de ejecutar el dockerizado nos sale ese error que fuimos tratando de solucionar, hasta ahora seguimos sin poder solucionarlo.

# 8. GIT:

[https://github.com/CristhianEscalera/Incoterms.git](https://github.com/CristhianEscalera/Incoterms.git)

Fabiana Bilbao

![](RackMultipart20231128-1-6pfiff_html_a0de398bd5267217.jpg)

Nicole Herbas

![](RackMultipart20231128-1-6pfiff_html_ff7c68be364906df.jpg)

Cristhian Escalera ![](RackMultipart20231128-1-6pfiff_html_16a0f7656c8d3d63.png)

# 9. Personalización y configuración

Contraseña Personalizada:

Cambio de Contraseña:

Proporciona a los usuarios la capacidad de cambiar su contraseña en cualquier momento. Esta funcionalidad puede ubicarse en la opción "Cambio de Contraseña".

Confirmación de Cambios:

Implementa un proceso de confirmación para asegurarte de que el usuario haya realizado el cambio de contraseña intencionalmente, solicitando la contraseña actual antes de permitir el cambio.

# 10. Seguridad

Se asegura de que la página no se almacene en la caché del navegador a través de un bloque if (!IsPostBack) este se desactiva el almacenamiento en cache en el navegador para garantizar que no se almacene datos confidenciales, lo cual es esencial para evitar la retención de información sensible en el lado del cliente. Este enfoque se activa solo durante la carga inicial de la página, garantizando que la información no se conserve en la caché en situaciones de recarga o postback.

Posteriormente, se realiza un bloque if (SessionClass.SessionRole != "Rol") que evalúa el rol del usuario almacenado en la sesión. Esto ayuda a controlar el acceso a secciones específicas de la aplicación según el rol del usuario. Por ejemplo, si el usuario tiene el rol de "Ingresos", se redirige a la página "Ingresos.aspx"; si es un "Empleado", se redirige a "Empleado.aspx". Si el rol no coincide con ninguno, la aplicación redirige al usuario a la página de inicio de sesión ("WebLogin.aspx").

El manejo de la encriptación de algunos datos al momento de ser ingresados a la base de datos también se ha visto, como el password/contraseña el cual se encripta al ser ingresado, además de los métodos de verificación de que sea una contraseña totalmente segura.

# 11. Depuración y solución de problemas

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

- Bilbao Mercado Fabiana Mercedes

Telf: 79788863

Email: bmf0031211@est.univalle.edu

- Escalera Muñoz Cristhian Andrés

Telf:75934191

Email: emc0031008@est.univalle.edu

- Herbas Fuentes Nicole Katherin

Telf: 77492551

Email: hfn5001384@est.univalle.edu

# 12. Glosario de términos:

Incoterm: Los Incoterms son términos de comercio internacional que definen las responsabilidades y costos del comprador y del vendedor en una transacción internacional. Estos términos especifican quién es responsable del transporte, seguro y otros aspectos logísticos durante el envío de mercancías.

PostBack:se refiere a la acción de enviar datos desde una página web al servidor y recibir una respuesta.

Dockerizado: Es un proceso en el cual convierte el proyecto en una imagen y lo guarda en un contenedor, con eso el proyecto puede ser buscado en el navegador sin necesidad de estar en ejecución.

API:es un conjunto de reglas y definiciones que permite que diferentes aplicaciones se comuniquen entre sí.

FrontEnd:Es la interfaz de usuario y todo lo que los usuarios experimentan visualmente al utilizar una aplicación o visitar un sitio web.

# 13. Referencias y recursos adicionales:

**Dockerizado**

[https://www.youtube.com/watch?v=bLVVj-3\_wlA](https://www.youtube.com/watch?v=bLVVj-3_wlA)

[![Video titulado:Dockerizando y publicando una ASP .Net Core](RackMultipart20231128-1-6pfiff_html_16af21fa62b848a0.png)](https://www.youtube.com/watch?v=bLVVj-3_wlA)

# Paquetes NuGet

- ITextSharp: para poder generar el PDF.

# 14. Herramientas de Implementación:

- Lenguajes de programación:

Frontend (Cliente):

HTML5

CSS

JavaScript

Backend (Server):

C# (utilizando ASP.NET)

- Framework:

ASP.NET:

Utilizando ASP.NET para el desarrollo del lado del servidor.

- Base de Datos:

Sistema de Gestión de Bases de Datos (DBMS):

Microsoft SQL Server 2022

# 15. Bibliografía:

Microsoft. "HttpResponse.Cache Property." [https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.cache?view=netframework-4.8.1](https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.cache?view=netframework-4.8.1)

Microsoft. "HttpResponse.Redirect Method." [https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.redirect?view=netframework-4.8.1](https://learn.microsoft.com/en-us/dotnet/api/system.web.httpresponse.redirect?view=netframework-4.8.1)

Microsoft. "ASP.NET Session State Overview." [https://learn.microsoft.com/en-us/dotnet/api/system.web.sessionstate.httpsessionstate?view=netframework-4.8.1](https://learn.microsoft.com/en-us/dotnet/api/system.web.sessionstate.httpsessionstate?view=netframework-4.8.1)

Microsoft. "GridView Class." [https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview?view=netframework-4.8.1](https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview?view=netframework-4.8.1)

Microsoft. "Client-side form validation." [https://developer.mozilla.org/en-US/docs/Learn/Forms/Form\_validation](https://developer.mozilla.org/en-US/docs/Learn/Forms/Form_validation)

Microsoft. "Realizar actualizaciones por lotes (VB)." [https://learn.microsoft.com/es-es/aspnet/web-forms/overview/data-access/editing-and-deleting-data-through-the-datalist/performing-batch-updates-vb](https://learn.microsoft.com/es-es/aspnet/web-forms/overview/data-access/editing-and-deleting-data-through-the-datalist/performing-batch-updates-vb)

Microsoft. "SqlCommand.ExecuteScalar Method." [https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=dotnet-plat-ext-8.0](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=dotnet-plat-ext-8.0)

Microsoft. "SqlCommand Clase" [https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-7.0](https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-7.0)

Microsoft. "SqlCommand.ExecuteNonQuery Method" [https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executenonquery?view=dotnet-plat-ext-8.0](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executenonquery?view=dotnet-plat-ext-8.0)

Microsoft. "SqlTransaction Clase" [https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqltransaction?view=dotnet-plat-ext-7.0](https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqltransaction?view=dotnet-plat-ext-7.0)

Stackoverflow. "Trying to pass SqlCommand in SqlDataAdapter as parameters" [https://stackoverflow.com/questions/44402669/trying-to-pass-sqlcommand-in-sqldataadapter-as-parameters](https://stackoverflow.com/questions/44402669/trying-to-pass-sqlcommand-in-sqldataadapter-as-parameters)

Stackoverflow. "How to read SQL Table data into a C# DataTable" [https://stackoverflow.com/questions/6073382/how-to-read-sql-table-data-into-a-c-sharp-datatable](https://stackoverflow.com/questions/6073382/how-to-read-sql-table-data-into-a-c-sharp-datatable)

Stackoverflow. "error with addwithvalue sql parameter" [https://stackoverflow.com/questions/38463844/error-with-addwithvalue-sql-parameter](https://stackoverflow.com/questions/38463844/error-with-addwithvalue-sql-parameter)

Stackoverflow. "La consulta espera el parametro @Nombre que no se ha proporcionado" [https://es.stackoverflow.com/questions/32573/la-consulta-espera-el-parametro-nombre-que-no-se-ha-proporcionado](https://es.stackoverflow.com/questions/32573/la-consulta-espera-el-parametro-nombre-que-no-se-ha-proporcionado)

Stackoverflow. "Input string was not in a correct format, Drop down list Selected Value." [https://stackoverflow.com/questions/10028046/input-string-was-not-in-a-correct-format-drop-down-list-selected-value](https://stackoverflow.com/questions/10028046/input-string-was-not-in-a-correct-format-drop-down-list-selected-value)
