<h1 align="center">CastGroup WEB API</h1>

<h2>API Rest que permita realizar as operações CRUD (criar, recuperar/consultar, editar e excluir) de Cursos para turmas de formação do Cast group</h2>

<h2 align="center">Construção</h2>
    Principais frameworks/bibliotecas utilizados no projeto

    -.NET 5
    -Swagger
    -Entity Framework Core

   

<h2 align="center">Clone</h2>

```
C:\>git clone https://github.com/DouglasFam/CastGroup-Project.git
```

<h2 align="center">Executar</h2>
Abra o projeto com o Visual Studio 19.
aponte o Gerenciador de pacotes para a aplicação CastGroup.Infra.Data
execute o script:

```
update-database
```
Defina o <b>CastGroup.Api</b> como projeto principal e Pressione F5.


<h2 align="center">Database</h2>
A ConnectionString está setada para o localdb.


```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Hyperativadb;Trusted_Connection=True;MultipleActiveResultSets=True"
```        
<h2 align="center">Consumindo a API</h2>
Após executar o projeto, irá abrir a página 

``` 
https://localhost/swagger/index.html
``` 


