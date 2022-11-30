public static class Extension
{
    public static IEnumerable<Student> GetTeenagers(this IEnumerable<Student> students)
    {
        return students.Where(s => s.Age is >= 13 and <= 19);
    }
    
    public static IEnumerable<Student> GetTeenagerUsingYield(this IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            if (student.Age is >= 13 and <= 19)
            {
                yield return student;
            }
        }
    }
}