#include <iostream>
using namespace std;

int main()
{
	const double DOG_PRICE = 2.5;
	const double CAT_PRICE = 4;

	int dogPacks, catPacks;
	cin >> dogPacks >> catPacks;

	double total = (dogPacks * DOG_PRICE) + (catPacks * CAT_PRICE);
	cout << total << " lv.";
}
