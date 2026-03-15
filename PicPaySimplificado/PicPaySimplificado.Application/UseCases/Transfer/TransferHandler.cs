using PicPaySimplificado.Application.Interfaces;
using PicPaySimplificado.Domain.Entities;
using PicPaySimplificado.Domain.Repositories;

namespace PicPaySimplificado.Application.UseCases.Transfer
{
    public class TransferHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly INotificationService _notificationService;


        public TransferHandler(
            IUserRepository userRepository,
            ITransactionRepository transactionRepository,
            IAuthorizationService authorizationService,
            INotificationService notificationService)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _authorizationService = authorizationService;
            _notificationService = notificationService;
        }


        public async Task Handle(TransferCommand command)
        {
            var sender = await _userRepository.GetByIdAsync(command.SenderId);
            var receiver = await _userRepository.GetByIdAsync(command.ReceiverId);

            // Verificar se o remetente e destinatário existem
            if (sender == null) 
                throw new Exception("Pagador/Remetente não identificado");
            

            if (receiver == null) 
                throw new Exception("Destino não identificado");
            

            // Verificar se o remetente é um lojista
            if (sender.IsStore()) 
                throw new Exception("Lojista não pode enviar dinheiro!");
                

            var authorized = await _authorizationService.Authorize();

            if (!authorized)
                throw new Exception("Transferência não autorizada");

            var transaction = new Transaction(sender.Id, receiver.Id, command.Amount);

            await _transactionRepository.Save(transaction);

            await _notificationService.Notify(receiver);
            
        }
    }
}
