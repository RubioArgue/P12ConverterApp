# P12ConverterApp
Aplicación para convertir las llaves criptográficas del Ministerio de hacienda a llaves criptográficas con algoritmos más modernos. Esto suprimirá la necesidad de utilizar openssl en modo legacy, ya que algunos servidores no lo tienen activado ni lo activarán aunque uno lo solicite (También funcionará para cualquier archivo.p12 que haya sido creado con versiones viejas de openssl y deba ser actualizado).

Instrucciones:

1: Compile el proyecto para que se genere la carpeta bin/Debug.

2: Copie la carpeta openssl que se encuentra en la carpeta P12ConverterApp dentro de este proyecto y peguela en la carpeta P12ConverterApp/bin/Debug.

3: Ejecute la aplicación.

Instrucciones para el uso de la aplicación:

Ejecute el programa, se abrirá la interfas de usuario, ingrese el pin de la llave criptográfica, seleccione la ubicación del archivo a convertir, y presione el botón convertir, si el proceso se ejecutó correctamente, se creará un archivo .p12 nuevo con el nombre del alchivo origial + el sufijo _new en la misma carpeta donde se encuentra el archivo original.

Ejemplo: Si desea convertir el archivo 123456789.p12 obtendrá el archivo 123456789_new.p12 actualizado con algoritmos modernos.

Nota: Para el correcto funcionamiento de la aplicación es necesario tener la carpeta openssl en la misma carpeta que P12ConverterApp.exe.

Aquí la aplicación ya compilada y lista para utilizar: https://drive.google.com/file/d/1zob2HN_xbHhTFhkP85nEf1mhnlkw5-M-/view?usp=sharing

