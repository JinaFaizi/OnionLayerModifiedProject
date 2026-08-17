using CSharpSyntaxTask.Application.DTOs;
using CSharpSyntaxTask.Application.Interfaces;
using CSharpSyntaxTask.Domain.Models;

namespace CSharpSyntaxTask.Application.Services;

public class SyntaxService : ISyntaxService
{
    public int CountVowels(string text)
    {
        int counter = 0;

        foreach (var character in text)
        {
            switch (character)
            {
                case 'a': counter++; break;
                case 'e': counter++; break;
                case 'i': counter++; break;
                case 'o': counter++; break;
                case 'u': counter++; break;
            }
        }

        return counter;
    }

    public List<string> FilterWords(FilterWordsRequestDto request)
    {
        if (request.Words == null || request.Words.Count == 0)
        {
            throw new ArgumentException("Enter a valid list of strings.");
        }

        return request.Words
            .Where(word => word.Length >= 4)
            .Select(word => word.ToUpper())
            .ToList();
    }

    public int Divide(int a, int b)
    {
        return a / b;
    }

    public double CalculateShapeArea(ShapeRequestDto request)
    {
        Shape shape;

        if (request.Type.ToLower() == "circle")
        {
            shape = new Circle(request.Value1);
        }
        else if (request.Type.ToLower() == "rectangle")
        {
            shape = new Rectangle(request.Value1, request.Value2);
        }
        else
        {
            throw new ArgumentException("Invalid Shape");
        }


        var area = shape switch
        {
            Circle circle =>
                Math.PI * circle.Radius * circle.Radius,

            Rectangle rectangle =>
                rectangle.Width * rectangle.Height,

            _ => 0
        };

        return area;
    }

    public async Task SimulateFetchAsync()
    {
        async Task SimulateDatabaseCall()
        {
            await Task.Delay(1000);
        }

        var task1 = SimulateDatabaseCall();
        var task2 = SimulateDatabaseCall();
        var task3 = SimulateDatabaseCall();

        await Task.WhenAll(task1, task2, task3);
    }

    public int FindFirstEven(GenericFirstRequestDto request)
    {
        var result = FindFirst(
            request.Numbers,
            number => number % 2 == 0
        );

        return result;
    }
    
    private T FindFirst<T>(IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }
}