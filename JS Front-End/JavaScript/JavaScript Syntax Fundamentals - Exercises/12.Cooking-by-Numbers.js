function solve(...input) {

    let number = parseInt(input[0]);

    for (let i = 1; i < input.length; i++) {

        switch (input[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.80;
                break;
            default:
                break;
        }

        console.log(parseFloat(number.toFixed(2)));
    }
}

solve ('9', 'dice', 'spice', 'chop', 'bake', 'fillet');