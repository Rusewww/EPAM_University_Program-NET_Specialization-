SELECT p.surname, p.name, p.birth_date
FROM customer c
INNER JOIN person p ON c.person_id = p.id
LEFT JOIN customer_order co ON c.id = co.customer_id
WHERE co.id IS NULL AND p.surname != 'Anonymous'
ORDER BY p.surname ASC, p.birth_date ASC;
