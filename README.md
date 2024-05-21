# E-Learning Platform Documentation

Welcome to the E-Learning Platform, an online education portal similar to Udemy, designed to help students start their careers. This platform enables students to explore courses, interact with instructors, and manage their learning journey efficiently. This README file provides an overview of the project, its features, and how to get started.

## Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
  - [Student Features](#student-features)
  - [Instructor Features](#instructor-features)
  - [Admin Features](#admin-features)
- [Technologies and Concepts](#technologies-and-concepts)
## Project Overview
The E-Learning Platform is designed to provide a comprehensive learning experience, enabling students to browse, enroll, and complete courses. Instructors can create and manage courses, assignments, and exams, while administrators oversee the platform's overall functionality.

## Features

### Student Features
- **Browse Courses**: Students can search and filter courses to find the ones that meet their needs.
- **Course Information**: View detailed information about courses and instructors, including their courses, contact details, and images.
- **Enrollment and Payment**: Add courses to the cart and make payments using Stripe.
- **My Learning Section**: Access enrolled courses and view lectures with downloadable attachments (PDFs, images, videos).
- **Exams and Assignments**: Take exams with specific start and end times. After finishing an exam, receive his grade along with feedback on correct and incorrect answers. Submit assignments and receive grades and feedback as well.
- **Performance Tracking**: View grades for exams and assignments.
- **Standings**: View the standings of all students in the course, sorted by their cumulative grades, to see where you rank among your peers.

### Instructor Features
- **Course Management**: Add, update, and delete courses.
- **Lecture Management**: Create, update, and delete lectures, and Manage Lecture attachments (PDFs, images, videos).
- **Exam Management**: Create, update, delete exams and manage exam questions.
- **Assignment Management**: Create, update, and delete assignments.
- **Student Evaluation**: View and evaluate student submissions and assign grades.

### Admin Features
- **Instructor Management**: Add and remove instructors.
- **Platform Analytics**: View the total number of students, instructors, and platform income.

## Technologies and Concepts

### Technologies Used
- **Backend**: ASP.NET MVC, Entity Framework Core (EF Core), LINQ
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **Payment Gateway**: Stripe
- **Caching**: Redis
- **AJAX Calls**: JavaScript for dynamic content loading and filtering
- **Authentication and Authorization**: Identity

### Architectural Patterns and Concepts
- **3-Tier Architecture**: The application is divided into three layers - Presentation, Business Logic, and Data Access.
- **Repository Pattern**
- **Specification Pattern**: Used for filtering and searching courses. AJAX calls in JavaScript pass the specifications to the backend, which applies these specifications and returns a partial view with the desired courses.
- **Unit of Work**
- **AutoMapper**
- **Generic Repository**

