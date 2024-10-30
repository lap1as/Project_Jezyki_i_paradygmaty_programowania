def generate_code(template, context):
    code = template.format(**context)
    local_scope = {}
    try:
        exec(code, globals(), local_scope)
        return local_scope['generated_function']
    except Exception as e:
        return f"Error executing code: {e}"

# Test Data
template = """
def generated_function(x):
    return x + {value}
"""
context = {'value': 5}

# Running test
generated_function = generate_code(template, context)
assert generated_function(3) == 8  # Check if the dynamically generated function works

print("Zadanie 5 passed.")
