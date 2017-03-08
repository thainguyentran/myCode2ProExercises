# Matching Brackets (Modified Uber Interview Question)

Write a function to match `(){}[]` for your editor:

```
#include <iostream>
#include <vector>

void printVector(const std::vector<int>& container)
{
    for (int i = 0; i < container.size(); ++i)
    {
        std::cout << container[i] << std::endl;
    }
}
```

## Sample input/output

### If all `(){}[]` are matching

```
./ex04.exe input.cpp
ALL-MATCHING
```

### If any of `(){}[]` is unmatched

```
./ex04.exe input.cpp
UNMATCHED
```

### If there are no `(){}[]` in the file

```
./ex04.exe input.cpp
NO-WORRIES
```
