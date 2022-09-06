#include <iostream>

using namespace std;

int main()
{
	double budget, price;
	string season, destination, place;
	cin >> budget >> season;

	if (budget <= 100)
	{
		destination = "Bulgaria";

		if (season == "summer")
		{
			place = "Camp";
			price = budget * 0.3;
		}

		else if (season == "winter")
		{
			place = "Hotel";
			price = budget * 0.7;
		}
	}

	else if (budget <= 1000)
	{
		destination = "Balkans";

		if (season == "summer")
		{
			place = "Camp";
			price = budget * 0.4;
		}

		else if (season == "winter")
		{
			place = "Hotel";
			price = budget * 0.8;
		}
	}

	else if (budget > 1000)
	{
		destination = "Europe";
		place = "Hotel";
		price = budget * 0.9;
	}

	cout.setf(ios::fixed);
	cout.precision(2);

	cout << "Somewhere in " << destination << endl;
	cout << place << " - " << price << endl;
}
