# Directory Size

Calculate sizes of directories at any level, given input file ex03_files.dat and depth = 3:

```
./ex03.exe files.dat 3
```

## Input

### .dat files

The input file has format:

```
/full/path/filename:size_in_bytes
```

Levels:

```
/usr => level 1
/usr/bin => level 2
```

### JSON files

If you have difficulty using `.dat`, you can use JSON format (equivalent):

```
./ex03.exe files.json 3
```

Levels:

```
{
    "usr": {           /* level 1 */
        "bin": {       /* level 2 */

        },
        "local": {     /* level 2 */
            "bin": {   /* level 3 */

            }
        }
    }
}
```

## Output

Regardless of your input format, always produce output like this:

```
/full/path/directory_name:size_in_bytes
/usr/abc/def:1234567
/usr/abc/xyz:12345678
```
