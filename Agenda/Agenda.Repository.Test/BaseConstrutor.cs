using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repository.Test
{
    public class BaseConstrutor<T> where T : class
    {
        protected readonly Fixture _fixure;
        protected readonly Mock<T> _mock;

        protected BaseConstrutor()
        {
            _fixure = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return _mock.Object;
        }

        public Mock<T> Obter()
        {
            return _mock;
        }
    }
}
