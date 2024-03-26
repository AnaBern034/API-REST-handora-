using AutoMapper;
using Models.Dto.Filme;
using Models.Filme;
using Models.Dto.FilmeUpdate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Models.Dto.ReadDto;

namespace FilmeController.Controller;

[Route("[controller]")]
[ApiController]
public class FilmesController : ControllerBase
{
    private FilmeContex _context;
    public static int id = 0;
    private IMapper _mapper;

    public FilmesController(FilmeContex contex,IMapper mapper){
        _context = contex;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme ([FromBody]  CreateDto createDto)
    {   
        Filmes filme = _mapper.Map<Filmes>(createDto);
        _context.Add(filme); 
        _context.SaveChanges() ;
         return CreatedAtAction(nameof(RecuperarFilmePorId),new{id = filme.Titulo}, filme);
    }

    [HttpGet]
    public IEnumerable<ReadDto> RecuperarFilme ([FromQuery] int skip,[FromQuery] int take )
    {
        return _mapper.Map<List<ReadDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        
      var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        var dto = _mapper.Map<ReadDto>(filme);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id,[FromBody]  UpdateDto filmedto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            _mapper.Map(filmedto, filme);
            _context.SaveChanges();
            return NoContent();
    }

    [HttpPatch("{id}")]
      public IActionResult AtualizarNome(int id, JsonPatchDocument<UpdateDto> patch )
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();

            var filmeAtualiza= _mapper.Map<UpdateDto>(filme); 

            patch.ApplyTo(filmeAtualiza, ModelState);
            if(!TryValidateModel(filmeAtualiza)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeAtualiza, filme);
            _context.SaveChanges();
            return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deletaFulme(int id){

         var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();

    }
}

