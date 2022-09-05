#include <iostream>

using namespace std;

int main()
{
    int number;
    cin >> number;

	if (!(number == 0 || number >= 100 && number <= 200))
	{
		cout << "invalid";
	}
}
