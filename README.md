# PruebaTecnica

Este proyecto fue realizado con .Net version 6 y SQL Server.

## Consideraciones

Se recomienda usar Visual Studio Community (o alguna otra de sus versiones) para abrir este proyecto.

## Desplegar aplicación

1. Abrir la carpeta `PruebaTecnica` y ejecute el archivo `PruebaTecnica.sln`.

2. Una vez Abierta la solución ingrese en el archivo `Api/PruebaTecnica/appsettings.json` y modifique la propiedad `PruebaTecnicaDbConnection` por su cadena de conexión.

    1. Si es su servidor local y puede acceder al mismo con sus credenciales de windows, entonces en el valor de `PruebaTecnicaDbConnection` cambie el `JUAN\\SQLEXPRESS` por el nombre de su servidor.
    2. Si va a usar una base de datos externa con autenticación de usuario de sql server cambie el valor de `PruebaTecnicaDbConnection` por algo como esto `Server=<su servidor>;Initial Catalog=Registration;Persist Security Info=False;User ID=<usuario>;Password=<contraseña>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;`.

3. En la parte superior izquierda busque la opción de `Herramientas -> Administrador de Paquetes Nuget -> Consola del Administrador de paquetes`.
4. Se abrirá una cosola en la que buscará en la parte superior una opción llamada `Proyecto predeterminado` donde seleccionará el que diga `PruebaTecnica.Infrastructure`.
5. Una vez seleccionado el proyecto en la consola del administrador de paquetes ejecute el comando `Update-Database -Context PruebaTecnicaWriteContext`.
6. Una vez ejecutado el comando y asegurandose de que no hayan ocurrido errores ejecute la aplicación presionando en su teclado la tecla `F5` o el boton de ejecucíon de Visual Studio.
7. Si realizo todo el procedimiento de manera correcta deberia crearse una nueva instancia de su navegador por defecto mostrando el swagger de la api.

**Notas**:
- 
1. **Consideraciones:** Pueden consumir directamente la api desde el swagger o pueden descargar [Aqui](https://drive.google.com/file/d/1Tdka-fUfBkm0U0FzSWm-p0UMj9fH1pI2/view?usp=drive_link) una colección de postman con ejemplos de como utilizar la api
2. **Arquitectura:** El proyecto se creo una arquitectura hexagonal con DDD en la que se separaron las capas de dominio, aplicación, infraestructura y presentación en diferentes proyectos, esto con el fin de hacer mantenible cada una de las capas y escalable en el tiempo.
3. **Excepciones:** En el manejo de excepciones se capturan y retornan de forma controlada a través de un middleware, tanto las excepciones dinámicas de FluentValidation y las excepciones no controladas.
4. **Patrones de diseño:** Se usaron diferentes patrones de diseño para su construcción entre los cuales estan: Respository, DependencyInjection-Singleton, Mediator, Decorator y Result
5. **Persistencia:** 

    1. Para la persistencia de datos se utilizó SQL Server con EntityFramework con enfoque CodeFirst donde las entidades primero se crean en la capa domain y luego se actualiza la base de datos en base a la misma.
    2. Se separaron los contextos de modificación y lectura para que con el tiempo y posible aumento del proyecto no se creen esperas entre las operaciones de lectura y modificación respectivamente.
    3. Asi mismo se usa una clase `DbContextOptionsSetup` donde se hacen configuraciones de reconexión en caso de fallas de en la conexión al servidor
