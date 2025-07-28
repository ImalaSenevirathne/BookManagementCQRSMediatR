using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Commands
{
    public class AddBookCommand : IRequest<Guid>
    {
        public string Title { get; set; } = null;
        public string Author { get; set; } = null;
    }
}
