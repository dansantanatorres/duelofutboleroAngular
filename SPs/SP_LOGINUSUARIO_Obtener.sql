USE [SGSIG]
GO
/****** Object:  StoredProcedure [dbo].[SP_LOGINUSAURIO_Obtener]    Script Date: 13-06-2024 18:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joan Mortheiru
-- Create date: 20240613
-- Description:	Procedimiento que obtiene los datos del usuario de Login.
-- =============================================
ALTER PROCEDURE [dbo].[SP_LOGINUSAURIO_Obtener]
	@USUARIO	VARCHAR(20)	= NULL,
	@CLAVE   	VARCHAR(50)	= NULL
AS
BEGIN
	SET NOCOUNT ON;	

	IF @USUARIO IS NOT NULL AND @USUARIO <> SPACE(0) AND @CLAVE IS NOT NULL AND @CLAVE <> SPACE(0)
	BEGIN
		SELECT USUARIO,NOMBRE1,NOMBRE2,APELLIDO1,APELLIDO2,RUT,EMAIL,SEXO,IDPERFIL,EMPRESA 
			FROM [SGSIG].[dbo].[AUTH_CUENTAS_USUARIOS] 
			WHERE USUARIO = @USUARIO AND CLAVE = @CLAVE AND IDESTADO = 1
	END
END


