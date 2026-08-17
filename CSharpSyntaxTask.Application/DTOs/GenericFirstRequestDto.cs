namespace CSharpSyntaxTask.Application.DTOs;

public class GenericFirstRequestDto
{
    public IEnumerable<int> Numbers { get; set; } = new List<int>();
}