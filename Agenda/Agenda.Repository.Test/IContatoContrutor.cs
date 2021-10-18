using Agenda.Domain;
using System;

namespace Agenda.Repository.Test
{
    class IContatoContrutor : BaseConstrutor<IContato>
    {
        protected IContatoContrutor() : base() { }

        public static IContatoContrutor Um()
        {
            return new IContatoContrutor();
        }

        public IContatoContrutor ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

        public IContatoContrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}
