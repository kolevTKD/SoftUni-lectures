#include <iostream>

using namespace std;

int main()
{
    string secretPass = "s3cr3t!P@ssw0rd";
    string input;
    cin >> input;

    bool isValid = input == secretPass;

    if (isValid)
    {
        cout << "Welcome";
    }

    else
    {
        cout << "Wrong password!";
    }
}
