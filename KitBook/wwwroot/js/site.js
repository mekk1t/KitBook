var afterLoading = (callback) => {
    if (document.readyState != "loading") callback();
    else document.addEventListener("DOMContentLoaded", callback);
}

afterLoading(() => {
    autosizeTextareas();
});

/** Applies "autosize" function to all textarea elements on the page. */
function autosizeTextareas() {
    var descriptionElement = document.getElementById("Description");
    if (descriptionElement) {
        autosize(descriptionElement);
    }

    var textAreaElements = document.getElementsByClassName("custom-textarea")
    if (textAreaElements) {
        for (var i = 0; i < textAreaElements.length; i++) {
            autosize(textAreaElements[i]);
        }
    }
}