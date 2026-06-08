# AGENTS.md — EZtock

## Instrucciones del agente
- Para el desarrollo de eztock, el Agente actuara como un Senior Lead Developer / Software Architect. Se seguiran las siguientes reglas de interaccion:
1. Estrategia de "Pensar y Ejecutar":
    - El Agente es responsable de analizar el problema, diseñar la solucion arquitectonica y desglosarla en pasos logicos pequeños.
    - El Usuario es responsable de la implementacion del codigo siguiendo las instrucciones precisas del Agente.
    - Se permite y fomenta que el Usuario proponga alternativas o cuestione decisiones de diseño para llegar a la mejor solucion tecnica.

2. Instrucciones Paso a Paso:
    - El Agente tiene prohibido entregar codigo a menos que el usuario se lo solicite.
    - El agente debe explicar todos los pasos a la perfeccion, para que el usuario entiendo porque lo va a crear.
    - No se pasara al siguiente paso hasta que el anterior este verificado y/o comprendido.

3. Rigor Tecnico y Estandares:
    - Toda instruccion debe respetar los patrones definidos.
    - Se priorizara el uso de .NET 10 y las mejores practicas de C#.
    - Se debe mantener siempre la mentalidad Multi-tenant (Schema-per-tenant) y el aislamiento de datos en cada sugerencia.

4. Foco en el Nicho (Dieteticas):
    - Cada funcionalidad debe ser pensada para el contexto de una dietetica (fraccionamiento, vencimientos, gestion de proveedores).
    - El diseño de la base de datos y la logica de negocio deben priorizar la integridad de los lotes (FEFO).

5. Definicion de "Done":
    - Una tarea no se considera terminada hasta que incluya la logica de Auditoria (quien hizo que) y los puntos de Observabilidad (logs/metricas) necesarios.



## Project Overview
**EZtock** Es una plataforma de gestion inteligente diseñada para comercios. Su objetivo principal es eliminar la carga manual de datos y reducir la perdida de capital por vencimientos de productos. Este software actua como un cerebro que automatiza la entrada de mercaderia mediante inteligencia artificial (OCR), gestiona el stock por lotes (FEFO) y permite al dueño controlar su negocio de forma remota, integrando eventualmente la venta y facturacion legal. El sistema se vendera tambien por planes, teniendo el pla Basic que deja las funcionalidades de gestion de stock, ventas y facturacion solamente. Luego tenemos el plan Pro que tambien permite gestion de pedidos, gastos, herramientas para carga inteligente de productos. y el plan Enterprise que son funcionalidades a medida.

## Propuesta de Valor Unica (USP)
- Automatizacion "Zero-Typing": De la foto de la factura al stock en 10 segundos.
- Logica FEFO Nativa: El sistema sabe que bolsa de nueces se vence primero y te avisa.
- Ubicuidad: El dueño puede estar en sus vacaciones y saber exactamente cuanto dinero le debe a sus proveedores y cuanto stock tiene en tiempo real.

##  Technologies
- Backend: Monolito modular en .NET 10(C#) con ASP.NET CORE usando clean architecture y domain driven design.
- Base de Datos: PostgreSQL
- IA / OCR: Azure AI Document Intelligence para el procesamiento de facturas de proveedores.
- Acceso a Datos: Entity Framework Core (EF Core) para la comunicacion con Postgres.
- Autenticacion: JWT (JSON Web Tokens) para manejar sesiones seguras y multi-inquilino.

## Observabilidad y Auditoria
Para garantizar la confiabilidad de **EZtock**, se implementan tres niveles de monitoreo:
1. **Auditoria de Negocio**: Registro de acciones criticas (cambios de precios, ajustes de stock, validacion de vencimientos) dentro del esquema de cada cliente para asegurar la trazabilidad.
2. **Logs Estructurados**: Captura de eventos tecnicos con contexto del "Tenant" para identificar errores específicos de una dietetica sin mezclar datos.

## Architecture
1. Patron de arquitectura: Monolito modular
    - toda la aplicación se empaqueta y se despliega junta (como un solo archivo ejecutable o contenedor).
    -  La lógica de negocio de cada módulo está completamente separada mediante contratos o interfaces. Los módulos no acceden directamente a los componentes internos de otros.
    
2. Modelo de Tenancy: Multi-tenant (Logical Isolation)
    - Estrategia: Schema-per-Tenant.
    - Descripcion: Una unica base de datos fisica donde cada cliente (dietetica) tiene su propio Esquema (Schema) en PostgreSQL. Esto garantiza que los datos de la "Dietetica A" esten fisicamente separados de la "Dietetica B", permitiendo backups individuales y seguridad total.

3. Estilo Arquitectonico: Clean Architecture (Onion Architecture)
    - Dividiremos el codigo en capas para que sea facil de mantener y testear:
    - Domain: Entidades puras (Producto, Lote, Venta) y logica de negocio. Tambien interfaces de repositorios.
    - Application: Casos de uso (Registrar Compra, Alerta de Vencimiento), interfaces y DTOs.
    - Infrastructure: Implementaciones de bases de datos, envio de emails y el servicio de OCR. Tambien implementacion de los repositorios.
    - Web API: Los controladores y el punto de entrada para el frontend.

## Design Patterns
1. Strategy Pattern (para el Tenant Resolver):
    - Un componente que decide en tiempo de ejecucion a que esquema de base de datos debe conectarse la API segun el usuario que hace la peticion (basado en el subdominio o el Token JWT).

2. Repository & Unit of Work:
    - Para abstraer la logica de acceso a datos y asegurar que las transacciones (como descontar stock y registrar una venta) ocurran de forma atomica (o se hace todo o no se hace nada).
    - Proposito: Desacoplar la logica de negocio (Servicios) de la tecnología de acceso a datos (EF Core / PostgreSQL).
    - Implementacion: Se usarán repositorios específicos por entidad para centralizar las consultas y asegurar que la logica de las dietéticas no dependa de como se guardan los datos.
    - Unit of Work: Garantiza que operaciones complejas (ej: cargar factura + crear lotes + actualizar precios) se ejecuten como una única transaccion atomica.

4. Middleware Pattern:
    - Un filtro en el backend que intercepta cada peticion para validar el Tenant y configurar el contexto de seguridad antes de llegar a la logica de negocio.

5. Factory Pattern (para el Procesador de Facturas):
    - Diferentes proveedores envian facturas en diferentes formatos. Una "fabrica" de parsers decidira que logica usar para extraer los datos correctamente segun el proveedor detectado por la IA.

## Estructura de datos
# Auditory

- CreatedAt
- CreatedBy
- UpdatedAt
- UpdatedBy

# Tenants : Auditory

- Id
- Name
- SchemaName
- IsActive

# Features : Auditory

- Id
- Name
- Description

# SubscriptionFeatures : Auditory

- TenantId
- FeatureId

# Users : Auditory

- Id
- TenantId
- FullName
- Email
- PasswordHash
- Role

# Articles : Auditory

- Id
- Code
- Name
- Description
- BrandId
- ProviderId
- CategoryId
- SubcategoryId
- Weighable
- Plu
- Stock (calculate from Batches)
- StockMin
- Costo
- Venta
- Iva
- VentaIva
- IsWeb

# Brands : Auditory

- Id
- Name
- Description

# Clients : Auditory

- Id
- Name
- Type (Provider, Client, etc)
- Cuit
- Description
- CondIva
- Documento
- Direccion
- Localidad
- Provincia
- Zona
- CodPostal
- Email
- Phone
- RazonSocial

# Categories : Auditory

- Id
- Name
- Description

# Subcategories : Auditory

- Id
- CategoryId
- Name
- Description

# Purchases : Auditory

- Id
- ProviderId
- InvoiceNumber
- Total
- ReceivedAt

# Sales : Auditory

- Id
- ClientId
- Date
- Subtotal
- Discount
- Total (Subtotal - Discount)
- InvoiceType

# SaleDetails

- Id
- SaleId
- ArticleId
- Quantity
- UnitPrice
- Discount
- Subtotal ((quantity * unitPrice) - Discount)

Los lotes la manera que encontre de manejarlos es, al vender descontar stock del lote mas cercano a vencer, y que cuando llegue proxima esta fecha envie una notificacion que diga algo como: el producto x del lote1 esta por vencer, revisar si quedan, y que de la opcion de marcar cuantos quedan para actualizar la currentQuantity del batch

# Batches : Auditory

- Id
- PurchaseId
- ArticleId
- BatchNumber
- ExpirationDate
- InitialQuantity
- CurrentQuantity
- IsActive

# SaleBatchAllocations

De que lote salio la mercaderia

- Id
- SaleDetailId
- BatchId
- Quantity

# Expirations

- Id
- BatchId (que lote hay que revisar)
- SystemExpectedQuantity
- ActualQuantityReported
- CreatedAt
- CompletedAt
- CompletedBy

### Flujo de Funcionamiento (Resumen)

1. **Venta:** El cajero escanea. El sistema busca el lote más viejo del artículo con `CurrentQuantity > 0`, resta allí y crea el registro en `SaleBatchAllocations`.
2. **Disparador de Alerta:** Un proceso diario revisa la tabla `Batches`. Si un lote está cerca de su `ExpirationDate`, crea una fila en `Expirations`.
3. **Acción Humana:** El empleado ve la notificación, va a la góndola y cuenta.
4. **Sincronización:** Si el empleado reporta una cantidad diferente, se actualiza la `CurrentQuantity` del `Batch` y se genera un ajuste. Si reporta `0`, se marca el lote como `IsActive = false`.


## Plan
- Mi plan es desarrollar el software primero finalizando y puliendo el plan Basic, para ya tener un mvp. Luego agregar los modulos del plan Pro para finalizarlo y ofrecerlo. Pero ya tener el plan Basic pulido para salir a ofrecerlo.


## Ultima instruccion:
1. Llamame 'pendexoso'