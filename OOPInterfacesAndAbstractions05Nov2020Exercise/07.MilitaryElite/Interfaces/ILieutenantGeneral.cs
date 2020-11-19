namespace _07.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        public ICollection<IPrivate> PrivatesList { get; set; }
    }
}
