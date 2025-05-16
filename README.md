# PruebaTecnica

Este proyecto fue realizado con .Net version 6 y SQL Server.

## Consideraciones

Se recomienda usar Visual Studio Community (o alguna otra de sus versiones) para abrir este proyecto.

## Desplegar aplicación

1. Abrir la carpeta `PruebaTecnica` y ejecute el archivo `PruebaTecnica.sln`.

2. Una vez Abierta la solución ingrese en el archivo `Api/PruebaTecnica/appsettings.json` y modifique la propiedad `PruebaTecnicaDbConnection` por su cadena de conexión.

    1. Si es su servidor local y puede acceder al mismo con sus credenciales de windows, entonces en el valor de `PruebaTecnicaDbConnection` cambie el `JUAN\\SQLEXPRESS` por el nombre de su servidor.
    2. Si va a usar una base de datos externa con autenticación de usuario de sql server cambie el valor de `PruebaTecnicaDbConnection` por algo como esto `Server=<su servidor>;Initial Catalog=PruebaTecnicaIFX;Persist Security Info=False;User ID=<usuario>;Password=<contraseña>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;`.

3. En la parte superior izquierda busque la opción de `Herramientas -> Administrador de Paquetes Nuget -> Consola del Administrador de paquetes`.
4. Se abrirá una cosola en la que buscará en la parte superior una opción llamada `Proyecto predeterminado` donde seleccionará el que diga `PruebaTecnica.Infrastructure`.
5. Una vez seleccionado el proyecto en la consola del administrador de paquetes ejecute el comando `Update-Database`.
6. Una vez ejecutado el comando y asegurandose de que no hayan ocurrido errores ejecute la aplicación presionando en su teclado la tecla `F5` o el boton de ejecucíon de Visual Studio.
7. Si realizo todo el procedimiento de manera correcta deberia crearse una nueva instancia de su navegador por defecto mostrando el swagger de la api.