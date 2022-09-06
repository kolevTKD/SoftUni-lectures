#include <iostream>

using namespace std;

int main()
{
	int num1, num2;
	char symbol;
	cin >> num1 >> num2 >> symbol;
	string evenOrOdd;

	if (symbol == '+' || symbol == '-' || symbol == '*')
	{
		int result1 = 0;

		if (symbol == '+')
		{
			result1 = num1 + num2;
		}

		else if (symbol == '-')
		{
			result1 = num1 - num2;
		}

		else if (symbol == '*')
		{
			result1 = num1 * num2;
		}

		if (result1 % 2 == 0)
		{
			evenOrOdd = "even";
		}

		else
		{
			evenOrOdd = "odd";
		}

		cout << num1 << " " << symbol << " " << num2 << " = " << result1 << " - " << evenOrOdd;
	}

	else if (symbol == '/' || symbol == '%')
	{
		double result2 = 0;

		if (num2 == 0)
		{
			cout << "Cannot divide "<< num1 << " by zero";
		}

		else
		{
			if (symbol == '/')
			{
				result2 = (double)num1 / num2;
				cout.setf(ios::fixed);
				cout.precision(2);
				cout << num1 << " " << symbol << " " << num2 << " = " << result2;
			}

			else if (symbol == '%')
			{
				result2 = num1 % num2;
				cout << num1 << " " << symbol << " " << num2 << " = " << result2;
			}
		}
	}
}

