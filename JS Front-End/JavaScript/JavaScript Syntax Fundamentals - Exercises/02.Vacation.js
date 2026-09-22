function solve(groupSize, groupType, dayOfWeek) {
    let totalPrice;
    let ticketPrice;

    if (dayOfWeek === 'Friday') {
        if (groupType === 'Students') {
            ticketPrice = 8.45;
        } else if (groupType === 'Business') {
            ticketPrice = 10.90;
        } else if (groupType === 'Regular') {
            ticketPrice = 15;
        }
    } else if (dayOfWeek === 'Saturday') {
        if (groupType === 'Students') {
            ticketPrice = 9.80;
        } else if (groupType === 'Business') {
            ticketPrice = 15.60;
        } else if (groupType === 'Regular') {
            ticketPrice = 20;
        }
    } else if (dayOfWeek === 'Sunday') {
        if (groupType === 'Students') {
            ticketPrice = 10.46;
        } else if (groupType === 'Business') {
            ticketPrice = 16;
        } else if (groupType === 'Regular') {
            ticketPrice = 22.50;
        }
    }

    totalPrice = groupSize * ticketPrice;

    if (groupType === 'Students' && groupSize >= 30) {
        totalPrice -= totalPrice * 0.15;
    } else if (groupType === 'Business' && groupSize >= 100) {
        totalPrice -= ticketPrice * 10;
    } else if (groupType === 'Regular' && groupSize >= 10 && groupSize <= 20) {
        totalPrice -= totalPrice * 0.05;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve (40, 'Regular', 'Saturday')