USE [MovieTicketBooking]
GO
/****** Object:  StoredProcedure [dbo].[FetchMovieDetails]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[FetchMovieDetails] 
(@cityId DECIMAL(8,0),
 @theatreId DECIMAL(8,0),
 @movieId DECIMAL(8,0)) AS

 BEGIN

SELECT m.Title, t.Name, s.ShowId, s.Date, s.Time, s.Price, c.CityName, (Capacity - TicketsSold) AS Tickets FROM Theatre AS t
INNER JOIN Show AS s ON t.TheatreId = s.TheatreId
LEFT JOIN Movie AS m ON s.MovieId = m.MovieId 
INNER JOIN City AS c ON t.CityId = c.CityId
WHERE t.TheatreId = @theatreId OR c.CityId = @cityId OR m.MovieId = @movieId

END


GO
/****** Object:  StoredProcedure [dbo].[FetchMovieList]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FetchMovieList](
@theatreId DECIMAL(8,0))
AS BEGIN
SELECT m.* FROM Theatre AS t
INNER JOIN Show AS s ON t.TheatreId = s.TheatreId
LEFT JOIN Movie AS m ON s.MovieId = m.MovieId WHERE t.TheatreId = @theatreId;
END

GO
/****** Object:  StoredProcedure [dbo].[USP_BookTicket]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_BookTicket]
(@showId DECIMAL(8,0),
 @custName varchar(50),
 @tickets DECIMAL(8,0))
AS BEGIN
   INSERT INTO Booking (ShowId,CustomerName,NoOfTickets)
     VALUES (@showId, @custName, @tickets);

	UPDATE Show SET TicketsSold = TicketsSold + @tickets WHERE ShowId = @showId;
END
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [decimal](8, 0) IDENTITY(1,1) NOT NULL,
	[ShowId] [decimal](8, 0) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[NoOfTickets] [decimal](8, 0) NOT NULL CONSTRAINT [DF_Booking_NoOfTickets]  DEFAULT ((0)),
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [decimal](8, 0) IDENTITY(121,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [decimal](8, 0) IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Show]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show](
	[ShowId] [decimal](8, 0) IDENTITY(1,1) NOT NULL,
	[TheatreId] [decimal](8, 0) NOT NULL,
	[MovieId] [decimal](8, 0) NOT NULL,
	[Date] [datetime2](7) NOT NULL CONSTRAINT [DF_Show_Date]  DEFAULT (CONVERT([date],getdate())),
	[Time] [time](7) NOT NULL CONSTRAINT [DF_Show_Time]  DEFAULT (CONVERT([time],getdate())),
	[Price] [money] NOT NULL,
	[TicketsSold] [decimal](8, 0) NOT NULL CONSTRAINT [DF_Show_TicketsSold]  DEFAULT ((0)),
 CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED 
(
	[ShowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Theatre]    Script Date: 5/21/2017 3:56:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Theatre](
	[TheatreId] [decimal](8, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Capacity] [decimal](8, 0) NOT NULL CONSTRAINT [DF_Theatre_Capacity]  DEFAULT ((0)),
	[CityId] [decimal](8, 0) NOT NULL,
 CONSTRAINT [PK_Theatre] PRIMARY KEY CLUSTERED 
(
	[TheatreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Show] FOREIGN KEY([ShowId])
REFERENCES [dbo].[Show] ([ShowId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Show]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Movie]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Theatre] FOREIGN KEY([TheatreId])
REFERENCES [dbo].[Theatre] ([TheatreId])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Theatre]
GO
ALTER TABLE [dbo].[Theatre]  WITH CHECK ADD  CONSTRAINT [FK_Theatre_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Theatre] CHECK CONSTRAINT [FK_Theatre_City]
GO
ALTER TABLE [dbo].[Theatre]  WITH CHECK ADD  CONSTRAINT [CK_Theatre] CHECK  (([Capacity]>=(0)))
GO
ALTER TABLE [dbo].[Theatre] CHECK CONSTRAINT [CK_Theatre]
GO
