using System;
using System.Text;
using LearnositySDK.Request;
using LearnositySDK.Utils;
using System.Collections.Generic;
using LearnositySDK;
using System.Net;
using System.Text.Json.Nodes;

namespace LearnosityCookbookRecipe
{
    public class Data
    {
        public static string RequestCredentials(out string JSON)
        {
            LearnositySDK.Utils.JsonObject security = new LearnositySDK.Utils.JsonObject();
            security.set("consumer_key", Secrets.ConsumerKey);
            security.set("domain", Secrets.Domain);

            string secret = Secrets.ConsumerSecret;

            LearnositySDK.Utils.JsonObject request = new LearnositySDK.Utils.JsonObject();
            request.set("limit", 1000);

            string action = "get";

            Init i = new Init(service, security, secret, request, action);
            string parameters = i.generate();
            Remote remote = new Remote();
            Remote r = remote.post(url, parameters);

            JSON = parameters;
            return r.getBody();
        }

    }
}