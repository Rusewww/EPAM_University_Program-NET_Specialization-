SELECT p.id, pt.title AS product, p.price
FROM product p
JOIN product_title pt ON p.product_title_id = pt.id
WHERE p.price >= 2 * (SELECT MIN(price) FROM product)
ORDER BY p.price, pt.title;
