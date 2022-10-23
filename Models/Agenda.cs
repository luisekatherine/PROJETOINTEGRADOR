using System.Reflection.Metadata;
using System.Data;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PROJETOINTEGRADOR.Models{
public class Agenda{
    public static List<PreAgendamento> agendamentos;
    static Agenda(){
        agendamentos = new List<PreAgendamento>();
    }

    public void Inserir(PreAgendamento agendamento){
        agendamentos.Add(agendamento);
    }
    public List<PreAgendamento> Listar(){
        foreach (PreAgendamento agendamento in agendamentos);
        return agendamentos;
    }
}
}
