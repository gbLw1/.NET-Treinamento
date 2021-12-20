namespace Aulas.NET.Aula02
{
    class Pessoa
    {
        public decimal Credito { get; set; }

        public void AjustarCredito(decimal valor)
        {
            Credito += valor;
        }
    }

    class Cliente : Pessoa
    {
        // propriedade sem atributo ↓
        public string? Apelido { get; set; }

        // => [Modelo antigo de criação de propriedade] ↓
        //public string Nome
        //{
        //    get { return _Nome; }
        //    set { _Nome = value; }
        //}

        private string? _Nome;
        public string? Nome { get => _Nome; set => _Nome = value; }

        private string? _Sobrenome;
        public string? Sobrenome { get => _Sobrenome; set => _Sobrenome = value; }

        private Guid _Id;
        public Guid Id { get => _Id; set => _Id = value; }

        // => [Construtores] ↓
        public Cliente(decimal creditoInicial = 0)
        {
            Credito = creditoInicial;
        }

        public Cliente(string nome, string sobrenome) : this()
        {
            _Nome = nome;
            _Sobrenome = sobrenome;
        }

        public Cliente(string nome, string sobrenome, decimal creditoInicial) : this(creditoInicial)
        {
            _Nome = nome;
            _Sobrenome = sobrenome;
        }
    }
}
