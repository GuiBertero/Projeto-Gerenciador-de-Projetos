using System;
using System.Collections.Generic;

class Program
{
    static Projetos projetos = new Projetos();

    static int proximoProjeto = 1;
    static int proximaTarefa = 1;

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("       SISTEMA DE PROJETOS");
            Console.WriteLine("======================================");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Adicionar projeto");
            Console.WriteLine("2 - Pesquisar projeto");
            Console.WriteLine("3 - Remover projeto");
            Console.WriteLine("4 - Adicionar tarefa em projeto");
            Console.WriteLine("5 - Concluir tarefa");
            Console.WriteLine("6 - Cancelar tarefa");
            Console.WriteLine("7 - Reabrir tarefa");
            Console.WriteLine("8 - Listar tarefas de um projeto");
            Console.WriteLine("9 - Filtrar tarefas por status ou prioridade em um projeto");
            Console.WriteLine("10 - Filtrar tarefas por status ou prioridade em todos os projetos");
            Console.WriteLine("11 - Resumo geral");
            Console.WriteLine("======================================");

            Console.Write("Digite uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    adicionarProjeto();
                    break;

                case 2:
                    pesquisarProjeto();
                    break;

                case 3:
                    removerProjeto();
                    break;

                case 4:
                    adicionarTarefa();
                    break;

                case 5:
                    concluirTarefa();
                    break;

                case 6:
                    cancelarTarefa();
                    break;

                case 7:
                    reabrirTarefa();
                    break;

                case 8:
                    listarTarefas();
                    break;

                case 9:
                    filtrarProjeto();
                    break;

                case 10:
                    filtrarTodos();
                    break;

                case 11:
                    resumoGeral();
                    break;

                case 0:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    static void adicionarProjeto()
    {
        Console.WriteLine("=== ADICIONAR PROJETO ===");

        Console.Write("Nome do projeto: ");
        string nome = Console.ReadLine();

        Projeto projeto = new Projeto(proximoProjeto, nome);

        if (projetos.adicionar(projeto))
        {
            Console.WriteLine("Projeto adicionado com sucesso.");
            Console.WriteLine("ID do projeto: " + proximoProjeto);
            proximoProjeto++;
        }
        else
        {
            Console.WriteLine("Não foi possível adicionar o projeto.");
        }
    }

    static void pesquisarProjeto()
    {
        Console.WriteLine("=== PESQUISAR PROJETO ===");

        Console.Write("Digite o ID do projeto: ");
        int id = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(id);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        projeto.mostrar();

        Console.WriteLine();
        Console.WriteLine("Tarefas do projeto:");

        foreach (Tarefa tarefa in projeto.getTarefas())
        {
            tarefa.mostrar();
        }
    }

    static void removerProjeto()
    {
        Console.WriteLine("=== REMOVER PROJETO ===");

        Console.Write("Digite o ID do projeto: ");
        int id = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(id);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        if (projeto.getTarefas().Count > 0)
        {
            Console.WriteLine("O projeto possui tarefas e não pode ser removido.");
            return;
        }

        if (projetos.remover(projeto))
        {
            Console.WriteLine("Projeto removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Não foi possível remover o projeto.");
        }
    }

    static void adicionarTarefa()
    {
        Console.WriteLine("=== ADICIONAR TAREFA ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Prioridade:");
        Console.WriteLine("1 - Alta");
        Console.WriteLine("2 - Média");
        Console.WriteLine("3 - Baixa");

        Console.Write("Escolha: ");
        int prioridade = int.Parse(Console.ReadLine());

        if (prioridade < 1 || prioridade > 3)
        {
            Console.WriteLine("Prioridade inválida.");
            return;
        }

        Tarefa tarefa = new Tarefa(
            proximaTarefa,
            titulo,
            descricao,
            prioridade
        );

        projeto.adicionarTarefa(tarefa);

        Console.WriteLine("Tarefa adicionada com sucesso.");
        Console.WriteLine("ID da tarefa: " + proximaTarefa);

        proximaTarefa++;
    }

    static void concluirTarefa()
    {
        Console.WriteLine("=== CONCLUIR TAREFA ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.Write("ID da tarefa: ");
        int idTarefa = int.Parse(Console.ReadLine());

        Tarefa tarefa = projeto.buscarTarefaPorId(idTarefa);

        if (tarefa == null)
        {
            Console.WriteLine("Tarefa não encontrada.");
            return;
        }

        if (tarefa.getStatus() != "Aberta")
        {
            Console.WriteLine("A tarefa não está aberta.");
            return;
        }

        tarefa.concluir();

        Console.WriteLine("Tarefa concluída com sucesso.");
    }

    static void cancelarTarefa()
    {
        Console.WriteLine("=== CANCELAR TAREFA ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.Write("ID da tarefa: ");
        int idTarefa = int.Parse(Console.ReadLine());

        Tarefa tarefa = projeto.buscarTarefaPorId(idTarefa);

        if (tarefa == null)
        {
            Console.WriteLine("Tarefa não encontrada.");
            return;
        }

        if (tarefa.getStatus() != "Aberta")
        {
            Console.WriteLine("A tarefa não está aberta.");
            return;
        }

        tarefa.cancelar();

        Console.WriteLine("Tarefa cancelada com sucesso.");
    }

    static void reabrirTarefa()
    {
        Console.WriteLine("=== REABRIR TAREFA ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.Write("ID da tarefa: ");
        int idTarefa = int.Parse(Console.ReadLine());

        Tarefa tarefa = projeto.buscarTarefaPorId(idTarefa);

        if (tarefa == null)
        {
            Console.WriteLine("Tarefa não encontrada.");
            return;
        }

        tarefa.reabrir();

        Console.WriteLine("Tarefa reaberta com sucesso.");
    }

    static void listarTarefas()
    {
        Console.WriteLine("=== LISTAR TAREFAS ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        if (projeto.getTarefas().Count == 0)
        {
            Console.WriteLine("O projeto não possui tarefas.");
            return;
        }

        Console.WriteLine("Projeto: " + projeto.getNome());
        Console.WriteLine();

        foreach (Tarefa tarefa in projeto.getTarefas())
        {
            tarefa.mostrar();
        }
    }

    static void filtrarProjeto()
    {
        Console.WriteLine("=== FILTRAR TAREFAS DE UM PROJETO ===");

        Console.Write("ID do projeto: ");
        int idProjeto = int.Parse(Console.ReadLine());

        Projeto projeto = projetos.buscarPorId(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("1 - Filtrar por status");
        Console.WriteLine("2 - Filtrar por prioridade");

        Console.Write("Escolha: ");
        int tipo = int.Parse(Console.ReadLine());

        if (tipo == 1)
        {
            Console.WriteLine();
            Console.WriteLine("Status:");
            Console.WriteLine("Aberta");
            Console.WriteLine("Fechada");
            Console.WriteLine("Cancelada");

            Console.Write("Digite o status: ");
            string status = Console.ReadLine();

            List<Tarefa> resultado = projeto.tarefasPorStatus(status);

            mostrarListaTarefas(resultado);
        }
        else if (tipo == 2)
        {
            Console.WriteLine();
            Console.WriteLine("Prioridade:");
            Console.WriteLine("1 - Alta");
            Console.WriteLine("2 - Média");
            Console.WriteLine("3 - Baixa");

            Console.Write("Digite a prioridade: ");
            int prioridade = int.Parse(Console.ReadLine());

            List<Tarefa> resultado = projeto.tarefasPorPrioridade(prioridade);

            mostrarListaTarefas(resultado);
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }

    static void filtrarTodos()
    {
        Console.WriteLine("=== FILTRAR TAREFAS DE TODOS OS PROJETOS ===");

        Console.WriteLine("1 - Filtrar por status");
        Console.WriteLine("2 - Filtrar por prioridade");

        Console.Write("Escolha: ");
        int tipo = int.Parse(Console.ReadLine());

        if (tipo == 1)
        {
            Console.Write("Digite o status: ");
            string status = Console.ReadLine();

            foreach (Projeto projeto in projetos.listar())
            {
                List<Tarefa> resultado = projeto.tarefasPorStatus(status);

                if (resultado.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Projeto: " + projeto.getNome());

                    mostrarListaTarefas(resultado);
                }
            }
        }
        else if (tipo == 2)
        {
            Console.Write("Digite a prioridade: ");
            int prioridade = int.Parse(Console.ReadLine());

            foreach (Projeto projeto in projetos.listar())
            {
                List<Tarefa> resultado = projeto.tarefasPorPrioridade(prioridade);

                if (resultado.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Projeto: " + projeto.getNome());

                    mostrarListaTarefas(resultado);
                }
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }

    static void mostrarListaTarefas(List<Tarefa> tarefas)
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
            return;
        }

        foreach (Tarefa tarefa in tarefas)
        {
            tarefa.mostrar();
        }
    }

    static void resumoGeral()
    {
        Console.WriteLine("=== RESUMO GERAL ===");

        int totalProjetos = projetos.listar().Count;
        int abertas = 0;
        int fechadas = 0;
        int canceladas = 0;

        foreach (Projeto projeto in projetos.listar())
        {
            abertas += projeto.totalAbertas();
            fechadas += projeto.totalFechadas();
            canceladas += projeto.totalCanceladas();
        }

        int totalTarefas = abertas + fechadas + canceladas;

        double percentual = 0;

        if (abertas + fechadas > 0)
        {
            percentual = ((double)fechadas / (abertas + fechadas)) * 100;
        }

        Console.WriteLine("Quantidade de projetos: " + totalProjetos);
        Console.WriteLine("Total de tarefas: " + totalTarefas);
        Console.WriteLine("Tarefas abertas: " + abertas);
        Console.WriteLine("Tarefas fechadas: " + fechadas);
        Console.WriteLine("Tarefas canceladas: " + canceladas);
        Console.WriteLine("Percentual concluído: " + percentual.ToString("F2") + "%");
    }
}
