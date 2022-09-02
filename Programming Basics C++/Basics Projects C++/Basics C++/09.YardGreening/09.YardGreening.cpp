#include <iostream>
using namespace std;

int main()
{
    const double PRICE_PER_SQM = 7.61;
    const double DISCOUNT = 0.18;

    double squareM;
    cin >> squareM;

    double total = (squareM * PRICE_PER_SQM);
    double totalDiscount = total * DISCOUNT;
    total -= totalDiscount;

    cout << "The final price is: " << total << " lv." << endl;
    cout << "The discount is: " << totalDiscount << " lv.";
}