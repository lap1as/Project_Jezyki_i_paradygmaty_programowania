def harmonogram_zadan(tasks):
    tasks.sort(key=lambda x: x[1])  # Sort by finish time
    selected_tasks = []
    last_finish_time = 0

    for task in tasks:
        if task[0] >= last_finish_time:
            selected_tasks.append(task)
            last_finish_time = task[1]
    
    return selected_tasks

# Przykład
tasks = [(1, 4), (3, 5), (0, 6), (5, 7)]
print(harmonogram_zadan(tasks))
