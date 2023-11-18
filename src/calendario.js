const currentDate = document.querySelector(".current-date"),
daysTag = document.querySelector(".days"),
prevNextIcon = document.querySelectorAll(".icons span")

// getting new date, current year and month
let date = new Date(),
currYear = date.getFullYear(),
currMonth = date.getMonth();

const months = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];


const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting fist day of month 
    lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
    lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), //getting last day of month
    lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
    let liTag = "";

    for (let i = firstDayofMonth; i > 0; i--) {  // creating li of previous month last days
        liTag += `<li class="inactive">${lastDateofLastMonth - i +1}</li>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) {  // creating li of all days of current month
        // adding active class to li if current day, month, and year matched
let isToday = i === date.getDate() && currMonth === new Date().getMonth() && currYear === new Date().getFullYear ? "active" : "";

        liTag += `<li class ="${isToday}">${i}</li>`;
    }

    for (let i = lastDateofMonth; i < 6; i++) {  // creating li of next month firt days
        liTag.innerHTML = liTag;
    }

    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    daysTag.innerHTML = liTag;
}
renderCalendar();

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () =>{ //adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if(currMonth < 0 || currMonth > 11) {  // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
           date = new Date(currYear, currMonth);
           currYear = date.getFullYear(); // updating current year with new date year
           currMonth = date.getMonth(); // upadating current month with new date month
        } else{ //else pass new Date as date value
            date = new Date();
        }
        renderCalendar();
    });
});

// Cronograma
const notes = document.querySelectorAll('.note');

  notes.forEach(note => {
    note.addEventListener('input', function () {
      const maxWords = parseInt(this.getAttribute('data-max-words'), 10);
      const words = this.innerText.split(/\s+/).filter(word => word !== '');
      if (words.length > maxWords) {
        this.innerText = words.slice(0, maxWords).join(' ');
      }
    });
  });

//   Final do Calendario









const formCursos = document.querySelector("#qualificacoes");
const btnSalvarCurso = document.querySelector("#btnSalvarCurso");
//const editarCardBtn = listaQualificacoes.querySelector("#editarCardBtn");
const divContainerQualific = document.querySelector("#containerQualificacoes");

const formExp = document.querySelector("#experiencias");
const btnSalvarXp = formExp.querySelector("#btnSalvarXp");

const formInfUser = document.querySelector("#formInfBasica");
const btnSalvarUser = formInfUser.querySelector("#salvarUser");

function verificarCamposVazios(formulario) {
  // Obtém todos os campos do formulário
  const campos = formulario.querySelectorAll("input, select, textarea");

  // Percorre todos os campos e verifica se estão vazios
  for (let i = 0; i < campos.length; i++) {
    const campo = campos[i];

    // Verifica se o campo está vazio
    if (campo.value.trim() === "") {
      // Campo vazio encontrado, retorna true
      return true;
    }
  }

  // Todos os campos estão preenchidos, retorna false
  return false;
}

function salvarFormularioNoLocalStorage(formulario, id) {
  // Obtém todos os elementos do formulário
  var elementos = formulario.elements;

  // Cria um objeto para armazenar os dados do formulário
  var dadosFormulario = {};

  // Itera sobre os elementos do formulário
  for (var i = 0; i < elementos.length; i++) {
    var elemento = elementos[i];

    // Verifica se o elemento tem um nome e um valor
    if (elemento.name && elemento.value) {
      // Adiciona o valor do elemento ao objeto de dados do formulário
      dadosFormulario[elemento.name] = elemento.value;
    }
  }

  // Obtém os dados existentes no Local Storage para o ID fornecido
  var dadosSalvos = localStorage.getItem(id);

  // Se houver dados salvos no Local Storage
  if (dadosSalvos) {
    // Converte os dados salvos em um array JavaScript
    var arrayDadosSalvos = JSON.parse(dadosSalvos);

    // Adiciona os novos dados ao array existente
    arrayDadosSalvos.push(dadosFormulario);

    // Atualiza os dados salvos no Local Storage para o ID fornecido
    localStorage.setItem(id, JSON.stringify(arrayDadosSalvos));
  } else {
    // Se não houver dados salvos no Local Storage para o ID fornecido, cria um novo array com os dados do formulário
    var novoArrayDados = [dadosFormulario];

    // Salva os dados no Local Storage para o ID fornecido
    localStorage.setItem(id, JSON.stringify(novoArrayDados));
  }
}

// function criarPopUpEditar() {
//   // Cria a div popUpEditar
//   var divPopUpEditar = document.createElement("div");
//   divPopUpEditar.setAttribute("class", "popUpEditar");
//   divPopUpEditar.setAttribute("id", "popUpEditar");

//   // Cria o título "Editar Qualificação"
//   var tituloEditarQualificacao = document.createElement("h2");
//   tituloEditarQualificacao.innerText = "Editar Qualificação";

//   // Cria o formulário formEditarQualificacao
//   var formEditarQualificacao = document.createElement("form");
//   formEditarQualificacao.setAttribute("id", "formEditarQualificacao");
//   formEditarQualificacao.setAttribute("class", "formContainerGrande fo");

//   // Cria os elementos do formulário
//   var labels = ["Início do Curso:", "Fim do Curso:", "Instituição:", "Nome do Curso:", "Tipo de Curso:", "Área do Curso:"];
//   var inputIds = ["inicioCurso", "fimCurso", "nomeInstituicao", "nomeCurso", "tipoCurso", "areaCurso"];

//   for (var i = 0; i < labels.length; i++) {
//     var divElement = document.createElement("div");
//     var labelElement = document.createElement("label");
//     var inputElement = document.createElement("input");

//     labelElement.setAttribute("for", inputIds[i]);
//     labelElement.setAttribute("class", "labels");
//     labelElement.innerText = labels[i];

//     inputElement.setAttribute("type", "text");
//     inputElement.setAttribute("id", inputIds[i]);
//     inputElement.setAttribute("name", inputIds[i]);
//     inputElement.setAttribute("class", "inputText inputData");
//     inputElement.setAttribute("required", "required");

//     divElement.appendChild(labelElement);
//     divElement.appendChild(inputElement);
//     formEditarQualificacao.appendChild(divElement);
//   }

//   // Cria os botões "Salvar" e "Cancelar"
//   var divGroupBtn = document.createElement("div");
//   divGroupBtn.setAttribute("class", "groupBtn");

//   var btnSalvarEditar = document.createElement("button");
//   btnSalvarEditar.setAttribute("type", "submit");
//   btnSalvarEditar.setAttribute("id", "btnSalvarEditar");
//   btnSalvarEditar.innerText = "Salvar";

//   var btnCancelarEditar = document.createElement("button");
//   btnCancelarEditar.setAttribute("type", "button");
//   btnCancelarEditar.setAttribute("id", "btnCancelarEditar");
//   btnCancelarEditar.innerText = "Cancelar";

//   divGroupBtn.appendChild(btnSalvarEditar);
//   divGroupBtn.appendChild(btnCancelarEditar);

//   formEditarQualificacao.appendChild(divGroupBtn);

//   // Adiciona os elementos à div popUpEditar
//   divPopUpEditar.appendChild(tituloEditarQualificacao);
//   divPopUpEditar.appendChild(formEditarQualificacao);

//   return divPopUpEditar;
// }

function criaEstruturaCardCursos() {
  let divContainerCard = document.createElement("div");
  divContainerCard.setAttribute("id", "cardCurso");

  let tituloCurso = document.createElement("h2");
  tituloCurso.setAttribute("class", "titulosH3");

  let ulDados = document.createElement("ul");
  let liInicio = document.createElement("li");
  liInicio.setAttribute("id", "inicio");
  let liFim = document.createElement("li");
  liFim.setAttribute("id", "fim");
  let liInstituicao = document.createElement("li");
  liInstituicao.setAttribute("id", "instituicao");
  let liTipoCurso = document.createElement("li");
  liTipoCurso.setAttribute("id", "tipoCurso");
  let liArea = document.createElement("li");
  liArea.setAttribute("id", "area");

  let grupoBotao = document.createElement("div");
  grupoBotao.setAttribute("class", "btnArea");
  grupoBotao.setAttribute("class", "groupBtn");
  grupoBotao.setAttribute("id", "btnArea");

  let botaoExcluir = document.createElement("button");
  botaoExcluir.setAttribute("type", "submit");
  botaoExcluir.setAttribute("class", "formBtn");
  botaoExcluir.innerText = "excluir";

  ulDados.appendChild(liInicio);
  ulDados.appendChild(liFim);
  ulDados.appendChild(liTipoCurso);
  ulDados.appendChild(liInstituicao);
  ulDados.appendChild(liTipoCurso);
  ulDados.appendChild(liArea);

  grupoBotao.appendChild(botaoExcluir);

  divContainerCard.appendChild(tituloCurso);
  divContainerCard.appendChild(ulDados);
  divContainerCard.appendChild(grupoBotao);

  botaoExcluir.addEventListener("click", function (e) {
    let divGroupBtn = botaoExcluir.parentNode;
    let divCardCurso = divGroupBtn.parentNode;
    removeCardLocalStorage(divCardCurso, "qualificacoes");
    divCardCurso.remove();
  });

  return divContainerCard;
}

function addDadosEstruturaCardCursos(chave) {
  let dados = JSON.parse(localStorage.getItem(chave));
  let cardsPreenchidos = [];

  for (i = 0; i < dados.length; i++) {
    let divContainerCard = criaEstruturaCardCursos();
    let tituloDiv = divContainerCard.querySelector("h2");
    let areaCurso = divContainerCard.querySelector("#area");
    let inicio = divContainerCard.querySelector("#inicio");
    let fim = divContainerCard.querySelector("#fim");
    let instituicao = divContainerCard.querySelector("#instituicao");
    let tipoCurso = divContainerCard.querySelector("#tipoCurso");

    tituloDiv.innerText = dados[i].nomeCurso;
    areaCurso.innerText = dados[i].areaCurso;
    tipoCurso.innerText = dados[i].tipoCurso;
    inicio.innerText = dados[i].inicioCurso;
    fim.innerText = dados[i].fimCurso;
    instituicao.innerText = dados[i].nomeInstituicao;

    cardsPreenchidos[i] = divContainerCard;
  }

  return cardsPreenchidos;
}

function insereCardsNaLista(conjuntoCards) {
  let listaQualificacoes = document.querySelector("#listaQualificacoes");

  for (let i = conjuntoCards.length - 1; i >= 0; i--) {
    listaQualificacoes.appendChild(conjuntoCards[i]);
  }
}

function removeCardLocalStorage(card, chave) {
  var id = chave;
  var dadosSalvos = localStorage.getItem(id);

  if (dadosSalvos) {
    var arrayDadosSalvos = JSON.parse(dadosSalvos);

    var tituloDiv = card.querySelector("h2").innerText;
    var areaCurso = card.querySelector("#area").innerText;
    var inicio = card.querySelector("#inicio").innerText;
    var fim = card.querySelector("#fim").innerText;
    var instituicao = card.querySelector("#instituicao").innerText;
    var tipoCurso = card.querySelector("#tipoCurso").innerText;

    var indiceCard = arrayDadosSalvos.findIndex(function (dados) {
      return (
        dados.nomeCurso === tituloDiv &&
        dados.areaCurso === areaCurso &&
        dados.inicioCurso === inicio &&
        dados.fimCurso === fim &&
        dados.nomeInstituicao === instituicao &&
        dados.tipoCurso === tipoCurso
      );
    });

    if (indiceCard !== -1) {
      arrayDadosSalvos.splice(indiceCard, 1);

      localStorage.setItem(id, JSON.stringify(arrayDadosSalvos));
    }
  }
}

function reloadParaAlvo(divId) {
  var elementoAlvo = document.getElementById(divId);

  if (elementoAlvo) {
    elementoAlvo.scrollIntoView({ behavior: "smooth", block: "start" });
    setTimeout(function () {
      location.reload();
    }, 100); // Tempo de espera para a rolagem antes de recarregar a página (500ms neste exemplo)
  }
}

function validarEmail(email) {
  // Expressão regular para verificar o formato do e-mail
  const formatoEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  return formatoEmail.test(email);
}

document.addEventListener("DOMContentLoaded", function (e) {
  let cardsPreenchidos = addDadosEstruturaCardCursos("qualificacoes");
  insereCardsNaLista(cardsPreenchidos);

  e.preventDefault();
});

//cria um card e insere na lista quando clicado o botao salvar do form
btnSalvarCurso.addEventListener("click", function (e) {
  if (verificarCamposVazios(formCursos)) {
    alert("você precisa preencher todos os campos!");
    reloadParaAlvo("containerQualificacoes");
  } else {
    let listaQualificacoes = document.querySelector("#listaQualificacoes");
    let divContainerCard = criaEstruturaCardCursos();

    let tituloDiv = divContainerCard.querySelector("h2");
    let areaCurso = divContainerCard.querySelector("#area");
    let inicio = divContainerCard.querySelector("#inicio");
    let fim = divContainerCard.querySelector("#fim");
    let instituicao = divContainerCard.querySelector("#instituicao");
    let tipoCurso = divContainerCard.querySelector("#tipoCurso");

    let inputNomeCurso = formCursos.querySelector("#nomeCurso");
    let inputAreaCurso = formCursos.querySelector("#areaCurso");
    let inputTipoCurso = formCursos.querySelector("#tipoCurso");
    let inputNomeInstituicao = formCursos.querySelector("#nomeInstituicao");
    let inputInicio = formCursos.querySelector("#inicioCurso");
    let inputFim = formCursos.querySelector("#fimCurso");

    tituloDiv.innerText = inputNomeCurso.value;
    areaCurso.innerText = inputAreaCurso.value;
    tipoCurso.innerText = inputTipoCurso.value;
    instituicao.innerText = inputNomeInstituicao.value;
    inicio.innerText = inputInicio.value;
    fim.innerText = inputFim.value;

    salvarFormularioNoLocalStorage(formCursos, "qualificacoes");
    listaQualificacoes.appendChild(divContainerCard);

    alert("Dados Salvos Com Sucesso!");
    reloadParaAlvo("containerQualificacoes");
  }
  //  e.preventDefault();
});

btnSalvarCurso.addEventListener("click", function (e) {
  e.preventDefault(); // Evita o comportamento padrão de recarregar a página
  reloadParaAlvo("containerQualificacoes");
});

function insereCardsNaListaExp(conjuntoCards) {
  let listaExp = document.querySelector("#listaDetalhes");

  for (let i = conjuntoCards.length - 1; i >= 0; i--) {
    listaExp.appendChild(conjuntoCards[i]);
  }
}

function addDadosEstruturaCardExp(chave) {
  let dados = JSON.parse(localStorage.getItem(chave));
  // console.log(dados);
  let cardsPreenchidos = [];

  for (i = 0; i < dados.length; i++) {
    let divContainerCard = criarEstruturaCardExp();

    let tituloExp = divContainerCard.querySelector("h2");
    let area = divContainerCard.querySelector("#areaAtuacao");
    let instituicao = divContainerCard.querySelector("#instituicaoAtuacao");
    let cargo = divContainerCard.querySelector("#cargoAtuacao");
    let descricao = divContainerCard.querySelector("#cargoAtuacao");
    let inicio = divContainerCard.querySelector("#inicioAtuacao");
    let fim = divContainerCard.querySelector("#fimAtuacao");

    tituloExp.innerText = dados[i].cargoAtuacao;
    area.innerText = dados[i].areaAtuacao;
    instituicao.innerText = dados[i].instituicaoAtuacao;
    cargo.innerText = dados[i].cargoAtuacao;
    descricao.innerText = dados[i].descricaoAtuacao;
    inicio.innerText = dados[i].inicioPeriodoAtuacao;
    fim.innerText = dados[i].fimPeriodoAtuacao;

    cardsPreenchidos[i] = divContainerCard;
  }

  return cardsPreenchidos;
}

document.addEventListener("DOMContentLoaded", function (e) {
  let cardsPreenchidos = addDadosEstruturaCardExp("experiencias");
  insereCardsNaListaExp(cardsPreenchidos);

  e.preventDefault();
});

function criarEstruturaCardExp() {
  let divContainerCard = document.createElement("div");
  divContainerCard.setAttribute("id", "cardExp");
  divContainerCard.setAttribute("class", "campoDetalhe");
  divContainerCard.setAttribute("class", "cardExp");

  let tituloExp = document.createElement("h2");
  tituloExp.setAttribute("class", "titulosH3");

  let ulDados = document.createElement("ul");

  let liArea = document.createElement("li");
  liArea.setAttribute("id", "areaAtuacao");

  let liInstituicao = document.createElement("li");
  liInstituicao.setAttribute("id", "instituicaoAtuacao");

  let liCargo = document.createElement("li");
  liCargo.setAttribute("id", "cargoAtuacao");

  let liDescricaoAtuacao = document.createElement("li");
  liDescricaoAtuacao.setAttribute("id", "descricaoAtuacao");

  let liInicio = document.createElement("li");
  liInicio.setAttribute("id", "inicioAtuacao");

  let liFim = document.createElement("li");
  liFim.setAttribute("id", "fimAtuacao");

  let grupoBotao = document.createElement("div");
  grupoBotao.setAttribute("class", "btnArea");
  grupoBotao.setAttribute("class", "groupBtn");
  grupoBotao.setAttribute("id", "btnArea");

  let botaoExcluir = document.createElement("button");
  botaoExcluir.setAttribute("type", "submit");
  botaoExcluir.setAttribute("class", "formBtn");
  botaoExcluir.innerText = "excluir";

  ulDados.appendChild(liArea);
  ulDados.appendChild(liInstituicao);
  ulDados.appendChild(liCargo);
  ulDados.appendChild(liDescricaoAtuacao);
  ulDados.appendChild(liInicio);
  ulDados.appendChild(liFim);

  grupoBotao.appendChild(botaoExcluir);
  divContainerCard.appendChild(tituloExp);
  divContainerCard.appendChild(ulDados);
  divContainerCard.appendChild(grupoBotao);

  botaoExcluir.addEventListener("click", function (e) {
    let divGroupBtn = botaoExcluir.parentNode;
    let divCardXp = divGroupBtn.parentNode;
    divCardXp.remove();
  });

  return divContainerCard;
}

btnSalvarXp.addEventListener("click", function (e) {
  if (verificarCamposVazios(formExp)) {
    alert("você precisa preencher todos os campos!");
    reloadParaAlvo("containerGrande");
  } else {
    let listaExp = document.querySelector("#listaDetalhes");
    let formExp = document.querySelector("#containerGrande");
    salvarFormularioNoLocalStorage(formExp, "containerGrande");

    let divContainerCard = criarEstruturaCardExp();
    let tituloDiv = divContainerCard.querySelector("h2");
    let areaExp = divContainerCard.querySelector("#cargoTitulo");
    let areaTipo = divContainerCard.querySelector("#campoRelevancia");
    let cargo = divContainerCard.querySelector("#cargoTitulo");
    // let descricao = divContainerCard.querySelector("#descricaoAtuacao");
    let inicioExp = divContainerCard.querySelector("#inicioAtuacao");
    // let fimExp = divContainerCard.querySelector("#fimAtuacao");

    let inputCargo = formExp.querySelector("#cargoTitulo");
    let inputcampoTitulo = formExp.querySelector("#cargoTitulo");
    let inputcampoRelevancia = formExp.querySelector("#campoRelevancia");
    // let inputDescricao = formExp.querySelector("#descricaoAtuacao");
    // let inputInicio = formExp.querySelector("#inicioPeriodoAtuacao");
    // let inputFim = formExp.querySelector("#fimPeriodoAtuacao");

    tituloDiv.innerText = inputCargo.value;
    areaExp.innerText = inputcampoTitulo.value;
    instituicao.innerText = inputInstituicao.value;
    cargo.innerText = inputCargo.value;
    // descricao.innerText = inputDescricao.value;
    inicioExp.innerText = inputInicio.value;
    fimExp.innerText = inputFim.value;

    listaExp.appendChild(divContainerCard);
    reloadParaAlvo("containerExperiencias");
    alert("dados salvos com sucesso");
  }

  e.preventDefault();
});

btnSalvarXp.addEventListener("click", function (e) {
  e.preventDefault(); // Evita o comportamento padrão de recarregar a página
  reloadParaAlvo("containerExperiencias");
});

btnSalvarUser.addEventListener("click", function (e) {
  let email = formInfUser.querySelector("#emailUsuario");

  if (verificarCamposVazios(formInfUser)) {
    alert("você precisa preencher todos os campos!");
    reloadParaAlvo("formInfBasica");
  } else if (validarEmail(email.value)) {
    salvarFormularioNoLocalStorage(formInfUser, "formUser");
    geraPerfilCompleto();
    alert("Dados Salvos Com Sucesso!");
    //reloadParaAlvo("formInfBasica");
  } else {
    alert("formato de email inválido!");
    //reloadParaAlvo("formInfBasica");
  }

  console.log(email.value);

  e.preventDefault();
});

function geraPerfilCompleto() {
  experiencias = JSON.parse(localStorage.getItem("experiencias"));
  let qualificacoes = [];
  qualificacoes = JSON.parse(localStorage.getItem("qualificacoes"));

  let perfilCompleto = {
    nome: formInfUser.querySelector("#nomeUsuario").value,
    email: formInfUser.querySelector("#emailUsuario").value,
    senha: formInfUser.querySelector("#senhaUsuario").value,
    tagUsuario: "Voluntário",
    biografia: formInfUser.querySelector("#textoBiografia").value,
    interesses: formInfUser.querySelector("#interesseUsuario").value,
    exp: experiencias,
    qualif: qualificacoes,
  };

  // Salvar perfilCompleto na localStorage
  localStorage.setItem("perfilCompleto", JSON.stringify(perfilCompleto));

  console.log(perfilCompleto);
}

// Selecionar o botão de salvar perfil pelo ID
let botaoSalvarPerfil = document.querySelector("#salvarPerfil");

// Adicionar o evento de clique ao botão
botaoSalvarPerfil.addEventListener("click", function () {
  geraPerfilCompleto();
  window.location.href = "paginaFormPerfilLog.html";
});







// document.addEventListener("containerGrande", function () {
//   // Adiciona um ouvinte de evento ao botão com o id "btnSalvarXp"
//   document.getElementById("btnSalvarXp").addEventListener("click", function (event) {
//       // Evita o comportamento padrão do formulário (recarregar a página)
//       event.preventDefault();

//       // Obtém os valores dos campos de entrada
//       var titulo = document.getElementById("Titulo").value;
//       var tipo = document.getElementById("areaTipo").value;
//       var relevancia = document.getElementById("campoRelevancia").value;

//       // Aqui você pode fazer o que quiser com os valores, por exemplo, imprimir no console
//       console.log("campoTitulo:", titulo);
//       console.log("campoTipo:", tipo);
//       console.log("campoRelevancia:", relevancia);
//   });
// });