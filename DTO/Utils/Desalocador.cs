using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO.Utils
{
    public static class Desalocador
    {
        public static void DesalocarLista<T>(List<T> Registros) where T : IDisposable
        {
            foreach (var registro in Registros)
                registro.Dispose();
            Registros.Clear();
            Registros = null;
        }
    }
}