#include "naivejson.h"

int main()
{
    JSONArray array;
    JSONObject object;
    std::shared_ptr<JSONValue> emailPtr(make("viet@code2.pro"));
    std::shared_ptr<JSONValue> namePtr(make("Viet Le"));

    array.add(namePtr);
    array.add(emailPtr);

    object.set("name", namePtr);
    object.set("email", emailPtr);

    std::cout << array;
    std::cout << object;
}
