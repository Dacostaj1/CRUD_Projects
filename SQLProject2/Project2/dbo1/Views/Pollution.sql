CREATE VIEW [dbo].[Pollution]
	AS 
	SELECT [l].[Id] As LocationId, [l].[City], [l].[State], 
	[p].[Id] AS PopulationId, [p].[Size]
	from dbo.Location l
	left join dbo.Population p on l.Id = p.LocationId

