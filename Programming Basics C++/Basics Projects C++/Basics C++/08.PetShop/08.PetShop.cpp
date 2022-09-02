#include <iostream>
using namespace std;

int main()
{
    const double DOG_FOOD = 2.5;
    const double CAT_FOOD = 4;

    int dogfoodPacks, catfoodPacks;
    cin >> dogfoodPacks >> catfoodPacks;

    double total = (dogfoodPacks * DOG_FOOD) + (catfoodPacks * CAT_FOOD);

    cout << total << " lv.";
}
