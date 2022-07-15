using leetocode;
using leetocode.AdOfCode;

var task = new Y2016D13();

var adj = task.GenerateAdjacencyList();

var bfs = new BFS(adj);

var r = bfs.DoBfsMagic();

Console.WriteLine(r);

return;
//using System;
//using leetocode;


//var s = new schule();

//s.LargestPerimeter(new int[] { 2, 1, 2 });

////Console.WriteLine(s.RoundTwoDigits(213.12421));
////Console.WriteLine(s.RoundTwoDigits(0.89123478392));
////Console.WriteLine(s.RoundTwoDigits(8932758923759.2398578932));
////Console.WriteLine(s.RoundTwoDigits(923759.234444449));
////Console.WriteLine(s.RoundTwoDigits(923759.23444444));

//return;

//pimTestCompare pimTestCompare = new pimTestCompare();

//pimTestCompare.CompareFiles();
//return;



//static string ToJadenCase(string phrase)
//{
//    var parts = phrase.Split(" ", StringSplitOptions.RemoveEmptyEntries);

//    var output = new List<string>();

//    foreach (var x in parts)
//    {
//        var fChar = char.ToUpper(x[0]);
//        var nofChar = x.Remove(0, 1);
//        output.Add(fChar.ToString() + nofChar);
//    }

//    return String.Join(" ", output);
//}


var m = new MADNOOP();
m.Play();
return;


var d = License("Zebediah", 1, "Bob Jim Becky Pat");
Console.WriteLine(d);

static string MaxOccur(string text)
{
    var occurences = new Dictionary<char, int>();
    foreach (var c in text)
    {
        if (occurences.ContainsKey(c))
        {
            occurences[c]++;
        }
        else
        {
            occurences.Add(c, 1);
        }

    }
    var h = occurences.MaxBy(c => c.Value);
    var r = occurences.Where(x => x.Value == h.Value).Select(x => x.Key).ToList();
    if (r.Count > 0)
        return String.Join(", ", r);
    else
        return r.ToString();
}

static int License(string me, int agents, string others)
{
    var allPeeps =
        (others + " " + me)
        .Split()
        .OrderBy(s => s)
        .ToList();

    int timeToFinish = 0;

    for (var i = 0; i < allPeeps.Count; i += agents)
    {
        timeToFinish += 20;
        for (var j = i; j < allPeeps.Count && j < agents + i; j++)
        {
            if (me == allPeeps[j])
            {
                return timeToFinish;
            }
        }
    }
    return -1;
}

static string ToJadenCase(string phrase)
{
    bool isNextFirst = true;
    var output = "";

    foreach (var x in phrase.ToArray())
    {
        if (isNextFirst && x != ' ')
        {
            output += char.ToUpper(x);
            isNextFirst = false;
            continue;
        }
        if (x == ' ')
        {
            isNextFirst = true;
        }
        output += x;
    }
    return output;

}

Console.WriteLine(ToJadenCase("How can mirrors be real if our eyes aren't real"));