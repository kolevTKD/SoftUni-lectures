#include <iostream>

using namespace std;

int main()
{
    string ticketType;
    int rows, cols;
    cin >> ticketType >> rows >> cols;

    double price = 0;

    if (ticketType == "Premiere")
    {
        price = 12;
    }

    else if (ticketType == "Normal")
    {
        price = 7.5;
    }

    else if (ticketType == "Discount")
    {
        price = 5;
    }

    double total = (rows * cols) * price;

    cout.setf(ios::fixed);
    cout.precision(2);
    cout << total << " leva";
}
