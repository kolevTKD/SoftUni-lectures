#include <iostream>

using namespace std;

int main()
{
	string product, dayOfWeek;
	double quantity;
	cin >> product >> dayOfWeek >> quantity;
	double price = 0;

	bool isWorkday = dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday";
	bool isWeekend = dayOfWeek == "Saturday" || dayOfWeek == "Sunday";
	bool isValidFruit = product == "banana" || product == "apple" || product == "orange" || product == "grapefruit" || product == "kiwi" || product == "pineapple" || product == "grapes";

	if ((isWorkday || isWeekend) && isValidFruit)
	{
		if (isWorkday)
		{
			// 2.50	1.20	0.85	1.45	2.70	5.50	3.85
			if (product == "banana")
			{
				price = 2.5;
			}

			else if (product == "apple")
			{
				price = 1.2;
			}

			else if (product == "orange")
			{
				price = 0.85;
			}

			else if (product == "grapefruit")
			{
				price = 1.45;
			}

			else if (product == "kiwi")
			{
				price = 2.7;
			}

			else if (product == "pineapple")
			{
				price = 5.5;
			}

			else if (product == "grapes")
			{
				price = 3.85;
			}
		}

		else if (isWeekend)
		{
			// 2.70	1.25	0.90	1.60	3.00	5.60	4.20
			if (product == "banana")
			{
				price = 2.7;
			}

			else if (product == "apple")
			{
				price = 1.25;
			}

			else if (product == "orange")
			{
				price = 0.9;
			}

			else if (product == "grapefruit")
			{
				price = 1.6;
			}

			else if (product == "kiwi")
			{
				price = 3;
			}

			else if (product == "pineapple")
			{
				price = 5.6;
			}

			else if (product == "grapes")
			{
				price = 4.2;
			}
		}

		cout.setf(ios::fixed);
		cout.precision(2);
		cout << price * quantity;
	}

	else
	{
		cout << "error";
	}
}


