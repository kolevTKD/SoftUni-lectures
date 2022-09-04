#include <iostream>

using namespace std;

int main()
{
    int number;
    cin >> number;

	if (number < 100)
	{
		cout << "Less than 100";
	}

	else if (number > 200)
	{
		cout << "Greater than 200";
	}

	else
	{
		cout << "Between 100 and 200";
	}
}
