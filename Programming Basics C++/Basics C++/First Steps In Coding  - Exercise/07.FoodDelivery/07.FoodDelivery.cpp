#include <iostream>

using namespace std;

int main()
{
    const double CHICKEN_MENU = 10.35;
    const double FISH_MENU = 12.40;
    const double VEGAN_MENU = 8.15;
    const double DELIVERY = 2.5;

    int chickenMenu, fishMenu, veganMenu;
    cin >> chickenMenu >> fishMenu >> veganMenu;

    double chickenTotal = chickenMenu * CHICKEN_MENU;
    double fishTotal = fishMenu * FISH_MENU;
    double veganTotal = veganMenu * VEGAN_MENU;
    double total = chickenTotal + fishTotal + veganTotal;
    double desertTotal = total * 0.2;
    total += desertTotal + DELIVERY;

    cout << total;
}
