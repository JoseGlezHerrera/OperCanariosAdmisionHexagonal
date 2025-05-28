# OperCanarios Admision — Arquitectura Hexagonal en C#

> Proyecto de migración de un sistema de gestión de admisiones a una arquitectura hexagonal, implementado en C# con .NET 8. Se busca una separación clara de responsabilidades, escalabilidad futura y facilidad de mantenimiento.

---

## ⚙️ Descripción General

Este repositorio contiene la versión reestructurada del sistema de admisiones de **Oper Canarios**, originalmente basado en un patrón MVC clásico. Esta versión implementa una arquitectura hexagonal (Ports and Adapters), lo que permite un desacoplamiento completo entre la lógica de negocio y los mecanismos de entrada/salida.

---

## 🎯 Objetivos Técnicos

- Desacoplar el dominio de las tecnologías externas (bases de datos, web, frameworks).
- Mejorar la testabilidad a través del uso de interfaces y dependencia por inversión.
- Separar los casos de uso del modelo de dominio y de la infraestructura.
- Mejorar la escalabilidad y mantenibilidad mediante principios SOLID.

---

## 🧱 Estructura del Proyecto

```
OperCanariosAdmisionHexagonal/
├── Oper.Admision.Api/             # Adaptadores primarios (Controllers por caso de uso)
├── Oper.Admision.Application/    # Casos de uso, Inputs, Outputs
├── Oper.Admision.Domain/         # Entidades, interfaces y lógica de negocio
├── Oper.Admision.Infrastructure/ # Implementaciones de persistencia, servicios externos
└── Oper.Admision.sln             # Solución Visual Studio
```

### 🧩 Roles de cada capa

- **API**: Define y organiza los endpoints HTTP por caso de uso.
- **Application**: Contiene la lógica de orquestación de los casos de uso, libre de dependencias.
- **Domain**: Entidades, contratos y reglas de negocio puras.
- **Infrastructure**: Adaptadores que conectan el dominio con tecnologías externas (base de datos, servicios, etc).

---

## 🚀 Ejecución Local

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/JoseGlezHerrera/OperCanariosAdmisionHexagonal.git
   cd OperCanariosAdmisionHexagonal
   ```

2. **Abrir la solución en Visual Studio**:  
   Archivo `Oper.Admision.sln`.

3. **Restaurar dependencias NuGet** (si no se hace automáticamente):

   ```bash
   dotnet restore
   ```

4. **Establecer el proyecto `Oper.Admision.Api` como inicio.**

5. **Ejecutar la API:**

   ```bash
   dotnet run --project Oper.Admision.Api
   ```

6. **La API estará disponible en:**

   - `https://localhost:7281`
   - `http://localhost:5034`

---

## 🔍 Casos de Uso Principales

| Caso de uso          | Descripción                                         | Endpoint                       |
|----------------------|-----------------------------------------------------|--------------------------------|
| CrearProblematico    | Alta de registro conflictivo                        | `POST /problematico`           |
| EliminarProblematico | Eliminación lógica por ID                           | `DELETE /problematico/{id}`    |
| FiltrarProblematico  | Filtro por tipo (Conflictivo, ProhibidaEntrada...)  | `GET /problematico?tipo=...`   |
| CrearSocio           | Alta de nuevo socio                                 | `POST /socio`                  |
| LoginUsuario         | Autenticación de usuario                            | `POST /usuario/login`          |
| Vista                | Consulta de vista consolidada                       | `GET /vista/{dni}`             |

---

## 🧪 Pruebas

- Se recomienda usar **Postman** para probar los endpoints REST.
- Cada caso de uso tiene controladores dedicados, aislados por carpeta.
- La lógica de dominio puede probarse sin necesidad de infraestructura externa.

---

## 🧠 Notas Técnicas

- Se utiliza **AutoMapper** con clases `Mapping.cs` por cada caso de uso.
- Cada `Mapping.cs` hereda de `AutoMapper.Profile`, siguiendo el patrón recomendado.
- No se usan interfaces para los `UseCase`, priorizando un flujo directo y controlado.
- Se mantiene un estilo uniforme en el uso de `Input`, `Response`, `Controller` y `Mapping` para cada caso de uso.

---

## 🧾 Repositorio Anterior (Versión Monolítica)

👉 [https://github.com/JoseGlezHerrera/OperCanariosMigracion](https://github.com/JoseGlezHerrera/OperCanariosMigracion)

Contiene la versión previa con arquitectura tradicional tipo MVC. Este proyecto fue el punto de partida para la reestructuración.

---

## 📚 Recursos Técnicos Recomendados

- [Arquitectura Hexagonal – franciscougalde.com](https://franciscougalde.com/introduccion-a-la-arquitectura-hexagonal)
- [Arquitectura Hexagonal en .NET – ByteHide](https://www.bytehide.com/blog/hexagonal-architectural-pattern-in-c-full-guide-2024)
- [Clean Architecture y Hexagonal – DevTo](https://dev.to/edwardpj/arquitectura-hexagonal-en-net-core-5e9e)
- [Documentación oficial de AutoMapper](https://automapper.org/)
