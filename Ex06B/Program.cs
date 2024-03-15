namespace Exe06B;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int[] vetor = new int[100];
        Random aleatorio = new Random();

        // Preencher vetor com valores aleatórios
        for (int i = 0; i < vetor.Length; i++)
        {
            vetor[i] = aleatorio.Next(100) + 1;
        }

        // Imprimir vetor
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
        // Ordenação com alguma funcionalidade da linguagem
        Array.Sort(vetor);
        Console.WriteLine("\n");
        // Imprimir vetor ordenado 
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
    }
}