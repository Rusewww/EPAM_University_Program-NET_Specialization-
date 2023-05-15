/**
 *
 * @param number1: {Number}
 * @param number2: {Number}
 * @param number3: {Number}
 * @returns {Number}
 */
module.exports.getMin = function getMin(number1, number2, number3) {
    return Math.min(number1, number2, number3);
};

/**
 *
 * @param x: {Number}
 * @param y: {Number}
 * @param z: {Number}
 * @returns {String}
 */
module.exports.evenOrOdd = function evenOrOdd(x, y, z) {
    const isEven = (num) => num % 2 === 0;
    const isOdd = (num) => !isEven(num);
    
    if (isEven(x) && isEven(y) && isEven(z)) {
        return 'even';
    } else if (isOdd(x) && isOdd(y) && isOdd(z)) {
        return 'odd';
    } else {
        return 'even/odd';
    }
};

/**
 *
 * @param x: {Number}
 * @param y: {Number}
 * @param z: {Number}
 * @returns {String}
 */
module.exports.inOrOutRange = function inOrOutRange(x, y, z) {
    if (z >= x && z <= y) {
        return 'In range';
    } else {
        return 'Out of range';
    }
};
