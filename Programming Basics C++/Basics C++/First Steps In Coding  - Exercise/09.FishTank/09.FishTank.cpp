#include <iostream>

using namespace std;

int main()
{
    int length, width, heigth;
    cin >> length >> width >> heigth;

    double usedSpace;
    cin >> usedSpace;

    double volumeCm3 = length * width * heigth;
    double volumeLiters = volumeCm3 / 1000;
    double totalVolume = volumeLiters * (1 - usedSpace / 100);

    cout << totalVolume;
}
