

## Prevenindo ataques CSRF no ASP.NET Core

> __Ataques CSRF__ são bem comuns, o CSRF está listado como a 909° vulnerabilidade mais perigosa 
já encontrada em um software e é de total responsabilidade do desenvolvedor evitar isto.

![Prevenindo ataques CSRF no ASP.NET Core](http://apimltools.com.br/itdeveloperimg/CRSF.png "Prevenindo ataques CSRF no ASP.NET Core")

> __CSRF__ significa __Cross-Site Request Forgery__ (Falsificação de solicitação entre sites).

O CSRF explora a confiança que um website tem do navegador do usuário. Portanto um ataque CSRF é baseado em transmitir um comando não autorizado através de um usuário que o site confia.

Cenário prático de um ataque CSRF
João é administrador de um site de e-commerce e está em seu ambiente de trabalho quando recebe um e-mail que oferece uma promoção imperdível e ao visitar o site da promoção existe um botão para ver mais detalhes, algo assim:

```HTML
<h1>Não perca esta promoção imperdível!</h1>

<form action="http://sitedojoao.com/admin/editar" method="post">
   <input type="hidden" name="Email" value="emaildojoaoadm@gmail.com" />
   <input type="hidden" name="Senha" value="senhaNovaDoHacker" />
   <input type="submit" value="Saiba Mais"/>
</form>
```

> Assim que João clica no botão um post altera a senha de administrador do site e como João é o próprio administrador e estava logado o site executa sua solicitação de imediato. Foi tarde demais para evitar o ataque bem sucedido de um ex-funcionário que estava chateado com a empresa e conhecia a aplicação.

Pode parecer Hollywoodiano demais, mas acontece bastante!

> __Como evitar o CSRF?__
Isto é de total responsabilidade do desenvolvedor, mas o ASP.NET MVC desde suas versões iniciais possui um filtro especial para evitar este tipo de ataque que é o ValidateAntiForgeryToken.

O exemplo abaixo mostra a implementação na Controller e na View:

```CSharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditAdmin(AdminModel account)
{
   // Ações para alteração do Admin
}
```
---
```CSharp
<form action="/" method="post">
    @Html.AntiForgeryToken()
</form>

 @*
Irá gerar algo assim no browser:
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkSldwD9CpLRyOtm6FiJB1Jr_F3FQJQDvhlHoLNJJrLA6zaMUmhjMsisu2D2tFkAiYgyWQawJk9vNm36sYP1esHOtamBEPvSk1_x--Sg8Ey2a-d9CV2zHVWIN9MVhvKHOSyKqdZFlYDVd69XYx-rOWPw3ilHGLN6K0Km-1p83jZzF0E4WU5OGg5ns2-m9Yw" />
*@
```

__PS__ – Apesar de ser permitido não é necessário declarar o AntiForgeryToken na View, pois toda View Razor é protegida automaticamente de CSRF e será gerado um input hidden com o “__RequestVerificationToken” a cada requisição.

__Como funciona o ValidateAntiForgeryToken?__
O token gerado na View é baseado no usuário logado e na sessão do browser e é submetido via POST para a Controller que deve conter o atributo [ValidateAntiForgeryToken] declarado no método.

Se o servidor recebe um token que não corresponde a identidade do usuário autenticado, a solicitação será rejeitada. O token é exclusivo e imprevisível. O token também pode ser usado para garantir o sequenciamento adequado de uma série de solicitações (página garantia 1 precede a página 2 que precede a página 3).

Se o filtro ValidateAntiForgeryToken estiver declarado o ataque que simulamos no cenário prático não teria sido efetuado com sucesso, pois a aplicação teria rejeitado o POST e retornado um erro 400 (Bad Request).

A OWASP (Open Web Application Security Project) recomenda que todo verbo POST, PUT e DELETE estejam protegidos deste tipo de ataque. (Esta implementação não se aplica no uso de APIs).

__Aplicando a proteção contra o CSRF de forma global no ASP.NET Core__

É possível que por um deslise o desenvolvedor esqueça de usar o ValidateAntiForgeryToken como atributo em seus métodos, para evitar isto podemos usar a implementação a seguir no Startup.cs e deixar a validação de forma global

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

> Assim não será mais necessário se preocupar com a implementação de proteção do CSRF no código e caso haja necessidade de ignorar a validação de CSRF basta usar o atributo [IgnoreAntiforgeryToken] no método.

O filtro __AutoValidateAntiforgeryTokenAttribute__ utilizado no Startup.cs é inteligente e aplica as validações de CSRF apenas para verbos que modificam o estado de um registro (POST, PUT e DELETE)

PS – Os verbos GET, TRACE etc são idempotentes por natureza e não devem fazer uso de validação de CSRF.

__Resumindo:__
A prevenção de CSRF é apenas uma das preocupações de um desenvolvedor web, existem diversos outros tipos de ataques e eu recomendo que todo desenvolvedor tenha no mínimo o conhecimento deles. Recomendo a leitura do guia OWASP para aplicações .NET que resume os tipos, como funcionam e como se prevenir de cada um deles.

__Referência:__

- Site oficial do ASP.Net MVC
- Edição especial do Microsoft Regional Director, Pires, E.
