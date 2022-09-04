#include <iostream>
#include <string>
#include <math.h>

using namespace std;

int main()
{
    string serialName;
    getline(cin, serialName);
    double episodeLength, breakLength;
    cin >> episodeLength >> breakLength;

    double lunchTime = breakLength / 8;
    double restTime = breakLength / 4;
    double timeLeft = breakLength - lunchTime - restTime;

    if (timeLeft >= episodeLength)
    {
        cout << "You have enough time to watch " << serialName << " and left with " << ceil(timeLeft - episodeLength) << " minutes free time.";
    }

    else
    {
        cout << "You don't have enough time to watch " << serialName << ", you need " << ceil(episodeLength - timeLeft) << " more minutes.";
    }
}
