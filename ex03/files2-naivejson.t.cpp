
#include <stack>

#include "naivejson.h"

std::shared_ptr<JSONValue> createJSONObject()
{
    std::stack< std::shared_ptr<JSONObject> > stack;
    std::shared_ptr<JSONObject> obj(new JSONObject);
    std::shared_ptr<JSONObject> tmpObj;

    stack.push(obj);
    tmpObj = stack.top(); stack.pop();

    tmpObj->set("usr", std::shared_ptr<JSONObject>(new JSONObject));
    stack.push(tmpObj->get<JSONObject>("usr"));
    tmpObj = stack.top(); stack.pop();
    tmpObj->set("bin", std::shared_ptr<JSONObject>(new JSONObject));
    stack.push(tmpObj->get<JSONObject>("bin"));
    tmpObj = stack.top(); stack.pop();
    tmpObj->set("2to3", make("925"));
    tmpObj->set("2to3-", make("925"));
    tmpObj->set("AssetCacheLocatorUtil", make("43456"));
    tmpObj->set("a2p", make("66816"));
    tmpObj->set("a2p5.16", make("230400"));
    tmpObj->set("a2p5.18", make("230400"));
    tmpObj->set("addftinfo", make("33760"));
    tmpObj->set("afclip", make("46688"));
    tmpObj->set("afconvert", make("106608"));
    tmpObj->set("afhash", make("37008"));
    tmpObj->set("afida", make("75696"));
    tmpObj->set("afinfo", make("83392"));
    tmpObj->set("afmtodit", make("162321"));
    tmpObj->set("afplay", make("38304"));
    tmpObj->set("afscexpand", make("41744"));
    tmpObj->set("agentxtrap", make("30048"));
    tmpObj->set("agvtool", make("18256"));
    tmpObj->set("alias", make("190"));
    tmpObj->set("applesingle", make("37040"));
    tmpObj->set("apply", make("18912"));
    tmpObj->set("apropos", make("1808"));
    tmpObj->set("ar", make("18240"));
    tmpObj->set("arch", make("66752"));
    tmpObj->set("as", make("18240"));
    tmpObj->set("asa", make("18240"));
    tmpObj->set("asctl", make("144272"));
    tmpObj->set("assetutil", make("850272"));
    tmpObj->set("at", make("83584"));
    tmpObj->set("atos", make("66800"));
    tmpObj->set("atq", make("83584"));
    tmpObj->set("atrm", make("83584"));
    tmpObj->set("atsutil", make("28880"));
    tmpObj->set("automator", make("38656"));
    tmpObj->set("auval", make("200"));
    tmpObj->set("auvaltool", make("273456"));
    tmpObj->set("avbdiagnose", make("61088"));
    tmpObj->set("avbutil", make("50928"));
    tmpObj->set("avconvert", make("95072"));
    tmpObj->set("avmetareadwrite", make("33392"));
    tmpObj->set("awk", make("112384"));
    tmpObj->set("banner", make("31056"));
    tmpObj->set("base64", make("23216"));
    tmpObj->set("basename", make("18256"));
    tmpObj->set("bashbug", make("6574"));
    tmpObj->set("batch", make("83584"));
    tmpObj->set("bc", make("85280"));
    tmpObj->set("bg", make("190"));
    tmpObj->set("biff", make("18176"));
    tmpObj->set("binhex", make("45712"));
    tmpObj->set("binhex.pl", make("811"));

    return obj;
}

int main()
{
    std::shared_ptr<JSONValue> obj = createJSONObject();

    std::cout << *obj << std::endl;

    return 0;
}

