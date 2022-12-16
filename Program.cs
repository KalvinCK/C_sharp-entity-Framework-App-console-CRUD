using Microsoft.EntityFrameworkCore;

namespace SQLiteConsole
{
    class Program
    {
        private static Crud crud = new Crud();
        static void Main()
        {

            crud.Read();

            bool loop = true;
            while(loop)
            {
                Console.WriteLine("-------------------------------------------CRUD----------------------------------------------");
                Console.WriteLine("Pressione... 1 : Criar | 2 : Atualizar | 3 : Deletar | 4 : Listar | 0 : sair");
                Console.WriteLine("---------------------------------------------------------------------------------------------");

                int input = 0;
                if(!int.TryParse(Console.ReadLine(), out input))
                {
                    input = 4;
                }

                if(input == 0) loop = false;
                else if(input == 1) crud.Create();
                else if(input == 2) crud.Update();
                else if(input == 3) crud.Delete();
                else if(input == 4) crud.Read();

            }

        }
    }
}