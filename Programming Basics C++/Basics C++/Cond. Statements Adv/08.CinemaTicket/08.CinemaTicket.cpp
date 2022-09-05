#include <iostream>

using namespace std;

int main()
{
    //12	12	14	14	12	16	16
    string dayOfWeek;
    cin >> dayOfWeek;

    int ticketPrice = 0;

    if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Friday")
    {
        ticketPrice = 12;
    }

    else if (dayOfWeek == "Wednesday" || dayOfWeek == "Thursday")
    {
        ticketPrice = 14;
    }

    else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
    {
        ticketPrice = 16;
    }

    cout << ticketPrice;
}
