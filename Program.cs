using System.Text.RegularExpressions;

class Product
{
    public int Index { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public string? Category { get; set; }
    public double Price { get; set; }
    public string? Currency { get; set; }
    public int Stock { get; set; }
    public string? EAN { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Availability { get; set; }
    public string? InternalID { get; set; }

    public override string ToString()
    {
        return $"[{Index} ## {Name} ## {Description} ## {Brand} ## {Category} ## {Price} ## {Currency} ## {Stock} ## {EAN} ## {Color} ## {Size} ## {Availability} ## {InternalID}]";
    }
}
class Lista
{
    public List<Product> Produtos = new List<Product>();

    public void Insercao(Product product)
    {
        Produtos.Add(product);
    }
    public void Remocao(int id)
    {
        for (int i = 0; i < Produtos.Count; i++)
        {
            if (Produtos[i].Index == id)
            {
                Produtos.RemoveAt(i);
                break;
            }
        }

    }
    public List<Product> Pesquisa(string atributo, string valor)
    {
        atributo = atributo.ToLower().Trim();
        valor = valor.ToLower().Trim();

        List<Product> produtosAchados = new List<Product>();

        foreach (var item in Produtos)
        {
            switch (atributo)
            {
                case "index":
                    string index = Convert.ToString(item.Index);
                    if (index == valor)
                        produtosAchados.Add(item);
                    break;

                case "name":
                    if (item.Name?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "description":
                    if (item.Description?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "brand":
                    if (item.Brand?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "category":
                    if (item.Category?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "price":
                    string price = Convert.ToString(item.Price);
                    if (price == valor)
                        produtosAchados.Add(item);
                    break;

                case "currency":
                    if (item.Currency?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "stock":
                    string stock = Convert.ToString(item.Stock);
                    if (stock == valor)
                        produtosAchados.Add(item);
                    break;

                case "ean":
                    if (item.EAN?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "color":
                    if (item.Color?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "size":
                    if (item.Size?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "availability":
                    if (item.Availability?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                case "internal id":
                case "internalid":
                    if (item.InternalID?.ToLower().Contains(valor) == true)
                        produtosAchados.Add(item);
                    break;

                default:
                    Console.WriteLine("Atributo inválido.");
                    break;
            }
        }

        return produtosAchados;
    }
    public void ListagemElementos()
    {
        foreach (var item in Produtos)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
class Metodos
{
    public void CarregarArquivo(Lista lista)
    {
        Console.WriteLine("Escolha o tamanho do arquivo (100, 1000, 10000 ou 100000):");
        string tamanho = Console.ReadLine();

        string caminho = $"data/products_{tamanho}.csv";

        if (File.Exists(caminho))
        {
            Console.WriteLine($"\nArquivo encontrado: {caminho}\n");
            Stream entrada = File.Open(caminho, FileMode.Open);

            StreamReader leitor = new StreamReader(entrada);

            string linha = leitor.ReadLine();
            linha = leitor.ReadLine();

            Console.WriteLine("Carregando dados...");

            while (linha != null)
            {
                string[] campos = Regex.Split(linha, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");


                Product p = new Product();

                p.Index = int.Parse(campos[0]);
                p.Name = campos[1];
                p.Description = campos[2];
                p.Brand = campos[3];
                p.Category = campos[4];
                p.Price = double.Parse(campos[5]);
                p.Currency = campos[6];
                p.Stock = int.Parse(campos[7]);
                p.EAN = campos[8];
                p.Color = campos[9];
                p.Size = campos[10];
                p.Availability = campos[11];
                p.InternalID = campos[12];

                lista.Insercao(p);

                linha = leitor.ReadLine();
            }

            leitor.Close();
            entrada.Close();

            Console.WriteLine("\nArquivo carregado com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado!");
        }
    }
    public void InserirManual(Lista lista)
    {
        Product p = new Product();

        Console.Write("Index: ");
        p.Index = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Description: ");
        p.Description = Console.ReadLine();

        Console.Write("Brand: ");
        p.Brand = Console.ReadLine();

        Console.Write("Category: ");
        p.Category = Console.ReadLine();

        Console.Write("Price: ");
        p.Price = double.Parse(Console.ReadLine());

        Console.Write("Currency: ");
        p.Currency = Console.ReadLine();

        Console.Write("Stock: ");
        p.Stock = int.Parse(Console.ReadLine());

        Console.Write("EAN: ");
        p.EAN = Console.ReadLine();

        Console.Write("Color: ");
        p.Color = Console.ReadLine();

        Console.Write("Size: ");
        p.Size = Console.ReadLine();

        Console.Write("Availability: ");
        p.Availability = Console.ReadLine();

        Console.Write("Internal ID: ");
        p.InternalID = Console.ReadLine();

        lista.Insercao(p);

        Console.WriteLine("\nProduto inserido com sucesso!");
    }
}
class Program
{
    static void Main()
    {
        Metodos m = new Metodos();
        Lista lista = new Lista();
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("1 - Carregar arquivo CSV");
            Console.WriteLine("2 - Listar elementos");
            Console.WriteLine("3 - Pesquisar");
            Console.WriteLine("4 - Remover pelo Index");
            Console.WriteLine("5 - Inserir manualmente");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha: ");

            string opc = Console.ReadLine();

            switch (opc)
            {
                case "1":
                    m.CarregarArquivo(lista);
                    break;

                case "2":
                    lista.ListagemElementos();
                    break;

                case "3":
                    Console.Write("Atributo para pesquisar: ");
                    string atributo = Console.ReadLine();

                    Console.Write("Valor: ");
                    string valor = Console.ReadLine();

                    var encontrados = lista.Pesquisa(atributo, valor);

                    foreach (var p in encontrados)
                        Console.WriteLine(p);

                    if (encontrados.Count == 0)
                        Console.WriteLine("Nada encontrado.");
                    break;

                case "4":
                    Console.Write("Index do produto a remover: ");
                    int id = int.Parse(Console.ReadLine());
                    lista.Remocao(id);
                    Console.WriteLine("Removido.");
                    break;

                case "5":
                    m.InserirManual(lista);
                    break;

                case "6":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
