namespace Game_Logic.Shot
{
    /// <summary>
    /// Clase que gestiona los tiros hechos al agua.
    /// </summary>
    public class WaterShot : ShotC
    {
        private int waterShotCount = 0;

        /// <summary>
        /// Constructor de la clase WaterShot que hereda el constructor de suu padre.
        /// </summary>
        public WaterShot() : base()
        {
        }
        /// <summary>
        /// Metodo que cuenta la cantidad de tiros al agua hechos por ambos jugadores
        /// </summary>
        public override void AddCount()
        {
            this.waterShotCount = this.waterShotCount + 1;
        }
        /// <summary>
        /// Obtiene la cantidad de tiros al agua realizados.
        /// </summary>
        public int WaterShotCount
        {
            get
            {
                return this.waterShotCount;
            }
        }

    }
}
