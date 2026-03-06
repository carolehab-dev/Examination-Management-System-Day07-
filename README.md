# Console-Based Examination Management System

## Project Overview
This project implements a **Console-Based Examination Management System** using **C#** and **Object-Oriented Programming (OOP)** principles.

The system allows managing different types of questions and exams, automatically correcting answers, and notifying students when an exam starts. It also logs questions and exam results into files.

---

## Main Features

- Multiple question types  
- Practice and Final exams  
- Automatic answer correction  
- Exam lifecycle management  
- Student notifications using events  
- File logging for questions and results  
- Generic repository with constraints  
- All collections implemented using **arrays (`T[]`)** as required (**no List used**)

---

## Design Decisions

### Question Hierarchy

An abstract class **`Question`** defines shared properties and behaviors for all question types.

#### Derived Question Types
- `TrueFalseQuestion`
- `ChooseOneQuestion`
- `ChooseAllQuestion`

Each class overrides:

- `Display()` → shows the question  
- `CheckAnswer()` → validates the student’s answer  

**Polymorphism** is used during exam correction by calling `CheckAnswer()` without knowing the exact question type.

---

### Exam Hierarchy

An abstract class **`Exam`** manages:

- Exam duration  
- Question array  
- Exam mode  
- Student answers  
- Correction logic  

#### Derived Exam Types

**PracticeExam**  
- Shows correct answers and grade after correction.

**FinalExam**  
- Shows only the final grade without revealing correct answers.

This design follows the **Open/Closed Principle**.

---

### Event System

An event **`ExamStarted`** is declared inside the `Exam` class.

When the exam starts:

1. Exam mode changes to **Starting**
2. The event is triggered
3. Subscribed students receive notification

This demonstrates the use of:

- **Delegates**
- **Events**
- **Loose coupling**

---

### File Logging

#### Question Logging
The `QuestionList` class logs added questions to a unique file using **`StreamWriter`** in append mode.

#### Exam Result Logging
After an exam finishes, results are stored in **`ExamResults.txt`**.

The file includes:

- Subject name  
- Exam type  
- Student answers  
- Correctness of each answer  
- Final grade  

---

### Exam Duration

Exam time is controlled using **`DateTime`** to track elapsed time instead of blocking execution using **`Thread.Sleep`**.

---

### Generics

A generic class **`Repository<T>`** was implemented with constraints:

```
T : ICloneable
T : IComparable
```

Features:

- Internally uses **arrays (`T[]`)**
- Provides **type safety**
- Allows reusable storage logic for multiple object types

---

## OOP Concepts Applied

- Inheritance  
- Polymorphism  
- Encapsulation  
- Abstraction  
- Method overriding  
- Events and Delegates  
- Enum usage  
- Generics with constraints  
- Composition  
- Aggregation  

---

## Technologies Used

- **C#**
- **.NET Console Application**
- **Object-Oriented Programming**
