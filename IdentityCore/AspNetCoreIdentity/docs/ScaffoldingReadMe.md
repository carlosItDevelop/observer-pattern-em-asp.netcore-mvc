# Atenção na Implementação do Identity: __ScaffoldingReadMe__

### O suporte para o __Identity__ do ASP.NET foi adicionado ao seu projeto
> O código para adicionar o Identity ao seu projeto foi gerado em Areas/Identity.

- A configuração dos serviços relacionados ao Identity pode ser encontrada no arquivo Areas/Identity/IdentityHostingStartup.cs.
- Se seu aplicativo foi configurado anteriormente para usar o Identity, remova a chamada para o método AddIdentity do seu método ConfigureServices.
- A interface do usuário gerada requer suporte para arquivos estáticos. Para adicionar arquivos estáticos ao seu aplicativo:
	1. Chame app.UseStaticFiles() do seu método Configure

- Para usar a identidade principal do ASP.NET, você também precisa habilitar a autenticação. Para autenticação no seu aplicativo:
	1. Chame app.UseAuthentication() do seu método Configure (depois dos arquivos estáticos)

- A interface do usuário gerada requer MVC. Para adicionar o MVC ao seu aplicativo:
	1. Chame services.AddMvc() do seu método ConfigureServices
	2. Chame app.UseMvc() do seu método Configure (após autenticação)

- O código do banco de dados gerado requer migrações principais do Entity Framework. Execute os seguintes comandos:
	1. dotnet ef migrations add CreateIdentitySchema
	2. dotnet ef database update
	
- Ou no Package Manager Console do Visual Studio:
	1. Add-Migration CreateIdentitySchema
	2. Update-Database


---
- Os aplicativos que usam o ASP.NET Core Identity também devem usar HTTPS. 
	1. Para ativar o HTTPS **[Leia aqui](https://go.microsoft.com/fwlink/?linkid=848054)**.


