# <img src='https://facturae.irenesolutions.com/img/logo-heart.png' style='width:80px;'/>  Irene.Solutions.Facturae


Irene.Solutions.Facturae la biblioteca .net para el trabajo con facturae y FACe creada por [Irene Solutions](http://www.irenesolutions.com) . La finalidad de esta herramienta es simplificar los trabajos de serialización xml, firma y envío de documentos facturae a FACe.
Si necesita soporte o tiene alguna sugerencia, por favor, nos lo puede hacer saber en support@irenesolutions.com.
</br>
</br>

## Primeros Pasos

Bienvenido a la herramienta de Irene.Solutions.Facturae Gestiona con facilidad tu comunicación con FACe y la generación, firma y almacenamiento de documentos facturae. En primer lugar necesitamos generar la ServiceKey que nos permitirá el uso de la librería. En el siguiente enlace [obtener mi ServiceKey](https://facturae.irenesolutions.com/go) podemos obtener nuestra clave.

Una vez obtenida la ServiceKey, utilizaremos la misma para crear una instancia de la clase FacturaeManager, que nos va a permitir generar nuestros documentos facturae, firmar los mismos y enviarlos.

### Ejemplo de creación de una instancia de la clase FacturaeManager
#### C#

```C#

// Incluimos nuestra SeviceKey en el contructor
var manager = new FacturaeManager("bWFudWVsQGlerrT8yZ.....");

```
#### VB

```VB

' Incluimos nuestra SeviceKey en el contructor
Dim manager As New FacturaeManager("bWFudWVsQGlerrT8yZ.....")

```

