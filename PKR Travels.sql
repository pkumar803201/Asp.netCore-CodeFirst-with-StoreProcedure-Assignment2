create database PKRTravelsDB
use PKRTravelsDB
Create table BusInfo(BusId int identity(1,1),BoardingPoint varchar(20),TravelDate Date,Amount Decimal(6,2),Rating int
constraint pk_BusId primary key(BusId));

Create Procedure dbo.GetBusList
as
begin
Select * from BusInfo
end

Create proc dbo.InsertBusInfo
(
@BoardingPoint nvarchar(20),
@Amount Decimal(6,2),
@Rating int
)
as
begin try
Insert into BusInfo(BoardingPoint,TravelDate,Amount,Rating)
values(@BoardingPoint,GetDate(),@Amount,@Rating)
select 'Save Successfully!' as Response
end try
begin catch
select ERROR_MESSAGE() as Response
end catch


select GETDATE()