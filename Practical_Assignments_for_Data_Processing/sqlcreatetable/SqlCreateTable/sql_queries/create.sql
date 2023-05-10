CREATE TABLE Employees (
    EmployeeID INTEGER PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Position VARCHAR(50) NOT NULL
);

CREATE TABLE Projects (
    ProjectID INTEGER PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    DateCreated DATE NOT NULL,
    Status ENUM('open', 'closed') NOT NULL,
    DateClosed DATE,
    CONSTRAINT check_status CHECK (Status IN ('open', 'closed'))
);

CREATE TABLE EmployeeProjects (
    EmployeeID INTEGER NOT NULL,
    ProjectID INTEGER NOT NULL,
    PRIMARY KEY (EmployeeID, ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);

CREATE TABLE Tasks (
    TaskID INTEGER PRIMARY KEY,
    ProjectID INTEGER NOT NULL,
    Description VARCHAR(100) NOT NULL,
    Deadline DATE NOT NULL,
    Status ENUM('open', 'completed', 'requires revision', 'accepted') NOT NULL,
    DateStatusSet DATE NOT NULL,
    EmployeeID INTEGER NOT NULL,
    CONSTRAINT check_task_status CHECK (Status IN ('open', 'completed', 'requires revision', 'accepted')),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE TaskComments (
    CommentID INTEGER PRIMARY KEY,
    TaskID INTEGER NOT NULL,
    Comment VARCHAR(100) NOT NULL,
    DateAdded DATE NOT NULL,
    EmployeeID INTEGER NOT NULL,
    FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE TaskAssignees (
    TaskID INTEGER NOT NULL,
    EmployeeID INTEGER NOT NULL,
    PRIMARY KEY (TaskID, EmployeeID),
    FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE TaskDependencies (
    DependentTaskID INTEGER NOT NULL,
    DependsOnTaskID INTEGER NOT NULL,
    PRIMARY KEY (DependentTaskID, DependsOnTaskID),
    FOREIGN KEY (DependentTaskID) REFERENCES Tasks(TaskID),
    FOREIGN KEY (DependsOnTaskID) REFERENCES Tasks(TaskID)
);
