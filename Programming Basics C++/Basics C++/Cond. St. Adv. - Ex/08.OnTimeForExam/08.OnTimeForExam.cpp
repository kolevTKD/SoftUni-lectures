#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	int examHour, examMinute, arriveHour, arriveMinute;
	cin >> examHour >> examMinute >> arriveHour >> arriveMinute;

	string arrival, message;
	int examTimeInMin = examHour * 60 + examMinute;
	int arriveTimeInMin = arriveHour * 60 + arriveMinute;
	int diffExamArrive = examTimeInMin - arriveTimeInMin;
	int diffHours = diffExamArrive / 60;
	int diffMins = diffExamArrive % 60;
	int absDiffHours = abs(diffExamArrive / 60);
	int absDiffMins = abs(diffExamArrive % 60);

	if (diffExamArrive < 0) // late
	{
		cout << "Late" << endl;

		if (absDiffHours >= 1)
		{
			if (absDiffMins <= 9)
			{
				cout << absDiffHours << ":0" << absDiffMins << " hours after the start";
			}

			else
			{
				cout << absDiffHours << ":" << absDiffMins << " hours after the start";
			}
		}

		else if (absDiffHours == 0)
		{
			cout << absDiffMins << " minutes after the start";
		}
	}

	else if (diffExamArrive == 0) // on time
	{
		cout << "On time" << endl;
	}

	else // early
	{
		if (diffExamArrive <= 30)
		{
			cout << "On time" << endl;
			cout << diffMins << " minutes before the start";
		}

		else
		{
			cout << "Early" << endl;

			if (diffHours >= 1)
			{
				if (diffMins <= 9)
				{
					cout << diffHours << ":0" << diffMins << " hours before the start";
				}

				else
				{
					cout << diffHours << ":" << diffMins << " hours before the start";
				}
			}

			else if (diffHours == 0)
			{
				cout << diffMins << " minutes before the start";
			}
		}
	}
}
