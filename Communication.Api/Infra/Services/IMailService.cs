using Communication.Api.ViewModel;

namespace Communication.Api.Infra.Services
{
    public interface IMailService
    {
        void SendMail(UserRequest request);
    }
}
