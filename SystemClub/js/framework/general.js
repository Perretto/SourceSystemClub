function ajax(parameters) {
    var retorno = false;
    var dataType = (parameters.dataType) ? parameters.dataType : "json";
    var type = (parameters.type) ? parameters.type : "";
    var url = (parameters.url) ? parameters.url : "";
    var dados = (parameters.dados) ? parameters.dados : "";
    var callback = (parameters.callback) ? parameters.callback : "";
    var async = (parameters.async) ? parameters.async : false;

    $.ajax({
        type: type,
        //headers: {
        //'Accept': 'application/json',
        //'Content-Type': 'text/plain; charset=utf-8'
        //},
        url: url,
        dataType: dataType,
        //contentType: 'application/json; charset=utf-8',
        //cors: true,
        async: async,
        crossDomain: true,
        data: dados,
        success: function (result) {
            retorno = result;
            if (result.length > 0) {                
                if (callback) {
                    callback(result);
                }
                              
            }
        },
        error: function (result) {
            alert("Erro");
        }
    });
    
    return retorno;
}

function getGlobal(parametro) {

    var global = new Object();
    global.urlPlataforma = "http://localhost:7000"
    global.urlInterface = "http://localhost:29294"

    if (parametro) {
        return global[parametro]
    }
    else {
        return global
    }

}