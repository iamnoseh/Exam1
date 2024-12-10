CREATE TABLE students
(
    student_id serial primary key,
    student_code varchar(12),
    student_full_name varchar(50),
    gender varchar(6),
    dob timestamp,
    email varchar(50) unique,
    phone VARCHAR(15),
    school_id int REFERENCES schools(school_id),
    stage int ,
    section char(2),
    is_active bool default true,
    join_date TIMESTAMP,
    created_at timestamp,
    updated_at TIMESTAMP
);

CREATE TABLE student_parents
(
    student_parent_id serial primary key,
    student_id int REFERENCES students(student_id),
    parent_id int,
    reletionship int
);

CREATE TABLE parents
(
    parent_id int REFERENCES student_parents(student_parent_id),
    parent_full_name varchar(50),
    parent_code varchar(12),
    email varchar(50) UNIQUE,
    phone varchar(15),
    create_at timestamp,
    updated_at timestamp
);
-- CREATE TABLE schools
-- (
-- 	school_id serial primary key,
-- 	school_title varchar(50),
-- 	level_count int,
-- 	is_active bool,
-- 	created_at TIMESTAMP,
-- 	updated_at timestamp
-- );
-- CREATE TABLE class_students
-- (
-- 	class_students_id serial PRIMARY key,
-- 	class_id int,
-- 	student_id int
-- );
CREATE TABLE class
(
    class_id serial primary key,
    class_name varchar(50),
    subject_id int REFERENCES subjects(subject_id),
    teacher_id int REFERENCES teachers(teacher_id),
    classroom_id int REFERENCES classroms(classroom_id),
    section varchar(6),
    created_at timestamp,
    updated_at timestamp
);
-- CREATE TABLE subjects
-- (
-- 	subject_id serial PRIMARY key,
-- 	title varchar(100),
-- 	school_id int REFERENCES schools(school_id),
-- 	stade int,
-- 	team int,
-- 	carry_mark int,
-- 	created_at timestamp,
-- 	updated_at timestamp
-- );

-- CREATE TABLE teachers
-- (
-- 	teacher_id serial primary key,
-- 	teacher_code varchar(12),
-- 	teacher_full_name varchar(75),
-- 	gender varchar(6),
-- 	dob timestamp,
-- 	email varchar(50) unique,
-- 	phone varchar(15),
-- 	is_active bool,
-- 	join_date timestamp,
-- 	working_days timestamp,
-- 	created_at timestamp,
-- 		updated_at timestamp
--  );

-- CREATE TABLE classroms
-- (
-- 	classroom_id serial primary key,
-- 	capacity int,
-- 	room_type int,
-- 	description varchar(100),
-- 		created_at timestamp,
-- 		updated_at timestamp
-- );