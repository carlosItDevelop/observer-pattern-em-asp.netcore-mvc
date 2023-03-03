

## Como evitar ataques de redirecionamento em ASP.NET Core


- Por José Luiz.
- Detalhes da matéria completa **[Leia aqui](https://joseluiz.net/como-evitar-ataques-de-redirecionamento-em-aspnet-core/)**.

---
![Evitando ataques de redirecionamento no ASP.NET Core](http://apimltools.com.br/itdeveloperimg/evitando-ataque-de-redirecionamento.png "Evitando ataques de redirecionamento no ASP.NET Core")

> Olá, tudo bem ? Neste post sobre segurança em .Net Core, vamos falar sobre o ataque de __redirecionamento aberto__, também muito comum a sistemas, vamos usar uma técnica *simples* para evitá-la.

Antes de mais nada: O Redirecionamento Aberto (do inglês open redirect) É um técnica que consiste em “enganar o usuário” afim de ele nos fornecer suas credenciais baseado em uma página web clonada.

Quando você acessa algum recurso no sistema que é protegido por autenticação, o sistema redireciona para a página de login, e após você informar seus dados de acesso o sistema redireciona novamente para a página de solicitada. É nesta confiança que este ataque se basea…



__Gravidade__
Bom, qualquer técnica de ataque aos nossos sistemas devem ser caracterizados como grave, não queremos nenhum invasor não é mesmo ? mas este tipo de ataque é gravíssimo pois podem expor informações sensíveis ao público e pior, pode demorar muito para percebermos a falha



__Caso prático__ para entender
Imagine que um usuário mal-intencionado cria uma página igual a página de login do seu sistema, para poder guardar as informações de login, e então ele monta um link e convence o usuário a clicar nele.


```
http://seusistema.com/protected/logon?returnurl=http://sistemahacker.com/protected/logon
```

> __Note que a url é do seu sistema__ mas ele redireciona para outro link!

1. usuário faz logon com êxito.
2. usuário é redirecionado (pelo site) para www.sistemahacker.com/protected/logon (site mal-intencionado que se parece com um site real).
3. usuário fizer logon novamente (fornecendo ao site suas credenciais do site) e é redirecionado para o site real.
4. usuário provavelmente vai achar sua primeira tentativa de logon falha, e sua segunda foi bem-sucedida e não irá perceber que as suas credenciais foram comprometidas.

Se você tem um redirecionamento aberto em sua aplicação, ela pode ser usada por este tipo de ataque, você já ouviu falar em Phishing ?

> __A Resolução__
Tenha em mente que: Ao desenvolver aplicativos, trate todos os dados fornecidos pelo usuário como não confiável.

Use o LocalRedirect que lançará uma exceção se uma URL local não for especificada. Caso contrário, ele se comporta exatamente como o Redirect.

```CSharp
public IActionResult Action(string redirectUrl)
{
    return LocalRedirect(redirectUrl);
}
```

- Use o __IsLocalUrl__ que impede que os usuários seja redirecionado para um site externo. Use este método para testar as URLs antes de redirecionar:

```CSharp
private IActionResult RedirectToLocal(string returnUrl)
{
    if (Url.IsLocalUrl(returnUrl))
    {
        return Redirect(returnUrl);
    }
    else
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
```

__Antes de partir__

- Registre os detalhes da URL que foi fornecida para redirecionamento externo, o log pode ajudar no diagnóstico de ataques de redirecionamento.
- Use autenticação de dois fatores sempre que posível.
- Se seu aplicativo redireciona o usuário com base no conteúdo da URL, certifique-se de que os redirecionamentos só são feitos localmente e não qualquer URL que pode ser fornecido na querystring.


__Resumindo:__

Proteger nosso sistema contra qualquer ataque é muito importante, tenha em mente que usuário mal-intencionado sempre estão em busca de novas técnicas, e cabe a você também aprimorar a segurança do seu sistema e da informação.


