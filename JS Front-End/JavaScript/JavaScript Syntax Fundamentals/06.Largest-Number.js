function solve(num1, num2, num3) {
    let largest = Number.MIN_SAFE_INTEGER;

    if (num1 > largest) {
        largest = num1;
    }
    if (num2 > largest) {
        largest = num2;
    }
    if (num3 > largest) {
        largest = num3;
    }

    console.log(`The largest number is ${largest}.`);
}

solve (-0, 0, 0.1);