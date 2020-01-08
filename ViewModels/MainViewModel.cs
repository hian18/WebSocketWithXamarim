using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteWebSocket.Serviços;
using System.Diagnostics;
namespace TesteWebSocket.ViewModels
{
    public class MainViewModel
    {

        public async Task GetEvento()
        {

            string json = "action-my-user-model{" +
               "\"Authenticated\": false,\"+" +
       "\"Filter\": {" +
       "\"AppActionPage\": null," +
       "\"AppLanguage\": \"pt-BR\"," +
       "\"AppPageId\": \"none\"," +
       "\"AuditDataSource\": 0," +
       "\"AuditDateTimeRegistration\": {" +
       "\"DateTime\": \"/Date(-62135596800000)/\"," +
       "\"OffsetMinutes\": 0}," +
       "\"AuditUserId\": 0," +
       "\"ClientId\": 0," +
       "\"TypeQuery\": \"all\"," +
       "\"MyUserId\": 0," +
       "\"MyUserLogin\": null," +
       "\"MyUserPassw\": null," +
       "\"MyUserTypeId\": null" +
       "}," +
       "\"MyUserCell\": null," +
       "\"MyUserDoc\": null," +
       "\"MyUserEmail\": null," +
       "\"MyUserGender\": false," +
       "\"MyUserId\": 0," +
       "\"MyUserKey\": 0," +
       "\"MyUserLastName\": null," +
       "\"MyUserName\": null," +
       "\"MyUserOnline\": false," +
       "\"MyUserPassw\": null," +
       "\"MyUserStatus\": null" +
    "}";


            var resposta = await WebSocket.Post(json, "123");

        }
    }
}
