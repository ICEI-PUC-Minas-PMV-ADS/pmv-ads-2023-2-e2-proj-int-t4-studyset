document.addEventListener("DOMContentLoaded", function () {
var increaseButtons = document.querySelectorAll(".config-btn-mais");
var decreaseButtons = document.querySelectorAll(".config-btn-menos");
var startBtn = document.querySelector("#start");
var stopBtn = document.querySelector("#stop");
var sessionTimeBlock = document.querySelector("#tempoEstudo");
var breakTimeBlock = document.querySelector("#tempoDescanso");
var timeStatusBlock = document.querySelector("#timer");
var hoursSpan = document.querySelector("#horas");
var minSpan = document.querySelector("#minutos");
var secSpan = document.querySelector("#segundos");
var timerTypeName = document.querySelector("#timerTitulo");
var totalProgress = document.querySelector(".progressoTotal");
var secondsProgress = document.querySelector(".progressoSegundos");

var timer = ""; //below used for setInterval/clearInterval
var timerActive = false;
var timerType = "estudo"; //is then changed to break
var startTime = 1500; //start of the session: session time by default
var sessionTime = 1500; //default session time stored in seconds
var breakTime = 300; //default break time stored in seconds;
var currentTime = 1500; //time displayed on timer in seconds

function displayDefaultTime() {
  displayCurrentTime();
  sessionTimeBlock.innerHTML = displayMinutes(sessionTime) + " min";
  breakTimeBlock.innerHTML = displayMinutes(breakTime) + " min";
}

function handleTotalProgress(startTime, currentTime) {
  var progressColor = "";
  if (timerType === "estudo") {
    progressColor = "#267BCA"; 
    totalProgress.style.backgroundColor = "#267BCA"; 
  } else {
    progressColor = "#A8CAEA";
    totalProgress.style.backgroundColor = "#A8CAEA";
  }
  var timePassed = startTime - currentTime;
  var deg;
  if (timePassed < startTime / 2) {
    deg = 90 + (360 * timePassed) / startTime;
    totalProgress.style.backgroundImage =
      "linear-gradient(" +
      deg +
      "deg, transparent 50%, #303030 50%),linear-gradient(90deg, #303030 50%, transparent 50%)";
  } else if (timePassed >= startTime / 2) {
    deg = -90 + (360 * timePassed) / startTime;
    totalProgress.style.backgroundImage =
      "linear-gradient(" +
      deg +
      "deg, transparent 50%, " +
      progressColor +
      " 50%),linear-gradient(90deg, #303030 50%, transparent 50%)";
  }
}

function handleSecondsProgress(currentTime) {
  var progressBarColor = "";
  if (timerType === "estudo") {
    progressBarColor = "#A8CAEA";
    secondsProgress.style.backgroundColor = "#A8CAEA"; 
  } else {
    progressBarColor = "#267BCA";
    secondsProgress.style.backgroundColor = "#267BCA";
  }
  var secondsPassed = 60 - convertFromSec(currentTime).seconds;
  var deg;
  if (secondsPassed < 60 / 2) {
    deg = 90 + (360 * secondsPassed) / 60;
    secondsProgress.style.backgroundImage =
      "linear-gradient(" +
      deg +
      "deg, transparent 50%, #303030 50%),linear-gradient(90deg, #303030 50%, transparent 50%)";
  } else if (secondsPassed >= 60 / 2) {
    deg = -90 + (360 * secondsPassed) / 60;
    secondsProgress.style.backgroundImage =
      "linear-gradient(" +
      deg +
      "deg, transparent 50%, " +
      progressBarColor +
      " 50%),linear-gradient(90deg, #303030 50%, transparent 50%)";
  }
}

function displayCurrentTime() {
  if (convertFromSec(currentTime).hours) {
    hoursSpan.classList.remove("hidden");
    hoursSpan.innerHTML = convertFromSec(currentTime).hours + ": ";
  } else {
    hoursSpan.innerHTML = "";
  }
  minSpan.innerHTML = convertFromSec(currentTime).minutes + ": ";
  secSpan.innerHTML = convertFromSec(currentTime).seconds;
}

function addLeadingZero(time) {
  return time < 10 ? "0" + time : time;
}

function displayMinutes(timeInSec) {
  return parseInt(timeInSec / 60);
}

function convertFromSec(timeInSec) {
  var result = { hours: 0, minutes: 0, seconds: 0 };
  var seconds = timeInSec % 60;
  var minutes = parseInt(timeInSec / 60) % 60;
  var hours = parseInt(timeInSec / 3600);
  if (hours > 0) {
    result.hours = hours;
  }
  result.minutes = addLeadingZero(minutes);
  result.seconds = addLeadingZero(seconds);
  return result;
}

function countDown() {
  timerTypeName.innerHTML = timerType;
  if (currentTime > 0) {
    currentTime--;
    displayCurrentTime();
    handleTotalProgress(startTime, currentTime);
    handleSecondsProgress(currentTime);
    if (currentTime === 0) {
      if (timerType === "estudo") {
        currentTime = breakTime;
        startTime = breakTime;
        timerType = "descanso";
        timerTypeName.innerHTML = timerType;
      } else {
        currentTime = sessionTime;
        startTime = sessionTime;
        timerType = "estudo";
        timerTypeName.innerHTML = timerType;
      }
    }
  }
}

function toggleTimer() {
  if (timerActive) {
    clearInterval(timer);
    startBtn.innerHTML = "iniciar";
    timerActive = false;
  } else {
    startBtn.innerHTML = "pausar";
    timer = setInterval(countDown, 1000);
    timerActive = true;
  }
}

function stopTimer() {
  timerActive = false;
  startBtn.innerHTML = "iniciar";
  clearInterval(timer);
  timerType = "estudo";
  currentTime = sessionTime;
  handleTotalProgress(startTime, currentTime);
  handleSecondsProgress(currentTime);
  displayDefaultTime();
}

function displayChangedTime(e, time) {
  if (e.target.id === "estudoMais" || e.target.id === "estudoMenos") {
    sessionTimeBlock.innerHTML = displayMinutes(sessionTime) + " min";
  } else if (e.target.id === "descansoMais" || e.target.id === "descansoMenos") {
    breakTimeBlock.innerHTML = displayMinutes(breakTime) + " min";
  }
}

startBtn.addEventListener("click", toggleTimer);
stopBtn.addEventListener("click", stopTimer);

for (var i = 0; i < increaseButtons.length; i++) {
  increaseButtons[i].addEventListener("click", function (e) {
    if (!timerActive) {
      if (e.target.id === "estudoMais") {
        sessionTime += 60;
        currentTime = sessionTime;
        startTime = sessionTime;
        displayChangedTime(e, sessionTime);
        displayCurrentTime();
      } else if (e.target.id === "descansoMais") {
        breakTime += 60;
        displayChangedTime(e, breakTime);
        displayCurrentTime();
      }
    }
  });
}

for (var i = 0; i < decreaseButtons.length; i++) {
  decreaseButtons[i].addEventListener("click", function (e) {
    if (!timerActive) {
      if (e.target.id === "estudoMenos") {
        if (sessionTime > 60) {
          sessionTime -= 60;
          currentTime = sessionTime;
          startTime = sessionTime;
          displayChangedTime(e, sessionTime);
          displayCurrentTime();
        }
      } else if (e.target.id === "descansoMenos") {
        if (breakTime > 60) {
          breakTime -= 60;
          displayChangedTime(e, breakTime);
          displayCurrentTime();
        }
      }
    }
  });
}

displayDefaultTime();

});