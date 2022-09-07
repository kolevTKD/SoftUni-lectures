#include <iostream>

using namespace std;

int main()
{
	int num;
	cin >> num;

	for (int number = 1; number <= num; number += 3)
	{
		cout << number << endl;
	}
}

