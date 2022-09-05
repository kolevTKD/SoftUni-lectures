#include <iostream>

using namespace std;

int main()
{
    string product;
    cin >> product;

	string type;

	if (product == "banana" || product == "apple" ||
		product == "kiwi" || product == "cherry" ||
		product == "lemon" || product == "grapes")
	{
		type = "fruit";
	}

	else if (product == "tomato" || product == "cucumber" ||
			 product == "pepper" || product == "carrot")
	{
		type = "vegetable";
	}

	else
	{
		type = "unknown";
	}

	cout << type;
}
