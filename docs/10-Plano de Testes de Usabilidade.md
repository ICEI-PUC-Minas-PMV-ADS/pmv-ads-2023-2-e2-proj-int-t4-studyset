# Plano de Testes de Usabilidade

<div align="justify">

Nesta seção são apresentados os casos de testes de usabilidade, que permitem avaliar a qualidade da interface com o usuário da aplicação interativa. Os testes foram desenhados com base em algumas das 10 heurísticas de Nielsen.

</div>

| Caso de Teste | **CT-001: Visibilidade do conteúdo das páginas** 	|
|:---:	|:---:	|
| Objetivo do Teste | Verificar se o design do site permite completa visibilidade do conteúdo das páginas, com tamanho de fonte legível e alto contrate entre cores |
| Passos | 1. Acessar o site <br> 2. Verificar em todas as páginas se o design está legível em termos de fontes, cores e ícones |
| Critério de Êxito | - Todo o conteúdo do site deve ser visível e legível |
|  	|  	|
| Caso de Teste | **CT-002: Consistência e padronização da navbar** 	|
| Objetivo do Teste | Verificar se o design da navbar está padronizado, com diferenciação para usuários logados |
| Passos | 1. Acessar o site <br> 2. Verificar em todas as páginas se o design está padronizado e se os links levam para as páginas corretas <br> 3. Realizar login de usuário <br> 4. Verificar se a navbar é alterada corretamente <br> 5. Verificar em todas as páginas se o design está padronizado e se os links levam para as páginas corretas |
| Critério de Êxito | - A navbar deve ser a mesma em todas as páginas do site e levar para os caminhos corretos <br> - Para usuários logados, o botão "login" deve ser substituído por "logout" e a mensagem de boas vindas deve conter o nome correto do usuário |
|  	|  	|
| Caso de Teste | **CT-003: Correspondência e reconhecimento de ações** |
| Objetivo do Teste | Verificar se as ações são dispostas no site de forma padrão e com iconografia adequada |
| Passos | 1. Acessar o site <br> 2. Verificar se a logo disposta no canto esquerdo da navbar leva à homepage <br> 3. Verificar se os links à direita da navbar permitem login/logout <br> 3. Verificar se o uso de iconografia na aplicação é compreensível a adequado às ações correspondentes |
| Critério de Êxito | - Os links na navbar devem seguir o padrão de aplicações web <br> - A iconografia utilizada na aplicação deve ser adequada às ações correspondentes (ex: para adicionar itens, botão "adicionar" ou ícone de "+"; para excluir, ícone de lixo ou "x") |
|  	|  	|
| Caso de Teste | **CT-004: Fluxo claro e facilitado entre as páginas** |
| Objetivo do Teste | Verificar se o fluxo é claro e se há disponível caminhos fáceis entre as páginas |
| Passos | 1. Acessar o site <br> 2. Seguir o fluxo na aplicação, verificando se é possível voltar às páginas anteriores e/ou acessar outras páginas <br> 3. Verificar se há na navbar link para todas as páginas <br> 4. Para usuários logados, verificar se o menu interno possui caminho para todas as funcionalidades da aplicação |
| Critério de Êxito | - Todas as páginas devem possuir retorno e/ou caminho para outras páginas <br> - Para usuários logados, o menu interno deve estar sempre disponível, fornecendo links para todas as funcionalidades |
|  	|  	|
| Caso de Teste | **CT-005: Flexibilidade de uso**	|
| Objetivo do Teste | Verificar se usuário consegue utilizar as funcionalidades com flexibilidade |
| Passos | 1. Realizar login de usuário <br> 2. Verificar se é permitido ao usuário personalizar seus dados conforme desejado (com exceção das restrições do sistema) <br> 3. Verificar se o usuário consegue utilizar as funcionalidades de forma independente e como desejar |
| Critério de Êxito | - O usuário deve conseguir personalizar os dados conforme o desejado (ex: dar títulos, editar datas, tipos e prioridades) <br> - O usuário deve conseguir excluir dados conforme o desejado <br> - O usuário deve conseguir utilizar apenas as funcionalidades que desejar, sem que seja obrigado a utilizar as demais |
|  	|  	|
| Caso de Teste | **CT-006: Prevenção de erros**	|
| Objetivo do Teste | Verificar se usuário recebe alertas antes de excluir dados salvos |
| Passos | 1. Realizar login de usuário <br> 2. Verificar em todas as funcionalidades se a aplicação emite alerta, pedindo ao usuário confirmação para excluir dados salvos (ex: deseja excluir este evento?) |
| Critério de Êxito | - Todas as funcionalidades devem emitir alerta, evitando que dados sejam apagados sem querer pelo usuário |
|  	|  	|
| Caso de Teste | **CT-007: Mensagens e alertas**	|
| Objetivo do Teste | Verificar se o usuário recebe mensagens e alertas quando realizar alguma ação inedequada |
| Passos | 1. Acessar o site <br> 2. Testar casos de erro no cadastro e login (formato de e-mail e senha inadequados, cadastro duplicado) <br> 3. Realizar login de usuário <br> 4. Testar casos de erro nas funcionalidades (ex: cadastro de meta maior que o tempo disponível; cadastro de evento, cronograma ou sessão sem os dados essenciais) |
| Critério de Êxito | - Todos os casos de erro devem ter mensagem e/ou alerta que indique ao usuário o motivo do erro e dê instruções para um uso correto da funcionalidade |
|  	|  	|
| Caso de Teste | **CT-008: Restrição de acesso às páginas**	|
| Objetivo do Teste | Verificar se as páginas possuem restrição de acesso quando necessário |
| Passos | 1. Acessar o site <br> 2. Tentar acessar as páginas de funcionalidade sem login de usuário <br> 3. Realizar login de usuário <br> 4. Verificar se a homepage é trocada para a página de agenda de usuário <br> 5. Tentar acessar as páginas de funcionalidades de usuários não logados (cadastro e login) |
| Critério de Êxito | - O usuário não deve conseguir visitar as páginas inequadas ao seu tipo de acesso (com ou sem login) |
|  	|  	|
| Caso de Teste | **CT-009: Acesso aos dados**	|
| Objetivo do Teste | Verificar se o usuário possui acesso correto aos seus próprios dados |
| Passos | 1. Acessar o site <br> 2. Realizar login de usuário <br> 3. Verificar na página de perfil se os dados estão corretos <br> 4. Verificar em todas as páginas se os dados exibidos correspondem ao uso do usuário e à página específica (ex: os eventos devem estar na página de agenda, o histórico de sessões na página de sessão de estudo etc.) |
| Critério de Êxito | - O usuário deve ter acesso correto aos próprios dados <br> - O usuário não deve ter acesso aos dados de outros usuários <br> - Os dados devem ser exibidos nas páginas correspondentes |
|  	|  	|
| Caso de Teste | **CT-010: Responsividade**	|
| Objetivo do Teste | Verificar se o site se adequa a diferentes tamanhos de tela, sem prejudicar a usabilidade |
| Passos | 1. Acessar o site <br> 2. Testar diferentes tamanhos de tela <br> 3. Verificar se todo o conteúdo do site continua visível <br> 4. Verificar se todas as funcionalidades continuam usáveis |
| Critério de Êxito | - O site deve se adequar esteticamente a diferentes tamanhos de tela <br> - Todo o conteúdo deve continuar visível <br> - O usuário deve conseguir navegar por todo o site e utilizar todas as funcionalidades independente do tamanho da tela |

<!--
Um plano de teste de usabilidade deverá conter: o detalhamento dos objetivos (em função dos requisitos levantados/implementados), dos critérios que serão utilizados para a seleção dos participantes, dos procedimentos a serem adotados pelos condutores de teste (por exemplo: os testes serão presenciais ou remotos? o método será observação direta, medição ou avaliação?), das tarefas a serem executadas, dos dados a serem coletados (quantidade de cliques, número de erros, tempo etc.), a ordem de execução das tarefas e das etapas da sessão de teste, recursos demandados, métricas coletadas etc.

Para cada voluntário do teste, é fundamental coletar e apresentar todos os dados/métricas previamente definidos, mas não se esqueça: atendendo à LGPD (Lei Geral de Proteção de Dados), nenhum dado sensível, que permita identificar o voluntário, deverá ser apresentado).

As referências abaixo irão auxiliá-lo na geração do artefato "Plano de Testes de Usabilidade".

> **Links Úteis**:
> - [Teste De Usabilidade: O Que É e Como Fazer Passo a Passo (neilpatel.com)](https://neilpatel.com/br/blog/teste-de-usabilidade/)
> - [Teste de usabilidade: tudo o que você precisa saber! | by Jon Vieira | Aela.io | Medium](https://medium.com/aela/teste-de-usabilidade-o-que-voc%C3%AA-precisa-saber-39a36343d9a6/)
> - [Planejando testes de usabilidade: o que (e o que não) fazer | iMasters](https://imasters.com.br/design-ux/planejando-testes-de-usabilidade-o-que-e-o-que-nao-fazer/)
> - [Ferramentas de Testes de Usabilidade](https://www.usability.gov/how-to-and-tools/resources/templates.html)
-->
