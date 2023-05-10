SELECT
SUM(quantity) AS product_total,
SUM(quantity * price) AS to_pay_total,
SUM(quantity * price * (discount / 100.0)) AS discount_total
FROM order_details
WHERE discount > 0;