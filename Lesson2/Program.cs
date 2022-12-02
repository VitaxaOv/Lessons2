
// 9. Напишите программу, которая выводит случайное число 
// из отрезка [10, 99] и показывает наибольшую цифру числа.
// 78 -> 8 12-> 2 85 -> 8

bool isParsed = false;
int number = 0;
while (isParsed == false)
{
    isParsed = int.TryParse(Console.ReadLine(), out number);
    if(isParsed == false)
    {
        Console.WriteLine("Пиши числа!");
    }
}












if (1 % 7 == 0 | 5 % 23 == 0)
{

}

if (true || (5 % 23 == 0 | 6 % 4 == 0))
{

}

if (false & true)
{

}

if (false && true)
{

}





















Random random = new Random();
int randomNumber = random.Next(10, 100);

int lastDigit = randomNumber % 10;
int firstDigit = randomNumber / 10;

//double tmp = (double)randomNumber / 10;

//Console.WriteLine(tmp);

Console.WriteLine(randomNumber);

if (lastDigit > firstDigit)
{
    Console.WriteLine(lastDigit);
}
else
{
    Console.WriteLine(firstDigit);
}


