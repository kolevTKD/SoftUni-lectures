function solve(numbers) {

    numbers = numbers.sort((a, b) => a - b);

    for (let i = 0; i < numbers.length; i += 2) {
        numbers.splice(i + 1, 0, numbers.pop());
    }

    return numbers;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])