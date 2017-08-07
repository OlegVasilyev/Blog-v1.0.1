using BusinessLogicLayerInterfaces.DataTransferObjects;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IAnswerService
    {
        void UpdateAnswer(AnswerDTO answer);
    }
}
