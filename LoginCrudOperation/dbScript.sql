

CREATE Database LoginDapperDb

USE [LoginDapperDb]
GO

/****** Object:  Table [dbo].[tblLogin]    Script Date: 10-12-2021 01:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_tblLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

GO
select * from tbllogin

GO
CREATE PROCEDURE usp_getLoginUser
As
BEGIN
select * from tbllogin
END

GO
CREATE PROCEDURE usp_InsertLoginUser
@UserName varchar(50),
@Password varchar(50)
AS
BEGIN
INSERT INTO tbllogin 
(UserName,
Password) 
Values(
@userName,
@Password)
END
