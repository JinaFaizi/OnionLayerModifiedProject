using CSharpSyntaxTask.Application.DTOs;

namespace CSharpSyntaxTask.Application.Interfaces;

public interface ISyntaxService
{
    int CountVowels(string text);

    List<string> FilterWords(FilterWordsRequestDto request);

    int Divide(int a, int b);

    double CalculateShapeArea(ShapeRequestDto request);

    Task SimulateFetchAsync();

    int FindFirstEven(GenericFirstRequestDto request);
}