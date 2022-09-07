#include <iostream>
#include <string>

using namespace std;

int main()
{
    string text;
    getline(cin, text);
	int sum = 0;

	for (int index = 0; index < text.length(); index++)
	{
		if (text[index] == 'a')
		{
			sum++;
		}

		else if (text[index] == 'e')
		{
			sum += 2;
		}

		else if (text[index] == 'i')
		{
			sum += 3;
		}

		else if (text[index] == 'o')
		{
			sum += 4;
		}

		else if (text[index] == 'u')
		{
			sum += 5;
		}
	}

	cout << sum;
}
