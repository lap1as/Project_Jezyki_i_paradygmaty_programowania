def analyze_data(data):
    numbers = list(filter(lambda x: isinstance(x, (int, float)), data))
    max_number = max(numbers) if numbers else None
    
    strings = list(filter(lambda x: isinstance(x, str), data))
    longest_string = max(strings, key=len) if strings else None
    
    tuples = list(filter(lambda x: isinstance(x, tuple), data))
    largest_tuple = max(tuples, key=len) if tuples else None
    
    return max_number, longest_string, largest_tuple

# Test Data
data = [5, "hello", (1, 2), 3.14, "world", [3, 4], (3, 4, 5), 42, "longest_string", {"key": "value"}]

# Running test
max_number, longest_string, largest_tuple = analyze_data(data)

assert max_number == 42
assert longest_string == "longest_string"
assert largest_tuple == (3, 4, 5)

print("Zadanie 3 passed.")
