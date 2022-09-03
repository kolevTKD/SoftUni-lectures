#include <iostream>

using namespace std;

int main()
{
    //сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)
    double deposit;
    cin >> deposit;

    int term;
    cin >> term;

    double yearInterest;
    cin >> yearInterest;

    double totalInterest = deposit * (yearInterest / 100);
    double monthlyInterest = totalInterest / 12;
    double totalSum = deposit + term * monthlyInterest;

    cout << totalSum;
}
