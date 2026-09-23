function solve (speed, area) {

    let limit = 0;
    let residentialLimit = 20;
    let speedExceed = 0;

    if (area == 'motorway') {

        limit = 130;
    } else if (area == 'interstate') {

        limit = 90;
    } else if (area == 'city') {

        limit = 50;
    } else if (area == 'residential') {

        limit = 20;
    }

    let status = "";
    let diff = speed - limit;

    if (speed <= limit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    } else {

        if (diff <= 20) {
            status = 'speeding'
        } else if (diff > 20 && diff <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

solve (200, 'motorway')