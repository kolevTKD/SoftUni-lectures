function solve (startNum, endNum) {
    let result = 0;
    let numbers = '';

    for (let i = startNum; i <= endNum; i++) {
        numbers += `${i} `;
        result += i;
    }

    console.log(numbers.trimEnd());
    
    console.log(`Sum: ${result}`);
}

solve (50, 60)