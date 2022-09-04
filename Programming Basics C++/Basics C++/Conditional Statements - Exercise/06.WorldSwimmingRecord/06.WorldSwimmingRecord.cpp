#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	double record, distanceM, timePerM;
	cin >> record >> distanceM >> timePerM;

	double slowdownSec = floor((distanceM / 15)) * 12.5;
	double totalTime = distanceM * timePerM + slowdownSec;

	cout.setf(ios::fixed);
	cout.precision(2);

	if (totalTime < record)
	{
		cout << "Yes, he succeeded! The new world record is " << totalTime << " seconds.";
	}

	else
	{
		cout << "No, he failed! He was " << totalTime - record << " seconds slower.";
	}
}
