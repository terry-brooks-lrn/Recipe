using System;
using System.Text;
using System.Text.Json;
using LearnositySDK.Request;
using LearnositySDK.Utils;
using System.Collections.Generic;

namespace LearnosityCookbookRecipe
{
    public class Data
    {
        public static string DataAPIRequest(out string JSON)
        {
            var service = "data";
            var questionsUrl = "https://data.learnosity.com/v2023.1.LTS/itembank/questions";
            var featuresUrl = "https://data.learnosity.com/v2023.1.LTS/itembank/features";


            LearnositySDK.Utils.JsonObject security = new LearnositySDK.Utils.JsonObject();
            security.set("consumer_key", Secrets.ConsumerKey);
            security.set("domain", Secrets.Domain);

            string secret = Secrets.ConsumerSecret;

            Dictionary<string, object> dictionary = new Dictionary<string, object>>;
            dictionary["questions"] = new Array<Dictionary<string, object>>;

            dictionary["questions"]
            // Seralized Data from Dict to String Before Request is 
            var request = JsonSerializer.Serialize(dictionary);

            string action = "set";
            var securityPacket = JsonSerializer.Serialize(security);

            Init i = new Init(service, securityPacket, secret, request, action);
            string parameters = i.generate();
            Remote remote = new Remote();
            Remote r = remote.post(questionsUrl, parameters);

            JSON = parameters;
            return r.getBody();
        }

    }
}
