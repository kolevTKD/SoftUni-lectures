#include <iostream>

using namespace std;

int main()
{
	string city;
	double sales;
	cin >> city >> sales;

	double commission = 0;
	bool isValidCity = city == "Sofia" || city == "Varna" || city == "Plovdiv";
	bool isValidSale = sales >= 0;


	if (isValidCity && isValidSale)
	{
		if (city == "Sofia")
		{
			if (sales <= 500)
			{
				commission = 0.05;
			}

			else if (sales <= 1000)
			{
				commission = 0.07;
			}

			else if (sales <= 10000)
			{
				commission = 0.08;
			}

			else
			{
				commission = 0.12;
			}
		}

		else if (city == "Varna")
		{
			if (sales <= 500)
			{
				commission = 0.045;
			}

			else if (sales <= 1000)
			{
				commission = 0.075;
			}

			else if (sales <= 10000)
			{
				commission = 0.1;
			}

			else
			{
				commission = 0.13;
			}
		}

		else if (city == "Plovdiv")
		{
			if (sales <= 500)
			{
				commission = 0.055;
			}

			else if (sales <= 1000)
			{
				commission = 0.08;
			}

			else if (sales <= 10000)
			{
				commission = 0.12;
			}

			else
			{
				commission = 0.145;
			}
		}

		cout.setf(ios::fixed);
		cout.precision(2);
		cout << sales * commission;
	}

	else
	{
		cout << "error";
	}
}
