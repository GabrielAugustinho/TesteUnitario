using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace Agenda.DAL.Test
{
    class ContatosTestSecao2 : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterTodos()
        {
            // Monta
            var contato1 = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();
            var lstContato = new List<Contato>();
            // Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Where(o => o.Id == contato1.Id).FirstOrDefault();
            // Verifica
            Assert.AreEqual(2, lstContato.Count());
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
