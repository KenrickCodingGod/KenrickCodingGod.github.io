const contactForm = document.querySelector("#contact-form");
const nameInput = document.querySelector("#name");
const emailInput = document.querySelector("#email");
const messageInput = document.querySelector("#message");
const formStatus = document.querySelector("#form-status");

const showError = (input, message) => {
    const errorElement = document.querySelector(`#${input.id}-error`);
    errorElement.textContent = message;
    input.setAttribute("aria-invalid", "true");
};

const clearError = (input) => {
    const errorElement = document.querySelector(`#${input.id}-error`);
    errorElement.textContent = "";
    input.removeAttribute("aria-invalid");
};

const validateName = () => {
    clearError(nameInput);

    if (nameInput.value.trim().length < 2) {
        showError(nameInput, "Vul een naam van minimaal 2 tekens in.");
        return false;
    }

    return true;
};

const validateEmail = () => {
    clearError(emailInput);
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailPattern.test(emailInput.value.trim())) {
        showError(emailInput, "Vul een geldig e-mailadres in.");
        return false;
    }

    return true;
};

const validateMessage = () => {
    clearError(messageInput);

    if (messageInput.value.trim().length < 10) {
        showError(messageInput, "Het bericht moet minimaal 10 tekens bevatten.");
        return false;
    }

    return true;
};

const validateForm = () => {
    const nameIsValid = validateName();
    const emailIsValid = validateEmail();
    const messageIsValid = validateMessage();

    return nameIsValid && emailIsValid && messageIsValid;
};

contactForm.addEventListener("submit", (event) => {
    event.preventDefault();
    formStatus.textContent = "";

    if (validateForm()) {
        formStatus.textContent = "De gegevens zijn geldig ingevuld. Verzending is nog niet gekoppeld aan een backend.";
        contactForm.reset();
    } else {
        formStatus.textContent = "Controleer de velden met een foutmelding.";
    }
});
