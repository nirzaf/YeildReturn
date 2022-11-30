// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Bogus;

Console.WriteLine("Find all teenage Students");

var students = new Faker<Student>();

students.RuleFor(s => s.Id, f => f.IndexFaker);
students.RuleFor(s => s.Name, f => f.Name.FirstName());
students.RuleFor(s => s.Age, f => f.Random.Int(18, 24));
IList<Student> studentsList = students.Generate(20);

// Track time taken to execute the query
var watch = new Stopwatch();
watch.Start();
var teenAgeStudents = studentsList.GetTeenagers().Take(3);
watch.Stop();
Console.WriteLine($"Time taken to execute the query: {watch.ElapsedTicks} ticks");

//Track time taken to execute the query
watch.Restart();
var teenAgeStudentsUsingYield = studentsList.GetTeenagerUsingYield().Take(3);
watch.Stop();
Console.WriteLine($"Time taken to execute the query using yield : {watch.ElapsedTicks} ticks");

/*
Console.WriteLine("Find all teenage Students using yield");
foreach (var student in teenAgeStudentsUsingYield)
{
    Console.WriteLine($"Student Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
}

Console.WriteLine("Find all teenage Students using Linq");

foreach (var student in teenAgeStudents)
{
    Console.WriteLine($"Student Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
}
*/

Console.ReadLine();