using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Program
	{
		public static string ArrayChallenge(string[] strArr)
		{
			var arr = new List<int[]>();
			foreach (var item in strArr)
			{
				arr.Add(GetTimeInMinutes(item));
			}
			var largestBreak = LargestBreak(arr);
			return ConvertIntToTimeFormat(largestBreak); 
		}

		private static double LargestBreak(List<int[]> arr)
		{
			var largestTime = 0;
			var index = arr.Count - 2;
			arr = arr.Select(lst => lst.OrderBy(i => i).ToArray())
				.OrderBy(lst => lst[0])
				.ToList();
			for (var i = arr.Count - 1; i > 0; i--)
			{
				var item1 = (int[])arr[i];
				var item2 = (int[])arr[index];
				var breakTime = item1[0] - item2[1];
				if (breakTime > largestTime)
				{
					largestTime = breakTime;
				}
				index--;
			}
			return largestTime;
		}

		private static int[] GetTimeInMinutes(string item)
		{
			var firstHours = item.Substring(0, 2);
			var firstMinutes = item.Substring(3, 2);
			var secondHours = item.Substring(8, 2);
			var secondMinutes = item.Substring(11, 2);

			var arr = new int[2];
			if (item.Substring(5, 2) == "PM" && int.Parse(firstHours) != 12)
			{
				var totalMinutes = (int.Parse(firstHours) * 60) + int.Parse(firstMinutes) + 720;
				arr[0] = totalMinutes;
			}
			else
			{
				var totalMinutes = (int.Parse(firstHours) * 60) + int.Parse(firstMinutes);
				arr[0] = totalMinutes;
			}

			if (item.Substring(13, 2) == "PM" && int.Parse(secondHours) != 12)
			{
				var totalMinutes = (int.Parse(secondHours) * 60) + int.Parse(secondMinutes) + 720;
				arr[1] = totalMinutes;

			}
			if (item.Substring(13, 2) == "AM" && int.Parse(secondHours) == 12)
			{
				var totalMinutes = int.Parse(secondMinutes);
				arr[1] = totalMinutes;

			}
			else if (item.Substring(13, 2) == "PM" && int.Parse(secondHours) == 12)
			{
				var totalMinutes = (int.Parse(secondHours) * 60) + int.Parse(secondMinutes);
				arr[1] = totalMinutes;

			}
			else if (item.Substring(13, 2) == "AM" && int.Parse(secondHours) != 12)
			{
				var totalMinutes = (int.Parse(secondHours) * 60) + int.Parse(secondMinutes);
				arr[1] = totalMinutes;

			}
			return arr;
		}

		public static string ConvertIntToTimeFormat(double time)
		{
			var hours = Math.Floor(time / 60);
			var minutes = (time % 60);
			var minVal = minutes.ToString();
			var hourVal = hours.ToString();
			if (hours < 10)
			{
				hourVal = "0" + hours.ToString();
			}
			if (minutes < 10)
			{
				minVal = "0" + minutes.ToString();
			}
			return $"{ hourVal}:{ minVal}";
		}

		static void Main(string[] args)
		{
			// keep this function call here
			var arr = new string[] { "07:00AM-08:00AM", "09:00AM-10:00AM", "10:00PM-11:00PM" };
			Console.WriteLine(ArrayChallenge(arr));
			Console.ReadLine();
		}
	}
}
