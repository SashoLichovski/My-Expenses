var sidebar = document.getElementById("sidebarContainer");
sidebar.style.top = "-450px"
function ToggleSidebar() {

    if (sidebar.style.top == "-450px") {
        sidebar.style.top = "55px"
    } else {
        sidebar.style.top = "-450px"
    }
    if (document.getElementById("customFilterForm").style.display == "block") {
        document.getElementById("customFilterForm").style.display = "none"
    }
    if (document.getElementById("formByMonth").style.display == "block") {
        document.getElementById("formByMonth").style.display = "none"
    }
    if (document.getElementById("formByWeek").style.display == "block") {
        document.getElementById("formByWeek").style.display = "none"
    }
    if (document.getElementById("formByDay").style.display == "block") {
        document.getElementById("formByDay").style.display = "none"
    }
    if (document.getElementById("formByEmployee").style.display == "block") {
        document.getElementById("formByEmployee").style.display = "none"
    }
}

var customFilterForm = document.getElementById("customFilterForm");
customFilterForm.style.display = "none";

var formByMonth = document.getElementById("formByMonth");
formByMonth.style.display = "none";

var formByWeek = document.getElementById("formByWeek");
formByWeek.style.display = "none";

var formByWeek = document.getElementById("formByDay");
formByWeek.style.display = "none";

var formByWeek = document.getElementById("formByEmployee");
formByWeek.style.display = "none";

function ToggleForm(id) {
    var form = document.getElementById(id);
    if (form.style.display == "none") {
        form.style.display = "block";
    } else {
        form.style.display = "none";
    }
    console.log(form)
}