import json
import os

class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def to_dict(self):
        return {'name': self.name, 'age': self.age, 'salary': self.salary}

class EmployeeManager:
    def __init__(self, filename):
        self.filename = filename
        self.employees = self.load_employees()

    def load_employees(self):
        if os.path.exists(self.filename):
            with open(self.filename, 'r', encoding='utf-8') as file:
                return [Employee(e['name'], e['age'], e['salary']) for e in json.load(file)]
        return []

    def save_employees(self):
        with open(self.filename, 'w', encoding='utf-8') as file:
            json.dump([e.to_dict() for e in self.employees], file, indent=4)

    def add_employee(self, name, age, salary):
        if self.validate_employee_data(name, age, salary):
            self.employees.append(Employee(name, age, salary))
            self.save_employees()
            print(f"Pracownik {name} dodany.")
        else:
            print("Błąd: Nieprawidłowe dane.")

    def display_employees(self):
        if self.employees:
            for emp in self.employees:
                print(f"{emp.name} | Wiek: {emp.age} | Pensja: {emp.salary}")
        else:
            print("Brak pracowników.")

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        self.save_employees()
        print(f"Usunięto pracowników w wieku {min_age}-{max_age}.")

    def update_salary(self, name, new_salary):
        for emp in self.employees:
            if emp.name.lower() == name.lower():
                emp.salary = new_salary
                self.save_employees()
                print(f"Wynagrodzenie {name} zaktualizowane.")
                return
        print(f"Pracownik {name} nie znaleziony.")

    def validate_employee_data(self, name, age, salary):
        return name and isinstance(age, int) and age >= 18 and isinstance(salary, (int, float)) and salary >= 0

def login():
    username = input("Login: ")
    password = input("Hasło: ")
    return username == "admin" and password == "admin"

def main():
    filename = 'employees.json'
    manager = EmployeeManager(filename)

    if login():
        while True:
            print("\n1. Dodaj pracownika")
            print("2. Wyświetl pracowników")
            print("3. Usuń pracowników w przedziale wiekowym")
            print("4. Zaktualizuj pensję")
            print("5. Zakończ")

            choice = input("Wybór: ")

            match choice:
                case "1":
                    name = input("Imię: ")
                    age = int(input("Wiek: "))
                    salary = float(input("Pensja: "))
                    manager.add_employee(name, age, salary)

                case "2":
                    manager.display_employees()

                case "3":
                    min_age = int(input("Minimalny wiek: "))
                    max_age = int(input("Maksymalny wiek: "))
                    manager.remove_employees_by_age_range(min_age, max_age)

                case "4":
                    name = input("Imię pracownika: ")
                    new_salary = float(input("Nowa pensja: "))
                    manager.update_salary(name, new_salary)

                case "5":
                    print("Zakończono program.")
                    break

                case _:
                    print("Nieprawidłowy wybór. Spróbuj ponownie.")


if __name__ == "__main__":
    main()