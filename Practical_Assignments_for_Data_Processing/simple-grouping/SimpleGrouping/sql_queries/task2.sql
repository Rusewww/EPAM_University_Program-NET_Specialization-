SELECT customer_order.id AS customer_order_id, SUM(order_details.price_with_discount * order_details.product_amount) AS to_pay
FROM customer_order
INNER JOIN order_details ON customer_order.id = order_details.customer_order_id
GROUP BY customer_order.id
HAVING SUM(order_details.price_with_discount * order_details.product_amount) > 100
ORDER BY customer_order.id ASC;
