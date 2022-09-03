#include <iostream>

using namespace std;

int main()
{
    int yearTax;
    cin >> yearTax;

    double sneakersPrice = yearTax * 0.6;
    double outfitPrice = sneakersPrice * 0.8;
    double basketballPrice = outfitPrice / 4;
    double accessories = basketballPrice / 5;
    double total = yearTax + sneakersPrice + outfitPrice + basketballPrice + accessories;

    cout << total;
}
