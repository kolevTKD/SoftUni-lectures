function solve(count, numbers) {

    let result = [];

    for (let i = 0; i < count; i++) {
        result.push(numbers[i]);
    }

    let output = '';

    // for (let i = result.length - 1; i >= 0; i--) {
    //     output += `${result[i]} `;
    // }

    output = result.reverse().join(' ');

    console.log(output);
}

solve(4, [-1, 20, 99, 5]);