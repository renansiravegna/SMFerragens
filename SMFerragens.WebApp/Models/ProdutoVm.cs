using System;
using System.Collections.Generic;
using System.Linq;

namespace SMFerragens.WebApp.Models
{
    public class ProdutoVm
    {
        public int CodPro { get; set; }
        public string Nome { get; set; }
        public decimal? PrecoMetro { get; set; }
        public decimal? PrecoTresMetros { get; set; }
        public decimal? PrecoUnidade { get; set; }
        public decimal? PrecoCinquenta { get; set; }
        public decimal? PrecoCento { get; set; }
        public decimal? PrecoQuilo { get; set; }

        public IEnumerable<FormaDeVenda> FormasDeVenda { get { return Precos.Where(p => p.Valor > 0).Select(p => p.FormaDeVenda).Distinct().ToList(); } }

        private readonly IList<PrecoVm> _precos = new List<PrecoVm>(); 
        public IEnumerable<PrecoVm> Precos
        {
            get
            {
                _precos.Clear();

                AdicionarPreco(PrecoMetro, FormaDeVenda.Metro);
                AdicionarPreco(PrecoTresMetros, FormaDeVenda.TresMetros);
                AdicionarPreco(PrecoUnidade, FormaDeVenda.Unidade);
                AdicionarPreco(PrecoCinquenta, FormaDeVenda.Cinquenta);
                AdicionarPreco(PrecoCento, FormaDeVenda.Cento);
                AdicionarPreco(PrecoQuilo, FormaDeVenda.Quilo);

                return _precos;
            }
        }

        private void AdicionarPreco(decimal? preco, FormaDeVenda formaDeVenda)
        {
            if (preco.HasValue)
                _precos.Add(new PrecoVm { FormaDeVenda = formaDeVenda, Valor = preco ?? 0 });
        }

        public IEnumerable<PrecoVm> PrecosPara(IEnumerable<FormaDeVenda> formasDeVenda)
        {
            return Precos.Where(p => formasDeVenda.Contains(p.FormaDeVenda)).OrderBy(p => p.FormaDeVenda).ToList();
        }

        public void AlterarPreco(FormaDeVenda formaDeVenda, decimal novoValor)
        {
            switch (formaDeVenda)
            {
                case FormaDeVenda.Metro:
                    PrecoMetro = novoValor;
                    break;

                case FormaDeVenda.TresMetros:
                    PrecoTresMetros = novoValor;
                    break;

                case FormaDeVenda.Unidade:
                    PrecoUnidade = novoValor;
                    break;

                case FormaDeVenda.Cinquenta:
                    PrecoCinquenta = novoValor;
                    break;

                case FormaDeVenda.Cento:
                    PrecoCento = novoValor;
                    break;

                case FormaDeVenda.Quilo:
                    PrecoQuilo = novoValor;
                    break;

                default:
                    throw new Exception("Forma de venda não encontrada");
            }
        }
    }
}