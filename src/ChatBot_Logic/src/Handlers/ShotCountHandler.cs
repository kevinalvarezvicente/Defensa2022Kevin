using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    /// Handler que cuenta la cantidad de tiros
    /// Es subclase de BaseHandler
    /// Forma parte de Chain of fResponsibility
    /// </summary>
    public class ShotCountHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ShotCountHandler"/>. Esta clase procesa el mensaje "/count".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ShotCountHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/count");
        }
        /// <summary>
        /// Es el método donde se trabaja todo lo del handler.
        /// Procesa el mensaje "/count"
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        /// <param name="response">Respuesta del bot</param>
        /// <returns>retorna un booleano de que será true si trabaja como corresponde</returns>
        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message)) //Si la Keyword o el Id del Usuario entra se procesa este handler.
            {
                Game game = GamesContainer.VerifyUserOnGame(message.From.Id);

                if (!chainData.userPostionHandler[from][0].Equals("/count"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0) //La primera iteracion del handler 
                {
                    chainData.userPostionHandler[from].Add("/countf"); //Persistimos en handler que esta ejecutando el usuario.
                    response = "Deseas obtener el /WaterShotCount o el /ShipShotCount ?";
                    this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords 
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 1 && message.Text == "/WaterShotCount") //La segunda iteración, caso mensaje "Si"
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la segunda iteración.
                    response = game.GetWaterShot.ToString();
                    this.Keywords.Remove(from); //Removemos el id asi el siguiente mensaje enviado sera evalaudo por
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 1 && message.Text == "/ShipShotCount") //La segunda iteración, caso mensaje "No"
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la segunda iteración.
                    response = game.GetShipShot.ToString();
                    this.Keywords.Remove(from); //Removemos el id asi sigue el handler
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}