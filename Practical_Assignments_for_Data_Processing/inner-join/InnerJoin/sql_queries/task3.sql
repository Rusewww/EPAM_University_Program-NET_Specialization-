SELECT DISTINCT product_title.title, product.price 
FROM customer_order 
JOIN order_details ON customer_order.id = order_details.customer_order_id 
JOIN product ON order_details.product_id = product.id 
JOIN product_title ON product.product_title_id = product_title.id 
JOIN customer ON customer_order.customer_id = customer.person_id 
JOIN person ON customer.person_id = person.id 
WHERE person.birth_date BETWEEN '2000-01-01' AND '2010-12-31' 
ORDER BY product_title.title ASC, product.price ASC;
