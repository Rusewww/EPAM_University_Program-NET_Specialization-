SELECT COUNT(customer.id) AS customer_count, customer.discount AS discount
FROM customer_order
INNER JOIN customer ON customer_order.customer_id = customer.person_id
GROUP BY customer.discount
ORDER BY customer.discount ASC;
