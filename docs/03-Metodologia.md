
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

A metodologia adotada para o desenvolvimento do StudySet será detalhada nesta seção, que contém abaixo a estrutura para gestão do código fonte, os processos, ferramentas e ambientes de trabalho utilizados pela equipe. 

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/) e a hospedagem do repositório feita no [Github](https://github.com).

O projeto segue a seguinte convenção para o nome de `branches`:

<!-- 
- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software 
!-->

- `main`: versão atual, estável testada do software, pronta para ser entregue ou implantada
- `dev`: versão em desenvolvimento do software, onde as funcionalidades são incorporadas e testadas continuamente
- `feature`: para cada nova funcionalidade, uma nova branch de feature é criada a partir da branch dev, seguindo o padrão de nomenclatura feature-nome

Quanto à gerência de `commits`, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: indica problemas em uma funcionalidade
- `enhancement`: melhorias em uma funcionalidade existente
- `feature`: adição de novas funcionalidades

<!--
> **Links Úteis**:
> - [Tutorial GitHub](https://guides.github.com/activities/hello-world/)
> - [Git e Github](https://www.youtube.com/playlist?list=PLHz_AreHm4dm7ZULPAmadvNhH6vk9oNZA)
>  - [Comparando fluxos de trabalho](https://www.atlassian.com/br/git/tutorials/comparing-workflows)
> - [Understanding the GitHub flow](https://guides.github.com/introduction/flow/)
> - [The gitflow workflow - in less than 5 mins](https://www.youtube.com/watch?v=1SXpE08hvGs)
!-->

## Gerenciamento de Projeto
O projeto adotará uma metodologia ágil, o Scrum.

### Divisão de Papéis

**Scrum Master:** Ana Beatriz Leite de Souza <br>
**Product Owner:** Ademir Colares Dos Santos Junior <br>
**Equipe de Desenvolvimento:** Israel Cunha Da Silva, Leonardo Júnio De Paula<br>
**Equipe de Design:** Jefferson Freitas Da Silva 

<!--
> **Links Úteis**:
> - [11 Passos Essenciais para Implantar Scrum no seu 
> Projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)
!-->

### Processo

O trabalho da equipe será dividido em sprints semanais para a execução das atividades de cada etapa, previstas no Backlog do projeto. Às segundas-feiras haverá o planejamento das ações a serem desenvolvidas na sprint e aos sábados será feita a entrega das atividades propostas. 

O projeto será gerenciado através do Github Projects, utilizando um board Kanban organizado da seguinte forma:

- **Backlog:** Atividades que devem ser realizadas na etapa correspondente do projeto, incluindo documentação e desenvolvimento da aplicação; 
- **To-do:** Lista das tarefas definidas previamente para a sprint, atualizada semanalmente; 
- **In progress:** Tarefas em andamento da sprint atual; 
- **Done:** Tarefas finalizadas. 

<!--
> **Links Úteis**:
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Sobre quadros de projeto](https://docs.github.com/pt/github/managing-your-work-on-github/about-project-boards)
> - [Como criar Backlogs no Github](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial Slack](https://slack.com/intl/en-br/)
!-->

### Ferramentas

As ferramentas empregadas no projeto são:

**Editor de código:** Visual Studio Code e Visual Studio 2022 <br>
**Ferramenta de comunicação**:  Teams <br>
**Ferramenta de desenho de telas e diagramas**: Figma
<!--
> **Possíveis Ferramentas que auxiliarão no gerenciamento**: 
> - [Slack](https://slack.com/)
> - [Github](https://github.com/)
!-->
