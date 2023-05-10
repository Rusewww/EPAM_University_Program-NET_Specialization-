SELECT p.surname, p.name, p.birth_date, SUM(od.price_with_discount * od.product_amount) AS sum
FROM customer_order co
JOIN customer c ON co.customer_id = c.person_id
JOIN person p ON c.person_id = p.id
JOIN order_details od ON co.id = od.customer_order_id
WHERE c.discount = 0 AND YEAR(co.operation_time) = 2021
GROUP BY p.surname, p.name, p.birth_date
ORDER BY sum ASC, p.surname ASC;
