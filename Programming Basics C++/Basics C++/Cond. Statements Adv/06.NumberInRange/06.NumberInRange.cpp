#include <iostream>

using namespace std;

int main()
{
    int number;
    cin >> number;

	string info;

	if (number < -100 || number > 100 || number == 0)
	{
		info = "No";
	}

	else
	{
		info = "Yes";
	}

	cout << info;
}
