#!/usr/bin/env python

import sys, json, re, os

def add_keys_stack(output, keys):
    output.extend([('tmpObj->set("%s", std::shared_ptr<JSONObject>(new JSONObject));' % key) for key in keys])
    output.extend([('stack.push(tmpObj->get<JSONObject>("%s"));' % key) for key in keys])
    return output

def json2cpp(odict):
    TEMPLATE_STR = '''
#include <stack>

#include "naivejson.h"

std::shared_ptr<JSONValue> createJSONObject()
{
    std::stack< std::shared_ptr<JSONObject> > stack;
    std::shared_ptr<JSONObject> obj(new JSONObject);
    std::shared_ptr<JSONObject> tmpObj;

    stack.push(obj);
    tmpObj = stack.top(); stack.pop();

    %s

    return obj;
}

int main()
{
    std::shared_ptr<JSONValue> obj = createJSONObject();

    std::cout << *obj << std::endl;

    return 0;
}
'''
    output = []
    key_stack = list(sorted(odict.keys()))
    value_stack = [odict[key] for key in key_stack]
    add_keys_stack(output, key_stack)

    while len(key_stack) > 0:
        node_key = key_stack.pop()
        tdict = value_stack.pop()
        output.append('tmpObj = stack.top(); stack.pop();')
        if isinstance(tdict, dict):
            keys = list(sorted(tdict.keys()))
            for key in keys:
                if isinstance(tdict[key], dict):
                    key_stack.append(key)
                    value_stack.append(tdict[key])
                    output.append('tmpObj->set("%s", std::shared_ptr<JSONObject>(new JSONObject));' % key)
                    output.append('stack.push(tmpObj->get<JSONObject>("%s"));' % key)
                else:
                    output.append('tmpObj->set("%s", make("%s"));' % (key, re.escape(tdict[key])))
        else:
            output.append('tmpObj->set("%s", make("%s"));' % (node_key, re.escape(tdict)))
    return (TEMPLATE_STR % '\n    '.join(output))

if __name__ == '__main__':
    if len(sys.argv) != 2:
        print("Usage: %s <file.json>" % sys.argv[0])
        exit(0)
    fh = open(sys.argv[1])
    odict = json.load(fh)
    output = json2cpp(odict)
    print(output)
    fh.close()
