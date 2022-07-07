namespace Game_Logic
{
    /// <summary>
    /// Clase de tipo abstracta ShotC que sera heredada por otros tipos de tiros para sobre escribir
    /// sus metodos.
    /// </summary>
    public abstract class ShotC
    {
        /// <summary>
        /// Conostructor de la clase, nos e piden parametros
        /// </summary>
        protected ShotC()
        {
            // Intencionalmente en blanco
        }
        /// <summary>
        /// Metodo en blanco que sera reescrito.
        /// </summary>
        public virtual void AddCount()
        {
            // Intencionalmente en blanco
        }
    }
}
