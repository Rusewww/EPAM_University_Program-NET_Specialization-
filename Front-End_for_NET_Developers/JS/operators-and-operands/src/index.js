/**
 *
 * @param number1: {Number}
 * @param number2: {Number}
 * @returns {Number}
 */
module.exports.getSum = function getSum(number1, number2) {
    return number1 + number2;
};

/**
 *
 * @param x: {Number}
 * @returns {Boolean}
 */
module.exports.isSquare = function isSquare(x) {
    return Math.sqrt(x) % 1 === 0;
};

/**
 *
 * @param name: {String}
 * @param surname: {String}
 * @param age: {Number}
 * @returns {String}
 */
module.exports.greeting = function greeting(name, surname, age) {
    return `Hello, my name is ${name} ${surname} and I am ${age} years old.`;
};
