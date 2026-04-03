
# 📝 Desafio Gerenciador de Tarefas com ASP.NET Core MVC

Este projeto consiste numa aplicação web completa que permite ao utilizador criar, visualizar, editar e remover tarefas, além de realizar filtragens avançadas por status, data ou título.

## 🚀 Tecnologias Utilizadas

* **ASP.NET Core MVC**: Estrutura principal da aplicação.
* **Entity Framework Core**: ORM para persistência de dados.
* **SQL Server**: Banco de dados relacional.
* **Bootstrap**: Interface responsiva e estilizada.

## 📁 Estrutura do Projeto

```
trilha-net-api-mvc-desafio/
├── 📂 Context/
│   └── 📄 OrganizadorContext.cs       
├── 📂 Controllers/
│   ├── 📄 HomeController.cs           
│   └── 📄 TarefaController.cs         
├── 📂 Migrations/                     
├── 📂 Models/
│   ├── 📂 Entities/
│   │   ├── 📄 EnumStatusTarefa.cs     
│   │   └── 📄 Tarefa.cs               
│   └── 📄 ErrorViewModel.cs           
├── 📂 Properties/
│   └── 📄 launchSettings.json         
├── 📂 Views/
│   ├── 📂 Home/                       
│   ├── 📂 Shared/                     
│   ├── 📂 Tarefa/                     
│   │   ├── 📄 Adicionar.cshtml        
│   │   ├── 📄 Deletar.cshtml          
│   │   ├── 📄 Editar.cshtml           
│   │   └── 📄 Index.cshtml            
│   ├── 📄 _ViewImports.cshtml         
│   └── 📄 _ViewStart.cshtml           
├── 📂 wwwroot/                        
├── 📄 appsettings.json                
├── 📄 Program.cs                      
├── 📄 trilha-net-api-mvc-desafio.csproj 
└── 📄 trilha-net-api-mvc-desafio.sln    
```

## 🛠️ Funcionalidades Detalhadas

### 1. Gestão de Tarefas (CRUD)
* **Listagem**: Visualiza todas as tarefas registadas na base de dados.
* **Criação**: Adiciona uma nova tarefa com Título, Descrição, Data e Status (Pendente ou Finalizado).
* **Edição**: Permite atualizar as informações de uma tarefa existente.
* **Exclusão**: Remove tarefas do sistema.

### 2. Sistema de Busca Avançada
A aplicação possui um método de busca inteligente no `TarefaController` que interpreta a entrada do utilizador:
* **Por Status**: Digitar "pendente" ou "finalizado" filtra automaticamente as tarefas.
* **Por Data**: Se o sistema detetar um formato de data, filtra tarefas agendadas para esse dia específico.
* **Por Título**: Caso não seja status nem data, o sistema procura por partes do título da tarefa.

## ⚙️ Como Configurar o Ambiente

### 1. Requisitos
* .NET 6.0 SDK ou superior.
* SQL Server (LocalDB ou Express).

### 2. Base de Dados
A aplicação está configurada para utilizar o SQL Server Local. A string de conexão padrão é:
`Server=localhost\sqlexpress; Initial Catalog=Tarefa; Integrated Security=True;`

Para criar o banco de dados, execute os seguintes comandos no Console do Gestor de Pacotes (Package Manager Console):
```bash
dotnet ef database update
```

### 3. Execução
Para iniciar a aplicação, utilize o comando:
```bash
dotnet run
```
A aplicação será aberta no navegador, por padrão na rota da `HomeController`, mas pode aceder diretamente ao gerenciador em `/Tarefa/Index`.

## 🔗 Endpoints e Rotas

| Ação | Rota | Descrição |
| :--- | :--- | :--- |
| Index | `/Tarefa` | Lista todas as tarefas. |
| Buscar | `/Tarefa/Buscar?busca={termo}` | Filtra tarefas por texto, data ou status. |
| Adicionar | `/Tarefa/Adicionar` | Formulário de criação (GET/POST). |
| Editar | `/Tarefa/Editar/{id}` | Edição de uma tarefa específica. |
| Deletar | `/Tarefa/Deletar/{id}` | Confirmação de exclusão. |

##
*Este projeto faz parte de um desafio técnico para demonstrar competências em desenvolvimento ASP.NET MVC e Entity Framework.*

---
<div align="center">
  
  **Obrigado pela visita!**  
  [Kenzo Friás](https://www.github.com/kenzofrias) © 2026
  
</div>
