<b>Instrucciones de ejecución local</b>

<b>Requisitos previos (Debe tener instalado los siguientes entornos):</b>
1.	Visual Studio (Versión .NET 8.0)
2.	Visual Studio Code
3.	Angular (Versión 17.3.0)

<b>Requisitos de ejecución</b>

Con el fin de orientar al usuario es necesario realizar la clonación del repositorio, una vez clonado el repositorio en su máquina local dar continuidad a los siguientes pasos:
1. Ingrese a la carpeta donde se clonó el repositorio.
2. Abra SQL Server y ejecute el Query que se encuentra ubicado en la carpeta denominada "Base de Datos".
3. Dirigase a la carpeta denominada WebAPI" de doble click en la solución de Visual Studio "WebAPI.sln"
4. Ir al explorador de soluciones abrir el archivo > "appsettings.json", cambiar la Data Source de acuerdo a su instancia de SQL Server.
   ![image](https://github.com/user-attachments/assets/5896a278-b5db-4639-ae9a-db3718f26536)
   
6. Una vez la solución esté abierta en Visual Studio, ejecutar el proyecto dando clic en el icono de play ubicado en la parte superior de Visual Studio.
7. Posteriorme dirigase a la carpeta denominada "WebApp" y abra esta carpeta en Visual Studio.
8. Ingrese a src > app > Setting > abrir archivo "appsettings.ts" y cambiar la url de la api de acuerdo al localhost del Visual Studio.
   ![image](https://github.com/user-attachments/assets/be71596c-39cb-4845-b836-1d332130b008)
   
10. Una vez este abierta la carpeta en visual studio abrir la terminar y finalmente, colocar el comando servidor ng server --open para ejecutar el servidor, esperar hasta que se abra una ventana del navegador predeterminado y podra realizar una interacción con el sistema, generando la creación, actualización, eliminación y listado de los Usuario.

<b>Breve explicación sobre como se ejecuto la prueba</b>
1. Se crean vistas, y procedimiento almacenado en SQL Server
   
   ![image](https://github.com/user-attachments/assets/c3f10451-8a58-498e-b612-75e4598d3aab)
   
3. Se crea API en Visual Studio
   ![image](https://github.com/user-attachments/assets/7692335c-fab1-485e-a5a8-36518d7d89d9)
   ![image](https://github.com/user-attachments/assets/448cd48d-ac2c-4b75-890f-1b991fd78cdc)
     
5. Se crea proyecto en Visual Studio Code
   Se crea vista con home
   ![image](https://github.com/user-attachments/assets/bedbb4f1-b8e1-4da7-bc23-30a33d01e672)

   Al dar clic en fila (Customer Name, Last Order Date, Next Predicted Order) de la tabla se direcciona a las diferentes ordenes asociadas al cliente seleccionado
   ![image](https://github.com/user-attachments/assets/f10b968b-078d-4da3-82c5-f49ce7d05ef3)

   Al dar clic en columna con boton "VIEW ORDERS" se visualiza la tabla con las diferentes ordenes asociadas al cliente seleccionado en un modal
   ![image](https://github.com/user-attachments/assets/9fe100fe-af4b-4066-9213-264114bc4e70)

   Al dar clic en columna con boton "NEW ORDERS" se visualiza un modal para crear una orden nueva
   ![image](https://github.com/user-attachments/assets/2a77e7f7-4974-48b7-9c31-c7af13a1dd04)


