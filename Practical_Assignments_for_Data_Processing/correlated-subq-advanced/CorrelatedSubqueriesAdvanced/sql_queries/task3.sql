SELECT 
  p.id AS product_id,
  pt.title,
  m.id AS manufacturer_id,
  m.name AS manufacturer
FROM product AS p
JOIN product_title AS pt ON p.product_title_id = pt.id
LEFT JOIN (
  SELECT product_title_id, manufacturer_id, COUNT(*) AS cnt
  FROM product
  GROUP BY product_title_id, manufacturer_id
  ) AS cnt_table ON p.product_title_id = cnt_table.product_title_id AND p.manufacturer_id = cnt_table.manufacturer_id
LEFT JOIN manufacturer AS m ON p.manufacturer_id = m.id
LEFT JOIN (
  SELECT product_title_id, MAX(cnt) AS max_cnt
  FROM (
    SELECT product_title_id, manufacturer_id, COUNT(*) AS cnt
    FROM product
    GROUP BY product_title_id, manufacturer_id
  ) AS cnt_table
  GROUP BY product_title_id
  ) AS max_cnt_table ON p.product_title_id = max_cnt_table.product_title_id AND cnt_table.cnt = max_cnt_table.max_cnt
WHERE cnt_table.cnt = max_cnt_table.max_cnt OR cnt_table.cnt IS NULL
ORDER BY product_id ASC;
``
