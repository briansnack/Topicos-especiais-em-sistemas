namespace API.Models;

public class Produto{
    // Construtor
    public Produto() { 
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public Produto(string nome, string descricao, double valor){
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        CriadoEm = DateTime.Now;
    }
    
    // Atributos ou propriedades = Características de um objeto
    public string Id { get; set; }
    public string? Nome { get; set; } // O ? mostra que pode dar problema sem que avise 
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }

    // private string nome;
    // private string descricao;
    // Colocar informações (JAVA)
    // public void setNome(string nome){
    //     this.nome = nome;
    // }

    // Pegar informações (JAVA)
    // public string getNome(){
    //     return this.nome;
    // }
   
}
// record Produto(string nome, string descricao);
