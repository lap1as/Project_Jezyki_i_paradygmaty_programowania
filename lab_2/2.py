import numpy as np

def validate_and_execute(operation, matrix_a, matrix_b=None):
    if operation == 'add' and matrix_b is not None:
        if matrix_a.shape == matrix_b.shape:
            return matrix_a + matrix_b
        else:
            raise ValueError("Incompatible dimensions for addition.")
    elif operation == 'multiply' and matrix_b is not None:
        if matrix_a.shape[1] == matrix_b.shape[0]:
            return np.dot(matrix_a, matrix_b)
        else:
            raise ValueError("Incompatible dimensions for multiplication.")
    elif operation == 'transpose':
        return matrix_a.T
    else:
        raise ValueError("Unknown operation or missing matrix.")

# Test Data
matrix_a = np.array([[1, 2], [3, 4]])
matrix_b = np.array([[5, 6], [7, 8]])

# Running test for addition
result_add = validate_and_execute('add', matrix_a, matrix_b)
expected_add = np.array([[6, 8], [10, 12]])
assert np.array_equal(result_add, expected_add)

# Fixing the dimensions for multiplication test
matrix_c = np.array([[1, 2], [3, 4]])
result_mul = validate_and_execute('multiply', matrix_a, matrix_c)
expected_mul = np.array([[7, 10], [15, 22]])  # Expected multiplication result
assert np.array_equal(result_mul, expected_mul)

print("Zadanie 2 passed.")
