#include <iostream>
#include <string>

using namespace std;

int main()
{
    string text;
    getline(cin, text);

	for (int index = 0; index < text.length(); index++)
	{
		cout << text[index] << endl;
	}
}
