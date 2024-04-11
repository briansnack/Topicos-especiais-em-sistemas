// using System.Collections.Generic;
// using Microsoft.AspNetCore.Builder;

using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Produto produto = new Produto();
produto.Nome = "Bolacha";
Console.WriteLine(produto.Nome);

List<Produto> produtos =
[
    new Produto("Celular", "IOS", 3600),
    new Produto("Celular", "Android", 1800),
    new Produto("Televisão", "LG", 2500),
    new Produto("Placa de Vídeo", "Nvidia", 1850.99),
];

// Funcionalidades da aplicação - EndPoints 

// GET: http://localhost:5143/
app.MapGet("/", () => "API de Produtos");

// GET: http://localhost:5143/produto/listar
app.MapGet("/produto/listar", () => produtos);

// GET: http://localhost:5143/produto/buscar/nomedoproduto
app.MapGet("/produto/buscar/{nome}", ([FromRoute] string nome) => {
    for (int i = 0; i < produtos.Count; i++)
        {
            if (produtos[i].Nome == nome)
            {
                // retornar o produto encotrado
                return Results.Ok(produtos[i]);
            }
        }
        return Results.NotFound();
    }
);

// POST: http://localhost:5143/produto/cadastrar
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) => {
    // // Preencher o objeto pelo construtor
    // Produto produto = new(nome, descricao, valor);

    // // Preencher o objeto pelos atributos
    // // Produto produto = new Produto(nome, descricao, valor);
    // // produto.Nome = nome;
    // // produto.Descricao = descricao;
    // // produto.Valor = valor;

    // Adicionar o objeto dentro da lista
    produtos.Add(produto);
    return Results.Created("", produto);
    }
);

// POST: http://localhost:5143/produto/deletar
app.MapDelete("/produto/deletar/{id}", ([FromRoute] string id, [FromBody] Produto produtoDeletado) => {

    Produto? produto = produtos.FirstOrDefault(x => x.Id == id);
    if(produto is null){
        return Results.NotFound("Produto não encontrado!");
    }
    produtos.Remove(produto);
    return Results.Ok("Produto deletado!");
    }
);

// PUT: http://localhost:5143/produto/alterar
app.MapPut("/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) => {

    Produto? produto = produtos.FirstOrDefault(x => x.Id == id);
    if(produto is null){
        return Results.NotFound("Produto não encontrado!");
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Valor = produtoAlterado.Valor;
    return Results.Ok("Produto alterado!");
    }
);

app.Run();
// record Produto(string nome, string descricao);         
