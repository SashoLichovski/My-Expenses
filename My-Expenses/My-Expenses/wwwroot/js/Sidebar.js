var sidebar = document.getElementById("sidebarContainer");
sidebar.style.top = "-500px"
function ToggleSidebar() {

    if (sidebar.style.top == "-500px") {
        sidebar.style.top = "55px"
    } else {
        sidebar.style.top = "-500px"
    }
}

var formByName = document.getElementById("formByName");
formByName.style.display = "none";
function ToggleForm(id) {
    var form = document.getElementById(id);
    if (form.style.display == "none") {
        form.style.display = "block"
    } else {
        form.style.display = "none";
    }
    console.log(form)
}