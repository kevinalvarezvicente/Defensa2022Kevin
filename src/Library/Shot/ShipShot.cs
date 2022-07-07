namespace Game_Logic.Shot
{
    /// <summary>
    /// Clase que gestiona los tiros hechos a barcos.
    /// </summary>
    public class ShipShot : ShotC
    {
        private int shipShopCount = 0;
        /// <summary>
        /// Constructor de la clase ShipShot que hereda el constructor de suu padre.
        /// </summary>
        public ShipShot() : base()
        {
        }
        /// <summary>
        /// Metodo que cuenta la cantidad de tiros al agua hechos por ambos jugadores
        /// </summary>
        public override void AddCount()
        {
            this.shipShopCount = this.shipShopCount + 1;
        }
        /// <summary>
        /// Obtiene la cantidad de tiros a barcos realizados.
        /// </summary>
        public int ShipShopCount
        {
            get
            {
                return this.shipShopCount;
            }
        }
    }
}
