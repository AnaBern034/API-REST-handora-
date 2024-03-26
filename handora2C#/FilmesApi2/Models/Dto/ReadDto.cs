namespace Models.Dto.ReadDto;
public class ReadDto
{
      
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public int Duraçao { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;


}