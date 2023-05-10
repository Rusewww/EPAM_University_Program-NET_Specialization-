SELECT p.surname, p.name, SUM(od.price_with_discount * od.product_amount) AS total_expenses
FROM customer_order co
JOIN customer c ON co.customer_id = c.person_id
JOIN person p ON c.person_id = p.id
JOIN order_details od ON co.id = od.customer_order_id
WHERE p.birth_date BETWEEN '2000-01-01' AND '2010-12-31'
GROUP BY p.surname, p.name
HAVING SUM(od.price_with_discount * od.product_amount) > (
    SELECT AVG(sum_price)
    FROM (
        SELECT SUM(od.price_with_discount * od.product_amount) AS sum_price
        FROM customer_order co
        JOIN order_details od ON co.id = od.customer_order_id
        JOIN customer c ON co.customer_id = c.person_id
        JOIN person p ON c.person_id = p.id
        WHERE p.card_number IS NOT NULL
        GROUP BY co.id
    ) AS t
)
ORDER BY total_expenses, p.surname;
