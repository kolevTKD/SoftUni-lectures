// function solveForLoop (number) {
//     let numberAsText = number.toString();
//     let sum = 0;

//     for (let i = 0; i < numberAsText.length; i++) {
//         sum += Number(numberAsText[i]);
//     }

//     console.log(sum);
// }

// solveForLoop (245678);

function solevWhileLoop (number) {
    
    let result = 0;

    while (number > 0) {
        result += number % 10;
        number = parseInt(number / 10);
    }

    console.log(result);
}

solevWhileLoop (245678);