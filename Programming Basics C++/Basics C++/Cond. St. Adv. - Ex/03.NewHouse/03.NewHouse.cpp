#include <iostream>

using namespace std;

int main()
{
    string flowerType;
    int flowersNum, budget;
    cin >> flowerType >> flowersNum >> budget;
    double flowerPrice = 0;
    double total = 0;

    if (flowerType == "Roses")
    {
        flowerPrice = 5;

        total = flowersNum > 80
            ? (flowerPrice * flowersNum) * 0.9
            : flowerPrice * flowersNum;
    }

    else if (flowerType == "Dahlias")
    {
        flowerPrice = 3.8;

        total = flowersNum > 90
            ? (flowerPrice * flowersNum) * 0.85
            : flowerPrice * flowersNum;
    }

    else if (flowerType == "Tulips")
    {
        flowerPrice = 2.8;

        total = flowersNum > 80
            ? (flowerPrice * flowersNum) * 0.85
            : flowerPrice * flowersNum;
    }

    else if (flowerType == "Narcissus")
    {
        flowerPrice = 3;

        total = flowersNum < 120
            ? (flowerPrice * flowersNum) * 1.15
            : flowerPrice * flowersNum;
    }

    else if (flowerType == "Gladiolus")
    {
        flowerPrice = 2.5;

        total = flowersNum < 80
            ? (flowerPrice * flowersNum) * 1.2
            : flowerPrice * flowersNum;
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget >= total)
    {
        cout << "Hey, you have a great garden with " << flowersNum << " " << flowerType << " and " << budget - total << " leva left.";
    }

    else
    {
        cout << "Not enough money, you need " << total - budget << " leva more.";
    }
}
