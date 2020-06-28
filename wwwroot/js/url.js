/**
 * 读取URL参数
 * @param {any} name 参数名
 */
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null)
        return unescape(r[2]);
    return null; //返回参数值
}

function getQueryValue(value) {
    var query = window.location.search.substring(1);
    var queryPro = query.split("&");
    for (var i = 0; i < queryPro.length; i++) {
        var pair = queryPro[i].split("=");
        if (pair[0] == value) {
            return pair[1];
        }
    }
}
