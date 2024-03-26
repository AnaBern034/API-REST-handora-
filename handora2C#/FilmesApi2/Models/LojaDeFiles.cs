public class LojaDeFilmes
{   
    [Key]
    
    private int id { get; set; }
    private List<Filmes> filmesVenda { get; set; }
    private double preco { get; set; }
    public int quantidade { get; set; }



}