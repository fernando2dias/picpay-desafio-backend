using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Application.DTOs;
using PicPaySimplificado.Application.UseCases.Transfer;

namespace PicPaySimplificado.API.Controllers
{
    [ApiController]
    [Route("api/transfer")]
    public class TransferController : ControllerBase
    {
        private readonly TransferHandler _handler;

        public TransferController(TransferHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(
            [FromBody] TransferRequest request)
        {
            var command = new TransferCommand
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                Amount = request.Amount
            };

            await _handler.Handle(command);

            return Ok(new { message = "Transferência realizada"});

        }

    }
}
