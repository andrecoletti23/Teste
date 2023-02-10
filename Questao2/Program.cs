using Newtonsoft.Json;

public class Program
{
    static void Main(string[] args)
        {
            Console.WriteLine(GetGoalsByTeamAndYear("Paris Saint-Germain", 2013).Result);
            Console.WriteLine(GetGoalsByTeamAndYear("Chelsea", 2014).Result);
            Console.ReadLine();
        }

        static async Task<string> GetGoalsByTeamAndYear(string teamName, int year)
        {
            int goalsScored = 0;
            int page = 1;
            bool moreData = true;

            while (moreData)
            {
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?team1={teamName}&year={year}&page={page}";

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        dynamic data = JsonConvert.DeserializeObject(result);

                        if (data.data.Count == 0)
                        {
                            moreData = false;
                        }
                        else
                        {
                            foreach (var match in data.data)
                            {
                                if (match.team1 == teamName)
                                {
                                    goalsScored += match.goals1;
                                }
                                else if (match.team2 == teamName)
                                {
                                    goalsScored += match.goals2;
                                }
                            }

                            page++;
                        }
                    }
                    else
                    {
                        return "Request failed";
                    }
                }
            }

            return $"Team {teamName} scored {goalsScored} goals in {year}";
        }
}