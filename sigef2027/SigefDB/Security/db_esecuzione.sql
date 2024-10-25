CREATE ROLE [db_esecuzione]
    AUTHORIZATION [dbo];


GO
EXECUTE sp_addrolemember @rolename = N'db_esecuzione', @membername = N'UserSigef_web';

