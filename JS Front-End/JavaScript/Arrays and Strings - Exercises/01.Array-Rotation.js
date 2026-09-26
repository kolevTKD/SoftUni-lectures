function solve(numbers, rotations) {

    for (let i = 0; i < rotations; i++) {
        let current = numbers.shift();
        numbers.push(current)
    }

    console.log(numbers.join(' '));
    
}

solve([51, 47, 32, 61, 21], 2);