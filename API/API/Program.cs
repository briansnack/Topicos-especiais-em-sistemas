// using System.Collections.Generic;
// using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
// Registrar o serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();

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
app.MapGet("/produto/listar", ([FromServices] AppDataContext ctx) => {
    if(ctx.Produtos.Any()){
        return Results.Ok(ctx.Produtos.ToList());
    } 
    return Results.NotFound("Não existem produtos na tabela");
});

// GET: http://localhost:5143/produto/buscar/idproduto
app.MapGet("/produto/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => {
        // BUSCA PELO NOME
        // ctx.Produtos.FirstOrDefaultAsync(produto => produto.Nome == nome);
        
        // if(produto != null){
        //     return Results.Ok(produto);
        // }

        // BUSCA PELO ID
        Produto? produto = ctx.Produtos.Find(id);
        if(produto is null){
            return Results.NotFound("Produto não encontrado!");
        }
        return Results.Ok(produto);
    }
);

// POST: http://localhost:5143/produto/cadastrar
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) => {

    // Adicionar o objeto dentro da tabela no banco de dados
    ctx.Produtos.Add(produto);
    ctx.SaveChanges(); // qnd grava, altera e remove tem que colocar o SaveChanges
    return Results.Created("", produto);
    }
);

// POST: http://localhost:5143/produto/deletar/id
app.MapDelete("/produto/deletar/{id}", (string id, [FromServices] AppDataContext ctx) => {
    
    Produto? produto = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null){
        return Results.NotFound("Produto não encontrado!");
    }
    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();
    return Results.Ok("Produto deletado!");
    }
);

// PUT: http://localhost:5143/produto/alterar
app.MapPut("/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado,[FromServices] AppDataContext ctx) => {

    Produto? produto = ctx.Produtos.Find(id);
    if(produto is null){
        return Results.NotFound("Produto não encontrado!");
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Valor = produtoAlterado.Valor;
    ctx.Produtos.Update(produto);
    ctx.SaveChanges();
    return Results.Ok("Produto alterado!");
    }
);

app.Run();
// record Produto(string nome, string descricao);         
