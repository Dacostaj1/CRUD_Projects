CREATE PROCEDURE [dbo].[spPerson_FilteredByLastName]
	@LastName nvarchar(50)
AS
begin
	SELECT [Id], [FirstName], [LastName]
	from dbo.Person
	where LastName = @LastName;
end
