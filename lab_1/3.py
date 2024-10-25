def optymalizacja_zadan(tasks):
    tasks.sort(key=lambda x: x[1])  # Sort by execution time
    total_wait_time = 0
    current_time = 0
    for task in tasks:
        total_wait_time += current_time
        current_time += task[1]
    
    return total_wait_time, tasks

# Przykład
tasks = [(10, 3), (20, 2), (30, 1)]
print(optymalizacja_zadan(tasks))
