

## ASP.Net MVC – Cuidado com links de exclusão “Delete”:
### (Pode ser uma falha de segurança)

> __ASP.Net MVC – Ao expor informações de um banco de dados, cuidado com o link do tipo “Delete”, siga essa dica para evitar uma falha de segurança em seu site.__

- Vamos supor que em nosso site ASP.Net MVC possuímos uma controller “FuncionarioController”, essa controller é responsável pelos métodos de CRUD da sua entidade Funcionario relacionada ao seu banco de dados.

Como o seu ActionResult de exclusão deveria estar escrito? Vamos observar este exemplo:

![Segurança no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-1.png "Cuidados com a action Delete com Get")

> __Algo de estranho?__

Teoricamente está tudo certo, o código está validando se o ID existe mesmo e caso não exista o usuário será redirecionando para uma página de erro, assim evitando em exibir mensagens de erro do banco de dados.

Mas nesse código habita uma grande falha de segurança, o ActionResult Delete é um método Get, ou seja, pode ser chamado diretamente de uma URL. O que aconteceria se alguém mal intencionado digitasse no browser a seguinte URL:

```
www.meusite.com.br/Funcionario/Delete/1
```

> Provavelmente o registro de funcionário com o ID = 1 seria excluído certo?
“Ah, mas minha aplicação requer login e senha para esse tipo de ação.”

Isso não evita de receber um ataque, imagine que um usuário mal intencionado deseja deletar um registro e envia um e-mail para um usuário desse sistema com uma imagem “para parecer inofensivo” e nessa imagem contenha um link para a URL que citamos acima. Se o usuário que recebeu o e-mail e clicou estiver conectado (logado) no sistema naquele momento já seria o suficiente para concretizar a exploração dessa falha.

__DICA__

Nunca escreva seus métodos Get de exclusão realizando a exclusão __direta da base.__

__A dica completa seria:__
Nunca escreva nenhum método Get realizando alteração de informações do sistema.

> __Como resolver?__

Vamos observar uma maneira indicada para evitar a falha citada:

![Segurança no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-2.png "Cuidados com a action Delete com Get")

- Repare que existem dois métodos ActionResult para exclusão, o método Get Delete não realiza a exclusão do registro, apenas verifica se ele existe e redireciona o usuário para uma View de visualização e confirmação de exclusão:

![Segurança no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-3.png "Cuidados com a action Delete com Get")

Ao realizar a confirmação dos dados e clicar em excluir a página será submetida via Post para o método DeleteConfirmed, que é responsável pela exclusão da base de dados.

Repare no código que um método chama-se Delete (Get) e o outro DeleteConfirmed (Post), repare também que existe um atributo ActionName(“Delete”) decorando o método DeleteConfirmed, isso significa que ele pode ser chamado como Delete, isso é necessário, pois o CLR (common language runtime) do .Net requer que haja apenas um método com a mesma assinatura, como os dois métodos recebem o mesmo tipo de parâmetro não seria possível possuírem o mesmo nome.

Utilizando o atributo ActionName(“Delete”)  faz que o roteamento do site aceite o método DeleteConfirmed como Delete quando uma URL que inclua o /Delete/ for acionada via Post.

__Resumo:__

Essa técnica evita que de forma indesejável um registro seja manipulado e por mais que haja sucesso na tentativa do usuário mal intencionado o site resultará em uma página de confirmação, logo o usuário logado poderá intervir a essa tentativa de burlar o sistema.

Todas as controllers criadas automaticamente em projetos no Visual Studio, seja na criação do projeto ou via scaffolding já preveem essa técnica, caso você esteja criando suas controllers manualmente, lembre-se dessa dica. :) 

__Referência:__

- Site oficial do ASP.Net MVC
- Edição especial do Microsoft Regional Director, Pires, E.