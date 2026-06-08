# EZtock API Reference

## Introducción

- **Base URL:** `https://localhost:{port}/api`
- **Content-Type:** `application/json`
- **Autenticación:** JWT Bearer Token (vía `Authorization: Bearer <token>`)
- **Formato de errores:** `{ "error": "mensaje descriptivo" }`

Actualmente **ningún endpoint requiere autenticación** (los controladores no usan `[Authorize]`).

---

## Autenticación

### `POST /api/auth/register`

Registra un nuevo usuario en el sistema.

**Request Body:**

| Campo    | Tipo     | Descripción                        |
| -------- | -------- | ---------------------------------- |
| FullName | string   | Nombre completo del usuario        |
| Dni      | string   | Documento de identidad             |
| Email    | string   | Correo electrónico                 |
| Phone    | string   | Teléfono                           |
| Password | string   | Contraseña (se hashea con BCrypt)  |
| Role     | UserRole | `Admin`, `Owner` o `Employee`      |

**Response `200 OK`:**
```json
{
  "fullName": "Juan Pérez",
  "dni": "12345678",
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "role": "Owner"
}
```

---

### `POST /api/auth/login`

Inicia sesión con credenciales existentes.

**Request Body:**

| Campo    | Tipo   |
| -------- | ------ |
| Email    | string |
| Password | string |

**Response `200 OK`:**
```json
{
  "fullName": "Juan Pérez",
  "dni": "12345678",
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "role": "Owner"
}
```

**Errores posibles:**
- `401 Unauthorized` — Credenciales inválidas

---

## Artículos

### `POST /api/article`

Crea un nuevo artículo. Valida que existan Brand, Provider, Category y SubCategory referenciados, y que no haya duplicados por Code/Name/PLU.

**Request Body:**

| Campo         | Tipo    | Descripción                           |
| ------------- | ------- | ------------------------------------- |
| Code          | string  | Código interno del artículo           |
| Name          | string  | Nombre                                |
| Description   | string  | Descripción                           |
| BrandId       | Guid    | ID de la marca                        |
| ProviderId    | Guid    | ID del proveedor (tabla Clients)      |
| CategoryId    | Guid    | ID de la categoría                    |
| SubCategoryId | Guid    | ID de la subcategoría                 |
| Weighable     | bool    | ¿Es pesable?                          |
| Plu           | string  | Código PLU (para balanza)            |
| Stock         | decimal | Stock actual                          |
| StockMin      | decimal | Stock mínimo                          |
| CostPrice     | decimal | Precio de costo                       |
| SalePrice     | decimal | Precio de venta                       |
| Iva           | decimal | Porcentaje de IVA                     |
| CostPriceIva  | decimal | Precio de costo con IVA              |
| SalePriceIva  | decimal | Precio de venta con IVA              |
| IsPublic      | bool    | Visible en web                        |

**Response `200 OK`:** Devuelve el `Article` creado (incluye `Id`, `CreatedAt`, `CreatedBy`, etc.).

**Errores posibles:**
- `409 Conflict` — Marca/Proveedor/Categoría/Subcategoría no encontrada, o artículo ya existente

---

## Marcas

### `POST /api/brand`

Crea una nueva marca.

**Request Body:**

| Campo       | Tipo   |
| ----------- | ------ |
| Name        | string |
| Description | string |

**Response `200 OK`:** Devuelve el `Brand` creado.

---

## Categorías

### `POST /api/category`

Crea una nueva categoría.

**Request Body:**

| Campo       | Tipo   |
| ----------- | ------ |
| Name        | string |
| Description | string |

**Response `200 OK`:** Devuelve el `Category` creado.

---

## Subcategorías

### `POST /api/subcategory`

Crea una nueva subcategoría asociada a una categoría.

**Request Body:**

| Campo       | Tipo   |
| ----------- | ------ |
| Name        | string |
| Description | string |
| CategoryId  | Guid   |

**Response `200 OK`:** Devuelve el `SubCategory` creado.

---

## Provincias

### `POST /api/province`

Crea una nueva provincia.

**Request Body:**

| Campo       | Tipo   |
| ----------- | ------ |
| Name        | string |
| Description | string |

**Response `200 OK`:** Devuelve el `Province` creado.

---

## Zonas

### `POST /api/zone`

Crea una nueva zona asociada a una provincia.

**Request Body:**

| Campo       | Tipo   |
| ----------- | ------ |
| Name        | string |
| Description | string |
| ProvinceId  | Guid   |

**Response `200 OK`:** Devuelve el `Zone` creado.

---

## Clientes

### `POST /api/client`

Crea un nuevo cliente o proveedor. Valida que existan Province y Zone referenciados.

**Request Body:**

| Campo       | Tipo       | Descripción                                       |
| ----------- | ---------- | ------------------------------------------------- |
| FullName    | string     | Nombre completo                                   |
| Type        | ClientType | `Client` o `Provider`                             |
| Dni         | string     | Documento de identidad                            |
| Cuit        | string     | CUIT                                              |
| Description | string     | Descripción                                       |
| CondIva     | CondIva    | `ResponsableInscripto`, `Monotributista`, `Exento` o `ConsumidorFinal` |
| Address     | string     | Dirección                                         |
| ProvinceId  | Guid       | ID de provincia                                   |
| ZoneId      | Guid       | ID de zona                                        |
| PostalCode  | int        | Código postal                                     |
| Email       | string     | Correo electrónico                                |
| Phone       | string     | Teléfono                                          |
| RazonSocial | string     | Razón social                                      |

**Response `200 OK`:** Devuelve el `Client` creado (incluye `Province` y `Zone`).

**Errores posibles:**
- `409 Conflict` — Provincia o Zona no encontrada


---

## Manejo de Errores

El middleware `ExceptionHandlingMiddleware` intercepta todas las excepciones y devuelve:

| Código | Tipo                        | Respuesta                           |
| ------ | --------------------------- | ----------------------------------- |
| 401    | `UnauthorizedException`     | `{ "error": "mensaje" }`            |
| 404    | `NotFoundException`         | `{ "error": "mensaje" }`            |
| 409    | `ConflictException`         | `{ "error": "mensaje" }`            |
| 500    | Excepción no controlada     | `{ "error": "Error interno del servidor" }` |

---

## Apéndice: Modelos de Datos

### Auditoría (base)

Toda entidad que hereda de `AuditableEntity` incluye:

| Campo      | Tipo     |
| ---------- | -------- |
| CreatedBy  | string   |
| CreatedAt  | DateTime |
| UpdatedBy  | string   |
| UpdatedAt  | DateTime |

### Enumeraciones

| Enum        | Valores                                                   |
| ----------- | --------------------------------------------------------- |
| `UserRole`  | `Admin`, `Owner`, `Employee`                              |
| `ClientType`| `Client`, `Provider`                                      |
| `CondIva`   | `ResponsableInscripto`, `Monotributista`, `Exento`, `ConsumidorFinal` |
| `InvoiceType`| `A`, `B`, `X`                                            |
| `PlanType`  | `Basic`, `Pro`, `Enterprise`                              |

### Entidades que retornan los endpoints

#### `Article`

| Campo         | Tipo     | Notas                        |
| ------------- | -------- | ---------------------------- |
| Id            | Guid     |                              |
| Code          | string   |                              |
| Name          | string   |                              |
| Description   | string   |                              |
| BrandId       | Guid     |                              |
| Brand         | Brand    | Incluido en respuesta        |
| ProviderId    | Guid     |                              |
| Provider      | Client   | Incluido en respuesta        |
| CategoryId    | Guid     |                              |
| Category      | Category | Incluido en respuesta        |
| SubCategoryId | Guid     |                              |
| SubCategory   | SubCategory | Incluido en respuesta     |
| Weighable     | bool     |                              |
| Plu           | string   |                              |
| Stock         | decimal  |                              |
| StockMin      | decimal  |                              |
| CostPrice     | decimal  |                              |
| SalePrice     | decimal  |                              |
| Iva           | decimal  |                              |
| CostPriceIva  | decimal  |                              |
| SalePriceIva  | decimal  |                              |
| IsPublic      | bool     |                              |
| Batches       | ICollection | No incluido por defecto    |
| + Auditoría   |          |                              |

#### `Brand / Category / Province`

| Campo       | Tipo   |
| ----------- | ------ |
| Id          | Guid   |
| Name        | string |
| Description | string |
| + Auditoría |        |

#### `SubCategory`

| Campo      | Tipo     |
| ---------- | -------- |
| Id         | Guid     |
| Name       | string   |
| Description| string   |
| CategoryId | Guid     |
| + Auditoría|          |

#### `Zone`

| Campo      | Tipo     |
| ---------- | -------- |
| Id         | Guid     |
| Name       | string   |
| Description| string   |
| ProvinceId | Guid     |
| Province   | Province |
| + Auditoría|          |

#### `Client`

| Campo       | Tipo       |
| ----------- | ---------- |
| Id          | Guid       |
| FullName    | string     |
| Type        | ClientType |
| Dni         | string     |
| Cuit        | string     |
| Description | string     |
| CondIva     | CondIva    |
| Address     | string     |
| ProvinceId  | Guid       |
| Province    | Province   |
| ZoneId      | Guid       |
| Zone        | Zone       |
| PostalCode  | int        |
| Email       | string     |
| Phone       | string     |
| RazonSocial | string     |
| + Auditoría |            |
