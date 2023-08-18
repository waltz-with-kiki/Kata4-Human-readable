using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class HumanTimeFormat
{
    delegate string Callback1(int item);

    public static string formatDuration(int seconds)
    {
        if (seconds == 0) return "now";
        Callback1[] mes1 = { Years, Days, Hours, Minutes, Seconds };
        List<string> res1 = mes1.Where(x => x(seconds) != "").Select(x => x(seconds)).ToList();
        int i = 0;
        string res = "";
        foreach (var item in res1)
        {
            res += item;
            if (i < res1.Count - 2)
            {
                res += ", ";
            }
            if (i == res1.Count - 2)
            {
                res += " and ";
            }
            i++;
        }
        return res;
    }

    static string Years(int seconds)
    {
        int item = seconds / 31536000;

        if (item == 1)
        {
            return "1 year";
        }
        if (item != 0)
        {
            return $"{item} years";
        }
        else return "";
    }

    static string Days(int seconds)
    {
        int item = (seconds % 31536000) / 86400;
        if (item == 1)
        {
            return "1 day";
        }
        if (item != 0)
        {
            return $"{item} days";
        }
        else return "";
    }



    static string Hours(int seconds)
    {
        int item = ((seconds % 31536000) % 86400) / 3600;
        if (item == 1)
        {
            return "1 hour";
        }
        if (item != 0)
        {
            return $"{item} hours";
        }
        else return "";
    }

    static string Minutes(int seconds)
    {
        int item = (((seconds % 31536000) % 86400) % 3600) / 60;
        string minutes = "minutes";
        if (item == 1)
        {
            minutes = "minute";
        }

        if (item != 0)
        {
            return $"{item} {minutes}";
        }
        else return "";
    }

    static string Seconds(int seconds)
    {
        int item = (((seconds % 31536000) % 86400) % 3600) % 60;
        if (item == 1)
        {
            return $"1 second";
        }
        if (item != 0)
        {
            return $"{item} seconds";
        }
        else return "";
    }
}