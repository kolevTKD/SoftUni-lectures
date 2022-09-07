#include <iostream>

using namespace std;

int main()
{
	int numbers, newNum;
    cin >> numbers;
	int sum = 0;

	for (int num = 1; num <= numbers; num++)
	{
		cin >> newNum;
		sum += newNum;
	}

	cout << sum;
}
