SELECT 
  p.id,
  pt.title,
  SUM(CASE WHEN od.price_with_discount * 100 / od.price > 105 THEN od.product_amount ELSE 0 END) AS count_with_discount_5,
  SUM(CASE WHEN od.price_with_discount * 100 / od.price <= 105 THEN od.product_amount ELSE 0 END) AS count_without_discount_5,
  100 * SUM(CASE WHEN od.price_with_discount * 100 / od.price > 105 THEN od.product_amount ELSE 0 END) / NULLIF(SUM(CASE WHEN od.price_with_discount * 100 / od.price <= 105 THEN od.product_amount ELSE 0 END), 0) AS difference
FROM product AS p
JOIN product_title AS pt ON p.product_title_id = pt.id
LEFT JOIN order_details AS od ON p.id = od.product_id
GROUP BY p.id, pt.title
HAVING SUM(CASE WHEN od.price_with_discount * 100 / od.price > 105 THEN od.product_amount ELSE 0 END) > 0
ORDER BY p.id ASC;
