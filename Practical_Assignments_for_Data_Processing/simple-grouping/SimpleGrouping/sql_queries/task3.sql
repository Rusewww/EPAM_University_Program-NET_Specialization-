SELECT customer_order.id AS customer_order_id, SUM(customer.discount) AS total_discount
FROM customer_order
INNER JOIN customer ON customer_order.customer_id = customer.person_id
GROUP BY customer_order.id
ORDER BY total_discount DESC
LIMIT 1;
