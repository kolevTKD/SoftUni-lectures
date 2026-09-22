function solve (number) {

    let numberAsText = number.toString();
    let first = numberAsText[0];
    let areSame = true;
    let sum = Number(first);

    for (let i = 1; i < numberAsText.length; i++) {

        if (first != numberAsText[i]) {
            areSame = false
        }

        sum += Number(numberAsText[i]);

    }

    console.log(areSame);
    console.log(sum);
}

solve (1234)