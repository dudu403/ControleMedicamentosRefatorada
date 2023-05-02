﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{    
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descricaco;
        public string lote;
        public DateTime validade;
        public int quantidade;
        public Fornecedor fornecedor;

        public int quantidadeRequisicoesSaida;

        public Medicamento(string nome, string descricaco, string lote, DateTime validade, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricaco = descricaco;
            this.lote = lote;
            this.validade = validade;
            this.fornecedor = fornecedor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Medicamento medicamentoAtualizado = (Medicamento)registroAtualizado;

            this.nome = medicamentoAtualizado.nome;
            this.descricaco = medicamentoAtualizado.descricaco;
            this.lote = medicamentoAtualizado.lote;
            this.validade = medicamentoAtualizado.validade;
            this.fornecedor = medicamentoAtualizado.fornecedor;
        }

        public void AdicionarQuantidade(int qtd)
        {
            this.quantidade += qtd;
        }

        public void RemoverQuantidade(int qtd)
        {
            quantidadeRequisicoesSaida++;
            this.quantidade -= qtd;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            DateTime hoje = DateTime.Now.Date;

            if (validade < hoje)
                erros.Add("O campo \"validade\" não pode ser menor que a data atual");

            if (fornecedor == null)
                erros.Add("O campo \"fornecedor\" é obrigatório");

            if (quantidade < 0)
                erros.Add("O campo \"quantidade\" não pode ser menor que 0");

            return erros;
        }

      
    }
}
