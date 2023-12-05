# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="02-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="03-Projeto de Interface.md"> Projeto de Interface</a>
<div align="justify">
 
Nesta seção são apresentados os cenários de testes utilizados na realização dos testes da aplicação. Os cenários de testes foram escolhidos de forma que demonstrem os requisitos sendo satisfeitos.

</div>
 
| **Caso de Teste** 	| **CT-001: Cadastro e acesso de usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001: O sistema deve permitir cadastro e login de usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar cadastro e login no site |
| Passos 	| 1. Acessar a página de cadastro a partir da homepage do site <br> 2. Preencher os dados do formulário seguindo as respectivas validações <br> 3. Submeter o cadastro <br> 4. Deslogar após o cadastro <br> 5. Realizar o login com os dados cadastrados nas etapas anteriores |
|Critério de Êxito | - Os campos do formulário de cadastro devem validar as informações inseridas (nome, e-mail e senha) <br> - A conta deve ser criada com êxito <br> - Os campos do formulário de login devem validar os dados inseridos (e-mail e senha) <br> - O login do usuário cadastrado deve ser realizado com êxito |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-002: Edição dos dados cadastrais do usuário**	|
|Requisito Associado | RF-002: O sistema deve permitir a edição dos dados cadastrais do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue editar seus dados após o cadastro |
| Passos 	| 1. Acessar a página de perfil do usuário <br> 2. Editar os dados de perfil (nome, tempo disponível e/ou meta de estudo) <br> 3. Acessar a página de edição de dados <br> 4. Editar e-mail e/ou senha do usuário |
|Critério de Êxito | - O formulário de edição de perfil deve validar os dados inseridos <br> - Os dados alterados devem ser salvos com êxito no perfil do usuário <br> - O formulário de edição de dados deve exigir confirmação de senha para alteração de e-mail e senha <br> - Os dados editados devem ser salvos com êxito |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-003: Recuperação de senha**	|
|Requisito Associado | RF-003 O sistema deve permitir a recuperação de senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue recuperar a senha |
| Passos 	| 1. Acessar a página de login <br> 2. Clicar em recuperar senha <br> 3. Inserir e-mail do usuário <br> 4. Verificar o recebimento do protocolo |
|Critério de Êxito | - O usuário deve receber o protocolo de recuperação de senha <br> - A senha deve ser recuperada com êxito |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-004: Gerenciamento de datas na agenda**	|
|Requisito Associado | RF-004 	O sistema deve permitir o controle e a organização de datas no calendário (eventos). |
| Objetivo do Teste 	| Verificar se o cadastro de eventos na agenda está funcionando |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2. Adicionar novo evento <br> 3. Verificar a inclusão do evento na lista <br> 4. Verificar a marcação das datas de eventos no calendário <br> 5. Deletar um evento cadastrado |
|Critério de Êxito | - O formulário de cadastro de eventos deve validar os dados inseridos <br> - O evento cadastrado deve aparecer na lista de eventos do usuário <br> - As datas com eventos devem aparecer em destaque no calendário <br> - O usuário deve conseguir deletar os eventos cadastrados. |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-005: Criação de cronograma semanal**	|
|Requisito Associado | O sistema deve permitir a criação de cronograma semanal de estudos. |
| Objetivo do Teste 	| Verificar se o usuário consegue cadastrar itens de cronograma |
| Passos 	| 1. Acessar a página de cronograma do usuário <br> 2. Cadastrar itens ao cronograma <br> 3. Verificar a inclusão dos itens no dia da semana correspondente <br> 4. Deletar um item de cronograma cadastrado |
|Critério de Êxito | - O item cadastrado deve aparecer no cronograma do dia da semana correspondente <br> - O usuário deve conseguir excluir os itens cadastrados. |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-006: Adequação do tempo de estudo no cronograma**	|
|Requisito Associado | RF-006: O sistema deve adequar as atividades dos cronogramas ao número de horas de estudo estipulado pelo usuário. |
| Objetivo do Teste 	| Verificar se o cronograma se adequa ao tempo de estudo cadastrado pelo usuário |
| Passos 	| 1. Verificar se o tempo disponível está cadastrado no perfil do usuário <br> 2. Acessar a página de cronograma do usuário <br> 3. Cadastrar itens de cronograma <br> 4. Verificar se a aplicação impede o cadastro de cronograma que se sobreponha ao tempo disponível para estudo |
|Critério de Êxito | - Ao tentar cadastrar cronograma que se sobreponha às horas estipuladas pelo usuário, o sistema deve impedir o cadastro e exibir mensagem de erro |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-007: Cadastro de meta de estudo**	|
|Requisito Associado | RF-007: O sistema deve permitir o cadastro de metas de estudo |
| Objetivo do Teste 	| Verificar se o usuário consegue cadastrar sua meta de estudo |
| Passos 	| 1. Acessar a página de perfil do usuário <br> 2. Inserir a meta de estudo |
|Critério de Êxito | - O sistema deve permitir o cadastro de meta de estudo <br> - O sistema deve impedir o cadastro de meta maior que o tempo disponível do usuário |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-008: Realização de sessão de estudo**	|
|Requisito Associado | RF-008: O sistema deve permitir ao usuário realizar sessões de estudo com base no método pomodoro. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar sessões de estudo |
| Passos 	| 1. Acessar a página de sessão de estudo do usuário <br> 2.  Ajustar o tempo de estudo e descanso no timer <br> 3. Inserir o título da sessão <br> 4. Iniciar a sessão <br> 5. Pausar a sessão <br> 6. Verificar se a sessão aparece no histórico |
|Critério de Êxito | - O usuário deve realizar sessão de estudos com o tempo escolhido <br> - A sessão realizada deve constar no histórico de sessões |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-009:  Notificação de eventos**	|
|Requisito Associado | RF-009: O sistema deve gerar notificações das datas importantes. |
| Objetivo do Teste 	| Verificar se o sistema mostra ao usuário os eventos próximos |
| Passos 	| 1. Acessar a página de agenda do usuário <br> 2. Verificar se as datas de eventos aparecem marcadas no calendário <br> 3. Verificar se os eventos são exibidos em lista com marcação do tipo e prioridade do evento |
|Critério de Êxito | - As datas com eventos cadastrados devem estar marcadas no calendário <br> - Os eventos devem ser exibidos na lista com marcação do tipo e prioridade |
|  	|  	|
|   |   |
| Caso de Teste 	| **CT-010:  Visualização de progresso**	|
|Requisito Associado | RF-010: O sistema deve gerar relatório mostrando o andamento em relação à meta de estudo e dados sobre o tempo estudado. |
| Objetivo do Teste 	| Verificar se o sistema retorna ao usuário dados sobre seu tempo disponível, meta de estudo e e tempo estudado |
| Passos 	| 1. Acessar qualquer página do usuário <br> 2. Verificar se são mostrados os dados em relação ao tempo disponível e meta de estudo em lugar acessível <br> 3. Acessar a página de sessão de estudo do usuário <br> 4. Verificar se é mostrado junto ao histórico geral a quantidade de tempo estudado no dia |
|Critério de Êxito | - Os dados devem aparecer em local visível ao usuário em todas as páginas <br> - O tempo estudado no dia deve ser calculado com base nas sessões realizadas e mostrado junto ao histórico |
