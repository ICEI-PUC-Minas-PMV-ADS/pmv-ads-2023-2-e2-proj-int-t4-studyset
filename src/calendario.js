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








document.addEventListener("DOMContentLoaded", function() {
    // Seleciona os elementos do DOM
    const tituloInput = document.getElementById("Titulo");
    const tipoInput = document.getElementById("areaTipo");
    const relevanciaInput = document.getElementById("campoRelevancia");
    const listaDetalhes = document.getElementById("listaDetalhes");
    const btnSalvarXp = document.getElementById("btnSalvarXp");
    const btnLimpar = document.getElementById("btnLimpar");



// Verificar se esta certo
    // Carrega os dados do armazenamento local
    const eventosSalvos = JSON.parse(localStorage.getItem("eventos")) || [];

    // Adiciona detalhes dos eventos salvos à lista
    eventosSalvos.forEach(evento => {
        adicionarDetalhesEvento(evento.titulo, evento.tipo, evento.relevancia);
    });





    // Adiciona um ouvinte de evento para o botão "Salvar"
    btnSalvarXp.addEventListener("click", function(event) {
        event.preventDefault();

        // Obtém os valores dos campos
        const tituloValor = tituloInput.value;
        const tipoValor = tipoInput.value;
        const relevanciaValor = relevanciaInput.value;

        // Adiciona os detalhes do evento à lista
        adicionarDetalhesEvento(tituloValor, tipoValor, relevanciaValor);

        // Limpa os campos após salvar
        limparCampos();
    });

    // Adiciona um ouvinte de evento para o botão "Limpar"
    btnLimpar.addEventListener("click", function() {
        limparCampos();
    });

    // Função para adicionar detalhes do evento à lista
    function adicionarDetalhesEvento(titulo, tipo, relevancia) {
        const detalhesEvento = document.createElement("div");
        detalhesEvento.classList.add("detalhesEvento");

        const tituloEvento = document.createElement("h3");
        tituloEvento.textContent = "Título do evento: " + titulo;
        detalhesEvento.appendChild(tituloEvento);

        const tipoEvento = document.createElement("p");
        tipoEvento.textContent = "Tipo: " + tipo;
        detalhesEvento.appendChild(tipoEvento);

        const relevanciaEvento = document.createElement("p");
        relevanciaEvento.textContent = "Relevancia: " + relevancia;
        detalhesEvento.appendChild(relevanciaEvento);

        listaDetalhes.appendChild(detalhesEvento);
    }

    // Função para limpar os campos do formulário
    function limparCampos() {
        tituloInput.value = "";
        tipoInput.value = "";
        relevanciaInput.value = "";
    }



    // Verificar se esta certo
    
    // Função para excluir um evento da lista e do armazenamento local
    function excluirEvento(titulo) {
        const eventosSalvos = JSON.parse(localStorage.getItem("eventos")) || [];
        const eventosAtualizados = eventosSalvos.filter(evento => evento.titulo !== titulo);
        localStorage.setItem("eventos", JSON.stringify(eventosAtualizados));
    
        // Remove o evento da lista
        const detalhesEvento = document.querySelector(`.detalhesEvento h3:contains('${titulo}')`).parentElement;
        detalhesEvento.remove();
    }
    
    // Função auxiliar para verificar se um elemento contém um determinado texto
    jQuery.expr[':'].contains = function(a, i, m) {
        return jQuery(a).text().toUpperCase()
            .indexOf(m[3].toUpperCase()) >= 0;
    };
});