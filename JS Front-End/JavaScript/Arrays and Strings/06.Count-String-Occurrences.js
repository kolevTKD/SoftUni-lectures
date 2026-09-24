function solve(text, searchWord) {

    let words = text.split(' ');
    let counter = 0;

    for (const word of words) {
        
        if (word === searchWord) {
            counter++;
        }
    }

    console.log(counter);
}

solve('This is a word and it also is a sentence', 'is')