#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    int num, leftNum, rightNum;
    cin >> num;
	int leftSum = 0;
	int rightSum = 0;

	for (int leftNums = 1; leftNums <= num; leftNums++)
	{
		cin >> leftNum;
		leftSum += leftNum;
	}

	for (int rightNums = 1; rightNums <= num; rightNums++)
	{
		cin >> rightNum;
		rightSum += rightNum;
	}

	if (leftSum == rightSum)
	{
		cout << "Yes, sum = " << leftSum;
	}

	else
	{
		cout << "No, diff = " << abs(leftSum - rightSum);
	}
}
