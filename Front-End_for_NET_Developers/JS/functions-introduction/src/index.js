/**
 *
 * @param str: {String}
 * @param symbolsCount: {Number}
 * @returns {String}
 */
module.exports.backToFront = function backToFront(str, symbolsCount) {
    const repeat = symbolsCount <= str.length ? symbolsCount : str.length;
    const start = str.slice(str.length - repeat);
    return start + str;
  };
  
  /**
   *
   * @param z: {Number}
   * @param x: {Number}
   * @param y: {Number}
   * @returns {Number}
   */
  module.exports.nearest = function nearest(z, x, y) {
    const distX = Math.abs(z - x);
    const distY = Math.abs(z - y);
    if (distX < distY) {
      return x;
    } else {
      return y;
    }
  };
  
  /**
   *
   * @param arr: {Array}
   * @returns {Array}
   */
  module.exports.removeDuplicate = function removeDuplicate(arr) {
    const newArr = [];
    for (let i = 0; i < arr.length; i++) {
      if (newArr.indexOf(arr[i]) === -1) {
        newArr.push(arr[i]);
      }
    }
    return newArr;
  };
  