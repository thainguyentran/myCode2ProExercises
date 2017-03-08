#!/bin/bash

find /usr -type f 2>/dev/null | xargs -L 50 ls -la | awk '{print $9":"$5}' > files.dat

