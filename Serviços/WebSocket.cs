using System;
using System.Collections.Generic;
using System.Text;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace TesteWebSocket.Serviços
{
    class WebSocket
    {
        static string _uri = "ws://13.82.91.23:4000";

        static ClientWebSocket clientWebSocket = null;

        static ArraySegment<Byte> buffer;

        static WebSocketReceiveResult webSocketReceive;

        static object retorno;

        static CancellationTokenSource source;

        static CancellationToken token;

        public static async Task<object> Post(string content, string action)
        {
            content = $"<query-message>{content}</query-message>";
            byte[] bytes;
            if (clientWebSocket == null)
            {
                clientWebSocket = new ClientWebSocket() { Options = { KeepAliveInterval = new TimeSpan(0, 0, 3, 0) } };
            }
            try
            {
                source = new CancellationTokenSource();
                token = source.Token;
                await clientWebSocket.ConnectAsync(new Uri(_uri), token);

                bytes = Encoding.UTF8.GetBytes(content);
                await clientWebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, token);
                buffer = new ArraySegment<byte>(new Byte[8192]);
                string receivedMessage = string.Empty;
                do
                {
                    webSocketReceive = await clientWebSocket.ReceiveAsync(buffer, token);
                    if (webSocketReceive.MessageType != WebSocketMessageType.Text)
                        break;
                    var messageBytes = buffer.Skip(buffer.Offset).Take(webSocketReceive.Count).ToArray();
                    receivedMessage = Encoding.UTF8.GetString(messageBytes);
                }
                while (!webSocketReceive.EndOfMessage);


                Debug.WriteLine(receivedMessage);
                retorno = receivedMessage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            try
            {
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }


            return retorno;
        }

    }
}
