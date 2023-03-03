

## Como evitar ataques de redirecionamento em ASP.NET Core


- Por Jos� Luiz.
- Detalhes da mat�ria completa **[Leia aqui](https://joseluiz.net/como-evitar-ataques-de-redirecionamento-em-aspnet-core/)**.

---
![Evitando ataques de redirecionamento no ASP.NET Core](http://apimltools.com.br/itdeveloperimg/evitando-ataque-de-redirecionamento.png "Evitando ataques de redirecionamento no ASP.NET Core")

> Ol�, tudo bem ? Neste post sobre seguran�a em .Net Core, vamos falar sobre o ataque de __redirecionamento aberto__, tamb�m muito comum a sistemas, vamos usar uma t�cnica *simples* para evit�-la.

Antes de mais nada: O Redirecionamento Aberto (do ingl�s open redirect) � um t�cnica que consiste em �enganar o usu�rio� afim de ele nos fornecer suas credenciais baseado em uma p�gina web clonada.

Quando voc� acessa algum recurso no sistema que � protegido por autentica��o, o sistema redireciona para a p�gina de login, e ap�s voc� informar seus dados de acesso o sistema redireciona novamente para a p�gina de solicitada. � nesta confian�a que este ataque se basea�



__Gravidade__
Bom, qualquer t�cnica de ataque aos nossos sistemas devem ser caracterizados como grave, n�o queremos nenhum invasor n�o � mesmo ? mas este tipo de ataque � grav�ssimo pois podem expor informa��es sens�veis ao p�blico e pior, pode demorar muito para percebermos a falha



__Caso pr�tico__ para entender
Imagine que um usu�rio mal-intencionado cria uma p�gina igual a p�gina de login do seu sistema, para poder guardar as informa��es de login, e ent�o ele monta um link e convence o usu�rio a clicar nele.


```
http://seusistema.com/protected/logon?returnurl=http://sistemahacker.com/protected/logon
```

> __Note que a url � do seu sistema__ mas ele redireciona para outro link!

1. usu�rio faz logon com �xito.
2. usu�rio � redirecionado (pelo site) para www.sistemahacker.com/protected/logon (site mal-intencionado que se parece com um site real).
3. usu�rio fizer logon novamente (fornecendo ao site suas credenciais do site) e � redirecionado para o site real.
4. usu�rio provavelmente vai achar sua primeira tentativa de logon falha, e sua segunda foi bem-sucedida e n�o ir� perceber que as suas credenciais foram comprometidas.

Se voc� tem um redirecionamento aberto em sua aplica��o, ela pode ser usada por este tipo de ataque, voc� j� ouviu falar em Phishing ?

> __A Resolu��o__
Tenha em mente que: Ao desenvolver aplicativos, trate todos os dados fornecidos pelo usu�rio como n�o confi�vel.

Use o LocalRedirect que lan�ar� uma exce��o se uma URL local n�o for especificada. Caso contr�rio, ele se comporta exatamente como o Redirect.

```CSharp
public IActionResult Action(string redirectUrl)
{
    return LocalRedirect(redirectUrl);
}
```

- Use o __IsLocalUrl__ que impede que os usu�rios seja redirecionado para um site externo. Use este m�todo para testar as URLs antes de redirecionar:

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

- Registre os detalhes da URL que foi fornecida para redirecionamento externo, o log pode ajudar no diagn�stico de ataques de redirecionamento.
- Use autentica��o de dois fatores sempre que pos�vel.
- Se seu aplicativo redireciona o usu�rio com base no conte�do da URL, certifique-se de que os redirecionamentos s� s�o feitos localmente e n�o qualquer URL que pode ser fornecido na querystring.


__Resumindo:__

Proteger nosso sistema contra qualquer ataque � muito importante, tenha em mente que usu�rio mal-intencionado sempre est�o em busca de novas t�cnicas, e cabe a voc� tamb�m aprimorar a seguran�a do seu sistema e da informa��o.


