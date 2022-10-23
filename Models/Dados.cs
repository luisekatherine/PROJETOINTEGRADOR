using System.Reflection.Metadata;
using System.Data;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PROJETOINTEGRADOR.Models{

    public class Dados
    {
        public static Agenda AgendaAtual{get;set;}
        static Dados()
        {
            AgendaAtual = new Agenda();
        }
    }
}
