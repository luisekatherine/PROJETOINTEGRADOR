// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const controls = document.querySelectorAll(".control");
let currentItem = 0;
const items = document.querySelectorAll(".item");
const maxItems = items.length;
const form = document.getElementById("form");
const username = document.getElementById("Nome");
const email = document.getElementById("Telefone");
const endereço = document.getElementById("Destino");
const sabores = document.getElementById("DataDesejada");
const telefone = document.getElementById("Passaporte");

controls.forEach((control) => {
  control.addEventListener("click", (e) => {
    isLeft = e.target.classList.contains("arrow-left");

    if (isLeft) {
      currentItem -= 1;
    } else {
      currentItem += 1;
    }

    if (currentItem >= maxItems) {
      currentItem = 0;
    }

    if (currentItem < 0) {
      currentItem = maxItems - 1;
    }

    items.forEach((item) => item.classList.remove("current-item"));

    items[currentItem].scrollIntoView({
      behavior: "smooth",
      inline: "center"
    });

    items[currentItem].classList.add("current-item");
  });
});

form.addEventListener("submit", (e) => {
  e.preventDefault();

  checkInputs();
});

function checkInputs() {
  const NomeValue = Nome.value;
  const TelefoneValue = Telefone.value;
  const DestinoValue = Destino.value;
  const DataDesejadaValue = DataDesejada.value;
  const PassaporteValue = Passaporte.value;

  if (NomeValue === "") {
    setErrorFor(Nome, "Faltou seu nome :(");
  } else {
    setSuccessFor(Nome);
  }

  if (TelefoneValue === "") {
    setErrorFor(Telefone, "Por favor, preencha o seu telefone");
  } else {
    setSuccessFor(Telefone);
  }

  if (DestinoValue === "") {
    setErrorFor(Destino, "Por favor, digite o destino desejado");
  } else {
    setSuccessFor(Destino);
  }

  if (DataDesejadaValue === "") {
    setErrorFor(DataDesejada, "Necessário escolher a data e horário");
  } else {
    setSuccessFor(DataDesejada);
  }

  if (PassaporteValue === "") {
    setErrorFor(Passaporte, "Informe se você já possui passaporte");
  } else {
    setSuccessFor(Passaporte);
  }

  const formControls = form.querySelectorAll(".form-control");

  const formIsValid = [...formControls].every((formControl) => {
    return formControl.className === "form-control success";
  });

  if (formIsValid) {
    console.log("O formulário está 100% válido!");
  }
}

function setErrorFor(input, message) {
  const formControl = input.parentElement;
  const small = formControl.querySelector("small");

  // Adiciona a mensagem de erro
  small.innerText = message;

  // Adiciona a classe de erro
  formControl.className = "form-control error";
}

function setSuccessFor(input) {
  const formControl = input.parentElement;

  // Adicionar a classe de sucesso
  formControl.className = "form-control success";
}
