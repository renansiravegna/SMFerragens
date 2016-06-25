using NUnit.Framework;
using SMFerragens.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SMFerragens.WebApp._Tests
{
    [TestFixture]
    public class ProdutoVmTeste
    {
        private ProdutoVm _produtoVm;

        [SetUp]
        public void SetUp()
        {
            _produtoVm = new ProdutoVm();
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_metro()
        {
            const decimal novoPreco = 10;

            _produtoVm.AlterarPreco(FormaDeVenda.Metro, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoMetro);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_tres_metros()
        {
            const decimal novoPreco = 100;

            _produtoVm.AlterarPreco(FormaDeVenda.TresMetros, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoTresMetros);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_unidade()
        {
            const decimal novoPreco = 1000;

            _produtoVm.AlterarPreco(FormaDeVenda.Unidade, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoUnidade);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_50_unidades()
        {
            const decimal novoPreco = 10000;

            _produtoVm.AlterarPreco(FormaDeVenda.Cinquenta, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoCinquenta);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_cento()
        {
            const decimal novoPreco = 100000;

            _produtoVm.AlterarPreco(FormaDeVenda.Cento, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoCento);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_alterar_apenas_o_preco_por_quilo()
        {
            const decimal novoPreco = 1000000;

            _produtoVm.AlterarPreco(FormaDeVenda.Quilo, novoPreco);

            Assert.AreEqual(novoPreco, _produtoVm.PrecoQuilo);
            Assert.AreEqual(1, _produtoVm.Precos.Count());
        }

        [Test]
        public void Deve_permitir_obter_todos_os_precos_diversas_vezes_sem_duplicar_a_lista()
        {
            _produtoVm.AlterarPreco(FormaDeVenda.Unidade, 1);
            var precos = _produtoVm.Precos;

            precos = _produtoVm.Precos;

            Assert.AreEqual(1, precos.Count());
        }

        [TestCase(FormaDeVenda.Metro)]
        [TestCase(FormaDeVenda.TresMetros)]
        [TestCase(FormaDeVenda.Unidade)]
        [TestCase(FormaDeVenda.Cinquenta)]
        [TestCase(FormaDeVenda.Cento)]
        [TestCase(FormaDeVenda.Quilo)]
        public void Deve_obter_precos_por_forma_de_venda(FormaDeVenda formaDeVenda)
        {
            _produtoVm.AlterarPreco(formaDeVenda, 10);

            var precos = _produtoVm.PrecosPara(new List<FormaDeVenda> { formaDeVenda });

            Assert.AreEqual(1, precos.Count());
            Assert.IsTrue(precos.All(preco => preco.FormaDeVenda == formaDeVenda));
        }
    }
}