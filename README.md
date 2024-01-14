# person-Api

<p align="center">
  <image
  src="https://img.shields.io/github/languages/count/JCDMeira/person-api"
  />
  <image
  src="https://img.shields.io/github/languages/top/JCDMeira/person-api"
  />
  <image
  src="https://img.shields.io/github/last-commit/JCDMeira/person-api"
  />
  <image
  src="https://img.shields.io/github/watchers/JCDMeira/person-api?style=social"
  />
</p>

# 📋 Indíce

- [Proposta](#id01)
  - [Conclusões](#id01.01)
- [Requisitos](#id02)
  - [Requisitos funcionais](#id02.1)
  - [Requisitos não funcionais](#id02.2)
  - [Requisitos não obrigatórios](#id02.3)
- [Aprendizados](#id03)
- [Feito com](#id04)
- [Pré-requisitos](#id05)
- [Procedimentos de instalação](#id06)
- [Autor](#id07)

# 🚀 Proposta <a name="id01"></a>

Este é o projeto tem como objetivo central a criação de uma api que conte com end-point de get all para pessoas, a entidade contém os dados de nome, idade e gênero, além de um id único em formato GUID.

# 🎯 Requisitos <a name="id02"></a>

## 🎯 Requisitos funcionais <a name="id02.1"></a>

Sua aplicação deve ter:

- Um end-point com método get para obter uma lista em json de pessoas com nome, idade e gênero. (dados que vem mockados)

## 🎯 Requisitos não funcionais <a name="id02.2"></a>

É obrigatório a utilização de:

- .net

## 🎯 Requisitos não obrigatórios <a name="id02.3"></a>

- Utilizar context db para manter dados da aplicação

# Aprendizados <a name="id03"></a>

Esse projeto foi inicialmente idealizado para contemplar apenas um end-point de get que funcionaria como um getAll, o desafio foi dimensionado dessa forma para dar enfase ao estudo de como começar uma aplicação com c# e .net, assim como configurar a mesma e retornar dados mockados que em geral são usado como fake contract para quem consome.

A configuração e início do projeto ocorreu sem muitos impedimentos, então foram adicionadas as funções não obrigatórias e ainda adicionais.

- Usar context db para armazenar os dados (só enquanto o projeto está rodando)
- criação de rota de getById para pegar dado de um único item da entidade
- criação de uma rota de post para criar novos itens.

Tudo no c# são classes, então quando vamos modelar algo que será manipulado, isso é uma classe. Por exemplo nesse caso temos uma pessoa com nome, idade e gênero. Além do id único.

```c#
﻿namespace person_api.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }
    }
}
```

Os controllers são as definições de controle de rotas, sendo responsáveis por trabalhar qual requisição será atendida e de que forma em geral será atendida.
Sendo também uma classe, e nesse caso podendo responder ao endereço base + api/person, e tendo dois méetodos do http disponíveis. O GET e o POST.

No get temos o getAll que pega os dados e devolve de forma direta e o getByID que rece um id e busca o item que contém esse mesmo exato id. Já no post temos o create que cria um item da entidade person no nosso banco local.

```c#
﻿using Microsoft.AspNetCore.Mvc;
using person_api.Entities;
using person_api.Persistence;

namespace person_api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll() {
        var persons = _context.Persons;
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            if(person == null) { NotFound(); }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            var newPerson = new Person();
            newPerson.Id = Guid.NewGuid();
            newPerson.Name = person.Name;
            newPerson.Age = person.Age;
            newPerson.Gender = person.Gender;

            _context.Persons.Add(newPerson);
            return CreatedAtAction(nameof(GetById), new { id= newPerson.Id.ToString() }, newPerson);
        }
    }
}
```

Há também uma persistência local chamada de db context que foi criada para armazenar pessoas. Sendo apenas uma lista (List) da entidade Person. E não tendo o armazenamento de alguns dados mockados. O retorno da rota getAll se fosse para usar um mock para adequar ao tipo fake contract já poderia por si só retornar algo dessa forma, mas aqui é usado um modelo de banco local.

```c#
﻿using person_api.Controllers;
using person_api.Entities;

namespace person_api.Persistence
{
    public class PersonDbContext
    {
        public List<Person> Persons { get; set; }

        public PersonDbContext()
        {
            Persons = new List<Person>()  {
        new Person() { Gender="male", Id= new Guid("de70438d-a47e-414c-8641-618d9b88447a"), Name = "John Doe", Age = 42 },
        new Person() { Gender="male", Id=  new Guid("ab9fe789-5d03-4b60-81c1-70db7eb2dde3"), Name = "Joseph Alan", Age = 30 },
        new Person() { Gender="female", Id=  new Guid("19726897-79bd-4c7c-9737-8721ed035f7d"), Name = "Stella Dolle", Age = 29 },
        new Person() { Gender="male", Id= new Guid("c960e0ac-8a9d-400e-8947-72786ddbaac5"), Name = "Charles Anthony", Age = 35 },
        }; ;
        }
    }
}
```

Para esse banco local funcionar é adicionado uma declaração do mesmo no arquivo Program.cs, que é nosso entry point da aplicação. O comentário já existia, o que deixa o espaço para se declarar services no conteiner evidente, então é adicionar a construção (builder) de um serviço (Services) do tipo Singleton que indica que todos acesso daquele tipo serão para a mesma origem, similar ao conceito de import e export do javaScript, e esse singleton e do tipo PersonDbContext.

Em outras palavras estamos criando algo similar a um context do react, que permite todos os nossos controllers acessar aquela classe que servirá como banco local.

```c#
// Add services to the container.
builder.Services.AddSingleton<PersonDbContext>();
```

# 🛠 Feito com <a name="id04"></a>

<br />

- C#
- .net 8
- visual studio

<br />

# :sunglasses: Autor <a name="id07"></a>

<br />

- Linkedin - [jeanmeira](https://www.linkedin.com/in/jeanmeira/)
- Instagram - [@jean.meira10](https://www.instagram.com/jean.meira10/)
- GitHub - [JCDMeira](https://github.com/JCDMeira)
