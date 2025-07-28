using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public Guid BookId { get; set; }
    }
}
