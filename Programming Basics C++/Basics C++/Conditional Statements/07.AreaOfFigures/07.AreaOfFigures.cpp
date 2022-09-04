#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    string figureType;
    cin >> figureType;

	double result = 0;
	double pi = 3.14159265359;

	if (figureType == "square")
	{
		double side;
		cin >> side;
		result = side * side;
	}

	else if (figureType == "rectangle")
	{
		double side1, side2;
		cin >> side1 >> side2;
		result = side1 * side2;
	}

	else if (figureType == "circle")
	{
		double radius;
		cin >> radius;
		result = pi * pow(radius, 2);
	}

	else if (figureType == "triangle")
	{
		double sideL, heigth;
		cin >> sideL >> heigth;
		result = (sideL * heigth) / 2;
	}

	cout.setf(ios::fixed);
	cout.precision(3);

	cout << result;
}
