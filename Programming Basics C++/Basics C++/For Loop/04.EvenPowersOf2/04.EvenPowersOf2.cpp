#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    int num;
    cin >> num;

	for (int number = 0; number <= num; number++)
	{
		if (number % 2 == 0)
		{
			cout << pow(2, number) << endl;
		}
	}
}

