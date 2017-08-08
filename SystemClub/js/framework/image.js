function createImage(id, label, value, link) {
    var html = "";
    html += "<div class='tile white title-scaleup imagetile w2 h1'>";
    html += "<a href=" + link + " target=\"_blank\">";
    html += "    <img width = '200px' height = '200px' src='" + value + "' alt='' />";
    html += "</a>";
    html += "</div>";

    $("#" + id).append(html);
}