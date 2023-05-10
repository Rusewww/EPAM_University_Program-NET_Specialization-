SELECT c.name AS city, SUM(od.price_with_discount * od.product_amount) AS income
FROM customer_order co
JOIN supermarket s ON co.supermarket_id = s.id
JOIN street st ON s.street_id = st.id
JOIN city c ON st.city_id = c.id
JOIN order_details od ON co.id = od.customer_order_id
WHERE co.operation_time BETWEEN '2020-11-01' AND '2020-11-30'
GROUP BY c.name
ORDER BY income ASC, c.name ASC;
