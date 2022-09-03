#include <iostream>
using namespace std;

int main()
{
    const double USD = 1.79549;

    double bgn;
    cin >> bgn;
    bgn *= USD;

    cout.setf(ios::fixed);
    cout.precision(2);

    cout << bgn;
     
}

