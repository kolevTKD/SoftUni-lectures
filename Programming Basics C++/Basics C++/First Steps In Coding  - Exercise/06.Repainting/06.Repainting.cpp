#include <iostream>

using namespace std;

int main()
{
    const double NYLON_SQ = 1.5;
    const double PAINT = 14.5;
    const double THINNER = 5;

    int nylonNeeded, paintLiters, thinnerLiters, hoursWork;
    cin >> nylonNeeded >> paintLiters >> thinnerLiters >> hoursWork;

    double nylonTotal = (nylonNeeded + 2) * NYLON_SQ;
    double paintTotal = (paintLiters * 1.1) * PAINT;
    double thinnerTotal = thinnerLiters * THINNER;
    double total = nylonTotal + paintTotal + thinnerTotal + 0.4;
    double workmanPayment = (total * 0.3) * hoursWork;
    total += workmanPayment;

    cout << total;
}
