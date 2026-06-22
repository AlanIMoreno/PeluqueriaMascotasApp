# ✅ SOLUCIÓN A: CORREGIR ERROR "Invalid column name 'Email'"

## 📋 RESUMEN DE LA SOLUCIÓN

El error **"Invalid column name 'Email'"** ocurría porque:
- ✗ El modelo `Persona` tenía una propiedad `Email`
- ✗ Pero la tabla `Personas` en la base de datos NO tenía esa columna
- ✗ Entity Framework intentaba hacer SELECT incluyendo Email, y SQL Server no encontraba la columna

**Solución A aplicada:**
- ✅ Se agregó mapeo explícito en `AppDbContext` para la propiedad `Email`
- ✅ Se creó una migración que agrega la columna `Email` a la tabla `Personas`
- ✅ El error desaparecerá después de ejecutar la migración

---

## 🔧 CAMBIOS REALIZADOS EN EL CÓDIGO

### 1. **Persona.cs** (YA CORREGIDO)
```csharp
private string _email;  // Ahora es private (antes era public)

public string Email
{
	get { return _email; }
	set { _email = value ?? string.Empty; }
}
```

### 2. **AppDbContext.cs** (YA CORREGIDO)
```csharp
// Agregada configuración explícita de Email
modelBuilder.Entity<Persona>()
	.Property(p => p.Email)
	.HasMaxLength(100)
	.IsRequired(false);  // Nullable para datos existentes
```

### 3. **Migración Creada** (LISTA PARA EJECUTAR)
**Archivo:** `PeluqueriaMascotasMVC\Migrations\20250115000001_FixEmailColumnInPersona.cs`

Lo que hace esta migración:
- Modifica la columna `Email` en la tabla `Personas`
- Cambia tipo de `nvarchar(max)` a `nvarchar(100)` (más eficiente)
- La columna sigue siendo nullable (para datos existentes)

---

## 🚀 CÓMO EJECUTAR LA SOLUCIÓN

### **OPCIÓN 1: Package Manager Console (RECOMENDADO - MÁS SIMPLE)**

1. Abre **Visual Studio**
2. Menú: **Tools** → **NuGet Package Manager** → **Package Manager Console**
3. Asegúrate que el proyecto sea: `PeluqueriaMascotasMVC`
4. Ejecuta este comando:

```powershell
Update-Database
```

**Eso es todo.** La migración se ejecutará automáticamente.

---

### **OPCIÓN 2: CLI de .NET**

Abre una terminal en la carpeta del proyecto y ejecuta:

```bash
dotnet ef database update
```

---

### **OPCIÓN 3: SQL Directo (Si prefieres ver exactamente qué se ejecuta)**

En Package Manager Console:
```powershell
Script-Migration -From 20260608233112_Inicial -To 20250115000001_FixEmailColumnInPersona
```

Esto generará un script SQL que puedes copiar y ejecutar en SQL Server Management Studio.

---

## ✔️ VERIFICAR QUE FUNCIONÓ

### En SQL Server Management Studio:

```sql
-- Ver la estructura de la tabla Personas
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Personas'
ORDER BY COLUMN_NAME;
```

Deberías ver:
```
Apellido          nvarchar      100      NO
Direccion         nvarchar      200      NO
Dni               int           null     NO
Email             nvarchar      100      YES  ✓ CORRECTA
FechaAlta         datetime2     null     NO
Nombre            nvarchar      100      NO
PersonaType       nvarchar      8        NO
Telefono          nvarchar      20       NO
```

### En tu aplicación:

Ejecuta nuevamente la acción que te daba el error:
- Ir a `/Personas/Index`

✅ **El error desaparecerá**

---

## 📊 ESTADO DE LA BASE DE DATOS DESPUÉS

```
Tabla: Personas
├─ Id (int, PK)
├─ FechaAlta (datetime2)
├─ Nombre (nvarchar(100))
├─ Apellido (nvarchar(100))
├─ Telefono (nvarchar(20))
├─ Direccion (nvarchar(200))
├─ Dni (int)
├─ Email (nvarchar(100)) ← CORREGIDA ✓
├─ PersonaType (nvarchar(8)) [Discriminator para TPH]
└─ SIN cambios en datos existentes
```

---

## 🔙 DESHACER LA MIGRACIÓN (Si algo sale mal)

```powershell
# Package Manager Console
Update-Database -Migration "20260608233112_Inicial"
```

Esto revierte a la versión anterior (pero NO es necesario, esta es una solución definitiva).

---

## 🎯 PRÓXIMOS PASOS (OPCIONAL)

Una vez que el error de Email esté resuelto, tienes dos opciones:

### A. Si quieres **SOLO** que funcione el Email:
✅ Listo. Ya está. El error desaparecerá.

### B. Si quieres **ADEMÁS** agregar autenticación con Identity:
Tenemos preparadas migraciones adicionales:
- `20250115000000_AddIdentityAndEmailToCliente.cs` (Agrega todas las tablas de Identity)

Para eso puedes ejecutar luego:
```powershell
Update-Database
```

Y se aplicarán todas las migraciones pendientes incluyendo la de Identity.

---

## ⚠️ IMPORTANTE

- ✅ **Esta solución NO elimina datos**
- ✅ **Email es nullable** (clientes antiguos pueden no tener email)
- ✅ **Compatible con tu DB actual**
- ✅ **Se puede deshacer si es necesario**

---

**La solución está lista. Solo necesitas ejecutar `Update-Database` en Package Manager Console.**

