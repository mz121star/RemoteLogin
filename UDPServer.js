var PORT = 33332;
var HOST = '192.168.112.11';

var dgram = require('dgram'); // UDP需要引入该模块
var server = dgram.createSocket('udp4'); // ipv4

var IsURL = function (str_url) {
    var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184
        + "|" // 允许IP和DOMAIN（域名）
        + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名
        + "[a-z]{2,6})" // first level domain- .com or .museum
        + "(:[0-9]{1,4})?" // 端口- :80
        + "((/?)|" // a slash isn't required if there is no file name
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
    var re = new RegExp(strRegex);
    //re.test()
    if (re.test(str_url)) {
        return (true);
    } else {
        return (false);
    }
};
var isJson = function (obj) {
    var isjson = typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
    return isjson;
}
// 给server绑定'listening'事件处理函数
server.on('listening', function () {
    var address = server.address();
    console.log('UDP Server listening on ' + address.address + ":" + address.port);
});

// 给server绑定'message'事件处理函数
//请求cookie client数据格式{"from":"192.168.112.11","flag":"reqlogin","url":"http://www.weibo.com"}
server.on('message', function (message, remote) {
    console.log(remote.address + ':' + remote.port + ' - ' + message);
    var sendmessage = {};
    try {
        message = JSON.parse(message);
    } catch (ex) { }

    //向所有远程登录客户端发送网址，请求登录信息
    
   
    if (isJson(message)) {
        //客户端向服务器请求Cookies
        if ((message.from === (remote.address + ':' + remote.port)) && message.flag === "0" && IsURL(message.url) ) {
            sendmessage.sourceip = remote.address + ":" + remote.port;
            sendmessage.url = message.url;
            sendmessage.flag = "1";
            sendmessage.from = server.address().address + ":" + server.address().port;

        }

        sendmessage = JSON.stringify(sendmessage);
        console.log(sendmessage);
        var rMessage = new Buffer(sendmessage);
        server.send(rMessage, 0, rMessage.length, "33333", "192.168.112.255", function (err, bytes) {
            if (err) throw err;

        });
    }
});

// 监听地址及端口
server.bind(PORT, HOST);
server.setBroadcast(true);
server.setMulticastTTL(128);
