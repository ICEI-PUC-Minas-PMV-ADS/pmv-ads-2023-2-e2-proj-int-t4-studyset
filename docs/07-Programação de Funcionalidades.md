# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="02-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="03-Projeto de Interface.md"> Projeto de Interface</a>, <a href="04-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="05-Arquitetura da Solução.md"> Arquitetura da Solução</a>

<div align="justify">

Nesta seção é descrita a implementação do sistema por meio dos requisitos funcionais e/ou não funcionais, relacionando os requisitos atendidos com os artefatos criados e apresentadando as instruções para acesso e verificação da implementação funcional no ambiente de hospedagem.

A tabela a seguir é ser preenchida com artefatos desenvolvidos. Cada artefato possui página (View) correspondente, que demonstra a funcionalidade implementada.

</div>

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-------------------------|--------------------------|
|RF-001| O sistema deve permitir cadastro e login de usuário. | Aluno.cs - Model; Register.cs e Login.cs - Controller/Identity |
|RF-002| O sistema deve permitir a edição dos dados cadastrais do usuário. | Aluno.cs - Model; Edit.cs e EditPassword.cs - Controller/Identity 
|RF-003| O sistema deve permitir a recuperação de senha. | |
|RF-004| O sistema deve permitir o controle e a organização de datas no calendário (eventos). | Evento.cs - Model; AgendaController.cs |
|RF-005| O sistema deve permitir a criação de cronograma semanal de estudos. | Cronograma.cs - Model; CronogramasController.cs |
|RF-006| 	O sistema deve adequar as atividades dos cronogramas ao número de horas de estudo estipulado pelo usuário. | Aluno.cs e Evento.cs - Model; AgendaController.cs, Register.cs e Edit.cs - Controller/Identity |
|RF-007| O sistema deve permitir o cadastro de metas de estudo. | Aluno.cs - Model; Register.cs e Login.cs - Controller/Identity |
|RF-008| 	O sistema deve permitir ao usuário realizar sessões de estudo com base no método pomodoro. | Sessao.cs - Model; SessoesController.cs |
|RF-009| O sistema deve gerar notificações das datas importantes e metas a serem cumpridas. | Evento.cs - Model; AgendaController.cs |
|RF-010| O sistema deve gerar relatório mostrando o andamento em relação às metas de estudo e dados sobre o tempo estudado. | Aluno.cs - Model; Edit.cshtml - Página e Controller/Identity; Sessao.cs - Model; SessoesController.cs; Layout.cshtml - Shared View |

# Instruções de acesso

A aplicação está disponível para acesso no link: https://studysetapp.azurewebsites.net/

O usuário deve fazer um cadastro para testar a aplicação. Após inserir os dados principais e realizar o cadastro, deve preencher na página "Meu Perfil" seu tempo disponível para estudo e sua meta de estudo, em horas. Por fim, pode utilizar as demais funcionalidades do site.
