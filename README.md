# 🎫 Tickets API (.NET)

API REST para gestión de tickets de soporte, desarrollada en .NET, enfocada en diseño de APIs, rendimiento y buenas prácticas de arquitectura.

---

## 📌 Descripción

Esta API permite gestionar tickets de soporte, incluyendo su creación, seguimiento, asignación y actualización de estado.

El objetivo del proyecto es demostrar la construcción de una API escalable, con manejo adecuado de datos, validaciones y control de errores.

---

## 🚀 Tecnologías

* .NET 8
* C#
* SQL Server
* Dapper / Entity Framework (según implementación)
* ASP.NET Core Web API

---

## 🧩 Arquitectura

El proyecto sigue una arquitectura por capas:

### Capa de presentación
- **Controllers** → exposición de endpoints y recepción de solicitudes HTTP

### Capa de aplicación / negocio
- **Services** → implementación de reglas de negocio y validaciones

### Capa de dominio
- **Entities** → modelo principal del sistema, representando las entidades y reglas base del negocio

### Capa de datos
- **Repositories** → acceso a base de datos y persistencia

### Capa de transporte
- **DTOs** → objetos utilizados para entrada y salida de información

---

## 📊 Funcionalidades

* Crear ticket
* Listar tickets con:

  * paginación
  * filtros (estado, prioridad, categoría)
* Obtener detalle de ticket
* Actualizar ticket
* Cambiar estado
* Asignar responsable
* Agregar comentarios
* Manejo centralizado de errores

---

## 🧱 Modelo de datos (simplificado)

### Ticket

* Id
* Código
* Título
* Descripción
* EstadoId
* PrioridadId
* CategoríaId
* UsuarioId
* AsignadoAId
* FechaCreación

### Comentario

* Id
* TicketId
* Texto
* UsuarioId
* Fecha

---

## 🔎 Ejemplo de endpoints

```http
GET    /api/tickets
GET    /api/tickets/{id}
POST   /api/tickets
PUT    /api/tickets/{id}
PATCH  /api/tickets/{id}/estado
POST   /api/tickets/{id}/comentarios
```

---

## ⚙️ Ejecución

1. Clonar repositorio
2. Configurar conexión a base de datos en `appsettings.json`
3. Ejecutar migraciones (si aplica)
4. Ejecutar proyecto:

```bash
dotnet run
```

---

## 🧠 Enfoque técnico

* Diseño de APIs REST consistentes
* Separación de responsabilidades
* Manejo de errores estructurado
* Código mantenible y escalable
* Preparado para crecimiento futuro

---

## 📈 Mejoras futuras

* Autenticación y autorización (JWT)
* Logging estructurado
* Cache (Redis)
* Documentación con Swagger avanzada
* Pruebas unitarias

---

## 📬 Notas

Este proyecto es una implementación demostrativa con fines de portafolio.
