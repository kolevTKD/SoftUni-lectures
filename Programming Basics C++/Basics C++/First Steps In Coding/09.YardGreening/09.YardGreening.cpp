#include <iostream>
using namespace std;

int main()
{
    const double PRICE_PER_SQ_M = 7.61;
    const double DISCOUNT = 0.18;

    double squareM;
    cin >> squareM;

    double total = squareM * PRICE_PER_SQ_M;
    double totalDiscount = total * DISCOUNT;
    total -= totalDiscount;

    cout << "The final price is: " << total << " lv." << endl;
    cout << "The discount is: " << totalDiscount << " lv." << endl;
}
