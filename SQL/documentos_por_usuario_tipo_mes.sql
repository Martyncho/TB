-- Agrupación de documentos por usuario, tipo de documento, paso y año/mes de checkin
-- Columnas agrupadas: r.name, e.doc_type_name, s.name, año/mes de checkin

SELECT
    r.name                          AS usuario,
    e.doc_type_name                 AS tipo_documento,
    s.name                          AS paso,
    FORMAT(checkin, 'yyyy/MM')      AS anio_mes,
    COUNT(*)                        AS total
FROM wfdocument w
INNER JOIN wfstep s          ON s.step_id     = w.step_id
INNER JOIN zuser_or_group r  ON r.id          = w.user_asigned
INNER JOIN doc_type e        ON e.doc_type_id = w.doc_type_id
WHERE
    user_asigned <> 0
    AND checkin < '01/01/2025'
GROUP BY
    r.name,
    e.doc_type_name,
    s.name,
    FORMAT(checkin, 'yyyy/MM')
ORDER BY
    r.name,
    e.doc_type_name,
    s.name,
    FORMAT(checkin, 'yyyy/MM');
