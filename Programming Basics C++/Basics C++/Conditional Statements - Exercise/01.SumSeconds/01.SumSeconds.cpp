#include <iostream>

using namespace std;

int main()
{
    int firstTime, secondTime, thirdTime;
    cin >> firstTime >> secondTime >> thirdTime;

    int totalTime = firstTime + secondTime + thirdTime;
    int minutes = totalTime / 60;
    int seconds = totalTime % 60;

    if (seconds < 10)
    {
        cout << minutes << ":0" << seconds;
    }

    else
    {
        cout << minutes << ':' << seconds;
    }
}
