function solve(names) {
    
    names = names.sort((a,b) => a.toLowerCase().localeCompare(b.toLowerCase()));

    for (let i = 1; i <= names.length; i++) {
        console.log(`${i}.${names[i - 1]}`);
    }
}

solve(['John', 'Bob', 'Christina', 'Ema']);