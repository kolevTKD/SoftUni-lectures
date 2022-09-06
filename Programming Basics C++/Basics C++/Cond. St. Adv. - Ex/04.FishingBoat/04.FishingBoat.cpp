#include <iostream>

using namespace std;

int main()
{
    int budget, fishermans;
    string season;
    int boatPrice = 0;
    double total = 0;

    cin >> budget >> season >> fishermans;

    if (season == "Spring")
    {
        boatPrice = 3000;
    }

    else if (season == "Summer" || season == "Autumn")
    {
        boatPrice = 4200;
    }

    else if (season == "Winter")
    {
        boatPrice = 2600;
    }

    if (fishermans <= 6)
    {
        total = boatPrice * 0.9;
    }

    else if (fishermans <= 11)
    {
        total = boatPrice * 0.85;
    }

    else if (fishermans >= 12)
    {
        total = boatPrice * 0.75;
    }

    if (fishermans % 2 == 0 && season != "Autumn")
    {
        total *= 0.95;
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    if (total <= budget)
    {
        cout << "Yes! You have " << budget - total << " leva left.";
    }

    else
    {
        cout << "Not enough money! You need " << total - budget << " leva.";
    }
}
