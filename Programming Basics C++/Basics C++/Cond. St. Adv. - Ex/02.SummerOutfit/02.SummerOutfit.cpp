#include <iostream>

using namespace std;

int main()
{
    int degrees;
    string dayTime;
    string outfit, shoes;
    cin >> degrees >> dayTime;

    if (dayTime == "Morning")
    {
        if (degrees >= 10 && degrees <= 18)
        {
            outfit = "Sweatshirt";
            shoes = "Sneakers";
        }

        else if (degrees >= 19 && degrees <=24)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }

        else if (degrees >= 25)
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }
    }

    else if (dayTime == "Afternoon")
    {
        if (degrees >= 10 && degrees <= 18)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }

        else if (degrees >= 19 && degrees <= 24)
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }

        else if (degrees >= 25)
        {
            outfit = "Swim Suit";
            shoes = "Barefoot";
        }
    }

    else if (dayTime == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }

    cout << "It's " << degrees << " degrees, get your " << outfit << " and " << shoes << ".";
}
