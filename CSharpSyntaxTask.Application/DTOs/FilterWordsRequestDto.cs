namespace CSharpSyntaxTask.Application.DTOs;

public class FilterWordsRequestDto
{
    public List<string> Words { get; set; } = new();
}