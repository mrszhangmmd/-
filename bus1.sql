USE [master]
GO
/****** Object:  Database [Bus]    Script Date: 2017/11/11 19:14:12 ******/
CREATE DATABASE [Bus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSEVER1\MSSQL\DATA\Bus.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSEVER1\MSSQL\DATA\Bus_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bus] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bus] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bus] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bus] SET RECOVERY FULL 
GO
ALTER DATABASE [Bus] SET  MULTI_USER 
GO
ALTER DATABASE [Bus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bus] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bus', N'ON'
GO
USE [Bus]
GO
/****** Object:  Table [dbo].[tbl_bus_station]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_bus_station](
	[id_tbl_bus_station] [int] NOT NULL,
	[col_name] [varchar](45) NOT NULL,
	[col_bs_state] [varchar](45) NOT NULL,
	[col_city] [varchar](45) NOT NULL,
 CONSTRAINT [PK_TBL_BUS_STATION] PRIMARY KEY CLUSTERED 
(
	[id_tbl_bus_station] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_captcha]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_captcha](
	[id_tbl_captcha] [int] NOT NULL,
	[col_userid] [int] NOT NULL,
	[col_token] [varchar](100) NOT NULL,
	[col_actved] [bit] NOT NULL,
	[col_expired] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_captcha] PRIMARY KEY CLUSTERED 
(
	[id_tbl_captcha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_coach]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_coach](
	[id_tbl_coach] [int] NOT NULL,
	[col_coach_type] [varchar](45) NOT NULL,
	[col_coach_count] [int] NOT NULL,
 CONSTRAINT [PK_TBL_COACH] PRIMARY KEY CLUSTERED 
(
	[id_tbl_coach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_line]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_line](
	[id_tbl_line] [int] IDENTITY(1,1) NOT NULL,
	[col_line_time] [varchar](45) NOT NULL,
	[col_line_price] [varchar](45) NOT NULL,
	[col_definitionid] [int] NOT NULL,
	[col_startid] [int] NOT NULL,
 CONSTRAINT [PK_TBL_LINE] PRIMARY KEY CLUSTERED 
(
	[id_tbl_line] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_order](
	[id_tbl_order] [int] IDENTITY(1,1) NOT NULL,
	[id_tbl_passenger] [int] NULL,
	[id_tbl_schedule] [int] NOT NULL,
	[col_take_order_no] [varchar](45) NOT NULL,
	[col_password] [varchar](45) NOT NULL,
	[col_start_time] [varchar](45) NOT NULL,
	[col_order_state] [varchar](45) NOT NULL,
	[col_passenger_tel] [varchar](45) NOT NULL,
	[col_passenger_num] [varchar](45) NOT NULL,
	[id_tbl_passenger2] [int] NULL,
	[id_tbl_passenger3] [int] NULL,
	[col_insurence_state] [int] NULL,
	[col_price] [float] NULL,
 CONSTRAINT [PK_TBL_ORDER] PRIMARY KEY CLUSTERED 
(
	[id_tbl_order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_passenger]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_passenger](
	[id_tbl_passenger] [int] IDENTITY(1,1) NOT NULL,
	[col_name] [varchar](50) NOT NULL,
	[col_passenger_state] [int] NOT NULL,
	[col_ischecked] [int] NOT NULL,
	[id_tbl_user] [int] NOT NULL,
	[col_indentity_no] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_passenger] PRIMARY KEY CLUSTERED 
(
	[id_tbl_passenger] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_schedule]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_schedule](
	[id_tbl_line] [int] NOT NULL,
	[id_tbl_coach] [int] NOT NULL,
	[id_tbl_schedule] [int] IDENTITY(1,1) NOT NULL,
	[col_start_date] [varchar](45) NOT NULL,
	[col_remainticket] [int] NOT NULL,
	[col_entrance] [int] NULL,
 CONSTRAINT [PK_TBL_SCHEDULE] PRIMARY KEY CLUSTERED 
(
	[id_tbl_schedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Ticket]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Ticket](
	[col_ticket_time] [varchar](45) NOT NULL,
	[id_tbl_ticket] [int] IDENTITY(1,1) NOT NULL,
	[id_tbl_order] [int] NOT NULL,
	[col_ticket_entrance] [varchar](45) NULL,
	[col_ticket_State] [int] NULL,
	[col_seatno] [int] NULL,
	[id_tbl_passenger] [int] NULL,
 CONSTRAINT [PK_TBL_TICKET] PRIMARY KEY CLUSTERED 
(
	[id_tbl_ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id_tbl_user] [int] IDENTITY(1,1) NOT NULL,
	[col_user_password] [varchar](45) NOT NULL,
	[col_user_tel] [varchar](45) NOT NULL,
	[col_user_email] [varchar](45) NOT NULL,
	[col_user_state] [int] NOT NULL,
	[col_nickname] [varchar](45) NOT NULL,
 CONSTRAINT [PK_TBL_USER] PRIMARY KEY CLUSTERED 
(
	[id_tbl_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[view_line]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_line]
AS
SELECT  dbo.tbl_line.col_line_time AS starttime, dbo.tbl_bus_station.col_city AS backcity, tbl_bus_station_1.col_city AS startcity, 
                   dbo.tbl_line.col_line_price AS price, dbo.tbl_coach.col_coach_type AS type, dbo.tbl_schedule.col_remainticket AS tnum, 
                   dbo.tbl_coach.col_coach_count AS count, dbo.tbl_bus_station.col_name AS definitionbusstation, 
                   tbl_bus_station_1.col_name AS startbusstation, dbo.tbl_bus_station.id_tbl_bus_station, dbo.tbl_schedule.id_tbl_schedule, 
                   dbo.tbl_coach.id_tbl_coach, tbl_bus_station_1.id_tbl_bus_station AS Expr1, dbo.tbl_line.id_tbl_line, 
                   dbo.tbl_schedule.col_start_date, dbo.tbl_schedule.col_entrance
FROM      dbo.tbl_bus_station INNER JOIN
                   dbo.tbl_line ON dbo.tbl_bus_station.id_tbl_bus_station = dbo.tbl_line.col_definitionid INNER JOIN
                   dbo.tbl_schedule ON dbo.tbl_line.id_tbl_line = dbo.tbl_schedule.id_tbl_line INNER JOIN
                   dbo.tbl_bus_station AS tbl_bus_station_1 ON dbo.tbl_line.col_startid = tbl_bus_station_1.id_tbl_bus_station INNER JOIN
                   dbo.tbl_coach ON dbo.tbl_schedule.id_tbl_coach = dbo.tbl_coach.id_tbl_coach

GO
/****** Object:  View [dbo].[view_order]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_order]
AS
SELECT  dbo.tbl_order.id_tbl_order, dbo.tbl_passenger.id_tbl_passenger, dbo.tbl_order.col_take_order_no, 
                   dbo.tbl_order.col_password, dbo.tbl_order.col_start_time, dbo.tbl_order.col_passenger_tel, 
                   dbo.tbl_order.col_passenger_num, dbo.tbl_order.col_order_state, dbo.tbl_order.col_insurence_state, 
                   dbo.tbl_order.col_price, dbo.view_line.col_start_date, dbo.view_line.definitionbusstation, dbo.view_line.startbusstation, 
                   dbo.view_line.startcity, dbo.view_line.backcity, dbo.view_line.starttime, dbo.tbl_passenger.id_tbl_user, 
                   dbo.tbl_passenger.col_passenger_state, dbo.tbl_passenger.col_indentity_no, dbo.view_line.tnum, 
                   dbo.view_line.id_tbl_line, dbo.view_line.col_entrance
FROM      dbo.tbl_order INNER JOIN
                   dbo.tbl_passenger ON dbo.tbl_order.id_tbl_passenger = dbo.tbl_passenger.id_tbl_passenger INNER JOIN
                   dbo.view_line ON dbo.tbl_order.id_tbl_schedule = dbo.view_line.id_tbl_schedule

GO
/****** Object:  View [dbo].[view_ticket]    Script Date: 2017/11/11 19:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_ticket]
AS
SELECT  dbo.tbl_Ticket.col_seatno, dbo.tbl_Ticket.col_ticket_State, dbo.tbl_Ticket.col_ticket_entrance, dbo.tbl_Ticket.id_tbl_ticket, 
                   dbo.tbl_Ticket.id_tbl_passenger, dbo.view_order.id_tbl_user, dbo.view_order.starttime, dbo.view_order.backcity, 
                   dbo.view_order.startcity, dbo.view_order.startbusstation, dbo.view_order.definitionbusstation, 
                   dbo.view_order.col_start_date, dbo.view_order.col_price, dbo.view_order.col_insurence_state, 
                   dbo.view_order.col_order_state, dbo.view_order.col_passenger_num, dbo.view_order.col_passenger_tel, 
                   dbo.view_order.col_start_time, dbo.view_order.col_password, dbo.view_order.col_take_order_no, 
                   dbo.view_order.col_passenger_state, dbo.view_order.col_indentity_no, dbo.view_order.tnum, 
                   dbo.tbl_passenger.col_name, dbo.tbl_Ticket.id_tbl_order, dbo.view_order.id_tbl_line, dbo.view_order.col_entrance
FROM      dbo.tbl_Ticket INNER JOIN
                   dbo.view_order ON dbo.tbl_Ticket.id_tbl_order = dbo.view_order.id_tbl_order INNER JOIN
                   dbo.tbl_passenger ON dbo.tbl_Ticket.id_tbl_passenger = dbo.tbl_passenger.id_tbl_passenger

GO
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (1, N'无锡客运站', N'1', N'无锡')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (2, N'硕放机场站', N'1', N'无锡')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (3, N'苏州西站', N'1', N'苏州')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (4, N'苏州北站', N'1', N'苏州')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (5, N'苏州吴中站', N'1', N'苏州')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (6, N'盐都客运站', N'1', N'盐城')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (7, N'建湖汽车站', N'1', N'建湖')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (8, N'客运南站', N'1', N'上海')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (9, N'客运西站', N'1', N'上海')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (10, N'南京东站', N'1', N'南京')
INSERT [dbo].[tbl_bus_station] ([id_tbl_bus_station], [col_name], [col_bs_state], [col_city]) VALUES (11, N'南京南站', N'1', N'南京')
INSERT [dbo].[tbl_coach] ([id_tbl_coach], [col_coach_type], [col_coach_count]) VALUES (1, N'小型商务', 15)
INSERT [dbo].[tbl_coach] ([id_tbl_coach], [col_coach_type], [col_coach_count]) VALUES (2, N'大型高一', 55)
INSERT [dbo].[tbl_coach] ([id_tbl_coach], [col_coach_type], [col_coach_count]) VALUES (3, N'中型巴士', 30)
SET IDENTITY_INSERT [dbo].[tbl_line] ON 

INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1, N'08:00:00', N'50    ', 1, 3)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (5, N'14:00:00', N'50', 1, 3)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (6, N'08:00:00', N'50', 3, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (7, N'14:00:00', N'50', 3, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (8, N'08:00:00', N'60', 1, 4)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (9, N'08:00:00', N'70', 4, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (10, N'08:00:00', N'65 ', 1, 5)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (11, N'08:00:00', N'65', 5, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (12, N'08:00:00', N'70', 1, 6)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (13, N'08:00:00', N'70', 6, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (14, N'08:00:00', N'75', 1, 7)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (15, N'08:00:00', N'75', 7, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (16, N'08:00:00', N'80', 1, 8)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (17, N'08:00:00', N'80', 8, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (18, N'08:00:00', N'85', 1, 9)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (19, N'08:00:00', N'85', 9, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (20, N'08:00:00', N'90', 1, 10)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (21, N'08:00:00', N'90', 10, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (22, N'14:00:00', N'90', 1, 10)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (23, N'08:00:00', N'95', 1, 11)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (25, N'08:00:00', N'95', 11, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (26, N'14:00:00', N'90', 10, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (27, N'14:00:00', N'60', 1, 4)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (28, N'14:00:00', N'60', 4, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (29, N'14:00:00', N'65', 1, 5)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (30, N'14:00:00', N'65', 5, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (31, N'14:00:00', N'70', 1, 6)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (32, N'14:00:00', N'70', 6, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (33, N'14:00:00', N'75', 1, 7)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (34, N'14:00:00', N'75', 7, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (35, N'14:00:00', N'80', 1, 8)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (36, N'14:00:00', N'80', 8, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (37, N'14:00:00', N'85', 1, 9)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (38, N'14:00:00', N'85', 9, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (39, N'14:00:00', N'95', 1, 11)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (40, N'14:00:00', N'95', 11, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1002, N'08:00:00', N'50', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1003, N'08:00:00', N'50', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1004, N'08:00:00', N'20', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1005, N'05:00:00', N'20', 4, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1006, N'05:00:00', N'20', 3, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1007, N'05:00:00', N'30', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1008, N'05:00:00', N'100', 3, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1009, N'05:00:00', N'100', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1010, N'00:00:00', N'30', 4, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1011, N'02:00:00', N'150', 7, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1012, N'02:00:00', N'35', 1, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (1013, N'01:00:00', N'35', 4, 1)
INSERT [dbo].[tbl_line] ([id_tbl_line], [col_line_time], [col_line_price], [col_definitionid], [col_startid]) VALUES (2002, N'08:00:00', N'30', 1, 3)
SET IDENTITY_INSERT [dbo].[tbl_line] OFF
SET IDENTITY_INSERT [dbo].[tbl_order] ON 

INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (32, 2, 14, N'等待出票', N'等待出票', N'2017/11/6 16:00:57', N'已支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (33, 2, 38, N'等待出票', N'等待出票', N'2017/11/6 16:32:51', N'未支付', N'18816209068', N'张健', NULL, NULL, 0, 63)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (34, 2, 14, N'等待出票', N'等待出票', N'2017/11/6 16:34:31', N'未支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (35, 2, 14, N'等待出票', N'等待出票', N'2017/11/6 16:52:30', N'已支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (36, 2, 38, N'等待出票', N'等待出票', N'2017/11/6 16:54:24', N'已支付', N'18816209068', N'张健', NULL, NULL, 0, 63)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (37, 2, 38, N'等待出票', N'等待出票', N'2017/11/6 16:56:07', N'取消支付', N'18816209068', N'张健', NULL, NULL, 1, 66)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (38, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 0:10:54', N'已支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (39, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 0:29:48', N'未支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (40, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 0:34:28', N'已出票', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1032, 2, 14, N'1', N'2', N'2017/11/7 2:08:56', N'未支付', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1033, 2, 12, N'等待出票', N'等待出票', N'2017/11/7 2:10:57', N'未支付', N'', N'', NULL, NULL, 1, 66)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1034, 2, 12, N'等待出票', N'等待出票', N'2017/11/7 2:11:57', N'未支付', N'', N'', NULL, NULL, 0, 63)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1035, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 2:12:44', N'未支付', N'', N'', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1036, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 2:15:49', N'未支付', N'', N'', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1037, 2, 12, N'等待出票', N'等待出票', N'2017/11/7 4:03:26', N'已支付', N'aaa', N'aa', NULL, NULL, 0, 159)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1038, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 4:06:58', N'已出票', N'xxx', N'xxx', NULL, NULL, 2, 201.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1039, 2, 1004, N'等待出票', N'等待出票', N'2017/11/7 4:08:57', N'已支付', N'uu', N'yy', NULL, NULL, 0, 384)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1040, 5, 14, N'等待出票', N'等待出票', N'2017/11/7 4:12:58', N'已支付', N'mm', N'mm', NULL, NULL, 0, 171.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1041, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 4:15:14', N'已支付', N'ii', N'mm', NULL, NULL, 0, 171.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1042, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 4:18:22', N'已支付', N'', N'', NULL, NULL, 0, 171.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1043, 2, 38, N'等待出票', N'等待出票', N'2017/11/7 4:23:50', N'已支付', N'', N'', NULL, NULL, 0, 189)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1044, 6, 38, N'等待出票', N'等待出票', N'2017/11/7 4:26:08', N'未支付', N'', N'', NULL, NULL, 0, 126)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1045, 2, 38, N'等待出票', N'等待出票', N'2017/11/7 4:31:46', N'已支付', N'aa', N'xx', NULL, NULL, 0, 189)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1046, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 4:37:46', N'已出票', N'eqwe', N'weqw', 3, 6, 0, 171.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1048, 3, 38, N'等待出票', N'等待出票', N'2017/11/7 5:34:29', N'未支付', N'aaa', N'bbb', 5, NULL, 0, 96)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1051, 3, 38, N'等待出票', N'等待出票', N'2017/11/7 5:38:32', N'未支付', N'', N'', 5, NULL, 0, 96)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1052, 2, 38, N'等待出票', N'等待出票', N'2017/11/7 5:39:05', N'未支付', N'', N'', 5, 6, 0, 189)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1053, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 5:41:12', N'已出票', N'mmm', N'mmm', 5, 6, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1054, 2, 40, N'等待出票', N'等待出票', N'2017/11/7 5:49:47', N'未支付', N'', N'', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1055, 2, 40, N'等待出票', N'等待出票', N'2017/11/7 5:50:45', N'已支付', N'', N'', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1056, 3, 40, N'等待出票', N'等待出票', N'2017/11/7 5:54:32', N'已支付', N'', N'', NULL, NULL, 0, 35.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1057, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 5:59:32', N'已支付', N'', N'', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1058, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 5:59:47', N'已支付', N'', N'', 6, NULL, 0, 136)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1059, 2, 14, N'37144841', N'10157621', N'2017/11/7 6:00:42', N'已出票', N'', N'', 3, 6, 0, 171.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1060, 2, 14, N'等待出票', N'等待出票', N'2017/11/7 6:05:46', N'已出票', N'das', N'sacsa', 5, 6, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1061, 2, 38, N'等待出票', N'等待出票', N'2017/11/7 14:31:44', N'已支付', N'', N'', 3, 6, 0, 159)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1062, 2012, 38, N'等待出票', N'等待出票', N'2017/11/7 15:10:51', N'已支付', N'16985212658', N'张小明', 2013, NULL, 0, 126)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1063, 2012, 14, N'等待出票', N'等待出票', N'2017/11/7 15:38:59', N'已出票', N'18816208368', N'张婷婷', 2013, 2014, 2, 234)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (1064, 2013, 14, N'等待出票', N'等待出票', N'2017/11/7 15:41:38', N'取消支付', N'18816209068', N'张健', 2014, NULL, 0, 136)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2063, 2012, 1004, N'60175365', N'57343266', N'2017/11/7 16:59:22', N'已出票', N'18816209068', N'张健', 2013, 2014, 2, 489)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2064, 2013, 51, N'等待出票', N'等待出票', N'2017/11/7 17:01:56', N'已出票', N'18816209099', N'哎哎哎', 2014, 3014, 2, 294)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2065, 2014, 51, N'等待出票', N'等待出票', N'2017/11/7 17:36:08', N'已出票', N'xxxxxxxxxxxxx', N'xxxxxxxxxxx', NULL, NULL, 2, 98)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2066, 2013, 14, N'等待出票', N'等待出票', N'2017/11/7 18:15:16', N'已出票', N'18816209639', N'张健健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2067, 3015, 10, N'等待出票', N'等待出票', N'2017/11/7 18:28:23', N'已出票', N'18816208368', N'季冬', NULL, NULL, 2, 63)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2068, 2013, 14, N'等待出票', N'等待出票', N'2017/11/7 21:51:38', N'已出票', N'18816209068', N'zhangjian', 3014, 3015, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2069, 2013, 51, N'等待出票', N'等待出票', N'2017/11/7 21:55:02', N'已出票', N'13770215917', N'张健', 2014, 3014, 0, 264)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2070, 2013, 45, N'等待出票', N'等待出票', N'2017/11/7 21:59:01', N'已退票', N'18816208368', N'张佳佳', 2014, 3015, 2, 264)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2071, 3015, 1004, N'等待出票', N'等待出票', N'2017/11/7 22:24:56', N'已退票', N'18816209068', N'张健', 3016, 3017, 0, 459)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2072, 3015, 51, N'95279379', N'50989913', N'2017/11/8 9:11:36', N'已退票', N'18816209068', N'张健', 3016, 3017, 0, 264)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2073, 3018, 1004, N'等待出票', N'等待出票', N'2017/11/8 9:14:04', N'已出票', N'18816209068', N'张健', NULL, NULL, 2, 163)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2074, 2013, 10, N'等待出票', N'等待出票', N'2017/11/8 9:22:02', N'已出票', N'18816209068', N'张健', 3015, 3017, 0, 159)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2075, 2014, 14, N'等待出票', N'等待出票', N'2017/11/8 9:26:32', N'已出票', N'19916208368', N'季冬', 3015, 3016, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2076, 2013, 14, N'等待出票', N'等待出票', N'2017/11/8 9:31:37', N'已出票', N'bbb', N'aaa', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2077, 3017, 14, N'39904706', N'42978847', N'2017/11/8 9:35:33', N'已退票', N'10016206326', N'大表哥', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2078, 2014, 14, N'62771837', N'51629787', N'2017/11/8 9:43:15', N'已退票', N'18816209068', N'zhangjian', 3015, 3016, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2079, 3015, 14, N'93197850', N'80589937', N'2017/11/8 9:44:09', N'已出票', N'xxxxxx', N'xxxxx', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2080, 3015, 14, N'58941494', N'56090314', N'2017/11/8 9:46:41', N'已退票', N'18816209068', N'张佳佳', 3016, 3017, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2081, 3015, 14, N'等待出票', N'等待出票', N'2017/11/8 9:54:22', N'取消订单', N'18816208368', N'季冬', 3017, NULL, 2, 156)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2082, 3015, 14, N'等待出票', N'等待出票', N'2017/11/8 9:57:29', N'未支付', N'18816209068', N'张健', 3019, NULL, 2, 123.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2083, 3015, 14, N'等待出票', N'等待出票', N'2017/11/8 9:58:22', N'取消订单', N'18816209068', N'张健', 3016, NULL, 2, 156)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2084, 3016, 14, N'22180712', N'31801993', N'2017/11/8 10:02:46', N'已出票', N'18816209068', N'张健', NULL, NULL, 1, 71)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2085, 3014, 14, N'43097043', N'14995165', N'2017/11/8 10:05:33', N'已退票', N'18816208368', N'张佳佳2', 3015, 3017, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2086, 3015, 14, N'28520850', N'27276046', N'2017/11/8 10:06:19', N'已出票', N'18816209068', N'zzd', 3016, 3017, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2087, 3020, 14, N'38264608', N'60755395', N'2017/11/8 10:09:01', N'已退票', N'18816208368', N'张健', NULL, NULL, 1, 71)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2088, 3021, 14, N'等待出票', N'等待出票', N'2017/11/8 10:35:22', N'取消订单', N'18816209068', N'张健', 3022, NULL, 1, 109.5)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2089, 3021, 9, N'等待出票', N'等待出票', N'2017/11/8 10:36:46', N'已支付', N'18816209068', N'张健', 3022, NULL, 0, 81)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2090, 2012, 20, N'55089807', N'72527800', N'2017/11/8 10:38:42', N'已退票', N'18816208368', N'张佳佳', 2014, 3015, 0, 234)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2091, 2013, 38, N'等待出票', N'等待出票', N'2017/11/10 21:08:29', N'已退票', N'18816209068', N'张佳佳', 3023, NULL, 1, 132)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2092, 2013, 14, N'等待出票', N'等待出票', N'2017/11/10 21:34:14', N'取消订单', N'18816209068', N'张婷婷', 2014, 3014, 0, 204)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2093, 2012, 14, N'13110250', N'78207990', N'2017/11/10 22:07:17', N'已出票', N'18816208368', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2094, 3015, 14, N'80348163', N'74120635', N'2017/11/10 22:08:48', N'已出票', N'18816209068', N'张健', NULL, NULL, 0, 68)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2095, 3015, 29, N'等待出票', N'等待出票', N'2017/11/10 22:20:09', N'未支付', N'18816209068', N'张健', 3016, 3017, 2, 309)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2096, 3015, 29, N'14080178', N'28941968', N'2017/11/10 22:21:14', N'已出票', N'18816209068', N'张健', 3016, 3017, 2, 309)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2097, 3015, 35, N'47602256', N'38166873', N'2017/11/10 22:25:55', N'已退票', N'aaa', N'aa', 3016, 3017, 0, 294)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2098, 3024, 29, N'33520279', N'67335413', N'2017/11/10 22:34:36', N'已出票', N'18816209068', N'张健', 3025, 3026, 2, 309)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2099, 3015, 10, N'45164941', N'56512758', N'2017/11/11 0:24:50', N'已出票', N'18816208368', N'季冬', 3017, NULL, 2, 126)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2100, 3015, 38, N'28988024', N'98250199', N'2017/11/11 0:28:18', N'已出票', N'18816208368', N'季冬', 3016, NULL, 0, 126)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2101, 3015, 38, N'18854539', N'64040845', N'2017/11/11 0:29:16', N'已出票', N'18816208368', N'张健', 3016, NULL, 0, 126)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2102, 3014, 12, N'等待出票', N'等待出票', N'2017/11/11 1:01:00', N'已支付', N'18816209068', N'季冬', 3015, 3019, 2, 189)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2103, 3016, 29, N'94004887', N'78415388', N'2017/11/11 12:01:34', N'已出票', N'18816208368', N'张健', NULL, NULL, 0, 93)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2104, 3015, 29, N'18687175', N'85785511', N'2017/11/11 12:02:27', N'已出票', N'18816208368', N'季冬', NULL, NULL, 0, 93)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2105, 3015, 12, N'等待出票', N'等待出票', N'2017/11/11 12:21:17', N'已支付', N'18816208368', N'季冬', 3016, 3017, 0, 189)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2106, 2014, 1004, N'74400270', N'55892214', N'2017/11/11 12:35:04', N'已出票', N'18816209068', N'张健', 3015, 3017, 2, 489)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2107, 3016, 38, N'42778408', N'90768931', N'2017/11/11 12:36:09', N'已出票', N'', N'', NULL, NULL, 0, 63)
INSERT [dbo].[tbl_order] ([id_tbl_order], [id_tbl_passenger], [id_tbl_schedule], [col_take_order_no], [col_password], [col_start_time], [col_order_state], [col_passenger_tel], [col_passenger_num], [id_tbl_passenger2], [id_tbl_passenger3], [col_insurence_state], [col_price]) VALUES (2108, 2012, 45, N'66718364', N'90836761', N'2017/11/11 12:37:16', N'已出票', N'18816209068', N'张健', 3014, NULL, 2, 176)
SET IDENTITY_INSERT [dbo].[tbl_order] OFF
SET IDENTITY_INSERT [dbo].[tbl_passenger] ON 

INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (1, N'张健', 1, 0, 1, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (2, N'张佳佳', 1, 0, 1009, N'320925199708131458')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3, N'乔布斯', 0, 0, 1009, N'32092519970813145x')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (5, N'比尔盖茨', 1, 0, 1009, N'320925199708131459')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (6, N'小狐狸', 1, 0, 1009, N'320925199708131456')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (7, N'虎丘', 1, 0, 1009, N'320925199708131451')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (8, N'30', 1, 0, 1009, N'30')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (9, N'小明', 0, 0, 1009, N'320925199908131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (1008, N'22', 1, 0, 1009, N'22')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (1009, N'张立生', 1, 0, 1009, N'327926198706251254')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (1010, N'a', 0, 0, 1009, N'a')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (1011, N'季冬', 0, 0, 1009, N'320925198929291569')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (2012, N'aaa', 1, 0, 5007, N'bbb')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (2013, N'张晓明', 1, 0, 5007, N'369852147123654789')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (2014, N'张婷婷', 1, 0, 5007, N'365421789365412987')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3014, N'机等等', 1, 0, 5007, N'123654789654789369')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3015, N'季冬', 1, 0, 5007, N'369852147123654789')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3016, N'张健', 1, 0, 5007, N'3213213213213221321')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3017, N'大表哥', 1, 0, 5007, N'3333333333333333333333')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3018, N'张健', 1, 0, 5009, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3019, N'张健', 0, 0, 5007, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3020, N'季冬', 1, 0, 5010, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3021, N'张健', 1, 0, 5011, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3022, N'季冬', 0, 0, 5011, N'320925198929291569')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3023, N'张健', 1, 0, 5007, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3024, N'张健', 1, 0, 5012, N'320925199708131455')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3025, N'季冬', 1, 0, 5012, N'369852147123654789')
INSERT [dbo].[tbl_passenger] ([id_tbl_passenger], [col_name], [col_passenger_state], [col_ischecked], [id_tbl_user], [col_indentity_no]) VALUES (3026, N'张健jian', 1, 0, 5012, N'320925198929291569')
SET IDENTITY_INSERT [dbo].[tbl_passenger] OFF
SET IDENTITY_INSERT [dbo].[tbl_schedule] ON 

INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1, 1, 1, N'2017-12-08', 15, 3)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (5, 1, 8, N'2017-12-08', 15, 2)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (6, 1, 9, N'2017-12-08', 14, 1)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (7, 1, 10, N'2017-12-08', 10, 9)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (8, 3, 11, N'2017-12-08', 30, 8)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (9, 3, 12, N'2017-12-08', 30, 7)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (10, 3, 13, N'2017-12-08', 30, 7)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (11, 3, 14, N'2017-12-08', 0, 6)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (12, 2, 15, N'2017-12-08', 55, 5)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (13, 2, 16, N'2017-12-08', 55, 4)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (14, 2, 17, N'2017-12-08', 55, 3)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (15, 2, 20, N'2017-12-08', 55, 2)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (16, 1, 21, N'2017-12-08', 15, 1)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (17, 1, 23, N'2017-12-08', 15, 29)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (18, 1, 24, N'2017-12-08', 15, 28)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (19, 1, 26, N'2017-12-08', 15, 27)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (20, 2, 27, N'2017-12-08', 55, 26)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (21, 2, 29, N'2017-12-08', 50, 25)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (22, 2, 30, N'2017-12-08', 55, 24)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (23, 2, 31, N'2017-12-08', 55, 23)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (25, 3, 35, N'2017-12-08', 30, 22)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (26, 3, 36, N'2017-12-08', 30, 21)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (27, 3, 37, N'2017-12-08', 30, 20)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (28, 3, 38, N'2017-12-08', 25, 19)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (29, 3, 39, N'2017-12-08', 30, 18)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (30, 3, 40, N'2017-12-08', 30, 17)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (31, 3, 41, N'2017-12-08', 30, 16)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (32, 3, 42, N'2017-12-08', 30, 15)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (36, 3, 43, N'2017-12-08', 30, 14)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (33, 3, 44, N'2017-12-08', 30, 13)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (34, 3, 45, N'2017-12-08', 28, 12)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (35, 3, 47, N'2017-12-08', 30, 11)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (37, 3, 50, N'2017-12-08', 30, 10)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (38, 3, 51, N'2017-12-08', 30, 9)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (39, 3, 52, N'2017-12-08', 30, 8)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (40, 3, 53, N'2017-12-08', 30, 7)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1008, 1, 1002, N'2017-12-11', 15, 6)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1010, 1, 1003, N'2017-12-11', 15, 5)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1011, 2, 1004, N'2017-12-12', 48, 4)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1012, 1, 1005, N'2017-12-05', 15, 3)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (1013, 1, 1006, N'2017-12-13', 15, 2)
INSERT [dbo].[tbl_schedule] ([id_tbl_line], [id_tbl_coach], [id_tbl_schedule], [col_start_date], [col_remainticket], [col_entrance]) VALUES (2002, 3, 1013, N'2017-11-08', 30, 1)
SET IDENTITY_INSERT [dbo].[tbl_schedule] OFF
SET IDENTITY_INSERT [dbo].[tbl_Ticket] ON 

INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:35:13', 1, 2106, N'2', 0, 5, 2014)
INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:35:13', 2, 2106, N'2', 0, 6, 3015)
INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:35:13', 3, 2106, N'2', 0, 7, 3017)
INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:36:17', 4, 2107, N'25', 0, 5, 3016)
INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:37:24', 5, 2108, N'10', 0, 1, 2012)
INSERT [dbo].[tbl_Ticket] ([col_ticket_time], [id_tbl_ticket], [id_tbl_order], [col_ticket_entrance], [col_ticket_State], [col_seatno], [id_tbl_passenger]) VALUES (N'2017/11/11 12:37:24', 6, 2108, N'10', 0, 2, 3014)
SET IDENTITY_INSERT [dbo].[tbl_Ticket] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (1, N'c4ca4238a0b923820dcc509a6f75849b', N'18816209068', N'1599083822@qq.com', 0, N'1')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3, N'21232f297a57a5a743894a0e4a801fc3', N'18816209067', N'1599083822@qq.com', 0, N'admin')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (4, N'sasa', N'18816209068', N'1599083822@qq.com', 0, N'sa')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (6, N'0d9b94f9998963f529b42d05cef24af5', N'18816209068', N'1599083822@qq.com', 1, N'3030144126')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (1008, N'b89a6c6bfb9fd9da054cd64a5a6907f2', N'18816209068', N'1599083822', 3, N'18816209068')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (1009, N'e10adc3949ba59abbe56e057f20f883e', N'111', N'111', 1, N'123456')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (1010, N'83b4ef5ae4bb360c96628aecda974200', N'', N'', 1, N'147852')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (2007, N'7275a8591b84cb1a26d6d9701b7e96cb', N'', N'', 1, N'131455')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3007, N'00b7691d86d96aebd21dd9e138f90840', N'', N'', 1, N'111222')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3008, N'e04755387e5b5968ec213e41f70c1d46', N'', N'', 1, N'131313')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3009, N'9dd1cbdaec89487b1ba9583f8aa26198', N'', N'', 1, N'1313131')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3010, N'b6d767d2f8ed5d21a44b0e5886680cb9', N'', N'', 1, N'22')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3011, N'd0970714757783e6cf17b26fb8e2298f', N'', N'', 1, N'112233')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (3012, N'0588c1af8a8ce2828f5c68e216ad5656', N'', N'', 1, N'111333222')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (4007, N'dc5c7986daef50c1e02ab09b442ee34f', N'', N'', 3, N'001')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5007, N'ce9e8dc8a961356d7624f1f463edafb5', N'', N'', 1, N'123333')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5008, N'e72581f8614727a152dec6fcfc739ad2', N'100', N'155555', 3, N'00005')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5009, N'ea20a043c08f5168d4409ff4144f32e2', N'', N'', 1, N'010')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5010, N'fc1198178c3594bfdda3ca2996eb65cb', N'', N'', 1, N'0010')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5011, N'21ef05aed5af92469a50b35623d52101', N'', N'', 1, N'010101')
INSERT [dbo].[tbl_user] ([id_tbl_user], [col_user_password], [col_user_tel], [col_user_email], [col_user_state], [col_nickname]) VALUES (5012, N'4c1c1cc12735195da3b9e52b182b4ded', N'', N'', 1, N'159988222')
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
ALTER TABLE [dbo].[tbl_line]  WITH CHECK ADD  CONSTRAINT [FK_TBL_LINE_REFERENCE_TBL_BUS_] FOREIGN KEY([col_definitionid])
REFERENCES [dbo].[tbl_bus_station] ([id_tbl_bus_station])
GO
ALTER TABLE [dbo].[tbl_line] CHECK CONSTRAINT [FK_TBL_LINE_REFERENCE_TBL_BUS_]
GO
ALTER TABLE [dbo].[tbl_line]  WITH CHECK ADD  CONSTRAINT [FK_TBL_LINE_REFERENCE_TBL_BUS2_] FOREIGN KEY([col_startid])
REFERENCES [dbo].[tbl_bus_station] ([id_tbl_bus_station])
GO
ALTER TABLE [dbo].[tbl_line] CHECK CONSTRAINT [FK_TBL_LINE_REFERENCE_TBL_BUS2_]
GO
ALTER TABLE [dbo].[tbl_order]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS] FOREIGN KEY([id_tbl_passenger])
REFERENCES [dbo].[tbl_passenger] ([id_tbl_passenger])
GO
ALTER TABLE [dbo].[tbl_order] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS]
GO
ALTER TABLE [dbo].[tbl_order]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS5] FOREIGN KEY([id_tbl_passenger2])
REFERENCES [dbo].[tbl_passenger] ([id_tbl_passenger])
GO
ALTER TABLE [dbo].[tbl_order] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS5]
GO
ALTER TABLE [dbo].[tbl_order]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS6] FOREIGN KEY([id_tbl_passenger3])
REFERENCES [dbo].[tbl_passenger] ([id_tbl_passenger])
GO
ALTER TABLE [dbo].[tbl_order] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS6]
GO
ALTER TABLE [dbo].[tbl_order]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS7] FOREIGN KEY([id_tbl_schedule])
REFERENCES [dbo].[tbl_schedule] ([id_tbl_schedule])
GO
ALTER TABLE [dbo].[tbl_order] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS7]
GO
ALTER TABLE [dbo].[tbl_passenger]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS3] FOREIGN KEY([id_tbl_user])
REFERENCES [dbo].[tbl_user] ([id_tbl_user])
GO
ALTER TABLE [dbo].[tbl_passenger] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS3]
GO
ALTER TABLE [dbo].[tbl_schedule]  WITH CHECK ADD  CONSTRAINT [FK_TBL_SCHE_REFERENCE_TBL_COAC2] FOREIGN KEY([id_tbl_line])
REFERENCES [dbo].[tbl_line] ([id_tbl_line])
GO
ALTER TABLE [dbo].[tbl_schedule] CHECK CONSTRAINT [FK_TBL_SCHE_REFERENCE_TBL_COAC2]
GO
ALTER TABLE [dbo].[tbl_schedule]  WITH CHECK ADD  CONSTRAINT [FK_TBL_SCHE_REFERENCE_TBL_COAC8] FOREIGN KEY([id_tbl_coach])
REFERENCES [dbo].[tbl_coach] ([id_tbl_coach])
GO
ALTER TABLE [dbo].[tbl_schedule] CHECK CONSTRAINT [FK_TBL_SCHE_REFERENCE_TBL_COAC8]
GO
ALTER TABLE [dbo].[tbl_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS15] FOREIGN KEY([id_tbl_passenger])
REFERENCES [dbo].[tbl_passenger] ([id_tbl_passenger])
GO
ALTER TABLE [dbo].[tbl_Ticket] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS15]
GO
ALTER TABLE [dbo].[tbl_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS9] FOREIGN KEY([id_tbl_order])
REFERENCES [dbo].[tbl_order] ([id_tbl_order])
GO
ALTER TABLE [dbo].[tbl_Ticket] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PASS9]
GO
ALTER TABLE [dbo].[tbl_user]  WITH CHECK ADD  CONSTRAINT [FK_tbl_user_tbl_user] FOREIGN KEY([id_tbl_user])
REFERENCES [dbo].[tbl_user] ([id_tbl_user])
GO
ALTER TABLE [dbo].[tbl_user] CHECK CONSTRAINT [FK_tbl_user_tbl_user]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[90] 4[3] 2[7] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[70] 2[3] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[29] 4[45] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -15
      End
      Begin Tables = 
         Begin Table = "tbl_bus_station"
            Begin Extent = 
               Top = 5
               Left = 35
               Bottom = 168
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_line"
            Begin Extent = 
               Top = 8
               Left = 408
               Bottom = 171
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tbl_schedule"
            Begin Extent = 
               Top = 12
               Left = 807
               Bottom = 258
               Right = 1022
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tbl_bus_station_1"
            Begin Extent = 
               Top = 329
               Left = 668
               Bottom = 585
               Right = 879
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_coach"
            Begin Extent = 
               Top = 49
               Left = 1114
               Bottom = 320
               Right = 1330
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1848
         Width = 2688
         Width = 1452
         Width = 1620
         Width = 1404
         Width = 1440
         Width = 1440
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Wid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_line'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'th = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2148
         Alias = 2052
         Table = 2496
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_line'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_line'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[3] 2[30] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[61] 2[3] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -126
      End
      Begin Tables = 
         Begin Table = "tbl_order"
            Begin Extent = 
               Top = 4
               Left = 271
               Bottom = 410
               Right = 509
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_passenger"
            Begin Extent = 
               Top = 25
               Left = 773
               Bottom = 519
               Right = 1015
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "view_line"
            Begin Extent = 
               Top = 27
               Left = 1082
               Bottom = 479
               Right = 1323
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1764
         Width = 360
         Width = 924
         Width = 948
         Width = 1752
         Width = 1236
         Width = 492
         Width = 684
         Width = 396
         Width = 636
         Width = 1152
         Width = 1032
         Width = 1068
         Width = 492
         Width = 504
         Width = 876
         Width = 1200
         Width = 1332
         Width = 336
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[77] 4[4] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_Ticket"
            Begin Extent = 
               Top = 11
               Left = 332
               Bottom = 310
               Right = 568
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_passenger"
            Begin Extent = 
               Top = 18
               Left = 55
               Bottom = 107
               Right = 297
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "view_order"
            Begin Extent = 
               Top = 0
               Left = 710
               Bottom = 536
               Right = 952
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 26
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2904
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_ticket'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_ticket'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_ticket'
GO
USE [master]
GO
ALTER DATABASE [Bus] SET  READ_WRITE 
GO
