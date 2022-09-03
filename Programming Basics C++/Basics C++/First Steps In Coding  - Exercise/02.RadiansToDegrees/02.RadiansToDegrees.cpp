#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    //deg = rad * 180 / pi
    double radians;
    cin >> radians;

    double degrees = radians * 180 / 3.14;

    cout << round(degrees);
}
