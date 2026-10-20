using System;
using System.Collections.Generic;

public class Projetos
{
    private List<Projeto> itens;

    public Projetos()
    {
        itens = new List<Projeto>();
    }

    public bool adicionar(Projeto p)
    {
        if (buscar(p) != null)
        {
            return false;
        }

        itens.Add(p);
        return true;
    }

    public bool remover(Projeto p)
    {
        if (p.getTarefas().Count > 0)
        {
            return false;
        }

        return itens.Remove(p);
    }

    public Projeto buscar(Projeto p)
    {
        foreach (Projeto projeto in itens)
        {
            if (projeto.getId() == p.getId())
            {
                return projeto;
            }
        }

        return null;
    }

    public Projeto buscarPorId(int id)
    {
        foreach (Projeto projeto in itens)
        {
            if (projeto.getId() == id)
            {
                return projeto;
            }
        }

        return null;
    }

    public List<Projeto> listar()
    {
        return itens;
    }
}
