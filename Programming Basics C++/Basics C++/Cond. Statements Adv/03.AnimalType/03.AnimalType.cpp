#include <iostream>

using namespace std;

int main()
{
    string animal;
    cin >> animal;

	string type;

	if (animal == "dog")
	{
		type = "mammal";
	}

	else if (animal == "crocodile" || animal == "tortoise" || animal == "snake")
	{
		type = "reptile";
	}

	else
	{
		type = "unknown";
	}

	cout << type;
}
