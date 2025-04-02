using TP1_EF.models;
using SimpleInjector;
using Microsoft.EntityFrameworkCore;
using TP1_EF.Repositories;

namespace TP1_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //without DI

            /* using var context = new SchoolContext();
             var studentRepo = new Repository<Student>(context);

             var students = studentRepo.GetAll();*/

            //using simple injector
            // DI setup
            var container = new Container();
            container.Register<SchoolContext>(Lifestyle.Singleton);
            container.Register<DbContext>(() => container.GetInstance<SchoolContext>(), Lifestyle.Singleton);
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Singleton);
            container.Verify();

            var studentRepo = container.GetInstance<IRepository<Student>>();
            var context = container.GetInstance<SchoolContext>();

            //CREATE
           /* var newStudent = new Student
            {
                FirstName = "Reda",
                LastName = "Ziyani",
                StudentNumber = "STU2025"
            };

            studentRepo.Add(newStudent);
            context.SaveChanges(); // 👈 always save to persist

            Console.WriteLine(" Étudiant ajouté.");
           */
            //READ
            var students = studentRepo.GetAll();

            if (!students.Any())
            {
                Console.WriteLine(" Aucun étudiant trouvé.");
                return;
            }

            Console.WriteLine("\n Liste des étudiants :");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.FirstName} {student.LastName}");
            }

            //UPDATE
            //
            /*
            var studentToUpdate = studentRepo.GetById(newStudent.Id);
            if (studentToUpdate != null)
            {
                studentToUpdate.LastName = "Ziyanie";
                studentRepo.Update(studentToUpdate);
                context.SaveChanges();
                Console.WriteLine($" Étudiant ID {studentToUpdate.Id} mis à jour.");
            }*
            /

            //DELETE
            /*var studentToDelete = studentRepo.GetById(newStudent.Id);
            if (studentToDelete != null)
            {
                studentRepo.Remove(studentToDelete);
                context.SaveChanges();
                Console.WriteLine($" Étudiant ID {studentToDelete.Id} supprimé.");
            }
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.FirstName} {student.LastName}");
            }
            */
            //
            Console.WriteLine(" VIEW TESTING ");
            string studentNumber = "STU1002";
            var student2 = context.StudentDto
     .FromSqlInterpolated($"EXEC GetStudentByStudentNumber {studentNumber}")
     .AsEnumerable()
     .FirstOrDefault();

            if (student2 != null)
            {
                Console.WriteLine($" {student2.FirstName} {student2.LastName} ({student2.StudentNumber})");
            }


        }
    }
}
