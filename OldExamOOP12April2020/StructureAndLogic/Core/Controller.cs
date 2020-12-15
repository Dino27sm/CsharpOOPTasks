using CounterStrike.Core.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Maps;
using System;
using System.Linq;
using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Players;
using CounterStrike.Models.Guns.Contracts;
using System.Reflection;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            switch (type)
            {
                case "Pistol":
                    this.guns.Add(new Pistol(name, bulletsCount));
                    break;
                case "Rifle":
                    this.guns.Add(new Rifle(name, bulletsCount));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
                    break;
            }
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun getGun = this.guns.FindByName(gunName);
            if (getGun == null)
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);

            switch (type)
            {
                case "Terrorist":
                    this.players.Add(new Terrorist(username, health, armor, getGun));
                    break;
                case "CounterTerrorist":
                    this.players.Add(new CounterTerrorist(username, health, armor, getGun));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
                    break;
            }
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(y => y.Health)
                .ThenBy(z => z.Username))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            return map.Start(this.players.Models.ToList());
        }
    }
}
