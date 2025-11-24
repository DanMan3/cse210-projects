using System;

class Program
{
    static void Main(string[] args)
    {

        Assignment assignment = new Assignment("John Cena", "Science");
        string assignmentSummary = assignment.GetSummary();
        Console.WriteLine(assignmentSummary);


        MathAssignment mathAssignment = new MathAssignment("Json Bourne", "Science", "6.7", "4-18");
        var mathSummary = mathAssignment.GetSummary();
        var homeworkList = mathAssignment.GetHomeworkList();
        Console.WriteLine(mathSummary);
        Console.WriteLine(homeworkList);


        WritingAssignment writingAssignment = new WritingAssignment("Mary Jane Barton", "Western Archaeology", "The Best of Western Archaeological Discoveries");
        var writingSummary = writingAssignment.GetSummary();
        var title = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingSummary);
        Console.WriteLine(title);


    }
}