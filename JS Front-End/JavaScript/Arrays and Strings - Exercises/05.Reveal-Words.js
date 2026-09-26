function solve(words, template = '') {
    let splitWords = words.split(', ');

    const expression = /[\*]+/g;
    let wordsToReplace = template.matchAll(expression);


    for (let word of wordsToReplace) {
        console.log(word);
        
    }
}

solve('great', 'softuni is ***** place for ******** new programming languages');