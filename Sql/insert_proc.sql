--USE [TCPtest]
--GO

/****** Object:  StoredProcedure [dbo].[VehicleInsert]    Script Date: 3/21/2021 1:40:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VehicleInsert]
	-- Add the parameters for the stored procedure here
	@make varchar(50),
	@model varchar(50),
	@year int,
	@color varchar(50),
	@licenseplate varchar(50),
	@id int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.Vehicles
	(
		make
		,model
		,year
		,color
		,licenseplate
	)
	Values
	(
		@make
		,@model
		,@year
		,@color
		,@licenseplate
	)

	Set @id = SCOPE_IDENTITY()
	Return @id

END
GO

