#include <iostream>

using namespace std;

int main()
{
	double age;
	char gender;
	cin >> age >> gender;

	string title;

	switch (gender)
	{
	case 'm':
		if (age >= 16)
		{
			title = "Mr.";
		}

		else
		{
			title = "Master";
		}
		break;

	case 'f':
		if (age >= 16)
		{
			title = "Ms.";
		}

		else
		{
			title = "Miss";
		}
		break;
	}

	cout << title;
}
