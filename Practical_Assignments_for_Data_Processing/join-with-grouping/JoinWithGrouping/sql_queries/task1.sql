SELECT pt.name AS category, COUNT(*) AS count
FROM product p
JOIN product_title pt ON p.product_title_id = pt.id
GROUP BY pt.name
HAVING count > 0
ORDER BY pt.name ASC;
