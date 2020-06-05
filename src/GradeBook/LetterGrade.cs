namespace GradeBook
{
    public class LetterGrade : ILetterGrade
    {
        public double ConvertToDouble(char grade)
        {
            switch (grade)
            {
                case 'A':
                    return 90;
                case 'B':
                    return 80;
                case 'C':
                    return 70;
                default:
                    return 0;
            }
        }
    }
}