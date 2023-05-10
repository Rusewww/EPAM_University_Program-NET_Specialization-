SELECT p.surname, p.name, COALESCE(SUM(od.price_with_discount * od.product_amount), 0) AS sum
FROM customer c
INNER JOIN person p ON c.person_id = p.id
LEFT JOIN customer_order co ON c.id = co.customer_id
LEFT JOIN order_details od ON co.id = od.customer_order_id
GROUP BY p.surname, p.name
ORDER BY sum ASC, p.surname ASC;
