
List<Usuario> nomes = new List<Usuario>
{
    new Usuario{Id = 1, Nome = "usuario1"},
    new Usuario{Id = 2, Nome = "usuario2"},
    new Usuario{Id = 3, Nome = "usuario3"}
};

nomes.Add(new Usuario { Id = 4, Nome = "usuario4" });

List<Funcionario> funcionarios = new List<Funcionario>
{
    new Funcionario{Id = 1, Nome = "funcionario1", Campo = "pescador de ilusão"},
    new Funcionario{Id = 2, Nome = "funcionario2", Campo = "secador de gelo"},
};

//--------------------------------------------------

var result = nomes
            .Join(funcionarios,
                nomes => nomes.Id, funcionarios => funcionarios.Id,
                (nomes, funcionarios) => new { Nomes = nomes, Funcionarios = funcionarios })
            .Select(a => new
            {
                Id = a.Nomes.Id,
                Nome = a.Nomes.Nome,
                Cargo = a.Funcionarios?.Campo
            })
            .ToList();


foreach (var item in result)
{
    Console.WriteLine($"{item.Id} - {item.Nome} - {item.Cargo}");
}

//--------------------------------------------------

var resultleft = nomes
                .GroupJoin(funcionarios,
                    nomes => nomes.Id, funcionarios => funcionarios.Id,
                    (nomes, funcionarios) => new { Nomes = nomes, Funcionarios = funcionarios.FirstOrDefault() })
                .Select(a => new
                {
                    Id = a.Nomes.Id,
                    Nome = a.Nomes.Nome,
                    Cargo = a.Funcionarios?.Campo
                })
                .ToList();

foreach (var item in resultleft)
{
    Console.WriteLine($"{item.Id} - {item.Nome} - {item.Cargo}");
}

//--------------------------------------------------

List<Usuario> Lista()
{
    var result = nomes
                .Join(funcionarios,
                    nomes => nomes.Id, funcionarios => funcionarios.Id,
                    (nomes, funcionarios) => new { Nomes = nomes, Funcionarios = funcionarios })
                .Select(a => new Usuario
                {
                    Id = a.Nomes.Id,
                    Nome = a.Nomes.Nome,
                    Cargo = a.Funcionarios?.Campo
                })
                .ToList();

    return result;

}

List<Usuario> ListaLeft()
{
    var resultleft = nomes
                    .GroupJoin(funcionarios,
                        nomes => nomes.Id, funcionarios => funcionarios.Id,
                        (nomes, funcionarios) => new { Nomes = nomes, Funcionarios = funcionarios.FirstOrDefault() })
                    .Select(uai => new Usuario
                    {
                        Id = uai.Nomes.Id,
                        Nome = uai.Nomes.Nome,
                        Cargo = uai.Funcionarios?.Campo
                    }).ToList();

    return resultleft;
}

Console.WriteLine("-----lista------");
foreach (var item in Lista())
{
    Console.WriteLine($"{item.Id} - {item.Nome} - {item.Cargo}");
}

Console.WriteLine("-----left------");
foreach (var item in ListaLeft())
{
    Console.WriteLine($"{item.Id} - {item.Nome} - {item.Cargo}");
}

//--------------------------------------------------

class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
}

class Funcionario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Campo { get; set; }
}
