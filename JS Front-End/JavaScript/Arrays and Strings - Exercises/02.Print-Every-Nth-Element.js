function solve(strings, step) {

    let result = [];

    for (let i = 0; i < strings.length; i += step) {
        result.push(strings[i]);
    }

    return result;
}

solve(['5', '20', '31', '4', '20'], 2)