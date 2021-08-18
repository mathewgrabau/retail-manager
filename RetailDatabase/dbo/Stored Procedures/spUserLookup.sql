CREATE PROCEDURE [dbo].[spUserLookup]
	@id nvarchar(128)
AS
	SET NOCOUNT ON;

	SELECT [Id], [FirstName], [LastName], [EmailAddress], [CreatedDate] FROM dbo.[User] WHERE @id=[Id];
RETURN 0
