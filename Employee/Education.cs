using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    [Serializable]
    public class Education
    {
        public string CourseID { get; set; }
        public string CourseDescription { get; set; }
        public enum GRADE { A = 1, A_MINUS, B_PLUS, B, B_MINUS, C_PLUS, C, C_MINUS, D_PLUS, D, D_MINUS, E, AU, IC, WD }
        public DateTime ApprovalDate { get; set; }
        public int CourseCredits { get; set; }
        public int TotalCredits { get; set; }
        public GRADE CourseGrade { get; set; }
        public Education()
        {

        }
        public Education (string courseID, string courseDescription, int gradeIndex, int courseCredits)
        {
            CourseGrade = (GRADE)gradeIndex;
            CourseDescription = courseDescription;
            ApprovalDate = DateTime.Today;
            CourseCredits = courseCredits;
            TotalCredits += courseCredits;
            CourseID = courseID;
        }
    }
}
