# 📌 Proyecto: Sistema de Gestión de Admisión – Oper Canarios

Este proyecto representa la migración completa del sistema de admisión de Oper Canarios a una arquitectura hexagonal (clean architecture), utilizando C# y .NET 6. El sistema expone una API REST profesional, desacoplada del frontend embebido original.

---

## 📐 Arquitectura

El sistema sigue una **arquitectura hexagonal**, organizada en:

- **Domain**: Entidades y contratos (interfaces)
- **Application**: Casos de uso (`UseCase`, `Input`, `Output`)
- **Infrastructure**: Implementación de los contratos (repositorios, acceso a datos)
- **Api**: Controladores, DTOs, mapeos y endpoints REST

```
Oper.Admision
├── Api
├── Application
├── Domain
└── Infrastructure
```

---

## 🚀 Setup del Proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tuusuario/admision-hexagonal.git
   cd admision-hexagonal
   ```

2. Crear la base de datos:
   - Usa el archivo `exportarheidi.sql` para importar la estructura y datos iniciales.
   - Asegúrate de tener **MySQL** en marcha.

3. Configurar `appsettings.json`:
   - Añade tu cadena de conexión a MySQL
   - Añade las claves JWT y credenciales de correo

4. Ejecutar el proyecto:
   ```bash
   dotnet run --project Oper.Admision.Api
   ```

5. Abrir Swagger:
   - [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🧪 Validación

- Todos los endpoints han sido probados manualmente con **Postman**
- Ejemplos incluidos:
  - Login
  - Crear socio
  - Obtener visitas por socio
  - Eliminar visita (devuelve mensaje profesional)

---

## 🔒 Seguridad

- Login basado en **JWT**
- Sesiones protegidas por middleware
- Contraseñas cifradas con algoritmo TripleDES (recomendación: migrar a `bcrypt` en el futuro)

---

## 📦 Base de datos

- Motor: **MySQL**
- Script de creación incluido: `exportarheidi.sql`
- No se utilizan migraciones automáticas (`EF Migrations`)

---

## 🌐 Frontend

⚠️ El sistema original incluía Razor Pages + AngularJS.  
**Este nuevo sistema es exclusivamente un backend API REST**.

---

## 📄 Documentación de Endpoints

- Swagger habilitado automáticamente en desarrollo
- URL: `/swagger`

---

## 📈 Futuras Mejoras

- Migrar cifrado de contraseñas a hashing (`bcrypt`)
- Añadir tests automáticos (xUnit/NUnit)
- Documentación Swagger enriquecida con `[ProducesResponseType]`
- Posible desacoplamiento de configuración a variables de entorno

---

## ✍️ Autor

Jose Carlos González Herrera  
Proyecto desarrollado en prácticas para **Oper Canarios**  
Ciclo de Desarrollo de Aplicaciones Multiplataforma (1º DAM)

---

## ✅ Estado del Proyecto

🟢 100% Migrado y funcional
