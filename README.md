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

### Crear facturae sin firmar

#### C#

```C#

var invoice = new Invoice()
{
    DocumentNumber = "#00218",
    DocumentDate = DateTime.Now,
    CurrencyID = "EUR",
    TotalAmount = 363,
    PaymentDate = DateTime.Now,
    SellerID = "B12959755",
    SellerName = "IRENE SOLUTIONS SL",
    SellerAddress = "AV CAMINO DE ONDA, 25",
    SellerPostCode = "12530",
    SellerTown = "BURRIANA",
    SellerProvince = "CASTELLÓN",
    SellerTelephone = "964679395",
    SellerElectronicMail = "info@irenesolutions.com",
    SellerCountryID = "ESP",
    BuyerID = "B12756474",
    BuyerName = "MAC ORGANIZACION SL",
    BuyerAddress = "CL DE PRIM, 4 PLANTA 1",
    BuyerPostCode = "12003",
    BuyerTown = "CASTELLON",
    BuyerProvince = "VALENCIA",
    BuyerTelephone = "964256545",
    BuyerElectronicMail = "info@arteroconsultores.com",
    Items = new List<InvoiceItem>()
    {
        new InvoiceItem()
        {
            ItemPosition = 1,
            ItemID = "REF001",
            ItemName = "MANTENIMIENTO MENSUAL EASYSII",
            UnitOfMeasure = "REF001",
            Quantity = 1,
            NetPrice = 300,
            NetAmount = 300,
            GrossPrice = 300,
            GrossAmount = 300,
            TaxesOutput = 63,
            TotalAmount = 300
        }
    },
    TaxesOutputs = new List<InvoiceTaxesOutput>()
    {
            new InvoiceTaxesOutput()
            {
            ItemPosition = 1,
            TaxBase = 300,
            TaxRate = 21,
            TaxAmount = 63
            }
    },
    Payments = new List<InvoicePayment>()
    {
        new InvoicePayment()
        {
            ItemPosition = 1,
            PaymentTypeID = "04", // Transferencia
            PaymentDate = DateTime.Now,
            Amount = 363,
            IBAN = "ES5500893453822115046060"
        }
    }
};

// Incluimos nuestra SeviceKey en el contructor
var manager = new FacturaeManager("bWFudWVsQGlerrT8yZ.....");

var facturaeXml = manager.Create(invoice);


```
#### VB

```VB



Dim invoice As Invoice = New Invoice With
{
    .DocumentNumber = "#00218",
    .DocumentDate = DateTime.Now,
    .CurrencyID = "EUR",
    .TotalAmount = 363,
    .PaymentDate = DateTime.Now,
    .SellerID = "B12959755",
    .SellerName = "IRENE SOLUTIONS SL",
    .SellerAddress = "AV CAMINO DE ONDA, 25",
    .SellerPostCode = "12530",
    .SellerTown = "BURRIANA",
    .SellerProvince = "CASTELLÓN",
    .SellerTelephone = "964679395",
    .SellerElectronicMail = "info@irenesolutions.com",
    .SellerCountryID = "ESP",
    .BuyerID = "B12756474",
    .BuyerName = "MAC ORGANIZACION SL",
    .BuyerAddress = "CL DE PRIM, 4 PLANTA 1",
    .BuyerPostCode = "12003",
    .BuyerTown = "CASTELLON",
    .BuyerProvince = "VALENCIA",
    .BuyerTelephone = "964256545",
    .BuyerElectronicMail = "info@arteroconsultores.com",
    .Items = New List(Of InvoiceItem)(
        {
            New InvoiceItem With
            {
                .ItemPosition = 1,
                .ItemID = "REF001",
                .ItemName = "MANTENIMIENTO MENSUAL EASYSII",
                .UnitOfMeasure = "REF001",
                .Quantity = 1,
                .NetPrice = 300,
                .NetAmount = 300,
                .GrossPrice = 300,
                .GrossAmount = 300,
                .TaxesOutput = 63,
                .TotalAmount = 300
            }
        }
    ),
    .TaxesOutputs = New List(Of InvoiceTaxesOutput)(
        {
            New InvoiceTaxesOutput With
            {
                .ItemPosition = 1,
                .TaxBase = 300,
                .TaxRate = 21,
                .TaxAmount = 63
            }
        }
    ),
    .Payments = New List(Of InvoicePayment)(
        {
            New InvoicePayment With
            {
                .ItemPosition = 1,
                .PaymentTypeID = "04", ' Transferencia
                .PaymentDate = DateTime.Now,
                .Amount = 363,
                .IBAN = "ES5500893453822115046060"
            }
        }
    )
}
        
' Incluimos nuestra SeviceKey en el contructor
Dim manager As New FacturaeManager("bWFudWVsQGlerrT8yZ.....")

Dim manager As New FacturaeManager("bWFudWVsQGlyZW5lc29sdXRpb25zLmNvbTplbGVmYW50ZQ==")

Dim facturaeXml = manager.Create(invoice)

```

