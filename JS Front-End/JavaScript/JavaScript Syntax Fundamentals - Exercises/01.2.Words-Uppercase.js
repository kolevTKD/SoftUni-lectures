function solve(input) {
    const expression = /\b\w+\b/g;

    const matches = input.matchAll(expression);
    let result = [];

    for (const match of matches) {

        result.push(match[0]);
    }

    console.log(result.join(', ').toUpperCase());
}

solve('Hi, how are you?');