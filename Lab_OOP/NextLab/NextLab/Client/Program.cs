using NextLab;
using NextLab.Builder;
using NextLab.ConcreteBuilder;
using NextLab.Product;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder msSqlQueryBuilder = new StringBuilder();
        SqlBuilder<Products> msSqlBuilder = new MsSqlBuilder<Products>(msSqlQueryBuilder);
        var msQuery = msSqlBuilder
            .Select()
            .Where(u => u.Price > 12)
            .OrderBy(_ => _.Price)
            .Take(5)
            .Build();

        StringBuilder postgresSqlQueryBuilder = new StringBuilder();
        SqlBuilder<Products> postgresSqlBuilder = new PostgresSqlBuilder<Products>(postgresSqlQueryBuilder);
        var postgresQuery = postgresSqlBuilder
            .Select()
            .Where(u => u.Price > 12)
            .OrderBy(_ => _.Price)
            .Take(5)
            .Build();

        Console.WriteLine("MSSQL Query:");
        Console.WriteLine(msQuery);

        Console.WriteLine("\n\nPostgreSQL Query:");
        Console.WriteLine(postgresQuery);
    }

}