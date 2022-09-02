#include <iostream>
using namespace std;

int main()
{
    const int HOURS = 3;

    string name;
    cin >> name;

    int projectsNum;
    cin >> projectsNum;

    int totalTime = HOURS * projectsNum;
    cout << "The architect " << name << " will need " << totalTime << " hours to complete " << projectsNum << " project/s.";
}
