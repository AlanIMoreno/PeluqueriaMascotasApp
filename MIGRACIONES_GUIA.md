# 📋 GUÍA DE APLICACIÓN DE MIGRACIONES - INTEGRACIÓN IDENTITY

## ✅ MIGRACIONES CREADAS

Se han creado las siguientes migraciones de forma segura y NO DESTRUCTIVA:

### Migración: `AddIdentityAndEmailToCliente`
**Archivo:** `20250115000000_AddIdentityAndEmailToCliente.cs`

**Cambios en la Base de Datos:**

1. **Nuevas columnas en tabla `Personas`:**
   - `Email` (nvarchar(100), nullable)
   - `IdentityUserId` (nvarchar(450), nullable) - Foreign Key a AspNetUsers

2. **Nuevas tablas de Identity:**
   - `AspNetRoles` - Para roles de seguridad
   - `AspNetUsers` - Datos de autenticación
   - `AspNetUserRoles` - Relación usuario-rol
   - `AspNetUserClaims` - Claims de usuario
   - `AspNetUserLogins` - Logins externos
   - `AspNetRoleClaims` - Claims de rol
   - `AspNetUserTokens` - Tokens (remember me, etc)

3. **Características de seguridad:**
   - Tablas heredadas de `IdentityDbContext`
   - Índices para búsqueda de usuarios por username y email
   - Claves primarias y foráneas configuradas correctamente

---

## 🚀 CÓMO APLICAR LA MIGRACIÓN

### **OPCIÓN 1: Usar Package Manager Console (Recomendado)**

1. Abre Visual Studio
2. Ve a **Tools** → **NuGet Package Manager** → **Package Manager Console**
3. Asegúrate de que el proyecto sea `PeluqueriaMascotasMVC`
4. Ejecuta los siguientes comandos en orden:

```powershell
# Ver migraciones pendientes
Get-Migration

# Aplicar la migración
Update-Database
```

### **OPCIÓN 2: Usar CLI de .NET**

Abre una terminal en la carpeta del proyecto y ejecuta:

```bash
# Ver migraciones pendientes
dotnet ef migrations list

# Aplicar la migración
dotnet ef database update
```

### **OPCIÓN 3: Aplicar SQL directamente (Si quieres ver qué se ejecuta)**

1. En Package Manager Console, genera el script SQL:
```powershell
Script-Migration -From 20260608233112_Inicial -To 20250115000000_AddIdentityAndEmailToCliente
```

2. Copia el SQL y ejecútalo en SQL Server Management Studio

---

## ⚠️ PUNTOS CRÍTICOS ANTES DE EJECUTAR

1. **Copia de seguridad:** Haz backup de tu BD antes (opcional pero recomendado)
   ```sql
   BACKUP DATABASE [PeluqueriaMascotasDb] TO DISK = 'C:\Backups\PreIdentity.bak'
   ```

2. **NO se eliminarán datos:**
   - ✅ Tabla `Personas` - SIN cambios estructurales, solo se agregan columnas
   - ✅ Tabla `Clientes` - SIN cambios, hereda de Personas (TPH)
   - ✅ Tabla `Mascotas` - SIN cambios
   - ✅ Tabla `Empleados` - SIN cambios
   - ✅ Todos los datos existentes persisten

3. **Columnas nuevas nullable:**
   - `Email` es nullable (clientes antiguos pueden no tener email)
   - `IdentityUserId` es nullable (solo se asigna cuando el cliente se registre)

---

## ✔️ VERIFICAR QUE LA MIGRACIÓN SE APLICÓ CORRECTAMENTE

### **En SQL Server Management Studio:**

```sql
-- Ver si las nuevas columnas existen
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Personas'
ORDER BY COLUMN_NAME;

-- Debería incluir: Email, IdentityUserId

-- Ver si la tabla AspNetUsers fue creada
SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE 'AspNet%'
ORDER BY TABLE_NAME;

-- Debería mostrar al menos 7 tablas AspNet*
```

### **En Visual Studio:**

```csharp
// En Package Manager Console
Get-Migration

# Debería mostrar:
# 20250115000000_AddIdentityAndEmailToCliente [Pendiente] o [Aplicada]
```

---

## 🔙 DESHACER LA MIGRACIÓN (Si hay problemas)

Si por alguna razón necesitas deshacer los cambios:

```powershell
# Package Manager Console
Update-Database -Migration "20260608233112_Inicial"

# O con CLI
dotnet ef database update 20260608233112_Inicial
```

Esto eliminará todas las tablas de Identity y las nuevas columnas de Personas.

---

## 📊 ESTADO ACTUAL DE LA BASE DE DATOS

Después de aplicar la migración:

```
┌─────────────────────────────────────────┐
│         TABLAS DE IDENTITY (NUEVAS)     │
├─────────────────────────────────────────┤
│ AspNetRoles                             │
│ AspNetUsers          ← Almacena logins  │
│ AspNetUserRoles                         │
│ AspNetUserClaims                        │
│ AspNetUserLogins                        │
│ AspNetRoleClaims                        │
│ AspNetUserTokens                        │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│    TABLAS EXISTENTES (SIN CAMBIOS)      │
├─────────────────────────────────────────┤
│ Personas     ← + Email, IdentityUserId  │
│ Clientes     ← (hereda de Personas)     │
│ Empleados    ← (hereda de Personas)     │
│ Mascotas     ← (sin cambios)            │
│ Servicios    ← (sin cambios)            │
│ Turnos       ← (sin cambios)            │
│ ... y todas las demás                   │
└─────────────────────────────────────────┘
```

---

## 🎯 PRÓXIMOS PASOS DESPUÉS DE MIGRAR

Una vez aplicada la migración, puedes:

1. **Crear AccountController** (login/register)
2. **Crear vistas de autenticación** (Login.cshtml, Register.cshtml)
3. **Adaptar MascotasController** para filtrar por usuario logueado
4. **Proteger endpoints** con `[Authorize]`

---

## ❓ SOLUCIÓN DE PROBLEMAS

### Problema: "Package 'Microsoft.AspNetCore.Identity' not found"
**Solución:** 
```powershell
# En Package Manager Console
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 10.0.0
```

### Problema: "Cannot open database file..."
**Solución:** Verifica que la cadena de conexión en `appsettings.json` sea correcta

### Problema: "There are pending model changes..."
**Solución:** Ejecuta `dotnet ef migrations add` primero (pero esto no debería suceder, ya que tenemos la migración creada)

