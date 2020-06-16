var transferForm = document.getElementById("transferForm");
transferForm.style.display = "none";

var addForm = document.getElementById("addForm");
addForm.style.display = "none";

function ToggleForm(id) {
    var form = document.getElementById(id);
    if (form.style.display == "none") {
        form.style.display = "flex";
    } else {
        form.style.display = "none";
    }
}