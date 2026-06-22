-- ============================================================
-- SCRIPT DE VERIFICACIÓN - MIGRACIONES IDENTITY
-- Ejecutar en SQL Server Management Studio
-- ============================================================

-- 1. VERIFICAR QUE LAS COLUMNAS SE AGREGARON A PERSONAS
PRINT '=== VERIFICANDO COLUMNAS EN PERSONAS ===';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Personas'
ORDER BY COLUMN_NAME;

-- 2. CONTAR PERSONAS EXISTENTES (debe haber datos)
PRINT '';
PRINT '=== CONTANDO REGISTROS EN PERSONAS ===';
SELECT COUNT(*) as 'Total Personas', 
	   SUM(CASE WHEN PersonaType = 'Cliente' THEN 1 ELSE 0 END) as 'Total Clientes',
	   SUM(CASE WHEN PersonaType = 'Empleado' THEN 1 ELSE 0 END) as 'Total Empleados'
FROM Personas;

-- 3. VERIFICAR QUE MASCOTAS SIGUE INTACTA
PRINT '';
PRINT '=== VERIFICANDO MASCOTAS ===';
SELECT COUNT(*) as 'Total Mascotas'
FROM Mascotas;

-- 4. VERIFICAR NUEVAS TABLAS DE IDENTITY
PRINT '';
PRINT '=== VERIFICANDO TABLAS DE IDENTITY ===';
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME LIKE 'AspNet%'
ORDER BY TABLE_NAME;

-- 5. ESTRUCTURA DE AspNetUsers
PRINT '';
PRINT '=== ESTRUCTURA DE AspNetUsers ===';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'AspNetUsers'
ORDER BY COLUMN_NAME;

-- 6. RELACIONES (FOREIGN KEYS)
PRINT '';
PRINT '=== FOREIGN KEYS EN AspNetUserRoles ===';
SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME IN ('AspNetUserRoles', 'AspNetUserClaims', 'AspNetUserLogins', 'AspNetUserTokens')
AND CONSTRAINT_TYPE = 'FOREIGN KEY'
ORDER BY TABLE_NAME, CONSTRAINT_NAME;

-- 7. ÍNDICES EN AspNetUsers
PRINT '';
PRINT '=== ÍNDICES EN AspNetUsers ===';
SELECT i.name as 'Índice', c.name as 'Columna'
FROM sys.indexes i
INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE OBJECT_NAME(i.object_id) = 'AspNetUsers'
ORDER BY i.name, ic.key_ordinal;

-- 8. VERIFICAR COMPATIBILIDAD: Columns nulables en Personas
PRINT '';
PRINT '=== COLUMNAS NUEVAS (NULLABLE) ===';
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Personas' AND COLUMN_NAME IN ('Email', 'IdentityUserId')
ORDER BY COLUMN_NAME;

PRINT '';
PRINT '✓ VERIFICACIÓN COMPLETADA';
PRINT 'Si ves todas las tablas AspNet* y las columnas Email/IdentityUserId en Personas, ¡todo funcionó correctamente!';
