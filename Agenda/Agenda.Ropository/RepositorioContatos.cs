using System;
using System.Collections.Generic;
using Agenda.DAL;
using Agenda.Domain;

namespace Agenda.Ropository
{
    public class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos (IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid id)
        {
            IContato contato = _contatos.Obter(id);
            List<ITelefone> lstTelefone = _telefones.ObterTodosDoContato(id);
            contato.Telefones = lstTelefone;

            return contato;
        }
    }
}
