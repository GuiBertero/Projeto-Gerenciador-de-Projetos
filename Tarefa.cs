using System;

public class Tarefa
{
    private int id;
    private string titulo;
    private string descricao;
    private int prioridade;
    private string status;
    private DateTime dataCriacao;
    private DateTime dataConclusao;

    public Tarefa(int id, string titulo, string descricao, int prioridade)
    {
        this.id = id;
        this.titulo = titulo;
        this.descricao = descricao;
        this.prioridade = prioridade;
        this.status = "Aberta";
        this.dataCriacao = DateTime.Now;
        this.dataConclusao = DateTime.MinValue;
    }

    public int getId()
    {
        return id;
    }

    public string getTitulo()
    {
        return titulo;
    }

    public string getDescricao()
    {
        return descricao;
    }

    public int getPrioridade()
    {
        return prioridade;
    }

    public string getStatus()
    {
        return status;
    }

    public DateTime getDataCriacao()
    {
        return dataCriacao;
    }

    public DateTime getDataConclusao()
    {
        return dataConclusao;
    }

    public void concluir()
    {
        if (status == "Aberta")
        {
            status = "Fechada";
            dataConclusao = DateTime.Now;
        }
    }

    public void cancelar()
    {
        if (status == "Aberta")
        {
            status = "Cancelada";
            dataConclusao = DateTime.Now;
        }
    }

    public void reabrir()
    {
        if (status == "Fechada" || status == "Cancelada")
        {
            status = "Aberta";
            dataConclusao = DateTime.MinValue;
        }
    }

    public void mostrar()
    {
        string prioridadeTexto = "";

        if (prioridade == 1)
            prioridadeTexto = "Alta";
        else if (prioridade == 2)
            prioridadeTexto = "Média";
        else
            prioridadeTexto = "Baixa";

        Console.WriteLine("ID: " + id);
        Console.WriteLine("Título: " + titulo);
        Console.WriteLine("Descrição: " + descricao);
        Console.WriteLine("Prioridade: " + prioridadeTexto);
        Console.WriteLine("Status: " + status);
        Console.WriteLine("Data de criação: " + dataCriacao.ToString("dd/MM/yyyy HH:mm"));

        if (dataConclusao != DateTime.MinValue)
            Console.WriteLine("Data de conclusão: " + dataConclusao.ToString("dd/MM/yyyy HH:mm"));

        Console.WriteLine("-----------------------------------");
    }
}
