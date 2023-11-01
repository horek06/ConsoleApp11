Obj[,] field = new Obj[10, 10];

Random rand = new Random();
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        int s = rand.Next(0, 10);
        if (s >= 0 && s <= 3)
        {
            field[i, j] = new Wall();
        }
        else
        {
            field[i, j] = new Empty();
        }
    }
}
field[5, 5] = new Person();
Print();
while (true)
{
    var key = Console.ReadKey();
    int indi = 0;
    int indj = 0;
    Person ps = null;
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (field[i, j] is Person p)
            {
                ps = p;
                indj = j;
                indi = i;
            }
        }
    }

    if (key.Key == ConsoleKey.UpArrow)
    {
        if (field[indi - 1, indj] is Empty e)
        {
            field[indi, indj] = new Empty();
            field[indi - 1, indj] = ps;
        }

    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        if (field[indi + 1, indj] is Empty e)
        {
            field[indi, indj] = new Empty();
            field[indi + 1, indj] = ps;
        }

    }
    if (key.Key == ConsoleKey.LeftArrow)
    {
        if (field[indi, indj - 1] is Empty e)
        {
            field[indi, indj] = new Empty();
            field[indi, indj - 1] = ps;
        }

    }
    if (key.Key == ConsoleKey.RightArrow)
    {
        if (field[indi, indj + 1] is Empty e)
        {
            field[indi, indj] = new Empty();
            field[indi, indj + 1] = ps;
        }

    }


    Console.Clear();
    Print();
}



void Print()
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Console.Write(field[i, j] + " ");
        }
        Console.WriteLine();
    }
}


public abstract class Obj
{
    public string S { get; set; }

    public override string ToString()
    {
        return S;
    }
}

public class Person : Obj
{
    public Person()
    {
        S = "P";
    }
}

public class Empty : Obj
{
    public Empty()
    {
        S = " ";
    }
}

public class Wall : Obj
{
    public Wall()
    {
        S = "#";
    }
}
