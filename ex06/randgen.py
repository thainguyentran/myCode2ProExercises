#!/usr/bin/env python

import random, sys

def float_generator():
    return (random.random() - 0.3)*100000

def int_generator():
    return random.randint(-100000, 1000000)

def wrap_generator(func):
    def helper(qty):
        if qty < 0:
            raise Exception('Invalid quantity: %d. Must not be negative!' % qty)
        result = []
        for count in range(qty):
            result.append(func())
        return result
    return helper

generate_float = wrap_generator(float_generator)
generate_int = wrap_generator(int_generator)

ALLOWED_TYPES = {
    'FLOAT': generate_float,
    'INT': generate_int,
}

def generate(type, qty):
    if not type in ALLOWED_TYPES:
        raise Exception('Invalid type %s! Accepting only: %s'
                % (type, ALLOWED_TYPES.keys()))
    genfun = ALLOWED_TYPES[type]
    return genfun(qty)

if __name__ == '__main__':
    if len(sys.argv) == 3:
        type, qty = sys.argv[1], int(sys.argv[2])
        result = [str(x) for x in generate(type, qty)]
        print('\n'.join(result))
    else:
        allowed_types = '|'.join(ALLOWED_TYPES.keys())
        print('Usage: %s <%s> <qty>' % (sys.argv[0], allowed_types))
