function createLabel(id, label, value) {
    var html = "";
    html += "<div>";
    html += "    <label>" + label + ": </label>";
    html += "    <label>" + value + "</label>";
    html += "</div>";


    $("#" + id).append(html);
}