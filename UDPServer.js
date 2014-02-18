var PORT = 33332;
var HOST = '192.168.112.11';

var dgram = require('dgram'); // UDP��Ҫ�����ģ��
var server = dgram.createSocket('udp4'); // ipv4

var IsURL = function (str_url) {
    var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp��user@
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP��ʽ��URL- 199.194.52.184
        + "|" // ����IP��DOMAIN��������
        + "([0-9a-z_!~*'()-]+\.)*" // ����- www.
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // ��������
        + "[a-z]{2,6})" // first level domain- .com or .museum
        + "(:[0-9]{1,4})?" // �˿�- :80
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
// ��server��'listening'�¼�������
server.on('listening', function () {
    var address = server.address();
    console.log('UDP Server listening on ' + address.address + ":" + address.port);
});

// ��server��'message'�¼�������
//����cookie client���ݸ�ʽ{"from":"192.168.112.11","flag":"reqlogin","url":"http://www.weibo.com"}
server.on('message', function (message, remote) {
    console.log(remote.address + ':' + remote.port + ' - ' + message);
    var sendmessage = {};
    try {
        message = JSON.parse(message);
    } catch (ex) { }

    //������Զ�̵�¼�ͻ��˷�����ַ�������¼��Ϣ
    
   
    if (isJson(message)) {
        //�ͻ��������������Cookies
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

// ������ַ���˿�
server.bind(PORT, HOST);
server.setBroadcast(true);
server.setMulticastTTL(128);
