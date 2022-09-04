#include <iostream>

using namespace std;

int main()
{
    const double PUZZLE = 2.6;
    const double DOLL = 3;
    const double TEDDY_BEAR = 4.10;
    const double MINION = 8.20;
    const double TRUCK = 2;

    double tripPrice;
    int puzzles, dolls, teddyBears, minions, trucks;
    cin >> tripPrice >> puzzles >> dolls >> teddyBears >> minions >> trucks;

    int totalToysCount = puzzles + dolls + teddyBears + minions + trucks;
    double puzzlesTotal = puzzles * PUZZLE;
    double dollsTotal = dolls * DOLL;
    double bearsTotal = teddyBears * TEDDY_BEAR;
    double minionsTotal = minions * MINION;
    double trucksTotal = trucks * TRUCK;
    double total = puzzlesTotal + dollsTotal + bearsTotal + minionsTotal + trucksTotal;

    if (totalToysCount >= 50)
    {
        total *= 0.75;
    }

    total *= 0.9;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (total >= tripPrice)
    {
        cout << "Yes! " << total - tripPrice << " lv left." << endl;
    }

    else
    {
        cout << "Not enough money! " << tripPrice - total << " lv needed." << endl;
    }
}

