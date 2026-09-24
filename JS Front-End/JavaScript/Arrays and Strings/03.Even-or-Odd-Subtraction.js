function solve(input) {

    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < input.length; i++) {

        let current = Number(input[i]);

        if (current % 2 == 0) {
            evenSum += current;
        } else if (current % 2 != 0) {
            oddSum += current;
        }
    }

    console.log(evenSum - oddSum);
}

solve([2,4,6,8,10]);