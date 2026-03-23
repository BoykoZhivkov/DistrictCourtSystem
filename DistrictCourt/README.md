# District Court System
## OOP Principles in the Project
1. Abstraction
- `Case` **Class**: Defined as `abstract` because a "case" is a generic concept. It cannot be instantiated on its own.
- `Conduct()`**Method**: An abstract method that forces derived classes (`CivilianCase` and `CriminalCase`) to define their own specific logic for how a trial is held.
2. Encapsulation
- **Data Access**: Fields such as `_fileName` in the `Case` class are `readonly`. Access to sensitive data, like lists ot witnesses and jurors in the `Case` class is controlled through methods like `AddJuror()` and `AddWitness()`, which prevents data duplication.
- **Properties**: Automatic and controlled properties with `get/set` accessors are used throughout the system to manage state safely. 
3. Inheritance
- **Legal Entities Hierarchy**: `Judge`, `Prosecutor`, `Juror` and `Lawyer` inherit from the `LegalEntity` base class, reusing common logic.
- **Citizen Hierarchy**: `Defendant`, `Accuser`, `Witness`.
- **Case Hierarchy**: `CivilianCase`, `CriminalCase`.
4. Polymorphism
   - **Interface Polymorphism**: Through the `IAccuser` interface, the system can treat both a private `Accuser` (citizen) and a `Prosecutor` (legal entity) interchangeably within the context of the case.
   - **Overriding**: The `Conduct()` method behaves differently depending on whether the object is an instance of `CivilianCase` or `CriminalCase`, allowing for dynamic behavior at runtime.