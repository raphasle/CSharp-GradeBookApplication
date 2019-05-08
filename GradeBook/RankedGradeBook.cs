using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) => Type = GradeBookType.Ranked;

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
            while (index < studentCount && gradeAverages[index] > averageGrade)
            {
                index++;
            }

            double percentage = 1 - index / studentCount;

            if (percentage > 0.8)
            {
                return 'A';
            } else if (percentage > 0.6)
            {
                return 'B';
            } else if (percentage > 0.4)
            {
                return 'C';
            } else if (percentage > 0.2)
            {
                return 'D';
            }

            return 'F';
        }
    }

}


