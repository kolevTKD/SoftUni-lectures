#include <iostream>
#include <climits>

using namespace std;

int main()
{
    int max = INT_MIN;
    int min = INT_MAX;
    int num, newNum;
    cin >> num;

    for (int numbers = 1; numbers <= num; numbers++)
    {
        cin >> newNum;

        if (newNum > max)
        {
            max = newNum;
        }

        if (newNum < min)
        {
            min = newNum;
        }
    }

    cout << "Max number: " << max << endl;
    cout << "Min number: " << min << endl;
}