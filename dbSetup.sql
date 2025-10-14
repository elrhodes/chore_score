-- Active: 1760459921661@@mysql.codeworksacademy.com@3306@wise_mermaid_7301_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE chores (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    difficulty TINYINT NOT NULL,
    isComplete BOOLEAN NOT NULL
    -- make sure to not have a comma on the last line of a table creation
)

DROP TABLE chores;
-- here i have set up a table for my chores with the columns id, name, description, difficulty, and is_complete, I have also used the Insert INTO statement to add 5 chores to the table as well as created some select statements to view the data in different ways;
INSERT INTO
    chores (
        name,
        description,
        difficulty,
        isComplete
    )
VALUES (
        'Wash Dishes',
        'Clean all the dishes in the sink',
        2,
        false
    ),
    (
        'Vacuum Living Room',
        'Vacuum the entire living room area',
        3,
        false
    ),
    (
        'Mow Lawn',
        'Mow the front and back lawn',
        4,
        false
    ),
    (
        'Take Out Trash',
        'Take out all household trash to the curb',
        1,
        false
    ),
    (
        'Clean Bathroom',
        'Scrub the toilet, sink, and shower',
        5,
        false
    );

SELECT * FROM chores;
-- This select statement will show all the chores in the table

SELECT name, difficulty
FROM chores
WHERE
    is_complete = false
ORDER BY difficulty DESC;
-- This select statement will show the name and difficulty of all chores that are not complete, ordered by difficulty from highest to lowest

SELECT * FROM chores WHERE id = 3;
-- This select statement will show the chore with an id of 3

DESCRIBE chores;