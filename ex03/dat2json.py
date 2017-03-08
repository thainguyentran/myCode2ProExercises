#!/usr/bin/env python

import sys, json, re, os

def process_line(line, count):
    line = line.strip()
    if not re.search(r'^\/|^\\\\|^[a-zA-Z]\:\\', line):
        sys.stderr.write("Invalid start of the path on the line %d, full string: %s" % (count, line))
        return None
    terms = line.split(os.path.sep)
    # // Is treated as /; \\ is treated as \; Ignore current dir
    terms = [term for term in terms if term not in ['', '.']]
    if '..' in terms:
        sys.stderr.write("'..' Found in the path! Line %d, full string: %s" % (count, line))
        return None
    # Match the tail
    pat = ':\d+$'
    regex = re.compile(pat)
    last = terms.pop()
    if not regex.search(last):
        sys.stderr.write("Invalid tail on the line %d, full string: %s" % (count, line))
        return None
    index = last.rfind(':')
    filename, size = last[:index], last[index + 1:]
    terms.append(filename)
    return (terms, size)

def path2json(odict, terms, size):
    tdict = odict
    last = terms[-1]
    for term in terms[:-1]:
        if not term in tdict:
            tdict[term] = {}
        tdict = tdict[term]
    tdict[last] = size
    return odict

def dat2json(dat_file):
    odict = {}
    fh = open(dat_file)
    count = 0
    for line in fh:
        count += 1
        res = process_line(line, count)
        if res:
            terms, size = res
            path2json(odict, terms, size)
    fh.close()
    return odict

if __name__ == '__main__':
    if len(sys.argv) != 2:
        print("Usage: %s <file.dat>" % sys.argv[0])
        exit(0)
    output = dat2json(dat_file=sys.argv[1])
    print(json.dumps(output, sort_keys=True, indent=2))
