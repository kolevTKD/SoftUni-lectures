#include <iostream>

using namespace std;

int main()
{
    int startingHours, startingMinutes;
    cin >> startingHours >> startingMinutes;

    int timeInMinutes = startingHours * 60 + startingMinutes;
    int timePlus15 = timeInMinutes + 15;
    int hours = timePlus15 / 60;
    int minutes = timePlus15 % 60;

    if (hours >= 24)
    {
        hours = 0;
    }

    if (minutes < 10)
    {
        cout << hours << ":0" << minutes;
    }

    else
    {
        cout << hours << ':' << minutes;
    }
}
