#include <iostream>
#include <string>

using namespace std;

int main()
{
    string dayOfWeek;
    getline(cin, dayOfWeek);
	string dayType;

	if (dayOfWeek == "Monday")
	{
		dayType = "Working day";
	}

	else if (dayOfWeek == "Tuesday")
	{
		dayType = "Working day";
	}

	else if (dayOfWeek == "Wednesday")
	{
		dayType = "Working day";
	}

	else if (dayOfWeek == "Thursday")
	{
		dayType = "Working day";
	}

	else if (dayOfWeek == "Friday")
	{
		dayType = "Working day";
	}

	else if (dayOfWeek == "Saturday")
	{
		dayType = "Weekend";
	}

	else if (dayOfWeek == "Sunday")
	{
		dayType = "Weekend";
	}

	else
	{
		dayType = "Error";
	}

	cout << dayType;
}
