using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApiAlura.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : Controller
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void Adicionar([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
    }

    [HttpGet]
    public IEnumerable<Filme> GetFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? GetFilmeById(int id)
    {
        return filmes.FirstOrDefault(filmes => filmes.Id == id);
    }


