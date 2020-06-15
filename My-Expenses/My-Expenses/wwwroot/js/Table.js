var notes = document.getElementsByClassName("productNote");
for (var i = 0; i < notes.length; i++) {
    notes[i].style.display = "none";
}

var checked = document.getElementsByClassName("checkedIcon");
for (var i = 0; i < checked.length; i++) {
    checked[i].parentElement.style.cursor = "pointer";
}

function ToggleNote(event) {
    if (event.target.parentElement.nextElementSibling.style.display == "none") {
        event.target.parentElement.nextElementSibling.style.display = "table-row"
    } else if (event.target.parentElement.nextElementSibling.style.display == "table-row"){
        event.target.parentElement.nextElementSibling.style.display = "none"
    }
}