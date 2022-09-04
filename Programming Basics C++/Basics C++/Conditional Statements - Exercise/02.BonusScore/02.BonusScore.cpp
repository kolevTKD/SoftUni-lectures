#include <iostream>

using namespace std;

int main()
{
    int score;
    cin >> score;
	double bonusPoints;

	if (score <= 100)
	{
		bonusPoints = 5;
	}

	else if (score <= 1000)
	{
		bonusPoints = score * 0.2;
	}

	else
	{
		bonusPoints = score * 0.1;
	}

	if (score % 2 == 0)
	{
		bonusPoints += 1;
	}

	if (score % 10 == 5)
	{
		bonusPoints += 2;
	}

	cout << bonusPoints << endl;
	cout << score + bonusPoints << endl;
}
