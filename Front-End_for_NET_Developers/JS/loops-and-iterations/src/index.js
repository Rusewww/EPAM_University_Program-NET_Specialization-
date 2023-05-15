/**
 *
 * @param x: {Number}
 * @param y: {Number}
 * @param step: {Number}
 * @returns {String}
 */
module.exports.createString = function createString(x, y, step) {
    let result = '';
    for (let i = x; i <= y; i += step) {
        result += i + ' ';
    }
    return result.trim();
};

/**
 *
 * @param x: {Number}
 * @param y: {Number}
 * @returns {Number}
 */
module.exports.rangeSum1 = function rangeSum1(x, y) {
    let result = 0;
    let count = 0;
    for (let i = 0; i <= y; i++) {
        for (let j = x; j <= y; j++) {
            if (i + j <= y) {
                result += i + j;
                count++;
            }
        }
    }
    return result;
};

/**
 *
 * @param x: {Number}
 * @param y: {Number}
 * @returns {Number}
 */
module.exports.rangeSum2 = function rangeSum2(x, y) {
    let result = 0;
    for (let i = x; i <= y; i++) {
        result += i;
    }
    return result;
};

/**
 *
 * @param x: {Number}
 * @returns {String}
 */
module.exports.seriesSum = function seriesSum(x) {
    let sum = 0;
    for (let i = 0; i < x; i++) {
        sum += 1 / Math.pow((i * 3 + 1), 2);
    }
    return sum.toFixed(2);
};

/**
 *
 * @param x: {Number}
 * @returns {Number}
 */
module.exports.countDigits = function countDigits(x) {
    return x.toString().length;
};
