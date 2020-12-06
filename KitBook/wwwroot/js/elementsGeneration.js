function Input(_class, _id) {
    this._class = _class;
    this._id = _id;
}
function Label(_class, _html) {
    this._class = _class;
    this._html = _html;
}
function Button(
    _class,
    _id,
    _type,
    _value,
    _html,
    _onclick) {
    this._class = _class;
    this._id = _id;
    this._type = _type;
    this._value = _value;
    this._html = _html;
    this._onclick = _onclick;
}

/**
 * @param {Label} object
 * @returns {HTMLElement}
 */
function createLabel(object) {
    var label = document.createElement("label");
    label.setAttribute("class", object._class);
    label.innerHTML = object._html;
    return label;
}

/**
 * @param {Button} object
 * @returns {HTMLElement}
 */
function createSubmitButton(object) {
    var submitButton = document.createElement("button");

    submitButton.setAttribute("class", object._class);
    submitButton.setAttribute("id", object._id);
    submitButton.setAttribute("type", object._type);
    submitButton.setAttribute("value", object._value);
    submitButton.setAttribute("onclick", object._onclick);
    submitButton.innerHTML = object._html;

    return submitButton;
}