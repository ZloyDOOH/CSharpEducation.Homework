using System.ComponentModel.Design;

namespace TicTacToe;

class Program
{
    static void isVictory(string Player1, string Player2, bool isStepPlayer1, char[][] arrField)
    {
        char findCharPlayer;
        if (isStepPlayer1)
            findCharPlayer = 'Х';
        else
            findCharPlayer = '0';
        
        if (((arrField[0][0] == findCharPlayer) && (arrField[0][1] == findCharPlayer) && (arrField[0][2] == findCharPlayer)) ||
            ((arrField[1][0] == findCharPlayer) && (arrField[1][1] == findCharPlayer) && (arrField[1][2] == findCharPlayer)) ||
            ((arrField[2][0] == findCharPlayer) && (arrField[2][1] == findCharPlayer) && (arrField[2][2] == findCharPlayer)) ||
            ((arrField[0][0] == findCharPlayer) && (arrField[1][0] == findCharPlayer) && (arrField[2][0] == findCharPlayer)) ||
            ((arrField[0][1] == findCharPlayer) && (arrField[1][1] == findCharPlayer) && (arrField[2][1] == findCharPlayer)) ||
            ((arrField[0][2] == findCharPlayer) && (arrField[1][2] == findCharPlayer) && (arrField[2][2] == findCharPlayer)) ||
            ((arrField[0][0] == findCharPlayer) && (arrField[1][1] == findCharPlayer) && (arrField[2][2] == findCharPlayer)) ||
            ((arrField[0][2] == findCharPlayer) && (arrField[1][1] == findCharPlayer) && (arrField[2][0] == findCharPlayer)))
        {
            if (isStepPlayer1)
                Console.WriteLine($"Победил игрок: {Player1}!!!!!!!!! УРА !!!!!"); 
            else
                Console.WriteLine($"Победил игрок: {Player2}!!!!!!!!! УРА !!!!!");
            
            // пауза 10 секунд для просмотра результата
            Thread.Sleep(10000);
            // выход из программы
            Environment.Exit(0);
        }
    }
    
    static void WriteField(string Player1, string Player2, int stepGame, bool isStepPlayer1, char[][] arrField)
    {
        // очистка консоли
        Console.Clear();
        // вывод назнвания игры
        Console.WriteLine("Игра крестики нолики");
        //вывод текущего ода игры
        if (stepGame > 1)
            Console.WriteLine($"{stepGame} ход игры");
        else
            Console.WriteLine($"Начало игры ");
        //вывод информации кто играет ноликами, а кто крестиками
        Console.WriteLine($"{Player1} играет крестиками, а {Player2} играет ноликами");
        // вывод игрового поля
        Console.WriteLine($"        \u2554\u2550\u2550\u2550\u2564\u2550\u2550\u2550\u2564\u2550\u2550\u2550\u2557");
        Console.WriteLine($"   1    \u2551 {arrField[0][0]} \u2502 {arrField[0][1]} \u2502 {arrField[0][2]} \u2551");
        Console.WriteLine($"        \u255F\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u2562");
        Console.WriteLine($"   2    \u2551 {arrField[1][0]} \u2502 {arrField[1][1]} \u2502 {arrField[1][2]} \u2551");
        Console.WriteLine($"        \u255F\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u2562");
        Console.WriteLine($"   3    \u2551 {arrField[2][0]} \u2502 {arrField[2][1]} \u2502 {arrField[2][2]} \u2551");
        Console.WriteLine($"        \u255A\u2550\u2550\u2550\u2567\u2550\u2550\u2550\u2567\u2550\u2550\u2550\u255D");
        Console.WriteLine($"          1   2   3");
        isVictory(Player1, Player2, isStepPlayer1, arrField);
    }

    static void Main(string[] args)
    {
        // определяем чей ход
        bool isStepPlayer1 = true;
        // заполняем информацию по первому игроку
        Console.Write("Введите имя первого игрока: ");
        string Player1 = Console.ReadLine();
        // заполняем информацию по второму игроку
        Console.Write("Введите имя второго игрока: ");
        string Player2 = Console.ReadLine();
        // счетчик ходов
        int stepGame = 1;
        int rowNum;
        int colNum;
        // данные игрового поля 3 строки, 3 столбца
        char[][] arrField =
        {
            new char[3] { ' ', ' ', ' ' },
            new char[3] { ' ', ' ', ' ' },
            new char[3] { ' ', ' ', ' ' }
        };
        // текущее имя игока
        string namePlayer;
        // текущий символ
        char currentChar;
        // начинаем игру
        do
        {
            do 
            {
                // рисуем игровое поле
                WriteField (Player1, Player2, stepGame, isStepPlayer1, arrField);
                // определяем чей ход
                if ((stepGame % 2) == 0)
                {
                    isStepPlayer1 = false;
                    namePlayer =  Player2;
                    currentChar = '0';
                }
                else
                {
                    isStepPlayer1 = true;
                    namePlayer = Player1;
                    currentChar = 'Х';
                }
                Console.WriteLine($"{namePlayer} ваш ход.");
                Console.Write($"{namePlayer} введите номер строки:");
                rowNum = int.Parse(Console.ReadLine());
                Console.Write($"{namePlayer} введите номер столбца:");
                colNum = int.Parse(Console.ReadLine());
                
            } while (arrField[rowNum-1][colNum-1] != ' ');
            // устанавливаем текущий символ в поле
            arrField[rowNum-1][colNum-1] = currentChar;  
            WriteField (Player1, Player2, stepGame, isStepPlayer1, arrField);
            isVictory(Player1, Player2, isStepPlayer1, arrField);
            stepGame++;
        } while (stepGame <= 9);
        Console.WriteLine("Победила дружба !!!! Ничья !!!!");
    }
}
