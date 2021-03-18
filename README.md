# DesafioTechnos
Projeto feito para a seleção technos usando os seguintes componentes :
- AspNet Core
- Entity Framework Core
- AutoMapper
- Swashbuckle

1. Se quiser pode utilizar o Postman para testar as chamadas de API não se esquecendo de obter o token antes de se comunicar.
2. Não será possível comunicar-se com a Api sem usar o token do tipo "bearer" no headers (consulte o metodo GetToken() na documentação).
3. O projeto executa o Seed quando é iniciado pela primeira vez e será necessário criar a base de dados através do comando "update-database"
o banco de dados escolhido foi o SqlServer, não se esqueça de ajustar o connectionString em appsettings.
4. O projeto já vem com uma chamada do tipo $.ajax mostrando como é possível fazer o cadastro utilizando apenas javascript puro.
5. Em nenhum momento eu utilizo TagHelper (deixei o mais puro possível para uma melhor compreensão para quem não é de .NET).
6. Criei um cadastro na aplicação para mostrar de forma prática como é possível Cadastrar Produtos 
7. Não me preocupei com a interface visto que não faz parte do escopo.
8. O sistema cadastra e Lista Produtos, mas a Api só responde ao Cadastro de Produtos, porque é esse o requisito.


Muito obrigado a equipe da Technos por me divertir por algumas horas fazendo esse projeto.
