# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="04-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="08-Plano de Testes de Software.md"> Plano de Testes de Software</a>

<div align="justify">
  
Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

</div>

| CT a serem avaliados: |
| :---	|
| CT-001: Cadastro e acesso de usuário |
| CT-002: Edição dos dados cadastrais do usuário	|
| CT-003: Recuperação de senha |
| CT-004: Gerenciamento de datas na agenda |
| CT-005:  Criação de cronograma semanal |
| CT-006:  Adequação do tempo de estudo no cronograma |
| CT-007:  Cadastro de meta de estudo |
| CT-008:  Realização de sessão de estudo |
| CT-009:  Notificação de eventos |
| CT-0010:  Visualização de progresso |

| **Caso de Teste**| **CT-001: Cadastro e acesso de usuário** |
| :--- | :---: |
| Pré-condições | Estar na  homepage |
| Procedimentos (passo à passo) | 1. Acessar a página de cadastro a partir da homepage do site <br> 2. Preencher os dados do formulário seguindo as respectivas validações <br> 3. Submeter o cadastro <br> 4. Deslogar após o cadastro <br> 5. Realizar o login com os dados cadastrados nas etapas anteriores |
| Dados de entrada | Inserir - Nome: Maria da Silva; E-mail: mariadasilva@gmail.com; Senha: S3nh@daMaria |
| Resultado esperado | Validação de dados; Cadastro e login bem sucedidos |
| Avaliação | O sistema validou os dados tanto no cadastro quanto login. Quando corretos, os dados permitiram cadastro e login bem sucedidos |
| Evidência | |

| **Caso de Teste** | **CT-002: Login e recuperação de senha** |
| :--- | :---: |
| Pré-condições | Estar na tela de Homepage |
| Procedimentos (passo à passo) | 1. Acessar a Homepage e procurar botão de login <br> 2. Inserir e-mail e senha do usuário|
| Dados de entrada | E-mail: Leonardojunio@gmail.com, senha: 1234 (senha verdadeira: 1235) |
| Resultado esperado | Aviso de erro: Usuário ou senha inválido |
| Avaliação (pegou/ não pegou erro) | EM PROCESSO|
| Evidência (print screen) | |

| **Caso de Teste**| **CT-003: Gerenciamento de datas** |
| :--- | :---: |
| Pré-condições| Acessar tela Agenda|
| Procedimentos (passo à passo) | 1. Acessar Homepage <br> 2. Inserir e-mail e senha do usuário <br> 3. Na aba perfil selecionar "Agenda" <br> 4. Clicar no botão "Adicionar novo evento"|
| Resultado esperado | EM PROCESSO|
| Evidência (print screen) |  |

| **Caso de Teste**| **CT-006: Sessões de estudo** |
| :--- | :---: |
| Pré-condições | Estar na tela de Sessão de estudo |
| Procedimentos (passo à passo) | 1. Acessar a página de sessões <br> 2. Ajustar os tempos de estudo/descanso da dessão <br> 3. Iniciar e parar a sessão de estudo <br> 4. Verificar se a sessão foi cadastrada no histórico |
| Dados de entrada | Tempo padrão (25-5 minutos); Inserir título: Sessão teste |
| Resultado esperado | "Sessão teste" aparece no histórico de sessões |
| Avaliação | O sistema foi capaz de executar a sessão de estudo e cadastrá-la no banco de dados |
| Evidência (print screen) | ![Realização da sessão](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t4-studyset/assets/129805332/72d21986-4285-48b1-8d4e-4117f991ec08) <br> ![Sessão cadastrada](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t4-studyset/assets/129805332/8148b204-4c11-4b56-a67c-1b20dfdc4ce6) |


## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
