# LRU (OS / Interview Question)

When data grows and you need to access certain chunks of data as quick as possible, you may need caching to improve performance. Least Recently Used (LRU) cache is one way to do in-memory caching. It is used by some [Operating System operations](http://lxr.free-electrons.com/source/mm/swap.c#L660) and also used in popular caching services such as [memcached](https://github.com/memcached/memcached/wiki/UserInternals) and [Redis](https://redis.io/topics/lru-cache) .

For the purpose of this kata, you need to implement a Least Recently Used (LRU) cache. The cached values are English words (lower case). We do not have key-value pairing, size limit or expiry time to keep our cache simple.

Here are the functions / features to implement:

* `set(value)`: Add value to the cache
* `front()`: Get the most recent value
* `back()`: Get the least recent value
* `dump()`: Print all values from the order of recency - from `front()` to `back()`

**NOTE:**

* The functions `front()`, `back()`, and `dump()` have no side effects and do not change the cache!
* You will need to accompany your implementation with test cases to verify that your implementation is correct.
* Think about TDD - Test Driven Development.
* Keep your code simple and keep everything in 1 file.
* Only use standard library or built-in features. Do not use any other library or package!
