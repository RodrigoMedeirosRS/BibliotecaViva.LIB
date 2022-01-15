using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BibliotecaViva.BLL.Utils
{
    public static class TratadorUtil
    {
        public static int BoolToInt(bool valor)
        {
            return valor ? 1 : 0;
        }
        public static void ValidarEMail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (!regex.IsMatch(email))
                throw new Exception("E-Mail inválido!");
        }
        public static void ValidarCPF(string cpf)
        {
            ValidarQuantidadeDeDigitos(cpf);
            ValidarDigitosVerificadores(cpf);
        }
        public static void ValidarSenha(string senha)
        {
            if(senha.Length < 8 && !string.IsNullOrEmpty(senha))
                throw new Exception("Usuário ou senha inválido.");
        }
        public static string CriarMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
        public static string CriptografarEmAES(string dados, string aes_chave, string aes_iv)
        {
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Convert.FromBase64String(aes_chave);
                rijAlg.IV = Convert.FromBase64String(aes_iv);
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        swEncrypt.Write(dados);
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public static string[] ProcessarLatLong(string latlong)
        {
            latlong = RemoverEspacosString(latlong);
            var coordenadas = SepararPorVirgula(latlong);
            ValidarCoordenadas(coordenadas);
            return coordenadas;
        }
        private static void ValidarCoordenadas(string[] coordenadas)
        {
            double.Parse(coordenadas[0], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
            double.Parse(coordenadas[1], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
        }
        public static string RemoverEspacosString(string input)
        {
            return input.Replace(" ", "");
        }
        public static string[] SepararPorVirgula(string input)
        {
            return input.Split(',');
        }
        private static void ValidarQuantidadeDeDigitos(string cpf)
        {
            if (cpf.Length < 11 || !cpf.All(char.IsDigit))
                throw new Exception("CPF Inválido, favor inserir um CPF com 11 dígitos.");
        }
        private static void ValidarDigitosVerificadores(string cpf)
        {
            ValidarPrimeiroDigitoVerificador(cpf);
            ValidarSegundoDigitoVerificador(cpf);
        }
        private static void ValidarPrimeiroDigitoVerificador(string cpf)
        {
            var soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * (int)Char.GetNumericValue(cpf.ToCharArray()[i]);
            }
            var resto = soma % 11;
            var primeiroDigitoVerificador = 0;
            if (resto >= 2)
                primeiroDigitoVerificador = 11 - resto;
            if ((int)Char.GetNumericValue(cpf.ToCharArray()[9]) != primeiroDigitoVerificador)
                throw new Exception("CPF Inválido!");
        }
        public static string ColocarZeroAFrente(int valor, int quantidade)
        {
            var resultadoFinal = string.Empty;
            for(int i = 0; i < quantidade; i++)
                resultadoFinal += "0";
            return valor <= 9 ? (resultadoFinal + valor).ToString() : valor.ToString();
        }
        private static void ValidarSegundoDigitoVerificador(string cpf)
        {
            var soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * (int)Char.GetNumericValue(cpf.ToCharArray()[i]);
            }
            var resto = soma % 11;
            var segundoDigitoVerificador = 0;
            if (resto >= 2)
                segundoDigitoVerificador = 11 - resto;
            if ((int)Char.GetNumericValue(cpf.ToCharArray()[10]) != segundoDigitoVerificador)
                throw new Exception("CPF Inválido!");
        }
    }
}