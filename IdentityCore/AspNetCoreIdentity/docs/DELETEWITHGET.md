

## ASP.Net MVC � Cuidado com links de exclus�o �Delete�:
### (Pode ser uma falha de seguran�a)

> __ASP.Net MVC � Ao expor informa��es de um banco de dados, cuidado com o link do tipo �Delete�, siga essa dica para evitar uma falha de seguran�a em seu site.__

- Vamos supor que em nosso site ASP.Net MVC possu�mos uma controller �FuncionarioController�, essa controller � respons�vel pelos m�todos de CRUD da sua entidade Funcionario relacionada ao seu banco de dados.

Como o seu ActionResult de exclus�o deveria estar escrito? Vamos observar este exemplo:

![Seguran�a no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-1.png "Cuidados com a action Delete com Get")

> __Algo de estranho?__

Teoricamente est� tudo certo, o c�digo est� validando se o ID existe mesmo e caso n�o exista o usu�rio ser� redirecionando para uma p�gina de erro, assim evitando em exibir mensagens de erro do banco de dados.

Mas nesse c�digo habita uma grande falha de seguran�a, o ActionResult Delete � um m�todo Get, ou seja, pode ser chamado diretamente de uma URL. O que aconteceria se algu�m mal intencionado digitasse no browser a seguinte URL:

```
www.meusite.com.br/Funcionario/Delete/1
```

> Provavelmente o registro de funcion�rio com o ID = 1 seria exclu�do certo?
�Ah, mas minha aplica��o requer login e senha para esse tipo de a��o.�

Isso n�o evita de receber um ataque, imagine que um usu�rio mal intencionado deseja deletar um registro e envia um e-mail para um usu�rio desse sistema com uma imagem �para parecer inofensivo� e nessa imagem contenha um link para a URL que citamos acima. Se o usu�rio que recebeu o e-mail e clicou estiver conectado (logado) no sistema naquele momento j� seria o suficiente para concretizar a explora��o dessa falha.

__DICA__

Nunca escreva seus m�todos Get de exclus�o realizando a exclus�o __direta da base.__

__A dica completa seria:__
Nunca escreva nenhum m�todo Get realizando altera��o de informa��es do sistema.

> __Como resolver?__

Vamos observar uma maneira indicada para evitar a falha citada:

![Seguran�a no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-2.png "Cuidados com a action Delete com Get")

- Repare que existem dois m�todos ActionResult para exclus�o, o m�todo Get Delete n�o realiza a exclus�o do registro, apenas verifica se ele existe e redireciona o usu�rio para uma View de visualiza��o e confirma��o de exclus�o:

![Seguran�a no Asp.Net Mvc](http://apimltools.com.br/itdeveloperimg/get-com-delete-3.png "Cuidados com a action Delete com Get")

Ao realizar a confirma��o dos dados e clicar em excluir a p�gina ser� submetida via Post para o m�todo DeleteConfirmed, que � respons�vel pela exclus�o da base de dados.

Repare no c�digo que um m�todo chama-se Delete (Get) e o outro DeleteConfirmed (Post), repare tamb�m que existe um atributo ActionName(�Delete�) decorando o m�todo DeleteConfirmed, isso significa que ele pode ser chamado como Delete, isso � necess�rio, pois o CLR (common language runtime) do .Net requer que haja apenas um m�todo com a mesma assinatura, como os dois m�todos recebem o mesmo tipo de par�metro n�o seria poss�vel possu�rem o mesmo nome.

Utilizando o atributo ActionName(�Delete�)  faz que o roteamento do site aceite o m�todo DeleteConfirmed como Delete quando uma URL que inclua o /Delete/ for acionada via Post.

__Resumo:__

Essa t�cnica evita que de forma indesej�vel um registro seja manipulado e por mais que haja sucesso na tentativa do usu�rio mal intencionado o site resultar� em uma p�gina de confirma��o, logo o usu�rio logado poder� intervir a essa tentativa de burlar o sistema.

Todas as controllers criadas automaticamente em projetos no Visual Studio, seja na cria��o do projeto ou via scaffolding j� preveem essa t�cnica, caso voc� esteja criando suas controllers manualmente, lembre-se dessa dica. :) 

__Refer�ncia:__

- Site oficial do ASP.Net MVC
- Edi��o especial do Microsoft Regional Director, Pires, E.