DECLARE @TableName sysname = 'User';

IF (NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = @TableName
)
   )
BEGIN
    PRINT 'Table ' + @TableName + ' Doesn''t exist';
END;
IF (EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = @TableName
)
   )
BEGIN



    DECLARE @Result VARCHAR(MAX) = 'public class ' + @TableName + '
{'  ;

    SELECT @Result = @Result + '
    public '         + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }' + CHAR(13)
    FROM
    (
        SELECT REPLACE(col.name, ' ', '_') ColumnName,
               column_id ColumnId,
               CASE typ.name
                   WHEN 'bigint' THEN
                       'long'
                   WHEN 'binary' THEN
                       'byte[]'
                   WHEN 'bit' THEN
                       'bool'
                   WHEN 'char' THEN
                       'string'
                   WHEN 'date' THEN
                       'DateTime'
                   WHEN 'datetime' THEN
                       'DateTime'
                   WHEN 'datetime2' THEN
                       'DateTime'
                   WHEN 'datetimeoffset' THEN
                       'DateTimeOffset'
                   WHEN 'decimal' THEN
                       'decimal'
                   WHEN 'float' THEN
                       'double'
                   WHEN 'image' THEN
                       'byte[]'
                   WHEN 'int' THEN
                       'int'
                   WHEN 'money' THEN
                       'decimal'
                   WHEN 'nchar' THEN
                       'string'
                   WHEN 'ntext' THEN
                       'string'
                   WHEN 'numeric' THEN
                       'decimal'
                   WHEN 'nvarchar' THEN
                       'string'
                   WHEN 'real' THEN
                       'float'
                   WHEN 'smalldatetime' THEN
                       'DateTime'
                   WHEN 'smallint' THEN
                       'short'
                   WHEN 'smallmoney' THEN
                       'decimal'
                   WHEN 'text' THEN
                       'string'
                   WHEN 'time' THEN
                       'TimeSpan'
                   WHEN 'timestamp' THEN
                       'long'
                   WHEN 'tinyint' THEN
                       'byte'
                   WHEN 'uniqueidentifier' THEN
                       'Guid'
                   WHEN 'varbinary' THEN
                       'byte[]'
                   WHEN 'varchar' THEN
                       'string'
                   --*******************************************************************************************************
                   -- ERP defined datatypes
                   --*******************************************************************************************************

                   WHEN 'mcAcct' THEN
                       'string'
                   WHEN 'mcAccFull' THEN
                       'string'
                   WHEN 'mcAddress' THEN
                       'string'
                   WHEN 'mcCity' THEN
                       'string'
                   WHEN 'mcCode' THEN
                       'string'
                   WHEN 'mcCode3' THEN
                       'string'
                   WHEN 'mcCodeExternal' THEN
                       'string'
                   WHEN 'mcCodeLong' THEN
                       'string'
                   WHEN 'mcCodeShort' THEN
                       'string'
                   WHEN 'mcCount' THEN
                       'int'
                   WHEN 'mcDate' THEN
                       'datetime'
                   WHEN 'mcDesc' THEN
                       'string'
                   WHEN 'mcDescLng' THEN
                       'string'
                   WHEN 'mcEmail' THEN
                       'string'
                   WHEN 'mcFactor' THEN
                       'int'
                   WHEN 'mcFullName' THEN
                       'string'
                   WHEN 'mcGUID' THEN
                       'Guid'
                   WHEN 'mcID' THEN
                       'int'
                   WHEN 'mcJV' THEN
                       'string'
                   WHEN 'mcLineNo' THEN
                       'float'
                   WHEN 'mcLineNo2' THEN
                       'float'
                   WHEN 'mcMoney' THEN
                       'decimal'
                   WHEN 'mcMoney2' THEN
                       'decimal'
                   WHEN 'mcNo' THEN
                       'decimal'
                   WHEN 'mcPart' THEN
                       'string'
                   WHEN 'mcPct' THEN
                       'decimal'
                   WHEN 'mcPeriod' THEN
                       'decimal'
                   WHEN 'mcPhone' THEN
                       'string'
                   WHEN 'mcQuantity' THEN
                       'decimal'
                   WHEN 'mcRSAKey2048' THEN
                       'string'
                   WHEN 'mcSeg' THEN
                       'string'
                   WHEN 'mcSeg2' THEN
                       'string'
                   WHEN 'mcState' THEN
                       'string'
                   WHEN 'mcStatus' THEN
                       'decimal'
                   WHEN 'mcTableID' THEN
                       'string'
                   WHEN 'mcType' THEN
                       'decimal'
                   WHEN 'mcType' THEN
                       'decimal'
                   WHEN 'mcUnitCost' THEN
                       'decimal'
                   WHEN 'mcURL' THEN
                       'string'
                   WHEN 'mcUser' THEN
                       'string'
                   WHEN 'mcYear' THEN
                       'decimal'
                   WHEN 'mcYN' THEN
                       'int'
                   WHEN 'mcZip' THEN
                       'string'
                   WHEN 'mcFullName' THEN
                       'string'
                   ELSE
                       'UNKNOWN_' + typ.name
               END ColumnType,
               CASE
                   WHEN col.is_nullable = 1
                        AND typ.name IN ( 'bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset',
                                          'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime',
                                          'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier'
                                        ) THEN
                       '?'
                   ELSE
                       ''
               END NullableSign
        FROM sys.columns col
            JOIN sys.types typ
                ON col.system_type_id = typ.system_type_id
                   AND col.user_type_id = typ.user_type_id
        WHERE object_id = OBJECT_ID(@TableName)
    ) t
    ORDER BY ColumnId;

    SET @Result = @Result + '}';

    PRINT @Result;
--Do Stuff
END;
