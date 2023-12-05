// Importa a função getHistoricoData do arquivo historicoEventos.js
import { getHistoricoData } from './historicoEventos.js';

const currentDate = document.querySelector(".current-date"),
    daysTag = document.querySelector(".days"),
    prevNextIcon = document.querySelectorAll(".icons span");

// Função para obter o último dia do mês
const getLastDayOfMonth = (year, month) => new Date(year, month + 1, 0).getDate();

// Captura a data, mês e ano
let date = new Date(),
    currYear = date.getFullYear(),
    currMonth = date.getMonth();

const months = [
    "Janeiro",
    "Fevereiro",
    "Março",
    "Abril",
    "Maio",
    "Junho",
    "Julho",
    "Agosto",
    "Setembro",
    "Outubro",
    "Novembro",
    "Dezembro",
];

const renderCalendar = (eventDates) => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(),
        lastDateofMonth = getLastDayOfMonth(currYear, currMonth),
        liTag = "";

    let isEventDate;  // Declare a variável aqui

    for (let i = firstDayofMonth; i > 0; i--) {
        liTag += `<li class="inactive">${getLastDayOfMonth(currYear, currMonth - 1) - i + 1}</li>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) {
        let liClass = "";

        const currentDate = new Date(currYear, currMonth, i);
        const currentDateISO = currentDate.toISOString().split('T')[0];

        console.log('Current Date ISO:', currentDateISO);

        if (eventDates) {
            const eventDatesArray = Array.isArray(eventDates) ? eventDates : [];

            console.log('Event Dates:', eventDatesArray);
            console.log('Is Array:', Array.isArray(eventDatesArray));

            // Verifica se a data está presente nos eventos
            isEventDate = eventDatesArray.some((event) => {
                // Utiliza um método diferente para criar uma data do evento
                const eventDate = new Date(event.dataEvento);
                const eventDateISO = eventDate.toISOString().split('T')[0];
                return eventDateISO === currentDateISO;
            });

            console.log('Is Event Date:', isEventDate);
        } else {
            console.log('No Event Dates provided');
        }

        if (isEventDate) {
            liClass += " event";
        }

        if (currMonth === date.getMonth() && currYear === date.getFullYear() && i === date.getDate()) {
            liClass += " active";
        }

        liTag += `<li class="${liClass}">${i}</li>`;
    }

    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    daysTag.innerHTML = liTag;
};

const updateCalendar = async () => {
    console.log('Atualizando o calendário...');
    try {
        const eventDates = await getHistoricoData();
        console.log('Dados do histórico recebidos:', eventDates);
        renderCalendar(eventDates);
    } catch (error) {
        console.error('Erro ao atualizar o calendário:', error);
    }
};

updateCalendar();

prevNextIcon.forEach((icon) => {
    icon.addEventListener("click", () => {
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) {
            date = new Date(currYear, currMonth);
            currYear = date.getFullYear();
            currMonth = date.getMonth();
        } else {
            date = new Date(currYear, currMonth);
        }
        updateCalendar();
    });
});