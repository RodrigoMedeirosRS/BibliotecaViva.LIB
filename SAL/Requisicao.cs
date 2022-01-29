using System;
using RestSharp;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using BibliotecaViva.Utils;
using BibliotecaViva.SAL.Interface;

namespace BibliotecaViva.SAL
{
    public class Requisicao : IRequisicao, IDisposable
    {
        public S ExecutarPost<T, S>(string url, T corpo, bool remoteAccess = false)
        {
            try
            {
                if(!remoteAccess)
                    return ExecutarRequestNormal<T, S>(url, corpo);
                return ExecutarRemoteAccess<T, S>(url,corpo);
            }
            catch(Exception e)
            {
                throw new Exception("Erro na transmissão: " + e.Message);
            }
        }
        private S ExecutarRequestNormal<T, S>(string url, T corpo)
        {
            var client = DefinirCliente(url);
            var request = CriarRequisicao(JsonConvert.SerializeObject(corpo));
            var retorno = EnviarPOST(client, request);
            if (typeof(S).Name == "String")
                return (S)Convert.ChangeType(retorno, typeof(S));
            return JsonConvert.DeserializeObject<S>(EnviarPOST(client, request));
        }
        private S ExecutarRemoteAccess<T, S>(string url, T corpo)
        {
            var argumento = url + "|" + JsonConvert.SerializeObject(corpo);
            var processo = ProcessoUtil.InstanciarNovoProcesso(argumento, "./Remote.Access.exe");
            var retorno = ProcessoUtil.ExecutarProcesso(processo);
            if (typeof(S).Name == "String")
                return (S)Convert.ChangeType(retorno, typeof(S));
            return JsonConvert.DeserializeObject<S>(retorno);
        }

        public string ExecutarGet(string requisicao)
        {
            try
            {
                using (var resposta = EnviarGET(requisicao))
                {
                    var textoResposta = ObterResposta(resposta);
                    return textoResposta;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na transmissão: " + ex.Message);
            }
        }

        private RestRequest CriarRequisicao(string body)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Host", "127.0.0.1");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Connection", "keep-alive");
            request.AddJsonBody(body);
            request.ReadWriteTimeout = 60000;
            return request;
        }

        private RestClient DefinirCliente(string url)
        {
            var client = new RestClient(url);
            client.ReadWriteTimeout = 60000;
            return client;
        }

        private string ObterResposta(WebResponse resposta)
        {
            var streamDados = resposta.GetResponseStream();
            var reader = new StreamReader(streamDados);
            var textoResposta = reader.ReadToEnd().ToString();

            reader.Close();
            streamDados.Close();
            return textoResposta;
        }

        private string EnviarPOST(RestClient client, RestRequest request)
        {
            var response = client.Execute(request);
            return response.Content.ToString();
        }

        private WebResponse EnviarGET(string requisicao)
        {
            var requisicaoWeb = WebRequest.CreateHttp(requisicao);
            requisicaoWeb.Method = "GET";
            var resposta = requisicaoWeb.GetResponse();
            return resposta;
        }
        public void Dispose()
        {
            
        }
    }
}