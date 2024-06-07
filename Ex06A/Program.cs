// Criar um vetor
using System.Reflection;

Console.Clear();

int[] vetor = new int[100];

// Criar o objeto que vai gerar o número ramdomico
Random aleatorio = new Random();

// Preencher vetor com valores aleatórios
for(int i = 0; i < vetor.Length; i++){
    vetor[i] = aleatorio.Next(100) + 1;
}

// Imprimir vetor
for(int i = 0; i < vetor.Length; i++){
    Console.Write(vetor[i] + " ");
}

// Ordenar vetor
bool troca = false; // se criar dentro do laço de repetição não funciona
do{
    troca = false;
    for(int i = 0; i < vetor.Length - 1; i++){
        if(vetor[i] > vetor[i + 1]){
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
            troca = true;
        }
    }
}while(troca == true);

Console.WriteLine("\n");

// Imprimir vetor ordenado
for(int i = 0; i < vetor.Length; i++){
    Console.Write(vetor[i] + " ");
}