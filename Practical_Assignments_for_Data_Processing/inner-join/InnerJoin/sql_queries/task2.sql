SELECT product.id, product_title.title AS title, product_category.name AS category, product.price 
FROM product 
JOIN product_title ON product.product_title_id = product_title.id 
JOIN product_category ON product_title.product_category_id = product_category.id 
ORDER BY category ASC, title ASC;
