using CSharpSyntaxTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CSharpSyntaxTask.Application.DTOs;

namespace CSharpSyntaxTask.API.Controllers;

[ApiController]
[Route("api/syntax")]
public class SyntaxMasteryController : ControllerBase
{
    private readonly ISyntaxService _syntaxService;

    public SyntaxMasteryController(ISyntaxService syntaxService)
    {
        _syntaxService = syntaxService;
    }

    [HttpGet("vowels/{text}")]
    public IActionResult Vowels(string text)
    {
        var result = _syntaxService.CountVowels(text);

        return Ok(result);
    }
    
    [HttpPost("filter-words")]
    public IActionResult FilterWords(FilterWordsRequestDto request)
    {
        try
        {
            var result = _syntaxService.FilterWords(request);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("divide")]
    public IActionResult Divide(int a, int b)
    {
        try
        {
            var result = _syntaxService.Divide(a, b);

            return Ok(result);
        }
        catch (DivideByZeroException)
        {
            return BadRequest("Cannot divide by zero.");
        }
    }
    
    [HttpPost("shapes")]
    public IActionResult Shapes(ShapeRequestDto request)
    {
        try
        {
            var result = _syntaxService.CalculateShapeArea(request);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("simulate-fetch")]
    public async Task<IActionResult> SimulateFetch()
    {
        await _syntaxService.SimulateFetchAsync();

        return Ok("All fetches completed successfully.");
    }
    
    [HttpPost("generic-first")]
    public IActionResult GenericFirst(GenericFirstRequestDto request)
    {
        var result = _syntaxService.FindFirstEven(request);

        return Ok(result);
    }
}