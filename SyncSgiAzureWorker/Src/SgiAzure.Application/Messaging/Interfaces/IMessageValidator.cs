namespace Application.Messaging.Interfaces
{
    /// <summary>
    /// Valida un DTO antes de ser procesado por un handler.
    /// 
    /// Permite que el pipeline rechace mensajes inválidos y los envíe a DLQ,
    /// evitando que lógica de dominio reciba datos corruptos.
    /// </summary>
    public interface IMessageValidator<in TMessage>
    {
        /// <summary>
        /// Lanza excepción si el mensaje no es válido
        /// </summary>
        /// <param name="message">Mensaje a validar</param>
        void Validate(TMessage message);
    }
}
