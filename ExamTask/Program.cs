using ExamTask;

List<Exam> Exams = new List<Exam>();

Exam exam1 = new Exam("Algorithm", new DateTime(2024, 03, 01, 14, 30, 00));
Exam exam2 = new Exam("Chemistry", new DateTime(2024, 02, 01, 15, 30, 00));
Exam exam3 = new Exam("English", new DateTime(2024, 07, 19, 08, 00, 00));
Exam exam4 = new Exam("Crypto", new DateTime(2024, 02, 25, 08, 00, 00));
Exam exam5 = new Exam("Riyaziyyat", new DateTime(2024, 01, 10, 11, 45, 00));


Exams.Add(exam1);
Exams.Add(exam2);
Exams.Add(exam3);
Exams.Add(exam4);

string opt;
string subject;
string dateStr;
DateTime date;
do
{
    Console.WriteLine("Exam blank");
    Console.WriteLine("1. Show all exams");
    Console.WriteLine("2. Add new exam");
    Console.WriteLine("3. Show exams that start with 'A' ");
    Console.WriteLine("4. Show passed exams");
    Console.WriteLine("5. Show exams that are in less than a month");
    Console.WriteLine("6. Show exams at 08:00");
    Console.WriteLine("7. Remove passed exams");
    Console.WriteLine("8. Check if there is a 'Riyaziyyat' exam ");
    Console.WriteLine("9. Show 'Riyaziyyat' exam");
    Console.WriteLine("0.Exit");
    Console.Write("Choose the operation:  ");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            if (Exams.Count == 0)
                Console.WriteLine("Exam list is empty !!");
            
            foreach (var exam in Exams)
            {
                Console.WriteLine(exam);
            }
            break;
        case "2":
            do
            {
                Console.Write("Enter the exam subject name:");
                subject = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(subject));
            do
            {
                Console.Write("Enter the exam date: ");
                dateStr = Console.ReadLine();
            } while (!DateTime.TryParse(dateStr, out date));
            Exam addExam = new Exam(subject, date);
            Exams.Add(addExam);
            Console.WriteLine("Exam succesfully added !");
            break;
        case "3":
            var examsStartWithA = (Exams.FindAll(exam => exam.Subject.StartsWith("A")));
            foreach (var examsA in examsStartWithA)
            {
                Console.WriteLine(examsA);
            }
            break;
        case "4":
            var passedExams = (Exams.FindAll(exam => exam.Date < DateTime.Now));
            if (passedExams.Count == 0)
                Console.WriteLine("No passed exams.");
            foreach (var passedExam in passedExams)
            {
                Console.WriteLine(passedExam);
            }
            break;
        case "5":
            var currentDate = DateTime.Now;
            var oneMonthForExam = currentDate.AddMonths(1);
            var lessThanOneMonth = Exams.FindAll(exam => exam.Date > currentDate && exam.Date <= oneMonthForExam);
            foreach (var examOneMonth in lessThanOneMonth)
            {
                Console.WriteLine(examOneMonth);
            }
            break;
        case "6":
            var examsAtEight = Exams.FindAll(exam => exam.Date.Hour == 08 && exam.Date.Minute == 00);
            foreach (var eightoclocexam in examsAtEight)
            {
                Console.WriteLine(eightoclocexam);
            }
            break;
        case "7":
            var removePassedExams = Exams.RemoveAll(exam => exam.Date < DateTime.Now);
            Console.WriteLine("Passed exams succesfully removed !");
            break;
        case "8":
            var hasRiyaziyyatExam = Exams.Exists(exam => exam.Subject.Contains("Riyaziyyat"));
            if (hasRiyaziyyatExam)
                Console.WriteLine("Found riyaziyyat exam");
            else 
                Console.WriteLine("Not found!");
            break;
        case "9":
            var riyaziyyatExams = Exams.FindAll(exam => exam.Subject.Contains("Riyaziyyat"));
            if (riyaziyyatExams.Count == 0) 
                Console.WriteLine("Not found!");
            foreach (var riyazExam in riyaziyyatExams)
            {
                Console.WriteLine(riyazExam);
            }
            break;
        case "0":
            Console.WriteLine("Exiting....");
            break;
        default:
            Console.WriteLine("Choose valid operation!");
            break;
    }
} while (opt != "0");

