--------------------------------------------------------
-- The SQL below is intended for Microsoft SQL Server --
--------------------------------------------------------

------------------------
-- Column definitions --
------------------------

-- [FlightId] -> Primary key
-- [OriginStation] -> 3letter Origin station airport code
-- [DestinationStation] -> 3letter Destination station airport code
-- [FlightsAvailableFrom] -> datetime, Route is available From
-- [FlightsAvailableTo] -> datetime, Route is available To
-- [AirlineCode] -> Airlinecode, Airline operating route (EW = Eurowings; LH = Lufthansa)

-------------------
-- Create table ---
-------------------

CREATE TABLE [Flight](
        [FlightId] [bigint] IDENTITY(1,1) NOT NULL,
        [OriginStation] [nvarchar](3) NOT NULL,
        [DestinationStation] [nvarchar](3) NOT NULL,
        [FlightsAvailableFrom] [datetime] NOT NULL,
        [FlightsAvailableTo] [datetime] NOT NULL,
        [AirlineCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED
(
        [FlightId] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
 
------------------
-- Create data ---
------------------

INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('CGN','BER','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('BER','CGN', '2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('CGN','PMI','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('PMI','CGN','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('HAM','PMI','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('PMI','HAM','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','EW')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('FRA','MUC','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','LH')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('MUC','FRA','2011-01-01 00:00:00.000','2099-01-01 00:00:00.000','LH')
INSERT INTO [Flight]([OriginStation],[DestinationStation],[FlightsAvailableFrom],[FlightsAvailableTo],[AirlineCode])
     VALUES ('CGN','MUC','2011-01-01 00:00:00.000','2023-01-01 00:00:00.000','EW')
GO
