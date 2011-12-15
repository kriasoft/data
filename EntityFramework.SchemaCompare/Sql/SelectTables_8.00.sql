SELECT
	Id AS [ID],
	NULL AS [Schema],
	name AS [Name]
FROM sysobjects SO WHERE type = 'U';
