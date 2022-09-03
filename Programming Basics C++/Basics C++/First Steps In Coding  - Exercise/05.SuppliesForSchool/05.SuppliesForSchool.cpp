#include <iostream>

using namespace std;

int main()
{
    const double PENS_PACK = 5.8;
    const double MARKERS_PACK = 7.2;
    const double DETERGENT_LITER = 1.2;

    int pens, markers, detergent;
    double discount;
    cin >> pens >> markers >> detergent >> discount;

    double pensTotal = pens * PENS_PACK;
    double markersTotal = markers * MARKERS_PACK;
    double detergentTotal = detergent * DETERGENT_LITER;
    double grandTotal = pensTotal + markersTotal + detergentTotal;
    discount = grandTotal * (discount / 100);
    grandTotal -= discount;

    cout << grandTotal;
}
