using AutoMapper;
using AutoMapper.Configuration.Conventions;
using FilmesApiAlura.Data;
using FilmesApiAlura.Dto;
using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApiAlura.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] CreateFilmeDtos filmeDtos)
    {
        Filme filme = _mapper.Map<Filme>(filmeDtos);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
    }


    [HttpGet]
    public IActionResult GetFilmes(int skip, int take)
    {
        var filmes = _context.Filmes.Skip(skip).Take(take);
        return Ok(filmes);
    }


    [HttpGet("{id}")]
    public IActionResult GetFilmeById(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody]
    UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();     
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}


