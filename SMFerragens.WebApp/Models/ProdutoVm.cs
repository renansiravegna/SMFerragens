using System.Collections.Generic;
using System.Linq;

namespace SMFerragens.WebApp.Models
{
    public class ProdutoVm
    {
        private decimal? _precoTresMetros;
        private decimal? _precoUnidade;
        private decimal? _precoQuilo;
        private decimal? _precoCento;
        private decimal? _precoCinquenta;
        private decimal? _precoMetro;

        public int CodPro { get; set; }
        public string Nome { get; set; }
        public IEnumerable<FormaDeVenda> FormasDeVenda { get { return Precos.Where(p => p.Valor > 0).Select(p => p.FormaDeVenda).Distinct().ToList(); } }

        private readonly IList<PrecoVm> _precos = new List<PrecoVm>();
        public IEnumerable<PrecoVm> Precos => _precos;

        public decimal? PrecoMetro
        {
            get { return _precoMetro; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.Metro);
                _precoMetro = value;
            }
        }

        public decimal? PrecoTresMetros
        {
            get { return _precoTresMetros; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.TresMetros);
                _precoTresMetros = value;
            }
        }

        public decimal? PrecoUnidade
        {
            get { return _precoUnidade; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.Unidade);
                _precoUnidade = value;
            }
        }

        public decimal? PrecoCinquenta
        {
            get { return _precoCinquenta; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.Cinquenta);
                _precoCinquenta = value;
            }
        }

        public decimal? PrecoCento
        {
            get { return _precoCento; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.Cento);
                _precoCento = value;
            }
        }

        public decimal? PrecoQuilo
        {
            get { return _precoQuilo; }
            set
            {
                AdicionarPreco(value, FormaDeVenda.Quilo);
                _precoQuilo = value;
            }
        }

        private void AdicionarPreco(decimal? preco, FormaDeVenda formaDeVenda)
        {
            _precos.Add(new PrecoVm { FormaDeVenda = formaDeVenda, Valor = preco ?? 0 });
        }

        public IEnumerable<PrecoVm> PrecosPara(IEnumerable<FormaDeVenda> formasDeVenda)
        {
            return Precos.Where(p => formasDeVenda.Contains(p.FormaDeVenda)).OrderBy(p => p.FormaDeVenda).ToList();
        }

        public void AlterarPreco(FormaDeVenda formaDeVenda, decimal novoValor)
        {
        }
    }
}