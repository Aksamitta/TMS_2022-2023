select * from Department
Insert into Department (DepartmentID, Department_Name, Department_Spec)
Values (1, 'Game Developers', 'Write code'),
(2, 'Game Designers', 'Desine a game'),
(3, 'QA/QC', 'test a game'),
(4, 'Human Resources (HR)', 'hire candidates'),
(5, 'Designe Leads', 'create smth'),
(6, 'Public Relations (PR)', 'increase awareness a game')

Update Department
set CEO = 6 
where DepartmentID = 6

delete Department 
where DepartmentID = 7


select * from Tool
Insert Tool Values ('Blender', 'Blender Foundation', '2023-03-03', '3D Grafics')
Insert Tool Values ('SpeedTree', 'SpeedTree Foundation', '2023-03-03', 'Create trees')
Insert Tool Values ('Unity', 'Unity Technologies', '2023-03-03', 'Game engine')
Insert Tool Values ('Adobe Audition', 'Adobe Systems', '2023-03-03', 'Create music and voices')
Insert Tool Values ('Nvidia ShadowPlay', 'Nvidia', '2023-03-03', 'Smth for video and devlogs')
Insert Tool Values ('Trello', 'Trello Foundations', '2023-03-03', 'Planning and save tasks')
Insert Tool Values ('Pairwise Testing', 'Pairwise Testing Foundations', '2023-03-03', 'Smth do')
Insert Tool Values ('Sublime Text 2', 'Sublime Text 2 Foundations', '2023-03-03', 'write code')
Insert Tool Values ('InVision', 'InVision Foundations', '2023-03-03', 'make mock-ups')
Insert into Tool (Tool_Name, Tool_Developer, Tool_Specialization) Values ('Linkedin', 'Linkedin', 'search')

select * from Employee
Insert Employee Values (1, 'Peter Spurrier', 1, 'Unity', 2000),
Insert Employee Values (2, 'Duc Luu', 2, 'Trello', 2800),
(3, 'Robert Alonzo', 3, 'Pairwise Testing', 1500),
Insert Employee Values (4, 'Gilad Lotan', 4, 'Linkedin', 1300),
(5, 'Phillip Moore', 5, 'Blender', 2800),
(6, 'Scott Piper', 6, 'Linkedin', 1300),
(7, 'Mike Smith', 1, 'Unity', 2000),
(8, 'Daniel Hawe', 2, 'InVision', 2100),
(9, 'Ming Qui', 2, 'Sublime Text 2', 2100),
(10, 'Mark Hicks', 1, 'Unity', 2000),
(11, 'Youlia Galenko', 1, 'Unity', 2000),
(12, 'Mitchell Gould', 3, 'Pairwise Testing', 1500),
(13, 'Luke Jackson', 5, 'Nvidia ShadowPlay', 1500),
(14, 'Kurt Wimmer', 5, 'SpeedTree', 1500)

delete Employee 
where EmployeeID = 2

select * from Client
insert Client values ('Portkey Games', 'USA', 'Zynga'),
('Techland', 'Poland', 'Pave Marchevka'),
('SCS Software', 'Check Republick', 'Lewis Rainer'),
('Blizzard Entertainment', 'USA', 'Allen Adam'),
('Roblox Corporation', 'USA', 'David Baszucki'),
('Deep Silver', 'Great Britain', 'Lewis Rainer')

select * from Project
insert Project values ('Dead Island', '2010-09-11', 2, 2, 50000),
('Euro Truck Simulator 2', '2010-10-01', 3, 2, 100000),
('Hogwarts Legacy', '2019-09-16', 1, 5, 60000),
('Hearthstone', '2012-11-22', 4, 3, 40000),
('Adopt Me!', '2012-06-11', 5, 2, 35000),
('Shenmue III', '2019-11-02', 6, 3, 50000)

select count(Project_Name) as Project_Name, DepartmentID from Project
Group by DepartmentID
Having count(Project_Name) > 2
Update Employee SET Salary = Salary - 100

select Name, DepartmentID, Salary from Employee
JOIN Department ON Employee.DepartmentID = Department.DepartmentID
JOIN Project ON Department.DepartmentID = Project.DepartmentID
Group by Name
Having count(Project_Name) > 1
Update Employee SET Salary = Salary - 100

CREATE PROCEDURE [dbo].[usp_Employee_Reduce_Salary] (@date_from	date, @date_to	date)	
AS
BEGIN
	Select Name, Salary from Employee
	Join Department on Employee.DepartmentID = Department.DepartmentID
	Join Project on Department.DepartmentID = Project.DepartmentID
	where Project_Start Between @date_from and @date_to
	Group by Name, Salary
	Having count(Project_Name) < 2
	
	UPDATE Employee set Salary = Salary - 100
END

exec usp_Employee_Reduce_Salary '2010-06-01', '2010-12-30'

CREATE function [dbo].[fnReturnExpenciveProject] (@date_from	date, @date_to	date)
returns nvarchar(50)
	BEGIN
		Declare @clientName nvarchar(50)
		Select @clientName = Client_Name from Client
		Join Project on Client.ClientID = Project.ClientID
		where Project_Start Between @date_from and @date_to 
		and Cost = (Select max(cost) from Client
				Join Project on Client.ClientID = Project.ClientID)
		return @clientName
	
	END

select dbo.fnReturnExpenciveProject ('2010-06-01', '2010-12-30')


