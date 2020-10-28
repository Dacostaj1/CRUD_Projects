CREATE PROCEDURE [dbo].[Location_FilterByState]
	@State nvarchar(50)
AS
begin
	SELECT [Id], [City], [State]
	from dbo.Location
	WHERE State = @State;
end
