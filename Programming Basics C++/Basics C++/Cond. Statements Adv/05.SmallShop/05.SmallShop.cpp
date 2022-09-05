#include <iostream>

using namespace std;

int main()
{
    string product, city;
    double quantity;

    cin >> product >> city >> quantity;
    double price;

    //coffee, water, beer, sweets, peanuts

    if (city == "Sofia")
    {
        //0.50	0.80	1.20	1.45	1.60
        if (product == "coffee")
        {
            price = 0.5;
        }

        else if (product == "water")
        {
            price = 0.8;
        }

        else if (product == "beer")
        {
            price = 1.2;
        }

        else if (product == "sweets")
        {
            price = 1.45;
        }

        else if (product == "peanuts")
        {
            price = 1.6;
        }
    }

    else if (city == "Plovdiv")
    {
        //0.40	0.70	1.15	1.30	1.50
        if (product == "coffee")
        {
            price = 0.4;
        }

        else if (product == "water")
        {
            price = 0.7;
        }

        else if (product == "beer")
        {
            price = 1.15;
        }

        else if (product == "sweets")
        {
            price = 1.3;
        }

        else if (product == "peanuts")
        {
            price = 1.5;
        }
    }

    else if (city == "Varna")
    {
        // 0.45	0.70	1.10	1.35	1.55
        if (product == "coffee")
        {
            price = 0.45;
        }

        else if (product == "water")
        {
            price = 0.7;
        }

        else if (product == "beer")
        {
            price = 1.1;
        }

        else if (product == "sweets")
        {
            price = 1.35;
        }

        else if (product == "peanuts")
        {
            price = 1.55;
        }
    }

    cout << quantity * price;
}
