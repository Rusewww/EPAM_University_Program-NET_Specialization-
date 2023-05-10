SELECT city.id, city.name
FROM city
LEFT JOIN street ON street.city_id = city.id
WHERE street.id IS NULL
ORDER BY city.name ASC;
