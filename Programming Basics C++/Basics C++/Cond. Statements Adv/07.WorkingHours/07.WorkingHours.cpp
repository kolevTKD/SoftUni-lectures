#include <iostream>

using namespace std;

int main()
{
    int hour;
    string dayOfWeek;

    cin >> hour >> dayOfWeek;

    bool isWorking = hour >= 10 && hour <= 18;
    bool isWorkday = dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday" || dayOfWeek == "Saturday";

    if (isWorking && isWorkday)
    {
        cout << "open";
    }

    else
    {
        cout << "closed";
    }
}
