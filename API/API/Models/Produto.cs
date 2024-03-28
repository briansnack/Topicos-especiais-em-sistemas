namespace API.Models;

public class Produto
{
    // Construtor
    public Produto() { }

    public Produto(string nome, string descricao, double valor){
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
    }
    
    // Atributos ou propriedades = Características de um objeto

    public string? Nome {get; set;} // O ? mostra que pode dar problema sem que avise 
    public string? Descricao { get; set; }
    public double Valor { get; set; }



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
