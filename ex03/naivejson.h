#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <memory>

class JSONValue {
public:
    enum {
        JSON_NULL = 0,
        JSON_STRING,
        JSON_OBJECT,
        JSON_ARRAY
    };

    JSONValue() {}

    virtual ~JSONValue() {}

    virtual void print(std::ostream&) const {}
};

std::ostream& operator<<(std::ostream& ostr, const JSONValue& jsonValue)
{
    jsonValue.print(ostr);

    return ostr;
}

class JSONObject: public JSONValue {
    std::map< std::string, std::shared_ptr<JSONValue> > m_elems;

public:
    typedef std::map< std::string, std::shared_ptr<JSONValue> >::iterator iterator;
    typedef std::map< std::string, std::shared_ptr<JSONValue> >::const_iterator const_iterator;

    JSONObject(): JSONValue() {}

    ~JSONObject() {}

    void set(const std::string& key, std::shared_ptr<JSONValue> val)
    {
        m_elems[key] = val;
    }

    template<typename T>
    std::shared_ptr<T> get(const std::string& key)
    {
        return std::static_pointer_cast<T>(m_elems[key]);
    }

    iterator begin()
    {
        return m_elems.begin();
    }

    iterator end()
    {
        return m_elems.end();
    }

    virtual void print(std::ostream& ostr) const
    {
        ostr << "{\n";
        for (const auto& kv: m_elems)
        {
            ostr << "\""<< kv.first << "\": " << *kv.second << ",\n";
        }
        ostr << "}\n";
    }
};

class JSONArray: public JSONValue {
    std::vector< std::shared_ptr<JSONValue> > m_elems;

public:
    typedef std::vector< std::shared_ptr<JSONValue> >::iterator iterator;
    typedef std::vector< std::shared_ptr<JSONValue> >::const_iterator const_iterator;

    JSONArray(): JSONValue() {}

    void add(std::shared_ptr<JSONValue> val)
    {
        m_elems.push_back(val);
    }

    iterator begin()
    {
        return m_elems.begin();
    }

    iterator end()
    {
        return m_elems.end();
    }

    virtual void print(std::ostream& ostr) const
    {
        ostr << "[\n";
        for (const auto& value: m_elems)
        {
            ostr << "" << *value << "," << "\n";
        }
        ostr << "]\n";
    }
};

class JSONString: public JSONValue {
    std::string m_value;
public:
    JSONString(const std::string& str): JSONValue(), m_value(str) {}

    void set(const std::string& str)
    {
        m_value = str;
    }

    virtual void print(std::ostream& ostr) const
    {
        ostr << '"' << m_value << '"';
    }
};

std::shared_ptr<JSONValue> make(const std::string& str)
{
    return std::shared_ptr<JSONValue>(new JSONString(str));
}
