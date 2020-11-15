namespace _03.TelephonyM1
{
    using System.Linq;

    public class StationaryPhone : IDialable
    {
        public bool DialPhoneNumber(string phoneNumber)
            => (phoneNumber.ToCharArray().All(x => char.IsDigit(x))) && phoneNumber.Length == 7;
    }
}
