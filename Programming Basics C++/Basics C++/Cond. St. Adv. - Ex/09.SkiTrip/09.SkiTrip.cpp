#include <iostream>
#include <string>

using namespace std;

int main()
{
    int daysOfStay;
    cin >> daysOfStay;
    string roomType;
    getline(cin >> ws, roomType);
    string rating;
    cin >> rating;

    double price = 0;
    double total = 0;
    daysOfStay -= 1;

    if (roomType == "room for one person")
    {
        price = 18;
        total = daysOfStay * price;
    }

    else if (roomType == "apartment")
    {
        price = 25;

        if (daysOfStay <= 10)
        {
            total = (daysOfStay * price) * 0.7;
        }

        else if (daysOfStay <= 15)
        {
            total = (daysOfStay * price) * 0.65;
        }

        else if (daysOfStay > 15)
        {
            total = (daysOfStay * price) * 0.5;
        }
    }

    else if (roomType == "president apartment")
    {
        price = 35;

        if (daysOfStay <= 10)
        {
            total = (daysOfStay * price) * 0.9;
        }

        else if (daysOfStay <= 15)
        {
            total = (daysOfStay * price) * 0.85;
        }

        else if (daysOfStay > 15)
        {
            total = (daysOfStay * price) * 0.8;
        }
    }

    if (rating == "positive")
    {
        total *= 1.25;
    }

    else if (rating == "negative")
    {
        total *= 0.9;
    }
    cout.setf(ios::fixed);
    cout.precision(2);
    cout << total;
}

