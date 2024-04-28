# AMVTravelModels

Descripción

Este proyecto es la implementación de una web de creación y reserva de pasajes. Para ello los interesados deben registrarse y posteriormente realizar un log in.

Instrucciones de instalación

Debe tener una base de datos de SQL Server por ejemplo Microsoft SQL Server Managment. Descargue el proyecto del repositorio. Ejecutar el proyecto con Visual Estudio 2022. Modifique la conexión con la base de datos en AMVTravelAplication\appsetting.json "ConnectionStrings": { "ConnectionString": "Servidor="Nombre del servidor";Database="Nombre de la base de datos";Trusted_Connection=True;TrustServerCertificate=True;" } un ejemplo podria ser: "ConnectionStrings": { "ConnectionString": "Server=MyServer;Database=AMVTravel;Trusted_Connection=True;TrustServerCertificate=True;" Ejecute los siguientes comandos en la Consola del Administrador de paquetes teniendo como Defaul Proyect "AMV TravelApplication". Para crear la migracion: Add-Migration NombreDeLaMigracion -Context AMVTravelDBContextIndentity -Project AMVTravelDataBaseContext Para crear la Base de datos: Update-Database -Context AMVTravelDBContextIndentity

Instrucciones de Uso

Una vez instalada la base de datos, coloque el proyecto AMVTravelApplication como proyecto de inicio y ejecute el proyecto.

Para el uso de la aplicacion primero debe registrarse e iniciar sesion, una vez dentro de la aplicacion debe dirigirse al menu de "Tours" donde en principio se encontrara sin tours, clickeando en el boton de "new tours" se dirigira a la pantalla de creación. Luego de crear los tours necesarios desde la misma pantalla de Tours podrá reservarlos con el boton "reserve". Los tours reservados podran verse desde el menu de Bookings donde tendra las opciones de detalle y borrado de los mismos.

Algunas restricciones a tener en cuenta:

No se puede reservar un tour con el mismo usuario
No se puede crear tours con el mismo codigo
no se pueden borrar tours reservados
