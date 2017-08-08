using BusinessLogicLayerInterfaces.DataTransferObjects;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    /// <summary>
    /// Interface for working with Answer
    /// </summary>
    public interface IAnswerService
    {
        void UpdateAnswer(AnswerDTO answer);
    }
}
