
-- =============================================
-- Author:		Mike Malinowski
-- Create date: 02/12/2020
-- Description:	Used for getting a User for the API Template
-- =============================================
CREATE PROCEDURE mcsp_APIUser_Get 
	-- Add the parameters for the stored procedure here
	@userID varchar(25) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID,
           UserID,
           UserName,
           Role,
           DataProfile,
           ActiveYN,
           LockOutCounter,
           LockOutDate,
           LastAccessDate,
           PasswordDate,
           ExpirationDate,
           IPRestrictionYN,
           HideFinancialDataYN,
           HideMedicalDataYN,
           CreateDate,
           CreateUser,
           LastUsedDate,
           LastUsedUser,
           EmailAddress,
           ReportSecurityProfile,
           UserSecurityLevel,
           UserNoteCount,
           PrinterID,
           PasswordHistoryBlob,
           IgnoreLockoutPeriodYN,
           PremierUserID,
           GaugeProfile,
           ExternalUserYN,
           ReleasedStatus,
           ReleasedDate,
           ActivationDate,
           ReleasedMsg,
           CIAMUpdateStatus,
           CIAMUpdateDate,
           CIAMMessage
	FROM dbo.users WITH(NOLOCK)
	WHERE userid = @userID
END
GO
