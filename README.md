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

# Aprendizados  <a name="id03"></a>

Esse projeto foi inicialmente idealizado para contemplar apenas um end-point de get que funcionaria como um getAll, o desafio foi dimensionado dessa forma para dar enfase ao estudo de como começar uma aplicação com c# e .net, assim como configurar a mesma e retornar dados mockados que em geral são usado como fake contract para quem consome.

A configuração e início do projeto ocorreu sem muitos impedimentos, então foram adicionadas as funções não obrigatórias e ainda adicionais.

- Usar context db para armazenar os dados (só enquanto o projeto está rodando)
- criação de rota de getById para pegar dado de um único item da entidade
- criação de uma rota de post para criar novos itens.

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
