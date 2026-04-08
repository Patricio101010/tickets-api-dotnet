# 🎫 Ticketing API (.NET)

API REST desarrollada en .NET para la gestión de tickets de soporte, diseñada con una arquitectura por capas y orientada a buenas prácticas de desarrollo backend.

---

## 🚀 Descripción

Este proyecto implementa un sistema de tickets que permite:

- Crear y gestionar tickets
- Actualizar estado y asignación
- Registrar comentarios asociados
- Consultar información con filtros y paginación
- Exponer catálogos (usuarios, prioridades, categorías)

El objetivo es demostrar una arquitectura limpia, mantenible y escalable, aplicando separación de responsabilidades.

---

## 🧩 Arquitectura

El proyecto sigue una arquitectura por capas:

### Capa de presentación (`Api`)
- Controllers
- Exposición de endpoints REST
- Manejo de solicitudes HTTP

### Capa de aplicación (`Application`)
- Services
- Reglas de negocio
- Validaciones

### Capa de dominio (`Domain`)
- Entities
- Enums
- Interfaces de repositorio

### Capa de infraestructura (`Infrastructure`)
- Repositories
- Acceso a datos (Dapper / SQL Server)
- Configuración de conexión

### Capa de transporte (`Transport`)
- DTOs (Request / Response)
- Modelos de entrada y salida

---

## 🛠 Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Dapper
- SQL Server
- FluentValidation
- Swagger (OpenAPI)

---

## 📌 Endpoints principales

### 🎫 Tickets

| Método | Endpoint | Descripción |
|-------|--------|------------|
| GET | `/api/tickets` | Obtener tickets (con filtros y paginación) |
| GET | `/api/tickets/{id}` | Obtener ticket por ID |
| POST | `/api/tickets` | Crear ticket |
| PUT | `/api/tickets/{id}` | Actualizar ticket |
| PATCH | `/api/tickets/{id}/status` | Actualizar estado |

---

### 💬 Comentarios

| Método | Endpoint | Descripción |
|-------|--------|------------|
| GET | `/api/tickets/{ticketId}/comments` | Listar comentarios |
| POST | `/api/tickets/{ticketId}/comments` | Crear comentario |

---

### 📚 Catálogos

| Método | Endpoint |
|-------|----------|
| GET | `/api/catalogs/categories` |
| GET | `/api/catalogs/priorities` |
| GET | `/api/catalogs/users` |

---

## ⚙️ Ejecución del proyecto

### 1. Clonar repositorio

```bash
git clone https://github.com/Patricio101010/tickets-api-dotnet.git
cd tickets-api-dotnet
```
## 📬 Notas

Este proyecto es una implementación demostrativa con fines de portafolio.
