SELECT
	t.object_id AS [ID],
	s.name AS [Schema],
	t.name AS [Name]
FROM sys.tables AS t
	LEFT JOIN sys.schemas AS s ON t.schema_id = s.schema_id