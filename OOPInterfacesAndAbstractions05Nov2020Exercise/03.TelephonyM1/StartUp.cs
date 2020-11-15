using System;

namespace _03.TelephonyM1
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IBrowsable mobiPhone = new Smartphone();
            IDialable stationPhone = new StationaryPhone();

            string[] readPhoneNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] readUrl = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < readPhoneNum.Length; i++)
            {
                string currentNum = readPhoneNum[i];
                if (stationPhone.DialPhoneNumber(currentNum))
                    Console.WriteLine($"Dialing... {currentNum}");
                else if (mobiPhone.DialPhoneNumber(currentNum))
                    Console.WriteLine($"Calling... {currentNum}");
                else
                    Console.WriteLine("Invalid number!");
            }
            for (int i = 0; i < readUrl.Length; i++)
            {
                string currentUrl = readUrl[i];
                if (mobiPhone.BrowseSites(currentUrl))
                    Console.WriteLine($"Browsing: {currentUrl}!");
                else
                    Console.WriteLine("Invalid URL!");
            }
        }
    }
}
