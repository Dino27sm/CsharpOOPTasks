namespace _03.TelephonyM1
{
    using System.Linq;

    public class Smartphone : IBrowsable
    {
        public bool BrowseSites(string webSites)
            => (!webSites.ToCharArray().Any(x => char.IsDigit(x)));

        public bool DialPhoneNumber(string phoneNumber)
            => (phoneNumber.ToCharArray().All(x => char.IsDigit(x))) && phoneNumber.Length == 10;
    }
}
