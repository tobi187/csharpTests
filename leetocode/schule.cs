using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode
{
    public class schule
    {
        public bool getSchaltjahr(int jahresZahl)
        {
            var stZahl = jahresZahl.ToString();

            if (stZahl.Length > 4)
            {
                if (jahresZahl % 4 != 0) return true;
                else return false;
            }
            else
            {
                if (stZahl.Substring(2) == "00")
                {
                    if (jahresZahl % 400 == 0 && jahresZahl % 4 == 0) return true;
                    else return false;
                }
                else
                {
                    if (jahresZahl % 4 == 0) return true;
                    else return false;
                }
            }
        }

        public void getCombinations(float[] prices)
        {
            var priceListe = prices.ToList();

            // Tiere für genau 100 euronen einkaufen: maus: 0.5 katze: 4.5 hund: 5
            // es müssen min 100 tiere sein, bei mehreren Kombinationsmgl alle ausgeben
            // b: katzen: 2.5 




        }

        public double RoundTwoDigits(double nr)
        {
            var s = nr.ToString();
            var parts = s.Split(',');
            var bPart = parts[1];
            var index = 2;

            if (bPart.Length < 3)
                return nr;

            var val = bPart[index];

            while (bPart[index] == '4')
            {
                if (index == bPart.Length - 1)
                    break;
                index++;
                val = bPart[index];
            }

            var ouptut = string.Join("", parts[0]) + "," + parts[1][0];

            if (int.Parse(val.ToString()) > 4)
            {
                var n = int.Parse((parts[1][1]).ToString()) + 1;
                return double.Parse(ouptut + n.ToString());
            }
            else
            {
                return double.Parse(ouptut + (parts[1][1]).ToString());
            }

        }

        public int LargestPerimeter(int[] nums)
        {
            if (nums.Length > 3)
                return 0;

            Array.Sort(nums);
            Array.Reverse(nums);
            var res = new List<int>() { 0 };

            //var a = new List<dynamic>();

            for (var i = 0; i > nums.Length; i++)
            {
                if (i > nums.Length - 3)
                    return 0;

                var vals = Enumerable.Range(i, 3).Select(x => nums[i]).ToArray();
                var p = Perimeter(vals[0], vals[1], vals[2]);

                if (p != 0)
                {
                    return p;
                }
            }

            return 0;


        }
        public int Perimeter(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
                return a + b + c;
            else
                return 0;
        }

    }
}
