SELECT product.id, product_title.title, product.price
FROM product
INNER JOIN (
  SELECT product_category_id, AVG(price) AS avg_price
  FROM product
  GROUP BY product_category_id
) AS category_avg_price ON product.product_category_id = category_avg_price.product_category_id
INNER JOIN product_title ON product.product_title_id = product_title.id
WHERE product.price > category_avg_price.avg_price
ORDER BY product.id ASC;
