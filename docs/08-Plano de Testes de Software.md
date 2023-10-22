# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>
<div align="justify">
 
Nesta seção são apresentados os cenários de testes utilizados na realização dos testes da aplicação. Os cenários de testes foram escolhidos de forma que demonstrem os requisitos sendo satisfeitos.

</div>
 
| **Caso de Teste** 	| **CT-001: Cadastro de acesso do usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001: O sistema deve permitir login de usuário |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar o cadastro no site |
| Passos 	| 1. Acessar a página de cadastro a partir da homepage do site <br> 2. Preencher os dados do formulário seguindo as respectivas validações <br> 3. Submeter o cadastro|
|Critério de Êxito | - Os campos do formulário devem validar as informações inseridas (nome, e-mail, senha e tempo de estudo disponível) <br> - A conta deve ser criada com êxito |
|  	|  	|
|   |   |
| Caso de Teste 	| CT-002: Recuperação de senha	|
|Requisito Associado | RF-002: O sistema deve permitir a recuperação de senha através de e-mail |
| Objetivo do Teste 	| Verificar se o usuário consegue recuperar a senha |
| Passos 	| 1. Acessar a página de login <br> 2. Clicar em recuperar senha <br> 3. Inserir e-mail do usuário <br> 4. Acessar a caixa de e-mail e verificar o recebimento do protocolo |
|Critério de Êxito | - O usuário deve receber via e-mail o protocolo de recuperação de senha <br> - A senha deve ser recuperada com êxito |
|  	|  	|
| Caso de Teste 	| CT-003: Gerenciamento de datas	|
|Requisito Associado | RF-003 O sistema deve permitir o controle e organização de datas no calendário |
| Objetivo do Teste 	| Verificar se o cadastro de datas na agenda está funcionando |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2. Adicionar novo evento <br> 3. Editar evento |
|Critério de Êxito | - O usuário deve conseguir cadastrar eventos em sua agenda <br> - O usuário deve conseguir editar e/ou apagar os eventos cadastrados. |
|  	|  	|
| Caso de Teste 	| CT-004: Restrição no cadastro de cronograma	|
|Requisito Associado | RF-004: O sistema não deve permitir que os conteúdos escolhidos para o cronograma se sobreponham ao número de horas de estudo estipuladas pelo usuário |
| Objetivo do Teste 	| Verificar se o sistema impede o cadastro de cronograma inadequado |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2. Cadastrar cronograma de estudos, adicionando conteúdos que se sobreponham ao tempo de estudo cadastrado pelo usuário <br> 3. Verificar se o sistema impede o cadastro e notifica o usuário da restrição |
|Critério de Êxito | - O sistema deve notificar o usuário da restrição e impedir o cadastro de cronograma inadequado |
|  	|  	|
| Caso de Teste 	| CT-005: Cadastro de metas	|
|Requisito Associado | RF-005: O sistema deve permitir o cadastro de metas de estudo |
| Objetivo do Teste 	| Verificar se o usuário consegue cadastrar suas metas de estudo |
| Passos 	| 1. Acessar os dados do usuário <br> 2. Cadastrar as metas de estudo |
|Critério de Êxito | - Ao editar seus dados no site, o usuário deve conseguir cadastrar metas de estudo com êxito |
|  	|  	|
| Caso de Teste 	| CT-006: Notificações de metas	|
|Requisito Associado | RF-006: O sistema deve gerar notificações das datas importantes e metas a serem cumpridas |
| Objetivo do Teste 	| Verificar se o usuário recebe notificações |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2.  Verificar se são mostradas notificações referentes aos eventos cadastrados, assim como às metas de estudo |
|Critério de Êxito | - O usuário deve visualizar as notificações na página de agenda |
|  	|  	|
| Caso de Teste 	| CT-007:  Visualização de progresso	|
|Requisito Associado | RF-007: O sistema deve gerar relatório mostrando a porcentagem para conclusão de metas de estudos e dados sobre o tempo estudado |
| Objetivo do Teste 	| Verificar se o sistema mostra ao usuário seu andamento com relação às metas cadastradas |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2. Verificar se o sistema mostra o andamento do usuário com relação às metas cadastradas |
|Critério de Êxito | - O andamento deve estar em local visível ao usuário <br> - O andamento deve corresponder corretamente às metas e às sessões de estudo cadastradas |

<!--
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
-->
