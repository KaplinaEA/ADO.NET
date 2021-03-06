USE [master]
GO
/****** Object:  Database [Journal]    Script Date: 09.12.2020 5:08:43 ******/
CREATE DATABASE [Journal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Journal', FILENAME = N'D:\Program File\MSSQL14.SQLEXPRESS\MSSQL\DATA\Journal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Journal_log', FILENAME = N'D:\Program File\MSSQL14.SQLEXPRESS\MSSQL\DATA\Journal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Journal] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Journal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Journal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Journal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Journal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Journal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Journal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Journal] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Journal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Journal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Journal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Journal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Journal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Journal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Journal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Journal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Journal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Journal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Journal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Journal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Journal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Journal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Journal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Journal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Journal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Journal] SET  MULTI_USER 
GO
ALTER DATABASE [Journal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Journal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Journal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Journal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Journal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Journal] SET QUERY_STORE = OFF
GO
USE [Journal]
GO
/****** Object:  Table [dbo].[Homework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homework](
	[Id] [int] NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[Text] [text] NULL,
 CONSTRAINT [PK_Homework] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Homework_Student]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homework_Student](
	[Homework_Id] [int] NULL,
	[Student_Id] [int] NULL,
	[grade] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] NOT NULL,
	[class] [nchar](10) NULL,
	[User_id] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[experience] [int] NULL,
	[Id] [int] NOT NULL,
	[User_id] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[DateOfBirth] [date] NULL,
	[UserName] [varchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[Id] [int] NOT NULL,
	[UserRole] [int] NOT NULL,
	[UserStatus] [int] NOT NULL,
	[User_password] [varchar](255) NOT NULL,
	[Login] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Homework_Student]  WITH CHECK ADD  CONSTRAINT [FK_Homework_Student_Homework] FOREIGN KEY([Homework_Id])
REFERENCES [dbo].[Homework] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Homework_Student] CHECK CONSTRAINT [FK_Homework_Student_Homework]
GO
ALTER TABLE [dbo].[Homework_Student]  WITH CHECK ADD  CONSTRAINT [FK_Homework_Student_Students] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Homework_Student] CHECK CONSTRAINT [FK_Homework_Student_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Users]
GO
/****** Object:  StoredProcedure [dbo].[Assign_Homework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Assign_Homework]
@S int, @H int, @G int
AS
	DECLARE @count INT;
    SELECT @count = COUNT(*) FROM dbo.Homework_Student where dbo.Homework_Student.Student_Id = @S and dbo.Homework_Student.Homework_Id = @H;
	if(@count>0) Update  [dbo].Homework_Student SET grade = @G where Student_Id = @S and Homework_Id = @H
	else Insert [dbo].Homework_Student(Student_Id, Homework_Id, grade) values(@S, @H, @G);

GO
/****** Object:  StoredProcedure [dbo].[Create_Homework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Create_Homework] 
@Name varchar(255), @Text text  = NULL, @Id int
AS
    INSERT INTO [dbo].Homework(Id, Name, Text)	values( @Id, @Name, @Text);
GO
/****** Object:  StoredProcedure [dbo].[Create_User]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Create_User] 
@Email varchar(100), @UserRole int,@Password varchar(255), @UserName varchar(255), @Id int
AS
    INSERT INTO [dbo].Users(Id, Email, UserRole, User_password, UserStatus, UserName)	values(@Id, @Email, @UserRole, @Password, 1, @UserName);
	DECLARE @User_Id INT;
	select @User_Id = IDENT_CURRENT('Students'); 
	IF (@UserRole = 1) INSERT INTO [dbo].Students (Id, User_id)  values(@Id,@Id) 
	ELSE INSERT INTO [dbo].Teachers(Id, User_id)  values(@Id, @Id) 
GO
/****** Object:  StoredProcedure [dbo].[DeleteHomework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteHomework] 
@ID int
AS
    Delete from dbo.Homework where Id = @ID;
GO
/****** Object:  StoredProcedure [dbo].[GetAllHomework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllHomework]
AS
SELECT * FROM Homework
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllUsers]
AS
SELECT * FROM Users where UserStatus = 1;
GO
/****** Object:  StoredProcedure [dbo].[GetHomework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetHomework]
@ID int
AS
SELECT * FROM Homework where Id = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetJournalByStudent]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetJournalByStudent]
@ID int
AS
SELECT h.Name, h.Text, hs.grade FROM Homework_Student  as hs
INNER JOIN Homework as h on (hs.Homework_Id = h.Id) 
where Student_Id = @ID ;
GO
/****** Object:  StoredProcedure [dbo].[GetStudent]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetStudent]
@ID int
AS
SELECT * FROM Students 
INNER JOIN Users as u on (Students.User_id = u.Id)
where User_id = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetTheacher]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTheacher]
@ID int
AS
SELECT * FROM Teachers 
INNER JOIN Users as u on (Teachers.User_id = u.Id)
where User_id = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
@ID int
AS
SELECT * FROM Users where Id = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByEmail]
@Email varchar(255)
AS
	Select TOP 1 * From Users where Email = @Email  
GO
/****** Object:  StoredProcedure [dbo].[Give_Grade]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Give_Grade]
@S int , @H int, @g int
AS
    UPDATE [dbo].Homework_Student SET grade = @g Where Student_Id = @S and Homework_Id = @H;
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
@bool bit, @Id int
AS
	UPDATE [dbo].Users SET Login = @bool Where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[Logout]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Logout]
@bool bit, @Id int
AS
	UPDATE [dbo].Users SET Login = @bool Where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[Update_Homework]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Homework] 
@Id int , @Name varchar(255), @Text text  = NULL
AS
    UPDATE [dbo].Homework SET Name = @Name, Text=@Text Where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[Update_Student_Profile]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_Student_Profile]
@ID int,  @birsday date , @class varchar(10)
AS
    UPDATE [dbo].Users SET DateOfBirth=@birsday Where Id = @ID;
	UPDate [dbo].Students SET class = @class Where User_id = @ID;
GO
/****** Object:  StoredProcedure [dbo].[Update_Teacher_Profile]    Script Date: 09.12.2020 5:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Update_Teacher_Profile] 
@ID int, @birsday date , @experience int
AS
    UPDATE [dbo].Users SET DateOfBirth=@birsday Where Id = @ID;
	UPDate [dbo].Teachers SET experience = @experience Where User_id = @ID;
GO
USE [master]
GO
ALTER DATABASE [Journal] SET  READ_WRITE 
GO
