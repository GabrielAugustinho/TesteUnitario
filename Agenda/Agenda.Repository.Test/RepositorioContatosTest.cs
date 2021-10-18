using System;
using System.Collections.Generic;
using Agenda.DAL;
using Agenda.Domain;
using NUnit.Framework;
using Moq;
using Agenda.Ropository;

namespace Agenda.Repository.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);

        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();
            var lstTelefone = new List<ITelefone>();
            //Monta

            //Criar moq de IContato
            var mContato = IContatoContrutor.Um().ComId(contatoId).ComNome("Gabriel").Obter();
            /*Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(contatoId);
            mContato.SetupGet(o => o.Nome).Returns("Gabriel");*/
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>()).Callback<List<ITelefone>>(p => lstTelefone = p);
            
            //Moq da função ObterPorId de IContatos
            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            //Criar moq de ITelefone
            var mockTelefone = ITelefoneConstrutor.Um().Padrao().ComId(telefoneId).ComContatoId(contatoId).Construir();
            /*mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(telefoneId);
            mTelefone.SetupGet(o => o.Numero).Returns("(12) 99657-9079");
            mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);*/

            //Moq da função ObterTodosDoContato de ITelefones
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mockTelefone });
            
            //Executa
            //Chamar o metodo ObterPorId de RepositoryContatos
            var contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            //verifica
            //Verificar se o Contato retornado contain os mesmos dados do Moq IContato com a lista de telefones do Moq ITelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
