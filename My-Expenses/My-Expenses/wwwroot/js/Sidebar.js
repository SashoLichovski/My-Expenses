var sidebar = document.getElementById("sidebarContainer");
sidebar.style.top = "-400px"
function ToggleSidebar() {

    if (sidebar.style.top == "-400px") {
        sidebar.style.top = "55px"
    } else {
        sidebar.style.top = "-400px"
    }
    if (document.getElementById("customFilterForm").style.display == "block") {
        document.getElementById("customFilterForm").style.display = "none"
    }
    if (document.getElementById("formByMonth").style.display == "block") {
        document.getElementById("formByMonth").style.display = "none"
    }
}

var customFilterForm = document.getElementById("customFilterForm");
customFilterForm.style.display = "none";

var formByMonth = document.getElementById("formByMonth");
formByMonth.style.display = "none";


function ToggleForm(id) {
    var form = document.getElementById(id);
    if (form.style.display == "none") {
        form.style.display = "block";
    } else {
        form.style.display = "none";
    }
    console.log(form)
}