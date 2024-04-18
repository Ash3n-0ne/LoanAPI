# LoanAPI
This project introduces a Web API designed for managing users' loans, facilitating user interactions with their loans, and enabling accountants to manage user accounts.

Accountant Controller:
Enables accountants to view, update, and delete loans. Accountants also possess the authority to temporarily block users, preventing them from initiating any loan transactions for a specified duration.

User Controller:
Facilitates user registration and authentication processes. Empowers users to access their personal information based on their unique ID. Additionally, users can submit loan requests contingent upon their account status (e.g., isBlocked).

Loan Entity:
Defines the essential attributes for loan requests, encompassing type, amount, currency, duration, and status.

Authorization:
Implements a role-based authorization system, distinguishing between accountant-specific functionalities and user privileges. Users possess restricted rights concerning loan requests and accessing their personal data.

Database Setup:
Outlines the procedural steps required for configuring the database.

