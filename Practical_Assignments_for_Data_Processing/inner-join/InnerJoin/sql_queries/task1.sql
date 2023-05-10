SELECT product.id, product_title.title AS title, product.price 
FROM product 
JOIN product_title ON product.product_title_id = product_title.id 
ORDER BY title ASC;
