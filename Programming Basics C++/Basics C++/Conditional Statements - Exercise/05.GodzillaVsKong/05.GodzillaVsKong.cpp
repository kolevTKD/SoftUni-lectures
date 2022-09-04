#include <iostream>

using namespace std;

int main()
{
    double budget, pricePerExtra;
    int extras;
    cin >> budget >> extras >> pricePerExtra;

    double decor = budget * 0.1;
    double clothingTotal = extras * pricePerExtra;

    if (extras > 150)
    {
        clothingTotal *= 0.9;
    }

    double total = decor + clothingTotal;

    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget >= total)
    {
        cout << "Action!\nWingard starts filming with " << budget - total << " leva left.";
    }

    else
    {
        cout << "Not enough money!\nWingard needs " << total - budget << " leva more.";
    }
}
