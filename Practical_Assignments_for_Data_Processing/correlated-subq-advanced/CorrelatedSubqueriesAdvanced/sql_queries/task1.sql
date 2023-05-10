SELECT p.name, p.surname, AVG(od.price_with_discount) AS avg_purchase, SUM(od.price_with_discount) AS sum_purchase 
FROM customer_order AS co
JOIN customer AS c ON co.customer_id = c.person_id
JOIN person AS p ON c.person_id = p.id
JOIN order_details AS od ON co.id = od.customer_order_id
GROUP BY p.name, p.surname
HAVING AVG(od.price_with_discount) > 70
ORDER BY sum_purchase ASC, p.surname ASC;

