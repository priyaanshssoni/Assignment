USE SISDB

--Task 1. Database Design:
--1. Create the database named "SISDB"
CREATE DATABASE SISDB
----
/*2. Define the schema for the Students, Courses, Enrollments, Teacher, and Payments tables based
on the provided schema. Write SQL scripts to create the mentioned tables with appropriate data
types, constraints, and relationships.
a. Students
b. Courses
c. Enrollments
d. Teacher
e. Payments */

CREATE TABLE Students(
student_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
first_name VARCHAR(20) NOT NULL,
last_name VARCHAR(20) NOT NULL,
date_of_birth DATE NOT NULL,
email VARCHAR(100) NOT NULL,
phone_number int NOT NULL,
)

CREATE TABLE Teacher(
teacher_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
first_name VARCHAR(20) NOT NULL,
last_name VARCHAR(20) NOT NULL,
email VARCHAR(100) NOT NULL,
)

CREATE TABLE Courses(
course_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
course_name VARCHAR(20) NOT NULL,
credits int NOT NULL,
teacher_id int NOT NULL,
FOREIGN KEY(teacher_id) REFERENCES Teacher(teacher_id) 
)

CREATE TABLE Enrollments(
enrollment_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
course_name VARCHAR(20) NOT NULL,
FOREIGN KEY(student_id) REFERENCES Students(student_id),
course_id int NOT NULL,
FOREIGN KEY(course_id) REFERENCES Courses(course_id),
enrollment_date DATE NOT NULL
)

CREATE TABLE Payments(
payment_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
student_id int NOT NULL,
FOREIGN KEY(student_id) REFERENCES Students(student_id),
amount int NOT NULL,
payment_date DATE NOT NULL
)


--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity. 

alter Table Studetns
add constraint Students_Student_id_PK

alter table Enrollments
add constraint Enrollments_student_id_FK
FOREIGN KEY(student_id) REFERENCES Students(student_id) on DELETE CASCADE on UPDATE CASCADE  

alter table Enrollments
add constraint Enrollments_course_id_FK
FOREIGN KEY(course_id) REFERENCES Courses(course_id) on delete cascade

alter table Payments
add constraint Payments_student_id_FK
FOREIGN KEY(student_id) REFERENCES Students(student_id) on delete cascade 

alter table Payments
add constraint Payments_course_id_FK
FOREIGN KEY(course_id) REFERENCES Courses(course_id) on delete cascade on update CASCADE


/* 5. Insert at least 10 sample records into each of the following tables.
i. Students
ii. Courses
iii. Enrollments
iv. Teacher
v. Payments */

INSERT INTO Students VALUES 
('Priyansh','Soni','2001-07-04','sample1@gmail.com',1928473857)
('Shreyansh','Patel','2002-08-24','sample1@gmail.com',1928473857),
('Sushil','Yadav','1999-02-17','sample1@gmail.com',1928472857),
('Rayn','Soni','2000-09-21','sample1@gmail.com',1928483857),
('Elon','Patel','2002-05-29','sample1@gmail.com',1928473857),
('Oreo','Tarnekar','2001-12-11','sample1@gmail.com',1328473857),
('Sharad','Gurjar','2000-07-2','sample1@gmail.com',1928443857),
('Kishan','Agrawal','2001-12-13','sample1@gmail.com',1928273857),
('Aakash','Khan','2001-11-11','sample1@gmail.com',1928473857),
('Himanshu','Namdev','2003-03-14','sample1@gmail.com',1928273857)
SELECT * from Students

INSERT INTO Courses VALUES 
('Python',5,1),
('Java',7,2),
('Digital Marketing',3,3),
('C++',7,4),
('Java Script',5,5),
('React',5,6),
('SQL',3,7),
('MongoDB',3,8),
('MYSQL',3,9),
('Data Analysis',7,10)
SELECT * from Courses

INSERT INTO Teacher VALUES 
('Sundar','Pichai','teacher1@gmail.com'),
('Elon','Musk','teacher2@gmail.com'),
('Mukesh','Ambani','teacher3@gmail.com'),
('Ratan','Tata','teacher4@gmail.com'),
('Larry','Page','teacher5@gmail.com'),
('Laxmi','Mittal','teacher6@gmail.com'),
('Rakesh','Jhunjunvala','teacher7@gmail.com'),
('Radhakrishna','Damani','teacher8@gmail.com'),
('Harshad','Mehta','teacher9@gmail.com'),
('Shahrukh','Khan','teacher10@gmail.com')
SELECT * from Teacher

INSERT INTO Enrollments VALUES 
(1,1,GETDATE()),
(2,2,GETDATE()),
(3,3,GETDATE()),
(4,4,GETDATE()),
(5,5,GETDATE()),
(6,6,GETDATE()),
(7,7,GETDATE()),
(8,8,GETDATE()),
(9,9,GETDATE()),
(10,10,GETDATE())
SELECT * from Enrollments

INSERT INTO Payments VALUES 
(1,125000,GETDATE()),
(2,100000,GETDATE()),
(3,120000,GETDATE()),
(4,225000,GETDATE()),
(5,145000,GETDATE()),
(6,125000,GETDATE()),
(7,109000,GETDATE()),
(8,155000,GETDATE()),
(9,129000,GETDATE()),
(10,105000,GETDATE())



--- Task 2--
/* 1. Write an SQL query to insert a new student into the "Students" table with the following details:
a. First Name: John
© Hexaware Technologies Limited. All rights www.hexaware.com
b. Last Name: Doe
c. Date of Birth: 1995-08-15
d. Email: john.doe@example.com
e. Phone Number: 1234567890 */

INSERT INTO Students VALUES 
('John','Doe','1995-08-15','john.doe@example.com',1234567890)

/* 2. Write an SQL query to enroll a student in a course. Choose an existing student and course and
insert a record into the "Enrollments" table with the enrollment date. */

INSERT INTO Enrollments values
(11,2,'2024-04-09')

/* 3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and
modify their email address.*/

update Teacher
set email = 'updated.email@example.com'
where teacher_id = 3

/* 4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select
an enrollment record based on the student and course.*/

DELETE FROM Enrollments where student_id = 2 and course_id = 2

/* 5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and
teacher from the respective tables.*/

UPDATE Courses
set Teacher_id = 10
where course_id = 2

/* 6. Delete a specific student from the "Students" table and remove all their enrollment records
from the "Enrollments" table. Be sure to maintain referential integrity.*/
DELETE from Students where student_id = 10

/*6. Delete a specific student from the "Students" table and remove all their enrollment records
from the "Enrollments" table. Be sure to maintain referential integrity.*/
UPDATE Payments
set amount = 99999
where payment_id = 1


-- Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:
/* 1. Write an SQL query to calculate the total payments made by a specific student. You will need to
join the "Payments" table with the "Students" table based on the student's ID. */
select p.student_id, sum(p.amount) as Payments FROM Payments p
JOIN Students s 
on s.student_id = p.student_id
where p.student_id = 1
group by p.student_id


/*2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each
course. Use a JOIN operation between the "Courses" table and the "Enrollments" table.*/
SELECT c.course_name, count(e.student_id) as Total_Students from Courses c
JOIN Enrollments e on c.course_id = e.course_id
GROUP BY c.course_name


/* 3. Write an SQL query to find the names of students who have not enrolled in any course. Use a
LEFT JOIN between the "Students" table and the "Enrollments" table to identify students
without enrollments. */
select s.first_name,s.last_name from Students s
LEFT JOIN Enrollments e on e.student_id=s.student_id
where e.enrollment_id is NULL

/* 4. Write an SQL query to retrieve the first name, last name of students, and the names of the
courses they are enrolled in. Use JOIN operations between the "Students" table and the
"Enrollments" and "Courses" tables */
select s.first_name,s.last_name,c.course_name from Students s
JOIN Enrollments e on s.student_id= e.student_id
JOIN Courses c on e.course_id= c.course_id

/*5. Create a query to list the names of teachers and the courses they are assigned to. Join the
"Teacher" table with the "Courses" table*/
SELECT t.first_name,t.last_name,c.course_name from Teacher t
JOIN Courses c on t.teacher_id=c.teacher_id

/*6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the
"Students" table with the "Enrollments" and "Courses" tables. */
select s.first_name,s.last_name,c.course_name,e.enrollment_date from Students s
JOIN Enrollments e on s.student_id= e.student_id
JOIN Courses c on e.course_id= c.course_id
where c.course_name = 'Python'
/* 7. Find the names of students who have not made any payments. Use a LEFT JOIN between the
"Students" table and the "Payments" table and filter for students with NULL payment records. */
select s.first_name,s.last_name from Students s
LEFT JOIN Payments p on s.student_id=p.student_id
where amount is NULL

/*8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN
between the "Courses" table and the "Enrollments" table and filter for courses with NULL
enrollment records.*/
SELECT c.course_name from Courses c
LEFT JOIN Enrollments e on c.course_id= e.course_id 
 where e.enrollment_id is NULL

/*9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments"
table to find students with multiple enrollment records.*/
select e.student_id , COUNT(en.student_id) as Enrolled_Courses
from Enrollments e , Enrollments en 
where e.enrollment_id = en.enrollment_id 
GROUP BY e.student_id
HAVING COUNT(en.student_id)>1

/*10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher"
table and the "Courses" table and filter for teachers with NULL course assignments. */
select t.first_name,t.last_name,c.course_name from Teacher t
LEFT JOIN Courses c on c.teacher_id=t.teacher_id
where course_name is NULL

-- Task 4. Subquery and its type: 

/*1. Write an SQL query to calculate the average number of students enrolled in each course. Use
aggregate functions and subqueries to achieve this. */
select * from Courses
select * from Enrollments

--select avg(cnt) as Avg_Number from
--(select count(student_id) as cnt from Enrollments group by course_id ) as Coount -- -For Total 


select avg(count),course_name from ( (select(select c.course_name from Courses c where c.course_id=e.course_id) as Course_Name, 
count(e.course_id) as Count 
from Enrollments e 
group by course_id) ) as Abc
group by Course_Name -- for Each


/*2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum
payment amount and then retrieve the student(s) associated with that amount.*/
select (select s.first_name from Students s where s.student_id = p.student_id)as Name,amount from Payments p
order by p.amount DESC
offset 0 rows
fetch NEXT 1 row only

--or

select first_name , last_name  from Students
where student_id = 
(select student_id from Payments where amount =
(select Max(Total_amounts) from 
(select sum(amount) as Total_Amounts,student_id from Payments group by student_id)  as Totall))

---Common Table Expression 
/*3. Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the
course(s) with the maximum enrollment count.*/

select course_name from Courses c
where course_id in (
select course_id from Enrollments e
GROUP by course_id
having count(student_id) = 
(select Max(enrollment_count) from 
(select COUNT(student_id) as enrollment_count
from Enrollments
group by course_id ) as Subb))

-- Count of Courses Enrolled -> Max Count -> Compared with Count of Student id in Enrollment -> Input Course Id -> Course Name


/*4. Calculate the total payments made to courses taught by each teacher. Use subqueries to sum
payments for each teacher's courses.*/ --

--- We have to add the column to solve the riddle
alter table Payments
add course_id int
  

select (select concat(t.first_name + ' ' , t.last_name) as Teacher_Name from Teacher t where t.teacher_id =c.teacher_id ),
  c.course_name,
  Payment_Recieved 
from (select courses_id ,sum(total) as Payment_Recieved 
from (select amount as Total ,course_id as courses_id from Payments) as Amt
      GROUP by courses_id) as Sums
Right JOIN Courses c on c.course_id = sums.courses_id

/*5. Identify students who are enrolled in all available courses. Use subqueries to compare a
student's enrollments with the total number of courses.*/ 

select e.student_id as Students_Enrolled_All from Enrollments e
group by student_id
having  COUNT(e.course_id) = (select count(course_id) from Courses)


/*6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to
find teachers with no course assignments.*/

select concat(t.first_name + ' ',t.last_name) as Unassigned_Teachers from Teacher t
where teacher_id not in (select teacher_id from Courses c where c.teacher_id=t.teacher_id)


/*7. Calculate the average age of all students. Use subqueries to calculate the age of each student
based on their date of birth.*/

select avg(DateDiff(year,s.date_of_birth,GETDATE())) as Avg_Age from Students s

/*8. Identify courses with no enrollments. Use subqueries to find courses without enrollment
records.*/

select c.course_id,c.course_name from Courses c
where  course_id not in (select course_id from Enrollments )


/*9. Calculate the total payments made by *** each student for each course **** they are enrolled in. Use
subqueries and aggregate functions to sum payments.*/ --- 

select (select first_name from Students where student_id = amt.sdt) as Student_Name,
(select course_name from Courses where course_id = amt.crse) as Course_Name,
sum(fees) as Fees_Paid
from (select p.amount as fees ,e.student_id as sdt,e.course_id as crse from Payments p
Join Enrollments e on e.student_id = p.student_id and e.course_id = p.course_id) as amt
group by amt.sdt,amt.crse



/*10. Identify students who have made more than one payment. Use subqueries and aggregate
functions to count payments per student and filter for those with counts greater than one.*/
select s.first_name from Students S
where s.student_id in  
(select p.student_id from Payments p
group by student_id
having count(student_id)>1)

/*11. Write an SQL query to calculate the total payments made by each student. Join the "Students"
table with the "Payments" table and use GROUP BY to calculate the sum of payments for each
student.*/
select (select concat(f.first_name + ' ', f.last_name) from Students f where student_id=p.student_id ) as Student_Name, 
sum(p.amount) as Total_Amount
from Payments p 
group by p.student_id

/*12. Retrieve a list of course names along with the count of students enrolled in each course. Use
JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to
count enrollments*/
select c.course_name,count(e.student_id) as Total_Enrollments from Courses c
LEFT JOIN Enrollments e 
on e.course_id=c.course_id
group by e.course_id,c.course_name

/*13. Calculate the average payment amount made by students. Use JOIN operations between the
"Students" table and the "Payments" table and GROUP BY to calculate the average.*/
select concat(s.first_name + ' ',s.last_name) as [Name],avg(p.amount) as Avg_Amt_Spent from Students s
JOIN Payments p 
on s.student_id=p.student_id
group by p.student_id,s.first_name,s.last_name

