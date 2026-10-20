using System;
using System.Collections.Generic;

public class Projeto
{
    private int id;
    private string nome;
    private List<Tarefa> tarefas;

    public Projeto(int id, string nome)
    {
        this.id = id;
        this.nome = nome;
        this.tarefas = new List<Tarefa>();
    }

    public int getId()
    {
        return id;
    }

    public string getNome()
    {
        return nome;
    }

    public List<Tarefa> getTarefas()
    {
        return tarefas;
    }

    public void adicionarTarefa(Tarefa t)
    {
        tarefas.Add(t);
    }

    public bool removerTarefa(Tarefa t)
    {
        return tarefas.Remove(t);
    }

    public Tarefa buscarTarefa(Tarefa t)
    {
        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getId() == t.getId())
            {
                return tarefa;
            }
        }

        return null;
    }

    public Tarefa buscarTarefaPorId(int id)
    {
        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getId() == id)
            {
                return tarefa;
            }
        }

        return null;
    }

    public List<Tarefa> tarefasPorStatus(string status)
    {
        List<Tarefa> resultado = new List<Tarefa>();

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getStatus().ToLower() == status.ToLower())
            {
                resultado.Add(tarefa);
            }
        }

        return resultado;
    }

    public List<Tarefa> tarefasPorPrioridade(int prioridade)
    {
        List<Tarefa> resultado = new List<Tarefa>();

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getPrioridade() == prioridade)
            {
                resultado.Add(tarefa);
            }
        }

        return resultado;
    }

    public int totalAbertas()
    {
        int total = 0;

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getStatus() == "Aberta")
            {
                total++;
            }
        }

        return total;
    }

    public int totalFechadas()
    {
        int total = 0;

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getStatus() == "Fechada")
            {
                total++;
            }
        }

        return total;
    }

    public int totalCanceladas()
    {
        int total = 0;

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.getStatus() == "Cancelada")
            {
                total++;
            }
        }

        return total;
    }

    public void mostrar()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Projeto: " + nome);
        Console.WriteLine("Quantidade de tarefas: " + tarefas.Count);
        Console.WriteLine("Tarefas abertas: " + totalAbertas());
        Console.WriteLine("Tarefas fechadas: " + totalFechadas());
        Console.WriteLine("Tarefas canceladas: " + totalCanceladas());
    }
}
