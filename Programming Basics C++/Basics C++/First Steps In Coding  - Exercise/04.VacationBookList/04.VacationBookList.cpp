#include <iostream>

using namespace std;

int main()
{
    int totalPages, pagesPerHour, daysToRead;
    cin >> totalPages >> pagesPerHour >> daysToRead;

    int hoursToRead = totalPages / pagesPerHour;
    int hoursPerDay = hoursToRead / daysToRead;

    cout << hoursPerDay;
}
