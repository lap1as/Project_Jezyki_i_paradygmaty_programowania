from functools import reduce
import numpy as np

def matrix_reduce(matrices, operation):
    return reduce(lambda x, y: eval(f'np.{operation}(x, y)'), matrices)

# Test Data
matrices = [
    np.array([[1, 2], [3, 4]]),
    np.array([[5, 6], [7, 8]]),
    np.array([[9, 10], [11, 12]])
]

# Running test for addition
result_reduce_add = matrix_reduce(matrices, 'add')
expected_reduce_add = np.array([[15, 18], [21, 24]])
assert np.array_equal(result_reduce_add, expected_reduce_add)

# Fixing the dimensions for multiplication test
matrices_mul = [
    np.array([[1, 2], [3, 4]]),
    np.array([[5, 6], [7, 8]])
]
result_reduce_mul = matrix_reduce(matrices_mul, 'dot')
expected_reduce_mul = np.array([[19, 22], [43, 50]])
assert np.array_equal(result_reduce_mul, expected_reduce_mul)

print("Zadanie 4 passed.")
