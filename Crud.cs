using Microsoft.EntityFrameworkCore;

namespace SQLiteConsole
{
    class Crud
    {
        private GameContext db { get; } = new GameContext();
        private DbSet<Game> games { get => db.Games!; }
        public void Read()
        {

            Console.WriteLine("Listando banco de dados..." + db.DbPath);
            foreach (var index in games)
            {   
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Id Do Game      :  {index.Id}");
                Console.WriteLine($"Nome Do Game    :  {index.Title}");
                Console.WriteLine($"Nome Da Empresa :  {index.Developer}");
                Console.WriteLine("-------------------------------------------------------");
            }
            Console.WriteLine("\n");
        }
        public void Create()
        {
           
            Console.WriteLine($"Banco de dados pronto para inserção. Local: {db.DbPath}.\n");

            Console.Write("Insira o titulo do game: ");
            string ?titulo = Console.ReadLine();

            Console.Write("Insira o nome da desenvolvedora: ");
            string ?dev = Console.ReadLine();

            
            // games.Add(new Game() { Title = titulo!, Developer = dev! });
            db.Add(new Game() { Title = titulo!, Developer = dev! });
            db.SaveChanges();

            Console.WriteLine($"{titulo} | {dev} Incluidos com exito!!!");
            Thread.Sleep(1000);

            Read();

        }
        public void Update()
        {
            Read();

            Console.WriteLine("Insira o ID do elemento da lista que deseja atualizar");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira o titulo do game: ");
            string ?titulo = Console.ReadLine();

            Console.Write("Insira o nome da desenvolvedora: ");
            string ?dev = Console.ReadLine();

            var gm = games.Single(g => g.Id == i);

            gm.Title = titulo!;
            gm.Developer = dev!;

            db.Update(gm);
            db.SaveChanges();

            Console.WriteLine($"{titulo} | {dev} Atualizados com exito!!!");
            Thread.Sleep(1000);

            Read();
        }
        public void Delete()
        {
            Read();

            Console.WriteLine("Deletar dados no banco de dados");

            Console.Write("insira o id da tabela: ");
            int i = Convert.ToInt32(Console.ReadLine());

            var gm = games.Single(g => g.Id == i);
            db.Remove(gm);
            db.SaveChanges();

            Console.WriteLine($"{gm.Id} | {gm.Title} | {gm.Developer} Atualizados com exito!!!");
            Thread.Sleep(1000);

            Read();
        }
    }
}