
function startIndex() {
    var products = ProductSearch(1);
    createProducts(products);

    var count = ProductCount();
    createPagination(count);
}

function ProductSearch(page) {
        var parameters = new Object();
        parameters.type = "get";
        parameters.url = getGlobal("urlPlataforma") + "/api/product/GetProducts";
        parameters.dados = "page=" + page;

        return ajax(parameters);        
}

function ProductCount() {
    var parameters = new Object();
    parameters.type = "get";
    parameters.url = getGlobal("urlPlataforma") + "/api/product/count";
    parameters.dados = "";

    return ajax(parameters);
}

function createProducts(products) {
    var html = "";

    for (var i = 0; i < products.products.length; i++) {
        html += createwindow(products.products[i]);
    }

    $("#containerProducts").html(html);
}

function createPagination(products){
    var count = products.count;
    var html = "<div class=\"caption white\"><h4>Paginas: </h4>";

    if (count != null && count != "" && count != 0) {
        var str = Left(count, 1);

        for (var i = 1; i <= str; i++) {
            html += "<a href='#' class='link' onclick=\"refreshProducts('" + i + "')\">" + i + "</a>   ";
        }
    }

    html += "</div>";

    $("#containerProductsCount").html(html);
}

function refreshProducts(page) {
    var products = ProductSearch(page);
    createProducts(products);
}

function Left(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0, n);
}

function createwindow(object) {
    var html = "";

    html += "<div class='tile white title-scaleup imagetile w2 h1'>";
    html += "    <div class='caption white'>";
    html += "        <a href=\"#\" class=\"link\" onclick=\"editProduct('" + object.id + "')\">"; //href='" + object.permalink + "'>";
    html += "            <div class='title'><i class='fa fa-file-text fa-2x'></i></div>";
    html += "            <div class='caption-text'>";
    html += "                " + object.title;
    html += "            </div>";
    html += "        </a>";
    html += "    </div>";

    if (object.featured_src == false) {
        html += "    <img src='" + object.images[0].src + "' alt='' width=\"200\" />";
    }else{
        html += "    <img src='" + object.featured_src + "' alt='' width=\"200\"/>";
    }

    html += "</div>";

    return html;
}

function getProduct(id) {
    var parameters = new Object();
    parameters.type = "get";
    parameters.url = getGlobal("urlPlataforma") + "/api/product/GetProduct";
    parameters.dados = "id=" + id;

    return ajax(parameters);

}

function editProduct(id) {
    var html = "";
    $("#containerProducts").html(html);

    var object = getProduct(id);
    var image = object.product.featured_src;

    if (image == false) {
        image = object.product.images[0].src;
    }

    createImage("containerProducts", "Imagem: ", image, object.product.permalink);
    
    createLabel("containerProducts", "Criado em", object.product.created_at);

    createLabel("containerProducts","Atualizado em", object.product.updated_at);
   
    createTextBox("containerProducts", "Nome", object.product.title);

    createTextBox("containerProducts", "Preço", object.product.price);

    if (object.product.categories != null) {
        html += "<div>";
        html += "    <label>Categorias: </label>";
        for (var i = 0; i < object.product.categories.length; i++) {
            html += "    <label>" + object.product.categories[i] + "</label>";
        }
        html += "</div>";
    }

    //$("#containerProducts").html(html);
    $("#containerProductsCount").html("");
}