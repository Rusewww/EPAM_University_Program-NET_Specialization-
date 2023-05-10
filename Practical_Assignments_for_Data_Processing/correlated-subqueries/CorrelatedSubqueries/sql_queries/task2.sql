SELECT DISTINCT product_category.id, product_category.name
FROM product_category
INNER JOIN product_title ON product_title.product_category_id = product_category.id
INNER JOIN product ON product.product_title_id = product_title.id
INNER JOIN order_details ON order_details.product_id = product.id
ORDER BY product_category.id ASC;
