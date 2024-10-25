from collections import deque

def bfs(graph, start, end):
    def bfs_inner(queue, visited):
        if not queue:
            return []
        
        path = queue.popleft()
        node = path[-1]

        if node == end:
            return path
        
        neighbors = [neighbor for neighbor in graph[node] if neighbor not in visited]
        visited.update(neighbors)
        queue.extend([path + [neighbor] for neighbor in neighbors])
        
        return bfs_inner(queue, visited)

    return bfs_inner(deque([[start]]), {start})

# Przykład grafu
graf = {
    'A': ['B', 'C'],
    'B': ['D', 'E'],
    'C': ['F'],
    'D': [],
    'E': ['F'],
    'F': []
}
print(bfs(graf, 'A', 'F'))
