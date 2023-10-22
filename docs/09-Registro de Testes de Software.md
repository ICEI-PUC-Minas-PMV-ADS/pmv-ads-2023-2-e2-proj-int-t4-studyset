# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

# CT a serem avaliados

| :---	|
| CT-001: Cadastro de acesso do usuário |
| CT-002: Login e recuperação de senha	|
| CT-003: Gerenciamento de datas |
| CT-004: Restrição no cadastro de cronograma |
| CT-005:  Cadastro de metas |
| CT-006:  Notificações de metas |
| CT-007:  Visualização de progresso |


As abordagens escolhidas serão:
| :---	|
CT-001: Funcional
CT-002: Funcional
CT-003: Caso de uso

| **Caso de Teste**| **CT-001: Cadastro de acesso do usuário** |
| :--- | :---: |
| Pré-condições | Estar na tela Homepage |
| Procedimentos (passo à passo) | 1. Acessar a página de cadastro a partir da homepage do site <br> 2. Preencher os dados do formulário seguindo as respectivas validações <br> 3. Submeter o cadastro |
| Dados de entrada | Inserir Nome: Leo, E-mail: teste@gmail.com (Email já foi cadastrado) e Senha: 1234|
| Resultado esperado | Aviso de erro: "Este email já foi cadastrado" |
| Avaliação (pegou/ não pegou erro) | O programa foi capaz de identificar o erro |
| Evidência (print screen) | ![erro de cadastro loign](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t4-studyset/assets/129237541/3f626bb1-8903-4620-8a64-02c543efde81) |

| **Caso de Teste** | **CT-002: Login e recuperação de senha** |
| :--- | :---: |
| Pré-condições | Estar na tela de Homepage |
| Procedimentos (passo à passo) | 1. Acessar a Homepage e procurar botão de login <br> 2. Inserir e-mail e senha do usuário|
| Dados de entrada | E-mail: Teste@gmail.com, senha: 1234 (senha verdadeira: 1235) |
| Resultado esperado | Aviso de erro: Usuário ou senha inválido |
| Avaliação (pegou/ não pegou erro) | |
| Evidência (print screen) | |

| **Caso de Teste**| **CT-003: Gerenciamento de datas** |
| :--- | :---: |
| Pré-condições| Acessar tela Agenda|
| Procedimentos (passo à passo) | 1. Acessar Homepage <br> 2. Inserir e-mail e senha do usuário <br> 3. Na aba perfil selecionar "Agenda" <br> 4. Clicar no botão "Adicionar novo evento"|
| Resultado esperado | |
| Evidência (print screen) |  |


## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
