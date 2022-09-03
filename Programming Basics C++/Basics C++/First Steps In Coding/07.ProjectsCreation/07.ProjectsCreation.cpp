#include <iostream>
using namespace std;

int main()
{
    const int CREATION_TIME = 3;

    string name;
    cin >> name;

    int projectsNum;
    cin >> projectsNum;

    cout << "The architect " << name << " will need " << CREATION_TIME * projectsNum << " hours to complete " << projectsNum << " project/s";
}
