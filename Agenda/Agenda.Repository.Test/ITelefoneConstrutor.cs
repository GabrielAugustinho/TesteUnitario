using Agenda.Domain;
using System;
using AutoFixture;

namespace Agenda.Repository.Test
{
    public class ITelefoneConstrutor : BaseConstrutor<ITelefone>
    {
        //Criar moq de ITelefone
        protected ITelefoneConstrutor() : base() { }

        public static ITelefoneConstrutor Um()
        {
            return new ITelefoneConstrutor();
        }

        public ITelefoneConstrutor Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixure.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixure.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixure.Create<Guid>());

            return this;
        }

        public ITelefoneConstrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ITelefoneConstrutor ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstrutor ComContatoId(Guid contatoid)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(contatoid);
            return this;
        }
    }
}
