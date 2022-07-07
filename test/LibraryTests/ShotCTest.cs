using Game_Logic.Shot;
using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;
using System;

namespace LibraryTests
{
    public class ShotCTest
    {

        private Player playerPaco;
        private Player playerAugust;
        private Game game;
        private ShipShot shipShot;
        private WaterShot waterShot;
        /// <summary>
        /// Suimulamos la creacion de un juego con sus correspondientes objetos.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            User userPaco = new User(2046982637, "Alvarez", "Paco");
            User userAugust = new User(2046982637, "Vicente", "August");
            UsersContainer.usersContainer.Add(userPaco);
            UsersContainer.usersContainer.Add(userAugust);
            playerPaco = new Player(userPaco);
            Player playerAugust = new Player(userAugust);
            playerPaco.AddPlayerShipBoard(new ShipBoard(7));
            playerPaco.AddPlayerShotBoard(new ShotBoard(7));
            playerAugust.AddPlayerShipBoard(new ShipBoard(7));
            playerAugust.AddPlayerShotBoard(new ShotBoard(7));
            game = new Game(playerPaco, playerAugust);
            GamesContainer.AddGame(game);
            shipShot = new ShipShot();
            waterShot = new WaterShot();
            Ship frigate = new Frigate("10", "H");
            playerPaco.PlaceShipOnBoard(frigate);
            playerAugust.PlaceShipOnBoard(frigate);

        }

        /// <summary>
        ///     Testeo del metodo AddCount de la clase WaterShot
        /// </summary>
        [Test]
        public void AddCountWaterShot()
        {
            waterShot.AddCount();
            String response = waterShot.WaterShotCount.ToString();
            Assert.That(response, Is.EqualTo("1"));
        }

        /// <summary>
        ///     Testeo del metodo AddCount de la clase ShipShot
        /// </summary>
        [Test]
        public void AddCountShipShot()
        {
            shipShot.AddCount();
            shipShot.AddCount();
            String response = shipShot.ShipShopCount.ToString();
            Assert.That(response, Is.EqualTo("2"));
        }

        /// <summary>
        ///     Testeo de tiro a agua de un player.
        /// </summary>
        [Test]
        public void AddCountWaterShotGame()
        {
            game.ShotMade("04");
            String response = game.GetWaterShot.ToString();
            Assert.That(response, Is.EqualTo("1"));
        }

        /// <summary>
        ///     Testeo el tiro a barco de un player.
        /// </summary>
        [Test]
        public void AddCountShipShotGame()
        {
            game.ShotMade("10");
            String response = game.GetShipShot.ToString();
            Assert.That(response, Is.EqualTo("1"));
        }
    }
}
