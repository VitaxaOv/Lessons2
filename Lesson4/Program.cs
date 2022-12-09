//Задача 24: Напишите программу, которая принимает на вход число (А) 
//и выдаёт сумму чисел от 1 до А.
//7 -> 28 4 -> 10 8 -> 36

/*int a = int.Parse(Console.ReadLine());
int sum = GetSumNumbersBetweenOneToNumber(a);
Console.WriteLine(sum);

int GetSumNumbersBetweenOneToNumber(int number)
{
    int sum = 0;
    for (var i = 1; i <= number; i++)
    {
        sum += i;
    }

    return sum;
}*/

int[] numbers = new int[]{12,3,23};
PrintArray(numbers);
void PrintArray(int[] array)
{
    Console.Write("[");
    for (var i = 0; i < array.Length-1; i++)
    {
        Console.Write($"{array[i]},");
    }
    Console.Write(array[array.Length-1]);
    Console.Write("]");
}

Math.Pow(234,2);

int Pow(){
    
}


