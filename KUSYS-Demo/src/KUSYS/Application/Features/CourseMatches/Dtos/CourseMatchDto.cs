namespace Application.Features.CourseMatches.Dtos;

public class CourseMatchDto
{
    public int Id { get; set; }
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public string StudentFirstName { get; set; }
    public string StudentLastName { get; set; }
}