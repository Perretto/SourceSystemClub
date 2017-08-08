function createTextBox(id, label, value) {
    var html = "";
    html += "<div>";
    html += "    <label>" + label + ": </label>";
    html += "    <input type='text' value='" + value + "' />";
    html += "</div>";


    $("#" + id).append(html);
}