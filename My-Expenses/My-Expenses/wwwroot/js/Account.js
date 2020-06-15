var form = document.getElementById("transferForm");
form.style.display = "none";

function ToggleForm() {
    if (form.style.display == "none") {
        form.style.display = "flex";
    } else {
        form.style.display = "none";
    }
}