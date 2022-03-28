using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;

namespace PooProject
{
    class Program
    {
        // public static CarsRepository carsRepository = new CarsRepository();
        // public static Guid g = Guid.NewGuid();

        public static ClassesRepository classesRepository = ClassesRepository.Singleton;
        public static CoursesRepository coursesRepository = CoursesRepository.Singleton;
        public static CoursesMatrixRepository coursesMatrixRepository = CoursesMatrixRepository.Singleton;
        public static CoursesMatrixDisciplinesRepository coursesMatrixDisciplinesRepository = CoursesMatrixDisciplinesRepository.Singleton;
        public static DisciplinesRepository disciplinesRepository = DisciplinesRepository.Singleton;
        public static GradesRepository gradesRepository = GradesRepository.Singleton;
        public static ProfessorsRepository professorsRepository = ProfessorsRepository.Singleton;
        public static RoomsRepository roomsRepository = RoomsRepository.Singleton;
        public static SchedulesRepository schedulesRepository = SchedulesRepository.Singleton;
        public static StudentsRepository studentsRepository = StudentsRepository.Singleton;

        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello world");
            carsRepository.addCar("audi");
            carsRepository.addCar("ford");
            Console.WriteLine(carsRepository.getAllWithBrandFord()[0]); */

            Principal principal = new ("diretor@escolar.ifrn.edu.br", "123123");

            Person user = new Person();

            try
            {
                classesRepository.Open();
                coursesRepository.Open();
                coursesMatrixRepository.Open();
                coursesMatrixDisciplinesRepository.Open();
                disciplinesRepository.Open();
                gradesRepository.Open();
                professorsRepository.Open();
                roomsRepository.Open();
                schedulesRepository.Open();
                studentsRepository.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Bem vindo ao sistema escolar");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("MENU:");
                Console.WriteLine("opcao 0 -> Exit");
                Console.WriteLine("Opcao 1 -> Login como diretor");
                Console.WriteLine("Opcao 2 -> Cadastro de aluno");
                Console.WriteLine("Opcao 3 -> Listagem de alunos");
                Console.WriteLine("Opcao 4 -> Atualizar de alunos");
                Console.WriteLine("Opcao 5 -> Remover aluno");
                Console.WriteLine("Opcao 6 -> Cadastro de professor");
                Console.WriteLine("Opcao 7 -> Listagem de professores");
                Console.WriteLine("Opcao 8 -> Atualizar professor");
                Console.WriteLine("Opcao 9 -> Remover professor");
                Console.WriteLine("Opcao 10 -> Cadastro de salas");
                Console.WriteLine("Opcao 11 -> Listagem de salas");
                Console.WriteLine("Opcao 12 -> Atualizar sala");
                Console.WriteLine("Opcao 13 -> Remover sala");
                Console.WriteLine("Opcao 14 -> Cadastro de horario");
                Console.WriteLine("Opcao 15 -> Listagem de horarios");
                Console.WriteLine("Opcao 16 -> Atualizacao de horario");
                Console.WriteLine("Opcao 17 -> Remover horario");
                Console.WriteLine("Opcao 28 -> Cadastro de curso");
                Console.WriteLine("Opcao 29 -> Listagem de cursos");
                Console.WriteLine("Opcao 20 -> Atualizar curso");
                Console.WriteLine("Opcao 21 -> Remover curso");


                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite o seu email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Digite sua senha:");
                        string password = Console.ReadLine();

                        if (email == principal.Email && password == principal.Password && email != null && password != null)
                        {
                            user.Email = email;
                            user.Password = password;
                        }

                        break;

                    case 2:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Course? course = new Course("", null);
                            Grade? grade = new Grade(null, null);
                            Console.WriteLine("Digite o nome do aluno:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Digite o email do aluno:");
                            string studentEmail = Console.ReadLine();
                            Console.WriteLine("Digite a senha do aluno");
                            string studentPassword = Console.ReadLine();
                            Console.WriteLine("Digite a matricula do aluno");
                            string studentEnrolment = Console.ReadLine();

                            Console.WriteLine("Deseja Cadastrar o curso? (sim ou nao)");
                            string resp1 = Console.ReadLine();

                            if (resp1 == "sim")
                            {
                                Console.WriteLine("digite o id do curso:");
                                string courseId = Console.ReadLine();

                                if (courseId != null)
                                {
                                    course = coursesRepository.ListOne(new Guid(courseId));
                                }
                            }

                            Console.WriteLine("deseja definir um boletim? (sim ou nao)");
                            string resp2 = Console.ReadLine();

                            if (resp2 == "sim")
                            {
                                Console.WriteLine("Digite o id do boletim");
                                string gradeId = Console.ReadLine();

                                if (gradeId != null)
                                {
                                    grade = gradesRepository.ListOne(new Guid(gradeId));
                                }
                            }

                            studentsRepository.Insert(name, email: studentEmail, password: studentPassword, enrolment: studentEnrolment, course, grade);

                        }
                        break;

                    case 3:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            ListarAlunos();
                        }
                        break;

                    case 4:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do aluno");
                            Guid id = Guid.Parse(Console.ReadLine());

                            Course? course = new Course("", null);
                            Grade? grade = new Grade(null, null);
                            Console.WriteLine("Digite o nome do aluno:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Digite o email do aluno:");
                            string studentEmail = Console.ReadLine();
                            Console.WriteLine("Digite a senha do aluno");
                            string studentPassword = Console.ReadLine();
                            Console.WriteLine("Digite a matricula do aluno");
                            string studentEnrolment = Console.ReadLine();

                            Console.WriteLine("Deseja Cadastrar o curso? (sim ou nao)");
                            string resp1 = Console.ReadLine();

                            if (resp1 == "sim")
                            {
                                Console.WriteLine("digite o id do curso:");
                                string courseId = Console.ReadLine();

                                if (courseId != null)
                                {
                                    course = coursesRepository.ListOne(new Guid(courseId));
                                }
                            }

                            Console.WriteLine("deseja definir um boletim? (sim ou nao)");
                            string resp2 = Console.ReadLine();

                            if (resp2 == "sim")
                            {
                                Console.WriteLine("Digite o id do boletim");
                                string gradeId = Console.ReadLine();

                                if (gradeId != null)
                                {
                                    grade = gradesRepository.ListOne(new Guid(gradeId));
                                }
                            }

                            studentsRepository.Update(id, name, email: studentEmail, password: studentPassword, enrolment: studentEnrolment, course, grade);
                        }

                        break;

                    case 5:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do aluno");
                            Guid id = Guid.Parse(Console.ReadLine());
                            studentsRepository.Delete(id);
                        }
                        break;

                    case 6:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o nome do professor:");
                            string teachersName = Console.ReadLine();
                            Console.WriteLine("Digite o email do professor:");
                            string teachersEmail = Console.ReadLine();
                            Console.WriteLine("Digite a senha do professor");
                            string teachersPassword = Console.ReadLine();

                            professorsRepository.Insert(name: teachersName, email: teachersEmail, password: teachersPassword);

                        }
                        break;

                    case 7:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("--------- Listagem de Professores--------");
                            List<Professor> teachers = professorsRepository.ListAll();

                            foreach (Professor teacher in teachers)
                            {
                                Console.WriteLine(teacher.Id + " - " + teacher.Name + " - " + teacher.Email);
                            }
                        }
                        break;

                    case 8:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do professor");
                            Guid id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o nome do professor:");
                            string teachersName = Console.ReadLine();
                            Console.WriteLine("Digite o email do professor:");
                            string teachersEmail = Console.ReadLine();
                            Console.WriteLine("Digite a senha do professor");
                            string teachersPassword = Console.ReadLine();

                            professorsRepository.Update(id, name: teachersName, email: teachersEmail, password: teachersPassword);
                        }
                        break;

                    case 9:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do professor");
                            Guid id = Guid.Parse(Console.ReadLine());

                            professorsRepository.Delete(id);
                        }
                        break;

                    case 10:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite a identificacao da sala:");
                            string identification = Console.ReadLine();

                            roomsRepository.Insert(identification);
                        }
                        break;

                    case 11:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("--------- Listagem de Salas--------");
                            List<Room> roomsList = roomsRepository.ListAll();

                            foreach (Room room in roomsList)
                            {
                                Console.WriteLine(room.Id + " - " + room.Identification);
                            }
                        }
                        break;

                    case 12:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id da sala:");
                            Guid id = new Guid(Console.ReadLine());
                            Console.WriteLine("Digite a identificacao da sala:");
                            string identification = Console.ReadLine();

                            roomsRepository.Update(id, identification);
                        }
                        break;

                    case 13:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id da sala:");
                            Guid id = new Guid(Console.ReadLine());

                            roomsRepository.Delete(id);
                        }
                        break;

                    case 14:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite a data de inicio:");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a data de termino:");
                            DateTime finishDate = DateTime.Parse(Console.ReadLine());

                            Room? room = new Room("");

                            Console.WriteLine("Voce quer adicionar uma sala? (sim ou nao)");
                            string resp = Console.ReadLine();

                            if (resp == "sim")
                            {
                                Console.WriteLine("Digite o id da sala");
                                Guid roomId = new Guid(Console.ReadLine());
                                Room savedRoom = roomsRepository.ListOne(roomId);
                                room = savedRoom;
                            }
                            else
                            {
                                room = null;
                            }

                            Classe? classe = new Classe("", schedule: null, discipline: null, professor: null, grade: null);

                            Console.WriteLine("Voce quer adicionar uma turma? (sim ou nao)");
                            resp = Console.ReadLine();

                            if (resp == "sim")
                            {
                                Console.WriteLine("Digite o id da turma:");
                                Guid classId = new Guid(Console.ReadLine());
                                Classe savedClass = classesRepository.ListOne(classId);
                                classe = savedClass;
                            }
                            else
                            {
                                classe = null;
                            }

                            schedulesRepository.Insert(scheduleStart: startDate, scheduleEnd: finishDate, courseMatrixDisciplines: null, room, classe);
                        }
                        break;

                    case 15:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("--------- Listagem de Horarios--------");
                            List<Schedule> schedules = schedulesRepository.ListAll();

                            foreach (Schedule schedule in schedules)
                            {
                                Console.WriteLine("ID: " + schedule.Id);
                                Console.WriteLine("Inicio: " + schedule.ScheduleStart);
                                Console.WriteLine("Fim: " + schedule.ScheduleEnd);
                                if (schedule.Classe != null)
                                {
                                    Console.WriteLine("ID da turma: " + schedule.Classe.Id);
                                }
                                if (schedule.Room != null)
                                {
                                    Console.WriteLine("ID da sala: " + schedule.Room.Id);
                                }
                                Console.WriteLine("-------------------------------------");
                            }
                        }
                        break;

                    case 16:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do horario:");
                            Guid id = Guid.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a data de inicio:");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a data de termino:");
                            DateTime finishDate = DateTime.Parse(Console.ReadLine());

                            Room? room = new Room("");

                            Console.WriteLine("Voce quer adicionar uma sala? (sim ou nao)");
                            string resp = Console.ReadLine();

                            if (resp == "sim")
                            {
                                Console.WriteLine("Digite o id da sala");
                                Guid roomId = new Guid(Console.ReadLine());
                                Room savedRoom = roomsRepository.ListOne(roomId);
                                room = savedRoom;
                            }
                            else
                            {
                                room = null;
                            }

                            Classe? classe = new Classe("", schedule: null, discipline: null, professor: null, grade: null);

                            Console.WriteLine("Voce quer adicionar uma turma? (sim ou nao)");
                            resp = Console.ReadLine();

                            if (resp == "sim")
                            {
                                Console.WriteLine("Digite o id da turma:");
                                Guid classId = new Guid(Console.ReadLine());
                                Classe savedClass = classesRepository.ListOne(classId);
                                classe = savedClass;
                            }
                            else
                            {
                                classe = null;
                            }

                            schedulesRepository.Update(id, scheduleStart: startDate, scheduleEnd: finishDate, courseMatrixDisciplines: null, room, classe);
                        }
                        break;

                    case 17:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do Horario");
                            Guid id = Guid.Parse(Console.ReadLine());
                            schedulesRepository.Delete(id);
                        }
                        break;

                    case 18:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite a descricao do curso:");
                            string description = Console.ReadLine();

                            if (description != null)
                            {
                                coursesRepository.Insert(description, courseMatrix: null);
                            }
                            else
                            {
                                Console.WriteLine("Descricao invalida");
                            }

                        }
                        break;

                    case 19:
                        Console.WriteLine("--------- Listagem de Horarios--------");
                        List<Course> courses = coursesRepository.ListAll();

                        foreach (Course course in courses)
                        {
                            Console.WriteLine(course.Id + " - " + course.Description);
                        }
                        break;

                    case 20:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do curso:");
                            Guid id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Digite a descricao do curso:");
                            string description = Console.ReadLine();

                            if (description != null)
                            {
                                coursesRepository.Update(id, description, courseMatrix: null);
                            }
                            else
                            {
                                Console.WriteLine("Descricao invalida");
                            }

                        }
                        break;

                    case 21:
                        if (user.Email == "diretor@escolar.ifrn.edu.br" && user.Password == "123123")
                        {
                            Console.WriteLine("Digite o id do curso:");
                            Guid id = Guid.Parse(Console.ReadLine());
                            coursesRepository.Delete(id);
                        }
                        break;


                    default:
                        keepRunning = false;
                        break;
                }
            }
        }
        public static void ListarAlunos()
        {
            Console.WriteLine("--------- Listagem de alunos --------");
            List<Student> students = studentsRepository.ListAll();

            foreach (Student student in students)
            {
               Console.WriteLine(student.Id + " - " + student.Name + " - " + student.Email + " - " + student.Enrolment);
            }

        }
    }    

}
