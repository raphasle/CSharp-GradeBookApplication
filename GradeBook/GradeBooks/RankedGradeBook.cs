using GradeBook.GradeBooks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) => Type = GradeBookType.Ranked;

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            List<double> gradeAverages = new List<double>();
            foreach (var student in Students)
            {
                gradeAverages.Add(student.AverageGrade);
            }

            gradeAverages.Sort();

            int index = 0;
            while (index < studentCount && gradeAverages[index] < averageGrade)
            {
                index++;
            }

            double percentage = (double) index / studentCount;

            if (percentage >= 0.8)
            {
                return 'A';
            } else if (percentage >= 0.6)
            {
                return 'B';
            } else if (percentage >= 0.4)
            {
                return 'C';
            } else if (percentage >= 0.2)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }

}


