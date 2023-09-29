-- Create the database
CREATE DATABASE student_fee_management;

-- Switch to the newly created database
USE student_fee_management;

-- Create the table to store student fee information
CREATE TABLE student_fees (
    id CHAR(36) PRIMARY KEY,
    student_id CHAR(36),
    amount DECIMAL(10, 2),
    due_date DATETIME,		
    is_paid BOOLEAN
);
