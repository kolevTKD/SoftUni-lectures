function solve(x1, y1, x2, y2) {
    let state = '';

    if (Number.isInteger(Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2)))) {
        state = 'valid';
    } else {
        state = 'invalid';
    }
    console.log(`\{${x1}, ${x2}\} to \{0, 0\} is ${state}`);

    if (Number.isInteger(Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2)))) {
        state = 'valid';
    } else {
        state = 'invalid';
    }
    console.log(`\{${y1}, ${y2}\} to \{0, 0\} is ${state}`);

    if (Number.isInteger(Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2)))) {
        state = 'valid';
    } else {
        state = 'invalid';
    }
    console.log(`\{${x1}, ${x2}\} to \{${y1}, ${y2}\} is ${state}`);
}

solve(3, 0, 0, 4);