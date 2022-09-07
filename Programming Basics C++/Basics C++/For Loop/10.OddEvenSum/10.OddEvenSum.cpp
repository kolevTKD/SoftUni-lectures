#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	int num, newNum;
    cin >> num;
	int evenSum = 0;
	int oddSum = 0;

	for (int evenOddPos = 1; evenOddPos <= num; evenOddPos++)
	{
		cin >> newNum;

		if (evenOddPos % 2 == 1)
		{
			oddSum += newNum;
		}

		else if (evenOddPos % 2 == 0)
		{
			evenSum += newNum;
		}
	}

	if (evenSum == oddSum)
	{
		cout << "Yes" << endl;
		cout << "Sum = " << evenSum;
	}

	else
	{
		cout << "No" << endl;
		cout << "Diff = " << abs(evenSum - oddSum);
	}
}
