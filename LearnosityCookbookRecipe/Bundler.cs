using System;

namespace LearnosityCookbookRecipe
{
	public class Bundler
	{
        // To Limit On Network Traffic This Class Will Bundle All Seraliazed JSON into Packets of 50 (The Max Per Request) 
        private List<string> jsonList = new List<string>();

        public string[] Bundle(string json)
		{
            if (jsonList.Count < 50)
            {
               jsonList.Add(json);

            }
            return jsonList.ToArray();

        }
    }
}

