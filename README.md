# Project Management Api

This project is a .NET Core Web API that provides an API for managing projects and tasks. It is designed for use by managers and employees, and it uses role authorization to control who can access which functions.

Features
The project management API includes the following features:

Create, read, update, and delete projects
Create, read, update, and delete tasks
Assign tasks to users
Set the status of tasks
View the progress of tasks
Filter tasks by project, status, and user
Role Authorization
The project management API uses role authorization to control who can access which functions. The following roles are defined:

Manager: Can create, read, update, and delete projects and tasks.
Employee: Can only view projects and tasks that they are assigned to.
