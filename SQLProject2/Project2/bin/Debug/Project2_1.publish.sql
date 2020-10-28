﻿/*
Deployment script for JCDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "JCDB"
:setvar DefaultFilePrefix "JCDB"
:setvar DefaultDataPath "C:\Users\JC\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\JC\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Pollution]...';


GO
CREATE VIEW [dbo].[Pollution]
	AS 
	SELECT [l].[Id] As LocationId, [l].[City], [l].[State], 
	[p].[Id] AS PopulationId, [p].[Size]
	from dbo.Location l
	left join dbo.Population p on l.Id = p.LocationId
GO
PRINT N'Creating [dbo].[Location_FilterByState]...';


GO
CREATE PROCEDURE [dbo].[Location_FilterByState]
	@State nvarchar(50)
AS
begin
	SELECT [Id], [City], [State]
	from dbo.Location
	WHERE State = @State;
end
GO
PRINT N'Update complete.';


GO
