SELECT co.id AS order_id, COUNT(od.id) AS items_count
FROM customer_order co
JOIN order_details od ON co.id = od.customer_order_id
WHERE YEAR(co.operation_time) = 2021
GROUP BY co.id
HAVING COUNT(od.id) > (
    SELECT AVG(items_per_order)
    FROM (
        SELECT COUNT(od.id) AS items_per_order
        FROM customer_order co
        JOIN order_details od ON co.id = od.customer_order_id
        GROUP BY co.id
    ) AS t
)
ORDER BY items_count, order_id;
