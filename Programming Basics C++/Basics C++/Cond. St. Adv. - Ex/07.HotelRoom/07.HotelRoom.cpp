#include <iostream>

using namespace std;

int main()
{
    string month;
    int nightsIn;
    cin >> month >> nightsIn;

    double studioPrice = 0;
    double apartmentPrice = 0;

    if (month == "May" || month == "October")
    {
        studioPrice = 50;
        apartmentPrice = 65;

        if (nightsIn > 7 && nightsIn <= 14)
        {
            studioPrice *= 0.95;
        }

        else if (nightsIn > 14)
        {
            studioPrice *= 0.7;
        }
    }

    else if (month == "June" || month == "September")
    {
        studioPrice = 75.2;
        apartmentPrice = 68.7;

        if (nightsIn > 14)
        {
            studioPrice *= 0.8;
        }
    }

    else if (month == "July" || month == "August")
    {
        studioPrice = 76;
        apartmentPrice = 77;
    }

    if (nightsIn > 14)
    {
        apartmentPrice *= 0.9;
    }

    double studioTotal = studioPrice * nightsIn;
    double apartmentTotal = apartmentPrice * nightsIn;

    cout.setf(ios::fixed);
    cout.precision(2);
    cout << "Apartment: " << apartmentTotal << " lv." << endl;
    cout << "Studio: " << studioTotal << " lv." << endl;
}
