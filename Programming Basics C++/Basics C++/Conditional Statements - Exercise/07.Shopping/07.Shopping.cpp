#include <iostream>

using namespace std;

int main()
{
    double budget;
    int graphicCards, processors, rams;
    cin >> budget >> graphicCards >> processors >> rams;

    double graphicPrice = 250;
    double totalForGraphics = graphicCards * graphicPrice;
    double processorPrice = totalForGraphics * 0.35;
    double totalForProcessors = processors * processorPrice;
    double ramPrice = totalForGraphics * 0.1;
    double totalForRams = rams * ramPrice;
    double total = totalForGraphics + totalForProcessors + totalForRams;

    if (graphicCards > processors)
    {
        total *= 0.85;
    }

    cout.setf(ios::fixed);
    cout.precision(2);

    if (budget >= total)
    {
        cout << "You have " << budget - total << " leva left!";
    }

    else
    {
        cout << "Not enough money! You need " << total - budget << " leva more!";
    }
}
