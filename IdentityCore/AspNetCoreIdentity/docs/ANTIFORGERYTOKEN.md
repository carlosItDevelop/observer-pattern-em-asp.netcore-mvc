

## Prevenindo ataques CSRF no ASP.NET Core

> __Ataques CSRF__ s�o bem comuns, o CSRF est� listado como a 909� vulnerabilidade mais perigosa 
j� encontrada em um software e � de total responsabilidade do desenvolvedor evitar isto.

![Prevenindo ataques CSRF no ASP.NET Core](http://apimltools.com.br/itdeveloperimg/CRSF.png "Prevenindo ataques CSRF no ASP.NET Core")

> __CSRF__ significa __Cross-Site Request Forgery__ (Falsifica��o de solicita��o entre sites).

O CSRF explora a confian�a que um website tem do navegador do usu�rio. Portanto um ataque CSRF � baseado em transmitir um comando n�o autorizado atrav�s de um usu�rio que o site confia.

Cen�rio pr�tico de um ataque CSRF
Jo�o � administrador de um site de e-commerce e est� em seu ambiente de trabalho quando recebe um e-mail que oferece uma promo��o imperd�vel e ao visitar o site da promo��o existe um bot�o para ver mais detalhes, algo assim:

```HTML
<h1>N�o perca esta promo��o imperd�vel!</h1>

<form action="http://sitedojoao.com/admin/editar" method="post">
   <input type="hidden" name="Email" value="emaildojoaoadm@gmail.com" />
   <input type="hidden" name="Senha" value="senhaNovaDoHacker" />
   <input type="submit" value="Saiba Mais"/>
</form>
```

> Assim que Jo�o clica no bot�o um post altera a senha de administrador do site e como Jo�o � o pr�prio administrador e estava logado o site executa sua solicita��o de imediato. Foi tarde demais para evitar o ataque bem sucedido de um ex-funcion�rio que estava chateado com a empresa e conhecia a aplica��o.

Pode parecer Hollywoodiano demais, mas acontece bastante!

> __Como evitar o CSRF?__
Isto � de total responsabilidade do desenvolvedor, mas o ASP.NET MVC desde suas vers�es iniciais possui um filtro especial para evitar este tipo de ataque que � o ValidateAntiForgeryToken.

O exemplo abaixo mostra a implementa��o na Controller e na View:

```CSharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditAdmin(AdminModel account)
{
   // A��es para altera��o do Admin
}
```
---
```CSharp
<form action="/" method="post">
    @Html.AntiForgeryToken()
</form>

 @*
Ir� gerar algo assim no browser:
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkSldwD9CpLRyOtm6FiJB1Jr_F3FQJQDvhlHoLNJJrLA6zaMUmhjMsisu2D2tFkAiYgyWQawJk9vNm36sYP1esHOtamBEPvSk1_x--Sg8Ey2a-d9CV2zHVWIN9MVhvKHOSyKqdZFlYDVd69XYx-rOWPw3ilHGLN6K0Km-1p83jZzF0E4WU5OGg5ns2-m9Yw" />
*@
```

__PS__ � Apesar de ser permitido n�o � necess�rio declarar o AntiForgeryToken na View, pois toda View Razor � protegida automaticamente de CSRF e ser� gerado um input hidden com o �__RequestVerificationToken� a cada requisi��o.

__Como funciona o ValidateAntiForgeryToken?__
O token gerado na View � baseado no usu�rio logado e na sess�o do browser e � submetido via POST para a Controller que deve conter o atributo [ValidateAntiForgeryToken] declarado no m�todo.

Se o servidor recebe um token que n�o corresponde a identidade do usu�rio autenticado, a solicita��o ser� rejeitada. O token � exclusivo e imprevis�vel. O token tamb�m pode ser usado para garantir o sequenciamento adequado de uma s�rie de solicita��es (p�gina garantia 1 precede a p�gina 2 que precede a p�gina 3).

Se o filtro ValidateAntiForgeryToken estiver declarado o ataque que simulamos no cen�rio pr�tico n�o teria sido efetuado com sucesso, pois a aplica��o teria rejeitado o POST e retornado um erro 400 (Bad Request).

A OWASP (Open Web Application Security Project) recomenda que todo verbo POST, PUT e DELETE estejam protegidos deste tipo de ataque. (Esta implementa��o n�o se aplica no uso de APIs).

__Aplicando a prote��o contra o CSRF de forma global no ASP.NET Core__

� poss�vel que por um deslise o desenvolvedor esque�a de usar o ValidateAntiForgeryToken como atributo em seus m�todos, para evitar isto podemos usar a implementa��o a seguir no Startup.cs e deixar a valida��o de forma global

```CSharp
public class Startup  
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddMvc(options =>
    {
        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });
  }
}
```

> Assim n�o ser� mais necess�rio se preocupar com a implementa��o de prote��o do CSRF no c�digo e caso haja necessidade de ignorar a valida��o de CSRF basta usar o atributo [IgnoreAntiforgeryToken] no m�todo.

O filtro __AutoValidateAntiforgeryTokenAttribute__ utilizado no Startup.cs � inteligente e aplica as valida��es de CSRF apenas para verbos que modificam o estado de um registro (POST, PUT e DELETE)

PS � Os verbos GET, TRACE etc s�o idempotentes por natureza e n�o devem fazer uso de valida��o de CSRF.

__Resumindo:__
A preven��o de CSRF � apenas uma das preocupa��es de um desenvolvedor web, existem diversos outros tipos de ataques e eu recomendo que todo desenvolvedor tenha no m�nimo o conhecimento deles. Recomendo a leitura do guia OWASP para aplica��es .NET que resume os tipos, como funcionam e como se prevenir de cada um deles.

__Refer�ncia:__

- Site oficial do ASP.Net MVC
- Edi��o especial do Microsoft Regional Director, Pires, E.
